using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using System.Diagnostics;

namespace AudioUtils
{
	/// <summary>
	/// Summary description for WaveFile.
	/// </summary>
    ///
    /// <summary>
    /// The Riff header is 12 bytes long
    /// </summary>
    class Riff
    {
        public Riff()
        {
            m_RiffID = new byte[4];
            m_RiffFormat = new byte[4];
        }

        public void ReadRiff(FileStream inFS)
        {
            inFS.Read(m_RiffID, 0, 4);

            Debug.Assert(m_RiffID[0] == 82, "Riff ID Not Valid");

            BinaryReader binRead = new BinaryReader(inFS);

            m_RiffSize = binRead.ReadUInt32();

            inFS.Read(m_RiffFormat, 0, 4);
        }

        public byte[] RiffID
        {
            get { return m_RiffID; }
        }

        public uint RiffSize
        {
            get { return (m_RiffSize); }
        }

        public byte[] RiffFormat
        {
            get { return m_RiffFormat; }
        }

        private byte[] m_RiffID;
        private uint m_RiffSize;
        private byte[] m_RiffFormat;
    }
    /// <summary>
    /// The Format header is 24 bytes long
    /// </summary>
     public class Fmt
    {
        public Fmt()
        {
            m_FmtID = new byte[4];
        }

        public void ReadFmt(FileStream inFS)
        {
            inFS.Read(m_FmtID, 0, 4);

            Debug.Assert(m_FmtID[0] == 102, "Format ID Not Valid");

            BinaryReader binRead = new BinaryReader(inFS);

            m_FmtSize = binRead.ReadUInt32();
            m_FmtTag = binRead.ReadUInt16();
            m_Channels = binRead.ReadUInt16();
            m_SamplesPerSec = binRead.ReadUInt32();
            m_AverageBytesPerSec = binRead.ReadUInt32();
            m_BlockAlign = binRead.ReadUInt16();
            m_BitsPerSample = binRead.ReadUInt16();

            // This accounts for the variable format header size 
            // 12 bytes of Riff Header, 4 bytes for FormatId, 4 bytes for FormatSize & the Actual size of the Format Header 
            inFS.Seek(m_FmtSize + 20, System.IO.SeekOrigin.Begin);
        }

        public byte[] FmtID
        {
            get { return m_FmtID; }
        }

        public uint FmtSize
        {
            get { return m_FmtSize; }
        }

        public ushort FmtTag
        {
            get { return m_FmtTag; }
        }

        public ushort Channels
        {
            get { return m_Channels; }
        }

        public uint SamplesPerSec
        {
            get { return m_SamplesPerSec; }
        }

        public uint AverageBytesPerSec
        {
            get { return m_AverageBytesPerSec; }
        }

        public ushort BlockAlign
        {
            get { return m_BlockAlign; }
        }

        public ushort BitsPerSample
        {
            get { return m_BitsPerSample; }
        }

        private byte[] m_FmtID;
        private uint m_FmtSize;
        private ushort m_FmtTag;
        private ushort m_Channels;
         private uint m_SamplesPerSec;
        private uint m_AverageBytesPerSec;
        private ushort m_BlockAlign;
         private ushort m_BitsPerSample;
    }
    /// <summary>
    /// The Data block is 8 bytes + ???? long
    /// </summary>
    public class Data
    {
        public Data()
        {
            m_DataID = new byte[4];
        }

        public void ReadData(FileStream inFS)
        {
            //inFS.Seek( 36, System.IO.SeekOrigin.Begin );

            inFS.Read(m_DataID, 0, 4);

            Debug.Assert(m_DataID[0] == 100, "Data ID Not Valid");  //100=d, data

            BinaryReader binRead = new BinaryReader(inFS);

            m_DataSize = binRead.ReadUInt32();

            m_Data = new double[m_DataSize];

            inFS.Seek(40, System.IO.SeekOrigin.Begin);

            m_NumSamples = (int)(m_DataSize / 2);
            int i;
            for ( i = 0; i < m_NumSamples; i++)
            {
                m_Data[i] =Convert.ToDouble(binRead.ReadInt16());
            }
            // Chuan hoa
            double maxx = m_Data[2];
            for (i = 3; i < m_NumSamples; i++)
                if (maxx < m_Data[i]) maxx = m_Data[i];
            for (i = 0; i < m_NumSamples; i++)
            {
                m_Data[i] /=maxx ;
            }
           // endcut(64, 1.2); 
        }

        public byte[] DataID
        {
            get { return m_DataID; }
        }

        public uint DataSize
        {
            get { return m_DataSize; }
        }

        public double this[int pos]
        {
            get { return m_Data[pos]; }
        }

        public int NumSamples
        {
            get { return m_NumSamples; }
        }

        private byte[] m_DataID;
        private uint m_DataSize;
        private double[] m_Data;
        private int m_NumSamples;
        
       
    }
    ////////////////
    public class WaveFile
    {
        private string m_Filepath;
        private FileInfo m_FileInfo;
        private FileStream m_FileStream;

        private Riff m_Riff;
        public Fmt m_Fmt;
        public Data m_Data;
        public double[] DataCut;
        public int somauEndCut;
        double[] X;           //tinh DFT 
        double[] x; double[] Xr; double[] Xi; double[] w; 

        public WaveFile(String inFilepath)
        {
            m_Filepath = inFilepath;
            m_FileInfo = new FileInfo(inFilepath);
            m_FileStream = m_FileInfo.OpenRead();

            m_Riff = new Riff();
            m_Fmt = new Fmt();
            m_Data = new Data();
            //==Danh cho bien doi DFT
            x = new double[512];//windonlength
            Xr = new double[512];
            Xi = new double[512];
            w = new double[512];
        }

        public void Read()
        {
            m_Riff.ReadRiff(m_FileStream);
            m_Fmt.ReadFmt(m_FileStream);
            m_Data.ReadData(m_FileStream);
            //cắt bỏ khoảng lặng
            double []DataCut1 = new double[m_Data.NumSamples];   
            somauEndCut= endcut(64, 0.015f, DataCut1);
            DataCut = new double[somauEndCut];
            for (int i = 0; i < somauEndCut; i++) DataCut[i] = DataCut1[i];
        }


        public void VeTinHieu(PictureBox p, Pen but)
        {
            Graphics grfx = p.CreateGraphics();

            float   xscale = 1.0f * p.Width / m_Data.NumSamples;
            float   yscale = 0.4f * p.Height;// / 32768;
            int dongngang = p.Height / 2;
            grfx.DrawLine(Pens.Blue, 0, dongngang, p.Width, dongngang);
            for (int i = 0; i < m_Data.NumSamples - 1; i++)
            {
                grfx.DrawLine(but, i * xscale, (float)m_Data[i] * yscale + dongngang, (i + 1) * xscale, (float)m_Data[i + 1] * yscale + dongngang);
            }
            

        }

        public void DFT(int startpos, float time, int windonlength, double[] X)  //N
        {
      
            //Biến đổi fourier rời rạc
            // bắt đầu từ vị trí startpos,
            // số lượng mẫu mỗi khung phân tích phổ là Fs*time mẫu
            // của sổ phân tích Fourier là windonlength
            // X là biên độ phổ phân tích được trên khung

            int numsample = Convert.ToInt16(time * m_Fmt.SamplesPerSec);
           
            int i, k;
            

            // Lấy tín hiệu từ [i+startpos..i+startpos+windonlengh]
            for (i = 0; i < numsample; i++) x[i] = DataCut[i + startpos];
            // cửa sổ hóa đoạn dữ liệu này
            for (i = 0; i < numsample; i++) w[i] = 1.0f * ((float)x[i] ) * (0.54 - 0.46 * Math.Cos(2 * Math.PI * i / windonlength));
            // Biến đổi Fourier
            for (k = 0; k < windonlength; k++)
            {
                Xr[k] = 0; Xi[k] = 0;
                for (i = 0; i < windonlength; i++)
                {
                    Xr[k] += w[i] * Math.Cos(2 * Math.PI * k * i / windonlength);
                    Xi[k] += w[i] * Math.Sin(2 * Math.PI * k * i / windonlength);
                }
            }
            // Tính năng lượng phổ 
            for (k = 0; k < windonlength; k++) X[k] = Math.Sqrt(Xr[k] * Xr[k] + Xi[k] * Xi[k]);
            //k = 0;
        }
        public void MFCC(double[] X, int FS, int windowlength, int numFilter, double[] c)
        {
            float fmin = 0.0f;              // tan so Hz
            float fmax = (float)FS / 2;     // tan so Hz
            float phi_min = 0.0f;                  // thang do Mel
            float phi_max = 2595.0f * (float)Math.Log10(1 + fmax / 700);  // thang do Mel
            float deltaphi = (phi_max - phi_min) / (numFilter + 1); // khoang cach cac bo loc tren thang mel
            
            float[] melCenterFreq = new float[numFilter + 2]; // cac tan so trung tam tren thang Mel
            float[] HzCenterFreq = new float[numFilter + 2];  // cac tan so trung tam tren thang Hz
            
            int i, j, m;
            // tinh cac tan so trung tam cua cac bo loc Mel, cung nhu tren thang Hz
            for (i = 1; i <= numFilter; i++)
            {
                melCenterFreq[i] = deltaphi * i;
                HzCenterFreq[i] = 700.0f * (float)(Math.Pow(10, melCenterFreq[i] / 2595) - 1);
            }
            //----------------------- Doi tu chi so J trong mang X sang don vi sang gia tri Hz tuong ung
            //Theo Matlab
            //f = Fs/2*linspace(0,1,NFFT/2);
            // --b1: chuyen chi so tu 0..windowlength/2 thanh dang 0..1
            //--- duoc bao nhieu dem nhan voi FS/2 se suy ra duoc f
            // cong thuc:    j/(windowlength/2)    *   FS/2 ============ f = j*Fs/N
            //Loc mel--------------------------
            double[] F = new double[numFilter + 2];
            float fj;
            for (m = 1; m <= numFilter; m++)  // Tinh nang luong cua tung bo loc melody
            {
                for (j = 0; j < windowlength; j++)
                {
                    fj = (float)j * m_Fmt.SamplesPerSec / windowlength;
                    if (fj < HzCenterFreq[m - 1])
                    {
                        F[m] += 0;
                    }
                    else if (fj < HzCenterFreq[m])
                    {
                        F[m] += X[j] * (fj - HzCenterFreq[m - 1]) / (HzCenterFreq[m] - HzCenterFreq[m - 1]);
                    }
                    else if (fj < HzCenterFreq[m + 1])
                    {
                        F[m] += X[j] * (fj - HzCenterFreq[m + 1]) / (HzCenterFreq[m] - HzCenterFreq[m + 1]);
                    }
                    else
                    {
                        F[m] += 0;
                    }
                }
                //lay Log
                F[m] = Math.Log(F[m]);
            }
            // Bien doi Cosin roi rac nguoc
            // double[] c = new double[numFilter];
            for (j = 1; j <= numFilter; j++)
            {
                for (m = 1; m <= numFilter; m++)
                { c[j] += F[m] * Math.Cos(Math.PI * j * ((m-1) + 0.5f) / numFilter); }
            }
        }
        public void toMFCC(double[] traindata)//5 phan * 12 heso = 60
        {
            int i, N = 512;
            double[] X = new double[N];
            int startpos = 0;
            double[] C = new double[13];
            int k = 0;
            double[] tam = new double[5000];
            while (startpos + N < somauEndCut) //m_Data.NumSamples
            {
                DFT(startpos, 0.02f, N, X);
                MFCC(X, (int)m_Fmt.SamplesPerSec, 512, 12, C);

                for (i = 1; i <= 12; i++)
                {
                    k++;
                    tam[k] = Math.Round(C[i], 4);
                }

                startpos = startpos + (int)(0.01f * m_Fmt.SamplesPerSec);
            }
            //-----Ley them khung cuoi cung ----------------
            startpos = somauEndCut  - (int)(0.02f * m_Fmt.SamplesPerSec);
            DFT(startpos, 0.02f, N, X);
            MFCC(X, 8000, 512, 12, C);
            for (i = 1; i <= 12; i++)
            {
                k++;
                tam[k] = Math.Round(C[i], 4);
            }

            int m = k / (12 * 5);  //so frame
            // tinh phan trung binh cua phan thu 1; t1+t13+t25
            double temp;
            for (i = 1; i <= 12; i++)
            {
                temp = 0.0;
                for (int j = 0; j < m; j++) temp += tam[12 * j + i];
                traindata[i] = temp / m;
            }
            // tinh phan trung binh cua phan thu 2
            int ii = 0;
            for (i = 13; i <= 24; i++)
            {
                temp = 0; ii++;
                for (int j = 0; j < m; j++) temp += tam[12 * j + ii + m * 12];
                traindata[i] = temp / m;
            }
            // tinh phan trung binh cua phan thu 3
            ii = 0;
            for (i = 25; i <= 36; i++)
            {
                ii++;
                temp = 0;
                for (int j = 0; j < m; j++) temp += tam[12 * j + ii + 2 * m * 12];
                traindata[i] = temp / m;
            }

            // tinh phan trung binh cua phan thu 4
            ii = 0;
            for (i = 37; i <= 48; i++)
            {
                ii++;
                temp = 0;
                for (int j = 0; j < m; j++) temp += tam[12 * j + ii + 3 * m * 12];
                traindata[i] = temp / m;
            }

            // tinh phan trung binh cua phan thu 5
            ii = 0;
            for (i = 49; i <= 60; i++)
            {
                ii++;
                temp = 0;
                for (int j = 0; j < m; j++) temp += tam[12 * j + ii + 4 * m * 12];
                traindata[i] = temp / m;
            }
            // dịch lại chỉ số từ 0
            for (i = 0; i < 60; i++) traindata[i] = Math.Round(traindata[i + 1],4);  
        }
        // hàm cắt bỏ khoảng lặng
        public int endcut(int N, double thresholdpower, double[] res)  //trả về số mẫu
        {
           // double[] res = new double[m_NumSamples];
            double e;
            int i = 2;
            int t;
            int k = 0;
            int m = 0;
            while (i < m_Data.NumSamples - N)
            {
                //tính năng lượng từng cửa khung độ rộng N
                e = 0;
                for (t = i; t < i + N; t++)
                    e += m_Data[t] * m_Data[t];
                if (e > thresholdpower)  // nếu lớn hơn ngưỡng dữ lại chép vào mảng res
                    for (t = i; t < i + N; t++)
                    {
                        res[m] = m_Data[t]; m++;
                    }
                i += N;
            }
            // Chep lai
           // for (i = 0; i < m; i++) m_Data[i] = res[i];
            return m;
           
        }
    }
}