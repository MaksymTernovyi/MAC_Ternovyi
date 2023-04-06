using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MAC_DLL
{
    public class MAC_Functions
    {
        public static double f0(double x, double a, double b, double eps)
        {
            if (x == 0) return 0;
            double xz = 11.0 * x / 7.0, bx = b * x;
            double pk = 1.0, Ak = 1.0, summa = 0.0, Ao = (Math.Cos(bx) + Math.Sin(bx / a)) / a;

            for (int k = 1; Math.Abs(Ak) > eps; k++)
            {
                pk = -pk * xz / (k + 1.0);
                Ak = pk * (Math.Cos(bx / (k + 1.0)) + Math.Sin(bx / (k + a))) / (2.0 * k + a);
                summa += Ak;
            }
            return 0.25 * xz * (Ao + summa);
        }

        public static double my_F(double x, double a, double b, double eps)
        {
            double cosPart = Math.PI * a * x * x;

            double pk = x / b;
            double ak = pk * Math.Cos(cosPart / 2);

            double sum = ak;

            for (int k = 1; Math.Abs(ak) > eps; k++)
            {
                pk = -pk * (x * x * b) / (b + 2) / (2 * k + 1) / (2 * k);
                b += 2;
                ak = pk * Math.Cos(cosPart / (2 * (k * x + 1))); 
                sum += ak;
            }

            return sum;
        }

        public static double Sin(double x, double eps)
        {
            if (x == 0) return 0;

            double sin = x;
            double pk = x;
            x *= 0.5;

            for (int k = 2; Math.Abs(pk) > eps; k++)
                sin += pk = -pk * (x / (k - 1.0)) * (x / (k - 0.5));

            return sin;
        }

        public static double Cos(double x, double eps)
        {
            if (x == 0) return 0;

            double cos = 1.0;
            double pk = 1.0;
            x *= 0.5;

            for (int k = 1; Math.Abs(pk) > eps; k++)
                cos += pk = -pk * (x / (k - 0.5)) * (x / k);

            return cos;
        }

        public static double Exp(double x, double eps)
        {
            if (x == 0) return 1.0;

            double exp = 1.0;
            double pk = 1.0;

            for (int k = 1; Math.Abs(pk) > eps; k++)
            {
                exp += pk *= x / k;
                Console.WriteLine($"{k,6}{pk,30:F22}");
            }

            return exp;
        }

        public static double Sinh(double x, double eps)
        {
            if (x == 0) return 0;

            double sin = x;
            double pk = x;
            x *= 0.5;

            for (int k = 2; Math.Abs(pk) > eps; k++)
                sin += pk *= x / (k - 1.0) * (x / (k - 0.5));

            return sin;
        }

        public static double Cosh(double x, double eps)
        {
            if (x == 0) return 0;

            double cos = 1.0;
            double pk = 1.0;
            x *= 0.5;

            for (int k = 1; Math.Abs(pk) > eps; k++)
                cos += pk *= x / (k - 0.5) * (x / k);

            return cos;
        }
    }
}
