using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using X.Core.Utility;
using X.Gis;

namespace X.Desk
{
    public partial class Edit : Form
    {
        string path { get; set; }
        string sname { get; set; }
        string key { get; set; }
        string dir { get; set; }
        int op { get; set; }
        Extend extends = null;
        Proc pc = null;

        public Edit(string path, string sname, string key, string dir, int op)
        {
            InitializeComponent();
            extends = new Extend();
            this.path = path;
            this.sname = sname;
            this.key = key;
            this.dir = dir;
            this.op = op;
        }

        public void AddLayer(Layer lay)
        {
            if (lay.Tp == 0) return;
            extends.SetBound(lay.Extends);
            lb_layers.Items.Add(lay);
        }

        private void lb_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lb = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 9, e.Bounds.Top + 9);
        }

        private void lb_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = lb_items.SelectedIndex;
            if (i < 0) return;
            tab_pages.SelectedIndex = i;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            lb_items.SelectedIndex = 0;
            tb_svr_name.Text = sname;
            tb_link.Text = path;
            tb_key.Text = key;
            lb_svr_name.Text = "服务名称:" + sname;
            lb_link.Text = (op == 3 ? "本地路径:" : "服务链接:") + path;
            lb_link1.Text = (op == 3 ? "本地路径:" : "服务链接:");
        }

        private void cb_show_bl_CheckedChanged(object sender, EventArgs e)
        {
            gb_show_bl.Enabled = cb_show_bl.Checked;
        }

        private void cb_setwm_CheckedChanged(object sender, EventArgs e)
        {
            gb_wm.Enabled = cb_setwm.Checked;
        }

        private void bt_preview_Click(object sender, EventArgs e)
        {
            var lys = new List<Layer>();
            foreach (Layer l in lb_layers.Items) lys.Add(l);
            new PreView(lys, new Extend(extends.xMin, extends.yMin, extends.xMax, extends.yMax)).Show();
        }

        private void tb_wmtran_ValueChanged(object sender, EventArgs e)
        {
            lb_wmtran.Text = "透明度：" + tb_wmtran.Value + "%";
        }

        private void rb_sp_grid_CheckedChanged(object sender, EventArgs e)
        {
            gp_fields.Visible = rb_sp_grid.Checked;
            var shp = lb_layers.SelectedItem as ShpLayer;
            shp.OutPut = rb_sp_grid.Checked ? "图形" : "图像";
            lb_layers.SelectedItem = shp;
        }

        private void lb_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lay = lb_layers.SelectedItem as Layer;
            if (lay == null) return;
            if (lay.Tp == 2)
            {
                gp_shp.Visible = true;
                gp_img.Visible = false;
                var sl = lay as ShpLayer;
                cb_namefield.Items.Clear();
                cb_namefield.Items.AddRange(sl.Fields.ToArray());
                if (sl.OutPut == "图形") { rb_sp_grid.Checked = true; cb_namefield.Text = sl.DiaplsyField; }
                else { rb_sp_map.Checked = true; cb_namefield.Text = ""; }
            }
            else
            {
                gp_img.Visible = true;
                gp_shp.Visible = false;
            }
        }

        private void cb_namefield_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shp = lb_layers.SelectedItem as ShpLayer;
            shp.DiaplsyField = (cb_namefield.SelectedItem as ShpLayer.Field).Name;
            foreach (var sp in shp.Shapes) sp.Name = sp.Data[shp.DiaplsyField];
            lb_layers.SelectedItem = shp;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            var img_lays = new List<Layer>();
            var shp_lays = new List<ShpLayer>();

            foreach (Layer l in lb_layers.Items)
            {
                if (l.Tp == 1) img_lays.Add(l);
                var sl = l as ShpLayer;
                if (sl == null) continue;
                if (sl.OutPut == "图像") img_lays.Add(l);
                else if (sl.OutPut == "图形") shp_lays.Add(l as ShpLayer);
            }

            var path = Application.StartupPath + "\\" + tb_svr_name.Text + "\\";
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            #region 生成
            outimg(img_lays, path);
            outshp(shp_lays, path);
            outlay(path);
            outsvr(path);
            #endregion

            if (op != 3)
            {
                #region 发布
                var be = Sdk.Begin(sname, op == 2);//预处理
                if (!be.issucc) { MessageBox.Show("预处理失败"); return; }
                if (Directory.Exists(path + "图像")) foreach (var f in Directory.GetFiles(path + "图像")) Sdk.Upload(1, sname, f);
                if (Directory.Exists(path + "图形")) foreach (var f in Directory.GetFiles(path + "图形")) Sdk.Upload(2, sname, f);
                Sdk.Upload(3, sname, path + "lays.x");
                Sdk.Upload(3, sname, path + "svr.x");
                Sdk.Init(sname);//初始化
                Sdk.End(sname);//清理
                #endregion
            }
            else
            {
                #region 打包
                var pi = new ProcessStartInfo(Application.StartupPath + "\\rar.exe");
                pi.Arguments = " a -ep1 -p" + tb_key.Text + " " + this.path + "\\" + sname + ".rar " + path.TrimEnd('\\');
                pi.CreateNoWindow = true;
                pi.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(pi);
                #endregion
            }

            MessageBox.Show("发布完成", Text);

        }

        void showProc(string t1, string t2, int p1, int p2)
        {
            if (pc == null) return;
        }

        /// <summary>
        /// 输出图层
        /// </summary>
        /// <param name="path"></param>
        void outlay(string path)
        {
            File.WriteAllBytes(path + "lays.x", Secret.XcEncode(Encoding.UTF8.GetBytes(Serialize.ToJson(lb_layers.Items)), tb_key.Text));
        }

        /// <summary>
        /// 输出服务信息
        /// </summary>
        /// <param name="path"></param>
        void outsvr(string path)
        {
            var svr = new Svr()
            {
                BlockSize = int.Parse(cb_blocksize.Text),
                Cached = new Svr.Cache() { MaxMem = int.Parse(tb_ch_max.Text), MinMem = int.Parse(tb_cb_min.Text), UseMemory = cb_ch_mem.Checked, UserFile = cb_ch_file.Checked },
                Dir = dir,
                DocumentInfo = new DocumentInfo() { Author = tb_author.Text, Category = "", Comments = tb_summary.Text, Desc = tb_remark.Text, Subject = "", Title = "" },
                FullExtend = extends,
                InitialExtend = new Extend(),
                Key = "",
                Name = tb_svr_name.Text,
                Version = 2,
                WaterMarked = new Svr.WaterMark() { Enabel = true, Img = pb_wmimg.Image, Transparent = tb_wmtran.Value },
                MapTile = new Svr.TileInfo() { DPI = 72, Format = "Jpg", Height = 256, Quality = 75, Width = 256 }
            };
            File.WriteAllBytes(path + "svr.x", Secret.XcEncode(Encoding.UTF8.GetBytes(Serialize.ToJson(svr)), tb_key.Text));
        }
        /// <summary>
        /// 输出图形
        /// </summary>
        /// <param name="lays"></param>
        /// <param name="path"></param>
        void outshp(List<ShpLayer> lays, string path)
        {
            var shp_path = path + "图形\\";
            if (!Directory.Exists(shp_path)) Directory.CreateDirectory(shp_path);
            var i = 1;
            var list = new List<ShpLayer.Shape>();
            var lno = 1;
            foreach (var l in lays)
            {
                int p = 1;
                do
                {
                    var tp = l.Shapes.Skip((p - 1) * 10000).Take(10000);
                    if (tp.Count() == 0) break;
                    p++;
                    foreach (var s in tp) s.LayerNo = lno.ToString("000");
                    list.AddRange(tp);
                    if (list.Count() >= 10000)
                    {
                        File.WriteAllBytes(shp_path + (i++).ToString("000") + ".x", Secret.XcEncode(Encoding.UTF8.GetBytes(Serialize.ToJson(list)), tb_key.Text));
                        list.Clear();
                    }
                } while (true);
                lno++;
            }
            if (list.Count() > 0)
            {
                File.WriteAllBytes(shp_path + (i++).ToString("000") + ".x", Secret.XcEncode(Encoding.UTF8.GetBytes(Serialize.ToJson(list)), tb_key.Text));
                list.Clear();
            }
        }
        /// <summary>
        /// 输出图像
        /// </summary>
        /// <param name="lays"></param>
        /// <param name="path"></param>
        void outimg(List<Layer> lays, string path)
        {
            if (lays.Count == 0) return;
            int lv = 18;
            var img = new Bitmap(4096, 4096);
            var g = Graphics.FromImage(img);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var img_path = path + "图像\\";
            if (!Directory.Exists(img_path)) Directory.CreateDirectory(img_path);

            var i = 1;
            var list = new List<Block>();
            do
            {
                var full = Utils.GetRect(extends, lv);
                if (full.Width < 512 || full.Height < 512) break;

                var w = full.X - (int)full.X;
                var h = full.Y - (int)full.Y;

                for (var y = -img.Height - (int)(256.0 * h); y < full.Height; y += img.Height)
                {
                    for (var x = -img.Width - (int)(256.0 * w); x < full.Width; x += img.Width)
                    {
                        g.Clear(Color.Transparent);
                        foreach (Layer l in lays) Utils.DrawImage(l, new RectangleF(x, y, img.Width, img.Height), full, lv, g);
                        var b = new Block()
                        {
                            file = i++.ToString("000") + ".x",
                            level = lv,
                            bound = new Rectangle((int)(full.X + x / 256.0), (int)(full.Y + y / 256.0), 15, 15)
                        };
                        list.Add(b);
                        using (var ms = new MemoryStream())
                        {
                            img.Save(ms, ImageFormat.Png);
                            File.WriteAllBytes(img_path + b.file, Secret.XcEncode(ms.ToArray(), tb_key.Text));
                        }
                    }
                }
                lv--;
            } while (true);

            g.Dispose();
            img.Dispose();

            File.WriteAllBytes(img_path + "000.x", Secret.XcEncode(Encoding.UTF8.GetBytes(Serialize.ToJson(list)), tb_key.Text));
        }

        private void pb_sp_style_Click(object sender, EventArgs e)
        {
            var lay = lb_layers.SelectedItem as ShpLayer;
            if (lay == null) return;
            var opst = new Style(lay.Style);
            if (opst.ShowDialog() == DialogResult.OK)
            {
                lay.Style = opst.DrawStyle;
                pb_sp_style.Image = opst.DrawStyle.Demo;
                foreach (var p in lay.Shapes) p.Style = opst.DrawStyle;
            }
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            var idx = lb_layers.SelectedIndex;
            if (idx >= lb_layers.Items.Count - 1) return;

            var lay = lb_layers.Items[idx];
            lb_layers.Items[idx] = lb_layers.Items[idx + 1];
            lb_layers.Items[idx + 1] = lay;

            lb_layers.SelectedItem = lay;
        }

        private void bt_up_Click(object sender, EventArgs e)
        {
            var idx = lb_layers.SelectedIndex;
            if (idx < 1) return;

            var lay = lb_layers.Items[idx];
            lb_layers.Items[idx] = lb_layers.Items[idx - 1];
            lb_layers.Items[idx - 1] = lay;

            lb_layers.SelectedItem = lay;
        }
    }
}
