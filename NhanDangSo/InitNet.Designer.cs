namespace NhanDangSo
{
    partial class InitNet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_activate_func = new System.Windows.Forms.ComboBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.txt_HidenNoron_Num = new System.Windows.Forms.TextBox();
            this.txt_output_num = new System.Windows.Forms.TextBox();
            this.txt_input_num = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_activate_func);
            this.groupBox1.Controls.Add(this.txtThreshold);
            this.groupBox1.Controls.Add(this.txt_HidenNoron_Num);
            this.groupBox1.Controls.Add(this.txt_output_num);
            this.groupBox1.Controls.Add(this.txt_input_num);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(40, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông số";
            // 
            // cmb_activate_func
            // 
            this.cmb_activate_func.FormattingEnabled = true;
            this.cmb_activate_func.Location = new System.Drawing.Point(144, 165);
            this.cmb_activate_func.Name = "cmb_activate_func";
            this.cmb_activate_func.Size = new System.Drawing.Size(129, 21);
            this.cmb_activate_func.TabIndex = 9;
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(148, 132);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(123, 20);
            this.txtThreshold.TabIndex = 8;
            // 
            // txt_HidenNoron_Num
            // 
            this.txt_HidenNoron_Num.Location = new System.Drawing.Point(150, 98);
            this.txt_HidenNoron_Num.Name = "txt_HidenNoron_Num";
            this.txt_HidenNoron_Num.Size = new System.Drawing.Size(122, 20);
            this.txt_HidenNoron_Num.TabIndex = 7;
            // 
            // txt_output_num
            // 
            this.txt_output_num.Location = new System.Drawing.Point(148, 64);
            this.txt_output_num.Name = "txt_output_num";
            this.txt_output_num.Size = new System.Drawing.Size(125, 20);
            this.txt_output_num.TabIndex = 6;
            // 
            // txt_input_num
            // 
            this.txt_input_num.Location = new System.Drawing.Point(148, 33);
            this.txt_input_num.Name = "txt_input_num";
            this.txt_input_num.Size = new System.Drawing.Size(126, 20);
            this.txt_input_num.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Hàm kích hoạt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ngưỡng trọng số";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số neuron lớp ẩn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số ngõ ra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Số ngõ vào";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Khởi tạo mạng";
            // 
            // InitNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 282);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "InitNet";
            this.Text = "InitNet";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_activate_func;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.TextBox txt_HidenNoron_Num;
        private System.Windows.Forms.TextBox txt_output_num;
        private System.Windows.Forms.TextBox txt_input_num;
    }
}