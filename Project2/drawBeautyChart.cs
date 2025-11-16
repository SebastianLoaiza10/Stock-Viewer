using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class drawBeautyChart
    {
        /// <summary>
        /// The purpose of this method is to draw a beauty bar chart to visualize the beauty scores of the selected wave
        /// We first calculate the start and end prices of the wave based on its direction. We clear any existing beauty series from the chart.
        /// We create a new series for the beauty bar chart and configure its properties. We add the default beauty score as the first bar in the chart.
        /// We add beauty scores for each percentage level to the chart. We format the X-axis and Y-axis of the beauty chart area.
        /// Finally, we add the series to the chart and display the beauty bar chart.
        /// </summary>
        /// <param name="selectedWave">A list of SmartCandlestick objects representing the wave.</param>
        /// <param name="defaultBeauty">The default beauty score of the wave.</param>
        /// <param name="beautyByPercentage">A dictionary mapping percentage levels (key) to their corresponding beauty scores (value). </param>
        /// <param name="isUpwardWave">A boolean indicating the wave's direction. True for an upward wave, false for a downward wave.</param>
        /// <param name="chart_stockData">The chart control used to display the beauty bar chart.</param>
        public static void DrawBeautyBarChart(List<SmartCandlestick> selectedWave, int defaultBeauty, Dictionary<double, int> beautyByPercentage, bool isUpwardWave, Chart chart_stockData)
        {
            // Calculate the start and end prices of the wave based on its direction
            double startPrice = (double)(isUpwardWave ? selectedWave[0].Low : selectedWave[0].High);
            double endPrice = (double)(isUpwardWave ? selectedWave[selectedWave.Count - 1].High : selectedWave[selectedWave.Count - 1].Low);

            // Clear any existing beauty series from the chart
            if (chart_stockData.Series.IndexOf("Series_Beauty") >= 0)
                chart_stockData.Series.Remove(chart_stockData.Series["Series_Beauty"]);

            // Create a new series for the beauty bar chart
            Series beautySeries = new Series("Series_Beauty")
            {
                ChartType = SeriesChartType.Column, // Use a bar chart type
                ChartArea = "ChartArea_beauty",    // Attach to the beauty chart area
                Color = System.Drawing.Color.Purple,
                IsXValueIndexed = true,
                XValueType = ChartValueType.Double
            };

            // Add the default beauty score as the first bar in the chart
            DataPoint defaultPoint = new DataPoint
            {
                XValue = startPrice, // Use start price as X-axis value
                YValues = new double[] { defaultBeauty }, // Default beauty score
                AxisLabel = startPrice.ToString("F2") // Label for the start price
            };
            beautySeries.Points.Add(defaultPoint);

            // Add beauty scores for each percentage level to the chart
            foreach (KeyValuePair<double, int> kvp in beautyByPercentage)
            {
                DataPoint percentagePoint = new DataPoint();

                // Adjust the percentage based on wave direction:
                double adjustedPercentage = isUpwardWave
                    ? 100.0 + kvp.Key      // If upward, 100% + key%
                    : 100.0 - kvp.Key;     // If downward, 100% - key%

                double fraction = adjustedPercentage / 100.0;
                double price = startPrice + (fraction * (endPrice - startPrice));

                percentagePoint.XValue = price;
                percentagePoint.YValues = new double[] { kvp.Value };
                percentagePoint.AxisLabel = string.Format("{0}% ({1:F2})", adjustedPercentage, price);

                beautySeries.Points.Add(percentagePoint);
            }


            // Add the series to the chart
            chart_stockData.Series.Add(beautySeries);

            // Format the X-axis of the beauty chart area
            ChartArea beautyChartArea = chart_stockData.ChartAreas["ChartArea_beauty"];
            beautyChartArea.AxisX.Title = "Price";
            beautyChartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            beautyChartArea.AxisX.LabelStyle.Format = "F2"; // Display labels with 2 decimal places
            beautyChartArea.AxisX.MajorGrid.Enabled = false;

            // Format the Y-axis of the beauty chart area
            beautyChartArea.AxisY.Title = "Beauty";
            beautyChartArea.AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
            beautyChartArea.AxisY.MajorGrid.Enabled = true;
        }
    }
}
