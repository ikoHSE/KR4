using System;
using System.Linq;

namespace Reader {
    public class Data {

        int[] V;

        public double M;
        public double D;
        public double Z;

        public Data(string values) {
            char[] separators = {' '};
            V = values.Split(separators).Select((n) => int.Parse(n)).ToArray();
            if (V.Count() < 1) {
                throw new ArgumentException();
            }
            foreach (var n in V) {
                if (n <= 0) {
                    throw new ArgumentOutOfRangeException();
                }
            }
            M = V.Average();
            D = V.Select((n) => (n-M)*(n-M)).Sum() / V.Count();
            Z = V.Select((n) => Math.Abs(n-M)).Sum() / V.Count();
        }

        public override string ToString() {
            return $"nums = {String.Join(" ", V.Select((n) => n.ToString()))}\nM = {M}\nD = {D}\nZ = {Z}";
        }
    }
}
