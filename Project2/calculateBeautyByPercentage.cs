using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    /// <summary>
    /// The purpose of this method is to calculate the beauty score of the selected wave based on different percentage levels
    /// We iterate through each percentage level (5%, 10%, 15%, 20%, 25%) and calculate the adjusted high and low levels for the wave.
    /// We create adjusted Fibonacci levels by applying the adjustment to the original Fibonacci levels.
    /// We calculate the beauty score for the adjusted levels and store the result in a dictionary.
    /// </summary>
    /// <param name="selectedWave">A list of SmartCandlestick objects representing the wave.</param>
    /// <param name="fibLevels">A list of Fibonacci levels to evaluate against the candlestick data.</param>
    /// <param name="isUpward">A boolean indicating the direction of the wave.</param>
    /// <returns>A dictionary mapping each percentage level (key) to the calculated beauty score (value).</returns>
    internal static class calculateBeautyByPercentage
    {
        public static Dictionary<double, int> CalculateBeautyByPercentage(List<SmartCandlestick> selectedWave, List<double> fibLevels, bool isUpward)
        {
            // Initialize a dictionary to store beauty scores by percentage level
            Dictionary<double, int> beautyByPercentage = new Dictionary<double, int>();

            // Retrieve the starting and ending candlesticks of the wave
            SmartCandlestick startCandle = selectedWave[0];
            SmartCandlestick endCandle = selectedWave[selectedWave.Count - 1];

            // Determine the base price and range based on wave direction
            double startPrice = isUpward ? (double)startCandle.Low : (double)startCandle.High;
            double endPrice = isUpward ? (double)endCandle.High : (double)endCandle.Low;
            double range = startPrice - endPrice;

            // Iterate through percentage adjustments from 5% to 25%
            for (double percentage = 5.0; percentage <= 25.0; percentage += 5.0)
            {
                // Calculate the adjustment based on the percentage
                double adjustment = (percentage / 100.0) * range;

                // Determine the adjusted high and low levels for the wave
                double adjustedHigh = isUpward ? startPrice + adjustment : startPrice - adjustment;
                double adjustedLow = isUpward ? startPrice - adjustment : startPrice + adjustment;

                // Create adjusted Fibonacci levels by applying the adjustment
                List<double> adjustedLevels = new List<double>();
                foreach (double level in fibLevels)
                {
                    double adjustedLevel = isUpward ? level + adjustment : level - adjustment;
                    adjustedLevels.Add(adjustedLevel);
                }

                // Calculate the beauty score for the adjusted levels
                int beauty = calculateBeauty.CalculateBeauty(selectedWave, adjustedLevels);

                // Add the calculated beauty score to the dictionary for the current percentage
                beautyByPercentage.Add(percentage, beauty);
            }

            // Return the dictionary containing beauty scores by percentage levels
            return beautyByPercentage;
        }
    }
}
