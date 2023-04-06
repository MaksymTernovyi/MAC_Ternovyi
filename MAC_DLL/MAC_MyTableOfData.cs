using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FTN = MAC_DLL.MAC_Function_Table_Node;
using CI = System.Globalization.CultureInfo;

namespace MAC_DLL
{
    public class MyTableOfData : MyTable
    {
        public string Table_in_File { get; }

        public MyTableOfData(string path, string title)
        {
            var temp = new List<FTN>();
            var file = new FileInfo(path);
            Table_in_File = $"\r\n Таблиця {title} в файлі {file.Name} :\r\n";

            switch (file.Extension)
            {
                case ".bin":
                {
                    using (var bin_rdr = new BinaryReader(file.OpenRead()))
                    {
                        var i = 0;
                        try
                        {
                            while (true)
                            {
                                temp.Add(new FTN(bin_rdr.ReadDouble(), bin_rdr.ReadDouble()));
                                Table_in_File += $"{i,4}{temp[i++].ToPrint()}\r\n";
                            }
                        } catch (IOException) { }
                    }

                    break;
                }
                case ".txt":
                {
                    using (var txt_rdr = new StreamReader(file.OpenRead()))
                    {
                        var i = 0;
                        while (!txt_rdr.EndOfStream)
                        {
                            var line = txt_rdr.ReadLine();
                            line = CI.CurrentCulture.NumberFormat.NumberDecimalSeparator == "."
                                ? line.Replace(",", ".")
                                : line.Replace(".", ",");
                            var txt = line.Trim().Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                            temp.Add(new FTN(Convert.ToDouble(txt[0]), Convert.ToDouble(txt[1])));
                            Table_in_File += $"{i,4}{temp[i++].ToPrint()}\r\n";
                        }
                    }

                    break;
                }
            }

            temp.Sort((i, j) => i.X.CompareTo(j.X));
            Nodes = temp.ToArray();
            Maximum = Nodes[0];
            Minimum = Nodes[0];
            for (var i = 1; i < Length; i++)
            {
                if (Minimum.F > Nodes[i].F)
                    Minimum = Nodes[i];
                if (Maximum.F < Nodes[i].F)
                    Maximum = Nodes[i]; 
            }

            Title = title;
        }
        public MyTableOfData() { }

        public override string ToPrint(string comment)
        {
            return comment + "\r\n" + Table_in_File + Table_of_Function();
        }
    }
}