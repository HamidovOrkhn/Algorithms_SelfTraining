using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSortingExamples
{
    internal static class SortingCore
    {
        internal static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        internal static void SelectiveSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int smallest = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[smallest] > arr[j])
                    {
                        smallest = j;
                    }
                }
                int temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;

            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static void plusMinus(List<int> arr)
        {
            decimal minus = 0;
            decimal plus = 0;
            decimal zero = 0;
            decimal count = arr.Count;
            decimal ratioPlus = 0;
            decimal ratioMinus = 0;
            decimal ratioZero = 0;
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    plus++;
                }
                else if (item < 0)
                {
                    minus++;
                }
                else
                {
                    zero++;
                }
            }
            ratioMinus = Math.Round(minus / count, 6);
            ratioPlus = Math.Round(plus / count, 6);
            ratioZero = Math.Round(zero / count, 6);
            Console.WriteLine(ratioPlus);
            Console.WriteLine(ratioMinus);
            Console.WriteLine(ratioZero);
        }
        public static void miniMaxSum(List<int> arr)
        {
            long min = 0;
            long max = 0;
            for (var i = 0; i < arr.Count; i++)
            {
                long sum = arr.Sum(a => (long)a) - arr[i];

                if (sum > max)
                {
                    max = sum;
                }
                if (sum < min && min != 0)
                {
                    min = sum;
                }
                else
                {
                    min = sum;
                }
            }
            Console.WriteLine(min + " " + max);
        }
        public static string timeConversion(string s)
        {
            if (s.Count() <= 2)
            {
                return "";
            }
            string formatizer = s.Substring(s.Length - 2);
            int hour = Convert.ToInt32(s.Substring(0, 2));
            if (formatizer.ToLower() == "am")
            {
                if (hour >= 12)
                {
                    string formated = "00" + s.Substring(2, s.Length - 2);
                    return formated.Substring(0, s.Length - 2);
                }
                else
                {
                    return s.Substring(0, s.Length - 2);
                }

            }
            else if (formatizer.ToLower() == "pm")
            {
                int formated_hour = hour + 12;
                if (formated_hour >= 24)
                {
                    string formated = "12" + s.Substring(2, s.Length - 2);
                    return formated.Substring(0, s.Length - 2);
                }
                else
                {

                    string formated = s.Substring(2, s.Length - 2);
                    formated = formated_hour.ToString() + formated;
                    return formated.Substring(0, s.Length - 2);
                }

            }
            else
            {
                return "";
            }

        }
        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            List<int> result = new();
            for (var i = 0; i < queries.Count; i++)
            {
                int count = 0;
                for (var j = 0; j < strings.Count; j++)
                {
                    if (queries[i] == strings[j])
                    {
                        count++;
                    }
                }
                result.Add(count);
            }
            return result;
        }
        public static int pageCount(int n, int p)
        {
            int numberOfReturns = 0;
            bool fromStart = true;
            int left = 0;
            int right = 1;
            if (p > n / 2)
            {
                fromStart = false;
                right = n;
                left = n - 1;
            }
            while (left != p && right != p)
            {
                numberOfReturns++;
                if (fromStart)
                {
                    left += 2;
                    right += 2;
                }
                else
                {
                    left -= 2;
                    right -= 2;
                }
            }
            return numberOfReturns;
        }
        public static string caesarCipher(string s, int k)
        {
            StringBuilder returnValue = new StringBuilder();
            string originalAlphabet = "abcdefghijklmnopqrstuvwxyz";
            if (k >= originalAlphabet.Count())
            {
                //int cnt = (int)Math.Ceiling(k / (float)originalAlphabet.Count());
                k = k % originalAlphabet.Count();

            }
            string rotated = new string(originalAlphabet
           .Skip(k)
           .Take(originalAlphabet.Count() - k).ToArray())
           + new string(originalAlphabet.Take(k).ToArray());


            for (int i = 0; i < s.Length; i++)
            {
                if (!originalAlphabet.Any(a => a.Equals(s[i])) && !originalAlphabet.ToUpper().Any(a => a.Equals(s[i])))
                {
                    returnValue.Append(s[i]);
                }
                else
                {
                    for (int j = 0; j < originalAlphabet.Length; j++)
                    {
                        if (s[i].Equals(originalAlphabet[j]))
                        {
                            returnValue.Append(rotated[j]);
                        }
                        else if (s[i].Equals(originalAlphabet[j].ToString().ToUpper().ToCharArray()[0]))
                        {
                            returnValue.Append(rotated[j].ToString().ToUpper());
                        }
                    }
                }
            }
            return returnValue.ToString();
        }
        public static string twoArrays(int k, List<int> A, List<int> B)
        {
            int n = A.Count - 1;
            for (var i = 0; i < A.Count; i++)
            {
                for (var j = 0; j < B.Count; j++)
                {
                    int plus = A[i] + B[j];
                    if (plus >= k)
                    {
                        n--;
                    }
                    if (n == 0)
                    {
                        break;
                    }
                }
            }
            if (n > 0)
            {
                return "NO";
            }
            else
            {
                return "YES";
            }

        }
        public static int maxMin(int k, List<int> arr)
        {
            int minvalue = int.MaxValue;
            arr.Sort();
            for (int i = 0; i < arr.Count - k + 1; i++)
            {
                minvalue = Math.Min(minvalue, arr[i + k - 1] - arr[i]);
            }
            return minvalue;
        }
        public static int birthday(List<int> s, int d, int m)
        {
            return 1;
        }
        public static string Sort(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
        public static string gridChallenge(List<string> grid)
        {
            for (int i = 0; i < grid[0].Length; i++)
            {
                for (int j = 1; j < grid.Count; j++)
                {
                    if (Sort(grid[j])[i] < Sort(grid[j - 1])[i])
                    {
                        return "NO";
                    }
                }
            }
            return "YES";
        }
        public static string balancedSums(List<int> arr)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                int firstPart = arr.Take(i).Sum();
                int secondPart = arr.Skip(i + 1).Take(arr.Count - i).Sum();
                if (firstPart == secondPart)
                {
                    return "YES";
                }
            }
            return "NO";
        }
        public static int superDigit(string n, int k)
        {
            int result = superDigitChild(n, k);
            return result;

        }
        public static int superDigitChild(string n, int k)
        {
            if (n.Count() == 1)
            {
                return int.Parse(n);
            }
            long sum = n.ToCharArray().ToList().Select(a => int.Parse(a.ToString())).Sum() * k;
            int result = superDigitChild(sum.ToString(), 1);
            return result;
        }
        public static List<string> Bomb(List<string> grid)
        {
            List<List<int>> indexes = new List<List<int>>();
            List<StringBuilder> zeros = new List<StringBuilder>();
            for (int i = 0; i < grid.Count; i++)
            {
                string data = string.Empty;
                for (int j = 0; j < grid[i].Length; j++)
                {
                    data += "O";
                    if (grid[i][j] == 'O')
                    {
                        indexes.Add(new List<int> { i, j });
                    }
                }
                zeros.Add(new StringBuilder(data));
            }
            for (int i = 0; i < indexes.Count; i++)
            {
                int rownum = indexes[i][0];
                int colnum = indexes[i][1];
                zeros[rownum][colnum] = '.';
                if (rownum - 1 >= 0)
                {
                    zeros[rownum - 1][colnum] = '.';
                }
                if (rownum + 1 < grid.Count)
                {
                    zeros[rownum + 1][colnum] = '.';
                }
                if (colnum - 1 >= 0)
                {
                    zeros[rownum][colnum - 1] = '.';
                }
                if (colnum + 1 < grid[0].Length)
                {
                    zeros[rownum][colnum + 1] = '.';
                }

            }
            return zeros.Select(a => a.ToString()).ToList();
        }
        public static List<string> Zeros(List<string> grid)
        {
            List<string> zeros = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                string data = string.Empty;
                for (int j = 0; j < grid[i].Length; j++)
                {
                    data += "O";
                }
                zeros.Add(data);
            }
            return zeros;
        }
        public static List<string> bomberMan(int n, List<string> grid)
        {
            if (n == 1)
            {
                return grid;
            }
            if (n % 2 == 0)
            {
                return Zeros(grid);
            }
            grid = Bomb(grid);
            if (n % 4 == 1)
                grid = Bomb(grid);
            grid = Bomb(grid);
            return grid;
        }
        public static bool IsPowerOf(uint a)
        {
            return (a != 0) && (a & (a - 1)) == 0;
        }
        public static string GetNumberOfPow(long n)
        {
            int cnt = 0;
            while (n != 1)
            {
                cnt++;
                n /= 2;
            }
            if (cnt % 2 == 0)
                return "Richard";
            return "Louise";

        }
        public static string counterGame(long n)
        {
            if (n == 1)
            {
                return "Richard";
            }

            bool chanceLouise = true;
            while (n > 1)
            {
                if (n > 1)
                {
                    double i = 1;
                    int count = 0;
                    while (i < n)
                    {
                        i = Math.Pow(2, count);
                        if (i > n)
                            break;
                        count++;
                    }
                    count--;
                    double nextNum = (long)Math.Pow(2, count);
                    n = (long)(n - nextNum);
                }
                else
                {
                    n = n / 2;
                }

                if (n == 1)
                    break;

                chanceLouise = !chanceLouise;
            }


            if (chanceLouise)
                return "Louise";
            else
                return "Richard";
        }

        //public static int superDigitChild(string n, int k)
        //{
        //    if (n.Count() == 1)
        //    {
        //        return int.Parse(n);
        //    }
        //    int sum = n.ToCharArray().ToList().Select(a => int.Parse(a.ToString())).Sum() * k;
        //    int result = superDigitChild(sum.ToString(), 1);
        //    return result;
        //}
        public static int lonelyinteger(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                bool notrepeated = true;
                for (var j = i + 1; j < a.Count - 1; j++)
                {
                    if (a[i] == a[j])
                    {
                        notrepeated = false;
                        break;
                    }
                }
                if (notrepeated)
                {
                    return a[i];
                }
            }
            return 0;
        }
        internal static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        internal static void Triangle()
        {
            int[] arr = { 0, 1, 3, 4, 5, 6, 7, 8, 10 };
            int[] arr2 = new int[9];
            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i];
            }
        }
        public static void modify(int[] arr, int n)
        {
            if (n <= 1)
                return;
            int prev = arr[0];
            arr[0] = arr[0] * arr[1];
            for (int i = 1; i < n - 1; i++)
            {
                int curr = arr[i];
                arr[i] = prev * arr[i + 1];
                prev = curr;
            }
            arr[n - 1] = prev * arr[n - 1];
        }

        //internal static int GetMaxMulti(int[] arr)
        //{
        //    int temp = 0;
        //    int count = 0;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        for (int j = 0; j < arr.Length; j++)
        //        {
        //            if (arr[i] == arr[j])
        //            {
        //                count++;
        //                temp = arr[i];
        //            }
        //        }
        //    }
        //}
        internal static List<int> MergeSort(List<int> res)
        {
            if (res.Count == 1)
            {
                return res;
            }
            List<int> right = new List<int>();
            List<int> left = new List<int>();
            int middle = res.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                right.Add(res[i]);
            }
            for (int i = middle; i < res.Count; i++)
            {
                left.Add(res[i]);
            }
            right = MergeSort(right);
            left = MergeSort(left);
            return Merge(left, right);

        }
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() > right.First())
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                    else
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
            }
            return result;
        }
    }
}
