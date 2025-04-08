using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class FileOut
    {
        public static bool sorted = false;
        public static string fileString;
        public static void Fill()
        {
            foreach (var i in Context.array)
                fileString += i + " ";
            fileString += "\n";   
        }
        public static void SaveFile(string path)
        {
            if (fileString != null && sorted)
            {
                using (var writer = new StreamWriter(path))
                    writer.Write(fileString);
            }
            else
                MessageBox.Show("Ошибка");
        }

    }
}
