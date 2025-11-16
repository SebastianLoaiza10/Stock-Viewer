using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public static class clearWaveAnnotations
    {
        /// <summary>
        /// The purpose of this method is to clear the wave annotations from the chart
        /// We iterate through the annotations in reverse to safely remove them. We check if the annotation name matches any of the wave-related annotations.
        /// If the annotation name matches, we remove the annotation from the chart.
        /// </summary>
        /// <param name="chart_stockData">The chart that we want to remove the wave annotations from</param>
        public static void ClearWaveAnnotations(Chart chart_stockData)
        {
            // Iterate through the annotations in reverse to safely remove them
            for (int i = chart_stockData.Annotations.Count - 1; i >= 0; i--)
            {
                // Retrieve the current annotation
                var annotation = chart_stockData.Annotations[i];

                // Check if the annotation name matches any of the wave-related annotations
                if (annotation.Name == "StartAnnotation" || annotation.Name == "EndAnnotation" || annotation.Name == "WaveRectangle")
                {
                    // Remove the matching annotation from the chart
                    chart_stockData.Annotations.RemoveAt(i);
                }
            }
        }

    }
}
