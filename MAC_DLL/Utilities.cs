using System.IO;
using System;

namespace MAC_DLL
{
    public class Utilities
    {
        public static StreamWriter ResultWriter(string name, params string[] files)
        {
            var projectDir =
                   Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;

            var file_name = name + " Ternovyi_M_S.txt";

            var writer = new StreamWriter(file_name);
            foreach (var file in files)
            {
                writer.WriteLine(file + ":\r\n");
                writer.Flush();
                using (var reader = new StreamReader(projectDir + '\\' + file))
                    reader.BaseStream.CopyTo(writer.BaseStream);
                writer.WriteLine("\r\n// -------------------------------------- //\r\n");
            }
            writer.Write(file_name);
            writer.WriteLine($"  data : {DateTime.Now.ToShortDateString()}" +
                             $"  time : {DateTime.Now.ToShortTimeString()}\r\n");
            return writer;
        }
    }
}