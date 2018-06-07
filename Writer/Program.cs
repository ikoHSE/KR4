/*
ФИО: Костюченко Илья Игоревич
Группа: БПИ 171-1
Дата: 5.6.18
Вариант: 4
*/

using System;
using static Iko.Iko;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Writer {
    class Writer {
        private static Random rand = new Random();

        public static void Main() {
            var k = GetInt("K = ", (n) => n > 0, "That is not a valid int bigger than 0.");
            var f = GetInt("F = ", (n) => n > 0, "That is not a valid int bigger than 0.");
            var s = GetInt("S = ", (n) => n > 0, "That is not a valid int bigger than 0.");
            var fs = new StreamWriter("../../../nums.txt", false);
            for (var i = 0; i < s; i++) {
                var l = rand.Next(k)+1;
                var ns = new List<int>();
                for (var j = 0; j < l; j++) {
                    ns.Add(rand.Next(f)+1);
                }
                var line = string.Join(" ", ns.Select((n) => $"{n}"));
                fs.WriteLine(line);
            }
            fs.Close();
        }
    }
}
