using System;

namespace Inventory.Classes
{
    class Util
    {
        internal static bool CheckEmptyString(string str)
        {
            return str.Trim().Length > 0;
        }

        internal static bool CheckValidCount(int count)
        {
            return count >= 0 && count < 2_147_483_647;
        }

        internal static bool CheckValidCount(string count)
        {
            try 
            {
                int val = Convert.ToInt32(count.Trim());
                return val >= 0 && val < 2_147_483_647;
            } 
            catch (Exception e) 
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        internal static bool CheckValidPrice(decimal price)
        {
            return price >= 0;
        }

        internal static bool CheckValidPrice(string price)
        {
            try
            {
                decimal val = Convert.ToDecimal(price.Trim());
                return val >= 0;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        internal static decimal ReAverage(decimal prevPrice, int prevCount, decimal purchasePrice, int purchaseCount)
        {
            decimal prevTotalPrice = prevPrice * prevCount;
            decimal newTotalPrice = prevTotalPrice + purchasePrice;

            int newCount = prevCount + purchaseCount;
            return newTotalPrice / newCount;
        }
    }
}
