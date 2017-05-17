using Interop.MapWinGIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace X.Desk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                label1.Text = ofd.FileName;
            }
        }

        void showmap(int lv)
        {
            var shp = new Shapefile();
            shp.Open(label1.Text);

            var lt = WorldToGps(shp.Extents.xMin, shp.Extents.yMax, lv);
            var rt = WorldToGps(shp.Extents.xMax, shp.Extents.yMax, lv);
            var lb = WorldToGps(shp.Extents.xMin, shp.Extents.yMin, lv);

            var w = getdist(lt, rt); var h = getdist(lt, lb);

            var img = new Bitmap(8192, 8192);
            var g = Graphics.FromImage(img);
            for (var i = 0; i < shp.NumShapes; i++)
            {
                var sp = shp.Shape[i];
                var pts = new List<PointF>();
                for (var p = 0; p < sp.numPoints; p++)
                {
                    var lg = sp.Point[p];
                    var pot = WorldToGps(lg.x, lg.y, lv);
                    pot.X = (pot.X - lt.X) * 256;
                    pot.Y = (pot.Y - lt.Y) * 256;
                    pts.Add(pot);
                }
                g.DrawPolygon(Pens.Red, pts.ToArray());
            }
            g.Dispose();
            img.Save("d:\\ss.jpg");
            pictureBox1.Image = img;
        }

        private int getdist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }

        Color RGB(int color)
        {
            int r = 0xFF & color;
            int g = 0xFF00 & color;
            g >>= 8;
            int b = 0xFF0000 & color;
            b >>= 16;
            return Color.FromArgb(r, g, b);
        }

        PointF WorldToGps(double lon, double lat, int zoom)
        {
            PointF p = new System.Drawing.Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            showmap((int)numericUpDown1.Value);
        }
    }
}
