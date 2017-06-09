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
        public Pack cfg { get; private set; }
        public Pub()
        {
            InitializeComponent();
        }

        private void bt_next_Click(object sender, EventArgs e)
        {
            if (rb_pub.Checked) tb_guide.SelectTab(1);
            else if (rb_save.Checked) tb_guide.SelectTab(3);
            else tb_guide.SelectTab(2);
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
            DialogResult = DialogResult.OK;
            cfg = new Pack()
            {
                Key = tx_key.Text,
                Name = tx_name.Text,
                Op = 2,
                Path = tx_dir.Text
            };
            Close();
        }

        private void bt_nt2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            cfg = new Pack()
            {
                Key = "",
                Name = tb_name.Text,
                Op = 0,
                Path = rb_newdir.Checked ? tb_newdir.Text : cb_dir.SelectedText
            };
            Close();
        }

        private void bt_nt3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            cfg = new Pack()
            {
                Key = "",
                Name = tb_name.Text,
                Op = 1,
                Path = ""
            };
            Close();
        }

        private void lb_svrs_DrawItem(object sender, DrawItemEventArgs e)
        {
            var lb = sender as ListBox;
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index < 0) return;
            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 9, e.Bounds.Top + 9);
        }
    }
}
