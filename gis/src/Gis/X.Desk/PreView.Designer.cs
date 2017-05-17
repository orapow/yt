namespace X.Desk
{
    partial class PreView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreView));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_cost_time = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt_m_lt = new System.Windows.Forms.Button();
            this.bt_m_rt = new System.Windows.Forms.Button();
            this.bt_m_ct = new System.Windows.Forms.Button();
            this.bt_m_bt = new System.Windows.Forms.Button();
            this.bt_un_full = new System.Windows.Forms.Button();
            this.bt_m_tp = new System.Windows.Forms.Button();
            this.pb_view = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_full = new System.Windows.Forms.ToolStripButton();
            this.tsb_zoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsb_zoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_view)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_m_lt);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_m_rt);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_m_ct);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_m_bt);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_un_full);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.bt_m_tp);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.pb_view);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(584, 465);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(584, 512);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_tip,
            this.tssl_cost_time});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // tssl_tip
            // 
            this.tssl_tip.Name = "tssl_tip";
            this.tssl_tip.Size = new System.Drawing.Size(471, 17);
            this.tssl_tip.Spring = true;
            this.tssl_tip.Text = "层级：8，范围：117,125-215,254";
            this.tssl_tip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_cost_time
            // 
            this.tssl_cost_time.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_cost_time.Name = "tssl_cost_time";
            this.tssl_cost_time.Size = new System.Drawing.Size(98, 17);
            this.tssl_cost_time.Text = "绘制时间：0.36s";
            // 
            // bt_m_lt
            // 
            this.bt_m_lt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_m_lt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_m_lt.BackgroundImage")));
            this.bt_m_lt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_m_lt.Location = new System.Drawing.Point(506, 28);
            this.bt_m_lt.Name = "bt_m_lt";
            this.bt_m_lt.Size = new System.Drawing.Size(24, 24);
            this.bt_m_lt.TabIndex = 2;
            this.bt_m_lt.Text = " ";
            this.bt_m_lt.UseVisualStyleBackColor = true;
            this.bt_m_lt.Click += new System.EventHandler(this.bt_m_lt_Click);
            // 
            // bt_m_rt
            // 
            this.bt_m_rt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_m_rt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_m_rt.BackgroundImage")));
            this.bt_m_rt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_m_rt.Location = new System.Drawing.Point(556, 28);
            this.bt_m_rt.Name = "bt_m_rt";
            this.bt_m_rt.Size = new System.Drawing.Size(24, 24);
            this.bt_m_rt.TabIndex = 3;
            this.bt_m_rt.Text = " ";
            this.bt_m_rt.UseVisualStyleBackColor = true;
            this.bt_m_rt.Click += new System.EventHandler(this.bt_m_rt_Click);
            // 
            // bt_m_ct
            // 
            this.bt_m_ct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_m_ct.BackgroundImage = global::X.Desk.Properties.Resources.dot;
            this.bt_m_ct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_m_ct.Location = new System.Drawing.Point(531, 28);
            this.bt_m_ct.Name = "bt_m_ct";
            this.bt_m_ct.Size = new System.Drawing.Size(24, 24);
            this.bt_m_ct.TabIndex = 4;
            this.bt_m_ct.Text = " ";
            this.bt_m_ct.UseVisualStyleBackColor = true;
            this.bt_m_ct.Click += new System.EventHandler(this.bt_m_ct_Click);
            // 
            // bt_m_bt
            // 
            this.bt_m_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_m_bt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_m_bt.BackgroundImage")));
            this.bt_m_bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_m_bt.Location = new System.Drawing.Point(531, 53);
            this.bt_m_bt.Name = "bt_m_bt";
            this.bt_m_bt.Size = new System.Drawing.Size(24, 24);
            this.bt_m_bt.TabIndex = 5;
            this.bt_m_bt.Text = " ";
            this.bt_m_bt.UseVisualStyleBackColor = true;
            this.bt_m_bt.Click += new System.EventHandler(this.bt_m_bt_Click);
            // 
            // bt_un_full
            // 
            this.bt_un_full.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_un_full.BackgroundImage = global::X.Desk.Properties.Resources.uf;
            this.bt_un_full.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_un_full.Location = new System.Drawing.Point(556, 3);
            this.bt_un_full.Name = "bt_un_full";
            this.bt_un_full.Size = new System.Drawing.Size(24, 24);
            this.bt_un_full.TabIndex = 6;
            this.bt_un_full.Text = " ";
            this.bt_un_full.UseVisualStyleBackColor = true;
            this.bt_un_full.Visible = false;
            this.bt_un_full.Click += new System.EventHandler(this.bt_un_full_Click);
            // 
            // bt_m_tp
            // 
            this.bt_m_tp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_m_tp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_m_tp.BackgroundImage")));
            this.bt_m_tp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_m_tp.Location = new System.Drawing.Point(531, 3);
            this.bt_m_tp.Name = "bt_m_tp";
            this.bt_m_tp.Size = new System.Drawing.Size(24, 24);
            this.bt_m_tp.TabIndex = 6;
            this.bt_m_tp.Text = " ";
            this.bt_m_tp.UseVisualStyleBackColor = true;
            this.bt_m_tp.Click += new System.EventHandler(this.bt_m_tp_Click);
            // 
            // pb_view
            // 
            this.pb_view.BackColor = System.Drawing.Color.White;
            this.pb_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_view.Image = ((System.Drawing.Image)(resources.GetObject("pb_view.Image")));
            this.pb_view.Location = new System.Drawing.Point(0, 0);
            this.pb_view.Name = "pb_view";
            this.pb_view.Size = new System.Drawing.Size(584, 465);
            this.pb_view.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_view.TabIndex = 7;
            this.pb_view.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_full,
            this.tsb_zoomIn,
            this.tsb_zoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_full
            // 
            this.tsb_full.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_full.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_full.Image = global::X.Desk.Properties.Resources.f;
            this.tsb_full.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_full.Name = "tsb_full";
            this.tsb_full.Size = new System.Drawing.Size(23, 22);
            this.tsb_full.Text = "全屏";
            this.tsb_full.Click += new System.EventHandler(this.tsb_full_Click);
            // 
            // tsb_zoomIn
            // 
            this.tsb_zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_zoomIn.Image = global::X.Desk.Properties.Resources.z_in;
            this.tsb_zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_zoomIn.Name = "tsb_zoomIn";
            this.tsb_zoomIn.Size = new System.Drawing.Size(23, 22);
            this.tsb_zoomIn.Text = "缩小";
            this.tsb_zoomIn.Click += new System.EventHandler(this.tsb_zoomIn_Click);
            // 
            // tsb_zoomOut
            // 
            this.tsb_zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_zoomOut.Image = global::X.Desk.Properties.Resources.z_out;
            this.tsb_zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_zoomOut.Name = "tsb_zoomOut";
            this.tsb_zoomOut.Size = new System.Drawing.Size(23, 22);
            this.tsb_zoomOut.Text = "放大";
            this.tsb_zoomOut.Click += new System.EventHandler(this.tsb_zoomOut_Click);
            // 
            // PreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.toolStripContainer1);
            this.MinimumSize = new System.Drawing.Size(600, 550);
            this.Name = "PreView";
            this.Text = "服务预览";
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_view)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_full;
        private System.Windows.Forms.ToolStripButton tsb_zoomIn;
        private System.Windows.Forms.ToolStripButton tsb_zoomOut;
        private System.Windows.Forms.Button bt_m_lt;
        private System.Windows.Forms.Button bt_m_rt;
        private System.Windows.Forms.Button bt_m_ct;
        private System.Windows.Forms.Button bt_m_bt;
        private System.Windows.Forms.Button bt_m_tp;
        private System.Windows.Forms.PictureBox pb_view;
        private System.Windows.Forms.ToolStripStatusLabel tssl_cost_time;
        private System.Windows.Forms.ToolStripStatusLabel tssl_tip;
        private System.Windows.Forms.Button bt_un_full;
    }
}