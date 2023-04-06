using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphic = MAC_DLL.FormWithGraphic;

namespace MAC_LabWork_0_1
{
    public class Main_LW_0_1
    {
        static void Main(string[] args)
        {
            TestSinus(100, -Math.PI, Math.PI, 800, 300);
        }

        static void TestSinus(int n, double x0, double xn, int offsetX, int offsetY)
        {
            var step = (xn - x0) / n;
            (double x, double y)[] sinus = new (double, double)[n];
            for (int i = 0; i < n; i++)
            {
                sinus[i].x = x0 + i * step;
                sinus[i].y = Math.Sin(sinus[i].x + 0.5);
            }

            Graphic.SingleGraphic(sinus, "My Graphic of Sin(x)", offsetX, offsetY);
        }
    }
}
