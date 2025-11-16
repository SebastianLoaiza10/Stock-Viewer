namespace Project2
{
    partial class Form_StockViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_loadData = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.label_startDate = new System.Windows.Forms.Label();
            this.label_endDate = new System.Windows.Forms.Label();
            this.openFileDialog_load = new System.Windows.Forms.OpenFileDialog();
            this.button_viewPeaks = new System.Windows.Forms.Button();
            this.button_viewValleys = new System.Windows.Forms.Button();
            this.comboBox_candlestickType = new System.Windows.Forms.ComboBox();
            this.label_candlestickType = new System.Windows.Forms.Label();
            this.button_clearAnnotations = new System.Windows.Forms.Button();
            this.button_beautyInstructions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stockData
            // 
            chartArea3.Name = "ChartArea_stockData";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 70F;
            chartArea3.Position.Width = 100F;
            chartArea4.Name = "ChartArea_beauty";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 30F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 70F;
            this.chart_stockData.ChartAreas.Add(chartArea3);
            this.chart_stockData.ChartAreas.Add(chartArea4);
            this.chart_stockData.Location = new System.Drawing.Point(12, 12);
            this.chart_stockData.Name = "chart_stockData";
            series2.ChartArea = "ChartArea_stockData";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series2.IsXValueIndexed = true;
            series2.Name = "Series_ohlc";
            series2.XValueMember = "Date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "High,Low,Open,Close";
            series2.YValuesPerPoint = 4;
            this.chart_stockData.Series.Add(series2);
            this.chart_stockData.Size = new System.Drawing.Size(2604, 867);
            this.chart_stockData.TabIndex = 0;
            this.chart_stockData.Text = "chart1";
            this.chart_stockData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart_stockData_MouseClick);
            // 
            // button_loadData
            // 
            this.button_loadData.Location = new System.Drawing.Point(904, 897);
            this.button_loadData.Name = "button_loadData";
            this.button_loadData.Size = new System.Drawing.Size(224, 90);
            this.button_loadData.TabIndex = 1;
            this.button_loadData.Text = "Load Stock(s)";
            this.button_loadData.UseVisualStyleBackColor = true;
            this.button_loadData.Click += new System.EventHandler(this.button_loadData_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(904, 1024);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(224, 90);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(119, 956);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(466, 31);
            this.dateTimePicker_startDate.TabIndex = 3;
            this.dateTimePicker_startDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(116, 1068);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(466, 31);
            this.dateTimePicker_endDate.TabIndex = 4;
            // 
            // label_startDate
            // 
            this.label_startDate.AutoSize = true;
            this.label_startDate.Location = new System.Drawing.Point(288, 917);
            this.label_startDate.Name = "label_startDate";
            this.label_startDate.Size = new System.Drawing.Size(114, 25);
            this.label_startDate.TabIndex = 5;
            this.label_startDate.Text = "Start Date:";
            // 
            // label_endDate
            // 
            this.label_endDate.AutoSize = true;
            this.label_endDate.Location = new System.Drawing.Point(288, 1030);
            this.label_endDate.Name = "label_endDate";
            this.label_endDate.Size = new System.Drawing.Size(107, 25);
            this.label_endDate.TabIndex = 6;
            this.label_endDate.Text = "End Date:";
            // 
            // openFileDialog_load
            // 
            this.openFileDialog_load.FileName = "IBM-Month";
            this.openFileDialog_load.Filter = "All Stocks|*.csv|Monthly|*-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv";
            this.openFileDialog_load.InitialDirectory = "C:\\Users\\sebas\\Desktop\\School\\Fall 2024\\Software Systems Development\\Stock Data";
            this.openFileDialog_load.Multiselect = true;
            this.openFileDialog_load.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_load_FileOk);
            // 
            // button_viewPeaks
            // 
            this.button_viewPeaks.Location = new System.Drawing.Point(1176, 897);
            this.button_viewPeaks.Name = "button_viewPeaks";
            this.button_viewPeaks.Size = new System.Drawing.Size(224, 90);
            this.button_viewPeaks.TabIndex = 7;
            this.button_viewPeaks.Text = "View Peaks";
            this.button_viewPeaks.UseVisualStyleBackColor = true;
            this.button_viewPeaks.Click += new System.EventHandler(this.button_viewPeaks_Click);
            // 
            // button_viewValleys
            // 
            this.button_viewValleys.Location = new System.Drawing.Point(1176, 1030);
            this.button_viewValleys.Name = "button_viewValleys";
            this.button_viewValleys.Size = new System.Drawing.Size(224, 90);
            this.button_viewValleys.TabIndex = 8;
            this.button_viewValleys.Text = "View Valleys";
            this.button_viewValleys.UseVisualStyleBackColor = true;
            this.button_viewValleys.Click += new System.EventHandler(this.button_viewValleys_Click);
            // 
            // comboBox_candlestickType
            // 
            this.comboBox_candlestickType.FormattingEnabled = true;
            this.comboBox_candlestickType.Items.AddRange(new object[] {
            "Bullish",
            "Bearish",
            "Neutral",
            "Marubozu",
            "Hammer",
            "Doji",
            "Dragonfly doji",
            "Gravestone doji"});
            this.comboBox_candlestickType.Location = new System.Drawing.Point(2016, 1024);
            this.comboBox_candlestickType.Name = "comboBox_candlestickType";
            this.comboBox_candlestickType.Size = new System.Drawing.Size(321, 33);
            this.comboBox_candlestickType.TabIndex = 9;
            this.comboBox_candlestickType.SelectedIndexChanged += new System.EventHandler(this.comboBox_candlestickType_SelectedIndexChanged);
            // 
            // label_candlestickType
            // 
            this.label_candlestickType.AutoSize = true;
            this.label_candlestickType.Location = new System.Drawing.Point(2034, 996);
            this.label_candlestickType.Name = "label_candlestickType";
            this.label_candlestickType.Size = new System.Drawing.Size(264, 25);
            this.label_candlestickType.TabIndex = 10;
            this.label_candlestickType.Text = "Choose Candlestick Type:";
            // 
            // button_clearAnnotations
            // 
            this.button_clearAnnotations.Location = new System.Drawing.Point(1457, 897);
            this.button_clearAnnotations.Name = "button_clearAnnotations";
            this.button_clearAnnotations.Size = new System.Drawing.Size(224, 90);
            this.button_clearAnnotations.TabIndex = 11;
            this.button_clearAnnotations.Text = "Clear Lines and Arrows";
            this.button_clearAnnotations.UseVisualStyleBackColor = true;
            this.button_clearAnnotations.Click += new System.EventHandler(this.button_clearAnnotations_Click);
            // 
            // button_beautyInstructions
            // 
            this.button_beautyInstructions.Location = new System.Drawing.Point(1457, 1030);
            this.button_beautyInstructions.Name = "button_beautyInstructions";
            this.button_beautyInstructions.Size = new System.Drawing.Size(224, 90);
            this.button_beautyInstructions.TabIndex = 12;
            this.button_beautyInstructions.Text = "Calculate Beauty Instructions";
            this.button_beautyInstructions.UseVisualStyleBackColor = true;
            this.button_beautyInstructions.Click += new System.EventHandler(this.button_beautyInstructions_Click);
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2628, 1146);
            this.Controls.Add(this.button_beautyInstructions);
            this.Controls.Add(this.button_clearAnnotations);
            this.Controls.Add(this.label_candlestickType);
            this.Controls.Add(this.comboBox_candlestickType);
            this.Controls.Add(this.button_viewValleys);
            this.Controls.Add(this.button_viewPeaks);
            this.Controls.Add(this.label_endDate);
            this.Controls.Add(this.label_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_loadData);
            this.Controls.Add(this.chart_stockData);
            this.Name = "Form_StockViewer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
        private System.Windows.Forms.Button button_loadData;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label label_startDate;
        private System.Windows.Forms.Label label_endDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog_load;
        private System.Windows.Forms.Button button_viewPeaks;
        private System.Windows.Forms.Button button_viewValleys;
        private System.Windows.Forms.ComboBox comboBox_candlestickType;
        private System.Windows.Forms.Label label_candlestickType;
        private System.Windows.Forms.Button button_clearAnnotations;
        private System.Windows.Forms.Button button_beautyInstructions;
    }
}

