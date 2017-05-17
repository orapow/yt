using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yt.Tiler
{
    public partial class Cut : Form
    {
        public Cut()
        {
            InitializeComponent();
        }

        PointF WorldToPixel(double lon, double lat, int zoom)
        {
            PointF p = new System.Drawing.Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom) * 256 % 256 + 0.5);
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom) * 256 % 256 + 0.5);
            return p;
        }

        PointF WorldToTilePos2(double lon, double lat, int zoom)
        {
            var topTileFromX = -180;
            var topTileFromY = 90;

            var tdtScale = new double[]
            {
                5.36441802978515E-06,
                1.07288360595703E-05,
                2.1457672119140625E-05,
                4.29153442382814E-05,
                8.58306884765629E-05,
                0.000171661376953125,
                0.00034332275390625,
                0.0006866455078125,
                0.001373291015625,
                0.00274658203125,
                0.0054931640625,
                0.010986328125,
                0.02197265625,
                0.0439453125,
                0.087890625,
                0.17578125,
                0.3515625,
                0.703125
            };

            //var strList = document.getElementById("content").value;


            var coef = tdtScale[18 - zoom] * 256;

            var x_num = (lon - topTileFromX) / coef;
            var y_num = (topTileFromY - lat) / coef;

            //  var dir =  "http://t7.tianditu.com/DataServer?T=vec_c&";
            // var server = "l="+String(level)+"&"+"x="+String(x_num)+"&"+"y="+String(y_num);


            //var dir = "http://t1.tianditu.cn/vec_c/wmts?SERVICE=WMTS&REQUEST=GetTile&STYLE=default&VERSION=1.0.0&LAYER=vec&TILEMATRIXSET=c&";
            //var server = "TILEMATRIX=" + String(level) + "&" + "TILEROW=" + String(y_num) + "&" + "TILECOL=" + String(x_num) + "&FORMAT=tiles";

            return new PointF() { X = (float)x_num, Y = (float)y_num };

            //var imageDir = dir + server;

            // alert(imageDir);

            //var imgDiv = document.getElementById("map");
            //imgDiv.style.backgroundImage = "url(" + imageDir + ")";


        }

        PointF WorldToTilePos(double lon, double lat, int zoom)
        {
            PointF p = new System.Drawing.Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom) - 2.0 / Math.Pow(2, (18 - zoom)));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) +
                1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom) - 2.0 / Math.Pow(2, (18 - zoom)));
            return p;
        }

        PointF TileToWorldPos(double tile_x, double tile_y, int zoom)
        {
            PointF p = new System.Drawing.Point();
            double n = Math.PI - ((2.0 * Math.PI * tile_y) / Math.Pow(2.0, zoom));

            p.X = (float)((tile_x / Math.Pow(2.0, zoom) * 360.0) - 180.0);
            p.Y = (float)(180.0 / Math.PI * Math.Atan(Math.Sinh(n)));

            return p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var pic = Bitmap.FromFile("");//img.Filename
            ////p.Save("d:\\s.jpg", ImageFormat.Jpeg);

            //var bmp = new Bitmap(256, 256);
            //var g = Graphics.FromImage(bmp);

            //var w = pic.Width;
            //var h = pic.Height;

            //var pt = new PointF() { X = (float)img.Extents.xMin, Y = (float)img.Extents.yMax };// img.Extents.xMin, img.Extents.yMax);

            //for (var l = 0; l <= 5; l++)
            //{
            //    var bp = new Bitmap(w, h);
            //    var gpic = Graphics.FromImage(bp);
            //    if (w == pic.Width) bp = (Bitmap)pic.Clone();
            //    else gpic.DrawImage(pic, new Rectangle(0, 0, w, h), new Rectangle(0, 0, pic.Width, pic.Height), GraphicsUnit.Pixel);

            //    var box = WorldToTilePos(pt.X, pt.Y, 18 - l);
            //    var ox = (int)((box.X - (int)box.X) * 256) % 256;
            //    var oy = (int)((box.Y - (int)box.Y) * 256) % 256;

            //    var y1 = (int)box.Y;

            //    for (var y = -oy; y <= pic.Height; y += 256)
            //    {
            //        var x1 = (int)box.X;
            //        for (var x = -ox; x <= pic.Width; x += 256)
            //        {
            //            g.Clear(Color.Transparent);
            //            g.DrawImage(bp, new Rectangle(0, 0, 256, 256), new Rectangle(x, y, 256, 256), GraphicsUnit.Pixel);
            //            bmp.Save("d:\\st\\tiles\\" + x1 + "_" + y1 + "_" + l + ".png", ImageFormat.Png);
            //            x1++;
            //        }
            //        y1++;
            //    }
            //    bp.Dispose();
            //    gpic.Dispose();
            //    w /= 2;
            //    h /= 2;
            //}

            //g.Dispose();
            //bmp.Dispose();
            //pic.Dispose();

        }

    }
}
