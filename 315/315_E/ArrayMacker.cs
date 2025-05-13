using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _315_E
{
    internal class ArrayMacker
    {
        public static void Run()
        {
            Console.WriteLine("Ener start end and step");
            var input = Console.ReadLine();
            string[] inputs = input.Split(" ");
            int[] result = MakeArray(int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]));
            Console.WriteLine(string.Join(", ", result));
        }

        public static int[] MakeArray(int firstElement,  int lastElement, int step)
        {
            return Enumerable.Range(0, (lastElement - firstElement)/step).Select(i => firstElement + i*step).ToArray();
        }
    }
}
