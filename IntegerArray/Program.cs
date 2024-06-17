using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerArray
{
    internal class Program
    {
        public int[] ExceptSelf(int[] nums)
        {
            int position = nums.Length;

            // Step 1: Create left and right product arrays
            int[] left = new int[position];
            int[] right = new int[position];
            int[] result = new int[position];

            // Step 2: Fill left product array
            left[0] = 1;
            for (int i = 1; i < position; i++)
            {
                left[i] = nums[i - 1] * left[i - 1];
            }
            /*
             * left[0] = 1

             left[1] = nums[0] * left[0] = 1 * 1 = 1
            left[2] = nums[1] * left[1] = 2 * 1 = 2
             left[3] = nums[2] * left[2] = 3 * 2 = 6
            */

           
            right[position - 1] = 1;
            for (int i = position - 2; i >= 0; i--)
            {
                right[i] = nums[i + 1] * right[i + 1];
            }
            /* 
           * right[length-1] = 1
          right[2] = nums[3] * right[3] = 4 * 1 = 4
          right[1] = nums[2] * right[2] = 3 * 4 = 12
          right[0] = nums[1] * right[1] = 2 * 12 = 24
              right = [24, 12, 4, 1]
          */
            // 
            for (int i = 0; i < position; i++)
            {
                result[i] = left[i] * right[i];
            }
            /*
         result[0] = left[0] * right[0] = 1 * 24 = 24
          result[1] = left[1] * right[1] = 1 * 12 = 12
        result[2] = left[2] * right[2] = 2 * 4 = 8
        result[3] = left[3] * right[3] = 6 * 1 = 6
            result = [24, 12, 8, 6]
            */

            return result;
        }

        // Test the function with the example
        public static void Main(string[] args)
        {
            Program product = new Program();

            int[] nums1 = { 1, 2, 3, 4 };
            int[] result1 = product.ExceptSelf(nums1);
            Console.WriteLine(string.Join(", ", result1));  // Output: 24, 12, 8, 6

            int[] nums2 = { -1, 1, 0, -3, 3 };
            int[] result2 = product.ExceptSelf(nums2);
            Console.WriteLine(string.Join(", ", result2));  // Output: 0, 0, 9, 0, 0
        }
    }
}
