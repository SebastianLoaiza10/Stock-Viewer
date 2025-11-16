using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class addPeaks
    {
        /// <summary>
        /// This method creates horizontal line and arrow annotations for peaks in the candlestick chart
        /// We first remove any existing peak annotations to avoid duplicates, then we ensure we have atleast 3 candlesticks to compare peaks
        /// Then we loop through the candlesticks, skipping the first and last elements, and check if the current candlestick is a peak
        /// If so, we create a HorizontalLineAnnotation and ArrowAnnotation for the peak, and add them to the chart annotations
        /// </summary>
        /// <param name="candlesticks">List of candlesticks to determine the peaks</param>
        /// <param name="chart_stockData">the chart that will be displayed with peaks</param>
        public static void AddPeaks(List<aCandlestick> candlesticks, Chart chart_stockData)
        {
            // Clear existing peak annotations to avoid duplicates
            for (int i = chart_stockData.Annotations.Count - 1; i >= 0; i--)
            {
                // Check if the annotation is a peak
                if (chart_stockData.Annotations[i].Name.StartsWith("Peak"))
                {
                    // Remove the annotation if it is a peak
                    chart_stockData.Annotations.RemoveAt(i);
                }
            }

            // Ensure there are enough candlesticks to compare peaks
            if (candlesticks.Count < 3) return;

            int peakCounter = 0;

            // Loop through the candlesticks, skipping the first and last elements
            for (int i = 1; i < candlesticks.Count - 1; i++)
            {
                // Get the previous, current, and next candlesticks
                var previousCandle = candlesticks[i - 1];
                var currentCandle = candlesticks[i];
                var nextCandle = candlesticks[i + 1];

                // Check if the current candlestick is a peak
                if (currentCandle.High > previousCandle.High && currentCandle.High > nextCandle.High)
                {
                    // Create a HorizontalLineAnnotation for the peak
                    var peakLine = new HorizontalLineAnnotation();
                    peakLine.AnchorDataPoint = chart_stockData.Series[0].Points[i]; // Set the anchor point at the specific data point
                    peakLine.ClipToChartArea = "ChartArea_stockData"; // Clip the line to the chart area
                    peakLine.LineColor = System.Drawing.Color.Green; // Green color for peaks
                    peakLine.LineWidth = (int)1.5f; // Set the line width
                    peakLine.AnchorY = (double)currentCandle.High; // Set the anchor point at the peak high
                    peakLine.IsInfinitive = true; // Extend the line across the chart
                    peakLine.Name = $"PeakLine_{peakCounter}"; // Assign a unique name

                    // Add the peak line to the chart annotations
                    chart_stockData.Annotations.Add(peakLine);

                    // Create an ArrowAnnotation for the peak
                    var peakArrow = new ArrowAnnotation();
                    peakArrow.AnchorDataPoint = chart_stockData.Series["Series_ohlc"].Points[i]; // Use the exact series name if different
                    peakArrow.ArrowSize = 3; // Set the arrow size for visibility
                    peakArrow.LineColor = System.Drawing.Color.Green; // Set the arrow color
                    peakArrow.LineWidth = 2; // Set the line width
                    peakArrow.Height = -3.0; // Set direction to point above the peak
                    peakArrow.Width = 0;
                    peakArrow.Name = $"PeakArrow_{peakCounter}"; // Assign a unique name

                    // Add the peak arrow to the chart annotations
                    chart_stockData.Annotations.Add(peakArrow);

                    // Increment the peak counter for the next peak
                    peakCounter++;
                }
            }
        }
    }
}
