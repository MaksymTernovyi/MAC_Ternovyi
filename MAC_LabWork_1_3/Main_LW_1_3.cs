using System;
using System.Text;
using UTL = MAC_DLL.Utilities;
using FwG = MAC_DLL.FormWithGraphic;
using MyTD = MAC_DLL.MyTableOfData;

namespace MAC_LabWork_1_3
{
    class Main_LW_1_3
    {
        public static void Main(string[] args)
        {
            // LW_1_3("MAC_LW_1_3_v00.bin", "MAC_LW_1_3_v00.txt", "LW_1_3_v00");
            LW_1_3("MAC_LW_1_3_v15.bin", "MAC_LW_1_3_v15.txt", "LW_1_3_v15");
        }

        private static void LW_1_3(string f_bin, string f_txt, string f_res)
        {
            Console.OutputEncoding = Encoding.Unicode;

            using (var sw = UTL.ResultWriter(f_res))
            {
                var T1 = new MyTD(f_bin, "binary file");
                var txt = $"\r\n Прочитано рядків: {T1.Length,0}";
                txt += T1.ToPrint("   Обробка файлу *.bin");
                sw.WriteLine(txt);
            
                var T2 = new MyTD(f_txt, "text   file");
                txt = $"\r\n\r\n\r\n  Прочитано рядків: {T2.Length,0}";
                txt += T2.ToPrint("   Обробка файлу *.txt");
                sw.WriteLine(txt);

                FwG.SingleGraphic(T2, 300, 500);
            }
        }
    }
}