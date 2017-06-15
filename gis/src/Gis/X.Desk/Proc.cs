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
        public void SetT1(string txt) { lb_all.Text = txt; }
        public void SetT2(string txt) { lb_cur.Text = txt; }
        public void SetP1(int v) { pb_all.Value = v; }
        public void SetP2(int v) { pb_cur.Value = v; }
    }
}
