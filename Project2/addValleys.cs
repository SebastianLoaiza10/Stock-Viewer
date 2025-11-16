using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class addValleys
    {
        /// <summary>
        /// This method creates horizontal line and arrow annotations to indicate valleys on the chart
        /// We first remove any existing valley annotations to avoid duplicates, and then ensure there are enough candlesticks to compare valleys
        /// Next, we loop through the candlesticks, skipping the first and last elements, and get the previous, current, and next candlesticks
        /// If there is a peak, we create a HorizontalLineAnnotation and ArrowAnnotation for the valley, and add them to the chart annotations
        /// </summary>
        /// <param name="candlesticks">List of candlesticks to determine the valleys</param>
        /// <param name="chart_stockData">the chart that will be displayed with valleys</param>
        public static void AddValleys(List<aCandlestick> candlesticks, Chart chart_stockData)
        {
            // Clear existing valley annotations to avoid duplicates
            for (int i = chart_stockData.Annotations.Count - 1; i >= 0; i--)
            {
                // Check if the annotation is a valley
                if (chart_stockData.Annotations[i].Name.StartsWith("Valley"))
                {
                    // Remove the annotation if it is a valley
                    chart_stockData.Annotations.RemoveAt(i);
                }
            }

            // Ensure there are enough candlesticks to compare valleys
            if (candlesticks.Count < 3) return;

            int valleyCounter = 0;

            // Loop through the candlesticks, skipping the first and last elements
            for (int i = 1; i < candlesticks.Count - 1; i++)
            {
                // Get the previous, current, and next candlesticks
                var previousCandle = candlesticks[i - 1];
                var currentCandle = candlesticks[i];
                var nextCandle = candlesticks[i + 1];

                // Check if the current candlestick is a valley
                if (currentCandle.Low < previousCandle.Low && currentCandle.Low < nextCandle.Low)
                {
                    // Create a HorizontalLineAnnotation for the valley
                    var valleyLine = new HorizontalLineAnnotation();
                    valleyLine.AnchorDataPoint = chart_stockData.Series[0].Points[i]; // Set the anchor point at the specific data point
                    valleyLine.ClipToChartArea = "ChartArea_stockData"; // Clip the line to the chart area
                    valleyLine.LineColor = System.Drawing.Color.Red; // Red color for valleys
                    valleyLine.LineWidth = (int)1.5f; // Set the line width
                    valleyLine.AnchorY = (double)currentCandle.Low; // Set the anchor point at the valley low
                    valleyLine.IsInfinitive = true; // Extend the line across the chart
                    valleyLine.Name = $"ValleyLine_{valleyCounter}"; // Assign a unique name

                    // Add the valley line to the chart annotations
                    chart_stockData.Annotations.Add(valleyLine);

                    // Create an ArrowAnnotation for the valley
                    var valleyArrow = new ArrowAnnotation();
                    valleyArrow.AnchorDataPoint = chart_stockData.Series[0].Points[i]; // Set the anchor point at the specific data point
                    valleyArrow.ArrowSize = 3; // Set the arrow size for visibility
                    valleyArrow.LineColor = System.Drawing.Color.Red; // Set the arrow color
                    valleyArrow.LineWidth = 2; // Set the line width
                    valleyArrow.Height = 3.0; // Set direction to point below the peak
                    valleyArrow.Width = 0;
                    valleyArrow.AnchorY = (double)currentCandle.Low; // Set the anchor point at the peak Low
                    valleyArrow.Name = $"ValleyArrow_{valleyCounter}"; // Assign a unique name

                    // Add the valley arrow to the chart annotations
                    chart_stockData.Annotations.Add(valleyArrow);

                    // Increment the valley counter
                    valleyCounter++;
                }
            }
        }
    }
}
