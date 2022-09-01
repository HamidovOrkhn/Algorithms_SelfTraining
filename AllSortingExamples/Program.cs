using System;
using System.Collections.Generic;
using System.Linq;

namespace AllSortingExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 9, 5, 6, 4, 8, 7, 34, 27, 56 };
            List<int> arr1 = new List<int> { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 };
            List<int> arr2 = new List<int> { 1132000000, 1120420000, 1512000000, 1132200000, 1123200000 };
            //SortingCore.BubbleSort(arr);
            //SortingCore.SelectiveSort(arr);
            //SortingCore.InsertionSort(arr);
            //var data = SortingCore.MergeSort(arr.ToList());
            //for (int i = 0; i < data.Count; i++)
            //{
            //    Console.WriteLine(data[i]);
            //}
            List<string> result = SortingCore.bomberMan(5,new List<string>{ ".......", "...O.O.", "....O..", "..O....", "OO...OO", "OO.O..." });
            Console.WriteLine(String.Join("\n", result));
        }
    }
}
