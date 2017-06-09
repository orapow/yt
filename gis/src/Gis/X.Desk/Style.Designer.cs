namespace X.Desk
{
    partial class Style
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_bc = new System.Windows.Forms.Label();
            this.lb_fc = new System.Windows.Forms.Label();
            this.bt_no = new System.Windows.Forms.Button();
            this.bt_ok = new System.Windows.Forms.Button();
            this.nud_bw = new System.Windows.Forms.NumericUpDown();
            this.nud_bt = new System.Windows.Forms.NumericUpDown();
            this.nud_ft = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ft)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "边框大小：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "边框颜色：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "边框透明：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(219, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "示例";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(37, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "填充颜色：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "填充透明：";
            // 
            // lb_bc
            // 
            this.lb_bc.BackColor = System.Drawing.Color.Green;
            this.lb_bc.Location = new System.Drawing.Point(97, 68);
            this.lb_bc.Name = "lb_bc";
            this.lb_bc.Size = new System.Drawing.Size(54, 31);
            this.lb_bc.TabIndex = 5;
            this.lb_bc.Text = "    ";
            this.lb_bc.Click += new System.EventHandler(this.lb_bc_Click);
            // 
            // lb_fc
            // 
            this.lb_fc.BackColor = System.Drawing.Color.White;
            this.lb_fc.Location = new System.Drawing.Point(97, 166);
            this.lb_fc.Name = "lb_fc";
            this.lb_fc.Size = new System.Drawing.Size(54, 31);
            this.lb_fc.TabIndex = 5;
            this.lb_fc.Text = "    ";
            this.lb_fc.Click += new System.EventHandler(this.lb_fc_Click);
            // 
            // bt_no
            // 
            this.bt_no.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_no.Location = new System.Drawing.Point(327, 253);
            this.bt_no.Name = "bt_no";
            this.bt_no.Size = new System.Drawing.Size(75, 30);
            this.bt_no.TabIndex = 6;
            this.bt_no.Text = "取消";
            this.bt_no.UseVisualStyleBackColor = true;
            this.bt_no.Click += new System.EventHandler(this.bt_no_Click);
            // 
            // bt_ok
            // 
            this.bt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ok.Location = new System.Drawing.Point(246, 253);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new System.Drawing.Size(75, 30);
            this.bt_ok.TabIndex = 6;
            this.bt_ok.Text = "确定";
            this.bt_ok.UseVisualStyleBackColor = true;
            this.bt_ok.Click += new System.EventHandler(this.bt_ok_Click);
            // 
            // nud_bw
            // 
            this.nud_bw.Location = new System.Drawing.Point(97, 34);
            this.nud_bw.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_bw.Name = "nud_bw";
            this.nud_bw.Size = new System.Drawing.Size(54, 21);
            this.nud_bw.TabIndex = 7;
            this.nud_bw.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_bw.ValueChanged += new System.EventHandler(this.nud_bw_ValueChanged);
            // 
            // nud_bt
            // 
            this.nud_bt.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_bt.Location = new System.Drawing.Point(97, 111);
            this.nud_bt.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_bt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_bt.Name = "nud_bt";
            this.nud_bt.Size = new System.Drawing.Size(54, 21);
            this.nud_bt.TabIndex = 7;
            this.nud_bt.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_bt.ValueChanged += new System.EventHandler(this.nud_bt_ValueChanged);
            // 
            // nud_ft
            // 
            this.nud_ft.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_ft.Location = new System.Drawing.Point(97, 212);
            this.nud_ft.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ft.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ft.Name = "nud_ft";
            this.nud_ft.Size = new System.Drawing.Size(54, 21);
            this.nud_ft.TabIndex = 7;
            this.nud_ft.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_ft.ValueChanged += new System.EventHandler(this.nud_ft_ValueChanged);
            // 
            // Style
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 295);
            this.Controls.Add(this.nud_ft);
            this.Controls.Add(this.nud_bt);
            this.Controls.Add(this.nud_bw);
            this.Controls.Add(this.bt_ok);
            this.Controls.Add(this.bt_no);
            this.Controls.Add(this.lb_fc);
            this.Controls.Add(this.lb_bc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Style";
            this.Text = "绘图样式";
            this.Load += new System.EventHandler(this.Style_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_bt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_bc;
        private System.Windows.Forms.Label lb_fc;
        private System.Windows.Forms.Button bt_no;
        private System.Windows.Forms.Button bt_ok;
        private System.Windows.Forms.NumericUpDown nud_bw;
        private System.Windows.Forms.NumericUpDown nud_bt;
        private System.Windows.Forms.NumericUpDown nud_ft;
    }
}