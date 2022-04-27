namespace HRFileUpload
{
    partial class frmFileUpload
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUploadStart = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalCnt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtUpMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpCnt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUploadStart);
            this.panel1.Controls.Add(this.txtFolderPath);
            this.panel1.Controls.Add(this.btnOpenFolder);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalCnt);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtUpMsg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUpCnt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 289);
            this.panel1.TabIndex = 3;
            // 
            // btnUploadStart
            // 
            this.btnUploadStart.Location = new System.Drawing.Point(99, 62);
            this.btnUploadStart.Name = "btnUploadStart";
            this.btnUploadStart.Size = new System.Drawing.Size(110, 32);
            this.btnUploadStart.TabIndex = 33;
            this.btnUploadStart.Text = "업로드 시작";
            this.btnUploadStart.UseVisualStyleBackColor = true;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtFolderPath.Location = new System.Drawing.Point(99, 24);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.ReadOnly = true;
            this.txtFolderPath.Size = new System.Drawing.Size(673, 21);
            this.txtFolderPath.TabIndex = 32;
            this.txtFolderPath.TabStop = false;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(24, 22);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(69, 23);
            this.btnOpenFolder.TabIndex = 31;
            this.btnOpenFolder.Text = "폴더선택";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "전체파일건수";
            // 
            // txtTotalCnt
            // 
            this.txtTotalCnt.Location = new System.Drawing.Point(117, 132);
            this.txtTotalCnt.Name = "txtTotalCnt";
            this.txtTotalCnt.ReadOnly = true;
            this.txtTotalCnt.Size = new System.Drawing.Size(116, 21);
            this.txtTotalCnt.TabIndex = 29;
            this.txtTotalCnt.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(778, 1);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(12, 115);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(778, 1);
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            // 
            // txtUpMsg
            // 
            this.txtUpMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpMsg.BackColor = System.Drawing.SystemColors.Window;
            this.txtUpMsg.Location = new System.Drawing.Point(24, 168);
            this.txtUpMsg.Name = "txtUpMsg";
            this.txtUpMsg.ReadOnly = true;
            this.txtUpMsg.Size = new System.Drawing.Size(748, 21);
            this.txtUpMsg.TabIndex = 16;
            this.txtUpMsg.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "진행건수";
            // 
            // txtUpCnt
            // 
            this.txtUpCnt.Location = new System.Drawing.Point(311, 132);
            this.txtUpCnt.Name = "txtUpCnt";
            this.txtUpCnt.ReadOnly = true;
            this.txtUpCnt.Size = new System.Drawing.Size(116, 21);
            this.txtUpCnt.TabIndex = 9;
            this.txtUpCnt.TabStop = false;
            // 
            // frmFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 289);
            this.Controls.Add(this.panel1);
            this.Name = "frmFileUpload";
            this.Text = "인사 첨부파일 업로드";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtUpMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpCnt;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalCnt;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnUploadStart;
    }
}