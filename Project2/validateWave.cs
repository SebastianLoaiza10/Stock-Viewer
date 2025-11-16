using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class validateWave
    {
        /// <summary>
        /// The purpose of this method is to check if the selected wave is valid
        /// We first ensure the provided indices are valid and within the bounds of the candlestick list.
        /// We then retrieve the start and end candlesticks for the wave. We calculate the high and low bounds for the wave.
        /// We iterate through the candlesticks in the specified range and validate that no high value exceeds the wave's high boundary.
        /// We also validate that no low value falls below the wave's low boundary. If all checks pass, the wave is valid.
        /// </summary>
        /// <param name="smartCandlesticks">The list of smart candlesticks.</param>
        /// <param name="startIndex">The index of the starting candlestick.</param>
        /// <param name="endIndex">The index of the ending candlestick.</param>
        /// <returns>True if the wave is valid, otherwise, false.</returns>
        public static bool ValidateWave(List<SmartCandlestick> smartCandlesticks, int startIndex, int endIndex)
        {
            // Retrieve the start and end candlesticks for the wave
            SmartCandlestick startCandle = smartCandlesticks[startIndex];
            SmartCandlestick endCandle = smartCandlesticks[endIndex];

            // Ensure the starting candlestick is either a peak or a valley
            if (!startCandle.IsPeak && !startCandle.IsValley)
            {
                return false; // Invalid wave if the starting point is not a peak or valley
            }

            // Determine the wave's high and low bounds
            decimal waveHigh = Math.Max(startCandle.High, endCandle.High);
            decimal waveLow = Math.Min(startCandle.Low, endCandle.Low);

            // Iterate through the candlesticks in the specified range
            for (int i = startIndex; i <= endIndex; i++)
            {
                SmartCandlestick currentCandle = smartCandlesticks[i];

                // Validate that no candlestick's high exceeds the wave's high boundary
                if (currentCandle.High > waveHigh)
                {
                    return false; // Invalid wave if any high value exceeds the wave's high boundary
                }

                // Validate that no candlestick's low falls below the wave's low boundary
                if (currentCandle.Low < waveLow)
                {
                    return false; // Invalid wave if any low value is below the wave's low boundary
                }
            }

            // All checks passed, the wave is valid
            return true;
        }

    }
}
