using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inlamning2Algoritmer
{
    class Runtime
    {
        public int[] ReadNumbersFromFile()
        {
            var filePath = Environment.CurrentDirectory + "\\data.txt";
            var lines = File.ReadAllLines(filePath);
            var data = lines[0].Split('\t');

            return Array.ConvertAll(data, int.Parse);
            
        }

        public string[] ReadCharsFromFile()
        {
            var filePath = Environment.CurrentDirectory + "\\data2.txt";
            var lines = File.ReadAllLines(filePath);
            var data = lines[0].Split('\t');
            return data;
        }


        #region MergeSort
        //Added this function just to be able to print the results out 
        //without repeating it many times as it will be recalled internally
        public void MergeSort<T>(T[] numbers)
        {
            //Starting the execution´s timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            MergeSort(numbers, 0, numbers.Length - 1);

            //Stopping the execution´s timer
            watch.Stop();
            var mergeSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Merge", mergeSortExeecutionTime);
        }
        void MergeSort<T>(T[] numbers, int left, int right)
        {
            int mid;
            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort(numbers, left, mid);
                MergeSort(numbers, (mid + 1), right);
                MainMerge(numbers, left, (mid + 1), right);
            }

        }

        private void MainMerge<T>(T[] numbers, int left, int mid, int right) 
        {
            T[] temp = new T[numbers.Length];

            int i, dim, num, pos;

            //dim is allways mid-1 to compare it with the left side therefore naming it backwards mid => All Copyrights reserved to Sami :-D
            dim = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= dim) && (mid <= right))
            {
                if (Comparer<T>.Default.Compare(numbers[left], numbers[mid] ) <= 0)
                    temp[pos++] = numbers[left++];

                else
                    temp[pos++] = numbers[mid++];
            }

            while (left <= dim)
            {
                temp[pos++] = numbers[left++];
            }

            while (mid <= right)
            {
                temp[pos++] = numbers[mid++];
            }

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }     
        }
        #endregion

        #region BubbleSort
        public void BubbleSort<T>(T[] numbers)
        {
            //Starting the execution´s timer
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < numbers.Length; i++)
            {               
                for (int j = numbers.Length -1; j  > 0; j--)
                {
                    if (Comparer<T>.Default.Compare(numbers[j], numbers[j - 1]) < 0)
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j - 1];
                        numbers[j - 1] = temp;
                    }
                }
            }

            //Stopping the execution´s timer
            watch.Stop();
            var bubbleSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Bubble", bubbleSortExeecutionTime);
        }
        #endregion

        #region QuickSort
        internal void QuickSort<T>(T[] numbers)
        {
            //Starting the execution´s timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(numbers, 0, numbers.Length - 1);
            watch.Stop();
            var quickSortExeecutionTime = watch.ElapsedMilliseconds;
            Print(numbers, "Quick", quickSortExeecutionTime);
        }
        internal void QuickSort<T>(T[] numbers, int left, int right)
        {           
            if (Comparer<int>.Default.Compare(left, right) < 0)
            {
                int index = Partition(numbers, left, right);

                QuickSort(numbers, left, index - 1);                
                QuickSort(numbers, index + 1, right);
            }           
        }

        private int Partition<T>(T[] numbers, int left, int right)
        {
            T pivot = numbers[right];
            T temp;

            int i = left;
            for (int j = left; j < right; j++)
            {
                if (Comparer<T>.Default.Compare(numbers[j], pivot) <= 0) 
                {
                    temp = numbers[j];
                    numbers[j] = numbers[i];
                    numbers[i] = temp;
                    i++;
                }
            }

            numbers[right] = numbers[i];
            numbers[i] = pivot;

            return i;
        }
        #endregion

        public void Print<T>(T[] numbers, string type, Int64 excutionTime)
        {
            string typeOfData;
            typeOfData = numbers.GetType().ToString();
            typeOfData = typeOfData.Substring(7);
            if (type == "Bubble")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Data type : {0} Bubble sorted:   (Execution time: {1} ms)", typeOfData, excutionTime);

            }
            else if (type == "Merge")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Data type : {0} Merge sorted:   (Execution time: {1} ms)", typeOfData, excutionTime);
            }
            else if (type == "Quick")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Data type : {0} Quick sorted:   (Execution time: {1} ms)", typeOfData, excutionTime);
            }
            foreach(var number in numbers)
            {
                Console.WriteLine("  " + number);
            }
        }
    }
}
