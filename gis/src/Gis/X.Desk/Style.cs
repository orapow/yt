using System;
using System.Drawing;
using System.Windows.Forms;
using X.Gis;

namespace X.Desk
{
    public partial class Style : Form
    {
        public DrawStyle DrawStyle { get; private set; }

        public Style() : this(null) { }

        public Style(DrawStyle style)
        {
            InitializeComponent();
            if (style != null)
            {
                nud_bt.Value = style.BorderTran;
                lb_bc.BackColor = style.BorderColor;
                nud_bw.Value = style.BorderWidth;

                nud_ft.Value = style.FillTran;
                lb_fc.BackColor = style.FillColor;
            }
            else
            {
                DrawStyle = new DrawStyle();
            }
        }

        void drawImage()
        {
            var bw = (int)nud_bw.Value;
            var bc = lb_bc.BackColor;
            var bt = (int)nud_bt.Value;

            var fc = lb_fc.BackColor;
            var ft = (int)nud_ft.Value;

            var img = new Bitmap(100, 100);
            var g = Graphics.FromImage(img);
            //var rect = new Rectangle(10, 10, 80, 80);
            //
            if (bw > 0) g.DrawRectangle(new Pen(Color.FromArgb(bt, bc), bw), new Rectangle(bw / 2, bw / 2, 100 - bw, 100 - bw));
            g.FillRectangle(new SolidBrush(Color.FromArgb(ft, fc)), new Rectangle(bw, bw, 100 - bw * 2, 100 - bw * 2));
            g.Dispose();

            DrawStyle = new DrawStyle();
            DrawStyle.BorderColor = bc;
            DrawStyle.BorderTran = bt;
            DrawStyle.BorderWidth = bw;
            DrawStyle.FillColor = fc;
            DrawStyle.FillTran = ft;
            DrawStyle.Demo = img;

            pictureBox1.Image = img;
        }

        private void nud_bw_ValueChanged(object sender, EventArgs e)
        {
            drawImage();
        }

        private void nud_bt_ValueChanged(object sender, EventArgs e)
        {
            drawImage();
        }

        private void nud_ft_ValueChanged(object sender, EventArgs e)
        {
            drawImage();
        }

        private void lb_bc_Click(object sender, EventArgs e)
        {
            var cop = new ColorDialog();
            if (DrawStyle != null) cop.Color = DrawStyle.BorderColor;
            if (cop.ShowDialog() == DialogResult.OK)
            {
                lb_bc.BackColor = cop.Color;
                drawImage();
            }
        }

        private void lb_fc_Click(object sender, EventArgs e)
        {
            var cop = new ColorDialog();
            if (DrawStyle != null) cop.Color = DrawStyle.FillColor;
            if (cop.ShowDialog() == DialogResult.OK)
            {
                lb_fc.BackColor = cop.Color;
                drawImage();
            }
        }

        private void Style_Load(object sender, EventArgs e)
        {
            drawImage();
        }

        private void bt_no_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
