using System;
using System.Collections.Generic;
using System.Text;
using System.IO; 

namespace ThuVien_THO
{
    public class MLP// Lớp mạng Neron 3 layer
    {
        int numInput; //Số neron lớp vào
        int numOutput; // Số neron lớp ra
        int numHiden;//Số neron lớp ẩn
        double alpha; // Hệ số học
        double[,] V; // Trọng số lớp vào - > lớp ẩn
        double[,] W; // Trọng số lớp ẩn - lớp ra
        double[] b1; //Bias lớp ẩn
        double[] b2; //Bias lớp ra
        double[] netIH;
        double[] netHO;
        double[] deltaH;
        double[] deltaOut;
        double ActiveFunc(double x)
        {//dùng hàm Sigmoid
            return 1.0f / (1.0 + Math.Exp(-x));
        }
        public MLP(int soNoronVao, int soNoronRa, int soNoronAn, double hesohoc)
        { // Hàm khởi tạo mạng
            numInput = soNoronVao;
            numOutput = soNoronRa;
            numHiden = soNoronAn;
            alpha = hesohoc;
            V = new double[numHiden, numInput];
            b1 = new double[numHiden];
            W = new double[numOutput, numHiden];
            b2 = new double[numOutput];
            netIH = new double[numHiden];  // đầu ra tại các noron ẩn
            netHO = new double[numOutput];// đầu ra tại các noron lớp ra
            deltaH = new double[numHiden]; //sai số tại các noron ẩn
            deltaOut = new double[numOutput];  // sai số tại các noron ra
            // Khởi tạo ngẫu nhiên các trọng số [0..1]
            Random r = new Random();
            int i, j;
            for (i = 0; i < numHiden; i++)
            {
                for (j = 0; j < numInput; j++) V[i, j] = r.NextDouble();
                b1[i] = r.NextDouble();
            }
            for (i = 0; i < numOutput; i++)
            {
                for (j = 0; j < numHiden; j++) W[i, j] = r.NextDouble();
                b2[i] = r.NextDouble();
            }
        }
        public void netTrain(double[] X, double[] Y)
        {   // Luyện mạng, với vector dữ liệu luyện X, 
            // kết quả mong muốn là Vector Y
            int i, j;
            // Lan truyền qua lớp ẩn
           
            for (i = 0; i < numHiden; i++)
            {
                netIH[i] = 0;
                for (j = 0; j < numInput; j++) netIH[i] += V[i, j] * X[j];
                netIH[i] += b1[i];
                netIH[i] = ActiveFunc(netIH[i]);
            }
            //lan truyền đến lớp ra
            
            for (i = 0; i < numOutput; i++)
            {
                netHO[i] = 0;
                for (j = 0; j < numHiden; j++) netHO[i] += W[i, j] * netIH[j];
                netHO[i] += b2[i];
                netHO[i] = ActiveFunc(netHO[i]);
            }
            // Tính sai số tại các noron lớp ra
          
            for (i = 0; i < numOutput; i++)
                deltaOut[i] = netHO[i] * (1 - netHO[i]) * (Y[i] - netHO[i]);
            // Cập nhật các trọng số lớp ẩn ->lớp ra
            for (i = 0; i < numOutput; i++)
            {
                for (j = 0; j < numHiden; j++) W[i, j] += alpha * deltaOut[i] * netIH[j];
                b2[i] += alpha * deltaOut[i];
            }
            //Tính sai số tại các noron lớp ẩn
          
            double tam = 0;
            for (i = 0; i < numHiden; i++)
            {
                tam = 0;
                for (j = 0; j < numOutput; j++) tam += W[j, i] * deltaOut[j];
                deltaH[i] = tam * netIH[i] * (1 - netIH[i]);
            }
            // Cập nhật các trọng số lớp vào ->lớp ẩn
            for (i = 0; i < numHiden; i++)
            {
                for (j = 0; j < numInput; j++) V[i, j] += alpha * deltaH[i] * X[j];
                b1[i] += alpha * deltaH[i];
            }

        }
        public void netRun(double[] X, double[] Y)
        {
            //X: dữ liệu chạy mạng
            //Y: dữ liệu kết quả
            int i, j;
            // Lan truyền qua lớp ẩn
            double[] netIH = new double[numHiden];  // đầu ra tại các noron ẩn
            for (i = 0; i < numHiden; i++)
            {
                netIH[i] = 0;
                for (j = 0; j < numInput; j++) netIH[i] += V[i, j] * X[j];
                netIH[i] += b1[i];
                netIH[i] = ActiveFunc(netIH[i]);
            }
            //lan truyền đến lớp ra
            //  double[] netHO = new double[numOutput];// đầu ra tại các noron lớp ra
            for (i = 0; i < numOutput; i++)
            {
                Y[i] = 0;
                for (j = 0; j < numHiden; j++) Y[i] += W[i, j] * netIH[j];
                Y[i] += b2[i];
                Y[i] = ActiveFunc(Y[i]);
            }
        }
        public void netSave(string tenmang)
        {
            FileStream f = new FileStream(tenmang, FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine(numInput.ToString());
            w.WriteLine(numHiden.ToString());
            w.WriteLine(numOutput.ToString());
            w.WriteLine(alpha.ToString());
            w.WriteLine("--- Cac trong so lop an-------------------------------");
            for (int i = 0; i < numHiden; i++)
                for (int j = 0; j < numInput; j++) w.WriteLine(V[i, j].ToString() + " ");

            w.WriteLine("--- Cac bias so lop an-------------------------------");
            for (int j = 0; j < numHiden; j++) w.WriteLine(b1[j].ToString() + " ");

            w.WriteLine("--- Cac trong so lop ra-------------------------------");
            for (int i = 0; i < numOutput; i++)
                for (int j = 0; j < numHiden; j++) w.WriteLine(W[i, j].ToString() + " ");

            w.WriteLine("--- Cac bias so lop ra-------------------------------");
            for (int j = 0; j < numOutput; j++) w.WriteLine(b2[j].ToString() + " ");
            w.Close();
            f.Close(); 
        }
        public void netLoad(string tenmang)
        {
           /* FileStream f = new FileStream(tenmang, FileMode.Open);
            StreamReader r = new StreamReader(f);
            numInput = Convert.ToInt16(r.ReadLine()); //bo qua doc so nut vao 
            numHiden = Convert.ToInt16(r.ReadLine()); //bo qua doc so nut an  
            numOutput = Convert.ToInt16(r.ReadLine()); //bo qua doc so nut ra
            alpha = Convert.ToDouble(r.ReadLine());
            r.ReadLine();
            //* doc cac trong so lop an-------------------------------");
            for (int i = 0; i < numHiden; i++)
                for (int j = 0; j < numInput; j++) V[i, j] = Convert.ToDouble(r.ReadLine());    //w.Write(w1[i, j].ToString() + " ");
            r.ReadLine();
            // Doc cac bias so lop an-------------------------------");

            for (int j = 0; j < numHiden; j++) b1[j] = Convert.ToDouble(r.ReadLine()); // w.Writeln(b1[j].ToString() + " ");
            r.ReadLine();
            // - Cac trong so lop ra-------------------------------");
            for (int i = 0; i < numOutput; i++)
                for (int j = 0; j < numHiden; j++) W[i, j] = Convert.ToDouble(r.ReadLine()); //  .ToString() + " ");
            r.ReadLine();
            //  Cac bias so lop ra-------------------------------");
            for (int j = 0; j < numOutput; j++) b2[j] = Convert.ToDouble(r.ReadLine());//   .ToString() + " ");
            r.Close();
            f.Close(); */
        }

    }
}
