using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class TargetPairs
    {
        public static int GetPairs(int[] arr, int target)
        {
            if ((arr.Length == 2) && Math.Abs(arr[1] - arr[0]) == target) return 1;

            Array.Sort(arr);

            var pairs = 0;

            for(var i = 0; i < arr.Length - 1; i++)
            {
                for(var k = i + 1;k < arr.Length; k++)
                {
                    if(arr[k] - arr[i] == target) 
                    {
                        pairs++;
                        break;
                    } 
                    else if (arr[k] - arr[i] > target) break;
                }
            }

            return pairs;
        }
    }
}