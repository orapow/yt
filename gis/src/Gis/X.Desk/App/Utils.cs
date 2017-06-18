using MapWinGIS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using X.Gis;

namespace X.Desk
{
    public class Utils
    {
        public static int GetDist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }
        public static RectangleF GetRect(Extend ext, int lv)
        {
            var lt = WorldToGps(ext.xMin, ext.yMax, lv);
            var rt = WorldToGps(ext.xMax, ext.yMax, lv);
            var lb = WorldToGps(ext.xMin, ext.yMin, lv);
            return new RectangleF(lt.X, lt.Y, GetDist(lt, rt), GetDist(lt, lb));
        }
        public static PointF WorldToGps(double lon, double lat, int zoom)
        {
            var p = new PointF();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }
        public static PointF GpsToWorld(float x, float y, int zoom)
        {
            var p = new PointF();
            p.X = x / (1 << zoom) * 360 - 180; //(float)(x / 256.0 / (1 << zoom)) * 360 - 180;
            p.Y = (float)(Math.Atan(Math.Sinh(Math.PI - 2 * Math.PI * y / (1 << zoom))) * 180 / Math.PI);
            return p;
        }

        public static void DrawImage(Layer lay, RectangleF rect, RectangleF full, int lv, Graphics g)
        {
            if (lay.Tp == 1)
            {
                var rg_lay = GetRect(lay.Extends, lv);
                var px = (int)((rg_lay.X - full.X) * 256 - rect.X);
                var py = (int)((rg_lay.Y - full.Y) * 256 - rect.Y);

                if (px + rg_lay.Width < 0 || py + rg_lay.Height < 0) return;
                if (px > rect.Width || py > rect.Height) return;

                var tif = new Tiff(lay.File);
                var bmp = tif.Pics[0].GetImage(new Rectangle(px, py, (int)rect.Width, (int)rect.Height), new Size((int)rg_lay.Width, (int)rg_lay.Height));
                if (bmp == null) return;
                g.DrawImage(bmp, Math.Max(px, 0), Math.Max(py, 0));
                bmp.Dispose();
                GC.Collect();
            }
            else
            {
                var l = lay as ShpLayer;
                if (l.Shapes == null) return;
                foreach (var s in l.Shapes)
                {
                    var pts = new List<PointF>();
                    var _pts = new List<PointF>();
                    foreach (var k in s.Points.Keys)
                    {
                        var ps = getPoints(s.Points[k], full.X, full.Y, rect.X, rect.Y, lv);
                        pts.AddRange(ps);
                        _pts.Add(ps[0]);
                    }
                    if (s.Tp == 3 || s.Tp == 13)
                    {
                        if (l.Style.BorderWidth > 0)
                            g.DrawLines(new Pen(Color.FromArgb(l.Style.BorderTran, l.Style.BorderColor), l.Style.BorderWidth), pts.ToArray());
                    }
                    else if (s.Tp == 5 || s.Tp == 15)
                    {
                        _pts.Reverse();
                        pts.AddRange(_pts);
                        g.FillPolygon(new SolidBrush(Color.FromArgb(l.Style.FillTran, l.Style.FillColor)), pts.ToArray());
                    }
                }
            }
            Debug.WriteLine("draw->" + lay.File);
        }
        static List<PointF> getPoints(List<PointF> pts, float x1, float y1, float x2, float y2, int lv)
        {
            var _pts = new List<PointF>();
            foreach (var p in pts)
            {
                var pot = Utils.WorldToGps(p.X, p.Y, lv);
                pot.X = (pot.X - x1) * 256 - x2;
                pot.Y = (pot.Y - y1) * 256 - y2;
                _pts.Add(pot);
            }
            return _pts;
        }
    }
}
