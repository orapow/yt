namespace Tiler
{
    partial class Cut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_setwm = new System.Windows.Forms.CheckBox();
            this.cb_filetype = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_setoutdir = new System.Windows.Forms.Button();
            this.lb_outdir = new System.Windows.Forms.Label();
            this.gb_wm = new System.Windows.Forms.GroupBox();
            this.pb_wmimg = new System.Windows.Forms.PictureBox();
            this.lb_wmtran = new System.Windows.Forms.Label();
            this.tb_wmtran = new System.Windows.Forms.TrackBar();
            this.gb_filetype = new System.Windows.Forms.GroupBox();
            this.p_setquality = new System.Windows.Forms.Panel();
            this.lb_quality = new System.Windows.Forms.Label();
            this.tb_setquality = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_tilexytype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_lfpre = new System.Windows.Forms.TextBox();
            this.tb_filename = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlb_tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.num_col = new System.Windows.Forms.NumericUpDown();
            this.lb_count = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_demo = new System.Windows.Forms.CheckBox();
            this.bt_addpic = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4.SuspendLayout();
            this.gb_wm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wmimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_wmtran)).BeginInit();
            this.gb_filetype.SuspendLayout();
            this.p_setquality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setquality)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_col)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_setwm
            // 
            this.cb_setwm.AutoSize = true;
            this.cb_setwm.Location = new System.Drawing.Point(275, 71);
            this.cb_setwm.Name = "cb_setwm";
            this.cb_setwm.Size = new System.Drawing.Size(72, 16);
            this.cb_setwm.TabIndex = 10;
            this.cb_setwm.Text = "切片水印";
            this.cb_setwm.UseVisualStyleBackColor = true;
            this.cb_setwm.CheckedChanged += new System.EventHandler(this.cb_setwm_CheckedChanged);
            // 
            // cb_filetype
            // 
            this.cb_filetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_filetype.FormattingEnabled = true;
            this.cb_filetype.Items.AddRange(new object[] {
            "Jpg",
            "Png"});
            this.cb_filetype.Location = new System.Drawing.Point(529, 69);
            this.cb_filetype.Name = "cb_filetype";
            this.cb_filetype.Size = new System.Drawing.Size(48, 20);
            this.cb_filetype.TabIndex = 13;
            this.cb_filetype.SelectedValueChanged += new System.EventHandler(this.cb_filetype_SelectedValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_setoutdir);
            this.groupBox4.Controls.Add(this.lb_outdir);
            this.groupBox4.Location = new System.Drawing.Point(266, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(362, 54);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "保存到";
            // 
            // btn_setoutdir
            // 
            this.btn_setoutdir.AutoSize = true;
            this.btn_setoutdir.Location = new System.Drawing.Point(322, 20);
            this.btn_setoutdir.Name = "btn_setoutdir";
            this.btn_setoutdir.Size = new System.Drawing.Size(33, 22);
            this.btn_setoutdir.TabIndex = 1;
            this.btn_setoutdir.Text = "...";
            this.btn_setoutdir.UseVisualStyleBackColor = true;
            this.btn_setoutdir.Click += new System.EventHandler(this.btn_setoutdir_Click);
            // 
            // lb_outdir
            // 
            this.lb_outdir.Location = new System.Drawing.Point(9, 18);
            this.lb_outdir.Name = "lb_outdir";
            this.lb_outdir.Size = new System.Drawing.Size(307, 27);
            this.lb_outdir.TabIndex = 0;
            this.lb_outdir.Text = "D:\\st\\";
            // 
            // gb_wm
            // 
            this.gb_wm.Controls.Add(this.pb_wmimg);
            this.gb_wm.Controls.Add(this.lb_wmtran);
            this.gb_wm.Controls.Add(this.tb_wmtran);
            this.gb_wm.Enabled = false;
            this.gb_wm.Location = new System.Drawing.Point(266, 72);
            this.gb_wm.Name = "gb_wm";
            this.gb_wm.Size = new System.Drawing.Size(192, 78);
            this.gb_wm.TabIndex = 11;
            this.gb_wm.TabStop = false;
            // 
            // pb_wmimg
            // 
            this.pb_wmimg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_wmimg.Location = new System.Drawing.Point(9, 20);
            this.pb_wmimg.Name = "pb_wmimg";
            this.pb_wmimg.Size = new System.Drawing.Size(48, 48);
            this.pb_wmimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_wmimg.TabIndex = 0;
            this.pb_wmimg.TabStop = false;
            this.pb_wmimg.Click += new System.EventHandler(this.pb_wmimg_Click);
            // 
            // lb_wmtran
            // 
            this.lb_wmtran.AutoSize = true;
            this.lb_wmtran.Location = new System.Drawing.Point(89, 52);
            this.lb_wmtran.Name = "lb_wmtran";
            this.lb_wmtran.Size = new System.Drawing.Size(77, 12);
            this.lb_wmtran.TabIndex = 0;
            this.lb_wmtran.Text = "透明度：100%";
            // 
            // tb_wmtran
            // 
            this.tb_wmtran.LargeChange = 10;
            this.tb_wmtran.Location = new System.Drawing.Point(63, 20);
            this.tb_wmtran.Maximum = 100;
            this.tb_wmtran.Minimum = 5;
            this.tb_wmtran.Name = "tb_wmtran";
            this.tb_wmtran.Size = new System.Drawing.Size(123, 45);
            this.tb_wmtran.SmallChange = 5;
            this.tb_wmtran.TabIndex = 1;
            this.tb_wmtran.TickFrequency = 10;
            this.tb_wmtran.Value = 100;
            this.tb_wmtran.ValueChanged += new System.EventHandler(this.tb_wmtran_ValueChanged);
            // 
            // gb_filetype
            // 
            this.gb_filetype.Controls.Add(this.p_setquality);
            this.gb_filetype.Location = new System.Drawing.Point(464, 72);
            this.gb_filetype.Name = "gb_filetype";
            this.gb_filetype.Size = new System.Drawing.Size(164, 78);
            this.gb_filetype.TabIndex = 14;
            this.gb_filetype.TabStop = false;
            this.gb_filetype.Text = "输出格式";
            // 
            // p_setquality
            // 
            this.p_setquality.Controls.Add(this.lb_quality);
            this.p_setquality.Controls.Add(this.tb_setquality);
            this.p_setquality.Location = new System.Drawing.Point(6, 20);
            this.p_setquality.Name = "p_setquality";
            this.p_setquality.Size = new System.Drawing.Size(149, 49);
            this.p_setquality.TabIndex = 2;
            // 
            // lb_quality
            // 
            this.lb_quality.AutoSize = true;
            this.lb_quality.Location = new System.Drawing.Point(40, 30);
            this.lb_quality.Name = "lb_quality";
            this.lb_quality.Size = new System.Drawing.Size(71, 12);
            this.lb_quality.TabIndex = 2;
            this.lb_quality.Text = "Jpg质量：80";
            // 
            // tb_setquality
            // 
            this.tb_setquality.Location = new System.Drawing.Point(1, 2);
            this.tb_setquality.Maximum = 100;
            this.tb_setquality.Minimum = 5;
            this.tb_setquality.Name = "tb_setquality";
            this.tb_setquality.Size = new System.Drawing.Size(147, 45);
            this.tb_setquality.SmallChange = 5;
            this.tb_setquality.TabIndex = 3;
            this.tb_setquality.TickFrequency = 10;
            this.tb_setquality.Value = 80;
            this.tb_setquality.ValueChanged += new System.EventHandler(this.tb_setquality_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cb_tilexytype);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.tb_lfpre);
            this.groupBox5.Controls.Add(this.tb_filename);
            this.groupBox5.Location = new System.Drawing.Point(266, 156);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(362, 84);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "瓦片设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "结果：lv1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "文件夹：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "坐标系：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "文件名：";
            // 
            // cb_tilexytype
            // 
            this.cb_tilexytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tilexytype.FormattingEnabled = true;
            this.cb_tilexytype.Items.AddRange(new object[] {
            "经纬度"});
            this.cb_tilexytype.Location = new System.Drawing.Point(68, 47);
            this.cb_tilexytype.Name = "cb_tilexytype";
            this.cb_tilexytype.Size = new System.Drawing.Size(71, 20);
            this.cb_tilexytype.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "l:层级,x:横向编号,y:竖向编号\r\n";
            // 
            // tb_lfpre
            // 
            this.tb_lfpre.Location = new System.Drawing.Point(204, 47);
            this.tb_lfpre.Name = "tb_lfpre";
            this.tb_lfpre.Size = new System.Drawing.Size(50, 21);
            this.tb_lfpre.TabIndex = 0;
            this.tb_lfpre.Text = "lv";
            this.tb_lfpre.TextChanged += new System.EventHandler(this.tb_lfpre_TextChanged);
            // 
            // tb_filename
            // 
            this.tb_filename.Location = new System.Drawing.Point(68, 20);
            this.tb_filename.Name = "tb_filename";
            this.tb_filename.Size = new System.Drawing.Size(71, 21);
            this.tb_filename.TabIndex = 0;
            this.tb_filename.Text = "{x},{y}";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlb_tip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlb_tip
            // 
            this.tlb_tip.Name = "tlb_tip";
            this.tlb_tip.Size = new System.Drawing.Size(625, 17);
            this.tlb_tip.Spring = true;
            this.tlb_tip.Text = "已经准备好";
            this.tlb_tip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_addpic);
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Controls.Add(this.num_col);
            this.groupBox2.Controls.Add(this.lb_count);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 283);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片拼接";
            // 
            // num_col
            // 
            this.num_col.Location = new System.Drawing.Point(186, 15);
            this.num_col.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_col.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_col.Name = "num_col";
            this.num_col.Size = new System.Drawing.Size(33, 21);
            this.num_col.TabIndex = 20;
            this.num_col.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_col.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_col.ValueChanged += new System.EventHandler(this.num_col_ValueChanged);
            // 
            // lb_count
            // 
            this.lb_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_count.AutoSize = true;
            this.lb_count.Location = new System.Drawing.Point(6, 19);
            this.lb_count.Name = "lb_count";
            this.lb_count.Size = new System.Drawing.Size(77, 12);
            this.lb_count.TabIndex = 19;
            this.lb_count.Text = "图片数：1 张";
            this.lb_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "列";
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(529, 252);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(99, 44);
            this.bt_start.TabIndex = 20;
            this.bt_start.Text = "开始输出切片";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_demo);
            this.groupBox1.Location = new System.Drawing.Point(266, 246);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 50);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "示例文件";
            // 
            // cb_demo
            // 
            this.cb_demo.AutoSize = true;
            this.cb_demo.Checked = true;
            this.cb_demo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_demo.Location = new System.Drawing.Point(9, 21);
            this.cb_demo.Name = "cb_demo";
            this.cb_demo.Size = new System.Drawing.Size(96, 16);
            this.cb_demo.TabIndex = 10;
            this.cb_demo.Text = "输出预览文件";
            this.cb_demo.UseVisualStyleBackColor = true;
            this.cb_demo.CheckedChanged += new System.EventHandler(this.cb_setwm_CheckedChanged);
            // 
            // bt_addpic
            // 
            this.bt_addpic.AutoSize = true;
            this.bt_addpic.Location = new System.Drawing.Point(89, 14);
            this.bt_addpic.Name = "bt_addpic";
            this.bt_addpic.Size = new System.Drawing.Size(27, 22);
            this.bt_addpic.TabIndex = 1;
            this.bt_addpic.Text = "..";
            this.bt_addpic.UseVisualStyleBackColor = true;
            this.bt_addpic.Click += new System.EventHandler(this.bt_addpic_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(235, 235);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // Cut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 329);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cb_setwm);
            this.Controls.Add(this.cb_filetype);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gb_wm);
            this.Controls.Add(this.gb_filetype);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.Name = "Cut";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输出切片";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gb_wm.ResumeLayout(false);
            this.gb_wm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wmimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_wmtran)).EndInit();
            this.gb_filetype.ResumeLayout(false);
            this.p_setquality.ResumeLayout(false);
            this.p_setquality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setquality)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_col)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_setwm;
        private System.Windows.Forms.ComboBox cb_filetype;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_setoutdir;
        private System.Windows.Forms.Label lb_outdir;
        private System.Windows.Forms.GroupBox gb_wm;
        private System.Windows.Forms.PictureBox pb_wmimg;
        private System.Windows.Forms.Label lb_wmtran;
        private System.Windows.Forms.TrackBar tb_wmtran;
        private System.Windows.Forms.GroupBox gb_filetype;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_tilexytype;
        private System.Windows.Forms.TextBox tb_filename;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlb_tip;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel p_setquality;
        private System.Windows.Forms.TrackBar tb_setquality;
        private System.Windows.Forms.Label lb_quality;
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.NumericUpDown num_col;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_lfpre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_demo;
        private System.Windows.Forms.Button bt_addpic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}