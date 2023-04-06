using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLS = MAC_DLL.MAC_Series;
using UTL = MAC_DLL.Utilities;

namespace MAC_LW_1_1
{
    public class Main_LW_1_1
    {
        static int kf = 0;
        static double eps = 1.0e-9;
        static double dlt = 1.0e-8;

        static void Main(string[] args)
        {
            //CommonTest("LW_1_1_Test", 10000);
            MyVariant("LW_1_1_v15", 17600);
        }

        static void CommonTest(string name, int n)
        {
            using (var writer = UTL.ResultWriter(name))
            {
                writer.WriteLine("\r\n Summa 1 :");
                var true_sum1 = Math.PI * Math.PI / 8.0 - 1.0;
                var s1_n = CLS.SumOfNumberSeries(1, n + 1, MyAk);
                writer.WriteLine($"{n,8}{s1_n,20:f15}\r\n{true_sum1,28:f15}");

                var s1_a = CLS.SumOfNumberSeriesA(1, eps, MyAk, ref kf);
                writer.WriteLine($"{kf,8}{s1_a,20:f15}");
                var s1_d = CLS.SumOfNumberSeriesD(1, dlt, MyAk, ref kf);
                writer.WriteLine($"{kf,8}{s1_d,20:f15}");

                writer.WriteLine("\r\n Summa 2 :");
                var true_sum2 = Math.Pow(Math.PI, 3.0) / 32.0;
                var s2_n = CLS.SumOfNumberSeries(0, n + 1, MyBk);
                writer.WriteLine($"{n,8}{s2_n,20:f15}\r\n{true_sum2,28:f15}");

                var s2_a = CLS.SumOfNumberSeriesA(0, eps, MyBk, ref kf);
                writer.WriteLine($"{kf,8}{s2_a,20:f15}");
                var s2_d = CLS.SumOfNumberSeriesD(0, dlt, MyBk, ref kf);
                writer.WriteLine($"{kf,8}{s2_d,20:f15}");
            }
        }

        static void MyVariant(string name, int n)
        {
            using (var writer = UTL.ResultWriter(name, "Main_LW_1_1.cs")) 
            {
                var sn = CLS.SumOfNumberSeries(0, n + 1, MySk);
                writer.WriteLine($"\r\n Summa SN : {n,8}{sn,20:f15}");

                var sqrt = Math.Sqrt(2);
                var true_sum1 = Math.PI / 4 * (1 - sqrt) - sqrt / 2 * Math.Log(sqrt - 1);
                var si = CLS.SumOfNumberSeriesA(0, eps, MySi, ref kf);
                writer.WriteLine($"\r\n Summa SI : {kf,8}{si,20:f15}\r\n{true_sum1,40:f15}");
            }
        }

        static double MySk(int k)
        {
            return 1.0 / (4 * k + 3) / (2 * k + 1);
        }

        static double MySi(int i)
        {
            return (i % 2 == 0 ? 1.0 : -1.0) / (2 * i + 1) / (4 * i + 3);
        }

        static double MyAk (int k)
        {
            var a = 2.0 * k + 1.0;
            return 1.0 / a / a;
        }

        static double MyBk (int k)
        {
            var b = 2.0 * k + 1.0;
            return (k % 2 == 0 ? 1.0 : -1.0) / b / b / b;
        }
    }
}
