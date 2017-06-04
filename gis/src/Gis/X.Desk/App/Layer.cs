using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace X.Desk
{
    public abstract class Layer
    {
        public Extend ext { get; set; }
        public string file { get; set; }
        /// <summary>
        /// 1、图形
        /// 2、图像
        /// </summary>
        public int tp { get; protected set; }

        public abstract void DrawImage(RectangleF rect, RectangleF full, int lv, Graphics g);

        public override string ToString()
        {
            return (tp == 1 ? "图形" : "图像") + " " + file.Substring(file.LastIndexOf('\\') + 1);
        }
    }

    public class ImgLayer : Layer
    {
        public ImgLayer()
        {
            tp = 2;
        }

        public override void DrawImage(RectangleF rect, RectangleF full, int lv, Graphics g)
        {
            var rg_lay = Utils.GetRect(ext, lv);

            var px = (int)((rg_lay.X - full.X) * 256 - rect.X);
            var py = (int)((rg_lay.Y - full.Y) * 256 - rect.Y);

            if (px + rg_lay.Width < 0 || py + rg_lay.Height < 0) return;
            if (px > rect.Width || py > rect.Height) return;

            var tif = new Tiff(file);
            var bmp = tif.Pics[0].GetImage(new Rectangle(px, py, 4096, 4096), new Size((int)rg_lay.Width, (int)rg_lay.Height));
            if (bmp == null) return;
            g.DrawImage(bmp, Math.Max(px, 0), Math.Max(py, 0));
            bmp.Dispose();
            GC.Collect();

            Debug.WriteLine("draw->" + file);

        }
    }

    public class ShpLayer : Layer
    {
        public List<Shape> Shapes { get; set; }
        public DrawStyle Style { get; set; }

        public ShpLayer()
        {
            tp = 1;
        }

        List<PointF> getPoints(List<PointF> pts, float x1, float y1, float x2, float y2, int lv)
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

        public override void DrawImage(RectangleF rect, RectangleF full, int lv, Graphics g)
        {
            if (Shapes == null) return;

            var rg_lay = Utils.GetRect(ext, lv);
            //if (rg_lay.X + rect.X < full.X || rg_lay.Y + y < full.Y) return;
            //if (rg_lay.X + x + 4096 < full.X || rg_lay.Y + y + 4096 < full.Y) return;
            //if (rg_lay.X + x > full.X + 4096 || rg_lay.Y + y > full.Y + 4096) return;

            foreach (var s in Shapes)
            {
                var pts = new List<PointF>();
                var _pts = new List<PointF>();
                foreach (var k in s.Points.Keys)
                {
                    var ps = getPoints(s.Points[k], full.X, full.Y, rect.X, rect.Y, lv);
                    if (Style.BorderWidth > 0) g.DrawLines(new Pen(Color.FromArgb(Style.BorderTran, Style.BorderColor), Style.BorderWidth), ps.ToArray());
                    pts.AddRange(ps);
                    _pts.Add(ps[0]);
                }
                _pts.Reverse();
                foreach (var p in _pts) pts.Add(p);
                if (s.Tp == 3 || s.Tp == 13) g.DrawLines(new Pen(Color.FromArgb(Style.BorderTran, Style.BorderColor), Style.BorderWidth), pts.ToArray());
                else if (s.Tp == 5 || s.Tp == 15)
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(Style.FillTran, Style.FillColor)), pts.ToArray());
                }
            }
        }

        public class DrawStyle
        {
            public int BorderWidth { get; set; }
            public int BorderTran { get; set; }
            public Color BorderColor { get; set; }
            public int FillTran { get; set; }
            public Color FillColor { get; set; }
        }
    }
}
