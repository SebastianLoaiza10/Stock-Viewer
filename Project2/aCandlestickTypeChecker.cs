using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class aCandlestickTypeChecker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="smartCandlesticks"></param>
        /// <param name="candlestickTpye"></param>
        /// <param name="chart_stockData"></param>
        public static void candlestickType(List<SmartCandlestick> smartCandlesticks, string candlestickType, Chart chart_stockData)
        {
            // Clear any existing annotations for candlestick types
            for (int i = chart_stockData.Annotations.Count - 1; i >= 0; i--)
            {
                // Check if the annotation is a candlestick type annotation
                if (chart_stockData.Annotations[i].Name.StartsWith("CandlestickTypeAnnotation"))
                {
                    // Remove the annotation if it matches the candlestick type
                    chart_stockData.Annotations.RemoveAt(i);
                }
            }

            // Loop through each SmartCandlestick in the list
            for (int i = 0; i < smartCandlesticks.Count; i++)
            {
                // Get the SmartCandlestick at the current index
                SmartCandlestick candle = smartCandlesticks[i];
                bool isMatch = false;

                // Check if the candlestick matches the specified type
                if (candlestickType == "Bullish" && candle.IsBullish()) isMatch = true;
                else if (candlestickType == "Bearish" && candle.IsBearish()) isMatch = true;
                else if (candlestickType == "Neutral" && candle.IsNeutral()) isMatch = true;
                else if (candlestickType == "Marubozu" && candle.IsMarubozu()) isMatch = true;
                else if (candlestickType == "Hammer" && candle.IsHammer()) isMatch = true;
                else if (candlestickType == "Doji" && candle.IsDoji()) isMatch = true;
                else if (candlestickType == "Dragonfly doji" && candle.IsDragonflyDoji()) isMatch = true;
                else if (candlestickType == "Gravestone doji" && candle.IsGravestoneDoji()) isMatch = true;

                // If the candlestick type matches, add an annotation
                if (isMatch)
                {
                    // Create an ArrowAnnotation pointing at the candlestick's position
                    var arrow = new ArrowAnnotation
                    {
                        AnchorDataPoint = chart_stockData.Series[0].Points[i],

                        // Set the arrow size and color
                        ArrowSize = 3,
                        LineColor = System.Drawing.Color.DodgerBlue,
                        LineWidth = 2,

                        // Set the arrow direction to point upwards
                        Height = -3.0, // Points upwards from the low position
                        Width = 0,
                        Name = $"CandlestickTypeAnnotation_{candle.Date:yyyyMMdd}" // Use formatted date
                    };

                    // Add the annotation to the chart
                    chart_stockData.Annotations.Add(arrow);
                }
            }
        }
    }
}
