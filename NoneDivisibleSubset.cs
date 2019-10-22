using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class NoneDivisibleSubset
    {
        // https://www.hackerrank.com/challenges/non-divisible-subset/problem?isFullScreen=true
        public static int SubsetCount(List<int> listOfNumbers, int div)
        {
            if (listOfNumbers.Count == 1) return 1;
            if ((listOfNumbers.Count == 2) && (listOfNumbers.Sum() % div == 0 )) return 1;
            if ((listOfNumbers.Count == 2) && (listOfNumbers.Sum() % div != 0 )) return 2;
            if (div < 3) return div;

            for (int i = 0; i < listOfNumbers.Count; i++)
            {
                listOfNumbers[i] = listOfNumbers[i] % div;
            }

            var distincts = listOfNumbers.Distinct().ToList();

            foreach (var item in distincts)
            {
                var appearance = listOfNumbers.Count(x => x == item);
                var oppositeAppearance = 0;

                // nr been removed from the list
                if (appearance == 0) continue;

                // remove appearance - 1 it item is half of the div or equal to 0
                if (((item == 0) || (item * 2 == div)) && (appearance > 1)) 
                {
                    for (int i = 1; i < appearance; i++)
                    {
                        listOfNumbers.Remove(item);
                    }
                }

                var opposite = distincts.Where(x => x != item).SingleOrDefault(x => (x + item) % div == 0);

                if (opposite != 0)
                {
                    oppositeAppearance = listOfNumbers.Count(x => x == opposite);
                }

                if (opposite == 0 || oppositeAppearance == 0) continue;
                
                if (oppositeAppearance > appearance) listOfNumbers.RemoveAll(x => x == item);
                else listOfNumbers.RemoveAll(x => x == opposite);
            }

            return listOfNumbers.Count;
        }
    }
}