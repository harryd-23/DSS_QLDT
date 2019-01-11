namespace QLDT
{
    partial class QLDT_MAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLDT_MAIN));
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnAsk = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BackgroundImage = global::QLDT.Properties.Resources.about;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAbout.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAbout.Location = new System.Drawing.Point(548, 106);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(260, 321);
            this.btnAbout.TabIndex = 1;
            this.btnAbout.Text = "Thông Tin Phần Mềm";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.MouseLeave += new System.EventHandler(this.btnAbout_MouseLeave);
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            this.btnAbout.MouseHover += new System.EventHandler(this.btnAbout_MouseHover);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.BackgroundImage = global::QLDT.Properties.Resources.show;
            this.btnShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnShow.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnShow.Location = new System.Drawing.Point(290, 106);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(233, 321);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Hiện Kết Quả";
            this.btnShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.MouseLeave += new System.EventHandler(this.btnShow_MouseLeave);
            this.btnShow.Click += new System.EventHandler(this.btnHien_Click);
            this.btnShow.MouseHover += new System.EventHandler(this.btnShow_MouseHover);
            // 
            // btnAsk
            // 
            this.btnAsk.BackColor = System.Drawing.Color.Transparent;
            this.btnAsk.BackgroundImage = global::QLDT.Properties.Resources.ask;
            this.btnAsk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAsk.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAsk.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAsk.FlatAppearance.BorderSize = 0;
            this.btnAsk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAsk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsk.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAsk.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAsk.Location = new System.Drawing.Point(39, 107);
            this.btnAsk.Name = "btnAsk";
            this.btnAsk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAsk.Size = new System.Drawing.Size(220, 321);
            this.btnAsk.TabIndex = 0;
            this.btnAsk.Text = "Đặt Câu Hỏi";
            this.btnAsk.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAsk.UseVisualStyleBackColor = false;
            this.btnAsk.MouseLeave += new System.EventHandler(this.btnAsk_MouseLeave);
            this.btnAsk.Click += new System.EventHandler(this.btnAsk_Click);
            this.btnAsk.MouseHover += new System.EventHandler(this.btnAsk_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Sitka Banner", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Location = new System.Drawing.Point(29, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(779, 44);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "PHẦN MỀM HỖ TRỢ QUẢN LÝ CƠ SỞ ĐÀO TẠO CÔNG NGHỆ THÔNG TIN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(245, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "---------✹✹✹----------";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QLDT_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(853, 464);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnAsk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QLDT_MAIN";
            this.Text = "PHẦN MỀM QUẢN LÝ CƠ SỞ ĐÀO TẠO CNTT CẢ NƯỚC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAsk;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
    }
}

