/***********************************************************************
 * <copyright file="BaseVoucherListUserControl.cs" company="BUCA JSC">
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.Presenter.System.Lock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BAWithDraw;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList
{
    /// <summary>
    /// BaseVoucherListUserControl
    /// </summary>
    public partial class FrmBaseVoucherList : XtraUserControl, IAudittingLogView, IRefTypesView, ILockView
    {
        #region RefTypes Member

        public RepositoryItemGridLookUpEdit GridLookUpEditRefType;
        public GridView GridLookUpEditRefTypeView;
        private List<RefTypeModel> _refTypes;
        private readonly RepositoryItemDateEdit _repositoryItemDateEdit = new RepositoryItemDateEdit();

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes

        {
            get { return _refTypes; }
            set
            {
                try
                {
                    _refTypes = value.ToList();
                    GridLookUpEditRefTypeView = new GridView();
                    GridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                    GridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = GridLookUpEditRefTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True,
                        NullValuePrompt = null,
                        DisplayMember = "RefTypeName",
                        ValueMember = "RefTypeId",
                    };
                    //GridLookUpEditRefTypeView.PopulateColumns();
                    GridLookUpEditRefType.View.OptionsView.ShowIndicator = false;
                    GridLookUpEditRefType.PopupFormSize = new Size(368, 150);
                    GridLookUpEditRefType.View.BestFitColumns();

                    GridLookUpEditRefType.DataSource = value;
                    GridLookUpEditRefTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeName",
                        ColumnCaption = "Tên loại CT",
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultDebitAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultCreditAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultTaxAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Postable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Searchable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region LockDate

        public string Content
        {
            get;
            set;
        }

        public string LockDate
        {
            get;
            set;
        }

        public bool IsLock
        {
            get;
            set;
        }

        #endregion

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        private string RefNo { get; set; }

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
            get
            {
                if (!DesignMode)
                {
                    var formCaption = "";
                    var firstOrDefault = RefTypes.FirstOrDefault(r => r.RefTypeId == (int)RefTypeId);
                    if (firstOrDefault != null)
                    {
                        var refTypeName = firstOrDefault.RefTypeName;
                        formCaption = refTypeName;
                    }
                    return (string.IsNullOrEmpty(formCaption) ? "" : formCaption);
                }
                return "";
            }
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
                    case ActionModeVoucherEnum.AddNew:
                        return 1;
                    case ActionModeVoucherEnum.Edit:
                        return 2;
                    case ActionModeVoucherEnum.Delete:
                        return 3;
                    case ActionModeVoucherEnum.None:
                        return 4;
                    default:
                        return 5;//Nhân bản
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
                    case ActionModeVoucherEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    case ActionModeVoucherEnum.None:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
                    default:
                        return "NHÂN BẢN " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               PrimaryKeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(RefNo) ? "" : RefNo);
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

        #region Variables

        private readonly LockPresenter _lockPresenter;

        protected int SelectedRowIndex;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _ref types presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// The e action mode
        /// </summary>
        public ActionModeVoucherEnum ActionMode;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// The primary key value
        /// </summary>
        public string PrimaryKeyValue;

        /// <summary>
        /// The posted date
        /// </summary>
        protected string PostedDate;


        /// <summary>
        /// The database option helper
        /// </summary>
        //   protected GlobalVariable DBOptionHelper;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the form detail.
        /// </summary>
        /// <value>
        /// The form detail.
        /// </value>
        [Category("BaseProperty")]
        public string FormDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace form.
        /// </summary>
        /// <value>
        /// The namespace form.
        /// </value>
        [Category("BaseProperty")]
        public string NamespaceForm { get; set; }

        /// <summary>
        /// Gets or sets the table primary key.
        /// </summary>
        /// <value>
        /// The table primary key.
        /// </value>
        [Category("BaseProperty")]
        public string TablePrimaryKey { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the row selected.
        /// </summary>
        /// <value>
        /// The row selected.
        /// </value>
        [Category("BaseProperty")]
        public int RowSelected { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        [Category("BaseProperty")]
        public RefType RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            // DBOptionHelper = new GlobalVariable();
            Text = FormCaption;
            grdList.Focus();

            _repositoryItemDateEdit.EditMask = "d";
            _repositoryItemDateEdit.DisplayFormat.FormatString = "dd/MM/yyyy";

            gridView.OptionsView.ShowFooter = true;
            gridViewDetail.OptionsView.ShowFooter = true;
            gridView.OptionsView.ShowAutoFilterRow = true;
            InitControls();
        }
        protected virtual void InitControls()
        {

        }

        /// <summary>
        /// Initializes the variables.
        /// </summary>
        private void InitVariables()
        {
            ActionMode = ActionModeVoucherEnum.None;
            PostedDate = GlobalVariable.PostedDate;
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
                //SetNumericFormatControl(gridView, true);
                LoadGridMasterFilter(ColumnsCollection, gridView);
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
                ActionMode = ActionModeVoucherEnum.None;
                RefreshToolbar();
            }
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        protected virtual void LoadGridLayout()
        {
            //gridView.InitGridLayout(ColumnsCollection);
            #region 
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
                            if (column.IsSummnary)
                            {
                                gridView.Columns[column.ColumnName].SummaryItem.SummaryType = column.SummaryType;
                            }

                            //default summary in some below cases
                            if (column.ColumnName.Contains("AmountOC") || column.ColumnName.Contains("Amount"))
                            {
                                gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Sum;
                                gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                                gridView.Columns[column.ColumnName].SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                            }
                            if (column.ColumnPosition == 1)
                            {
                                gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Count;
                                gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Số dòng = {0:n0}";
                            }


                        }
                        else
                            gridView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        private void SetRowSelected(int rowHandler = 0)
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
            {
                gridView.MakeRowVisible(rowHandler);
                gridView.FocusedRowHandle = rowHandler;
                //LoadDataIntoGridDetail(PrimaryKeyValue);
            }
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        /// <returns></returns>
        public void GetRowValueSelected()
        {
            try
            {
                if (gridView.DataSource != null)
                {
                    var rowHandle = gridView.FocusedRowHandle;
                    if (!DesignMode)
                    {
                        if (ActionMode == ActionModeVoucherEnum.None || ActionMode == ActionModeVoucherEnum.Delete)
                            PrimaryKeyValue = gridView.GetRowCellValue(rowHandle, TablePrimaryKey) != null
                                                  ? gridView.GetRowCellValue(rowHandle, TablePrimaryKey).ToString()
                                                  : null;
                    }
                    gridView.MakeRowVisible(rowHandle);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        //protected virtual void ShowFormDetail()
        //{
        //    try
        //    {
        //        BindingSource BindingSource1 = new BindingSource();
        //        BindingSource1.DataSource = bindingSource.DataSource;

        //        using (var frmDetail = GetFormDetail())
        //        {
        //            frmDetail.ActionMode = ActionMode;
        //            frmDetail.KeyValue = frmDetail.ActionMode == ActionModeVoucherEnum.AddNew
        //                                     ? null
        //                                     : PrimaryKeyValue;
        //            frmDetail.PostKeyValue += FrmDetail_PostKey;

        //            frmDetail.MasterBindingSource = bindingSource;
        //            SelectedRowIndex = bindingSource.Position;
        //            frmDetail.CurrentPosition = SelectedRowIndex;
        //            frmDetail.HelpTopicId = HelpTopicId;

        //            if (ActionMode == ActionModeVoucherEnum.AddNew)
        //            {
        //                bindingSource.AddNew();
        //                bindingSource.MoveLast();
        //            }
        //            if (frmDetail.ShowDialog() == DialogResult.OK)
        //            {
        //            }

        //            if (bindingSource.Count > 0)
        //            {
        //                bindingSource.RemoveAt(bindingSource.Count - 1);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
        //                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        protected virtual void ShowFormDetail()
        {
            try
            {
                BindingSource BindingSource1 = new BindingSource();
                BindingSource1.DataSource = bindingSource.DataSource;

                using (var frmDetail = GetFormDetail())
                {
                    frmDetail.ActionMode = ActionMode;
                    frmDetail.KeyValue = frmDetail.ActionMode == ActionModeVoucherEnum.AddNew
                                             ? null
                                             : PrimaryKeyValue;
                    frmDetail.PostKeyValue += FrmDetail_PostKey;

                    frmDetail.MasterBindingSource = BindingSource1;
                    BindingSource1.Position = bindingSource.Position;
                    SelectedRowIndex = BindingSource1.Position;
                    //frmDetail.CurrentPosition = SelectedRowIndex;     cmt de fix loi ko double click ở đánh giá lại TSCD
                    frmDetail.HelpTopicId = HelpTopicId;

                    if (ActionMode == ActionModeVoucherEnum.AddNew)
                    {
                        BindingSource1.AddNew();
                        BindingSource1.MoveLast();
                    }
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                    }

                    if (bindingSource.Count > 0)
                    {
                        bindingSource.RemoveAt(bindingSource.Count - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected virtual FrmXtraBaseVoucherDetail GetFormDetail()
        {
            try
            {
                var typeOfFormDetail = Assembly.GetExecutingAssembly().GetType(NamespaceForm + "." + FormDetail);
                return typeOfFormDetail != null ? (FrmXtraBaseVoucherDetail)Activator.CreateInstance(typeOfFormDetail) : null;
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
        /// LinhMC bổ sung thêm 1 số lệnh để điều kiển lại việc nạp dữ liệu trên list
        /// nếu không có các lệnh này, thì khi lưu lần thứ nhất, nhấn thêm chứng từ, 
        /// rồi nhấn hoãn sẽ bị trường hợp dữ liệu bị rỗng
        /// LoadDataIntoGrid();
        /// LoadGridLayout();
        /// SetGridNumericFormat();
        /// bindingSource.MoveFirst(); ---LinhMC bỏ dòng này để focus vào dòng được thêm hoặc sửa
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">The data.</param>
        public void FrmDetail_PostKey(object sender, string data)
        {
            PrimaryKeyValue = data;
            LoadDataIntoGrid();
            LoadGridLayout();

            //gridView.InitGridLayout(ColumnsCollection);
            LoadDataIntoGridDetail(PrimaryKeyValue);
            //SetGridNumericFormat();
            SetRowAfterUpdate();
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            barButtonEditItem.Enabled = gridView.RowCount > 0;
            barButtonDuplicate.Enabled = gridView.RowCount > 0;
            barButtonDeleteItem.Enabled = gridView.RowCount > 0;
            barButtonPrintItem.Enabled = gridView.RowCount > 0;
            barButtonCalculatePriceItem.Enabled = gridView.RowCount > 0;
            //if (RefTypeId == RefType.OutwardStock)
            //{
            //    barButtonCalculatePriceItem.Visibility = BarItemVisibility.Always;
            //}

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

        #endregion

        #region Functions overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected virtual void LoadDataIntoGrid()
        {
        }

        protected virtual void LoadDataIntoGridDetail(string refId)
        {
            //switch (RefTypeId)
            //{
            //    case RefType.ReceiptEstimate:
            //        break;
            //    case RefType.PaymentEstimate:
            //        break;
            //    case RefType.ReceiptCash:
            //        break;
            //    case RefType.PaymentCash:
            //        break;
            //    case RefType.ReceiptDeposite:
            //        break;
            //    case RefType.PaymentDeposite:
            //        break;
            //    case RefType.InwardStock:
            //        break;
            //    case RefType.OutwardStock:
            //        break;
            //    case RefType.FixedAssetIncrement:
            //        break;
            //    case RefType.FixedAssetDecrement:
            //        break;
            //    case RefType.FixedAssetArmortization:
            //        break;
            //    case RefType.OpeningAccountEntry:
            //        break;
            //    case RefType.GeneralVoucher:
            //        break;
            //    case RefType.CaptitalAllocateVoucher:
            //        break;
            //    case RefType.AccountTranferVourcher:
            //        break;
            //    case RefType.Salary:
            //        break;
            //    case RefType.FixedAssetDictionary:
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected virtual void DeleteGrid()
        {
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        public virtual void AddData()
        {
            if (!ValidAddNew())
                return;

            if ((_lockPresenter.CheckLockDate(PrimaryKeyValue, (int)RefTypeId)) && (((Convert.ToDateTime(GlobalVariable.PostedDate) >= Convert.ToDateTime(GlobalVariable.LockVoucherDateFrom)) && (Convert.ToDateTime(GlobalVariable.PostedDate) <= Convert.ToDateTime(GlobalVariable.LockVoucherDateTo)))))
            {
                XtraMessageBox.Show("Chứng từ hiện tại đang khóa sổ. Bạn phải mở sổ để thêm chứng từ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActionMode = ActionModeVoucherEnum.AddNew;
            ShowFormDetail();
            LoadData();


        }

        protected virtual void DuplicateData()
        {
            ActionMode = ActionModeVoucherEnum.DuplicateVoucher;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Shows the data.
        /// </summary>
        protected virtual void ShowData()
        {
            ActionMode = ActionModeVoucherEnum.None;
            ShowFormDetail();
            LoadData();
        }

        protected virtual bool ValidEdit()
        {
            return true;
        }

        protected virtual bool ValidAddNew()
        {
            return true;
        }

        /// <summary>
        /// Edits the data.
        /// </summary>
        protected virtual void EditData()
        {
            if (!ValidEdit())
                return;

            if ((_lockPresenter.CheckLockDate(PrimaryKeyValue, (int)RefTypeId)))
            {
                XtraMessageBox.Show("Chứng từ hiện tại đang khóa sổ. Bạn phải mở sổ để sửa chứng từ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ActionMode = ActionModeVoucherEnum.Edit;
            ShowFormDetail();
            LoadData();


        }

        /// <summary>
        /// Prints the data.
        /// </summary>
        protected virtual void PrintData()
        {
        }

        /// <summary>
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

        /// <summary>
        /// Calculates the price outward stock.
        /// </summary>
        protected virtual void CalculatePriceOutwardStock()
        {
            //var frm = new FrmXtraReCalOutputInventory();
            //frm.ShowDialog();
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
                        //if (isSummary)
                        //{
                        //    oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                        //    oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                        //    oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        //}
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        //if (isSummary)
                        //{
                        //    oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                        //    //oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                        //    oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        //}
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.ColumnEdit = _repositoryItemDateEdit;
                        //oCol.DisplayFormat.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        //oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }

            }
        }

        protected virtual void LoadGridMasterFilter(List<XtraColumn> listColumn, GridView grdView)
        {
            foreach (var column in listColumn)
                if (grdView.Columns[column.ColumnName] != null)
                    if (column.ColumnVisible)
                    {
                        grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        grdView.Columns[column.ColumnName].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        grdView.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBaseVoucherList"/> class.
        /// </summary>
        public FrmBaseVoucherList()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _lockPresenter = new LockPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the BaseVoucherListUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BaseVoucherListUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            _refTypesPresenter.Display();
            _lockPresenter.Display();
            InitializeLayout();
            InitVariables();
            LoadData();
            SetRowSelected(RowSelected);
            GetRowValueSelected();
            PermissionUseFormMaster();
        }

        /// <summary>
        /// Handles the FocusedRowChanged event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs"/> instance containing the event data.</param>
        private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            ChangeFormDetail();
            GetRowValueSelected();
            var column = gridView.Columns.ColumnByFieldName("RefNo");

            if (column != null)
            {
                var refNo = gridView.GetRowCellValue(e.FocusedRowHandle, column);
                RefNo = (refNo != null) ? refNo.ToString() : "";
            }
            var columnRefId = gridView.Columns.ColumnByFieldName("RefId");

            if (columnRefId != null)
            {
                var refId = gridView.GetRowCellValue(e.FocusedRowHandle, columnRefId);

                if (refId != null)
                {
                    LoadDataIntoGridDetail(refId.ToString());
                }
                else
                {
                    bindingSourceDetail.DataSource = null;
                    //gridDetail.DataSource = bindingSourceDetail.DataSource;
                }
            }
        }

        protected virtual void ChangeFormDetail()
        {

        }

        protected void SetFormDetail(int refType)
        {
            this.RefTypeId = (RefType)refType;
            switch (refType)
            {
                case (int)RefType.BUTransfer:
                    this.FormDetail = nameof(FormBusiness.Estimate.FrmBUTransferDetail);
                    this.NamespaceForm = typeof(FormBusiness.Estimate.FrmBUTransferDetail).Namespace;
                    break;
                case (int)RefType.BUTransferPurchase:
                    this.FormDetail = nameof(FormBusiness.Estimate.FrmBUTransferDetailPurchase);
                    this.NamespaceForm = typeof(FormBusiness.Estimate.FrmBUTransferDetailPurchase).Namespace;
                    break;

                case (int)RefType.CAPayment:
                    this.FormDetail = nameof(FrmCAPaymentDetail);
                    this.NamespaceForm = typeof(FrmCAPaymentDetail).Namespace;
                    break;
                case (int)RefType.CAPaymentInventoryItem:
                    this.FormDetail = nameof(FrmCAPaymentInwardDetail);
                    this.NamespaceForm = typeof(FrmCAPaymentInwardDetail).Namespace;
                    break;
                case (int)RefType.CAPaymentDetailFixedAsset:
                    this.FormDetail = nameof(FrmCAPaymentFixedAssetDetail);
                    this.NamespaceForm = typeof(FrmCAPaymentFixedAssetDetail).Namespace;
                    break;
                case (int)RefType.CAPaymentTreasury:
                    this.FormDetail = nameof(FrmCAPaymentTreasuryDetail);
                    this.NamespaceForm = typeof(FrmCAPaymentTreasuryDetail).Namespace;
                    break;

                case (int)RefType.BAWithDraw:
                    this.FormDetail = nameof(FrmBAWithDrawDetail);
                    this.NamespaceForm = typeof(FrmBAWithDrawDetail).Namespace;
                    break;
                case (int)RefType.BAWithDrawPurchase:
                    this.FormDetail = nameof(FrmBAWithDrawPurchaseDetail);
                    this.NamespaceForm = typeof(FrmBAWithDrawPurchaseDetail).Namespace;
                    break;
                case (int)RefType.BAWithDrawFixedAsset:
                    this.FormDetail = nameof(FrmBAWithDrawFixedAssetDetail);
                    this.NamespaceForm = typeof(FrmBAWithDrawFixedAssetDetail).Namespace;
                    break;

                case (int)RefType.CAReceipt:
                    this.FormDetail = nameof(FrmCAReceiptDetail);
                    this.NamespaceForm = typeof(FrmCAReceiptDetail).Namespace;
                    break;
                case (int)RefType.CAReceiptEstimate:
                    this.FormDetail = nameof(FrmCAReceiptEstimateDetail);
                    this.NamespaceForm = typeof(FrmCAReceiptEstimateDetail).Namespace;
                    break;
                case (int)RefType.CAReceiptTreasury:
                    this.FormDetail = nameof(FrmCAReceiptTreasuryDetail);
                    this.NamespaceForm = typeof(FrmCAReceiptTreasuryDetail).Namespace;
                    break;
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void grdList_DoubleClick(object sender, EventArgs e)
        {
            if (gridView.RowCount == 0)
                return;
            ShowData();
            SetRowAfterUpdate();
            GetRowValueSelected();
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraBars.ItemClickEventArgs"/> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonAddNewItem":
                    AddData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDuplicate":
                    DuplicateData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonEditItem":
                    EditData();
                    SetRowAfterUpdate();
                    GetRowValueSelected();
                    break;
                case "barButtonDeleteItem":
                    var deleteSuccess = false;
                    try
                    {
                        if (Convert.ToDateTime(GlobalVariable.PostedDate) > Convert.ToDateTime(GlobalVariable.LockVoucherDateTo) || Convert.ToDateTime(GlobalVariable.PostedDate) < Convert.ToDateTime(GlobalVariable.LockVoucherDateFrom))
                        {
                            ActionMode = ActionModeVoucherEnum.Delete;
                            var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                                                             ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                DeleteGrid();
                                _audittingLogPresenter.Save();
                                deleteSuccess = true; //LinhMC chạy đến đây là ok rồi
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                            ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //if (RefTypeId != RefType.InwardStock)
                                //{
                                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                //                        ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                            }
                        }
                        else
                        {
                            if ((_lockPresenter.CheckLockDate(PrimaryKeyValue, (int)RefTypeId)))
                            {
                                XtraMessageBox.Show("Chứng từ đang khóa sổ. Bạn phải mở sổ để xóa", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }


                            ActionMode = ActionModeVoucherEnum.Delete;
                            var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                                                             ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                DeleteGrid();
                                _audittingLogPresenter.Save();
                                deleteSuccess = true; //LinhMC chạy đến đây là ok rồi
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                            ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //if (RefTypeId != RefType.InwardStock)
                                //{
                                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                                //                        ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                //                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    }
                    finally
                    {
                        if (deleteSuccess)
                        {
                            LoadData();
                            SetRowSelected();
                            GetRowValueSelected();
                        }
                    }
                    break;
                case "barButtonRefeshItem":
                    LoadData();
                    SetRowSelected();
                    GetRowValueSelected();
                    LoadDataIntoGridDetail(PrimaryKeyValue);
                    break;
                case "barButtonPrintItem":
                    PrintData();
                    break;
                case "barButtonHelpItem":
                    ActionMode = ActionModeVoucherEnum.None;
                    ShowHelp();
                    break;
                case "barButtonCalculatePriceItem":
                    CalculatePriceOutwardStock();
                    break;
            }
            RefreshToolbar();
        }

        #endregion

        /// <summary>
        /// Handles the CustomDrawFooterCell event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FooterCellCustomDrawEventArgs"/> instance containing the event data.</param>
        private void gridView_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName.Contains("AmountOC") || e.Column.FieldName.Contains("Amount"))
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                return;
            }
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
        }

        /// <summary>
        /// Handles the CustomDrawFooterCell event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FooterCellCustomDrawEventArgs"/> instance containing the event data.</param>
        private void gridViewDetail_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName.Contains("AmountOC") || e.Column.FieldName.Contains("Amount"))
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                return;
            }
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;
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

        /// <summary>
        /// Permissions the use form master.
        /// </summary>
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
        }
    }
}
