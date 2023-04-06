using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAC_DLL;
using Functions = MAC_DLL.MAC_Functions;

namespace MAC_LabWork_1_2
{
    public class Main_LW_1_2
    {
        static double A, B, C, eps;

        static void Main(string[] args)
        {
            //Console.WriteLine(SinhCoshTest());
            //Console.WriteLine(SinCosTest());

            //A = 15.0;
            //B = 17.0;
            //C = -11.0;
            //e = 1.0E-19;

            //Console.WriteLine(TestDLL());
            //Console.WriteLine(TestMath());

            MyVariant("LW_1_2_v15");
        }

        static void MyVariant(string name)
        {
            using (var sw = Utilities.ResultWriter(name, "Main_LW_1_2.cs"))
            {
                sw.WriteLine($"\r\n{name}\r\n");
                A = 12.3;
                B = 22.4;
                eps = 1.0E-19;
                sw.WriteLine($"Test 1 {TestDLL()}\r\nTest 1 {TestMath()}");
                A = 3.57;
                B = 1.98;
                sw.WriteLine($"Test 2 {TestDLL()}\r\nTest 2 {TestMath()}");
            }
        }

        static string TestDLL()
        {
            //var d0 = Functions.Sin(A + B + C, eps);
            //var d1 = Functions.Sin(A, eps) * Functions.Cos(B, eps) * Functions.Cos(C, eps);
            //var d2 = Functions.Cos(A, eps) * Functions.Sin(B, eps) * Functions.Cos(C, eps);
            //var d3 = Functions.Cos(A, eps) * Functions.Cos(B, eps) * Functions.Sin(C, eps);
            //var d4 = Functions.Sin(A, eps) * Functions.Sin(B, eps) * Functions.Sin(C, eps);
            //var error = Math.Abs(d0 - (d1 + d2 + d3 - d4));

            var d0 = Functions.Cos(A, eps) + Functions.Cos(B, eps);
            var d1 = 2 * Functions.Cos(0.5 * (A + B), eps) * Functions.Cos(0.5 * (A - B), eps);

            var error = Math.Abs(d0 - d1);

            return $"  MAC = {d0,19:F16}   error = {error,10:E2}";
        }

        static string TestMath()
        {
            //var d0 = Math.Sin(A + B + C);
            //var d1 = Math.Sin(A) * Math.Cos(B) * Math.Cos(C);
            //var d2 = Math.Cos(A) * Math.Sin(B) * Math.Cos(C);
            //var d3 = Math.Cos(A) * Math.Cos(B) * Math.Sin(C);
            //var d4 = Math.Sin(A) * Math.Sin(B) * Math.Sin(C);
            //var error = Math.Abs(d0 - (d1 + d2 + d3 - d4));

            var d0 = Math.Cos(A) + Math.Cos(B);
            var d1 = 2 * Math.Cos(0.5 * (A + B)) * Math.Cos(0.5 * (A - B));

            var error = Math.Abs(d0 - d1);

            return $" Math = {d0,19:F16}   error = {error,10:E2}";
        }

        static string SinhCoshTest()
        {
            var result = "\tTest of Sinh() Cosh()\r\n";
            var eps = 1.0E-20;
            double unit, error;
            for (double x = 0.0; x <= 20.0; x += 1.0)
            {
                double cosh = Functions.Cosh(x, eps), sinh = Functions.Sinh(x, eps);
                unit = (cosh - sinh) * (cosh + sinh);
                error = Math.Abs(1.0 - unit);
                result += $"{x,7:F1}{unit,22:F16}{error,22:F16}\r\n";
            }
            return result;
        }

        static string SinCosTest()
        {
            var result = "\tTest of Sin() Cos()\r\n";
            var eps = 1.0E-20;
            double unit, error;
            for (double x = 1.0; x <= 40.0; x += 1.0)
            {
                double cos = Functions.Cos(x, eps), sin = Functions.Sin(x, eps);
                unit = cos * cos + sin * sin;
                error = Math.Abs(1.0 - unit);
                result += $"{x,7:F1}{unit,20:F16}{error,20:F16}\r\n";
            }
            return result;
        }
    }
}
