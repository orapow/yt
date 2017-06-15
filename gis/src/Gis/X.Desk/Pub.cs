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
    public partial class Pub : Form
    {
        public string Path { get; set; }
        public string SName { get; set; }
        public string Key { get; set; }
        public string Dir { get; set; }
        /// <summary>
        /// 1、新服务
        /// 2、替换服务
        /// 3、本地打包
        /// </summary>
        public int Op { get; set; }

        public Pub()
        {
            InitializeComponent();
            var links = Config.LoadConfig().Links;
            if (links != null)
            {
                cb_link1.Items.AddRange(links.Select(o => o.url).ToArray());
                cb_link2.Items.AddRange(links.Select(o => o.url).ToArray());
            }
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            if (rb_pub.Checked) tb_guide.SelectTab(1);
            else if (rb_save.Checked) tb_guide.SelectTab(3);
            else tb_guide.SelectTab(2);
            Op = tb_guide.SelectedIndex;
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_pre_Click(object sender, EventArgs e)
        {
            tb_guide.SelectTab(0);
        }

        private void bt_nt4_Click(object sender, EventArgs e)
        {
            Path = tx_dir.Text;
            SName = tx_name.Text;

            if (string.IsNullOrEmpty(Path)) { MessageBox.Show("请选择存储路径", Text); return; }
            if (string.IsNullOrEmpty(SName)) { MessageBox.Show("请输入服务名称", Text); return; }

            tb_guide.SelectTab(4);
        }

        private void bt_nt2_Click(object sender, EventArgs e)
        {
            if (cb_link1.SelectedIndex < 0) { MessageBox.Show("请选择一个链接", Text); return; }
            if (string.IsNullOrEmpty(tb_name.Text)) { MessageBox.Show("请输入服务名称", Text); return; }

            SName = tb_name.Text;
            Path = cb_link1.SelectedItem + "";
            Dir = cb_dir.SelectedItem + "";
            if (rb_newdir.Checked)
            {
                SName = tb_newdir.Text;
                var rsp = Sdk.NewDir(SName);
                if (!rsp.issucc) { MessageBox.Show(rsp.msg, Text); return; }
            }
            if (string.IsNullOrEmpty(SName)) { MessageBox.Show("请选择或创建一个文件夹", Text); return; }
            tb_guide.SelectTab(4);
        }

        private void bt_nt3_Click(object sender, EventArgs e)
        {
            if (cb_link2.SelectedIndex < 0) { MessageBox.Show("请选择一个链接", Text); return; }
            if (lb_svrs.SelectedIndex < 0) { MessageBox.Show("请选择一个服务", Text); return; }

            var s = lb_svrs.SelectedItem as Sdk.SvrsRsp.Svr;

            Path = cb_link2.SelectedItem + "";
            SName = s.name;
            Dir = s.dir;
            tx_key.Text = s.key;

            tx_key.Enabled = false;
            tb_guide.SelectTab(4);
        }

        private void lb_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lb = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 9, e.Bounds.Top + 9);
        }

        private void cb_link1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_dir.Items.Clear();
            cb_dir.Items.Insert(0, "根目录");
            Sdk.SetUrl(cb_link1.Text);
            var dirs = Sdk.GetDirs();
            if (!dirs.issucc) { MessageBox.Show(dirs.msg, Text); return; }
            if (dirs.items != null) cb_dir.Items.AddRange(dirs.items.ToArray());
        }

        private void cb_link2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sdk.SetUrl(cb_link2.Text);
            var svrs = Sdk.GetSvrs();
            if (!svrs.issucc) { MessageBox.Show(svrs.msg, Text); return; }
            if (svrs.items != null) lb_svrs.Items.AddRange(svrs.items.ToArray());
        }

        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lb = sender as ComboBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 2, e.Bounds.Top + 2);
        }

        private void bt_pre2_Click(object sender, EventArgs e)
        {
            tb_guide.SelectTab(Op);
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            Key = tx_key.Text;
            if (string.IsNullOrEmpty(Key)) { MessageBox.Show("请输入服务密钥", Text); return; }
            if (Op == 1)
            {
                var r = Sdk.NewSvr(SName, Key);
                if (!r.issucc) MessageBox.Show("创建服务失败" + (string.IsNullOrEmpty(r.msg) ? "" : "，错误信息：" + r.msg));
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bt_seldir_Click(object sender, EventArgs e)
        {
            var odf = new FolderBrowserDialog();
            if (odf.ShowDialog() != DialogResult.OK) return;
            tx_dir.Text = odf.SelectedPath;
        }
    }
}
