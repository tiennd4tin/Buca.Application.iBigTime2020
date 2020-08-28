﻿/***********************************************************************
 * <copyright file="BaseTreeListUserControl.cs" company="BUCA JSC">
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
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Report;
using Buca.Application.iBigTime2020.Presenter.System.Lock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Report;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Data;
using DevExpress.XtraTreeList.Nodes;
using SummaryItemType = DevExpress.XtraTreeList.SummaryItemType;


namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList
{
    public partial class FrmBaseTreeList : XtraUserControl, IReportsView, IAudittingLogView, ILockView
    {
        private readonly ReportListPresenter _reportListPresenter;
        private List<ReportListModel> _reportList;
        public readonly LockPresenter _lockPresenter;
        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

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
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        [Category("BaseProperty")]
        public string ReportID { get; set; }

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
        /// Gets or sets the name of the parent field.
        /// </summary>
        /// <value>
        /// The name of the parent field.
        /// </value>
        [Category("BaseProperty")]
        public string ParentFieldName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [expand all].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [expand all]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        public bool ExpandAll { get; set; }

        /// <summary>
        /// Gets or sets the active node.
        /// </summary>
        /// <value>
        /// The active node.
        /// </value>
        public object ActiveNode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [visible button edit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visible button edit]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonEdit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [visible button delete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visible button delete]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonDelete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [visible button find].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [visible button find]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonFind { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [visible button add new].
        /// </summary>
        /// <value>
        /// <c>true</c> if [visible button add new]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        [DefaultValue(true)]
        public bool VisibleButtonAddNew { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        /// <summary>
        /// Gets or sets the message error delete tree has child.
        /// </summary>
        /// <value>The message error delete tree has child.</value>
        [Category("BaseCategory")]
        public string MessageErrorDeleteTreeHasChild { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            Text = FormCaption;
            ActionMode = ActionModeEnum.None;

            barButtonAddNewItem.Visibility = VisibleButtonAddNew == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonEditItem.Visibility = VisibleButtonEdit == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonDeleteItem.Visibility = VisibleButtonDelete == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            barButtonFindItem.Visibility = VisibleButtonFind == false ? BarItemVisibility.Never : BarItemVisibility.Always;
            treeList.OptionsView.ShowSummaryFooter = true;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            try
            {
                treeList.BeginUpdate();
                InitializeTreeMain();
                LoadDataIntoTree();
                LoadGridLayout();
                SetGridNumericFormat();
                SetTreeListNumericFormat();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                treeList.EndUpdate();
            }
            finally
            {
                treeList.EndUpdate();
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
                    if (treeList.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            treeList.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            treeList.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            treeList.Columns[column.ColumnName].Width = column.ColumnWith;
                            treeList.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment =
                                column.Alignment;
                            treeList.Columns[column.ColumnName].UnboundType = (UnboundColumnType) column.ColumnType;
                            treeList.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;

                            if (column.ColumnName.Contains("DebitAmountOC") ||
                                column.ColumnName.Contains("CreditAmountOC"))
                            {
                                treeList.Columns[column.ColumnName].SummaryFooter = SummaryItemType.Sum;
                                treeList.Columns[column.ColumnName].SummaryFooterStrFormat =
                                    GlobalVariable.CurrencyDisplayString;

                            }

                            if (column.ColumnPosition == 1)
                            {
                                treeList.Columns[column.ColumnName].SummaryFooter = SummaryItemType.Count;
                                treeList.Columns[column.ColumnName].SummaryFooterStrFormat = @"Số dòng = {0:n0}";

                            }

                        }

                        else
                                treeList.Columns[column.ColumnName].Visible = false;
                        
                    }
                }

                if (ExpandAll)
                    treeList.ExpandAll();
                else
                    treeList.CollapseAll();

            }
        }

        /// <summary>
        /// Sets the tree list numeric format.
        /// </summary>
        protected virtual void SetTreeListNumericFormat()
        {
            foreach (TreeListColumn oCol in treeList.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        oCol.Format.FormatString = GlobalVariable.CurrencyDisplayString;
                        oCol.Format.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        //oCol.SummaryFooter = (SummaryItemType)DevExpress.Data.SummaryItemType.Sum;
                        //oCol.SummaryFooterStrFormat = GlobalVariable.CurrencyDisplayString;
                        break;
                    case UnboundColumnType.Integer:
                        oCol.Format.FormatString = GlobalVariable.NumericDisplayString;
                        oCol.Format.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                        break;
                    case UnboundColumnType.DateTime:
                        oCol.Format.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.Format.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the tree main.
        /// </summary>
        private void InitializeTreeMain()
        {
            treeList.ParentFieldName = ParentFieldName;
            treeList.KeyFieldName = TablePrimaryKey;
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        /// <param name="nodeHandler">The node handler.</param>
        public void SetRowSelected(int nodeHandler = 0)
        {
            treeList.OptionsSelection.EnableAppearanceFocusedRow = true;
            treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (treeList.Nodes.Count > 0)
                treeList.FocusedNode = treeList.Nodes[nodeHandler];
            else
                GetRowValueSelected();
        }

        /// <summary>
        /// Gets the form detail.
        /// LinhMC comment
        /// </summary>
        /// <returns></returns>
        //protected virtual FrmXtraBaseTreeDetail GetFormDetail()
        //{
        //    try
        //    {
        //        Type typeOfForm = Assembly.GetExecutingAssembly().GetType(NamespaceForm + "." + FormDetail);
        //        return typeOfForm != null ? (FrmXtraBaseTreeDetail)Activator.CreateInstance(typeOfForm) : null;
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected virtual FrmXtraBaseTreeDetail GetFormDetail()
        {
            try
            {
                return new FrmXtraBaseTreeDetail();
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
        private void SetRowAfterUpdate()
        {
            if (PrimaryKeyValue == null)
                return;
            if (treeList.Nodes.Count > 0)
                treeList.FocusedNode = treeList.FindNodeByKeyID(PrimaryKeyValue);
            else
                SetRowSelected();
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
            barButtonEditItem.Enabled = treeList.Nodes.Count > 0;
            barButtonDeleteItem.Enabled = treeList.Nodes.Count > 0;
            barButtonPrintItem.Enabled = treeList.Nodes.Count > 0;
            barButtonFindItem.Enabled = treeList.Nodes.Count > 0;
        }

        #endregion

        #region LockDate

        public string Content { get; set; }

        public string LockDate { get; set; }

        public bool IsLock { get; set; }

        #endregion

        #region Functions overrides

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected virtual void LoadDataIntoTree()
        {
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected virtual void DeleteTree()
        {

        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        protected virtual void AddData()
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
            if (!ValidEdit())
                return;
            ShowFormDetail();
            LoadData();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected void DeleteItem()
        {
            try
            {
                ActionMode = ActionModeEnum.Delete;
                var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"), ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if (treeList.FindNodeByKeyID(PrimaryKeyValue).HasChildren)
                        ShowErrorDeleteParent();
                    else
                    {
                        DeleteTree();
                        _audittingLogPresenter.Save();
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
                            ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                LoadData();
                SetRowSelected();
            }
        }

        /// <summary>
        /// Shows the error delete parent.
        /// </summary>
        protected virtual void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(MessageErrorDeleteTreeHasChild, ResourceHelper.GetResourceValueByName("ResDeleteCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (_reportList != null)
                {
                    reportHelper.ReportLists = _reportList;
                    reportHelper.PrintPreviewReport(null, ReportID, false);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Có lỗi xảy ra trong quá trình truy vấn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
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
        /// Shows the form detail.
        /// </summary>
        protected virtual void ShowFormDetail()
        {
            try
            {
                using (var frmDetail = GetFormDetail())
                {
                    if (frmDetail != null)
                    {
                        frmDetail.KeyFieldName = TablePrimaryKey;
                        frmDetail.ParentName = ParentFieldName;
                        frmDetail.ActionMode = ActionMode;
                        frmDetail.HelpTopicId = HelpTopicId;
                        frmDetail.KeyValue = frmDetail.ActionMode == ActionModeEnum.AddNew ? null : PrimaryKeyValue;
                        frmDetail.HasChildren = PrimaryKeyValue != null && treeList.FindNodeByKeyID(PrimaryKeyValue).HasChildren;
                        frmDetail.CurrentNode = treeList.Nodes.Count > 0 ? ActiveNode : null;
                        frmDetail.PostKeyValue += FrmDetail_PostKey;
                        if (frmDetail.ShowDialog() == DialogResult.OK)
                        { }
                    }
                }
            }
            catch (Exception ex) {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// Valids the edit.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidEdit()
        {
            return true;
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        protected virtual void GetRowValueSelected()
        {
            try
            {
                if (ActionMode == ActionModeEnum.None || ActionMode == ActionModeEnum.Delete)
                    PrimaryKeyValue = treeList.Nodes.Count > 0 ? treeList.FocusedNode[treeList.KeyFieldName].ToString() : null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// Sets the grid numeric format.
        /// </summary>
        protected virtual void SetGridNumericFormat()
        {
            foreach (var column in treeList.Columns)
            {
                var treeColumn = column as TreeListColumn;
                if (treeColumn != null && !treeColumn.Visible)
                    continue;
                if (treeColumn != null)
                    switch (treeColumn.UnboundType)
                    {

                        case UnboundColumnType.Decimal:
                            treeColumn.Format.FormatString = GlobalVariable.CurrencyDisplayString;
                            treeColumn.Format.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                            treeColumn.SummaryFooter = SummaryItemType.Sum;
                            treeColumn.SummaryFooterStrFormat = GlobalVariable.CurrencyDisplayString;
                            break;
                        case UnboundColumnType.Integer:
                            treeColumn.Format.FormatString = GlobalVariable.NumericDisplayString;
                            treeColumn.Format.Format = Thread.CurrentThread.CurrentCulture.NumberFormat;
                            break;
                        case UnboundColumnType.DateTime:
                            treeColumn.Format.FormatString = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            treeColumn.Format.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                            break;
                    }
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBaseTreeList"/> class.
        /// </summary>
        public FrmBaseTreeList()
        {
            InitializeComponent();
            _reportListPresenter = new ReportListPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _lockPresenter = new LockPresenter(this);
          
        }

        /// <summary>
        /// Handles the Load event of the BaseTreeListUserControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BaseTreeListUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            InitializeLayout();
            LoadData();
            SetRowSelected(RowSelected);
            RefreshToolbar();
            treeList.Focus();
            PermissionUseFormMaster();
        }

        /// <summary>
        /// Handles the AfterFocusNode event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.NodeEventArgs"/> instance containing the event data.</param>
        private void treeList_AfterFocusNode(object sender, NodeEventArgs e)
        {

        }

        /// <summary>
        /// Handles the DoubleClick event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            if (treeList.Nodes.Count == 0)
                return;
            EditData();
            SetRowAfterUpdate();
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
                    break;
                case "barButtonEditItem":
                    EditData();
                    SetRowAfterUpdate();
                    break;
                case "barButtonDeleteItem":
                    DeleteItem();
                    break;
                case "barButtonRefeshItem":
                    LoadData();
                    SetRowSelected();
                    break;
                case "barButtonPrintItem":
                    PrintData();
                    break;
                case "barButtonHelpItem":
                    ShowHelp();
                    break;
                case "barButtonFindItem":
                    treeList.ShowFindPanel();
                    break;
            }
            RefreshToolbar();
        }

        /// <summary>
        /// Handles the FocusedNodeChanged event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.FocusedNodeChangedEventArgs"/> instance containing the event data.</param>
        private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            var node = e.Node;
            if (node == null || node is TreeListAutoFilterNode)
                return;
            GetRowValueSelected();
            ActiveNode = treeList.GetDataRecordByNode(node);
        }

        /// <summary>
        /// Handles the BeforePopup event of the popupMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void popupMenu_BeforePopup(object sender, CancelEventArgs e)
        {
            Point p = treeList.PointToClient(MousePosition);
            TreeListHitInfo hitInfo = treeList.CalcHitInfo(p);

            if (hitInfo.HitInfoType != HitInfoType.Row && hitInfo.HitInfoType != HitInfoType.Cell && hitInfo.HitInfoType != HitInfoType.Empty)
            {
                e.Cancel = true;
            }
        }

        #region IReportView Members

        /// <summary>
        /// Gets or sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
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

        /// <summary>
        ///     Handles the NodeCellStyle event of the treeDepartment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///     The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs" /> instance containing the
        ///     event data.
        /// </param>
        private void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            e.Column.ShowButtonMode = ShowButtonModeEnum.ShowOnlyInEditor;
            e.Appearance.Font = e.Node.HasChildren 
                ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold)
                : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

        public event FilterNodeEventHandler TreeListFilterNode;

        private void treeList_FilterNode(object sender, FilterNodeEventArgs e)
        {
            if (TreeListFilterNode != null)
                TreeListFilterNode.Invoke(sender, e);
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
                    foreach (BarButtonItem barToolsItemLink in bar1.Manager.Items)
                    {
                        CommonFunction.CheckPermissionUseFormMaster(barToolsItemLink, userFeaturePermisions.ToList());
                    }
                }
                else
                {
                    bar1.Visible = false;
                }
            }
        }

        private void treeList_CustomDrawFooterCell(object sender, CustomDrawFooterCellEventArgs e)
        {
            if (e.Column.FieldName.Contains("DebitAmountOC") || e.Column.FieldName.Contains("CreditAmountOC"))
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
                return;
            }
            e.Appearance.TextOptions.HAlignment = HorzAlignment.Near;

        }
    }
}
