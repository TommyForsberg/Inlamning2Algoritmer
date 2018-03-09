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
            runtime.BubbleSort(numbers);
            runtime.MergeSort(numbers);
            runtime.QuickSort(numbers);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
