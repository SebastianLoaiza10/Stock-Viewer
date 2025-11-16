using System;
using System.Collections.Generic;

namespace Project2
{
    public static class aCandlestickFilter
    {
        /// <summary>
        /// Filters the list of candlesticks based on a date range.
        /// We first create a new list to store the filtered candlesticks.
        /// Afterwards, we loop through each candlestick in the input list and check if the candlestick date is within the specified date range.
        /// If so, its added the filtered candlestick list. Then we return the filtered list.
        /// </summary>
        /// <param name="candlesticks">The list of candlesticks to filter.</param>
        /// <param name="startDate">The start date of the filter range.</param>
        /// <param name="endDate">The end date of the filter range.</param>
        /// <returns>A list of candlesticks within the specified date range.</returns>
        public static List<aCandlestick> FilterByDateRange(List<aCandlestick> candlesticks, DateTime startDate, DateTime endDate)
        {
            // Create a new list to store the filtered candlesticks
            List<aCandlestick> filteredCandlesticks = new List<aCandlestick>();

            // Loop through each candlestick in the list
            foreach (aCandlestick candlestick in candlesticks)
            {
                // Check if the candlestick date is within the specified date range
                if (candlestick.Date >= startDate && candlestick.Date <= endDate)
                {
                    // Add the candlestick to the filtered list
                    filteredCandlesticks.Add(candlestick);
                }
            }

            // Return the filtered list
            return filteredCandlesticks;
        }
    }
}
