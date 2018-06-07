/*
ФИО: Костюченко Илья Игоревич
Группа: БПИ 171-1
Дата: 5.6.18
Вариант: 4
*/

using System;
using System.IO;
using System.Linq;

namespace Reader {
    class MainClass {
        private static string path = "../../../nums.txt";
        public static void Main(string[] args) {
            try {
                var text = File.ReadAllText(path);
                Console.WriteLine("\tThe contents of the file:");
                Console.WriteLine();
                Console.WriteLine(text);

                Console.WriteLine("\tElements as they are in file:");
                Console.WriteLine();

                var processing = new Processing(path);
                foreach (var d in processing) {
                    Console.WriteLine(d);
                    Console.WriteLine();
                }

                Console.WriteLine();

                var sorted = from d in processing
                             orderby d.D / d.M ascending
                             select d;
                Console.WriteLine("\tSorted elements:");
                Console.WriteLine();

                foreach (var d in sorted) {
                    Console.WriteLine(d);
                    Console.WriteLine();
                }
            } catch {
                Console.WriteLine("\tThere was an error reading the file.");
                return;
            }

        }
    }
}
