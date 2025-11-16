using Project2;
using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class aCandlestickNormalizer
    {
        /// <summary>
        /// Adjusts the Y-axis range of the OHLC ChartArea based on the maximum and minimum values of the candlesticks.
        /// We first create the varibles maxHigh and minLow to store the maximum high and minimum low values of the candlesticks.
        /// Then, we loop through the candlesticks to find the maximum high and minimum low values.
        /// Lastly, we calculate a 2% padding for the Y-axis range and set the minimum and maximum values of the Y-axis.
        /// </summary>
        /// <param name="chartArea">The ChartArea containing the OHLC chart to adjust.</param>
        /// <param name="candlesticks">The list of filtered candlestick data.</param>
        public static void SetYAxisRange(ChartArea chartArea, List<aCandlestick> candlesticks)
        {
            // Initialize the maximum high and minimum low values
            decimal maxHigh = decimal.MinValue;
            decimal minLow = decimal.MaxValue;

            // Loop through the candlesticks to find the maximum high and minimum low values
            foreach (aCandlestick candlestick in candlesticks)
            {
                // Updating the maxHigh and minLow values if necessary
                if (candlestick.High > maxHigh) maxHigh = candlestick.High;
                if (candlestick.Low < minLow) minLow = candlestick.Low;
            }

            // Calculate 2% padding for the Y-axis range
            decimal rangePadding = 0.02m * (maxHigh - minLow);
            decimal adjustedMax = maxHigh + rangePadding;
            decimal adjustedMin = minLow - rangePadding;

            // Convert decimal to double for setting Y-axis values
            chartArea.AxisY.Minimum = (double)adjustedMin;
            chartArea.AxisY.Maximum = (double)adjustedMax;

        }
    }
}
