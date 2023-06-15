using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {

        public static List<string> rocerds = new List<string>();

        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("1 - додати елементи; 2 - Вивети данни на екран; 3 - зберегти елементи; 4 - Завантажити елементи;");
                string menuNam = Console.ReadLine();

                switch (menuNam)
                {
                    case "1":
                        {
                            for (int i = 1; i <= 10; i++)
                            {
                                rocerds.Add($"Hello Elemmen {i}");
                            }

                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            if (rocerds.Count == 0)
                            {
                                Console.WriteLine("Елементив немае тут пусто!");
                            }

                            foreach (var item in rocerds)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case "3":
                        {
                            Save();
                            break;
                        }

                    case "4":
                        {
                            Dowload();
                            break;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }



        }


        public static void Save()
        {

            using (StreamWriter sw = new StreamWriter("seves.txt"))
            {
                foreach (var item in rocerds)
                {
                    sw.WriteLine(item);
                }
            }


        }

        public static void Dowload()
        {
            using (StreamReader rd = new StreamReader("seves.txt"))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    rocerds.Add(line);
                }
            }
        }
    }
}
