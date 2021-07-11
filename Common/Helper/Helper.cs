using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public static class Helper
    {

        public static decimal GetCurrentDiscountAmount(DateTime campaignStartDate, decimal priceManipulationLimit, int duration)
        {
            return Math.Abs((SystemClock.Now - campaignStartDate).Hours) * (priceManipulationLimit / duration + 1) + (priceManipulationLimit / duration + 1);
        }
    }
}
