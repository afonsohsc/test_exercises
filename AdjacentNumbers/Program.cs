using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjacentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 3, 3, 12, 5, 3, 7, 1 };

            Console.Write("Array Main: ");

            foreach (var item in A)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            AdjacentMaxDistance adjacentMaxDistance = new AdjacentMaxDistance(A);

            Console.WriteLine("Adjacent Max Distance: {0} ", adjacentMaxDistance.Solution());

            Console.ReadKey();
        }
    }
}
