using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Project2
{
    public partial class Form_StockViewer : Form
    {
        // Member variables to store the candlesticks and filtered candlesticks
        private List<aCandlestick> originalCandlesticks; // Store original, unfiltered data
        private List<aCandlestick> filteredCandlesticks; // Filtered data based on date range
        private List<SmartCandlestick> smartCandlesticks; // Smart candlesticks for analysis
        private List<SmartCandlestick> peaksAndValleys;
	    private List<SmartCandlestick> selectedWave;
	    private int firstCandlestickIndex = -1;
        private int secondCandlestickIndex = -1;
        private bool isUpward = false;
        private bool isDownward = false;

        /// <summary>
        /// Constructor for the Form_StockViewer class
        /// </summary>
        public Form_StockViewer()
        {
            InitializeComponent();
            // Set the form title
            this.Text = "Form_StockViewer";

            // Setting up the height and width
            Height = 650;
            Width = 1330;
        }

        /// <summary>
        /// Method to load data into the form, called from the main form after file selection
        /// </summary>
        /// <param name="candlesticks">The candlestick data to load</param>
        public void LoadData(List<aCandlestick> candlesticks)
        {
            this.originalCandlesticks = new List<aCandlestick>(candlesticks); // Store original data for filtering
            this.filteredCandlesticks = new List<aCandlestick>(candlesticks); // Initialize with full dataset
            this.smartCandlesticks = new List<SmartCandlestick>(candlesticks.Select(c => new SmartCandlestick(c.Date, c.Open, c.High, c.Low, c.Close, c.Volume)));
            this.peaksAndValleys = findAllPeaksAndValleys.FindAllPeaksAndValleys(smartCandlesticks);
            

            // Initialize bindings for the Chart
            InitializeBindings();
        }

        /// <summary>
        /// Initializes the Chart bindings with the filtered data
        /// </summary>
        private void InitializeBindings()
        {
            // Set Y-axis range and bind to Chart
            aCandlestickNormalizer.SetYAxisRange(chart_stockData.ChartAreas[0], filteredCandlesticks);
            chart_stockData.DataSource = new BindingList<aCandlestick>(filteredCandlesticks);
        }

        // Event handler for displaying the open file dialog when the Load Data button is clicked
        private void button_loadData_Click(object sender, EventArgs e)
        {
            // Show the open file dialog
            openFileDialog_load.ShowDialog();
        }

        // Event Handler to update the data based on the date range specified by the user
        private void button_update_Click(object sender, EventArgs e)
        {
            // Get the date range from the DateTimePicker controls
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            // Filter originalCandlesticks based on the new selected date range
            filteredCandlesticks = aCandlestickFilter.FilterByDateRange(originalCandlesticks, startDate, endDate);

            // Rebind Chart with the new filtered data
            chart_stockData.DataSource = new BindingList<aCandlestick>(filteredCandlesticks);
            aCandlestickNormalizer.SetYAxisRange(chart_stockData.ChartAreas[0], filteredCandlesticks);
        }

        // Event handler to load the data from the selected file, then display the data based on the date range on the chart
        private void openFileDialog_load_FileOk(object sender, CancelEventArgs e)
        {
            // Get the selected file names
            string[] fileNames = openFileDialog_load.FileNames;

            // Get the date range from the DateTimePicker controls
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            // Loop through each selected file
            for (int i = 0; i < fileNames.Length; i++)
            {
                // Load the candlesticks from the file
                List<aCandlestick> candlesticks = aCandlestickLoader.LoadCandlesticksFromFile(fileNames[i]);

                // Apply initial filtering based on the selected date range
                List<aCandlestick> filteredCandlesticks = aCandlestickFilter.FilterByDateRange(candlesticks, startDate, endDate);

                // Display the first stock data in the main form
                if (i == 0)
                {
                    // Load the filtered data into the main form
                    this.Text = System.IO.Path.GetFileNameWithoutExtension(fileNames[i]);
                    this.LoadData(filteredCandlesticks); // Load filtered data directly into the main form
                }
                else
                {
                    // Create a new form for each additional stock data
                    Form_StockViewer newForm = new Form_StockViewer
                    {
                        // Set the title of the new form to the file name
                        Text = System.IO.Path.GetFileNameWithoutExtension(fileNames[i])
                    };

                    // Load filtered data into the new form
                    newForm.LoadData(filteredCandlesticks);

                    // Show the new form
                    newForm.Show();
                }
            }
        }

        // Event handler to display peaks on the chart
        private void button_viewPeaks_Click(object sender, EventArgs e)
        {
            addPeaks.AddPeaks(filteredCandlesticks, chart_stockData);
        }

        // Event handler to display valleys on the chart
        private void button_viewValleys_Click(object sender, EventArgs e)
        {
            addValleys.AddValleys(filteredCandlesticks, chart_stockData);
        }

        // Event handler to clear all annotations from the chart
        private void button_clearAnnotations_Click(object sender, EventArgs e)
        {
            // Clear all annotations from the chart
            chart_stockData.Annotations.Clear();
        }

        // Event handler that points arrow annontation to the candlestick type selected
        private void comboBox_candlestickType_SelectedIndexChanged(object sender, EventArgs e)
        {
            aCandlestickTypeChecker.candlestickType(smartCandlesticks, comboBox_candlestickType.Text, chart_stockData);
        }

        // Event handler to display the beauty instructions
        private void button_beautyInstructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "How to Calculate Beauty:\n\n" +
            "1. Use a single left-click to select the first candlestick, which must be a peak or valley.\n" +
            "2. Use another single left-click to select the second candlestick. Ensure it comes after the first candlestick.\n" +
            "3. Once a valid wave is selected, Fibonacci levels will be calculated automatically.\n" +
            "4. The Beauty of the wave will be computed based on the number of confirmations between " +
            "the candlestick OHLC values and Fibonacci levels.\n" +
            "Note: If the wave selection is invalid, you will be prompted to adjust your selection.",
            "How to Calculate Beauty", // Title of the message box
            MessageBoxButtons.OK,      // Buttons to display
            MessageBoxIcon.Information // Icon to display
            );
        }

        // Event handler to help compute the beauty of a selected wave
        private void chart_stockData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Perform a hit test to detect the clicked candlestick
                HitTestResult hit = chart_stockData.HitTest(e.X, e.Y);
                if (hit.ChartElementType == ChartElementType.DataPoint)
                {
                    int index = hit.PointIndex;

                    // If no candlestick is selected or the user is starting a new wave
                    if (firstCandlestickIndex == -1)
                    {
                        SmartCandlestick selectedCandle = smartCandlesticks[index];

                        // Check if the first candlestick is a peak or valley
                        if (selectedCandle.IsPeak || selectedCandle.IsValley)
                        {
                            firstCandlestickIndex = index;

                            // Annotate the first candlestick
                            TextAnnotation annotation = new TextAnnotation
                            {
                                Name = "StartAnnotation", // Assign a name for easy identification
                                Text = "Start",
                                AnchorDataPoint = chart_stockData.Series[0].Points[index],
                                ForeColor = System.Drawing.Color.Blue
                            };
                            chart_stockData.Annotations.Add(annotation);

                            MessageBox.Show("First candlestick selected! You can now pick the second candlestick.");
                        }
                        else
                        {
                            MessageBox.Show("The first candlestick must be a peak or valley.");
                        }
                    }
                    else if (secondCandlestickIndex == -1)
                    {
                        // Ensure the second candlestick comes after the first
                        if (index > firstCandlestickIndex)
                        {
                            secondCandlestickIndex = index;

                            // Annotate the second candlestick
                            TextAnnotation annotation = new TextAnnotation
                            {
                                Name = "EndAnnotation", // Assign a name for easy identification
                                Text = "End",
                                AnchorDataPoint = chart_stockData.Series[0].Points[index],
                                ForeColor = System.Drawing.Color.Blue
                            };
                            chart_stockData.Annotations.Add(annotation);

                            // Validate and highlight the wave
                            if (validateWave.ValidateWave(smartCandlesticks, firstCandlestickIndex, secondCandlestickIndex))
                            {
                                selectedWave = selectWaveCandlesticks.SelectWaveCandlesticks(smartCandlesticks, firstCandlestickIndex, secondCandlestickIndex);

                                bool isUpward = isUpwardWave.IsUpwardWave(smartCandlesticks, firstCandlestickIndex, secondCandlestickIndex);
                                bool isDownward = isDownwardWave.IsDownwardWave(smartCandlesticks, firstCandlestickIndex, secondCandlestickIndex);

                                // Calculate Fibonacci levels based on wave type
                                List<double> fibonacciLevels = calculateFibonacciLevels.CalculateFibonacciLevels(selectedWave, isUpward);
                                int beauty = calculateBeauty.CalculateBeauty(selectedWave, fibonacciLevels);
                                Dictionary<double, int> beautyByPercentage = calculateBeautyByPercentage.CalculateBeautyByPercentage(selectedWave, fibonacciLevels, isUpward);

                                drawBeautyChart.DrawBeautyBarChart(selectedWave, beauty, beautyByPercentage, isUpward, chart_stockData);
                                MessageBox.Show("Wave selected successfully! Click again to start a new wave.");
                                highlightWave.HighlightWave(smartCandlesticks, firstCandlestickIndex, secondCandlestickIndex, chart_stockData);
                            }
                            else
                            {
                                MessageBox.Show("Invalid wave selection. Please try again.");
                                clearWaveAnnotations.ClearWaveAnnotations(chart_stockData); // Clear if the wave is invalid
                                firstCandlestickIndex = -1;
                                secondCandlestickIndex = -1;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The second candlestick must come after the first.");
                        }
                    }
                    else
                    {
                        // If a wave is already selected, clear the previous annotations and start a new wave
                        clearWaveAnnotations.ClearWaveAnnotations(chart_stockData);
                        chart_stockData.ChartAreas[0].AxisY.StripLines.Clear();
                        chart_stockData.ChartAreas[0].AxisX.StripLines.Clear();
                        firstCandlestickIndex = -1;
                        secondCandlestickIndex = -1;
                    }
                }
            }
        }
    }
}
