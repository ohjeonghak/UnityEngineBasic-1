using System.Globalization;
using System.Diagnostics;
using System.Linq;
namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int[] arr // = {1, 4, 3, 3, 9, 8, 7, 2, 5, 0};
                
                = Enumerable
                .Repeat(0, 100000)
                .Select(i => random.Next(0, 100000))
                .ToArray();


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // O(N^2) 형태의 SortAlgorithm은 잘 안씀
            //ArraySort.BubbleSort(arr);
            //ArraySort.SelecionSort(arr);
            //ArraySort.InsertionSort(arr);

            //로그N 형태
            //ArraySort.MergeSort(arr);
            //ArraySort.RecursiveMergeSort(arr);

            // O(N^2) 최악의 형태지만 잘쓰는 형태
            //ArraySort.RecursiveQuickSort(arr);
            // ->중복된 경우의 수가 많으면  MergeSort의 성능이 QuickSort보다 좋아지는 경향이 있다.
            // ->공간복잡도에대해 문제가 없으면 해당 경우에서는 MergeSort를 사용하는것을 고려해야한다.


            ArraySort.QuickSort(arr);
            stopwatch.Stop();
            Console.WriteLine($"소요시간 : {stopwatch.ElapsedMilliseconds}");

            Console.Write("Result : ");
            
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]},");
            }
        }
    }
}