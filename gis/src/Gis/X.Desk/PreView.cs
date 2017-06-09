using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using X.Gis;

namespace X.Desk
{
    public partial class PreView : Form
    {
        Extend extends = null;
        List<Layer> layers = null;
        RectangleF rg_full = RectangleF.Empty;
        float x = 0f;
        float y = 0f;
        int lv = 12;

        public PreView(List<Layer> lays, Extend exts)
        {
            InitializeComponent();
            layers = lays;
            extends = exts;
            rg_full = Utils.GetRect(extends, lv);
        }

        void drawImage()
        {
            lb_tip.Text = "正在渲染...";
            var dt = DateTime.Now;
            var img = new Bitmap(pb_view.Width, pb_view.Height);
            var g = Graphics.FromImage(img);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.Clear(Color.Transparent);

            foreach (var l in layers)
                l.DrawImage(new RectangleF(-x, -y, img.Width, img.Height), rg_full, lv, g);

            g.Dispose();
            pb_view.Image = img;

            lb_tip.Text = "等级:" + lv + ",耗时：" + (DateTime.Now - dt).TotalMilliseconds / 1000.0 + "s\r\n坐标：" + x + "," + y;
        }

        private void tsb_zoomIn_Click(object sender, EventArgs e)
        {
            lv--;
            if (lv <= 1) lv = 2;
            rg_full = Utils.GetRect(extends, lv);

            x = (Width - rg_full.Width) / 2;
            y = (Height - rg_full.Height) / 2;

            drawImage();
        }

        private void tsb_zoomOut_Click(object sender, EventArgs e)
        {
            lv++;
            if (lv >= 21) lv = 20;
            rg_full = Utils.GetRect(extends, lv);

            x = (Width - rg_full.Width) / 2;
            y = (Height - rg_full.Height) / 2;

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
            x = (Width - rg_full.Width) / 2;
            y = (Height - rg_full.Height) / 2;
            drawImage();
        }

        private void PreView_SizeChanged(object sender, EventArgs e)
        {
            drawImage();
        }

        private void PreView_Load(object sender, EventArgs e)
        {
            x = (Width - rg_full.Width) / 2;
            y = (Height - rg_full.Height) / 2;
            drawImage();
        }
    }
}
