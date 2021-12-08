using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NhanDangSo
{
    public partial class frmMain : Form
    {
       
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnNhanDang_TuFile_Click(object sender, EventArgs e)
        {
            FromFileRegn ff = new FromFileRegn() ;
            ff.ShowDialog(); 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();    
        }

        private void btnHuanLuyen_Click(object sender, EventArgs e)
        {
            TrainingNet ff = new TrainingNet();
            ff.ShowDialog(); 
        }

        private void btnNhanDang_Onilne_Click(object sender, EventArgs e)
        {
            NhanDangOnline nh = new NhanDangOnline();
            nh.ShowDialog();
        }
    }
}