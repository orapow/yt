namespace X.Desk
{
    partial class Links
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
            this.lb_links = new System.Windows.Forms.ListBox();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.bt_new = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_links
            // 
            this.lb_links.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lb_links.FormattingEnabled = true;
            this.lb_links.IntegralHeight = false;
            this.lb_links.ItemHeight = 30;
            this.lb_links.Location = new System.Drawing.Point(12, 41);
            this.lb_links.Name = "lb_links";
            this.lb_links.Size = new System.Drawing.Size(462, 278);
            this.lb_links.TabIndex = 0;
            this.lb_links.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lb_links_DrawItem);
            this.lb_links.DoubleClick += new System.EventHandler(this.lb_links_DoubleClick);
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(59, 12);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(357, 21);
            this.tb_url.TabIndex = 1;
            // 
            // bt_new
            // 
            this.bt_new.Location = new System.Drawing.Point(422, 11);
            this.bt_new.Name = "bt_new";
            this.bt_new.Size = new System.Drawing.Size(52, 23);
            this.bt_new.TabIndex = 2;
            this.bt_new.Text = "添加";
            this.bt_new.UseVisualStyleBackColor = true;
            this.bt_new.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "地址：";
            // 
            // Links
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_new);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.lb_links);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Links";
            this.Text = "链接管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_links;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Button bt_new;
        private System.Windows.Forms.Label label1;
    }
}