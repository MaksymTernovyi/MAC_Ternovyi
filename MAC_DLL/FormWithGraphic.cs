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

namespace MAC_DLL
{
    public partial class FormWithGraphic : Form
    {
        public string filename;

        public FormWithGraphic()
        {
            InitializeComponent();
        }

        private FormWithGraphic((double x, double y)[] points, string title)
        {
            InitializeComponent();
            ChartWithGraphic.Series[0].Points.Clear();
            ChartWithGraphic.Series[1].Points.Clear();

            ChartWithGraphic.Titles[0].Text = title;
            ChartWithGraphic.ChartAreas[0].AxisX.Interval = 1;
            ChartWithGraphic.ChartAreas[0].AxisY.Interval = 1;

            var s1 = new Series()
            {
                ChartType = SeriesChartType.Spline,
                MarkerStyle = MarkerStyle.None,
                BorderWidth = 3,
                Color = Color.DarkBlue
            };
            var fMin = double.MaxValue;
            var fMax = double.MinValue;

            for (var i = 0; i < points.Length; i++)
            {
                s1.Points.AddXY(points[i].x, points[i].y);
                fMin = Math.Min(fMin, points[i].y);
                fMax = Math.Max(fMax, points[i].y);
            }

            ChartWithGraphic.Series[0] = s1;

            ChartWithGraphic.ChartAreas[0].AxisX.Minimum = Math.Floor(points.First().x);
            ChartWithGraphic.ChartAreas[0].AxisX.Maximum = Math.Ceiling(points.Last().x);
            ChartWithGraphic.ChartAreas[0].AxisY.Minimum = Math.Floor(fMin);
            ChartWithGraphic.ChartAreas[0].AxisY.Maximum = Math.Ceiling(fMax);

            ChartWithGraphic.Invalidate();
        }

        private FormWithGraphic(MyTable table)
        {
            InitializeComponent();
            ChartWithGraphic.Series[0].Points.Clear();
            ChartWithGraphic.Series[1].Points.Clear();

            ChartWithGraphic.Titles[0].Text = table.Title;
            ChartWithGraphic.ChartAreas[0].AxisX.Interval = 1;
            ChartWithGraphic.ChartAreas[0].AxisY.Interval = 1;
            
            var s1 = new Series()
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                BorderWidth = 3,
                Color = Color.DarkBlue
            };
            var fMin = double.MaxValue;
            var fMax = double.MinValue;
            
            for (var i = 0; i < table.Length; i++)
            {
                s1.Points.AddXY(table.X(i), table.F(i));
                fMin = Math.Min(fMin, table.F(i));
                fMax = Math.Max(fMax, table.F(i));
            }
            
            ChartWithGraphic.Series[0] = s1;
            
            ChartWithGraphic.ChartAreas[0].AxisX.Minimum = Math.Floor(table.X(0));
            ChartWithGraphic.ChartAreas[0].AxisX.Maximum = Math.Ceiling(table.X(-1));
            ChartWithGraphic.ChartAreas[0].AxisY.Minimum = Math.Floor(fMin);
            ChartWithGraphic.ChartAreas[0].AxisY.Maximum = Math.Ceiling(fMax);
        }

        public static void SingleGraphic((double, double)[] points, string title, int x, int y)
        {
            var singleGraphic = new FormWithGraphic(points, title)
            {
                filename = title,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(x, y)
            };

            singleGraphic.ShowDialog();
        }

        public static void SingleGraphic(MyTable table, int x, int y)
        {
            if (table == null) return;
            var graphic = new FormWithGraphic(table);
            graphic.filename = table.Title;
            graphic.StartPosition = FormStartPosition.Manual;
            graphic.Location = new Point(x, y);
            graphic.ShowDialog();
        }

        private void SaveGraph_Click(object sender, EventArgs e)
        {
            ChartWithGraphic.SaveImage(filename + ".png", ChartImageFormat.Png);
            SaveGraph.Enabled = false;
            Dispose();
        }
    }
}
