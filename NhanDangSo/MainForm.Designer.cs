namespace NhanDangSo
{
    partial class frmMain
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
            this.btnHuanLuyen = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNhanDang_TuFile = new System.Windows.Forms.Button();
            this.btnNhanDang_Onilne = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuanLuyen
            // 
            this.btnHuanLuyen.Location = new System.Drawing.Point(6, 31);
            this.btnHuanLuyen.Name = "btnHuanLuyen";
            this.btnHuanLuyen.Size = new System.Drawing.Size(170, 23);
            this.btnHuanLuyen.TabIndex = 1;
            this.btnHuanLuyen.Text = "Huấn luyện mạng";
            this.btnHuanLuyen.UseVisualStyleBackColor = true;
            this.btnHuanLuyen.Click += new System.EventHandler(this.btnHuanLuyen_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(225, 89);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 23);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNhanDang_TuFile
            // 
            this.btnNhanDang_TuFile.Location = new System.Drawing.Point(6, 60);
            this.btnNhanDang_TuFile.Name = "btnNhanDang_TuFile";
            this.btnNhanDang_TuFile.Size = new System.Drawing.Size(170, 23);
            this.btnNhanDang_TuFile.TabIndex = 3;
            this.btnNhanDang_TuFile.Text = "Nhận dạng từ file";
            this.btnNhanDang_TuFile.UseVisualStyleBackColor = true;
            this.btnNhanDang_TuFile.Click += new System.EventHandler(this.btnNhanDang_TuFile_Click);
            // 
            // btnNhanDang_Onilne
            // 
            this.btnNhanDang_Onilne.Location = new System.Drawing.Point(6, 89);
            this.btnNhanDang_Onilne.Name = "btnNhanDang_Onilne";
            this.btnNhanDang_Onilne.Size = new System.Drawing.Size(170, 23);
            this.btnNhanDang_Onilne.TabIndex = 4;
            this.btnNhanDang_Onilne.Text = "Nhận dạng trực tiếp";
            this.btnNhanDang_Onilne.UseVisualStyleBackColor = true;
            this.btnNhanDang_Onilne.Click += new System.EventHandler(this.btnNhanDang_Onilne_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nhận dạng các số từ  0..9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(81, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ĐỒ ÁN MÔN HỌC TRÍ TUỆ NHÂN TẠO NÂNG CAO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mai Cường Thọ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trần Công Cẩn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Huỳnh Quang Đệ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNhanDang_Onilne);
            this.groupBox1.Controls.Add(this.btnNhanDang_TuFile);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnHuanLuyen);
            this.groupBox1.Location = new System.Drawing.Point(41, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 129);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(252, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(127, 71);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thực hiện";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 334);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhan dang tieng noi cac so tu 1..9";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuanLuyen;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnNhanDang_TuFile;
        private System.Windows.Forms.Button btnNhanDang_Onilne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

