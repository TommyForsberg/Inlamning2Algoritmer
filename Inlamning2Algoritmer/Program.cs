using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning2Algoritmer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var runtime = new Runtime();
            var numbers = runtime.ReadNumbersFromFile();
            var numbers2 = runtime.ReadNumbersFromFile();
            var numbers3 = runtime.ReadNumbersFromFile();
            var chars = runtime.ReadCharsFromFile();
            var chars2 = runtime.ReadCharsFromFile();
            var chars3 = runtime.ReadCharsFromFile();

            runtime.BubbleSort(numbers);
            runtime.BubbleSort(chars);

            runtime.MergeSort(numbers2);
            runtime.MergeSort(chars2);

            runtime.QuickSort(numbers3);
            runtime.QuickSort(chars3);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
