using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.leetcode.algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            Console.WriteLine("please start typing the numbers");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine() == null ? "0" : Console.ReadLine());
            }

            Console.WriteLine("please enter target number");

            var target = int.Parse(Console.ReadLine());

            var result = TwoSum(arr, target);

            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static int[] TwoSum(int[] arr, int target)
        {
            List<int> set = new List<int>();
            foreach (int i in arr)
            {
                set.Add(i);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (set.Contains(target - arr[i]))
                {
                    return new int[] { i, set.IndexOf(target - arr[i]) };
                }
            }

            throw new NotImplementedException();
        }
    }
}
