using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class calculateFibonacciLevels
    {
        /// <summary>
        /// The purpose of this method is to calculate the Fibonacci levels for the selected wave
        /// We first retrieve the starting and ending candlesticks of the wave. We determine the start and end prices based on the wave direction.
        /// We calculate the price range of the wave and calculate Fibonacci levels based on the wave direction.
        /// For an upward wave, levels are calculated as additions to the start price. For a downward wave, levels are calculated as subtractions from the start price.
        /// We add the calculated Fibonacci levels to a list and return the list of double values representing the Fibonacci levels.
        /// </summary>
        /// <param name="selectedWave">A list of SmartCandlestick objects representing the wave.</param>
        /// <param name="isUpward">A boolean indicating the direction of the wave.</param>
        /// <returns>A list of double values representing the calculated Fibonacci levels.</returns>
        public static List<double> CalculateFibonacciLevels(List<SmartCandlestick> selectedWave, bool isUpward)
        {
            // Initialize a list to store the Fibonacci levels
            List<double> levels = new List<double>();

            // Retrieve the starting and ending candlesticks of the wave
            SmartCandlestick startCandle = selectedWave[0];
            SmartCandlestick endCandle = selectedWave[selectedWave.Count - 1];

            // Determine the start and end prices for the wave based on its direction
            decimal startPrice = isUpward ? startCandle.Low : startCandle.High;
            decimal endPrice = isUpward ? endCandle.High : endCandle.Low;

            // Calculate the price range of the wave
            decimal range = Math.Abs(startPrice - endPrice);

            // Calculate Fibonacci levels based on wave direction
            if (isUpward)
            {
                // For an upward wave, levels are calculated as additions to the start price
                levels.Add((double)startPrice);                    // 0%
                levels.Add((double)(startPrice + 0.236m * range)); // 23.6%
                levels.Add((double)(startPrice + 0.382m * range)); // 38.2%
                levels.Add((double)(startPrice + 0.5m * range));   // 50.0%
                levels.Add((double)(startPrice + 0.618m * range)); // 61.8%
                levels.Add((double)(startPrice + 0.786m * range)); // 78.6%
                levels.Add((double)endPrice);                      // 100%
            }
            else
            {
                // For a downward wave, levels are calculated as subtractions from the start price
                levels.Add((double)startPrice);                    // 100%
                levels.Add((double)(startPrice - 0.236m * range)); // 78.6%
                levels.Add((double)(startPrice - 0.382m * range)); // 61.8%
                levels.Add((double)(startPrice - 0.5m * range));   // 50.0%
                levels.Add((double)(startPrice - 0.618m * range)); // 38.2%
                levels.Add((double)(startPrice - 0.786m * range)); // 23.6%
                levels.Add((double)endPrice);                      // 0%
            }

            // Return the calculated Fibonacci levels
            return levels;
        }

    }
}
