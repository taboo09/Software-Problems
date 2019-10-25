using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class MinimumLoss
    {
        public static int GetMinimumLoss(long[] prices)
        {
            if(prices.Length == 2) return (int)(prices[1] - prices[0]);

            var sortedPrices = new long[prices.Length];

            Array.Copy(prices, sortedPrices, prices.Length);

            Array.Sort(sortedPrices);
            var step = sortedPrices.Length;
            
            long prevLoss = 0;

            while (step > 0)
            {
                long price1 = 0;
                long price2 = 0;
                
                var loss = Int64.MaxValue;

                for(var i = 0; i < sortedPrices.Length - 1; i++)
                {
                    if (loss > (sortedPrices[i + 1] - sortedPrices[i]) && (sortedPrices[i + 1] - sortedPrices[i] > prevLoss))
                    {
                        loss = sortedPrices[i + 1] - sortedPrices[i];
                        price1 = sortedPrices[i];
                        price2 = sortedPrices[i + 1];
                    }
                }

                if (Array.IndexOf(prices, price1) > Array.IndexOf(prices, price2)) return (int)loss;

                prevLoss = loss;

                step--;
            }

            return (int)prevLoss;
        }
    }
}