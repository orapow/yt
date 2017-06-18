using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using X.Core.Utility;

namespace X.Desk
{
    public partial class Links : Form
    {
        Config cfg = null;
        public Links()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cfg = Config.LoadConfig();
            if (cfg.Links != null) lb_links.Items.AddRange(cfg.Links.ToArray());
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (cfg.Links == null) cfg.Links = new List<Config.Link>();
            else cfg.Links.Clear();
            foreach (var l in lb_links.Items) cfg.Links.Add(l as Config.Link);
            Config.SaveConfig(cfg);
            base.OnClosing(e);
        }

        private void lb_links_DoubleClick(object sender, EventArgs e)
        {
            var it = lb_links.SelectedItem as Config.Link;
            if (it == null) return;
            lb_links.Items.Remove(it);
            cfg.Links.Remove(it);
        }

        private void bt_new_Click(object sender, EventArgs e)
        {
            if (cfg.Links != null && cfg.Links.FirstOrDefault(o => o.url == tb_url.Text) != null) { MessageBox.Show("服务链接已经存在", Text); return; }

            try
            {
                Sdk.SetUrl(tb_url.Text);
                lb_links.Items.Add(new Config.Link() { url = tb_url.Text, status = 1 });
                tb_url.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text);
            }
        }

        private void lb_links_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lb = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 9, e.Bounds.Top + 9);
        }
    }
}
