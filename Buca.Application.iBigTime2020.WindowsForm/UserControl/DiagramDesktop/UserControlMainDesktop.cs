using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.View.System;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using Buca.Application.iBigTime2020.Model.BusinessObjects.System;
using Buca.Application.iBigTime2020.Presenter.System.UserProfile;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.UserControl.DiagramDesktop
{
    public partial class UserControlMainDesktop : XtraUserControl, IUserControlMainDesktopView, IDashBoardBudgetView, IDashBoardCashView, IDashBoardActivityView
    {
        private readonly UserControlMainDesktopPresenter _usercontrolmaindesktop;
        private readonly DashBoardBudgetPresenter _dashBoardBudget;
        private readonly DashBoardCashPresenter _dashBoardCash;
        private readonly DashBoardActivityPresenter _dashBoardActivity;
        private int CurentPostedDate = Convert.ToDateTime(GlobalVariable.PostedDate).Year - (int)DateTime.Now.Year;
        public int EstimateCurentYear = Convert.ToDateTime(GlobalVariable.PostedDate).Year - (int)DateTime.Now.Year;
        public int ExpenseCurentYear = Convert.ToDateTime(GlobalVariable.PostedDate).Year - (int)DateTime.Now.Year;
        public int CashCurentMonth = 0;
        public int CashCurentMonthYear = Convert.ToDateTime(GlobalVariable.PostedDate).Year - (int)DateTime.Now.Year;
        public int ActivityCurentYear = Convert.ToDateTime(GlobalVariable.PostedDate).Year - (int)DateTime.Now.Year;
        private int CashMonth, CashYear;
        private ChartControl EstimateChart = new ChartControl();
        private ChartControl ExpenseChart = new ChartControl();
        private ChartControl CashChart = new ChartControl();
        private ChartControl ActivityChart = new ChartControl();
        private DateTime PostedDate = Convert.ToDateTime(GlobalVariable.PostedDate);
        public UserControlMainDesktop()
        {
            InitializeComponent();
            _usercontrolmaindesktop = new UserControlMainDesktopPresenter(this);
            _dashBoardBudget = new DashBoardBudgetPresenter(this);
            _dashBoardCash = new DashBoardCashPresenter(this);
            _dashBoardActivity = new DashBoardActivityPresenter(this);
            _usercontrolmaindesktop.Display(CurentPostedDate);
            _dashBoardBudget.Display(CurentPostedDate);
            _dashBoardCash.Display(0, CurentPostedDate);
            _dashBoardActivity.Display(CurentPostedDate);
        }

        public IList<UserControlMainDesktopModel> UserControlMainDesktop1
        {
            set
            {
                AddFirstChart(value);
            }
        }
        public IList<DashBoardBudgetModel> DashBoardBudget
        {
            set
            {
                AddSecondChart(value);
            }
        }

        public IList<DashBoardCashModel> DashBoardCash
        {
            set
            {
                AddSixthChart(value);
            }
        }
        public IList<DashBoardAcitityModel> DashBoardAcitity
        {
            set
            {
                AddSeventhChart(value);
            }
        }
        private void UserControlMainDesktop_Load(object sender, EventArgs e)
        {
            //AddFirstChart();
            //AddSecondChart();
            //AddThirdChart();
            //AddFourthChart();
            //AddFifthChart();
            //AddSixthChart();
            //AddSeventhChart();
            labelControl1.Focus();
        }
        private DataTable CreateChartData(int rowCount)
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add two columns to the table.
            table.Columns.Add("RefTypeName", typeof(string));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            Random rnd = new Random();
            DataRow row = null;
            for (int i = 0; i < rowCount; i++)
            {
                row = table.NewRow();
                row["RefTypeName"] = "Chứng từ" + i;
                row["Value"] = rnd.Next(100);
                table.Rows.Add(row);
            }

            return table;
        }

        private void AddFirstChart(IList<UserControlMainDesktopModel> UserControlMainDesktop1)
        {
            // Create a new chart.
            if (!EstimateChart.Series.Equals(null) || UserControlMainDesktop1.Count <= 0)
            {
                EstimateChart.Series.Clear();
                lblEstimateYear.Text = "NĂM " + ((int)DateTime.Now.Year + EstimateCurentYear).ToString() + ". Không có dữ liệu";
            }
            if (UserControlMainDesktop1.Count >= 1)
            {
                NodataChar1.Visible = false;
                lblEstimateYear.Text = "NĂM " + ((int)DateTime.Now.Year + EstimateCurentYear).ToString();
                // Create two stacked bar series.
                Series series1 = new Series("Dự toán bị hủy", ViewType.StackedBar);
                Series series2 = new Series("Dự toán còn lại", ViewType.StackedBar);
                Series series3 = new Series("Rút dự toán", ViewType.StackedBar);
                // Add points to them
                for (int i = 0; i < UserControlMainDesktop1.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint("Nguồn: " + UserControlMainDesktop1[i].BudgetSourceCode,

                            UserControlMainDesktop1[i].Cancel));
                    series2.Points.Add(new SeriesPoint("Nguồn: " + UserControlMainDesktop1[i].BudgetSourceCode,

                            UserControlMainDesktop1[i].Remaining));
                    series3.Points.Add(new SeriesPoint("Nguồn: " + UserControlMainDesktop1[i].BudgetSourceCode,

                            UserControlMainDesktop1[i].WithDraw));
                    //Tùy chỉnh nhãn khi hover chuột
                    //series1.CrosshairLabelPattern = "Dự toán bị hủy: " + UserControlMainDesktop1[i].Cancel;
                    //series2.CrosshairLabelPattern = "Dự toán còn lại: " + UserControlMainDesktop1[i].Remaining;
                    //series3.CrosshairLabelPattern = "Rút dự toán: " + UserControlMainDesktop1[i].WithDraw;
                }
                // Add both series to the chart.
                EstimateChart.Series.AddRange(new Series[] { series1, series2, series3 });

                BarSeriesView view = (BarSeriesView)series1.View;
                view.FillStyle.FillMode = FillMode.Empty;
                SideBySideBarSeriesLabel label = EstimateChart.Series[0].Label as SideBySideBarSeriesLabel;

                ((StackedBarSeriesView)EstimateChart.Series[0].View).Color = Color.FromArgb(0, 237, 224);
                ((StackedBarSeriesView)EstimateChart.Series[0].View).FillStyle.FillMode = FillMode.Solid;
                ((StackedBarSeriesView)EstimateChart.Series[1].View).Color = Color.FromArgb(255, 145, 0);
                ((StackedBarSeriesView)EstimateChart.Series[1].View).FillStyle.FillMode = FillMode.Solid;
                ((StackedBarSeriesView)EstimateChart.Series[2].View).Color = Color.FromArgb(0, 106, 253);
                ((StackedBarSeriesView)EstimateChart.Series[2].View).FillStyle.FillMode = FillMode.Solid;

                //stackedBarChart.ToolTipEnabled = DefaultBoolean.True;
                //stackedBarChart.CrosshairEnabled = DefaultBoolean.False;
                //stackedBarChart.Series[0].ToolTipSeriesPattern = "fdasfasdfasdfasd";
                //// Access the view-type-specific options of the series.
                //((StackedBarSeriesView)series1.View).BarWidth = 1;

                // Access the type-specific options of the diagram.
                ((XYDiagram)EstimateChart.Diagram).EnableAxisXZooming = false;

                // Hide the legend (if necessary).
                EstimateChart.Legend.Visible = true;

                //// Add a title to the chart (if necessary).
                //EstimateChart.Titles.Clear();
                //EstimateChart.Titles.Add(new ChartTitle());
                //EstimateChart.Titles[0].Text = "NĂM: " + ((int)DateTime.Now.Year + EstimateCurentYear).ToString();
                //EstimateChart.Location = new Point(40, 70);
                //EstimateChart.Location = new Point(PanelControlEstimate.Location.X + 3, PanelControlEstimate.Location.Y + 40);

                //EstimateChart.Size = new Size(548, 289);

                //Convert label bên trái sang định dạng mong muốn
                EstimateChart.CustomDrawAxisLabel += (s, e) =>
                {
                    var args = (CustomDrawAxisLabelEventArgs)e;
                    AxisBase axis = args.Item.Axis;
                    if (axis is AxisY)
                    {
                        double axisValue = (double)args.Item.AxisValue;
                        //TimeSpan t = TimeSpan.FromSeconds(axisValue);

                        string answer = string.Format("{0:0,0}",
                            axisValue);
                        args.Item.Text = answer;
                    }
                };


                // Add the chart to the form.
                EstimateChart.Dock = DockStyle.Fill;
                PanelControlEstimateSub.Controls.Add(EstimateChart);
                //EstimateChart.BringToFront();
            }
            else
            {
                NodataChar1.Visible = true;
            }
        }

        private void AddSecondChart(IList<DashBoardBudgetModel> DashBoardBudget)
        {

            if (!ExpenseChart.Series.Equals(null) || DashBoardBudget.Count <= 0)
            {
                ExpenseChart.Series.Clear();
                labelControl8.Text = "NĂM " + ((int)DateTime.Now.Year + ExpenseCurentYear).ToString() + ". Không có dữ liệu";
            }
            if (DashBoardBudget.Count >= 1)
            {
                NodataChar2.Visible = false;
                labelControl8.Text = "NĂM " + ((int)DateTime.Now.Year + ExpenseCurentYear).ToString();
                // Create two stacked bar series.
                Series series1 = new Series("Kinh phí chi", ViewType.StackedBar);
                Series series2 = new Series("Kinh phí còn lại", ViewType.StackedBar);
                Series series3 = new Series("Kinh phí nhận", ViewType.StackedBar);
                // Add points to them
                for (int i = 0; i < DashBoardBudget.Count; i++)
                {
                    series1.Points.Add(new SeriesPoint("Nguồn: " + DashBoardBudget[i].BudgetSourceCode,
                        DashBoardBudget[i].BudgetGive));
                    series2.Points.Add(new SeriesPoint("Nguồn: " + DashBoardBudget[i].BudgetSourceCode,
                       DashBoardBudget[i].Remaining));
                    series3.Points.Add(new SeriesPoint("Nguồn: " + DashBoardBudget[i].BudgetSourceCode,
                        DashBoardBudget[i].BudgetRecive));
                    //Tùy chỉnh nhãn khi hover chuột
                    //series1.CrosshairLabelPattern = "Kinh phí nhận: " + DashBoardBudget[i].BudgetGive;
                    //series2.CrosshairLabelPattern = "Kinh phí còn lại: " + DashBoardBudget[i].Remaining;
                    //series3.CrosshairLabelPattern = "Kinh phí chi: " + DashBoardBudget[i].BudgetRecive;
                }
                // Add both series to the chart.
                ExpenseChart.Series.AddRange(new Series[] { series1, series2, series3 });

                BarSeriesView view = (BarSeriesView)series1.View;
                view.FillStyle.FillMode = FillMode.Empty;
                SideBySideBarSeriesLabel label = ExpenseChart.Series[0].Label as SideBySideBarSeriesLabel;

                ((StackedBarSeriesView)ExpenseChart.Series[0].View).Color = Color.FromArgb(0, 237, 224);
                ((StackedBarSeriesView)ExpenseChart.Series[0].View).FillStyle.FillMode = FillMode.Solid;
                ((StackedBarSeriesView)ExpenseChart.Series[1].View).Color = Color.FromArgb(255, 145, 0);
                ((StackedBarSeriesView)ExpenseChart.Series[1].View).FillStyle.FillMode = FillMode.Solid;
                ((StackedBarSeriesView)ExpenseChart.Series[2].View).Color = Color.FromArgb(0, 106, 253);
                ((StackedBarSeriesView)ExpenseChart.Series[2].View).FillStyle.FillMode = FillMode.Solid;

                //stackedBarChart.ToolTipEnabled = DefaultBoolean.True;
                //stackedBarChart.CrosshairEnabled = DefaultBoolean.False;
                //stackedBarChart.Series[0].ToolTipSeriesPattern = "fdasfasdfasdfasd";
                //// Access the view-type-specific options of the series.
                //((StackedBarSeriesView)series1.View).BarWidth = 1;

                // Access the type-specific options of the diagram.
                ((XYDiagram)ExpenseChart.Diagram).EnableAxisXZooming = false;

                // Hide the legend (if necessary).
                ExpenseChart.Legend.Visible = true;


                //Convert label bên trái sang định dạng mong muốn
                ExpenseChart.CustomDrawAxisLabel += (s, e) =>
                {
                    var args = (CustomDrawAxisLabelEventArgs)e;
                    AxisBase axis = args.Item.Axis;
                    if (axis is AxisY)
                    {
                        double axisValue = (double)args.Item.AxisValue;
                        TimeSpan t = TimeSpan.FromSeconds(axisValue);

                        string answer = string.Format("{0:0,0}",
                            axisValue);
                        args.Item.Text = answer;
                    }
                };


                // Add the chart to the form.
                ExpenseChart.Dock = DockStyle.Fill;
                PanelControlExpenseSub.Controls.Add(ExpenseChart);
                //ExpenseChart.BringToFront();
            }
            else
            {
                NodataChar2.Visible = true;
            }

        }

        private void AddThirdChart()
        {
            // Create a chart.
            ChartControl chart = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chart.Series.Add(series);
            chart.Location = new Point(40, 498);
            chart.Size = new Size(356, 236);

            // Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(3);

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Auto;
            series.ArgumentDataMember = "RefTypeName";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visible = true;
            chart.Legend.Visible = true;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.None;
            this.Controls.Add(chart);
            chart.BringToFront();
        }

        private void AddFourthChart()
        {
            // Create a chart.
            ChartControl chart = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chart.Series.Add(series);
            chart.Location = new Point(430, 498);
            chart.Size = new Size(356, 236);

            // Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(3);

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Auto;
            series.ArgumentDataMember = "RefTypeName";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visible = true;
            chart.Legend.Visible = true;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.None;
            this.Controls.Add(chart);
            chart.BringToFront();
        }

        private void AddFifthChart()
        {
            // Create a chart.
            ChartControl chart = new ChartControl();

            // Create an empty Bar series and add it to the chart.
            Series series = new Series("Series1", ViewType.Bar);
            chart.Series.Add(series);
            chart.Location = new Point(820, 498);
            chart.Size = new Size(356, 236);

            // Generate a data table and bind the series to it.
            series.DataSource = CreateChartData(3);

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Auto;
            series.ArgumentDataMember = "RefTypeName";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            // Set some properties to get a nice-looking chart.
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chart.Diagram).AxisY.Visible = true;
            chart.Legend.Visible = true;

            // Dock the chart into its parent and add it to the current form.
            chart.Dock = DockStyle.None;
            this.Controls.Add(chart);
            chart.BringToFront();
        }

        private void AddSixthChart(IList<DashBoardCashModel> DashBoardCash)
        {
            if (DashBoardCash.Count > 0)
                NodataChar3.Visible = false;
            else
            {
                NodataChar3.Visible = true;

            }
            lblCashYear.Text = "NĂM " + DashBoardCash[0].ThisTime.Year.ToString();
            CashMonth = DashBoardCash[0].PrevTime.Month;
            CashYear = DashBoardCash[0].PrevTime.Year;
            // Create a new chart.
            //CashChart = new ChartControl();
            if (!CashChart.Series.Equals(null) || DashBoardCash.Count <= 0)
            {
                CashChart.Series.Clear();
            }
            // Create two full-stacked line series.
            Series series1 = new Series("Tiền mặt", ViewType.Line);
            Series series2 = new Series("Tiền gửi", ViewType.Line);
            Series series3 = new Series("Tiền đang chuyển", ViewType.Line);



            // Add points to them.            
            series1.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].PrevTime.Month, DashBoardCash[0].PrevCash));
            series1.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].ThisTime.Month, DashBoardCash[0].ThisCash));
            series1.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].NextTime.Month, DashBoardCash[0].NextCash));

            series2.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].PrevTime.Month, DashBoardCash[0].PrevCashInBank));
            series2.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].ThisTime.Month, DashBoardCash[0].ThisCashInBank));
            series2.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].NextTime.Month, DashBoardCash[0].NextCashInBank));

            series3.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].PrevTime.Month, DashBoardCash[0].PrevCashInTransit));
            series3.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].ThisTime.Month, DashBoardCash[0].ThisCashInTransit));
            series3.Points.Add(new SeriesPoint("Tháng " + DashBoardCash[0].NextTime.Month, DashBoardCash[0].NextCashInTransit));

            //CashChart.Location = new Point(40, 873);
            //CashChart.Size = new Size(548, 289);

            // Add both series to the chart.
            CashChart.Series.AddRange(new Series[] { series1, series2, series3 });

            ((LineSeriesView)CashChart.Series[0].View).Color = Color.FromArgb(0, 106, 253);
            ((LineSeriesView)CashChart.Series[1].View).Color = Color.FromArgb(255, 145, 0);
            ((LineSeriesView)CashChart.Series[2].View).Color = Color.FromArgb(0, 237, 224);

            ((LineSeriesView)CashChart.Series[0].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)CashChart.Series[1].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            ((LineSeriesView)CashChart.Series[2].View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Access the type-specific options of the diagram.
            ((XYDiagram)CashChart.Diagram).EnableAxisXZooming = false;
            //((XYDiagram)CashChart.Diagram).AxisY.Label.TextPattern = "{VP:P0}";

            // Hide the legend (if necessary).
            CashChart.Legend.Visible = true;

            //// Add a title to the chart (if necessary).
            //CashChart.Titles.Add(new ChartTitle());
            //CashChart.Titles[0].Text = "Full Stacked Line Chart";

            // Convert label bên trái sang định dạng mong muốn
            CashChart.CustomDrawAxisLabel += (s, e) =>
            {
                var args = (CustomDrawAxisLabelEventArgs)e;
                AxisBase axis = args.Item.Axis;
                if (axis is AxisY)
                {
                    double axisValue = (double)args.Item.AxisValue;
                    string answer = string.Format("{0:0,0}",
                        axisValue);
                    args.Item.Text = answer;
                }
            };

            // Add the chart to the form.
            CashChart.Dock = DockStyle.Fill;
            PanelControlCashSub.Controls.Add(CashChart);
            CashChart.BringToFront();
        }

        private void AddSeventhChart(IList<DashBoardAcitityModel> DashBoardAcitity)
        {
            lblActivityYear.Text = "NĂM " + ((int)DateTime.Now.Year + ActivityCurentYear).ToString();
            // Create a chart.
            //ActivityChart = new ChartControl();// Create a new chart.
            if (!ActivityChart.Series.Equals(null) || DashBoardAcitity.Count <= 0)
            {
                ActivityChart.Series.Clear();
            }
            for (int i = 0; i < DashBoardAcitity.Count; i++)
            {
                if (DashBoardAcitity[i].Revenue != 0 || DashBoardAcitity[i].Revenue != 0)
                {
                    NodataChar4.Visible = false;
                    break;
                }
                NodataChar4.Visible = true;
                NodataChar4.BringToFront();
                break;
            }
            // Create an empty Bar series and add it to the chart.
            Series series1 = new Series("Doanh thu", ViewType.Bar);
            Series series2 = new Series("Chi phí", ViewType.Bar);
            Series series3 = new Series("Chênh lệch thu chi", ViewType.Bar);

            ActivityChart.Series.AddRange(new Series[] { series1, series2, series3 });

            //ActivityChart.Location = new Point(631, 873);
            //ActivityChart.Size = new Size(548, 289);

            // Add points to them.
            for (int i = 0; i < DashBoardAcitity.Count; i++)
            {
                series1.Points.Add(new SeriesPoint("Quý " + DashBoardAcitity[i].Time.ToString(), DashBoardAcitity[i].Revenue));
                series2.Points.Add(new SeriesPoint("Quý " + DashBoardAcitity[i].Time.ToString(), DashBoardAcitity[i].Expense));
                series3.Points.Add(new SeriesPoint("Quý " + DashBoardAcitity[i].Time.ToString(), DashBoardAcitity[i].Differences));
            }

            ((BarSeriesView)ActivityChart.Series[0].View).Color = Color.FromArgb(0, 106, 253);
            ((BarSeriesView)ActivityChart.Series[1].View).Color = Color.FromArgb(0, 237, 224);
            ((BarSeriesView)ActivityChart.Series[2].View).Color = Color.FromArgb(255, 145, 0);
            ((BarSeriesView)ActivityChart.Series[0].View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)ActivityChart.Series[1].View).FillStyle.FillMode = FillMode.Solid;
            ((BarSeriesView)ActivityChart.Series[2].View).FillStyle.FillMode = FillMode.Solid;

            //// Set some properties to get a nice-looking chart.
            //((SideBySideBarSeriesView)series1.View).ColorEach = true;
            ((XYDiagram)ActivityChart.Diagram).AxisY.Visible = true;
            ((XYDiagram)ActivityChart.Diagram).Rotated = true;
            ActivityChart.Legend.Visible = true;

            // Convert label bên trái sang định dạng mong muốn
            ActivityChart.CustomDrawAxisLabel += (s, e) =>
            {
                var args = (CustomDrawAxisLabelEventArgs)e;
                AxisBase axis = args.Item.Axis;
                if (axis is AxisY)
                {
                    double axisValue = (double)args.Item.AxisValue;
                    string answer = string.Format("{0:0,0}",
                        axisValue);
                    args.Item.Text = answer;
                }
            };

            // Dock the chart into its parent and add it to the current form.
            ActivityChart.Dock = DockStyle.Fill;
            PanelControlActivitySub.Controls.Add(ActivityChart);
            //ActivityChart.BringToFront();
        }


        #region Button Control
        /// <summary>
        /// Di chuyển các NĂM của biểu đồ
        /// </summary>
        /// <param name="year">NĂM</param>
        /// <param name="dbtype">số thứ tự biểu đồ</param>
        private bool ButtonControl(int year, int dbtype)
        {
            var listyeartemp = new[] { EstimateCurentYear, ExpenseCurentYear, CashCurentMonth, ActivityCurentYear };//Mảng tạm chứa NĂM
            switch (dbtype)
            {
                case 1://Biểu đồ 1
                    EstimateCurentYear += year;
                    if (((int)DateTime.Now.Year + EstimateCurentYear) >=
                        Convert.ToInt32(GlobalVariable.DBStartDate.Substring(GlobalVariable.DBStartDate.Length - 4, 4)))
                        _usercontrolmaindesktop.Refresh(EstimateCurentYear);
                    else
                        goto case -1;
                    break;
                case 2://Biểu đồ 2
                    ExpenseCurentYear += year;
                    if (((int)DateTime.Now.Year + ExpenseCurentYear) >=
                        Convert.ToInt32(GlobalVariable.DBStartDate.Substring(GlobalVariable.DBStartDate.Length - 4, 4)))
                        _dashBoardBudget.Refresh(ExpenseCurentYear);
                    else
                        goto case -1;
                    break;
                case 3://Biểu đồ 3
                    CashCurentMonth += year;
                    if ((CashMonth + year) < (Convert.ToDateTime(GlobalVariable.DBStartDate).Month) && CashYear.Equals(Convert.ToDateTime(GlobalVariable.DBStartDate).Year))
                        goto case -1;
                    else _dashBoardCash.Refresh(CashCurentMonth, CashCurentMonthYear);
                    break;
                case 4://Biểu đồ 4
                    ActivityCurentYear += year;
                    if (((int)DateTime.Now.Year + ActivityCurentYear) >=
                        Convert.ToInt32(GlobalVariable.DBStartDate.Substring(GlobalVariable.DBStartDate.Length - 4, 4)))
                        _dashBoardActivity.Refresh(ActivityCurentYear);
                    else
                        goto case -1;
                    break;
                case -1:
                    //XtraMessageBox.Show("Không thể xem dữ liệu trước ngày bắt đầu hạch toán", ResourceHelper.GetResourceValueByName("ResDetailContent"),
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EstimateCurentYear = listyeartemp[0];
                    ExpenseCurentYear = listyeartemp[1];
                    CashCurentMonth = listyeartemp[2];
                    ActivityCurentYear = listyeartemp[3];
                    return false;
                    break;
                default: break;
            }
            return true;
        }

        private void btnEstimatePrev_Click_1(object sender, EventArgs e)
        {
            if (EstimateCurentYear - CurentPostedDate > -1)
                ButtonControl(-1, 1);
        }

        private void btnEstimateNext_Click_1(object sender, EventArgs e)
        {
            if (EstimateCurentYear - CurentPostedDate < 1)
                ButtonControl(1, 1);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!ButtonControl(-2 - (EstimateCurentYear - CurentPostedDate), 1))
                if (!ButtonControl(-1 - (EstimateCurentYear - CurentPostedDate), 1))
                    ButtonControl((EstimateCurentYear - CurentPostedDate), 1);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ButtonControl(2 - (EstimateCurentYear - CurentPostedDate), 1);
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (ExpenseCurentYear - CurentPostedDate > -1)
                ButtonControl(-1, 2);
        }

        private void btnExpenseNext_Click(object sender, EventArgs e)
        {
            if (ExpenseCurentYear - CurentPostedDate < 1)
                ButtonControl(1, 2);
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (CashCurentMonth < 12 - (int)DateTime.Now.Month - 1)
                ButtonControl(1, 3);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (ActivityCurentYear - CurentPostedDate > -1)
                ButtonControl(-1, 4);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (ActivityCurentYear - CurentPostedDate < 1)
                ButtonControl(1, 4);

        }


        private void PanelControlExpense_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UserControlMainDesktop_Resize(object sender, EventArgs e)
        {
            //if(this.Size.Width <= 1236)
            //    this.Size = new Size(1236, this.Size.Height);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            if (!ButtonControl(-2 - (ExpenseCurentYear - CurentPostedDate), 2))
                if (!ButtonControl(-1 - (ExpenseCurentYear - CurentPostedDate), 2))
                    ButtonControl((ExpenseCurentYear - CurentPostedDate), 2);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            ButtonControl(2 - (ExpenseCurentYear - CurentPostedDate), 2);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (!ButtonControl(-2 - (ActivityCurentYear - CurentPostedDate), 4))
                if (!ButtonControl(-1 - (ActivityCurentYear - CurentPostedDate), 4))
                    ButtonControl((ActivityCurentYear - CurentPostedDate), 4);
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {
            ButtonControl(2 - (ActivityCurentYear - CurentPostedDate), 4);
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            CashCurentMonth = 0;
            ButtonControl(0 - (int)DateTime.Now.Month + 2, 3);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            CashCurentMonth = 0;
            ButtonControl(12 - (int)DateTime.Now.Month - 1, 3);
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (CashCurentMonth > 0 - (int)DateTime.Now.Month + 2)
                ButtonControl(-1, 3);
        }
        #endregion
    }
}
