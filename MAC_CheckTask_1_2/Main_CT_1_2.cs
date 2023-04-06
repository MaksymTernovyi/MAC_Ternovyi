using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTL = MAC_DLL.Utilities;
using MyF = MAC_DLL.MAC_Functions;
using System.Threading;
using System.Diagnostics;

namespace MAC_CheckTask_1_2
{
    public class Main_CT_1_2
    {
        static void Main(string[] args)
        {
            MyVariant("CT_1_2_v15");
        }

        static void MyVariant(string file)
        {
            using (StreamWriter SW = UTL.ResultWriter(file, "Main_CT_1_2.cs"))
            {
                //double x1 = 2.5, x2 = 3.2, a = 0.5, b = 1.5, e = 1.0E-9;
                double x1 = 2.36, x2 = 3.71, a = 0.87, b = 1.33, e = 1.0E-9;
                SW.WriteLine($"\r\n\r\n{file}\r\n");
                SW.WriteLine($" a = {a,5:F2}  b = {b,5:F2}");
                SW.WriteLine($" my_F({x1,4:F2}) = {MyF.my_F(x1, a, b, e),13:F10}");
                SW.WriteLine($" my_F({x2,4:F2}) = {MyF.my_F(x2, a, b, e),13:F10}");
            }
        }
    }
}
