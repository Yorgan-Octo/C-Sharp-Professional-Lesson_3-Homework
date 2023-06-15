using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Task_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo("Test");


            if (!directory.Exists)
            {
                directory.Create();
            }

            for (int i = 0; i < 100; i++)
            {
                string name = $"Folder_{i}.txt";

                FileStream newFile = File.Create(directory +"\\"+ name);

                newFile.Close();
            }

            Console.WriteLine("Натисніть на кнопку щоб все відалити!");
            Console.ReadKey();

            FileInfo[] files = directory.GetFiles("*.txt");
            foreach (var item in files)
            {
                item.Delete();
            }
            directory.Delete();

            Console.ReadKey();

        }
    }
}
