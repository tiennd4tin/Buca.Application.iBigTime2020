using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.DataHelpers;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.Presenter.System.Lock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DateTimeRangeBlockDev.Helper;
using DevExpress.CodeParser;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraCharts.GLGraphics;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    public partial class FrmUnlockBook : XtraForm, IDBOptionsView, IAudittingLogsView, IAudittingLogView
    {
        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly AudittingLogPresenter _audittingLogPresenter;
        private readonly AudittingLogsPresenter _audittingLogsPresenter;
        public FrmUnlockBook()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _audittingLogsPresenter = new AudittingLogsPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
            dtReportPeriod.DateRangePeriodMode = DateRangeMode.Reduce;
            //dtReportPeriod.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dtReportPeriod.InitSelectedIndex = 0;
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
            dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));

        }


        public string Content { get; set; }
        public string LockDateSeason
        {
            get { return dtReportPeriod.cboDateRange.EditValue.ToString(); }
            set { dtReportPeriod.cboDateRange.EditValue = value; }
        }
        public DateTime LockDateFrom
        {
            get { return dtReportPeriod.FromDate; }
            set { dtReportPeriod.FromDate = value; }
        }
        public DateTime LockDateTo
        {
            get { return dtReportPeriod.ToDate; }
            set { dtReportPeriod.ToDate = value; }
        }

        public int IsLock { get; set; }
        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        private string RefNo { get; set; }
        public ActionModeEnum ActionMode;

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public string EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return GlobalVariable.LoginName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName { get { return "Khóa sổ /Mở khóa sổ"; } set { } }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction 
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeEnum.Lock:
                        return 9;
                    case ActionModeEnum.Unlock:
                        return 10;
                    default:
                        return 3;
                }
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference 
        {
            get
            {
                switch (ActionMode)
                {
                    case ActionModeEnum.Lock:
                        //return "Khóa sổ từ " + LockDateFrom.ToShortDateString() + " đến " + LockDateTo.ToShortDateString();
                        return "Khóa sổ";
                    case ActionModeEnum.Unlock:
                        //return "Mở khóa sổ " + LockDateFrom.ToShortDateString() + " đến " + LockDateTo.ToShortDateString();\
                        return "Mở khóa sổ";
                    default:
                        return null;
                }
            }
            set { }
        }
        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion
        public IList<DBOptionModel> DBOptions
        {
            get
            {
                string lockValue = dtReportPeriod.FromDate.ToShortDateString() + "-" + dtReportPeriod.ToDate.ToShortDateString();
                string lockSeason = dtReportPeriod.cboDateRange.EditValue.ToString();
                var dbOptions = new List<DBOptionModel>
                {
                   
                    new DBOptionModel { OptionId = "LockVoucher", OptionValue = lockValue != "" ? lockValue :"", ValueType = IsLock,
                        Description = lockSeason, IsSystem = true },

                };
                GlobalVariable.LockVoucherSeason = dtReportPeriod.cboDateRange.EditValue.ToString();
                GlobalVariable.LockVoucherDateFrom = Convert.ToDateTime(LockDateFrom).ToShortDateString();
                GlobalVariable.LockVoucherDateTo= Convert.ToDateTime(LockDateTo).ToShortDateString();
                //GlobalVariable.LockVoucherDate = Convert.ToDateTime(LockDate).ToShortDateString();
                GlobalVariable.IsLockVoucher = IsLock;

                return dbOptions;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<AudittingLogModel> AudittingLogs 
        {
            set
            {
                try
                {
                    var data = value.Where(x => x.EventAction == 9 || x.EventAction == 10).ToList();
                    gridLog.DataSource = data;
                    var ColumnsCollection = new List<XtraColumn>();
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "LoginName",
                        ColumnCaption = "Tên đăng nhập",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 50
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ComputerName",
                        ColumnCaption = "Máy tính",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 50
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "EventTime",
                        ColumnCaption = "Thời gian",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 70,
                    });
                    ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "Reference",
                        ColumnCaption = "Hành động",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 100,
                    });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "EventId", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "ComponentName", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "EventAction", ColumnVisible = false });
                    ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnVisible = false });
                    (gridLogView as GridView).Columns["EventTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    (gridLogView as GridView).Columns["EventTime"].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
                    gridLogView = InitGridLayout(ColumnsCollection, gridLogView);
                }

                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmUnlockBook_Load(object sender, EventArgs e)
        {

            RefeshForm();

            //btn.FlatStyle = FlatStyle.Flat;
            //btn.FlatAppearance.BorderColor = Color.White;
            //btn.FlatAppearance.BorderSize = 0;
            _audittingLogsPresenter.Display();
            dtReportPeriod.DateRangePeriodMode = DateRangeMode.Reduce;
            //dtReportPeriod.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
      
            if (Convert.ToDateTime(GlobalVariable.PostedDate) > Convert.ToDateTime(GlobalVariable.LockVoucherDateTo)|| Convert.ToDateTime(GlobalVariable.PostedDate) < Convert.ToDateTime(GlobalVariable.LockVoucherDateFrom))
            {
                dtReportPeriod.InitSelectedIndex = 0;
                var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
                dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
                dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
                btnLock.Enabled = true;
                btnUnlock.Enabled = false;
                Content = "Hệ thống chưa thực hiện khóa sổ!";
                lblNotice.Text = Content;
            }
            else
            {

                if (GlobalVariable.IsLockVoucher == 1)
                {
                    btnLock.Enabled = false;
                    btnUnlock.Enabled = true;
                    if ((!string.IsNullOrEmpty(GlobalVariable.LockVoucherDateFrom) && !GlobalVariable.LockVoucherDateFrom.AsDateTime().Equals(Convert.ToDateTime("01/01/0001"))) && (!string.IsNullOrEmpty(GlobalVariable.LockVoucherDateTo) && !GlobalVariable.LockVoucherDateTo.AsDateTime().Equals(Convert.ToDateTime("01/01/0001"))) && (!string.IsNullOrEmpty(GlobalVariable.LockVoucherSeason)))
                    {
                        //dtExcuteDate.DateTime = GlobalVariable.LockVoucherDate.AsDateTime();
                        dtReportPeriod.cboDateRange.EditValue = GlobalVariable.LockVoucherSeason;
                        dtReportPeriod.FromDate = GlobalVariable.LockVoucherDateFrom.AsDateTime();
                        dtReportPeriod.ToDate = GlobalVariable.LockVoucherDateTo.AsDateTime();
                        Content = "Hệ thống đã khóa sổ từ ngày: " + dtReportPeriod.FromDate.ToShortDateString() + " đến ngày " + dtReportPeriod.ToDate.ToShortDateString();
                    }
                }
                else
                {
                    btnLock.Enabled = true;
                    btnUnlock.Enabled = false;
                    dtReportPeriod.InitSelectedIndex = 1;
                    var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dtReportPeriod.cboDateRange.EditValue = "Năm nay";
                    dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
                    dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
                    dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
                    Content = "Hệ thống chưa thực hiện khóa sổ!";
                }
                lblNotice.Text = Content;
            }

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dtReportPeriod.ToDate >= DateTime.Parse(GlobalVariable.DBStartDate))
                //if (dtExcuteDate.DateTime >= DateTime.Parse(GlobalVariable.DBStartDate))
            {
                IsLock = 1;
                ActionMode = ActionModeEnum.Lock;
                _dbOptionsPresenter.Save();
                _audittingLogPresenter.Save();
                GlobalVariable.LockVoucherSeason = LockDateSeason;
                GlobalVariable.LockVoucherDateFrom = LockDateFrom.ToLongDateString();
                GlobalVariable.LockVoucherDateTo = LockDateTo.ToLongDateString();
                RefeshForm();
                XtraMessageBox.Show("Khóa sổ thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnLock.Enabled = false;
                btnUnlock.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show("Ngày khóa sổ không được nhỏ hơn ngày khởi tạo dữ liệu!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        /// <summary>
        /// btnUnlock_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnlock_Click(object sender, EventArgs e)
        {

            IsLock = 0;
            LockDateSeason = "";
            ActionMode = ActionModeEnum.Unlock;
            //var firstDay = new DateTime(DateTime.Now.Year, 1, 1);
            //var lastDay = new DateTime(DateTime.Now.Year, 12, 31);
            LockDateFrom = DateTime.MinValue;
            LockDateTo = DateTime.MinValue;
            //dtExcuteDate.EditValue = "";
            _dbOptionsPresenter.Save();
            _audittingLogPresenter.Save();
            RefeshForm();
            btnLock.Enabled = true;
            btnUnlock.Enabled = false;
            XtraMessageBox.Show(" Bỏ khóa sổ thành công!",
           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lblNotice.Text = "Hệ thống chưa thực hiện khóa sổ!";
            IModel model = new Model.Model();
            gridLog.DataSource = null;
            gridLog.DataSource = model.GetAudittingLogs().Where(o => o.EventAction == 10 || o.EventAction == 9);
            gridLog.Refresh();
            gridLogView.RefreshData();
            //dtExcuteDate.DateTime = DateTime.Now;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void RefeshForm()
        {
            // lockPresenter.Display();
            lblNotice.Text = Content;
            if(!string.IsNullOrEmpty(GlobalVariable.LockVoucherSeason) || GlobalVariable.LockVoucherDateFrom.AsDateTime() == DateTime.MinValue || GlobalVariable.LockVoucherDateTo.AsDateTime() == DateTime.MinValue)
            {
                dtReportPeriod.InitSelectedIndex = 0;
                var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtReportPeriod.cboDateRange.EditValue = "Năm nay";
                dtReportPeriod.InitData(new DateTime(basePostedDate.Year, 1, 1));
                dtReportPeriod.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
                dtReportPeriod.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
            }
            else
            {
                dtReportPeriod.cboDateRange.EditValue = GlobalVariable.LockVoucherSeason;
                dtReportPeriod.FromDate = GlobalVariable.LockVoucherDateFrom.AsDateTime();
                dtReportPeriod.ToDate = GlobalVariable.LockVoucherDateTo.AsDateTime();
            }    

        }

        /// <summary>
        /// Handles the KeyPress event of the FrmUnlockBook control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void FrmUnlockBook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView gridView)
        {
            foreach (var column in columnsCollection)
            {
                if (gridView.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        if (column.IsSummaryText)
                        {
                            gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        gridView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            return gridView;
        }
    }
}