using Interop.MapWinGIS;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using X.Core.Utility;

namespace X.Desk
{
    public partial class Down : Form
    {
        private Extents extents = null;
        private string path = "";
        private int mtype = 0;
        private bool stop = false;
        public Down(Extents ext)
        {
            InitializeComponent();
            cb_source.SelectedIndex = 0;
            extents = ext;

            tb_xmin.Text = ext.xMin.ToString("F8");
            tb_xmax.Text = ext.xMax.ToString("F8");
            tb_ymin.Text = ext.yMax.ToString("F8");
            tb_ymax.Text = ext.yMin.ToString("F8");

            cb_minlev.SelectedIndex = 14;
            cb_maxlev.SelectedIndex = 18;
            cb_map_type.SelectedIndex = 0;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            var minlev = int.Parse(cb_minlev.SelectedItem + "");
            var maxlev = int.Parse(cb_maxlev.SelectedItem + "");

            path = lb_outdir.Text;
            mtype = cb_map_type.SelectedIndex;
            bt_start.Enabled = false;
            bt_stop.Enabled = true;

            stop = false;
            for (var l = minlev; l <= maxlev; l++)
            {
                new Thread(o =>
                {
                    startDownLoad(o as md);
                }).Start(new md()
                {
                    lv = l,
                    pe = WorldToGps(extents.xMin, extents.yMin, l),
                    ps = WorldToGps(extents.xMax, extents.yMax, l)
                });
            }

        }

        void startDownLoad(md m)
        {
            var dir = path + tb_lfpre.Text + m.lv;

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            var x1 = (int)Math.Min(m.ps.X, m.pe.X);
            var x2 = (int)Math.Max(m.ps.X, m.pe.X);
            var y1 = (int)Math.Min(m.ps.Y, m.pe.Y);
            var y2 = (int)Math.Max(m.ps.Y, m.pe.Y);

            var pc = (x2 - x1 + 1) * (y2 - y1 + 1);
            long c = 0;

            var img = new Bitmap(256, 256);
            var g = Graphics.FromImage(img);

            for (var x = x1; x <= x2; x++)
            {
                for (var y = y1; y <= y2; y++)
                {
                    if (stop) return;
                    var url = mtype == 0 ?
                        "http://webgis.591map.net/tiler/tdt-vec_w-{sw}-" + x + "-" + y + "-" + m.lv + ".html" :
                        "http://webgis.591map.net/tiler/tdt-img_w-{sw}-" + x + "-" + y + "-" + m.lv + ".html";

                    var data = downData(url);
                    using (var ms = new MemoryStream())
                    {
                        ms.Write(data, 0, data.Length);
                        var bmp = System.Drawing.Image.FromStream(ms);
                        g.DrawImage(bmp, new Rectangle(0, 0, 256, 256), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
                        bmp.Dispose();
                    }

                    img.Save(dir + "\\" + x + "," + y + ".jpg", ImageFormat.Jpeg);

                    lock (this) c++;

                    Invoke((Action)(() =>
                    {
                        tsl_tip.Text = "已下载瓦片：" + m.lv + "级，" + x + "," + y + " " + c + "/" + pc + "(" + ((float)c / pc * 100).ToString("F2") + "%)";
                    }));
                }
            }
            Invoke((Action)(() =>
            {
                if (m.lv == int.Parse(cb_maxlev.SelectedItem + "")) tsl_tip.Text = "下载完成";
                else tsl_tip.Text = "下载取消";
                bt_start.Enabled = true;
                bt_stop.Enabled = false;
            }));
            g.Dispose();
            img.Dispose();
        }

        byte[] downData(string url)
        {
            var wc = new Webc(5 * 1000);
            try
            {
                var fg = Tools.GetRandNext(0, 7);
                return wc.DownloadData(url.Replace("{sw}", fg + ""));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("down:err->" + ex.Message);
                Thread.Sleep(3 * 1000);
                return downData(url);
            }
        }

        class Webc : WebClient
        {
            int to = 0;
            public Webc(int timeout)
            {
                to = timeout;
            }
            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.Timeout = to;
                request.ReadWriteTimeout = to;
                return request;
            }
        }

        PointF WorldToGps(double lon, double lat, int zoom)
        {
            PointF p = new PointF();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));// - 2.0 / Math.Pow(2, (18 - zoom)));
            return p;
        }

        class md
        {
            public PointF ps { get; set; }
            public PointF pe { get; set; }
            public int lv { get; set; }
        }

        private void btn_setoutdir_Click(object sender, EventArgs e)
        {
            var ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK) lb_outdir.Text = ofd.SelectedPath + "\\";
        }
    }
}
