namespace Yt.Tiler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_tcount = new System.Windows.Forms.TextBox();
            this.cb_tcount = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_owndir = new System.Windows.Forms.CheckBox();
            this.tb_dirfix = new System.Windows.Forms.TextBox();
            this.cb_maxcj = new System.Windows.Forms.ComboBox();
            this.tb_levelcount = new System.Windows.Forms.TextBox();
            this.cb_autolevels = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_wm = new System.Windows.Forms.GroupBox();
            this.pb_wmimg = new System.Windows.Forms.PictureBox();
            this.lb_wmtran = new System.Windows.Forms.Label();
            this.tb_wmtran = new System.Windows.Forms.TrackBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.p_setquality = new System.Windows.Forms.Panel();
            this.lb_quality = new System.Windows.Forms.Label();
            this.tb_setquality = new System.Windows.Forms.TrackBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_tilexytype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_filemark = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlb_tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.tpb_prog = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_wm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wmimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_wmtran)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.p_setquality.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setquality)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // 
            // cb_filetype
            // 
            this.cb_filetype.FormattingEnabled = true;
            this.cb_filetype.Items.AddRange(new object[] {
            "Jpg",
            "Png"});
            this.cb_filetype.Location = new System.Drawing.Point(331, 153);
            this.cb_filetype.Name = "cb_filetype";
            this.cb_filetype.Size = new System.Drawing.Size(48, 20);
            this.cb_filetype.TabIndex = 13;
            this.cb_filetype.Text = "Jpg";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_setoutdir);
            this.groupBox4.Controls.Add(this.lb_outdir);
            this.groupBox4.Location = new System.Drawing.Point(266, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 54);
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
            // 
            // lb_outdir
            // 
            this.lb_outdir.Location = new System.Drawing.Point(9, 18);
            this.lb_outdir.Name = "lb_outdir";
            this.lb_outdir.Size = new System.Drawing.Size(307, 27);
            this.lb_outdir.TabIndex = 0;
            this.lb_outdir.Text = "D:\\Documents\\SQL Server Management Studio\\Templates\\ProjectTemplates";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_tcount);
            this.groupBox1.Controls.Add(this.cb_tcount);
            this.groupBox1.Location = new System.Drawing.Point(266, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "线程数";
            // 
            // tb_tcount
            // 
            this.tb_tcount.Location = new System.Drawing.Point(8, 20);
            this.tb_tcount.Name = "tb_tcount";
            this.tb_tcount.ReadOnly = true;
            this.tb_tcount.Size = new System.Drawing.Size(32, 21);
            this.tb_tcount.TabIndex = 0;
            this.tb_tcount.Text = "1";
            // 
            // cb_tcount
            // 
            this.cb_tcount.AutoSize = true;
            this.cb_tcount.Enabled = false;
            this.cb_tcount.Location = new System.Drawing.Point(46, 22);
            this.cb_tcount.Name = "cb_tcount";
            this.cb_tcount.Size = new System.Drawing.Size(48, 16);
            this.cb_tcount.TabIndex = 1;
            this.cb_tcount.Text = "自动";
            this.cb_tcount.UseVisualStyleBackColor = true;
            this.cb_tcount.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cb_owndir);
            this.groupBox3.Controls.Add(this.tb_dirfix);
            this.groupBox3.Controls.Add(this.cb_maxcj);
            this.groupBox3.Controls.Add(this.tb_levelcount);
            this.groupBox3.Controls.Add(this.cb_autolevels);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(436, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 107);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "层级";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "前辍：";
            // 
            // cb_owndir
            // 
            this.cb_owndir.AutoSize = true;
            this.cb_owndir.Checked = true;
            this.cb_owndir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_owndir.Location = new System.Drawing.Point(11, 20);
            this.cb_owndir.Name = "cb_owndir";
            this.cb_owndir.Size = new System.Drawing.Size(72, 16);
            this.cb_owndir.TabIndex = 4;
            this.cb_owndir.Text = "层文件夹";
            this.cb_owndir.UseVisualStyleBackColor = true;
            // 
            // tb_dirfix
            // 
            this.tb_dirfix.Location = new System.Drawing.Point(139, 18);
            this.tb_dirfix.Name = "tb_dirfix";
            this.tb_dirfix.Size = new System.Drawing.Size(46, 21);
            this.tb_dirfix.TabIndex = 5;
            this.tb_dirfix.Text = "lv";
            // 
            // cb_maxcj
            // 
            this.cb_maxcj.FormattingEnabled = true;
            this.cb_maxcj.Items.AddRange(new object[] {
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19"});
            this.cb_maxcj.Location = new System.Drawing.Point(84, 79);
            this.cb_maxcj.Name = "cb_maxcj";
            this.cb_maxcj.Size = new System.Drawing.Size(46, 20);
            this.cb_maxcj.TabIndex = 3;
            this.cb_maxcj.Text = "18";
            // 
            // tb_levelcount
            // 
            this.tb_levelcount.Location = new System.Drawing.Point(80, 49);
            this.tb_levelcount.Name = "tb_levelcount";
            this.tb_levelcount.Size = new System.Drawing.Size(50, 21);
            this.tb_levelcount.TabIndex = 0;
            this.tb_levelcount.Text = "4";
            // 
            // cb_autolevels
            // 
            this.cb_autolevels.AutoSize = true;
            this.cb_autolevels.Location = new System.Drawing.Point(137, 52);
            this.cb_autolevels.Name = "cb_autolevels";
            this.cb_autolevels.Size = new System.Drawing.Size(48, 16);
            this.cb_autolevels.TabIndex = 1;
            this.cb_autolevels.Text = "自动";
            this.cb_autolevels.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "最大图面在：         级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "输出级数：";
            // 
            // gb_wm
            // 
            this.gb_wm.Controls.Add(this.pb_wmimg);
            this.gb_wm.Controls.Add(this.lb_wmtran);
            this.gb_wm.Controls.Add(this.tb_wmtran);
            this.gb_wm.Enabled = false;
            this.gb_wm.Location = new System.Drawing.Point(266, 72);
            this.gb_wm.Name = "gb_wm";
            this.gb_wm.Size = new System.Drawing.Size(164, 78);
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
            // 
            // lb_wmtran
            // 
            this.lb_wmtran.AutoSize = true;
            this.lb_wmtran.Location = new System.Drawing.Point(70, 52);
            this.lb_wmtran.Name = "lb_wmtran";
            this.lb_wmtran.Size = new System.Drawing.Size(71, 12);
            this.lb_wmtran.TabIndex = 0;
            this.lb_wmtran.Text = "透明度：60%";
            // 
            // tb_wmtran
            // 
            this.tb_wmtran.Enabled = false;
            this.tb_wmtran.LargeChange = 10;
            this.tb_wmtran.Location = new System.Drawing.Point(63, 20);
            this.tb_wmtran.Maximum = 100;
            this.tb_wmtran.Minimum = 5;
            this.tb_wmtran.Name = "tb_wmtran";
            this.tb_wmtran.Size = new System.Drawing.Size(85, 45);
            this.tb_wmtran.SmallChange = 5;
            this.tb_wmtran.TabIndex = 1;
            this.tb_wmtran.TickFrequency = 10;
            this.tb_wmtran.Value = 60;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.p_setquality);
            this.groupBox6.Location = new System.Drawing.Point(266, 156);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(164, 80);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "输出格式";
            // 
            // p_setquality
            // 
            this.p_setquality.Controls.Add(this.lb_quality);
            this.p_setquality.Controls.Add(this.tb_setquality);
            this.p_setquality.Location = new System.Drawing.Point(9, 23);
            this.p_setquality.Name = "p_setquality";
            this.p_setquality.Size = new System.Drawing.Size(149, 50);
            this.p_setquality.TabIndex = 2;
            // 
            // lb_quality
            // 
            this.lb_quality.AutoSize = true;
            this.lb_quality.Location = new System.Drawing.Point(40, 33);
            this.lb_quality.Name = "lb_quality";
            this.lb_quality.Size = new System.Drawing.Size(71, 12);
            this.lb_quality.TabIndex = 2;
            this.lb_quality.Text = "Jpg质量：80";
            // 
            // tb_setquality
            // 
            this.tb_setquality.Location = new System.Drawing.Point(2, 2);
            this.tb_setquality.Maximum = 100;
            this.tb_setquality.Minimum = 5;
            this.tb_setquality.Name = "tb_setquality";
            this.tb_setquality.Size = new System.Drawing.Size(146, 45);
            this.tb_setquality.SmallChange = 5;
            this.tb_setquality.TabIndex = 1;
            this.tb_setquality.TickFrequency = 10;
            this.tb_setquality.Value = 80;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.cb_tilexytype);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.tb_filemark);
            this.groupBox5.Location = new System.Drawing.Point(436, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(191, 78);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "瓦片设置";
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
            this.cb_tilexytype.FormattingEnabled = true;
            this.cb_tilexytype.Items.AddRange(new object[] {
            "经纬度",
            "墨卡托",
            "百度坐标",
            "00坐标"});
            this.cb_tilexytype.Location = new System.Drawing.Point(124, 21);
            this.cb_tilexytype.Name = "cb_tilexytype";
            this.cb_tilexytype.Size = new System.Drawing.Size(61, 20);
            this.cb_tilexytype.TabIndex = 3;
            this.cb_tilexytype.Text = "经纬度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "l:层级,x:横向编号,y:竖向编号\r\n";
            // 
            // tb_filemark
            // 
            this.tb_filemark.Location = new System.Drawing.Point(68, 20);
            this.tb_filemark.Name = "tb_filemark";
            this.tb_filemark.Size = new System.Drawing.Size(50, 21);
            this.tb_filemark.TabIndex = 0;
            this.tb_filemark.Text = "x,y";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlb_tip,
            this.tpb_prog});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlb_tip
            // 
            this.tlb_tip.Name = "tlb_tip";
            this.tlb_tip.Size = new System.Drawing.Size(746, 17);
            this.tlb_tip.Spring = true;
            this.tlb_tip.Text = "已经准备好";
            this.tlb_tip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpb_prog
            // 
            this.tpb_prog.Name = "tpb_prog";
            this.tpb_prog.Size = new System.Drawing.Size(200, 16);
            this.tpb_prog.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 283);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片拼接";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "行：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(209, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(33, 21);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "列：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(236, 236);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "图片数：6张";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cb_setwm);
            this.Controls.Add(this.cb_filetype);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_wm);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Name = "Cut";
            this.Text = "Cut";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_wm.ResumeLayout(false);
            this.gb_wm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_wmimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_wmtran)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.p_setquality.ResumeLayout(false);
            this.p_setquality.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_setquality)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_setwm;
        private System.Windows.Forms.ComboBox cb_filetype;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_setoutdir;
        private System.Windows.Forms.Label lb_outdir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_tcount;
        private System.Windows.Forms.CheckBox cb_tcount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_owndir;
        private System.Windows.Forms.TextBox tb_dirfix;
        private System.Windows.Forms.ComboBox cb_maxcj;
        private System.Windows.Forms.TextBox tb_levelcount;
        private System.Windows.Forms.CheckBox cb_autolevels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_wm;
        private System.Windows.Forms.PictureBox pb_wmimg;
        private System.Windows.Forms.Label lb_wmtran;
        private System.Windows.Forms.TrackBar tb_wmtran;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel p_setquality;
        private System.Windows.Forms.Label lb_quality;
        private System.Windows.Forms.TrackBar tb_setquality;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_tilexytype;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_filemark;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlb_tip;
        private System.Windows.Forms.ToolStripProgressBar tpb_prog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
    }
}