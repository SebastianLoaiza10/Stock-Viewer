using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public static class isUpwardWave
    {
        /// <summary>
        /// The purpose of this method is to check if the wave is upward
        /// First, we ensure the provided indices are valid and within the bounds of the candlestick list.
        /// We then retrieve the first and last candlesticks in the wave. Then, we compare the high and low values of the start and end candlesticks.
        /// If the high and low values of the end candlestick are greater than the start candlestick, the wave is upward.
        /// </summary>
        /// <param name="smartCandlesticks">The list of candlesticks to check.</param>
        /// <param name="startIndex">The index of the starting candlestick.</param>
        /// <param name="endIndex">The index of the ending candlestick.</param>
        /// <returns>True if the wave is upward, otherwise, false.</returns>
        public static bool IsUpwardWave(List<SmartCandlestick> smartCandlesticks, int startIndex, int endIndex)
        {
            // Ensure the provided indices are valid and within the bounds of the candlestick list
            if (startIndex < 0 || endIndex < 0 || startIndex >= smartCandlesticks.Count || endIndex >= smartCandlesticks.Count)
            {
                // Display an error message if indices are invalid
                MessageBox.Show("Invalid indices for checking wave direction.");
                return false; // Default to false as the wave direction cannot be determined
            }

            // Retrieve the candlesticks at the specified start and end indices
            SmartCandlestick startCandle = smartCandlesticks[startIndex];
            SmartCandlestick endCandle = smartCandlesticks[endIndex];

            // Determine if the wave is upward by comparing the high and low values of the start and end candlesticks
            return (endCandle.High > startCandle.High) && (endCandle.Low > startCandle.Low);
        }

    }
}
