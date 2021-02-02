using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace CExercise {

    class Program {
        /// <summary>
        /// This is a exersice programm;
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            // Console.WriteLine("Hello World!");
            // Console.WriteLine($"{DuplicateCount("aabBcdeEfgHhI")}");
            // Console.WriteLine($"'{SongDecoder("WUBWEWUBAREWUBWUBWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB")}'");
            // Console.WriteLine($"{PrinterError("aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz")}");
            // Console.WriteLine($"{Longest("loopingisfunbutdangerous", "lessdangerousthancoding")}");
            // Console.WriteLine($"{MaxSequence(new int[]{-2, 1, -3, 4, -1, 2, 1, -5, 4})}");
            /*var arr = Tribonacci(new double[] {1, 1, 1}, 10);
            foreach(var d in arr) {
                Console.WriteLine(d);
            }*/
            Console.WriteLine($"{Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })}");
        }

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

        // return masked string
        public static string Maskify(string cc) {
            return cc.Length > 4 ? cc.Substring(cc.Length - 4).PadLeft(cc.Length, '#') : cc;
        }

        public static int DuplicateCount(string str) {
            /*var s = str.ToLower();
            return s.Distinct()
                .Select(c => s.Count(a => a == c))
                .Sum(b => b > 1?1:0);*/

            return str.ToLower().GroupBy(c=> c).Where(a=>a.Count()>1).Count();
        }
        
        public static string SongDecoder(string input) {
            return Regex.Replace(input,@"(WUB)+"," ").Trim();
        }

        public static string PrinterError(String s) => $"{s.Count(a => a > 'm')}/{s.Length}";
        public static string Longest(string s1, string s2) => String.Concat((s1+s2).Distinct().OrderBy(a => a));

        public static string Likes(string[] name) {
            switch(name.Length) {
                case 0: return "no one likes this";
                case 1: return name[0] + " likes this";
                case 2: return name[0] + " and " + name[1] + " likes this";
                case 3: return name[0] + ", " + name[1] + " and " + name[2] + " likes this";
                default:
                    return name[0] + ", " + name[1] + " and " + (name.Length-2) + " others likes this";
            }
        }

        public static string GetReadableTime(int seconds) {
            return $"{(seconds/3600):00}:{(seconds%3600/60):00}:{(seconds%3600%60):00}";
        }

        public static int MaxSequence(int[] arr) {
            var max = 0;
            for(var i = 1; i < arr.Length + 1; i++)
            for(var j = 0; j < arr.Length - i + 1; j++)
                if(arr.TakeLast(arr.Length - j).Take(i).Select(a => a).Sum() > max)
                    max = arr.TakeLast(arr.Length - j).Take(i).Select(a => a).Sum();
            return Math.Max(max, 0);
        }
        
        /*public static int MaxSequence(int[] arr)
        {
            int currentMax = 0, totalMax = 0;
            foreach (var a in arr)
            {
                currentMax = Math.Max(0, currentMax + a);
                totalMax = Math.Max(totalMax, currentMax);
            }
            return totalMax;
        }*/
         static double[] Tribonacci(double[] signature, int n) {
            var arr = new double[n];
            for(var i = 0; i < Math.Min(3,n); i++) arr[i] = signature[i];
            if(n < 4) return arr;
            for(var i = 3; i < n ; i++) arr[i] = arr[i - 3] + arr[i - 2] + arr[i - 1];
            return arr;
        }

         public static string Extract(int[] args) {
             var list = new List<int>();
             for(var i = 1; i < args.Length - 1; i++)
                 if(args[i] - args[i - 1] == args[i + 1] - args[i] && args[i] - args[i - 1] == 1)
                     list.Add(i);
             var temp = new string[args.Length];
             for(var i = 0; i < args.Length; i++) {
                 temp[i] = args[i].ToString();
                 if(list.Contains(i)) temp[i] = "-";
             }
             var s = string.Join(',', temp);
             return Regex.Replace(s, "(,-)+,", "-");
         }

        /// <summary>
        /// Description:
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
        /// The sum of these multiples is 23.
        /// Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
        /// Note: If the number is a multiple of both 3 and 5, only count it once.
        /// Also, if a number is negative, return 0(for languages that do have them)
        /// </summary>
        /// <param name="Multiples of 3 or 5"></param>
        public static int Solution(int value) {
             return (value >0)?Enumerable.Range(1, value-1).Where(i=> i%5 ==0 || i%3 ==0).Sum():0;
         }

        /// <summary>
        /// Write an algorithm that takes an array and moves all of the zeros to the end,
        /// preserving the order of the other elements.
        /// </summary>
        /// Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}
        /// <param name="Moving Zeros To The End"></param>
        /// <returns></returns>
        public static int[] MoveZeroes(int[] arr) {
            return Enumerable.Concat(arr.Where(a=> a !=0) ,arr.Where(a => a == 0)).ToArray();
            // return arr.OrderBy(x => x==0).ToArray();
        }
    }

}
    