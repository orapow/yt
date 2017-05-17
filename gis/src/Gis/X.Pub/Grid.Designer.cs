namespace X.Pub
{
    partial class Pub
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
            this.label5 = new System.Windows.Forms.Label();
            this.cb_outtype = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_addr = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.gp_tv_format = new System.Windows.Forms.GroupBox();
            this.cbl_fields = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_namefield = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_open = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_demo = new System.Windows.Forms.TextBox();
            this.bt_pre = new System.Windows.Forms.Button();
            this.bt_nxt = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsp_pr = new System.Windows.Forms.ToolStripProgressBar();
            this.tssl_pr = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3.SuspendLayout();
            this.gp_tv_format.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "输出为：";
            // 
            // cb_outtype
            // 
            this.cb_outtype.FormattingEnabled = true;
            this.cb_outtype.Items.AddRange(new object[] {
            "YtGis服务",
            "Json文件",
            "Excel文件",
            "文本文件"});
            this.cb_outtype.Location = new System.Drawing.Point(77, 23);
            this.cb_outtype.Name = "cb_outtype";
            this.cb_outtype.Size = new System.Drawing.Size(136, 20);
            this.cb_outtype.TabIndex = 4;
            this.cb_outtype.Text = "YtGis服务";
            this.cb_outtype.SelectedIndexChanged += new System.EventHandler(this.cb_outtype_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_open);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cb_outtype);
            this.groupBox3.Controls.Add(this.tb_addr);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 80);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "输出设置";
            // 
            // tb_addr
            // 
            this.tb_addr.Location = new System.Drawing.Point(77, 48);
            this.tb_addr.Name = "tb_addr";
            this.tb_addr.Size = new System.Drawing.Size(259, 21);
            this.tb_addr.TabIndex = 1;
            this.tb_addr.Text = "http://localhost:17830/api/grid.inport";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Location = new System.Drawing.Point(518, 293);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(92, 30);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "立即发布";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // gp_tv_format
            // 
            this.gp_tv_format.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gp_tv_format.Controls.Add(this.label6);
            this.gp_tv_format.Controls.Add(this.cb_namefield);
            this.gp_tv_format.Controls.Add(this.cbl_fields);
            this.gp_tv_format.Location = new System.Drawing.Point(12, 98);
            this.gp_tv_format.Name = "gp_tv_format";
            this.gp_tv_format.Size = new System.Drawing.Size(375, 225);
            this.gp_tv_format.TabIndex = 4;
            this.gp_tv_format.TabStop = false;
            this.gp_tv_format.Text = "输出字段";
            // 
            // cbl_fields
            // 
            this.cbl_fields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbl_fields.CheckOnClick = true;
            this.cbl_fields.FormattingEnabled = true;
            this.cbl_fields.Location = new System.Drawing.Point(7, 52);
            this.cbl_fields.MultiColumn = true;
            this.cbl_fields.Name = "cbl_fields";
            this.cbl_fields.Size = new System.Drawing.Size(362, 164);
            this.cbl_fields.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "名称字段：";
            // 
            // cb_namefield
            // 
            this.cb_namefield.FormattingEnabled = true;
            this.cb_namefield.Location = new System.Drawing.Point(77, 23);
            this.cb_namefield.Name = "cb_namefield";
            this.cb_namefield.Size = new System.Drawing.Size(136, 20);
            this.cb_namefield.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "输出地址：";
            // 
            // bt_open
            // 
            this.bt_open.Location = new System.Drawing.Point(342, 47);
            this.bt_open.Name = "bt_open";
            this.bt_open.Size = new System.Drawing.Size(25, 23);
            this.bt_open.TabIndex = 6;
            this.bt_open.Text = "...";
            this.bt_open.UseVisualStyleBackColor = true;
            this.bt_open.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_demo);
            this.groupBox1.Location = new System.Drawing.Point(394, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 275);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "示例数据";
            // 
            // tb_demo
            // 
            this.tb_demo.Enabled = false;
            this.tb_demo.Location = new System.Drawing.Point(6, 20);
            this.tb_demo.Multiline = true;
            this.tb_demo.Name = "tb_demo";
            this.tb_demo.Size = new System.Drawing.Size(204, 249);
            this.tb_demo.TabIndex = 0;
            // 
            // bt_pre
            // 
            this.bt_pre.Location = new System.Drawing.Point(393, 293);
            this.bt_pre.Name = "bt_pre";
            this.bt_pre.Size = new System.Drawing.Size(24, 30);
            this.bt_pre.TabIndex = 6;
            this.bt_pre.Text = "<";
            this.bt_pre.UseVisualStyleBackColor = true;
            this.bt_pre.Click += new System.EventHandler(this.bt_pre_Click);
            // 
            // bt_nxt
            // 
            this.bt_nxt.Location = new System.Drawing.Point(423, 293);
            this.bt_nxt.Name = "bt_nxt";
            this.bt_nxt.Size = new System.Drawing.Size(24, 30);
            this.bt_nxt.TabIndex = 6;
            this.bt_nxt.Text = ">";
            this.bt_nxt.UseVisualStyleBackColor = true;
            this.bt_nxt.Click += new System.EventHandler(this.bt_nxt_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_info,
            this.tsp_pr,
            this.tssl_pr});
            this.statusStrip1.Location = new System.Drawing.Point(0, 333);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(622, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_info
            // 
            this.tssl_info.Name = "tssl_info";
            this.tssl_info.Size = new System.Drawing.Size(293, 17);
            this.tssl_info.Spring = true;
            this.tssl_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsp_pr
            // 
            this.tsp_pr.AutoToolTip = true;
            this.tsp_pr.Name = "tsp_pr";
            this.tsp_pr.Size = new System.Drawing.Size(150, 16);
            // 
            // tssl_pr
            // 
            this.tssl_pr.Name = "tssl_pr";
            this.tssl_pr.Size = new System.Drawing.Size(0, 17);
            // 
            // Pub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 355);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.bt_nxt);
            this.Controls.Add(this.bt_pre);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gp_tv_format);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Pub";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输出地图要素";
            this.Load += new System.EventHandler(this.Pub_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gp_tv_format.ResumeLayout(false);
            this.gp_tv_format.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_outtype;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_addr;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.GroupBox gp_tv_format;
        private System.Windows.Forms.CheckedListBox cbl_fields;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_namefield;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_open;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_demo;
        private System.Windows.Forms.Button bt_pre;
        private System.Windows.Forms.Button bt_nxt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_info;
        private System.Windows.Forms.ToolStripProgressBar tsp_pr;
        private System.Windows.Forms.ToolStripStatusLabel tssl_pr;
    }
}