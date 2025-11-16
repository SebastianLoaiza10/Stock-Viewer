using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{

    public static class findAllPeaksAndValleys
    {
        /// <summary>
        /// The purpose of this method is to find all peaks and valleys in the smart candlestick data.
        /// We first create a new list to store the identified peaks and valleys. We then check if there are enough candlesticks to process.
        /// We loop through the candlesticks, skipping the first and last as they cannot be peaks or valleys.
        /// We get the previous, current, and next candlesticks for comparison. We then check if the current candlestick is a peak or valley.
        /// If the candlestick is both a peak and a valley, we decide which one to prioritize based on business logic.
        /// If it's a peak, we mark it and add it to the result list. If it's a valley, we mark it and add it to the result list.
        /// Finally, we return the list of identified peaks and valleys.
        /// </summary>
        /// <param name="candlesticks">A list of SmartCandlestick objects representing the candlestick data.</param>
        /// <returns>A list of SmartCandlestick objects that are identified as peaks or valleys.</returns>
        public static List<SmartCandlestick> FindAllPeaksAndValleys(List<SmartCandlestick> candlesticks)
        {
            // Create a new list to store the identified peaks and valleys
            List<SmartCandlestick> peaksAndValleys = new List<SmartCandlestick>();

            // Return an empty list if there are less than three candlesticks to process
            if (candlesticks.Count < 3) return peaksAndValleys;

            // Loop through the candlesticks, skipping the first and last as they cannot be peaks or valleys
            for (int i = 1; i < candlesticks.Count - 1; i++)
            {
                // Get the previous, current, and next candlesticks for comparison
                SmartCandlestick previous = candlesticks[i - 1];
                SmartCandlestick current = candlesticks[i];
                SmartCandlestick next = candlesticks[i + 1];

                // Check if the current candlestick is a peak
                bool isPeak = current.High > previous.High && current.High > next.High;

                // Check if the current candlestick is a valley
                bool isValley = current.Low < previous.Low && current.Low < next.Low;

                // If the candlestick is both a peak and a valley, decide which one to prioritize
                if (isPeak && isValley)
                {
                    // Use business logic to determine priority, e.g., by comparing amplitudes
                    if ((current.High - current.Low) > (previous.High - previous.Low))
                    {
                        isPeak = true;
                        isValley = false;
                    }
                    else
                    {
                        isPeak = false;
                        isValley = true;
                    }
                }

                // If it's a peak, mark it and add it to the result list
                if (isPeak)
                {
                    current.IsPeak = true; // Mark as peak
                    peaksAndValleys.Add(current); // Add to the list
                    current.Index = i; // Store the index for reference
                }
                // If it's a valley, mark it and add it to the result list
                else if (isValley)
                {
                    current.IsValley = true; // Mark as valley
                    peaksAndValleys.Add(current); // Add to the list
                    current.Index = i; // Store the index for reference
                }
            }

            // Return the list of identified peaks and valleys
            return peaksAndValleys;
        }
    }
}
