using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using Project2;

namespace Project2
{
    public static class aCandlestickLoader
    {
        /// <summary>
        /// This method loads candlestick data from a CSV file and returns a list of candlesticks.
        /// We create a list of candlesticks to store the candlesticks. Then, we skip the header line and process to read each line in the file.
        /// After using our separators to split the lines, we parse each value and input into a new Candlestick object and add it the list of candlesticks.
        /// After that process is completed we check to see the order of the list and handle it accordingly
        /// </summary>
        /// <param name="filePath">A string that contains the stock data file path</param>
        /// <returns>Returns a list of candlesticks from the stock data file</returns>
        public static List<aCandlestick> LoadCandlesticksFromFile(string filePath)
        {
            // Making an array called separators to handle the different types of separators in the CSV file
            char[] separators = { ',', '\"' };

            // Creating a list of candlesticks to store the candlesticks
            List<aCandlestick> candlesticks = new List<aCandlestick>();

            try
            {
                // Using StreamReader to read the data from filePath
                using (StreamReader stockData = new StreamReader(filePath))
                {
                    // Reading in the headerline to skip it
                    string headerLine = stockData.ReadLine();

                    // Makes a string variable called line to hold the current line being read
                    string line;

                    // Utilizing a while loop to read each line in the file
                    while ((line = stockData.ReadLine()) != null)
                    {
                        // Splitting the line into an array of values using the separators while also removing empty entries
                        string[] values = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        // Checking if the values array has 6 elements
                        if (values.Length == 6)
                        {
                            // Parsing each value
                            DateTime date = DateTime.ParseExact(values[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            decimal open = Math.Round(100 * decimal.Parse(values[1], CultureInfo.InvariantCulture)) / 100;
                            decimal high = Math.Round(100 * decimal.Parse(values[2], CultureInfo.InvariantCulture)) / 100;
                            decimal low = Math.Round(100 * decimal.Parse(values[3], CultureInfo.InvariantCulture)) / 100;
                            decimal close = Math.Round(100 * decimal.Parse(values[4], CultureInfo.InvariantCulture)) / 100;
                            ulong volume = ulong.Parse(values[5], CultureInfo.InvariantCulture);

                            // Create a new Candlestick object
                            aCandlestick candlestick = new aCandlestick(date, open, high, low, close, volume);

                            // Add the candlestick to the candlesticks list
                            candlesticks.Add(candlestick);
                        }
                    }

                    // Getting the first and last date in the list to check the order
                    DateTime firstDate = candlesticks[0].Date;
                    DateTime lastDate = candlesticks[candlesticks.Count - 1].Date;

                    // If the first date is after the last date, the list is in reverse order
                    if (firstDate > lastDate)
                    {
                        // Reverse the list to correct the order
                        candlesticks.Reverse();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handles exceptions such as the file not being found, incorrect format, etc.
                Console.WriteLine("Error loading CSV file: " + ex.Message);
            }

            // Returning the list of candlesticks
            return candlesticks;
        }
    }
}
