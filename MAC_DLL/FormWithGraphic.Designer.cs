namespace MAC_DLL
{
    partial class FormWithGraphic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWithGraphic));
            this.ChartWithGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SaveGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChartWithGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartWithGraphic
            // 
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.Format = "0.0";
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelStyle.Format = "0.0";
            chartArea1.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.Name = "ChartArea1";
            this.ChartWithGraphic.ChartAreas.Add(chartArea1);
            this.ChartWithGraphic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartWithGraphic.Location = new System.Drawing.Point(0, 0);
            this.ChartWithGraphic.Name = "ChartWithGraphic";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series2";
            this.ChartWithGraphic.Series.Add(series1);
            this.ChartWithGraphic.Series.Add(series2);
            this.ChartWithGraphic.Size = new System.Drawing.Size(674, 431);
            this.ChartWithGraphic.TabIndex = 0;
            this.ChartWithGraphic.Text = "chart1";
            title1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Графік функції, яку задано формулою";
            this.ChartWithGraphic.Titles.Add(title1);
            // 
            // SaveGraph
            // 
            this.SaveGraph.Image = global::MAC_DLL.Properties.Resources.saveHS;
            this.SaveGraph.Location = new System.Drawing.Point(630, 12);
            this.SaveGraph.Name = "SaveGraph";
            this.SaveGraph.Size = new System.Drawing.Size(32, 32);
            this.SaveGraph.TabIndex = 1;
            this.SaveGraph.UseVisualStyleBackColor = true;
            this.SaveGraph.Click += new System.EventHandler(this.SaveGraph_Click);
            // 
            // FormWithGraphic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 431);
            this.Controls.Add(this.SaveGraph);
            this.Controls.Add(this.ChartWithGraphic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWithGraphic";
            this.Text = "FormWithGraphic";
            ((System.ComponentModel.ISupportInitialize)(this.ChartWithGraphic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartWithGraphic;
        private System.Windows.Forms.Button SaveGraph;
    }
}