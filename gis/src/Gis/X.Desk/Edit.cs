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
using X.Core.Utility;
using X.Gis;

namespace X.Desk
{
    public partial class Edit : Form
    {
        Pack pb { get; set; }
        Extend extends = null;

        public Edit(Pack p)
        {
            InitializeComponent();
            pb = p;
            extends = new Extend();
        }

        public void AddLayer(Layer lay)
        {
            if (lay.tp == 0) return;
            extends.SetBound(lay.ext);
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
            tb_svr_name.Text = pb.Name;
            tb_link.Text = pb.Path;
            tb_key.Text = pb.Key;
            lb_svr_name.Text = "服务名称:" + pb.Name;
            lb_link.Text = (pb.Op == 2 ? "本地路径:" : "服务链接:") + pb.Path;
            lb_link1.Text = (pb.Op == 2 ? "本地路径:" : "服务链接:");
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
            new PreView(lys, new Gis.Extend(extends.xMin, extends.yMin, extends.xMax, extends.yMax)).Show();
        }

        private void tb_wmtran_ValueChanged(object sender, EventArgs e)
        {
            lb_wmtran.Text = "透明度：" + tb_wmtran.Value + "%";
        }

        private void rb_sp_grid_CheckedChanged(object sender, EventArgs e)
        {
            gp_fields.Visible = rb_sp_grid.Checked;
            var shp = lb_layers.SelectedItem as ShpLayer;
            //shp.OutPut = rb_sp_grid.Checked ? ShpLayer.OutType.Grid : ShpLayer.OutType.Img;
            lb_layers.SelectedItem = shp;
        }

        private void lb_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lay = lb_layers.SelectedItem as Layer;
            if (lay == null) return;
            if (lay.tp == 1)
            {
                gp_shp.Visible = true;
                gp_img.Visible = false;
            }
            else
            {
                gp_img.Visible = true;
                gp_shp.Visible = false;
            }
        }

        private void cbl_fields_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void cb_namefield_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shp = lb_layers.SelectedItem as ShpLayer;
            //shp.DiaplsyField = (cb_namefield.SelectedItem as ShpLayer.Field).Name;
            lb_layers.SelectedItem = shp;
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            var lv = 18;

            var img = new Bitmap(4096, 4096);
            var g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

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
                        foreach (Layer l in lb_layers.Items) l.DrawImage(new RectangleF(x, y, 4096, 4096), full, lv, g);
                        var b = new Block()
                        {
                            file = i++.ToString("000") + ".png",
                            level = lv,
                            bound = new Rectangle((int)(full.X + x / 256.0), (int)(full.Y + y / 256.0), 15, 15)
                        };
                        list.Add(b);
                        img.Save("d:\\temp\\s\\" + b.file, ImageFormat.Png);
                    }
                }
                lv--;

            } while (true);

            File.WriteAllText("d:\\temp\\s\\cfg.json", Serialize.ToJson(list));

            g.Dispose();
            img.Dispose();

        }

        class Block
        {
            public int level { get; set; }
            public string file { get; set; }
            public Rectangle bound { get; set; }
        }

        private void pb_sp_style_Click(object sender, EventArgs e)
        {
            var lay = lb_layers.SelectedItem as ShpLayer;
            if (lay == null) return;
            var opst = new Style(lay.Style);
            if (opst.ShowDialog() == DialogResult.OK)
            {
                lay.Style = opst.DrawStyle;
                //lb_layers.SelectedItem = lay;
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
