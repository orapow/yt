using Interop.MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X.Gis;

namespace X.Desk
{
    public partial class PreView : Form
    {
        Extend extends = null;
        List<Layer> layers = null;
        RectangleF rg_full = RectangleF.Empty;
        double x = 0.0;
        double y = 0.0;
        int lv = 12;

        public PreView(List<Layer> lays, Extend exts)
        {
            InitializeComponent();
            layers = lays;
            extends = exts;
            drawImage();
            pb_view.MouseWheel += Pb_view_MouseWheel;
        }

        private void Pb_view_MouseWheel(object sender, MouseEventArgs e)
        {
        }

        void drawImage()
        {
            var dt = DateTime.Now;
            var img = new Bitmap(pb_view.Width, pb_view.Height);
            var g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Clear(Color.Transparent);

            rg_full = getRect(extends, lv);

            var ox = (pb_view.Width - rg_full.Width) / 2;
            var oy = (pb_view.Height - rg_full.Height) / 2;

            foreach (var ly in layers)
            {
                var rg_lay = getRect(ly.Extends, lv);
                if (ly.Tp == 2)
                {
                    var shp = new Shapefile();
                    shp.Open(ly.File);
                    shp.FastMode = true;
                    for (var i = 0; i < shp.NumShapes; i++)
                    {
                        var sp = shp.Shape[i];
                        for (var j = 0; j < sp.NumParts; j++)
                        {
                            var pa = sp.PartAsShape[j];
                            var pts = new List<PointF>();
                            for (var p = 0; p < pa.numPoints; p++)
                            {
                                var pt = pa.Point[p];
                                var pot = WorldToGps(pt.x, pt.y, lv);
                                pot.X = (pot.X - rg_full.X) * 256 + (float)x + ox;
                                pot.Y = (pot.Y - rg_full.Y) * 256 + (float)y + oy;
                                pts.Add(pot);
                            }
                            if (sp.ShapeType == ShpfileType.SHP_POLYGON)
                            {
                                if (pts[0].X != pts[pa.numPoints - 1].X && pts[0].Y != pts[pa.numPoints - 1].Y) continue; g.DrawPolygon(Pens.Red, pts.ToArray());
                                if (!pa.PartIsClockWise[j]) g.FillPolygon(new SolidBrush(Color.FromArgb(100, Color.Green)), pts.ToArray());
                                else g.FillPolygon(new SolidBrush(Color.FromArgb(0, Color.White)), pts.ToArray());
                            }
                            else if (sp.ShapeType == ShpfileType.SHP_POLYLINE) g.DrawLines(Pens.Red, pts.ToArray());
                        }
                    }
                    shp.Close();
                }
                else if (ly.Tp == 1)
                {
                    var tif = new Tiff(ly.File);
                    var px = (int)((rg_lay.X - rg_full.X) * 256 + (float)x + ox);
                    var py = (int)((rg_lay.Y - rg_full.Y) * 256 + (float)y + oy);
                    var bmp = tif.Pics[0].GetImage(new Rectangle(px, py, img.Width, img.Height), new Size((int)rg_lay.Width, (int)rg_lay.Height));
                    if (bmp == null) continue;
                    g.DrawImage(bmp, Math.Max(px, 0), Math.Max(py, 0));
                    bmp.Dispose();
                }
            }
            g.Dispose();
            pb_view.Image = img;
            tssl_tip.Text = "层级：" + lv + "，范围：";
            tssl_cost_time.Text = "耗时:" + ((DateTime.Now - dt).TotalMilliseconds / 1000.0).ToString("F3") + "s";
        }

        private RectangleF getRect(Extend ext, int lv)
        {
            var lt = WorldToGps(ext.XMin, ext.YMax, lv);
            var rt = WorldToGps(ext.XMax, ext.YMax, lv);
            var lb = WorldToGps(ext.XMin, ext.YMin, lv);

            return new RectangleF(lt.X, lt.Y, getdist(lt, rt), getdist(lt, lb));
        }

        private int getdist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }

        PointF WorldToGps(double lon, double lat, int zoom)
        {
            PointF p = new System.Drawing.Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }

        private void tsb_zoomIn_Click(object sender, EventArgs e)
        {
            lv--;
            if (lv <= 1) lv = 2;
            else
            {
                x /= 2;
                y /= 2;
            }
            drawImage();
        }

        private void tsb_zoomOut_Click(object sender, EventArgs e)
        {
            lv++;
            if (lv >= 21) lv = 20;
            else { x *= 2; y *= 2; }
            drawImage();
        }

        private void bt_m_tp_Click(object sender, EventArgs e)
        {
            y += 100;
            drawImage();
        }

        private void bt_m_bt_Click(object sender, EventArgs e)
        {
            y -= 100;
            drawImage();
        }

        private void bt_m_lt_Click(object sender, EventArgs e)
        {
            x += 100;
            drawImage();
        }

        private void bt_m_rt_Click(object sender, EventArgs e)
        {
            x -= 100;
            drawImage();
        }

        private void bt_m_ct_Click(object sender, EventArgs e)
        {
            x = 0; y = 0;
            drawImage();
        }

        private void tsb_full_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            bt_un_full.Visible = true;
        }

        private void bt_un_full_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            TopMost = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            bt_un_full.Visible = false;
        }

        private void PreView_SizeChanged(object sender, EventArgs e)
        {
            drawImage();
        }
    }
}
