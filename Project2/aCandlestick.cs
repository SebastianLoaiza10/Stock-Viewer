using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Project2
{
    public class aCandlestick
    {
        // Properties to represent the open, high, low, close prices, and volume
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public ulong Volume { get; set; }

        // Constructor to initialize the candlestick with values
        public aCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume)
        {
            // Initialize the properties with the provided values
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

    }
}
