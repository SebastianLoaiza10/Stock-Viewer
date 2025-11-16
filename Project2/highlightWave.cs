using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace Project2
{
    public static class highlightWave
    {
        public static void HighlightWave(List<SmartCandlestick> smartCandlesticks, int startIndex, int endIndex, Chart chart_stockData)
        {
            // Validate indices to ensure they are within bounds
            if (startIndex < 0 || endIndex < 0 || startIndex >= smartCandlesticks.Count || endIndex >= smartCandlesticks.Count)
            {
                MessageBox.Show("Invalid indices for highlighting the wave.");
                return;
            }

            // Determine the direction of the wave
            bool isUpward = isUpwardWave.IsUpwardWave(smartCandlesticks,startIndex, endIndex);
            bool isDownward = isDownwardWave.IsDownwardWave(smartCandlesticks, startIndex, endIndex);

            // Select candlesticks within the wave range
            List<SmartCandlestick> selectedWave = selectWaveCandlesticks.SelectWaveCandlesticks(smartCandlesticks, startIndex, endIndex);

            // Calculate Fibonacci levels for the wave
            List<double> fibonacciLevels = calculateFibonacciLevels.CalculateFibonacciLevels(selectedWave, isUpward);

            // Retrieve the high and low values of the wave
            SmartCandlestick startCandle = smartCandlesticks[startIndex];
            SmartCandlestick endCandle = smartCandlesticks[endIndex];
            double waveHigh = (double)Math.Max(startCandle.High, endCandle.High);
            double waveLow = (double)Math.Min(startCandle.Low, endCandle.Low);

            // Clear any existing wave-related annotations from the chart
            clearWaveAnnotations.ClearWaveAnnotations(chart_stockData);

            // Create a rectangle annotation to visually highlight the wave
            RectangleAnnotation waveRectangle = new RectangleAnnotation
            {
                ClipToChartArea = "ChartArea_stockData",
                AnchorDataPoint = chart_stockData.Series[0].Points[startIndex],
                BackColor = System.Drawing.Color.Transparent,
                LineColor = System.Drawing.Color.Orange,
                LineWidth = 1
            };

            // Configure the rectangle's dimensions and position based on wave direction
            if (isUpward)
            {
                waveRectangle.AnchorOffsetX += (endIndex - startIndex);
                waveRectangle.Y = waveLow;
                waveRectangle.Width = (endIndex - startIndex) * 3;
                waveRectangle.Height = -(waveHigh - waveLow) / 2.9;
            }
            else if (isDownward)
            {
                waveRectangle.AnchorOffsetX += (endIndex - startIndex);
                waveRectangle.Y = waveHigh;
                waveRectangle.Width = (endIndex - startIndex) * 3;
                waveRectangle.Height = (waveHigh - waveLow) / 2.9;
            }

            // Add the rectangle annotation to the chart
            waveRectangle.Name = "WaveRectangle";
            chart_stockData.Annotations.Add(waveRectangle);

            // Draw Fibonacci levels as strip lines based on wave direction
            foreach (double fibLevel in fibonacciLevels)
            {
                StripLine fibStrip = new StripLine
                {
                    IntervalOffset = fibLevel, // Position of the Fibonacci level
                    StripWidth = 0, // No width to make it a line
                    BorderColor = System.Drawing.Color.Blue, // Line color
                    BorderWidth = 1, // Line thickness
                    BorderDashStyle = ChartDashStyle.Solid // Line style
                };
                chart_stockData.ChartAreas["ChartArea_stockData"].AxisY.StripLines.Add(fibStrip);
            }
        }

    }
}
