using System;
using System.IO;
using System.Windows.Forms;
using FTN = MAC_DLL.MAC_Function_Table_Node;

namespace MAC_DLL
{
    public abstract class MyTable
    {
        public FTN[] Nodes { get; internal set; }
        public int Length => Nodes?.Length ?? 0;
        public FTN Maximum { get; protected set; }
        public FTN Minimum { get; protected set; }
        public double Region_x => Nodes?[Length - 1].X - Nodes?[0].X ?? double.NaN;
        public double Region_f => Maximum?.F - Minimum?.F ?? double.NaN;
        public double Epsilon { get; set; }
        public string Title { get; protected set; }

        // Модифицируем наш индексатор для возможности обращения к последнему элементу this[-1]
        public FTN this[int index] => Math.Abs(index) < Length ? Nodes[index < 0 ? Length + index : index] : null;
        public double X(int index) => Math.Abs(index) < Length ? this[index < 0 ? Length + index : index].X : double.NaN;
        public double F(int index) => Math.Abs(index) < Length ? this[index < 0 ? Length + index : index].F : double.NaN;

        public void ToArrays(out double[] x, out double[] f)
        {
            x = new double[Length];
            f = new double[Length];
            for (var i = 0; i < Length; i++)
            {
                // Убираем обращение через this,
                // дабы не выполнять проверки, на то что индекс находится в промежутке, каждое обращение
                x[i] = Nodes[i].X;
                f[i] = Nodes[i].F;
            }
        }

        public virtual string Table_of_Function()
        {
            var txt = "\r\n Таблиця функції " + Title + " : \r\n";
            for (var i = 0; i < Length; i++) 
                txt += $"{i,4}" + Nodes[i].ToPrint() + "\r\n";
            txt += $"\r\n x = [{X(0),17:F12} :{X(Length - 1),17:F12} ]";
            txt += $"  x_Reg = {Region_x,16:F12}\r\n";
            txt += $"\r\n Min  ({Minimum.X,18:F12},{Minimum.F,18:F12} )";
            txt += $"\r\n Max  ({Maximum.X,18:F12},{Maximum.F,18:F12} )";
            txt += $"  f_Reg = {Region_f,16:F12}\r\n";
            return txt;
        }

        public virtual void To_txt_File(string path, string comment)
        {
            if (string.IsNullOrEmpty(path)) path = "My_Table.txt";
            var file = new FileInfo(path);
            if (file.Exists) file.Delete();
            using (var writer = new StreamWriter(file.OpenWrite()))
                writer.WriteLine(comment + "\r\n" + Table_of_Function());
        }

        public virtual string ToPrint(string comment) => comment;
    }
}