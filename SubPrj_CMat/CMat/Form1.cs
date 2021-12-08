using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using untitled4;
using xor; 
namespace CMat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] a = new double[2] { 99, 10 };
            double[] b = new double[2] { 33, 33 };
            MWNumericArray mwnA = new MWNumericArray(a);
            MWNumericArray mwnB = new MWNumericArray(b);
            untitled4class t = new untitled4class();
            MWArray mwS = t.Cong(mwnA, mwnB);
            MessageBox.Show (  mwS.ToString());

            double[,] m = new double[4, 2] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1,1} };
            double[,] n = new double[4, 2] { { 0, 0 }, { 0, 1 }, { 0, 1 }, { 0, 0 }};

            MWNumericArray mwnIn = new MWNumericArray(m);
            MWNumericArray mwnOut = new MWNumericArray(n);
            xorclass x = new xorclass();
            MWArray tt=  x.LuyenXor(mwnIn, mwnOut, 1500);
            rt1.Text = tt.ToString();  
            //rt1.Text = mwnC.ToString();   
             }

    }
}