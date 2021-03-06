using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using ThuVien_THO;
using untitled5;


// Đọc file trong thư mục 10 ==============================================

/*label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 10";
label6.Refresh();
s = Directory.GetFiles(d[10]); // Lấy danh sách các file trong thư mục
double[] TRAIN10;
soluongfile[10] = s.Length;
TRAIN10 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
{
    wave = new WaveFile(s[j]);
    wave.Read();
    waveM = new MWNumericArray(wave.DataCut);
    Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
    tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
    for (k = 0; k < 60; k++) TRAIN10[j * 60 + k] = (double)tamArr.GetValue(0, k);
}*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AudioUtils;
using System.IO;

using MLPTho; 
namespace NhanDangSo
{
    public partial class TrainingNet : Form
    {
        WaveFile wave;
        MLP nn;  //Khai báo một mạng nơron
        double[] traindata;

        ThoWave2MFCC mfcc; // = new ThoWave2MFCC();
        MWNumericArray waveM;// = new MWNumericArray(wave.Data);
        MWNumericArray Mfcc12out;
        MWArray kqnet;
        MLPTho.MLPTho mang;
        public TrainingNet()
        {
            InitializeComponent();
            nn = new MLP(60, 10, 100, 0.6); 
            traindata = new double[61];
            mfcc = new ThoWave2MFCC();
            mang = new MLPTho.MLPTho();
            
        }
       private void LuyenTap(string tap)
       {
       
       }
       private void btnTrain_Click(object sender, EventArgs e)
        {
            //Đọc các thư mục số trong thư mục TRAIN chỉ ra, luyện từng file tương ứng. 
            //  MessageBox.Show("Bắt đầu thực hiện");
            //nn.netLoad("so.net"); 
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 0";
            label6.Refresh();
            String[] s;
            String[] d = Directory.GetDirectories(textBox2.Text);
            int[] soluongfile = new int[11]; //lưu số lượng file trong mỗi thư mục
            // Đọc dữ liệu các file trong thư mục, nối đuôi dữ liệu
            int i, j, k;
            // Đọc file trong thư mục 0 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 0";
            s = Directory.GetFiles(d[0]); // Lấy danh sách các file trong thư mục
            double[] TRAIN0;
            soluongfile[0] = s.Length;
            TRAIN0 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            Array tamArr;  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real  );
                for (k = 0; k < 60; k++) TRAIN0[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 1 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 1";
            s = Directory.GetFiles(d[1]); // Lấy danh sách các file trong thư mục
            double[] TRAIN1;
            soluongfile[1] = s.Length;
            TRAIN1 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            //tam = new double[61];  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN1[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 2 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 2";
            label6.Refresh();
            s = Directory.GetFiles(d[2]); // Lấy danh sách các file trong thư mục
            double[] TRAIN2;
            soluongfile[2] = s.Length;
            TRAIN2 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN2[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 3 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 3";
            label6.Refresh();
            s = Directory.GetFiles(d[3]); // Lấy danh sách các file trong thư mục
            double[] TRAIN3;
            soluongfile[3] = s.Length;
            TRAIN3 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN3[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 4 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 4";
            label6.Refresh();
            s = Directory.GetFiles(d[4]); // Lấy danh sách các file trong thư mục
            double[] TRAIN4;
            soluongfile[4] = s.Length;
            TRAIN4 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN4[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 5 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 5";
            label6.Refresh();
            s = Directory.GetFiles(d[5]); // Lấy danh sách các file trong thư mục
            double[] TRAIN5;
            soluongfile[5] = s.Length;
            TRAIN5 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN5[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 6 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 6";
            label6.Refresh();
            s = Directory.GetFiles(d[6]); // Lấy danh sách các file trong thư mục
            double[] TRAIN6;
            soluongfile[6] = s.Length;
            TRAIN6 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN6[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 7 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 7";
            label6.Refresh();
            s = Directory.GetFiles(d[7]); // Lấy danh sách các file trong thư mục
            double[] TRAIN7;
            soluongfile[7] = s.Length;
            TRAIN7 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN7[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 8 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 8";
            label6.Refresh();
            s = Directory.GetFiles(d[8]); // Lấy danh sách các file trong thư mục
            double[] TRAIN8;
            soluongfile[8] = s.Length;
            TRAIN8 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN8[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 9 ==============================================
            label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 9";
            label6.Refresh();
            s = Directory.GetFiles(d[9]); // Lấy danh sách các file trong thư mục
            double[] TRAIN9;
            soluongfile[9] = s.Length;
            TRAIN9 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN9[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }
            // Đọc file trong thư mục 10 ==============================================
           
            /*label6.Text = "Đang tính toán các vector đặc trưng MFCC...số 10";
            label6.Refresh();
            s = Directory.GetFiles(d[10]); // Lấy danh sách các file trong thư mục
            double[] TRAIN10;
            soluongfile[10] = s.Length;
            TRAIN10 = new double[61 * s.Length];   // Cấp phát dãy dữ liệu  
            for (j = 0; j < s.Length; j++)  //Duyệt qua từng file trong tm
            {
                wave = new WaveFile(s[j]);
                wave.Read();
                waveM = new MWNumericArray(wave.DataCut);
                Mfcc12out = (MWNumericArray)mfcc.wave2mfcc(waveM, 8000,12);  //tinh mfcc trung binh
                tamArr = Mfcc12out.ToArray(MWArrayComponent.Real);
                for (k = 0; k < 60; k++) TRAIN10[j * 60 + k] = (double)tamArr.GetValue(0, k);
            }*/
            int hhh = 0;
            GC.Collect();
            //----------Hết chuẩn bị dữ liệu cho mạng------------------------------------
          
           int tong=soluongfile[0]+ soluongfile[1]+soluongfile[2]+soluongfile[3]+
               soluongfile[4]+soluongfile[5]+soluongfile[6]+soluongfile[7]+soluongfile[8]+
               soluongfile[9];// +soluongfile[10];

            double[,] DataTrain= new double [tong,60];
            double[,] DataTarget = new double[tong, 10];
            int _i; int hang=0;
            //----------------------------------------------------------0
            for (_i = 0; _i < soluongfile[0]; _i++)
               for (j = 0; j < 60; j++)
                    DataTrain[_i,j] = TRAIN0[_i * 60 + j];
            for (_i = 0; _i < soluongfile[0]; _i++) DataTarget[_i, 0] = 1;
            hang += soluongfile[0];
            //----------------------------------------------------------1
            for (_i = 0; _i < soluongfile[1]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i+hang, j] = TRAIN1[_i * 60 + j];
            for (_i = 0; _i < soluongfile[1]; _i++) DataTarget[_i+hang, 1] = 1;
            hang += soluongfile[1];

            //----------------------------------------------------------2
            for (_i = 0; _i < soluongfile[2]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN2[_i * 60 + j];
            for (_i = 0; _i < soluongfile[2]; _i++) DataTarget[_i + hang, 2] = 1;
            hang += soluongfile[2];
            //----------------------------------------------------------3
            for (_i = 0; _i < soluongfile[3]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN3[_i * 60 + j];
            for (_i = 0; _i < soluongfile[3]; _i++) DataTarget[_i + hang, 3] = 1;
            hang += soluongfile[3];

            //----------------------------------------------------------4
            for (_i = 0; _i < soluongfile[4]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN4[_i * 60 + j];
            for (_i = 0; _i < soluongfile[4]; _i++) DataTarget[_i + hang, 4] = 1;
            hang += soluongfile[4];

           //----------------------------------------------------------5
            for (_i = 0; _i < soluongfile[5]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN5[_i * 60 +j];
            for (_i = 0; _i < soluongfile[5]; _i++) DataTarget[_i + hang, 5] = 1;
            hang += soluongfile[5];
           //----------------------------------------------------------6
            for (_i = 0; _i < soluongfile[6]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN6[_i * 60 + j];
            for (_i = 0; _i < soluongfile[6]; _i++) DataTarget[_i + hang, 6] = 1;
            hang += soluongfile[6];
            //----------------------------------------------------------7
            for (_i = 0; _i < soluongfile[7]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN7[_i * 60 + j];
            for (_i = 0; _i < soluongfile[7]; _i++) DataTarget[_i + hang, 7] = 1;
            hang += soluongfile[7];
           //----------------------------------------------------------8
            for (_i = 0; _i < soluongfile[8]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN8[_i * 60 + j];
            for (_i = 0; _i < soluongfile[8]; _i++) DataTarget[_i + hang, 8] = 1;
            hang += soluongfile[8];
           //----------------------------------------------------------9
            for (_i = 0; _i < soluongfile[9]; _i++)
                for (j = 0; j < 60; j++)
                    DataTrain[_i + hang, j] = TRAIN9[_i * 60 + j];
            for (_i = 0; _i < soluongfile[9]; _i++) DataTarget[_i + hang, 9] = 1;
            hang += soluongfile[9];
           //----------------------------------------------------------3
            //for (_i = 0; _i < soluongfile[10]; _i++)
           //     for (j = 0; j < 60; j++)
           //         DataTrain[_i + hang, j] = TRAIN10[_i * 60 + j];
          //  for (_i = 0; _i < soluongfile[10]; _i++) DataTarget[_i + hang, 10] = 1;
          //  hang += soluongfile[10];
            MWNumericArray Dtrain= new MWNumericArray(DataTrain);
            MWNumericArray Dtag = new MWNumericArray(DataTarget);
            //MLPTho.MLPTho luyen = new MLPTho.MLPTho();
            Int64 solan = Convert.ToInt64(textBox4.Text); 
            kqnet= mang.netTrain(Dtrain, Dtag, solan);
           
           
           
            
            /*         label6.Text = "Đang luyện mạng...";
           // dữ liệu ra mong muốn
           double[] y0 = new double[11]; y0[0] = 1;
           double[] y1 = new double[11]; y1[1] = 1;
           double[] y2 = new double[11]; y2[2] = 1;
           double[] y3 = new double[11]; y3[3] = 1;
           double[] y4 = new double[11]; y4[4] = 1;
           double[] y5 = new double[11]; y5[5] = 1;
           double[] y6 = new double[11]; y6[6] = 1;
           double[] y7 = new double[11]; y7[7] = 1;
           double[] y8 = new double[11]; y8[8] = 1;
           double[] y9 = new double[11]; y9[9] = 1;
           double[] y10 = new double[11]; y10[10] = 1;


           Int64 _k, solan = Convert.ToInt64(textBox4.Text);  // Lấy số lần luyện mạng
           int _i, n, tt;
           double[] tam = new double[60]; 
           for (_k = 0; _k < solan; _k++)
           {
               // Luyện số 0, -----------------------------
               for (_i = 0; _i < soluongfile[0]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN0[_i * 60 + n];
                   nn.netTrain(tam, y0);
               }
               // Luyện số 1, -----------------------------
               for (_i = 0; _i < soluongfile[1]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN1[_i * 60 + n];
                   nn.netTrain(tam, y1);
               }
               // Luyện số 2, -----------------------------
               for (_i = 0; _i < soluongfile[2]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN2[_i * 60 + n];
                   nn.netTrain(tam, y2);
               }
               // Luyện số 3, -----------------------------
               for (_i = 0; _i < soluongfile[3]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN3[_i * 60 + n];
                   nn.netTrain(tam, y3);
               }
               // Luyện số 4, -----------------------------
               for (_i = 0; _i < soluongfile[4]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN4[_i * 60 + n];
                   nn.netTrain(tam, y4);
               }
               // Luyện số 5, -----------------------------
               for (_i = 0; _i < soluongfile[5]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN5[_i * 60 + n];
                   nn.netTrain(tam, y5);
               }
               // Luyện số 6, -----------------------------
               for (_i = 0; _i < soluongfile[6]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN6[_i * 60 + n];
                   nn.netTrain(tam, y6);
               }
               // Luyện số 7, -----------------------------
               for (_i = 0; _i < soluongfile[7]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN7[_i * 60 + n];
                   nn.netTrain(tam, y7);
               }
               // Luyện số 8, -----------------------------
               for (_i = 0; _i < soluongfile[8]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN8[_i * 60 + n];
                   nn.netTrain(tam, y8);
               }
               // Luyện số 9, -----------------------------
               for (_i = 0; _i < soluongfile[9]; _i++)
               {
                   for (n = 0; n < 60; n++)
                       tam[n] = TRAIN9[_i * 60 + n];
                   nn.netTrain(tam, y9);
               }
               // Luyện số 10, -----------------------------
              // for (_i = 0; _i < soluongfile[10]; _i++)
             //  {
             //      for (n = 0; n < 60; n++)
             //          tam[n] = TRAIN10[_i * 60 + n];
             //      nn.netTrain(tam, y10);
              // }
                
               tt = (int)Math.Round(((float)_k / solan) * 100);
               label6.Text = "Đang luyện mạng..." + tt.ToString() + "%";
               label6.Refresh();
           }
           */
            MessageBox.Show("Luyện mạng thành công. Hãy lưu lại"); 
        }


    private void btnSave_Click(object sender, EventArgs e)
        {
            MWArray rt= mang.netSave(kqnet); 
            MessageBox.Show("Đã lưu xong. Mạng có tên là: so.mat","Lưu mạng") ;  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Directory.GetCurrentDirectory();  
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = 10;
            GC.Collect();
            MessageBox.Show(x.ToString()); 
        }

       
    }
}