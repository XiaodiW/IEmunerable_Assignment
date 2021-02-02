using System.Collections;
using System.Collections.Generic;

namespace AllNumbersLooping
{
    public class AllNumbersLooping : IEnumerable
    {
        private readonly List<int> givenNumbers = new();

        public AllNumbersLooping(int from, int to) //Constructor
        {
            givenNumbers.Add(from);
            givenNumbers.Add(to);
        }

        public void AlsoLoopTo(int number) => givenNumbers.Add(number);

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < givenNumbers.Count - 1; i++)
            {
                var a = givenNumbers[i];
                var b = givenNumbers[i + 1];
                a = i == 0 ? a : a + (a < b ? 1 : -1);
                if (a < b)
                    for (var j = a; j < b + 1; j++)
                        yield return j;
                else
                    for (var j = a; j > b - 1; j--)
                        yield return j;
            }
        }
    }
}