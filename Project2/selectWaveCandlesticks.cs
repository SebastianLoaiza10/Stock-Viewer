using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class selectWaveCandlesticks
    {
        /// <summary>
        /// The purpose of this method is to get the selected wave candlesticks in a list of SmartCandlesticks
        /// We first validate the provided indices to ensure they are within the bounds of the candlestick list.
        /// We then iterate through the candlesticks in the specified range and create a copy of each candlestick.
        /// We add the copied candlestick to the wave candlesticks list and return the list of selected candlesticks.
        /// </summary>
        /// <param name="smartCandlesticks">The list of SmartCandlestick objects to select from.</param>
        /// <param name="startIndex">The starting index of the wave range.</param>
        /// <param name="endIndex">The ending index of the wave range.</param>
        /// <returns> A list of SmartCandlestick objects that are the candlesticks in the selected wave</returns>
        public static List<SmartCandlestick> SelectWaveCandlesticks(List<SmartCandlestick> smartCandlesticks, int startIndex, int endIndex)
        {
            // Initialize a new list to store the selected candlesticks
            List<SmartCandlestick> waveCandlesticks = new List<SmartCandlestick>();

            // Iterate through the candlesticks in the specified range
            for (int i = startIndex; i <= endIndex; i++)
            {
                // Create a new SmartCandlestick object as a copy of the original data
                SmartCandlestick candle = new SmartCandlestick(
                    smartCandlesticks[i].Date,
                    smartCandlesticks[i].Open,
                    smartCandlesticks[i].High,
                    smartCandlesticks[i].Low,
                    smartCandlesticks[i].Close,
                    smartCandlesticks[i].Volume
                );

                // Add the copied candlestick to the wave candlesticks list
                waveCandlesticks.Add(candle);
            }

            // Return the list of selected candlesticks
            return waveCandlesticks;
        }

    }
}
