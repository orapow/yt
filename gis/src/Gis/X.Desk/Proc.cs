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
    public partial class Proc : Form
    {
        public Proc()
        {
            InitializeComponent();
        }

        public void SetR2(int min, int max)
        {
            Invoke(new Action(() =>
            {
                pb_cur.Minimum = min;
                pb_cur.Maximum = max;
            }));
        }
        public void SetT1(string txt) { Invoke(new Action(() => { lb_all.Text = txt; })); }
        public void SetT2(string txt) { Invoke(new Action(() => { lb_cur.Text = txt; })); }
        public void SetP1(int v) { Invoke(new Action(() => { pb_all.Value = v; })); }
        public void SetP2(int v, int d)
        {
            Invoke(new Action(() =>
            {
                if (v > pb_cur.Maximum) v = pb_cur.Maximum;
                pb_cur.Value = v;
                var p1 = pb_all.Value + (int)(v / (float)pb_cur.Maximum * d);
                pb_all.Value = p1 > pb_all.Maximum ? pb_all.Maximum : p1;
            }));
        }

        public void End()
        {
            Invoke(new Action(() => { Close(); }));
        }

    }
}
