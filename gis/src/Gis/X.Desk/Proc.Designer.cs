namespace X.Desk
{
    partial class Proc
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
            this.pb_all = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_cur = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_all = new System.Windows.Forms.Label();
            this.lb_cur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_all
            // 
            this.pb_all.Location = new System.Drawing.Point(96, 30);
            this.pb_all.Name = "pb_all";
            this.pb_all.Size = new System.Drawing.Size(294, 13);
            this.pb_all.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "总进度：";
            // 
            // pb_cur
            // 
            this.pb_cur.Location = new System.Drawing.Point(96, 83);
            this.pb_cur.Name = "pb_cur";
            this.pb_cur.Size = new System.Drawing.Size(294, 13);
            this.pb_cur.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前进度：";
            // 
            // lb_all
            // 
            this.lb_all.AutoSize = true;
            this.lb_all.Location = new System.Drawing.Point(94, 55);
            this.lb_all.Name = "lb_all";
            this.lb_all.Size = new System.Drawing.Size(71, 12);
            this.lb_all.TabIndex = 1;
            this.lb_all.Text = "正在生成...";
            // 
            // lb_cur
            // 
            this.lb_cur.AutoSize = true;
            this.lb_cur.Location = new System.Drawing.Point(94, 111);
            this.lb_cur.Name = "lb_cur";
            this.lb_cur.Size = new System.Drawing.Size(107, 12);
            this.lb_cur.TabIndex = 1;
            this.lb_cur.Text = "正在处理 图层1...";
            // 
            // Proc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 190);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_cur);
            this.Controls.Add(this.lb_all);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_cur);
            this.Controls.Add(this.pb_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Proc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "正在发布";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_all;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pb_cur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_all;
        private System.Windows.Forms.Label lb_cur;
    }
}