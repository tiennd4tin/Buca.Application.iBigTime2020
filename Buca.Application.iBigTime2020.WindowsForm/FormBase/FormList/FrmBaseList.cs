/***********************************************************************
 * <copyright file="BaseListUserControl.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, February 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Report;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Report;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem.UserProfile;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList
{
    /// <summary>
    /// Class BaseListUserControl.
    /// </summary>
    public partial class FrmBaseList : XtraUserControl, IReportsView, IAudittingLogView
    {
        /// <summary>
        /// The _report list presenter
        /// </summary>
        private readonly ReportListPresenter _reportListPresenter;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;

        #region Variables

        /// <summary>
        /// The e action mode
        /// </summary>
        public ActionModeEnum ActionMode;
        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// The primary key value
        /// </summary>
        public string PrimaryKeyValue;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the form detail.
        /// </summary>
        /// <value>The form detail.</value>
        [Category("BaseProperty")]
        public string FormDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace form.
        /// </summary>
        /// <value>The namespace form.</value>
        [Category("BaseProperty")]
        public string NamespaceForm { get; set; }

        /// <summary>
        /// Gets or sets the table primary key.
        /// </summary>
        /// <value>The table primary key.</value>
        [Category("BaseProperty")]
        public string TablePrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>The form caption.</value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the row selected.
        /// </summary>
        /// <value>The row selected.</value>
        [Category("BaseProperty")]
        public int RowSelected { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>The report identifier.</value>
        [Category("BaseProperty")]
        // ReSharper disable once InconsistentNaming
        public string ReportID { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display add new bar button.
        /// </summary>
        /// <value><c>true</c> if this instance is display add new bar button; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool IsDisplayAddNewBarButton { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display edit bar button.
        /// </summary>
        /// <value><c>true</c> if this instance is display edit bar button; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool IsDisplayDeleteBarButton { get; set; }

        /// <summary>
        /// Gets or sets Type Project
        /// </summary>
        /// <value>The report identifier.</value>
        public int ObjectType { get; set; }
        #endregion

        #region Functions

        /// <summary>
        /// Initializes the menu.
        /// </summary>
        private void InitializeMenu()
        {
            barButtonAddNewItem.Visibility = IsDisplayAddNewBarButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            barButtonDeleteItem.Visibility = IsDisplayDeleteBarButton ? BarItemVisibility.Always : BarItemVisibility.Never;
        }

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            if (!DesignMode)
                Text = FormCaption;
            ActionMode = ActionModeEnum.None;
            grdList.Focus();

        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        protected void LoadData()
        {
            try
            {
                gridView.BeginUpdate();
                LoadDataIntoGrid();
                LoadGridLayout();
                SetGridNumericFormat();
                grdList.ForceInitialize();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                gridView.EndUpdate();
            }
            finally
            {
                gridView.EndUpdate();
                ActionMode = ActionModeEnum.None;
            }
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        private void LoadGridLayout()
        {
            if (ColumnsCollection != null)
            {
                foreach (var column in ColumnsCollection)
                {
                    if (gridView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridView.Columns[column.ColumnName].DisplayFormat.FormatString = column.DisplayFormat;
                        }
                        else
                            gridView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        /// <param name="rowHandler">The row handler.</param>
        public void SetRowSelected(int rowHandler = 0)
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
            {
                gridView.FocusedRowHandle = rowHandler;
                gridView.MakeRowVisible(rowHandler);
            }
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        public void GetRowValueSelected()
        {
            try
            {
                if (gridView.DataSource != null)
                {
                    var rowHandle = gridView.FocusedRowHandle;
                    if (!DesignMode)
                    {
                        if (ActionMode == ActionModeEnum.None || ActionMode == ActionModeEnum.Delete)
                            PrimaryKeyValue = gridView.GetRowCellValue(rowHandle, TablePrimaryKey) != null
                                                  ? gridView.GetRowCellValue(rowHandle, TablePrimaryKey).ToString()
                                                  : null;
                    }
                    gridView.MakeRowVisible(rowHandle);
                    GridViewFocusedRowChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        public virtual void GridViewFocusedRowChanged()
        {

        }

        private void ShowFormRole()
        {
            try
            {
                FrmPermiss frmPermiss = new FrmPermiss();
                frmPermiss.UserProfileID = PrimaryKeyValue;
                frmPermiss.KeyValue = frmPermiss.ActionMode == ActionModeEnum.Edit ? null : PrimaryKeyValue;
                frmPermiss.PostKeyValue += FrmDetail_PostKey;
                frmPermiss.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "Lỗi ở đây", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        private void ShowFormDetail()
        {
            try
            {
                using (var frmDetail = GetFormDetail())
                {
                    if (frmDetail == null)
                    {
                        return;
                    }
                    frmDetail.ActionMode = ActionMode;
                    frmDetail.HelpTopicId = HelpTopicId;

                    frmDetail.KeyValue = frmDetail.ActionMode == ActionModeEnum.AddNew ? null : PrimaryKeyValue;
                    frmDetail.PostKeyValue += FrmDetail_PostKey;

                    if (ActionMode == ActionModeEnum.AddNew)
                    {
                        ListBindingSource.AddNew();
                        ListBindingSource.MoveLast();
                    }
                    frmDetail.BindingSourceDetail = ListBindingSource;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    { }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message + "Lỗi ở đây", ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// LinhMC comment method này lại.
        /// </summary>
        /// <returns>FrmXtraBaseCategoryDetail.</returns>
        protected virtual FrmXtraBaseCategoryDetail GetFormDetail()
        {
            try
            {
                var typeOfFormDetail = Assembly.GetExecutingAssembly().GetType(NamespaceForm + "." + FormDetail);
                return typeOfFormDetail != null ? (FrmXtraBaseCategoryDetail)Activator.CreateInstance(typeOfFormDetail) : null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        /// <summary>
        /// Sets the row after update.
        /// </summary>
        protected void SetRowAfterUpdate()
        {
            try
            {
                if (gridView.RowCount <= 0)
                    return;
                var xtraColumn = gridView.Columns[TablePrimaryKey];
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    var currentValue = gridView.GetRowCellValue(i, xtraColumn).ToString();
                    if (PrimaryKeyValue != currentValue)
                        continue;
                    RowSelected = i;
                    break;
                }
                SetRowSelected(RowSelected);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// FRMs the detail_ post key.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void FrmDetail_PostKey(object sender, string data)
        {
            PrimaryKeyValue = data;
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            barButtonEditItem.Enabled = gridView.RowCount > 0;
            barButtonDeleteItem.Enabled = gridView.RowCount > 0;
            barButtonPrintItem.Enabled = gridView.RowCount > 0;

            GridViewFocusedRowChanged();
        }

        /// <summary>
        /// Sets the grid numeric format.
        /// </summary>
        protected virtual void SetGridNumericFormat()
        {
            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        oCol.DisplayFormat.FormatString = GlobalVariable.CurrencyDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                        oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                        oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.Integer:
                        oCol.DisplayFormat.FormatString = GlobalVariable.NumericDisplayString;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        // ThangNK bổ sung

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode)
                return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        #endregion

        #region Functions overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected virtual void LoadDataIntoGrid()
        {
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected virtual void DeleteGrid()
        {

        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected virtual void DeleteItem()
        {
            try
            {

                ActionMode = ActionModeEnum.Delete;
                var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                                                 ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    DeleteGrid();
                    _audittingLogPresenter.Save();
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                        ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData();
                SetRowSelected();
                GetRowValueSelected();
            }

        }
        /// <summary>
        /// Adds the data.
        /// </summary>
        protected virtual void AddRole()
        {
            ActionMode = ActionModeEnum.Edit;
            ShowFormRole();
            LoadData();
        }


        public virtual void AddData()
        {
            ActionMode = ActionModeEnum.AddNew;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Edits the data.
        /// </summary>  
        protected virtual void EditData()
        {
            ActionMode = ActionModeEnum.Edit;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Prints the data.
        /// </summary>
        protected virtual void PrintData()
        {
            try
            {
                ActionMode = ActionModeEnum.None;
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                _reportList = _reportListPresenter.GetAllReportList();
                if (_reportList == null)
                    return;
                reportHelper.ReportLists = _reportList;
                reportHelper.PrintPreviewReport(null, ReportID, false);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Using form name to get help topic id in database
        /// Helps this instance.
        /// </summary>
        protected virtual void ShowHelp()
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(HelpTopicId));
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBaseList" /> class.
        /// </summary>
        public FrmBaseList()
        {
            InitializeComponent();
            _reportListPresenter = new ReportListPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the BaseListUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void BaseListUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            InitializeMenu();
            InitializeLayout();
            LoadData();
            SetRowSelected(RowSelected);
            GetRowValueSelected();
            RefreshToolbar();
            PermissionUseFormMaster();
        }

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs" /> instance containing the event data.</param>
        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetRowValueSelected();
        }

        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0)
                return;
            GetRowValueSelected();
            EditData();
            SetRowAfterUpdate();
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs" /> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonAddNewItem":
                    AddData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonEditItem":
                    EditData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDeleteItem":
                    DeleteItem();
                    break;
                case "barButtonRefeshItem":
                    LoadData();
                    SetRowSelected();
                    GetRowValueSelected();
                    break;
                case "barButtonPrintItem":
                    PrintData();
                    break;
                case "barButtonHelpItem":
                    ActionMode = ActionModeEnum.None;
                    ShowHelp();
                    break;
                case "barButtonFind":
                    gridView.ShowFindPanel();
                    break;
                case "barButtonItemRole":
                    AddRole();
                    GetRowValueSelected();
                    break;
            }
            RefreshToolbar();
        }

        /// <summary>
        /// Handles the RowStyle event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowStyleEventArgs"/> instance containing the event data.</param>
        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                e.Appearance.BackColor = Color.Moccasin;
            }
        }

        /// <summary>
        /// Handles the BeforePopup event of the popupMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            Point p = grdList.PointToClient(MousePosition);
            GridHitInfo hitInfo = gridView.CalcHitInfo(p);

            if (hitInfo.HitTest != GridHitTest.RowCell)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region IReportView Members

        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>The report lists.</value>
        public List<ReportListModel> ReportLists
        {
            get
            {
                return _reportList;
            }
            set
            {
                _reportList = value;
            }
        }

        #endregion

        #region AuditingLog Member

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
        public string ComponentName
        {
            get { return (string.IsNullOrEmpty(FormCaption) ? "" : CommonFunction.FirstCharToUpper(FormCaption)); }
            set { }
        }

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
                    case ActionModeEnum.AddNew:
                        return 1;
                    case ActionModeEnum.Edit:
                        return 2;
                    case ActionModeEnum.Delete:
                        return 3;
                    default:
                        return 4;
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
                    case ActionModeEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    case ActionModeEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    case ActionModeEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
                    default:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + PrimaryKeyValue;
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

        // In thẻ tài sản cố định
        //protected virtual void PrintFixedAssetData()
        //{
        //    try
        //    {
        //        ActionMode = ActionModeEnum.None;
        //        Cursor.Current = Cursors.WaitCursor;
        //        var reportHelper = new ReportHelper();
        //        _reportList = _reportListPresenter.GetAllReportList();
        //        reportHelper.ReportLists = _reportList;

        //        using (var frmXtraPrintVoucherByLot = new FrmXtraPrintVoucherByLot())
        //        {
        //            frmXtraPrintVoucherByLot.RefType = RefType.FixedAssetDictionary;
        //            IList<ReportListModel> reportLists = _reportList.FindAll(item => item.ReportID.Contains("ReportFixedAsset"));
        //            frmXtraPrintVoucherByLot.InitComboData(reportLists);
        //            frmXtraPrintVoucherByLot.RefID = int.Parse(PrimaryKeyValue);
        //            if (frmXtraPrintVoucherByLot.ShowDialog() == DialogResult.OK)
        //            {
        //                var refIds = frmXtraPrintVoucherByLot.SelectedFa;
        //                var reportVoucherId = frmXtraPrintVoucherByLot.ReportID;
        //                reportHelper.CommonVariable = new GlobalVariable
        //                {
        //                    RefIdList = refIds
        //                };

        //                if (reportVoucherId != null)
        //                {
        //                    reportHelper.PrintPreviewReport(null, reportVoucherId, false);
        //                }
        //            }E:\WORKING\Buca.Application.aBigTime\Buca.Application.iBigTime2020.WindowsForm\CommonControl\
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }
        //}

        private void barButtonPrintFixedAssetItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // PrintFixedAssetData();
        }

        private void PermissionUseFormMaster()
        {
            var _model = new Model.Model();
            var formName = this.Name;
            var userProfile = _model.GetUserProfileByUserName(LoginName);
            if (userProfile != null && !userProfile.IsSystem && LoginName != "admin")
            {
                var userFeaturePermisions =
                    _model.GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(userProfile.UserProfileId, formName);
                if (userFeaturePermisions.Any())
                {
                    foreach (BarButtonItem barToolsItemLink in barTools.Manager.Items)
                    {
                        CommonFunction.CheckPermissionUseFormMaster(barToolsItemLink, userFeaturePermisions.ToList());
                    }
                }
                else
                {
                    barTools.Visible = false;
                }
            }
            if (formName != "UserControlUserProfileList")
                barTools.Manager.Items["barButtonItemRole"].Visibility = BarItemVisibility.Never;
        }

    }
}