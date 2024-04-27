namespace KMeansClustering
{
    partial class fMain
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.tbC = new System.Windows.Forms.TextBox();
            this.btnSetData = new System.Windows.Forms.Button();
            this.tbOut = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // cbMethod
            // 
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbMethod.Location = new System.Drawing.Point(12, 89);
            this.cbMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(244, 23);
            this.cbMethod.TabIndex = 0;
            // 
            // chart
            // 
            chartArea3.AxisX.Title = "PetalLength";
            chartArea3.AxisY.Title = "PetalWidth";
            chartArea3.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(264, 6);
            this.chart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart.Name = "chart";
            series5.ChartArea = "ChartArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Legend = "Legend1";
            series5.Name = "Data";
            series6.ChartArea = "ChartArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Legend = "Legend1";
            series6.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series6.MarkerSize = 8;
            series6.Name = "Centroids";
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Size = new System.Drawing.Size(700, 582);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Кількість центроїдів C";
            // 
            // tbC
            // 
            this.tbC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbC.Location = new System.Drawing.Point(179, 59);
            this.tbC.Margin = new System.Windows.Forms.Padding(4);
            this.tbC.Name = "tbC";
            this.tbC.Size = new System.Drawing.Size(77, 22);
            this.tbC.TabIndex = 3;
            this.tbC.Text = "2";
            // 
            // btnSetData
            // 
            this.btnSetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSetData.Location = new System.Drawing.Point(12, 6);
            this.btnSetData.Name = "btnSetData";
            this.btnSetData.Size = new System.Drawing.Size(244, 37);
            this.btnSetData.TabIndex = 4;
            this.btnSetData.Text = "Налаштувати дані";
            this.btnSetData.UseVisualStyleBackColor = true;
            this.btnSetData.Click += new System.EventHandler(this.btnSetData_Click);
            // 
            // tbOut
            // 
            this.tbOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.tbOut.Location = new System.Drawing.Point(12, 165);
            this.tbOut.Multiline = true;
            this.tbOut.Name = "tbOut";
            this.tbOut.ReadOnly = true;
            this.tbOut.Size = new System.Drawing.Size(244, 423);
            this.tbOut.TabIndex = 5;
            this.tbOut.Text = "Поле виведення";
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSolve.Location = new System.Drawing.Point(12, 119);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(244, 40);
            this.btnSolve.TabIndex = 6;
            this.btnSolve.Text = "Кластеризувати";
            this.btnSolve.UseVisualStyleBackColor = true;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 601);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.tbOut);
            this.Controls.Add(this.btnSetData);
            this.Controls.Add(this.tbC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.cbMethod);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fMain";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbC;
        private System.Windows.Forms.Button btnSetData;
        private System.Windows.Forms.TextBox tbOut;
        private System.Windows.Forms.Button btnSolve;
    }
}

