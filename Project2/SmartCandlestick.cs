using Project2;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Drawing;

namespace Project2
{
    public class SmartCandlestick : aCandlestick
    {
        // Properties for candlestick ranges and prices
        public decimal Range => High - Low;
        public decimal BodyRange => Math.Abs(Close - Open);
        public decimal TopPrice => Math.Max(Open, Close);
        public decimal BottomPrice => Math.Min(Open, Close);
        public decimal UpperTail => High - TopPrice;
        public decimal LowerTail => BottomPrice - Low;

        public bool IsPeak;
        public bool IsValley;
        public int Index;

        // Constructor to initialize SmartCandlestick using aCandlestick properties
        public SmartCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, ulong volume)
            : base(date, open, high, low, close, volume)
        {
        }

        // Methods to determine the candlestick pattern
        public bool IsBullish() => Close > Open;
        public bool IsBearish() => Close < Open;
        public bool IsNeutral() => Close == Open;
        public bool IsMarubozu() => Open == Low && Close == High || Open == High && Close == Low;
        public bool IsHammer() => BodyRange < (Range * 0.3m) && LowerTail > (Range * 0.5m) && UpperTail < (Range * 0.1m);
        public bool IsDoji() => BodyRange < (Range * 0.05m);
        public bool IsDragonflyDoji() => IsDoji() && LowerTail > (Range * 0.7m) && UpperTail < (Range * 0.1m);
        public bool IsGravestoneDoji() => IsDoji() && UpperTail > (Range * 0.7m) && LowerTail < (Range * 0.1m);
    }
}
