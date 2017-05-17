using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace X.Pub
{
    public partial class Tile : Form
    {
        class img
        {
            public Image bmp { get; set; }
            public Point pos { get; set; }
            public Point tpos { get; set; }
            public PointF gps { get; set; }
            public int level { get; set; }
        }
        //List<Tn> tns = null;
        List<img> imgs = null;
        //int maxlev = 18;

        #region 
        public Tile()
        {
            InitializeComponent();
            //this.tns = tns;
            //var c = (int)Math.Ceiling(Math.Sqrt(tns.Count()));
            //num_col.Value = c;
            //lb_count.Text = "图片数：" + tns.Count() + " 张";
            //cb_filetype.SelectedIndex = 0;
            //cb_tilexytype.SelectedIndex = 0;
            //Text = "输出瓦片 " + tns[0].Text;
        }

        //private void tlb_layout(int r, int c)
        //{
        //    tlp_layout.RowStyles.Clear();
        //    tlp_layout.ColumnStyles.Clear();

        //    var w = (int)Math.Floor(236.0 / Math.Max(r, c));

        //    for (var i = 0; i < r; i++) tlp_layout.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100 / r));
        //    for (var i = 0; i < c; i++) tlp_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100 / c));

        //    tlp_layout.ColumnCount = c;
        //    tlp_layout.RowCount = r;

        //    int x = 0, y = 0;
        //    foreach (var t in tns)
        //    {
        //        tlp_layout.Controls.Add(new PictureBox() { Dock = DockStyle.Fill, Image = t.img }, x, y);
        //        x++;
        //        if (x == c) { x = 0; c++; }
        //    }
        //}

        private void num_col_ValueChanged(object sender, EventArgs e)
        {
            var col = (int)num_col.Value;
            flowLayoutPanel1.Controls.Clear();
            var row = (int)Math.Ceiling(imgs.Count() / (decimal)col);
            var i = 0;
            for (var r = 0; r < row; r++)
            {
                var fl = new FlowLayoutPanel() { WrapContents = false, Margin = new Padding(0), Padding = new Padding(0), Width = col * 48, Height = 48 };
                for (var c = 0; c < col; c++)
                {
                    if (i >= imgs.Count()) break;
                    fl.Controls.Add(new PictureBox() { Image = imgs[i++].bmp, Margin = new Padding(0), Width = 48, Height = 48 });
                }
                flowLayoutPanel1.Controls.Add(fl);
                if (i >= imgs.Count()) break;
            }
            //flowLayoutPanel1.WrapContents = false;
            //flowLayoutPanel1.SetBounds(0, 0, 48 * col, 48 * (flowLayoutPanel1.Controls.Count / col));
            //for (var i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            //{
            //    var pb = flowLayoutPanel1.Controls[i];
            //    flowLayoutPanel1.SetFlowBreak(pb, i > 0 && i % col == 0);
            //}
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            imgs = new List<img>();
            bt_start.Enabled = false;
            var fp = lb_outdir.Text + "\\tiles";
            if (!Directory.Exists(fp)) Directory.CreateDirectory(fp);

            var ed = Encoder.Quality;
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(ed, tb_setquality.Value);
            var ftype = cb_filetype.SelectedItem.ToString().ToLower();
            var fname = tb_filename.Text;
            var fpre = tb_lfpre.Text;

            new Thread(p =>
            {
                ////foreach (var t in tns)
                ////{
                ////var t = new { data = "" };// tns[0];
                //var img = new { Filename = "" };///(t.data as Interop.MapWinGIS.Image);
                //var pic = Image.FromFile(img.Filename);

                //var lv = maxlev;
                //var demo = cb_demo.Checked;

                //for (; lv > 0; lv--)
                //{
                //    //var lt = WorldToGps(img.Extents.xMin, img.Extents.yMax, lv);
                //    //var rt = WorldToGps(img.Extents.xMax, img.Extents.yMax, lv);
                //    //var lb = WorldToGps(img.Extents.xMin, img.Extents.yMin, lv);

                //    //var w = getdist(lt, rt); var h = getdist(lt, lb);

                //    //if (w < 256) break;

                //    //var lp = fp + "\\" + fpre + lv;
                //    //if (!Directory.Exists(lp)) Directory.CreateDirectory(lp);

                //    //var rw = w / (decimal)pic.Width;
                //    //var rh = h / (decimal)pic.Height;
                //    //var bw = (int)Math.Ceiling(256 / rw);
                //    //var bh = (int)Math.Ceiling(256 / rh);

                //    //var bmp = new Bitmap(256, 256);
                //    //var g = Graphics.FromImage(bmp);

                //    //var pos = new Point() { X = (int)((lt.X - (int)lt.X) * 256) % 256, Y = (int)((lt.Y - (int)lt.Y) * 256) % 256 };
                //    //var ofset = new Point() { X = (int)(pos.X / rw), Y = (int)(pos.Y / rh) };

                //    //var _w = (int)Math.Ceiling((float)pic.Width / bw) + 1;
                //    //var _h = (int)Math.Ceiling((float)pic.Height / bh) + 1;

                //    //var count = _w * _h;
                //    //var c = 1;
                //    //for (var i = 0; i < _w; i++)
                //    //{
                //    //    for (var j = 0; j < _h; j++)
                //    //    {
                //    //        g.Clear(ftype == "png" ? Color.Transparent : Color.White);
                //    //        if (i == 0 && j == 0)
                //    //            g.DrawImage(pic, new Rectangle(pos.X, pos.Y, bmp.Width, bmp.Height), new Rectangle(0, 0, bw, bh), GraphicsUnit.Pixel);
                //    //        else if (i == 0)
                //    //            g.DrawImage(pic, new Rectangle(pos.X, 0, bmp.Width, bmp.Height), new Rectangle(0, (j - 1) * bh + (bh - ofset.Y), bw, bh), GraphicsUnit.Pixel);
                //    //        else if (j == 0)
                //    //            g.DrawImage(pic, new Rectangle(0, pos.Y, bmp.Width, bmp.Height), new Rectangle((i - 1) * bw + (bw - ofset.X), 0, bw, bh), GraphicsUnit.Pixel);
                //    //        else
                //    //            g.DrawImage(pic, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle((i - 1) * bw + (bw - ofset.X), (j - 1) * bh + (bh - ofset.Y), bw, bh), GraphicsUnit.Pixel);

                //    //        if (cb_setwm.Checked && pb_wmimg.Image != null) g.DrawImage(pb_wmimg.Image, 0, 0);

                //    //        var fn = fname.Replace("{x}", (int)(lt.X + i) + "").Replace("{y}", (int)(lt.Y + j) + "") + "." + ftype;
                //    //        if (ftype == "jpg") bmp.Save(lp + "\\" + fn, ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid), eps);
                //    //        else bmp.Save(lp + "\\" + fn, ImageFormat.Png);

                //    //        showtip("正在输出第：" + lv + "层，切片：" + fn + "。" + c + "/" + count + "(" + (c++ / (float)count * 100).ToString("F2") + "%)");

                //    //    }
                //    //}
                //    //g.Dispose();
                //    //bmp.Dispose();
                //}
                //pic.Dispose();
                //eps.Dispose();
                //Invoke((Action)(() =>
                //{
                //    bt_start.Enabled = true;
                //}));
                //showtip("切片完成！");
                ////}

                //var dir = fp.Substring(0, fp.LastIndexOf('\\'));
                //if (demo)
                //{
                //    var html = Properties.Resources.demo;
                //    html = html.Replace("$name", t.Name).Replace("$lng", img.Extents.Center.x + "").Replace("$lat", img.Extents.Center.y + "").Replace("$ft", ftype).Replace("$lv", "15");
                //    File.WriteAllText(dir + "\\demo.html", html);
                //    Process.Start(dir + "\\demo.html");
                //}
                //else
                //{
                //    Process.Start(dir);
                //}

            }).Start();

        }
        #endregion

        void showtip(string txt)
        {
            Invoke((Action)(() => { tlb_tip.Text = txt; }));
        }

        PointF WorldToMercator(double lon, double lat, int zoom)
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

            var coef = tdtScale[19 - zoom] * 256;

            var x_num = (lon - topTileFromX) / coef;
            var y_num = (topTileFromY - lat) / coef;

            return new PointF() { X = (float)x_num, Y = (float)y_num };

        }

        PointF WorldToGps(double lon, double lat, int zoom)
        {
            PointF p = new Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }

        private int getdist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }

        private void btn_setoutdir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                lb_outdir.Text = fbd.SelectedPath;
            }
        }

        private void cb_setwm_CheckedChanged(object sender, EventArgs e)
        {
            gb_wm.Enabled = cb_setwm.Checked;
        }

        private void cb_filetype_SelectedValueChanged(object sender, EventArgs e)
        {
            gb_filetype.Enabled = cb_filetype.SelectedItem + "" == "Jpg";
        }

        private void pb_wmimg_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "图片文件(*.jpg,*.png)|*.jpg;*.png;";
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var img = Image.FromFile(ofd.FileName);
            if (img.Width != 256 || img.Height != 256) MessageBox.Show("水印图片需为256*256");
            else { pb_wmimg.Tag = img; tb_wmtran.Value = 60; }
        }

        private void tb_wmtran_ValueChanged(object sender, EventArgs e)
        {
            if (pb_wmimg.Tag == null) return;
            var img = new Bitmap(256, 256);
            var g = Graphics.FromImage(img);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float[][] nArray ={
                new float[] {2, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, (float)(tb_wmtran.Value/100.0), 0},
                new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(nArray);
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(pb_wmimg.Tag as Image, new Rectangle(0, 0, 256, 256), 0, 0, 256, 256, GraphicsUnit.Pixel, attributes);
            pb_wmimg.Image = img;
            g.Dispose();
            lb_wmtran.Text = "透明度：" + tb_wmtran.Value + "%";
        }

        private void tb_setquality_ValueChanged(object sender, EventArgs e)
        {
            lb_quality.Text = "Jpg质量：" + tb_setquality.Value;
        }

        private void tb_lfpre_TextChanged(object sender, EventArgs e)
        {
            label3.Text = tb_lfpre.Text + "1";
        }

        private void bt_addpic_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgs = new List<img>();
                foreach (var f in ofd.FileNames)
                {
                    imgs.Add(new img() { bmp = gettum(f) });
                }
                //var pb = new PictureBox();
                //pb.Margin = new Padding(-1, -1, 0, 0);
                //pb.Width = pb.Height = 48;
                //pb.BorderStyle = BorderStyle.FixedSingle;
                //pb.Image = gettum(f);
                //flowLayoutPanel1.Controls.Add(pb);
            }
        }
        Image gettum(string f)
        {
            var img = Image.FromFile(f);
            var bmp = img.GetThumbnailImage(48, 48, () => { return true; }, IntPtr.Zero);
            img.Dispose();
            return bmp;
        }
    }
}
