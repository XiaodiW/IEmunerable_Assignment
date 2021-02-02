using System;
using System.Linq;

namespace CExercise {

    public class Program {
        public static bool isPrimemy(int x) {
            var n = (int) Math.Ceiling(Math.Sqrt(x));
            return x > 1 ? Enumerable.Range(1, n).Where(a => x % a == 0).SequenceEqual(new[] {1}) : false;
        }

        public static bool isPrime(int x) {
            int i = 2;
            while(i++ <= x && x % i != 0) ;
            return i == x;
        }

        public static int SortDescending(int num) =>
            int.Parse(String.Concat(num.ToString().Select(s => int.Parse(s.ToString())).OrderBy(a => a).Reverse()
                .ToArray()));

        void change() {
            string str = "123int";
            
        }

        static void Main() {
            
        }
    }

}