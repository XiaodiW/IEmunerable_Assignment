using System;

namespace AllNumbersLooping.HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*IEnumerable array = new[] {1, 2, 3, 4};
            foreach (var number in array) {
                Console.WriteLine("Foreach: "+number);
            }
            var enumerator = array.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Enumerator: " + enumerator.Current);
            }*/
            
            var enumerable = new AllNumbersLooping(3, 7);
            enumerable.AlsoLoopTo(5);
            enumerable.AlsoLoopTo(9);
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext()) Console.Write($"{enumerator.Current};");
        }
    }
}
