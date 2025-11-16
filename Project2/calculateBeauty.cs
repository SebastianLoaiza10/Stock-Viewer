using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class calculateBeauty
    {
        /// <summary>
        /// The purpose of this method is to calculate the beauty score of the selected wave based on Fibonacci levels
        /// We iterate through each candlestick in the selected wave and check the proximity of each value to all Fibonacci levels.
        /// If any value (open, high, low, close) is within 1.5% of a Fibonacci level, we increment the beauty score.
        /// We return the total amount of beauty calculated for the wave.
        /// </summary>
        /// <param name="selectedWave">A list of SmartCandlestick objects representing the wave.</param>
        /// <param name="fibLevels">A list of Fibonacci levels to evaluate against the candlestick data.</param>
        /// <returns>the total amount of beauty</returns>
        public static int CalculateBeauty(List<SmartCandlestick> selectedWave, List<double> fibLevels)
        {
            // Initialize the beauty score
            int beauty = 0;

            // Iterate through each candlestick in the selected wave
            foreach (SmartCandlestick candle in selectedWave)
            {
                // Check the proximity of each candlestick value to all Fibonacci levels
                foreach (double level in fibLevels)
                {
                    // Convert level to decimal for compatibility with candlestick properties
                    decimal decimalLevel = (decimal)level;

                    // Increment beauty if any value (open, high, low, close) is within 1.5% of a Fibonacci level
                    if (Math.Abs(candle.Open - decimalLevel) <= decimalLevel * 0.015m ||
                        Math.Abs(candle.High - decimalLevel) <= decimalLevel * 0.015m ||
                        Math.Abs(candle.Low - decimalLevel) <= decimalLevel * 0.015m ||
                        Math.Abs(candle.Close - decimalLevel) <= decimalLevel * 0.015m)
                    {
                        beauty++;
                    }
                }
            }

            // Return the calculated beauty score
            return beauty;
        }
    }
}
