using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using untitled5; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NhanDangSo
{
    public partial class NhanDangOnline : Form
    {
        public NhanDangOnline()
        {
            InitializeComponent();
            timer1.Start();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
 
            btnThuAm.Text = "Đang thu âm";
            btnThuAm.Enabled = false;
            
            GhiAm.GhiAmclass ghi = new GhiAm.GhiAmclass(); //ghi âm 2 giây
            MWNumericArray dl = (MWNumericArray)ghi.ghiam();
            Array data = dl.ToArray(MWArrayComponent.Real);
            double[] wav = new double[data.Length];
            for (int i = 0; i < data.Length; i++) wav[i] = (double)data.GetValue(i,0);
            //Ve tin hieu
            Graphics grfx = pictureBox1.CreateGraphics();
            grfx.Clear(pictureBox1.BackColor ); 
            float xscale = 1.0f * pictureBox1.Width / data.Length;
            float yscale = 0.5f * pictureBox1.Height;// / 32768;
            int dongngang = pictureBox1.Height / 2;
            grfx.DrawLine(Pens.Blue, 0, dongngang, pictureBox1.Width, dongngang);
            for (int i = 0; i < data.Length - 1; i++)
            {
                grfx.DrawLine(Pens.Yellow, i * xscale, (float)wav[i] * yscale + dongngang, (i + 1) * xscale, (float)wav[i + 1] * yscale + dongngang);
            }
            btnThuAm.Enabled = true;
            btnThuAm.Text = "Thu âm & Nhận dạng"; 
            //-----------------Cat bo khoang lang
            double[] KQ1 = new double[data.Length];   
            int somauEndCut = endcut(wav, data.Length, 64, 0.015, KQ1);
            if (somauEndCut == 0) somauEndCut =data.Length; 
            double[] datacut = new double[somauEndCut];
            for (int i = 0; i < somauEndCut; i++) datacut[i] = KQ1[i];
  

            //------------Pha nhận dạng
            double[] res = new double[11];
            double[] x = new double[60];
            MLPTho.MLPTho lopmang = new MLPTho.MLPTho();
            MWArray mang = lopmang.netLoad();
            // ThoWave2MFCC mfcc = new ThoWave2MFCC();
          
            ThoWave2MFCC mfcc = new ThoWave2MFCC();
           
            MWNumericArray waveM = new MWNumericArray(datacut);
            MWNumericArray Mout;
            
            Mout = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000, 12);
                    
            MWNumericArray output = (MWNumericArray)lopmang.netRun(mang, Mout);
            Array s = output.ToArray(MWArrayComponent.Real);
            for (int i = 0; i < 10; i++) res[i] = (double)s.GetValue(0, i);

            //listBox1.Items.Clear();
            // nn.netRun(x,res);

            double max = res[0];
            int kq = 0; //so nhan dang duoc
            for (int i = 0; i < 10; i++)
            {
                if (max < res[i])
                {
                    max = res[i];
                    kq = i;
                }
               // listBox1.Items.Add(Math.Round(res[i], 2).ToString());
            }
            // lblFs.Text = lblFs.Text + wave.m_Fmt.SamplesPerSec.ToString() + "Hz";
            // lblNumSamp.Text  =lblNumSamp.Text + wave.m_Data.NumSamples.ToString() + " mẫu";     
            // sbpMainPanel.Text = "Finished Reading .WAV file...";
            // picVeWave.BackColor = Color.Black;  

            if ((kq >= 2) && (kq <= 9)) kq--;
            //if (kq == 5) kq = 9;
            textBox1.Text = kq.ToString(); 
        }
        private int endcut(double []Data,int lenData, int N, double thresholdpower, double[] res)  //trả về số mẫu
        {
            // double[] res = new double[m_NumSamples];
            double e;
            int i = 2;
            int t;
            int k = 0;
            int m = 0;
            while (i < lenData - N)
            {
                //tính năng lượng từng cửa khung độ rộng N
                e = 0;
                for (t = i; t < i + N; t++)
                    e += Data[t] * Data[t];
                if (e > thresholdpower)  // nếu lớn hơn ngưỡng dữ lại chép vào mảng res
                    for (t = i; t < i + N; t++)
                    {
                        res[m] = Data[t]; m++;
                    }
                i += N;
            }
            // Chep lai
            // for (i = 0; i < m; i++) m_Data[i] = res[i];
            return m;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();//  .ToString ()  ;   
        }
    }
}