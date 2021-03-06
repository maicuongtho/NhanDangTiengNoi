using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AudioUtils;
using System.IO;
using System.Media;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using untitled5;    
using ThuVien_THO;
using MLPTho; 
namespace NhanDangSo
{
    public partial class FromFileRegn : Form
    {
        MLP nn; 
        double[] testdata;
        WaveFile wave;
        bool dave;
        public FromFileRegn()
        {
            InitializeComponent();
            nn = new MLP(60, 10, 100, 0.2);
            testdata = new double[60];
            dave = false; 
         }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Wave file |*.wav";  
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                wave = new WaveFile(fileDlg.FileName);
             //   sbpMainPanel.Text = "Reading .WAV file...";
                lblFile.Text = fileDlg.FileName;   
                wave.Read();
                picVeWave.Refresh(); 
               // lblFs.Text = lblFs.Text + wave.m_Fmt.SamplesPerSec.ToString() + "Hz";
               // lblNumSamp.Text  =lblNumSamp.Text + wave.m_Data.NumSamples.ToString() + " mẫu";     
               // sbpMainPanel.Text = "Finished Reading .WAV file...";
               // picVeWave.BackColor = Color.Black;  
                wave.VeTinHieu(picVeWave, Pens.White); dave = true;   
            }

             
        }

        private void FromFileRegn_Paint(object sender, PaintEventArgs e)
        {
            
        }
        /*
        private void btnDFT_Click(object sender, EventArgs e)
        {
            int i,N = 512;
            double[] X= new double[N];
            int startpos = 0;
            double[] C = new double[13];
            while (startpos + N <= wave.m_Data.NumSamples)
            {
                wave.DFT(startpos, 0.02f, N, X);
                wave.MFCC(X, 8000, 512, 12, C);
                for (i = 1; i <= 12; i++) listBox1.Items.Add(Math.Round(C[i],4).ToString());
                startpos = startpos + (int)(0.01f * wave.m_Fmt.SamplesPerSec);
            }
            //-----Ley them khung cuoi cung ----------------
            startpos = wave.m_Data.NumSamples - (int)(0.02f * wave.m_Fmt.SamplesPerSec);
            wave.DFT(startpos, 0.02f, N, X);
            wave.MFCC(X, 8000, 512, 12, C);
            for (i = 1; i <= 12; i++) listBox1.Items.Add(Math.Round(C[i], 4).ToString());
            
            //-----------------------
            Graphics g=pictureBox1.CreateGraphics();
            int MM = pictureBox1.Height;
            float xscale = (float) pictureBox1.Width *2/ N;
            for (i = 0; i < N/2-1; i++)
            {
                g.DrawLine(Pens.Azure , i*xscale  ,MM- (float)(X[i])/10, (i + 1)*xscale , MM-(float)(X[i + 1])/10);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] t = new double[60]; 
            wave.toMFCC(t);
  
        }
        */
        private void btnNhanDdang_Click(object sender, EventArgs e)
        {
            double[] res = new double[11];
            double[] x = new double[60]; 

            ThoWave2MFCC mfcc = new ThoWave2MFCC();
            MWNumericArray waveM = new MWNumericArray(wave.DataCut);
            MWNumericArray Mout;
            MWArray rr = mfcc.wave2mfcc(waveM, 8000,12);
            richTextBox1.Text = rr.ToString(); 

            Mout = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);
            
            MLPTho.MLPTho lopmang = new MLPTho.MLPTho();
            Directory.SetCurrentDirectory("E:\\MatNhanDangSo_ver2\\NhanDangSo\\bin\\Debug");
          //  MessageBox.Show (  Directory.GetCurrentDirectory());  
            MWArray mang =lopmang.netLoad();

            MWNumericArray output = (MWNumericArray)lopmang.netRun(mang, Mout);
            Array s = output.ToArray(MWArrayComponent.Real);
            for (int i = 0; i < 10; i++) res[i] =(double)s.GetValue(0, i);

            listBox1.Items.Clear();   
           // nn.netRun(x,res);

            double max = res[0];
            int kq=0; //so nhan dang duoc
            for (int i = 0; i < 10; i++)
            {
                if (max < res[i])
                { 
                    max = res[i]; 
                    kq = i;
                }
                listBox1.Items.Add(Math.Round(res[i], 2).ToString());
            }
            // lblFs.Text = lblFs.Text + wave.m_Fmt.SamplesPerSec.ToString() + "Hz";
            // lblNumSamp.Text  =lblNumSamp.Text + wave.m_Data.NumSamples.ToString() + " mẫu";     
            // sbpMainPanel.Text = "Finished Reading .WAV file...";
            // picVeWave.BackColor = Color.Black;  

            if ((kq >= 2) && (kq <= 9)) kq--;
            //if (kq == 5) kq = 9;
            txtRes.Text = kq.ToString();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // double[] t = new double[1000];
           // nn.netLoad("so.net");
            MessageBox.Show("Load mạng xong","Thông báo");
            btnNhanDdang.Enabled = true;
            btnReadFile.Enabled = true;
            button1.Enabled = false ;
            button2.Enabled = true;
            button3.Enabled = true; 
            
        }

        private void picVeWave_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(ForeColor);
            if (dave) wave.VeTinHieu(picVeWave, Pens.White);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            double []res =new double [wave.m_Data.NumSamples];   
            int m=wave.endcut(64, 0.015,res); 
            
            Graphics grfx = pictureBox1.CreateGraphics();

            float xscale = 1.0f * pictureBox1.Width / m;
            float yscale = 0.4f * pictureBox1.Height;// / 32768;
            int dongngang = pictureBox1.Height / 2;
            grfx.DrawLine(Pens.Blue, 0, dongngang, pictureBox1.Width, dongngang);
            for (int i = 0; i < m - 1; i++)
            {
                grfx.DrawLine(Pens.Yellow, i * xscale, (float)res[i] * yscale + dongngang, (i + 1) * xscale, (float)res[i + 1] * yscale + dongngang);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
             SoundPlayer p = new SoundPlayer(lblFile.Text);
             p.Play();
 

        }
        //--------------------------------------------------------------------

    }
}