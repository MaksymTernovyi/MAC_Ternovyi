using MAC_DLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTL = MAC_DLL.Utilities;
using CLS = MAC_DLL.MAC_Series;

namespace MAC_CT_1_1
{
    internal class Main_CT_1_1
    {
        //static int n = 10000;
        //static double a = 1.2, b = -2.10, c = -0.5, d = 1.4, eps = 1.0E-9, delta = 1.0E-8;

        static int n = 11350;
        static double a = 2.34, b = -1.57, c = 2.03, d = 0.91, eps = 1.0E-9, delta = 1.0E-8;

        static void Main(string[] args)
        {
            using (StreamWriter SW = UTL.ResultWriter("CT_1_1_v10", "Main_CT_1_1.cs"))
            {
                double SN = CLS.SumOfNumberSeries(0, n + 1, sk);
                SW.WriteLine($"   N ={n,10}   SN ={SN,15:F10}");

                int i_max = 0;
                double S1 = CLS.SumOfNumberSeriesA(-1, eps, si, ref i_max);
                SW.WriteLine($"i_max ={i_max,10}   S1 ={S1,15:F10}");

                int j_max = 0;
                double S2 = CLS.SumOfNumberSeriesD(1, delta, sj, ref j_max);
                SW.WriteLine($"j_max ={j_max,10}   S2 ={S2,15:F10}");
            }
        }

        public static double sk(int k)
        {
            return Math.Pow(k + 1.0, 1.0 / 4.0) / (3.0 * k * k - 1.0) / (Math.Sqrt(k) + 3.0);
        }

        public static double si(int i)
        {
            double x1 = 5.0 * i + 2.0 * a;
            return (Math.Sqrt(a + i) + Math.Sqrt(i - b)) / x1 / x1 / (b * i + 1.0);
        }

        public static double sj(int j)
        {
            return (j % 2 == 0 ? 1.0 : -1.0) / (Math.Pow(j, 1.5) + c) / (2.0 * j - d + 1.0);
        }
    }
}
