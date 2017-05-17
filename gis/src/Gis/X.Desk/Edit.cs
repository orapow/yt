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
        //List<Layer> layers = null;
        Extend extends = null;

        public Edit(Pack p)
        {
            InitializeComponent();
            pb = p;
            extends = new Extend();
        }

        public void AddLayer(Layer lay)
        {
            if (extends.XMin > lay.Extends.XMin || extends.XMax == 0) extends.XMin = lay.Extends.XMin;
            if (extends.YMin > lay.Extends.YMin || extends.XMax == 0) extends.YMin = lay.Extends.YMin;
            if (extends.XMax < lay.Extends.XMax || extends.XMax == 0) extends.XMax = lay.Extends.XMax;
            if (extends.YMax < lay.Extends.YMax || extends.YMax == 0) extends.YMax = lay.Extends.YMax;
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
            new PreView(lys, extends).Show();
        }

        private void tb_wmtran_ValueChanged(object sender, EventArgs e)
        {
            lb_wmtran.Text = "透明度：" + tb_wmtran.Value + "%";
        }

        private void rb_sp_grid_CheckedChanged(object sender, EventArgs e)
        {
            gp_fields.Visible = rb_sp_grid.Checked;
            var shp = lb_layers.SelectedItem as ShpLayer;
            shp.OutPut = rb_sp_grid.Checked ? ShpLayer.OutType.Grid : ShpLayer.OutType.Img;
            lb_layers.SelectedItem = shp;
        }

        private void lb_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lay = lb_layers.SelectedItem as Layer;
            if (lay == null) return;
            if (lay.Tp == 1)
            {
                var pl = lay as ImgLayer;
                gp_img.Visible = true;
                gp_shp.Visible = false;
                pb_tr_color.BackColor = pl.TransparentColor;
            }
            else
            {
                gp_shp.Visible = true;
                gp_img.Visible = false;
                var shp = lay as ShpLayer;
                if (shp.OutPut == ShpLayer.OutType.Grid)
                {
                    gp_fields.Visible = rb_sp_grid.Checked = true;
                }
                else
                {
                    rb_sp_map.Checked = true;
                    gp_fields.Visible = false;
                }
                cb_namefield.SelectedItem = shp.DiaplsyField;
                cbl_fields.Items.Clear();
                if (shp.Fields != null)
                {
                    foreach (var f in shp.Fields)
                    {
                        cbl_fields.Items.Add(f);
                        if (f.Selected) cbl_fields.SelectedItems.Add(f);
                    }
                }
            }
        }

        private void cbl_fields_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void cb_namefield_SelectedIndexChanged(object sender, EventArgs e)
        {
            var shp = lb_layers.SelectedItem as ShpLayer;
            shp.DiaplsyField = (cb_namefield.SelectedItem as ShpLayer.Field).Name;
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
                var full = getRect(extends, lv);
                if (full.Width < 512 || full.Height < 512) break;

                var w = full.X - (int)full.X;
                var h = full.Y - (int)full.Y;

                for (var y = -img.Height + (int)(256 * h); y < full.Height; y += img.Height)
                {
                    for (var x = -img.Width + (int)(256 * w); x < full.Width; x += img.Width)
                    {
                        drawImage(x, y, lv, full, g);
                        var b = new Block()
                        {
                            file = i++.ToString("000") + ".png",
                            level = lv,
                            bound = new Rectangle((int)(full.X + x / 256.0), (int)(full.Y + y / 256.0), 15, 15)
                        };
                        list.Add(b);
                        img.Save("c:\\temp\\s\\" + b.file, ImageFormat.Png);
                    }
                }
                lv--;

            } while (true);

            File.WriteAllText("c:\\temp\\s\\cfg.json", Serialize.ToJson(list));

            g.Dispose();
            img.Dispose();

        }

        class Block
        {
            public int level { get; set; }
            public string file { get; set; }
            public Rectangle bound { get; set; }
        }

        void drawImage(float x, float y, int lv, RectangleF f, Graphics g)
        {
            g.Clear(Color.Transparent);
            foreach (Layer ly in lb_layers.Items)
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
                                pot.X = (pot.X - f.X) * 256 - x;
                                pot.Y = (pot.Y - f.Y) * 256 - y;
                                pts.Add(pot);
                            }
                            if (sp.ShapeType == ShpfileType.SHP_POLYGON)
                            {
                                if (pts[0].X != pts[pa.numPoints - 1].X && pts[0].Y != pts[pa.numPoints - 1].Y) continue;
                                g.DrawPolygon(Pens.Red, pts.ToArray());
                                //if (!pa.PartIsClockWise[j]) g.FillPolygon(new SolidBrush(Color.FromArgb(100, Color.Green)), pts.ToArray());
                                //else g.FillPolygon(new SolidBrush(Color.FromArgb(0, Color.White)), pts.ToArray());
                            }
                            else if (sp.ShapeType == ShpfileType.SHP_POLYLINE) g.DrawLines(Pens.Red, pts.ToArray());
                        }
                    }
                    shp.Close();
                }
                else if (ly.Tp == 1)
                {
                    var tif = new Tiff(ly.File);
                    var px = (int)((rg_lay.X - f.X) * 256 - x);
                    var py = (int)((rg_lay.Y - f.Y) * 256 - y);
                    var bmp = tif.Pics[0].GetImage(new Rectangle(px, py, 8192, 8192), new Size((int)rg_lay.Width, (int)rg_lay.Height));
                    if (bmp == null) continue;
                    g.DrawImage(bmp, Math.Max(px, 0), Math.Max(py, 0));
                    bmp.Dispose();
                }
            }
        }

        private int getdist(PointF p1, PointF p2)
        {
            return (int)Math.Ceiling(Math.Abs(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))) * 256);
        }
        private RectangleF getRect(Extend ext, int lv)
        {
            var lt = WorldToGps(ext.XMin, ext.YMax, lv);
            var rt = WorldToGps(ext.XMax, ext.YMax, lv);
            var lb = WorldToGps(ext.XMin, ext.YMin, lv);

            return new RectangleF(lt.X, lt.Y, getdist(lt, rt), getdist(lt, lb));
        }
        PointF WorldToGps(double lon, double lat, int zoom)
        {
            PointF p = new System.Drawing.Point();
            p.X = (float)((lon + 180.0) / 360.0 * (1 << zoom));
            p.Y = (float)((1.0 - Math.Log(Math.Tan(lat * Math.PI / 180.0) + 1.0 / Math.Cos(lat * Math.PI / 180.0)) / Math.PI) / 2.0 * (1 << zoom));
            return p;
        }
    }
}
