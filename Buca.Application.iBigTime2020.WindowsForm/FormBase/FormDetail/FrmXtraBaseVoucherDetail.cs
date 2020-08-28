/***********************************************************************
 * <copyright file="FrmXtraBaseVoucherDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date: 23/09/2014  Author: ThangND  Description: Sửa lại chức năng xóa chứng từ
 * 27/8/2015: LINHMC   Đưa phần nhật ký vào form base ghi lại thao tác người dùng
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoNumber;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CalculateClosing;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Report;
using Buca.Application.iBigTime2020.Presenter.System.Lock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Report;
using Buca.Application.iBigTime2020.View.System;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormUtility;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Report;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraRichEdit;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using System.Diagnostics;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;

using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using DevExpress.XtraRichEdit.API.Word;
using System.Runtime.InteropServices;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail
{
    /// <summary>
    /// FrmXtraBaseVoucherDetail
    /// </summary>
    public partial class FrmXtraBaseVoucherDetail : XtraForm, IAutoIDView, IReportsView, ICalculateClosingView,
        IAudittingLogView, IRefTypesView,
        ILockView, ICurrenciesView, IAccountingObjectCategoriesView

    {
        #region LockDate

        public Dictionary<string, GridView> dsView { get; set; }
        public string Content { get; set; }

        public string LockDate { get; set; }

        public bool IsLock { get; set; }
        //ColumnName số tiền quy đổi
        public string SAmountOCEx { get; set; }
        //ColumnName số tiền
        public string SAmountEx { get; set; }
        //ColumnName số tiền quy đổi
        public string SAmountOCExParallel { get; set; }
        //ColumnName số tiền
        public string SAmountExParallel { get; set; }

        public DevExpress.XtraGrid.Views.Grid.GridView grdViewParallel;
        protected static IModel Model { get; private set; }
        #endregion

        #region AutoNumber properties

        /// <summary>
        /// Gets or sets the reference type category identifier.
        /// </summary>
        /// <value>The reference type category identifier.</value>
        public int RefTypeCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the reference type category.
        /// </summary>
        /// <value>The name of the reference type category.</value>
        public string RefTypeCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the length of value.
        /// </summary>
        /// <value>The length of value.</value>
        public int LengthOfValue { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        // set giá trị tự động cho lưới theo master
        public string AutoAccountingObjectId { get; set; }

        public string AutoBankId { get; set; }

        public string AutoProjectId { get; set; }


        #endregion

        #region IViews

        internal RepositoryItemGridLookUpEdit _gridLookUpEditCurrency;
        private GridView _gridLookUpEditCurrencyView;
        private List<CurrencyModel> _currencies;

        protected RepositoryItemGridLookUpEdit GridLookUpEditRefType;
        protected GridView GridLookUpEditRefTypeView;
        private List<RefTypeModel> _refTypes;

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
                        HideSelection = true,
                        PopupFormWidth = 200
                    };
                    GridLookUpEditRefTypeView.PopulateColumns();

                    GridLookUpEditRefType.DataSource = value;
                    GridLookUpEditRefTypeView.PopulateColumns(value);
                    GridLookUpEditRefTypeView.OptionsView.ShowIndicator = false;
                    _refTypes = value.ToList();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeId",
                        ColumnVisible = false,
                        ColumnCaption = "Mã CT",
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeName",
                        ColumnCaption = "Tên loại CT",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 200,
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultTaxAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false });
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
                    GridLookUpEditRefTypeView.BestFitColumns();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<CurrencyModel> Currencies
        {
            get { return _currencies; }
            set
            {
                try
                {
                    _gridLookUpEditCurrencyView = new GridView();
                    _gridLookUpEditCurrencyView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCurrency = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCurrencyView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCurrency.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditCurrency.View.BestFitColumns();

                    _gridLookUpEditCurrency.DataSource = value;
                    _gridLookUpEditCurrencyView.PopulateColumns(value);
                    _currencies = value.ToList();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Mã loại tiền",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CurrencyName",
                        ColumnCaption = "Tên loại tiền",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditCurrency.DisplayMember = "CurrencyCode";
                    _gridLookUpEditCurrency.ValueMember = "CurrencyCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            //get; set;
            //get
            //{
            //    var formCaption = "";
            //    var firstOrDefault = RefTypes.FirstOrDefault(r => r.RefTypeId == (int)BaseRefTypeId);
            //    if (firstOrDefault != null)
            //    {
            //        var refTypeName = firstOrDefault.RefTypeName;
            //        formCaption = refTypeName;
            //    }
            //    return (string.IsNullOrEmpty(formCaption) ? "" : formCaption);
            //}
            //set { }
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
                        return 5; //Nhân bản
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
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) +
                               " - SỐ CT: " +
                               (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) +
                               " - SỐ CT: " +
                               (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) +
                               " - SỐ CT: " +
                               (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.None:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) +
                               " - SỐ CT: " +
                               (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    default:
                        return "NHÂN BẢN " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) +
                               " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                        //case ActionModeVoucherEnum.AddNew:
                        //    return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                        //           KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                        //case ActionModeVoucherEnum.Edit:
                        //    return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                        //           KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                        //case ActionModeVoucherEnum.Delete:
                        //    return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                        //           KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                        //case ActionModeVoucherEnum.None:
                        //    return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                        //           KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                        //default:
                        //    return "NHÂN BẢN " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                        //           KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
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
        //Kiểm tra nếu là load dữ liệu lên thì ko tính lại số tiền quy đổi
        public bool checkLoad = false;
        private readonly AccountingObjectCategoriesPresenter _accountingObjectCategoryPresenter;

        private readonly LockPresenter _lockPresenter;
        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _ref types presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

        private readonly CurrenciesPresenter _currenciesPresenter;

        /// <summary>
        /// The _report list presenter
        /// </summary>
        private ReportListPresenter _reportListPresenter;

        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;

        /// <summary>
        /// The _navigation state
        /// </summary>
        private EnumNavigationStatus _navigationState;

        /// <summary>
        /// The _type of model
        /// </summary>
        private Type _typeOfModel;

        /// <summary>
        /// The _calculate closing presenter
        /// </summary>
        private CalculateClosingPresenter _calculateClosingPresenter;

        /// <summary>
        /// The master binding source
        /// </summary>
        public BindingSource MasterBindingSource;

        /// <summary>
        /// The _action mode
        /// </summary>
        private ActionModeVoucherEnum _actionMode;

        /// <summary>
        /// The system date
        /// </summary>
        //protected DateTime SystemDate;

        /// <summary>
        /// The base posted date
        /// </summary>
        protected DateTime BasePostedDate;

        /// <summary>
        /// Gets or sets the currency current.
        /// </summary>
        /// <value>
        /// The currency current.
        /// </value>
        protected string CurrencyCurrent { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate decimal digits.
        /// </summary>
        /// <value>
        /// The exchange rate decimal digits.
        /// </value>
        protected string ExchangeRateDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the action mode.
        /// </summary>
        /// <value>
        /// The action mode.
        /// </value>
        public ActionModeVoucherEnum ActionMode
        {
            get { return _actionMode; }
            set
            {
                _actionMode = value;

                switch (_actionMode)
                {
                    case ActionModeVoucherEnum.None:
                        Text = FormCaption;
                        SetEnableToolbarControl(false);
                        break;
                    case ActionModeVoucherEnum.Edit:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResEditText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                    case ActionModeVoucherEnum.AddNew:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                    case ActionModeVoucherEnum.DuplicateVoucher:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                }
            }
        }

        /// <summary>
        /// The key for send
        /// </summary>
        protected string _keyForSend;

        /// <summary>
        /// The _auto number presenter
        /// </summary>
        private readonly AutoIDPresenter _autoIDPresenter;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>
        /// The key value.
        /// </value>
        public string KeyValue { get; set; }

        /// <summary>
        /// Gets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string BaseRefNo { get; set; }

        /// <summary>
        /// The is copy row
        /// </summary>
        protected bool IsCopyRow;

        /// <summary>
        /// Gets or sets the automatic business model.
        /// </summary>
        /// <value>The automatic business model.</value>
        public AutoBusinessModel AutoBusinessModel { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        [Category("BaseProperty")]
        public RefType BaseRefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference type using display report.
        /// </summary>
        /// <value>The reference type using display report.</value>
        [Category("BaseProperty")]
        public RefType RefTypeUsingDisplayReport { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the summary in column.
        /// </summary>
        /// <value>
        /// The summary in column.
        /// </value>
        [Category("BaseProperty")]
        public string SummaryInColumn { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        [Category("BaseProperty")]
        public string ReportID { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        [Category("BaseProperty")]
        public long RefID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is in visible popup menu grid].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is in visible popup menu grid]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        public bool IsInVisiblePopupMenuGrid { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display accounting.
        /// </summary>
        /// <value><c>true</c> if this instance is display accounting; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [Description("Cho phép ẩn tab hạch toán")]
        public bool IsDisplayAccounting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display accounting detail.
        /// </summary>
        /// <value><c>true</c> if this instance is display accounting detail; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [Description("Cho phép ẩn tab thống kê")]
        public bool IsDisplayAccountingDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display tax.
        /// </summary>
        /// <value><c>true</c> if this instance is display tax; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [Description("Cho phép ẩn tab thuế")]
        public bool IsDisplayTax { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is display inventory item.
        /// </summary>
        /// <value><c>true</c> if this instance is display inventory item; otherwise, <c>false</c>.</value>
        [Category("BaseProperty")]
        [Description("Cho phép ẩn tab hàng tiền")]
        public bool IsDisplayInventoryItem { get; set; }

        /// <summary>
        /// Gets or sets the model in grid detail.
        /// </summary>
        /// <value>
        /// The model in grid detail.
        /// </value>
        public string ModelInGridDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace of model.
        /// </summary>
        /// <value>
        /// The namespace of model.
        /// </value>
        public string NamespaceOfModel { get; set; }

        /// <summary>
        /// Gets or sets the account lists.
        /// LinhMC: thằng này được tạo ra nhằm mục đích, ở các form kế thừa sẽ gán giá trị của member Accounts vào AccountLists
        /// Dựa vào AccountLists sẽ lấy được AccountModel, từ AccountModel sẽ lấy các điều kiện ràng buộc chi tiết của tài khoản
        /// Từ các điều kiện này sẽ dùng để valid dữ liệu nhập ở phần GridDetail.
        /// </summary>
        /// <value>
        /// The account lists.
        /// </value>
        public IList<AccountModel> AccountLists { get; set; }



        // public Dictionary<string, GridView> dsView = new Dictionary<string, GridView>();

        #endregion

        #region calulateClosing properties

        /// <summary>
        /// Gets or sets the Account Id.
        /// </summary>
        /// <value>
        /// The Account Id.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the Account Code.
        /// </summary>
        /// <value>
        /// The Account Code.
        /// </value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the Account Name.
        /// </summary>
        /// <value>
        /// The Account Name.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the Parent Id.
        /// </summary>
        /// <value>
        /// The Parent Id.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the Closing Amount.
        /// </summary>
        /// <value>
        /// The Closing Amount.
        /// </value>
        public decimal ClosingAmount { get; set; }

        #endregion
        #region Functions

        /// <summary>
        /// Lấy tổng số tối đa có thể chi có thể kết hợp nguồn
        /// </summary>
        /// <param name="paymentaccountCode">The paymentaccount code.</param>
        /// <param name="paymentBudgetSourceCode">The payment budget source code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateAmountPayment(string paymentaccountCode, string paymentBudgetSourceCode,
            string toDate)
        {

            if (!GlobalVariable.IsPaymentNegativeFund && !GlobalVariable.IsDepositeNegavtiveFund &&
                !GlobalVariable.IsPaymentNegativeBudgetSource)
            {
                if (!string.IsNullOrEmpty(paymentBudgetSourceCode))
                {
                    _calculateClosingPresenter.Display(paymentaccountCode,
                        "BudgetSourceCode = " + paymentBudgetSourceCode, CurrencyCurrent, toDate,
                        GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
                }
                else
                {
                    _calculateClosingPresenter.Display(paymentaccountCode, " 1 = 1 ", CurrencyCurrent, toDate,
                        GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
                }
            }
            else
            {
                ClosingAmount = decimal.MaxValue;
            }
        }

        /// <summary>
        /// Gets the calculate amount payment.
        /// </summary>
        /// <param name="cashaccountCode">The paymentaccount code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateCashBalance(string cashaccountCode, string toDate)
        {
            if (!GlobalVariable.IsPaymentNegativeFund)
            {
                _calculateClosingPresenter.Display(cashaccountCode, " 1 = 1 ", CurrencyCurrent, toDate,
                    GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Gets the calculate deposit balance.
        /// </summary>
        /// <param name="cashaccountCode">The cashaccount code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateDepositBalance(string cashaccountCode, string toDate)
        {

            if (!GlobalVariable.IsDepositeNegavtiveFund)
            {
                _calculateClosingPresenter.Display(cashaccountCode, " 1 = 1 ", CurrencyCurrent, toDate,
                    GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Gets the calculate capital balance.
        /// </summary>
        /// <param name="cashaccountCode">The cashaccount code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateCapitalBalance(string cashaccountCode, string budgetSourceCode, string toDate)
        {
            if (!GlobalVariable.IsPaymentNegativeBudgetSource)
            {
                _calculateClosingPresenter.Display(cashaccountCode, "BudgetSourceCode = " + budgetSourceCode,
                    CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"),
                    (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            ExchangeRateDecimalDigits = GlobalVariable.ExchangeRateDecimalDigits;
            BasePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            tabAccounting.PageVisible = IsDisplayAccounting;
            tabAccountingDetail.PageVisible = IsDisplayAccountingDetail;
            tabTax.PageVisible = IsDisplayTax;
            tabInventoryItem.PageVisible = IsDisplayInventoryItem;
            if (bindingSourceDetail != null && bindingSourceDetail.DataSource != null)
                bindingSourceDetail.DataSource = null;

            if (bindingSourceDetailByTax != null && bindingSourceDetailByTax.DataSource != null)
                bindingSourceDetailByTax.DataSource = null;

            if (bindingSourceDetailParallel != null && bindingSourceDetailParallel.DataSource != null)
                bindingSourceDetailParallel.DataSource = null;

            //grdAccountingView.OptionsView.ShowFooter = true;
            InitControls();

        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            if (PostKeyValue != null)
                PostKeyValue(this, _keyForSend);
        }

        /// <summary>
        /// Generateds the reference no.
        /// </summary>
        protected void GeneratedBaseRefNo()
        {
            //lay ra ma so voucher theo reftype
            BaseRefNo = "";
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            {
                var refTypeId = (int)BaseRefTypeId;
                if (refTypeId == (int)RefType.BUTransferFixedAsset || refTypeId == (int)RefType.BAWithDrawFixedAsset || refTypeId == (int)RefType.PUInvoiceFixedAsset || refTypeId == (int)RefType.FAIncrementDecrement)
                {
                    refTypeId = (int)RefType.CAPaymentDetailFixedAsset;
                }
                _autoIDPresenter.DisplayByRefType(refTypeId);

                if (!String.IsNullOrEmpty(Prefix))
                {
                    BaseRefNo += Prefix;
                }
                //--------------------------------------------------------
                //LinhMC: 29/11/2014
                //Thêm hàm kiểm tra nếu chọn tiền hạch toán thì lấy giá trị Value, ngược lại lấy giá trị ValueLocalCurency
                //Theo yêu cầu nhảy số tự động theo 2 loại tiền của Thẩm kế
                //-------------------------------------------------------------//
                if (Value >= 0)
                {
                    for (var i = 0; i < (LengthOfValue - ((int)Value).ToString().Length); i++)
                        BaseRefNo += "0";
                    BaseRefNo += ((int)Value);
                }
                if (!String.IsNullOrEmpty(BaseRefNo))
                    txtRefNo.Text = BaseRefNo;
            }
        }

        /// <summary>
        /// Lấy số chứng từ tự động dành riêng cho chứng từ chung
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        protected void GeneratedGetBaseRefNo(string currencyCode)
        {
            //lay ra ma so voucher theo reftype
            BaseRefNo = "";
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            {
                _autoIDPresenter.DisplayByRefType((int)BaseRefTypeId);

                if (!String.IsNullOrEmpty(Prefix))
                {
                    BaseRefNo += Prefix;
                }

                if (Value >= 0)
                {
                    for (var i = 0; i < (LengthOfValue - ((int)Value).ToString().Length); i++)
                        BaseRefNo += "0";
                    BaseRefNo += ((int)Value);
                }
                if (!String.IsNullOrEmpty(BaseRefNo))
                    txtRefNo.Text = BaseRefNo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyValue">The key value.</param>
        public delegate void EventPostKeyHandler(object sender, string keyValue);

        /// <summary>
        /// The key value
        /// </summary>
        public event EventPostKeyHandler PostKeyValue;

        /// <summary>
        /// Loads the grid detail layout.
        /// </summary>
        protected virtual void LoadGridDetailLayout()
        {
            if (ColumnsCollection == null)
                return;
            foreach (var column in ColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdAccountingView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdAccountingView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdAccountingView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdAccountingView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    //dung de dinh dang so theo kieu du lieu
                    if (column.IsSummaryText)
                    {
                        grdAccountingView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdAccountingView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                            Properties.Resources.SummaryText;
                    }
                }
                else
                    grdAccountingView.Columns[column.ColumnName].Visible = false;
            }
        }

        /// <summary>
        /// Sets the enable toolbar control.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected void SetEnableToolbarControl(bool isEnable)
        {
            barButtonAddNewItem.Enabled = !isEnable;
            barButtonDeleteItem.Enabled = !isEnable;
            barButtonEditItem.Enabled = !isEnable;
            barButtonFirstItem.Enabled = !isEnable;
            barButtonPreviousItem.Enabled = !isEnable;
            barButtonNextItem.Enabled = !isEnable;
            barButtonLastItem.Enabled = !isEnable;
            if (BaseRefTypeId == RefType.GLVoucherList)// TinTV: Ẩn nút in ở chứng từ ghi sổ
            {
                barButtonPrintItem.Enabled = false;
            }
            else
                barButtonPrintItem.Enabled = !isEnable;
            barButtonRefeshItem.Enabled = !isEnable;
            barButtonCancelItem.Enabled = isEnable;
            barButtonSaveItem.Enabled = isEnable;
            barButtonAddNewRowItem.Enabled = isEnable;
            barButtonDuplicateItem.Enabled = !isEnable;
            barButtonDeleteRowItem.Enabled = isEnable;
            barButtonCopyRow.Enabled = isEnable;

            //edit by thangnd; 20/03/2014
            EnableControlsInGroup(groupObject, isEnable);
            EnableControlsInGroup(groupVoucher, isEnable);

            SetEnableGroupBox(isEnable); // su dung cho cac form thua ke

            grdAccountingView.OptionsBehavior.Editable = isEnable;
            grdAccountingView.OptionsBehavior.ReadOnly = !isEnable;
            grdAccountingView.FocusRectStyle = DrawFocusRectStyle.None;
            grdAccountingView.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdAccountingView.OptionsView.NewItemRowPosition = !isEnable
                ? NewItemRowPosition.None
                : NewItemRowPosition.Bottom;

            grdAccountingDetailView.OptionsBehavior.Editable = isEnable;
            grdAccountingDetailView.OptionsBehavior.ReadOnly = !isEnable;
            grdAccountingDetailView.FocusRectStyle = DrawFocusRectStyle.None;
            grdAccountingDetailView.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdAccountingDetailView.OptionsView.NewItemRowPosition = !isEnable
                ? NewItemRowPosition.None
                : NewItemRowPosition.Bottom;

            grdTaxView.OptionsBehavior.Editable = isEnable;
            grdTaxView.OptionsBehavior.ReadOnly = !isEnable;
            grdTaxView.FocusRectStyle = DrawFocusRectStyle.None;
            grdTaxView.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdTaxView.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;

            grdDetailByInventoryItemView.OptionsBehavior.Editable = isEnable;
            grdDetailByInventoryItemView.OptionsBehavior.ReadOnly = !isEnable;
            grdDetailByInventoryItemView.FocusRectStyle = DrawFocusRectStyle.None;
            grdDetailByInventoryItemView.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdDetailByInventoryItemView.OptionsView.NewItemRowPosition = !isEnable
                ? NewItemRowPosition.None
                : NewItemRowPosition.Bottom;

            gridViewMaster.OptionsBehavior.Editable = isEnable;
            gridViewMaster.OptionsBehavior.ReadOnly = !isEnable;
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            switch (ActionMode)
            {
                case ActionModeVoucherEnum.None:
                    SetEnableToolbarControl(false);
                    break;
                case ActionModeVoucherEnum.Edit:
                case ActionModeVoucherEnum.AddNew:
                    SetEnableToolbarControl(true);
                    break;
                case ActionModeVoucherEnum.DuplicateVoucher:
                    SetEnableToolbarControl(true);
                    break;
            }
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        public void ReloadGrid()
        {
            checkLoad = false;
            ReloadParallelGrid();
        }
        protected virtual void ReloadParallelGrid()
        {

        }

        /// <summary>
        /// Refreshes the navigation button.
        /// </summary>
        protected virtual void RefreshNavigationButton()
        {
            switch (_navigationState)
            {
                case EnumNavigationStatus.FirstPosition:
                    barButtonFirstItem.Enabled = false;
                    barButtonPreviousItem.Enabled = false;
                    barButtonNextItem.Enabled = true;
                    barButtonLastItem.Enabled = true;
                    break;
                case EnumNavigationStatus.LastPosition:
                    barButtonFirstItem.Enabled = true;
                    barButtonPreviousItem.Enabled = true;
                    barButtonNextItem.Enabled = false;
                    barButtonLastItem.Enabled = false;
                    break;
                case EnumNavigationStatus.InsidePosition:
                    barButtonFirstItem.Enabled = true;
                    barButtonPreviousItem.Enabled = true;
                    barButtonNextItem.Enabled = true;
                    barButtonLastItem.Enabled = true;
                    break;
                case EnumNavigationStatus.EmptyPostion:
                case EnumNavigationStatus.OnlyOneRow:
                    barButtonFirstItem.Enabled = false;
                    barButtonPreviousItem.Enabled = false;
                    barButtonNextItem.Enabled = false;
                    barButtonLastItem.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the state of the navigation.
        /// </summary>
        /// <value>
        /// The state of the navigation.
        /// </value>
        private EnumNavigationStatus NavigationState
        {
            get
            {
                if (MasterBindingSource == null)
                    _navigationState = EnumNavigationStatus.CloseForm;
                else
                {
                    var rowCount = BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count;
                    switch (rowCount)
                    {
                        case 0:
                            _navigationState = EnumNavigationStatus.EmptyPostion;
                            break;
                        case 1:
                            _navigationState = EnumNavigationStatus.OnlyOneRow;
                            break;
                        default:
                            var iCurrentPosition =
                                BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                            if (iCurrentPosition == 0)
                            {
                                _navigationState = EnumNavigationStatus.FirstPosition;
                            }
                            else if (iCurrentPosition == rowCount - 1)
                            {
                                _navigationState = EnumNavigationStatus.LastPosition;
                            }
                            else
                                _navigationState = EnumNavigationStatus.InsidePosition;
                            break;
                    }
                }

                return _navigationState;
            }
            set { _navigationState = value; }
        }

        /// <summary>
        /// The _navigation state before delete
        /// </summary>
        private EnumNavigationStatus _navigationStateBeforeDelete;

        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        /// <value>
        /// The current position.
        /// </value>
        public int CurrentPosition
        {
            get
            {
                if (DesignMode)
                    return 0;
                return BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
            }
            set
            {
                if (DesignMode)
                    return;
                if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit ||
                    ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                    return;
                BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = value;
                switch (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count)
                {
                    case 0:
                        NavigationState = EnumNavigationStatus.EmptyPostion;
                        break;
                    case 1:
                        NavigationState = EnumNavigationStatus.OnlyOneRow;
                        break;
                    default:
                        if (value == 0)
                        {
                            NavigationState = EnumNavigationStatus.FirstPosition;
                            break;
                        }
                        if (value == BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count - 1)
                        {
                            NavigationState = EnumNavigationStatus.LastPosition;
                            break;
                        }
                        NavigationState = EnumNavigationStatus.InsidePosition;
                        break;
                }
                RefreshNavigationButton();
            }
        }

        /// <summary>
        /// Moves the first voucher.
        /// </summary>
        protected virtual void MoveFirstVoucher()
        {
            try
            {
                if (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = 0;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition <= 0
                        ? EnumNavigationStatus.FirstPosition
                        : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the previous voucher.
        /// </summary>
        protected virtual void MovePreviousVoucher()
        {
            try
            {
                if (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position -= 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition <= 0
                        ? EnumNavigationStatus.FirstPosition
                        : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the next voucher.
        /// </summary>
        protected virtual void MoveNextVoucher()
        {
            try
            {
                if (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position += 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition >=
                                      BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count - 1
                        ? EnumNavigationStatus.LastPosition
                        : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the last voucher.
        /// </summary>
        protected virtual void MoveLastVoucher()
        {
            try
            {
                var iRowCount = BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count;
                if (iRowCount > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = iRowCount - 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = EnumNavigationStatus.LastPosition;
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    KeyValue = null;
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets the numeric format control.
        /// LinhMC bo sung them dieu kien: 
        /// repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.ExchangeRateDecimalDigits)/ int.Parse(DBOptionHelper.CurrencyDecimalDigits);
        /// mục đích của thằng này là để làm tròn đúng số thập phân như định dạng khi người dùng nhấn công cụ tính toán
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible)
                    continue;
                switch (oCol.UnboundType)
                {

                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
                        }

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
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        repositoryDateEdit.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                        repositoryDateEdit.Mask.EditMask = @"dd/MM/yyyy";
                        repositoryDateEdit.DisplayFormat.FormatType = FormatType.DateTime;
                        repositoryDateEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryDateEdit;

                        //oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        //oCol.DisplayFormat.FormatType = FormatType.DateTime;
                        //oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the numeric format grid band.
        /// </summary>
        /// <param name="bandedGridView">The banded grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatGridBand(BandedGridView bandedGridView, bool isSummary)
        {
            //Get format data from db to format grid control
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (var oCol in bandedGridView.Columns.Cast<GridColumn>().Where(oCol => oCol.Visible))
            {
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        //LinhMC thêm 24/8/2015:
                        repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
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
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        oCol.ColumnEdit.DisplayFormat.FormatString = "dd/MM/yyyy";
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Enables the controls in group.
        /// </summary>
        /// <param name="groupControl">The group control.</param>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected void EnableControlsInGroup(GroupControl groupControl, bool isEnable)
        {
            foreach (var control in groupControl.Controls)
            {
                if (control.GetType() == typeof(ButtonEdit))
                {
                    ((ButtonEdit)control).Properties.ReadOnly = !isEnable;
                    for (int i = 0; i < ((ButtonEdit)control).Properties.Buttons.Count; i++)
                    {
                        ((ButtonEdit)control).Properties.Buttons[i].Enabled = isEnable;
                    }

                    ((ButtonEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(TextEdit))
                {
                    ((TextEdit)control).Properties.ReadOnly = !isEnable;
                    ((TextEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(DateEdit))
                {

                    ((DateEdit)control).Properties.AppearanceDropDownHeader.ForeColor = Color.Black;
                    ((DateEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((DateEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                    ((DateEdit)control).Properties.ReadOnly = !isEnable;

                    for (int i = 0; i < ((DateEdit)control).Properties.Buttons.Count; i++)
                    {
                        ((DateEdit)control).Properties.Buttons[i].Enabled = isEnable;
                    }

                    ((DateEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((DateEdit)control).Properties.ShowDropDown = (!isEnable)
                        ? ShowDropDown.Never
                        : ShowDropDown.SingleClick;


                }
                if (control.GetType() == typeof(LookUpEdit))
                {
                    ((LookUpEdit)control).Properties.ReadOnly = !isEnable;
                    ((LookUpEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((LookUpEdit)control).Properties.ShowDropDown = (!isEnable)
                        ? ShowDropDown.Never
                        : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(ComboBoxEdit))
                {
                    ((ComboBoxEdit)control).Properties.ReadOnly = !isEnable;
                    ((ComboBoxEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((ComboBoxEdit)control).Properties.ShowDropDown = (!isEnable)
                        ? ShowDropDown.Never
                        : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(SimpleButton))
                {
                    ((SimpleButton)control).Enabled = isEnable;
                    ((SimpleButton)control).Appearance.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(SpinEdit))
                {
                    ((SpinEdit)control).Properties.ReadOnly = !isEnable;
                    ((SpinEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(MemoEdit))
                {
                    ((MemoEdit)control).Properties.ReadOnly = !isEnable;
                    ((MemoEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(GridLookUpEdit))
                {
                    ((GridLookUpEdit)control).Properties.ReadOnly = !isEnable;
                    ((GridLookUpEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((GridLookUpEdit)control).Properties.ShowDropDown = (!isEnable)
                        ? ShowDropDown.Never
                        : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(CheckEdit))
                {
                    ((CheckEdit)control).Properties.Enabled = isEnable;
                    ((CheckEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
            }
        }

        /// <summary>
        /// Sets the automatic number.
        /// </summary>
        protected virtual void SetAutoNumber()
        {
            try
            {
                grdAccountingView.AddNewRow();
                var rowHandle = grdAccountingView.GetSelectedRows()[0];
                if (AutoBusinessModel.BudgetSourceId != (new Guid()).ToString())
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetSourceId", AutoBusinessModel.BudgetSourceId);

                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetChapterCode))
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetChapterCode",
                        AutoBusinessModel.BudgetChapterCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetKindItemCode))
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetKindItemCode",
                        AutoBusinessModel.BudgetKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubKindItemCode))
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetSubKindItemCode",
                        AutoBusinessModel.BudgetSubKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubItemCode))
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetSubItemCode",
                        AutoBusinessModel.BudgetSubItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetItemCode))
                    grdAccountingView.SetRowCellValue(rowHandle, "BudgetItemCode", AutoBusinessModel.BudgetItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.AutoBusinessName))
                    grdAccountingView.SetRowCellValue(rowHandle, "Description", AutoBusinessModel.AutoBusinessName);

                //edit by thangnd check DebitAccount, CreditAccount phai khac null
                if (!string.IsNullOrEmpty(AutoBusinessModel.DebitAccount))
                    grdAccountingView.SetRowCellValue(rowHandle, "DebitAccount",
                        AutoBusinessModel.DebitAccount.Replace("\r\n", ""));
                if (!string.IsNullOrEmpty(AutoBusinessModel.CreditAccount))
                    grdAccountingView.SetRowCellValue(rowHandle, "CreditAccount",
                        AutoBusinessModel.CreditAccount.Replace("\r\n", ""));
                grdAccountingView.SetRowCellValue(rowHandle, "MethodDistributeId",
                    AutoBusinessModel.MethodDistributeId);
                //grdAccountingView.SetRowCellValue(rowHandle, "CashWithDrawTypeId",
                //    AutoBusinessModel.CashWithDrawTypeId);

                #region cach khac

                //int rowHandle;
                //if (tabMain.SelectedTabPage == tabAccounting)
                //{
                //    grdAccountingView.AddNewRow();
                //    rowHandle = grdAccountingView.GetSelectedRows()[0];
                //    if (AutoBusinessModel.BudgetSourceId != (new Guid()).ToString())
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetSourceId", AutoBusinessModel.BudgetSourceId);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetChapterCode))
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetChapterCode", AutoBusinessModel.BudgetChapterCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetKindItemCode))
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetKindItemCode", AutoBusinessModel.BudgetKindItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubKindItemCode))
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetSubKindItemCode", AutoBusinessModel.BudgetSubKindItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubItemCode))
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetSubItemCode", AutoBusinessModel.BudgetSubItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetItemCode))
                //        grdAccountingView.SetRowCellValue(rowHandle, "BudgetItemCode", AutoBusinessModel.BudgetItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.AutoBusinessName))
                //        grdAccountingView.SetRowCellValue(rowHandle, "Description", AutoBusinessModel.AutoBusinessName);
                //    grdAccountingView.SetRowCellValue(rowHandle, "DebitAccount", AutoBusinessModel.DebitAccount.Replace("\r\n", ""));
                //    grdAccountingView.SetRowCellValue(rowHandle, "CreditAccount", AutoBusinessModel.CreditAccount.Replace("\r\n", ""));
                //    grdAccountingView.SetRowCellValue(rowHandle, "MethodDistributeId", AutoBusinessModel.MethodDistributeId);
                //    grdAccountingView.SetRowCellValue(rowHandle, "CashWithDrawTypeId", AutoBusinessModel.CashWithDrawTypeId);
                //}
                //else { }

                //if (tabMain.SelectedTabPage == tabInventoryItem)
                //{
                //    grdDetailByInventoryItemView.AddNewRow();
                //    rowHandle = grdDetailByInventoryItemView.GetSelectedRows()[0];
                //    if (AutoBusinessModel.BudgetSourceId != (new Guid()).ToString())
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSourceId", AutoBusinessModel.BudgetSourceId);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetChapterCode))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetChapterCode", AutoBusinessModel.BudgetChapterCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetKindItemCode))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetKindItemCode", AutoBusinessModel.BudgetKindItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubKindItemCode))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubKindItemCode", AutoBusinessModel.BudgetSubKindItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubItemCode))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubItemCode", AutoBusinessModel.BudgetSubItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetItemCode))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetItemCode", AutoBusinessModel.BudgetItemCode);
                //    if (!string.IsNullOrEmpty(AutoBusinessModel.AutoBusinessName))
                //        grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "Description", AutoBusinessModel.AutoBusinessName);
                //    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "DebitAccount", AutoBusinessModel.DebitAccount.Replace("\r\n", ""));
                //    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CreditAccount", AutoBusinessModel.CreditAccount.Replace("\r\n", ""));
                //    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "MethodDistributeId", AutoBusinessModel.MethodDistributeId);
                //    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CashWithDrawTypeId", AutoBusinessModel.CashWithDrawTypeId);
                //}
                //else { }
                //if (tabMain.SelectedTabPage == tabTax)
                //{ }
                //if (tabMain.SelectedTabPage == tabAccountingDetail)
                //{ }
                //else { }

                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        protected virtual void DeleteRowItem()
        {
            if (tabMain.SelectedTabPage.Equals(tabAccounting))
            {
                grdAccountingView.DeleteSelectedRows();
                CalculateGridMasterAfterDeletedRow(grdAccountingView);
            }
            else if (tabMain.SelectedTabPage.Equals(tabInventoryItem))
            {
                grdDetailByInventoryItemView.DeleteSelectedRows();
                CalculateGridMasterAfterDeletedRow(grdDetailByInventoryItemView);
            }
            else if (tabMain.SelectedTabPage.Equals(tabTax))
                grdTaxView.DeleteSelectedRows();

            DeleteRowItemInBandedGridView();
        }

        protected virtual void DeleteRowItemInBandedGridView()
        {
        }

        protected virtual void AddNewRowItemInBandedGridView()
        {
        }

        /// <summary>
        /// Deletes the item.
        /// LinhMC: 21/10/2015
        /// </summary>
        private void DeleteItem()
        {
            var deleteSuccess = false;
            try
            {

                ActionMode = ActionModeVoucherEnum.Delete;
                var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                    ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    DeleteVoucher();
                    deleteSuccess = true; //LinhMC: chạy đến đây là xóa thành công
                    SaveAuditingLog(); //LINHMC ADD 27/8/2012
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
            finally
            {
                if (deleteSuccess) //LinhMC chỉ khi nào xóa thành công mới nhảy dòng
                {
                    ActionMode = ActionModeVoucherEnum.None;
                    switch (NavigationState)
                    {
                        case EnumNavigationStatus.FirstPosition:
                            _navigationStateBeforeDelete = EnumNavigationStatus.FirstPosition;
                            MoveNextVoucher();
                            break;
                        case EnumNavigationStatus.LastPosition:
                            _navigationStateBeforeDelete = EnumNavigationStatus.LastPosition;
                            MovePreviousVoucher();
                            break;
                        case EnumNavigationStatus.InsidePosition:
                            if (_navigationStateBeforeDelete == EnumNavigationStatus.FirstPosition)
                                MoveNextVoucher();
                            else
                                MovePreviousVoucher();
                            break;
                        case EnumNavigationStatus.CloseForm:
                            this.Close();
                            break;
                        case EnumNavigationStatus.OnlyOneRow:
                            this.Close();
                            break;
                        default:
                            MoveNextVoucher();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Saves this instance.
        /// LinhMC: 21/10/2015
        /// </summary>
        private void Save()
        {
            try
            {
                UpdateGridUpdateCurrentRow();
                if (CheckExistValidateGridView())
                {
                    return;
                }

                if (ValidData())
                {


                    if ((int)BaseRefTypeId != 51 && (int)BaseRefTypeId != 53 && (int)BaseRefTypeId != 71 && (int)BaseRefTypeId != 72 && (int)BaseRefTypeId != 407)
                    {
                        if (!ValidateBindata(bindingSourceDetail, bindingSourceDetailParallel))
                            return;
                    }

                    if (DateTime.Parse(dtRefDate.Text) < DateTime.Parse(GlobalVariable.SystemDate))
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostedDateLessSysemDate"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (RefID != 0)
                    {
                        if (_lockPresenter.CheckLockDate(RefID.ToString(), (int)BaseRefTypeId, dtRefDate.DateTime))
                        {
                            XtraMessageBox.Show(
                                "Bạn không được phép nhập vào ngày đã khóa sổ.Bạn phải mở sổ để nhập ngày này!",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!string.IsNullOrEmpty(GlobalVariable.LockVoucherDateFrom))
                            if (GlobalVariable.LockVoucherDateFrom != null &&
                                DateTime.Parse(GlobalVariable.LockVoucherDateTo) >= dtRefDate.DateTime &&
                                GlobalVariable.IsLockVoucher == 1)
                            {
                                XtraMessageBox.Show(
                                    "Bạn không được phép nhập vào ngày đã khóa sổ.Bạn phải mở sổ để nhập ngày này!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        if (gridViewMaster.UpdateCurrentRow() && grdAccountingView.UpdateCurrentRow() &&
                            grdAccountingDetailView.UpdateCurrentRow() && grdDetailByInventoryItemView.UpdateCurrentRow() &&
                            grdTaxView.UpdateCurrentRow())
                        {
                            var refId = SaveData();
                            if (!string.IsNullOrEmpty(refId))
                            {
                                //save Bu id
                                if (ActionMode == ActionModeVoucherEnum.AddNew ||
                                    ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                    _autoIDPresenter.Save();
                                SaveAuditingLog(); //LINHMC ADD 27/8/2012
                                _keyForSend = ActionMode == ActionModeVoucherEnum.AddNew ||
                                              ActionMode == ActionModeVoucherEnum.DuplicateVoucher
                                    ? refId.ToString(CultureInfo.InvariantCulture)
                                    : KeyValue;
                                if (ActionMode == ActionModeVoucherEnum.AddNew ||
                                    ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                    KeyValue = _keyForSend;
                                CloseForm();
                                ActionMode = ActionModeVoucherEnum.None;
                                RefreshNavigationButton();
                                ReloadGrid();
                            }
                            else
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else

                    {
                        if (!string.IsNullOrEmpty(GlobalVariable.LockVoucherDateFrom))
                            if (GlobalVariable.LockVoucherDateFrom != null &&
                                DateTime.Parse(GlobalVariable.LockVoucherDateTo) >= dtRefDate.DateTime &&
                                GlobalVariable.IsLockVoucher == 1)
                            {
                                XtraMessageBox.Show(
                                    "Bạn không được phép nhập vào ngày đã khóa sổ.Bạn phải mở sổ để nhập ngày này!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                        if (gridViewMaster.UpdateCurrentRow() && grdAccountingView.UpdateCurrentRow() &&
                            grdAccountingDetailView.UpdateCurrentRow() && grdDetailByInventoryItemView.UpdateCurrentRow() &&
                            grdTaxView.UpdateCurrentRow())
                        {
                            var refId = SaveData();
                            if (!string.IsNullOrEmpty(refId))
                            {
                                //save auto id
                                if (ActionMode == ActionModeVoucherEnum.AddNew ||
                                    ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                    _autoIDPresenter.Save();
                                SaveAuditingLog(); //LINHMC ADD 27/8/2012
                                _keyForSend = ActionMode == ActionModeVoucherEnum.AddNew ||
                                              ActionMode == ActionModeVoucherEnum.DuplicateVoucher
                                    ? refId.ToString(CultureInfo.InvariantCulture)
                                    : KeyValue;
                                if (ActionMode == ActionModeVoucherEnum.AddNew ||
                                    ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                    KeyValue = _keyForSend;
                                CloseForm();
                                ActionMode = ActionModeVoucherEnum.None;
                                RefreshNavigationButton();
                                ReloadGrid();
                            }
                            else
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReFreshControl();
            }
        }
        ///<summary>
        ///Kiểm tra dữ liệu trong grid
        /// </summary>
        protected virtual bool ValidateBindata(BindingSource bindingSource, BindingSource bindingSourceParaller)
        {

            string CurrencyCode = gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString();
            if (bindingSource.List != null)
            {
                var account = (List<AccountModel>)Model.GetAccountsByIsDetail(GlobalVariable.IsPostToParentAccount);
                var DataDetail = bindingSource.List ?? new List<object>();
                foreach (object item in DataDetail)
                {

                    var Credit = item.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(item, null) ?? "";
                    var Debit = item.GetType().GetProperties().First(o => o.Name == "DebitAccount").GetValue(item, null) ?? "";
                    var CreditAccount = account.FirstOrDefault(o => o.AccountNumber.Equals(Credit)) ?? new AccountModel();
                    var DebitAccount = account.FirstOrDefault(o => o.AccountNumber.Equals(Debit)) != null ? account.FirstOrDefault(o => o.AccountNumber.Equals(Debit)).AccountNumber : "";
                    if (String.IsNullOrEmpty(DebitAccount.ToString()) && string.IsNullOrEmpty(CreditAccount.AccountNumber))
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        return false;
                    }
                    long? fiNumCreditAccount = null;
                    long? fiNumDebitAccount = null;
                    if (!string.IsNullOrEmpty(DebitAccount.ToString()))
                    {
                        fiNumDebitAccount = Int64.Parse(DebitAccount.ToString().Substring(0, 1));
                        if (fiNumDebitAccount != 0 && String.IsNullOrEmpty(CreditAccount.AccountNumber))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (!string.IsNullOrEmpty(CreditAccount.AccountNumber))
                    {
                        fiNumCreditAccount = Int64.Parse(CreditAccount.AccountNumber.ToString().Substring(0, 1));
                        if (fiNumCreditAccount != 0 && String.IsNullOrEmpty(DebitAccount.ToString()))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    //Check Chi quy am
                    if (CreditAccount.AccountNumber != null && CurrencyCode == "VND")
                    {
                        decimal AmountCheck = 0;
                        foreach (var ls in DataDetail)
                        {
                            var lsCredit = ls.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(ls, null) ?? "";
                            if (lsCredit.Equals(CreditAccount.AccountNumber))
                            {
                                decimal amount = (decimal)ls.GetType().GetProperties().First(o => o.Name == "Amount").GetValue(ls, null);
                                AmountCheck = AmountCheck + amount;
                            }
                        }
                        if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "111")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền mặt
                            if (!GlobalVariable.IsPaymentNegativeFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi quỹ vượt quỹ tiền mặt, bạn làm ơn kiểm tra!",
                                      ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }
                        else if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "112")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền gửi
                            if (!GlobalVariable.IsDepositeNegavtiveFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi tiền vượt quỹ tiền gửi, bạn làm ơn kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        decimal AmountCheck = 0;
                        foreach (var ls in DataDetail)
                        {
                            var LsCredit = ls.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(ls, null) ?? "";

                            if (LsCredit.Equals(CreditAccount.AccountNumber))
                            {
                                decimal amountOC = (decimal)(item.GetType().GetProperty("AmountOC") != null ? item.GetType().GetProperties().First(o => o.Name == "AmountOC").GetValue(item, null) : item.GetType().GetProperties().First(o => o.Name == "Amount").GetValue(item, null));
                                AmountCheck = AmountCheck + amountOC;
                            }
                        }
                        if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "111")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền mặt
                            if (!GlobalVariable.IsPaymentNegativeFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi quỹ vượt quỹ tiền mặt, bạn làm ơn kiểm tra!",
                                      ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }
                        else if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "112")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền gửi
                            if (!GlobalVariable.IsDepositeNegavtiveFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi tiền vượt quỹ tiền gửi, bạn làm ơn kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }

                    }
                }

            }
            if (bindingSourceParaller.List != null && bindingSourceParaller.List.Count > 0)
            {
                var account = (List<AccountModel>)Model.GetAccountsByIsDetail(GlobalVariable.IsPostToParentAccount);
                var DataDetail = bindingSource.List ?? new List<object>();
                foreach (object item in DataDetail)
                {

                    var Credit = item.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(item, null) ?? "";
                    var Debit = item.GetType().GetProperties().First(o => o.Name == "DebitAccount").GetValue(item, null) ?? "";
                    var CreditAccount = account.FirstOrDefault(o => o.AccountNumber.Equals(Credit)) ?? new AccountModel();
                    var DebitAccount = account.FirstOrDefault(o => o.AccountNumber.Equals(Debit)) != null ? account.FirstOrDefault(o => o.AccountNumber.Equals(Debit)).AccountNumber : "";
                    if (String.IsNullOrEmpty(DebitAccount.ToString()) && string.IsNullOrEmpty(CreditAccount.AccountNumber.ToString()))
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        return false;
                    }
                    long? fiNumCreditAccount = null;
                    long? fiNumDebitAccount = null;
                    if (!string.IsNullOrEmpty(DebitAccount.ToString()))
                    {
                        fiNumDebitAccount = Int64.Parse(DebitAccount.ToString().Substring(0, 1));
                        if (fiNumDebitAccount != 0 && String.IsNullOrEmpty(CreditAccount.AccountNumber.ToString()))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (!string.IsNullOrEmpty(CreditAccount.AccountNumber.ToString()))
                    {
                        fiNumCreditAccount = Int64.Parse(CreditAccount.AccountNumber.ToString().Substring(0, 1));
                        if (fiNumCreditAccount != 0 && String.IsNullOrEmpty(DebitAccount.ToString()))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccount"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    //Check Chi quy am
                    if (CreditAccount.AccountNumber != null && CurrencyCode == "VND")
                    {
                        decimal AmountCheck = 0;
                        foreach (var ls in DataDetail)
                        {
                            var lsCredit = ls.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(ls, null) ?? "";
                            if (lsCredit.Equals(CreditAccount.AccountNumber))
                            {
                                decimal amount = (decimal)ls.GetType().GetProperties().First(o => o.Name == "Amount").GetValue(ls, null);
                                AmountCheck = AmountCheck + amount;
                            }
                        }
                        if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "111")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền mặt
                            if (!GlobalVariable.IsPaymentNegativeFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi quỹ vượt quỹ tiền mặt, bạn làm ơn kiểm tra!",
                                      ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }
                        else if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "112")
                        {
                            #region Kiểm tra chi vượt quá quỹ tiền gửi
                            if (!GlobalVariable.IsDepositeNegavtiveFund && AmountCheck > 0)
                            {
                                decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                if (AmountCheck > amountExist)
                                {
                                    XtraMessageBox.Show(@"Bạn chi tiền vượt quỹ tiền gửi, bạn làm ơn kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "112")
                        {
                            decimal AmountCheck = 0;
                            foreach (var ls in DataDetail)
                            {
                                var LsCredit = ls.GetType().GetProperties().First(o => o.Name == "CreditAccount").GetValue(ls, null) ?? "";

                                if (LsCredit.Equals(CreditAccount.AccountNumber))
                                {
                                    decimal amountOC = (decimal)(item.GetType().GetProperty("AmountOC") != null ? item.GetType().GetProperties().First(o => o.Name == "AmountOC").GetValue(item, null) : item.GetType().GetProperties().First(o => o.Name == "Amount").GetValue(item, null));
                                    AmountCheck = AmountCheck + amountOC;
                                }
                            }
                            if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "111")
                            {
                                #region Kiểm tra chi vượt quá quỹ tiền mặt
                                if (!GlobalVariable.IsPaymentNegativeFund && AmountCheck > 0)
                                {
                                    decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                    if (AmountCheck > amountExist)
                                    {
                                        XtraMessageBox.Show(@"Bạn chi quỹ vượt quỹ tiền mặt, bạn làm ơn kiểm tra!",
                                          ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                #endregion
                            }
                            else if (!String.IsNullOrEmpty(CreditAccount.AccountNumber) && CreditAccount.AccountNumber.Substring(0, 3) == "112")
                            {
                                #region Kiểm tra chi vượt quá quỹ tiền gửi
                                if (!GlobalVariable.IsDepositeNegavtiveFund && AmountCheck > 0)
                                {
                                    decimal amountExist = _calculateClosingPresenter.AmountExist(CreditAccount.AccountNumber, CurrencyCode, (DateTime)dtRefDate.DateTime, KeyValue, (int)BaseRefTypeId);
                                    if (AmountCheck > amountExist)
                                    {
                                        XtraMessageBox.Show(@"Bạn chi tiền vượt quỹ tiền gửi, bạn làm ơn kiểm tra lại!",
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }

            }

            #endregion
            return true;
        }
        /// <summary>
        /// Hiển thị các form khi click tiện ích
        /// </summary>
        protected virtual void ShowFormUtility()
        {

        }

        /// <summary>
        /// Shows the ba with draw detail tt bh.
        /// </summary>
        protected virtual void ShowBAWithDrawDetail_TT_BH()
        {

        }

        /// <summary>
        /// Show form Voucher
        /// </summary>
        protected virtual void ShowVoucherList()
        {

        }

        /// <summary>
        /// Bus the plan with draw transfer insurrance detail.
        /// </summary>
        protected virtual void BUPlanWithDrawTransferInsurranceDetail()
        {

        }

        /// <summary>
        /// Updates the grid update current row.
        /// </summary>
        private void UpdateGridUpdateCurrentRow()
        {
            gridViewMaster.UpdateCurrentRow();
            grdAccountingView.UpdateCurrentRow();
            grdAccountingDetailView.UpdateCurrentRow();
            grdDetailByInventoryItemView.UpdateCurrentRow();
            grdTaxView.UpdateCurrentRow();

            gridViewMaster.CloseEditor();
            grdAccountingView.CloseEditor();
            grdAccountingDetailView.CloseEditor();
            grdDetailByInventoryItemView.CloseEditor();
            grdTaxView.CloseEditor();
        }



        #region Functions overrides

        /// <summary>
        /// Shows the help.
        /// </summary>
        protected virtual void ShowHelp()
        {
            //foreach (DriveInfo curdrive in DriveInfo.GetDrives())
            //{
            //    if (!curdrive.IsReady) continue; string driveRoot = curdrive.RootDirectory.Name.Replace("\\", "");
            //}
            if (!File.Exists("BigTime.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BigTime.CHM", HelpNavigator.TopicId,
                Convert.ToString(HelpTopicId));
        }

        /// <summary>
        /// Gets the account detail by.
        /// LinhMC
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        protected virtual string GetAccountDetailBy(string accountNumber)
        {
            if (AccountLists != null && AccountLists.Count > 0)
            {
                var detailBy = "";
                var accountModel = AccountLists.FirstOrDefault(c => c.AccountNumber == accountNumber);
                if (accountModel != null && accountModel.DetailByBudgetItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetItemCode" : detailBy + ";BudgetItemCode";
                if (accountModel != null && accountModel.DetailByBudgetSource)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetSourceCode" : detailBy + ";BudgetSourceCode";
                if (accountModel != null && accountModel.DetailByAccountingObject)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "AccountingObjectId" : detailBy + ";AccountingObjectId";
                //if (accountModel != null && accountModel.IsCurrency)
                //    detailBy = string.IsNullOrEmpty(detailBy) ? "CurrencyCode" : detailBy + ";CurrencyCode";
                //if (accountModel != null && accountModel.IsCustomer)
                //    detailBy = string.IsNullOrEmpty(detailBy) ? "CustomerId" : detailBy + ";CustomerId";
                //if (accountModel != null && accountModel.IsEmployee)
                //    detailBy = string.IsNullOrEmpty(detailBy) ? "EmployeeId" : detailBy + ";EmployeeId";
                //if (accountModel != null && accountModel.IsVendor)
                //    detailBy = string.IsNullOrEmpty(detailBy) ? "VendorId" : detailBy + ";VendorId";
                if (accountModel != null && accountModel.DetailByFixedAsset)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "FixedAssetId" : detailBy + ";FixedAssetId";
                if (accountModel != null && accountModel.DetailByInventoryItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "InventoryItemId" : detailBy + ";InventoryItemId";
                if (accountModel != null && accountModel.DetailByProject)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "ProjectId" : detailBy + ";ProjectId";
                if (accountModel != null && accountModel.DetailByBudgetChapter)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetChapterCode" : detailBy + ";BudgetChapterCode";
                if (accountModel != null && accountModel.DetailByBudgetKindItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetKindItemCode" : detailBy + ";BudgetKindItemCode";
                if (accountModel != null && accountModel.DetailByBudgetSubItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetSubItemCode" : detailBy + ";BudgetSubItemCode";
                if (accountModel != null && accountModel.DetailByMethodDistribute)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "MethodDistributeId" : detailBy + ";MethodDistributeId";
                if (accountModel != null && accountModel.DetailByActivity)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "ActivityId" : detailBy + ";ActivityId";
                if (accountModel != null && accountModel.DetailByBankAccount)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BankId" : detailBy + ";BankId";
                if (accountModel != null && accountModel.DetailByBudgetKindItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetKindItemCode" : detailBy + ";ProjectId";
                if (accountModel != null && accountModel.DetailByBudgetKindItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetKindItemCode" : detailBy + ";ProjectId";
                return detailBy;
            }
            return null;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidData()
        {
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected virtual string SaveData()
        {
            return null;
        }

        /// <summary>
        /// Saves the voucher.
        /// </summary>
        protected void SaveVoucher()
        {
            try
            {
                UpdateGridUpdateCurrentRow();

                if (gridViewMaster.UpdateCurrentRow() &&
                    grdAccountingView.UpdateCurrentRow() &&
                    grdAccountingDetailView.UpdateCurrentRow() &&
                    grdDetailByInventoryItemView.UpdateCurrentRow() &&
                    grdTaxView.UpdateCurrentRow())
                {
                    if (ValidData())
                    {
                        var refId = SaveData();
                        if (!string.IsNullOrEmpty(refId))
                        {
                            _keyForSend = ActionMode == ActionModeVoucherEnum.AddNew ||
                                          ActionMode == ActionModeVoucherEnum.DuplicateVoucher
                                ? refId.ToString(CultureInfo.InvariantCulture)
                                : KeyValue;
                            if (ActionMode == ActionModeVoucherEnum.AddNew ||
                                ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                KeyValue = _keyForSend;
                            CloseForm();
                            ActionMode = ActionModeVoucherEnum.None;
                            RefreshNavigationButton();
                        }
                        else
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReFreshControl();
            }
        }

        /// <summary>
        /// Saves the auditing log.
        /// LINHMC add 27/8/2015
        /// </summary>
        /// <returns></returns>
        protected virtual string SaveAuditingLog()
        {
            return _audittingLogPresenter.Save();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected virtual void InitData()
        {

        }

        /// <summary>
        /// Initializes the data master grid.
        /// </summary>
        protected virtual void InitDataMasterGrid()
        {
            var value = new List<MasterGrid>
            {
                new MasterGrid
                {
                    TotalAmount = 0,
                    CurrencyCode = GlobalVariable.MainCurrencyId,
                    TotalAmountOC = 0,
                    ExchangeRate = 1
                }
            };
            grdMaster.DataSource = value;
            gridViewMaster.PopulateColumns(value);
            //LoadLayoutGridMaster();

            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "CurrencyCode",
                ColumnCaption = "Loại tiền",
                ColumnVisible = true,
                ColumnWith = 90,
                ColumnPosition = 1,
                AllowEdit = true,
                RepositoryControl = _gridLookUpEditCurrency
            });
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "ExchangeRate",
                ColumnCaption = "Tỷ giá",
                ColumnVisible = true,
                ColumnWith = 70,
                ColumnPosition = 2,
                IsNumeric = true,
                AllowEdit = true
            });
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "TotalAmountOC",
                ColumnCaption = "Số tiền",
                ColumnVisible = true,
                ColumnWith = 130,
                ColumnPosition = 3,
                IsNumeric = true,
                AllowEdit = false
            });
            gridColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "TotalAmount",
                ColumnCaption = "Quy đổi",
                ColumnVisible = true,
                ColumnWith = 130,
                ColumnPosition = 4,
                IsNumeric = true,
                AllowEdit = false
            });

            XtraColumnCollectionHelper<MasterGrid>.ShowXtraColumnInGridView(gridColumnsCollection, gridViewMaster);
            gridViewMaster.OptionsView.ShowFooter = false;

        }

        /// <summary>
        /// Loads the layout grid master full.
        /// </summary>
        protected virtual void LoadLayoutGridMaster()
        {
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
            repositoryNumberCalcEdit.Mask.EditMask = GlobalVariable.NumberDecimalDigits; //lay theo option
            repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;

            gridViewMaster.Columns["CurrencyCode"].Caption = @"Loại tiền";
            gridViewMaster.Columns["CurrencyCode"].VisibleIndex = 1;
            gridViewMaster.Columns["CurrencyCode"].ColumnEdit = _gridLookUpEditCurrency;
            gridViewMaster.Columns["CurrencyCode"].Width = 90;

            gridViewMaster.Columns["ExchangeRate"].Caption = @"Tỷ giá";
            gridViewMaster.Columns["ExchangeRate"].Visible = true;
            gridViewMaster.Columns["ExchangeRate"].VisibleIndex = 2;
            gridViewMaster.Columns["ExchangeRate"].ColumnEdit = repositoryNumberCalcEdit;
            gridViewMaster.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
            gridViewMaster.Columns["ExchangeRate"].Width = 70;

            gridViewMaster.Columns["TotalAmountOC"].Caption = @"Số tiền";
            gridViewMaster.Columns["TotalAmountOC"].VisibleIndex = 3;
            gridViewMaster.Columns["TotalAmountOC"].Visible = true;
            gridViewMaster.Columns["TotalAmountOC"].UnboundType = UnboundColumnType.Decimal;
            gridViewMaster.Columns["TotalAmountOC"].OptionsColumn.AllowEdit = true;
            gridViewMaster.Columns["TotalAmountOC"].Width = 130;

            gridViewMaster.Columns["TotalAmount"].Caption = @"Quy đổi";
            gridViewMaster.Columns["TotalAmount"].VisibleIndex = 4;
            gridViewMaster.Columns["TotalAmount"].UnboundType = UnboundColumnType.Decimal;
            gridViewMaster.Columns["TotalAmount"].OptionsColumn.AllowEdit = true;
            gridViewMaster.Columns["TotalAmount"].Width = 130;

            SetNumericFormatControl(gridViewMaster, false);
        }

        /// <summary>
        /// Show detail data.
        /// LinhMC thêm code update lại trường DetailBy trong trường hợp sửa không bắt được chi tiết
        /// </summary>
        protected virtual void ShowData()
        {
            InitDataMasterGrid();
            InitData();
            InitRefInfo();
            LoadGridDetailLayout();
            SetNumericFormatControl(grdAccountingView, true);

            if (grdAccounting.MainView != null && grdAccounting.MainView.GetType() == typeof(BandedGridView))
            {
                SetNumericFormatGridBand((BandedGridView)grdAccounting.MainView, true);
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                SetDefaultValue(grdAccountingView);
                lkAccountingObjectCategory.EditValue = null;
                cboObjectCode.EditValue = null;
                cboObjectName.EditValue = null;
                txtAddress.EditValue = null;
                txtContactName.EditValue = null;
                txtDescription.EditValue = null;
                cboBank.EditValue = null;

            }
        }

        /// <summary>
        /// Updates the detail by.
        /// </summary>
        protected virtual void UpdateDetailBy()
        {
            var colAccountNumber = grdAccountingView.Columns["AccountNumber"];
            for (int i = 0; i < grdAccountingView.DataRowCount; i++)
            {
                //thangNK modify <14/01/2015>
                var accountNumber = (string)grdAccountingView.GetRowCellValue(i, colAccountNumber);
                string accountNumberDetailBy = "";
                if (accountNumber != null)
                {
                    accountNumberDetailBy = GetAccountDetailBy(accountNumber);
                }
                var correspondingAccountNumber =
                    (string)grdAccountingView.GetRowCellValue(i, "CorrespondingAccountNumber");
                string correspondingAccountNumberDetailBy = "";
                if (correspondingAccountNumber != null)
                {
                    correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber);
                }


                accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                    ? correspondingAccountNumberDetailBy
                    : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;
                if (accountNumberDetailBy != null)
                {
                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    grdAccountingView.SetRowCellValue(i, "DetailBy", detail);
                }

            }
        }

        /// <summary>
        /// Updates the detail by for accounting detail.
        /// </summary>
        protected virtual void UpdateDetailByForAccountingDetail()
        {
            var colAccountNumber = grdAccountingDetailView.Columns["AccountNumber"];
            for (int i = 0; i < grdAccountingDetailView.DataRowCount; i++)
            {
                //thangNK modify <14/01/2015>
                var accountNumber = (string)grdAccountingDetailView.GetRowCellValue(i, colAccountNumber);
                string accountNumberDetailBy = "";
                if (accountNumber != null)
                {
                    accountNumberDetailBy = GetAccountDetailBy(accountNumber);
                }
                var correspondingAccountNumber =
                    (string)grdAccountingDetailView.GetRowCellValue(i, "CorrespondingAccountNumber");
                string correspondingAccountNumberDetailBy = "";
                if (correspondingAccountNumber != null)
                {
                    correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber);
                }


                accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                    ? correspondingAccountNumberDetailBy
                    : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;
                if (accountNumberDetailBy != null)
                {
                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    grdAccountingDetailView.SetRowCellValue(i, "DetailBy", detail);
                }

            }
        }

        /// <summary>
        /// Updates the detail by for detail tax.
        /// </summary>
        protected virtual void UpdateDetailByForDetailTax()
        {
        }

        /// <summary>
        /// Updates the detail by for detail inventory item.
        /// </summary>
        protected virtual void UpdateDetailByForDetailInventoryItem()
        {
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected virtual void InitControls()
        {

        }

        /// <summary>
        /// Adds the new voucher.
        /// </summary>
        protected virtual void AddNewVoucher()
        {
            try
            {
                ActionMode = ActionModeVoucherEnum.AddNew;
                var count = grdAccountingView.RowCount;
                for (int i = 0; i < count; i++)
                    grdAccountingView.DeleteRow(0);
                MasterBindingSource.AddNew();
                MasterBindingSource.EndEdit();
                MasterBindingSource.MoveLast();               
                ShowData();
                GeneratedBaseRefNo();
                EnableControl();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Duplicates the voucher.ds
        /// </summary>
        protected virtual void DuplicateVoucher()
        {
            try
            {
                ActionMode = ActionModeVoucherEnum.DuplicateVoucher;
                ShowData();
                GeneratedBaseRefNo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual bool ValidEdit()
        {
            return true;
        }

        /// <summary>
        /// Edits the voucher.
        /// </summary>
        protected virtual void EditVoucher()
        {
            ActionMode = ActionModeVoucherEnum.Edit;
            EnableControl();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected virtual void DeleteVoucher()
        {

        }

        /// <summary>
        /// Enables the control.
        /// </summary>
        protected virtual void EnableControl()
        {

        }

        /// <summary>
        /// Cancels the voucher.
        /// LinhMC: vì sắp xếp chứng từ theo thời gian mới nhất ở đầu danh sách,
        /// do đó sẽ phải sửa lại việc hiển thị chứng từ sẽ là chứng từ đầu tiên
        /// CurrentPosition =
        /// MasterBindingSource.Position =
        /// BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
        /// //MoveFirstVoucher();
        /// </summary>
        protected virtual void CancelVoucher()
        {
            try
            {
                ConfirmSaveDataChanged();
                ActionMode = ActionModeVoucherEnum.None;
                if (MasterBindingSource != null)
                {
                    MasterBindingSource.CancelEdit();
                    MasterBindingSource.ResumeBinding();
                }
                bindingSourceDetail.CancelEdit();
                bindingSourceDetailByTax.CancelEdit();
                bindingSourceDetailParallel.CancelEdit();

                if (MasterBindingSource == null || MasterBindingSource.Count <= 0)
                {
                    Close();
                    return;
                }
                CurrentPosition =
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position-1;
                ShowData();
                RefreshNavigationButton();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prints the voucher.
        /// </summary>
        protected virtual void PrintVoucher()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //for (var i = 0; i < grdAccountingDetailView.DataSource; i++)
                //{
                //    var rowVoucher = grdAccountingView.GetRow(i);
                // var bindingSource = (BindingSource)grdDetailByInventoryItem.DataSource;

                using (var frmVoucherReports = new FrmVoucherReports(bindingSourceDetail.DataSource))
                {
                    frmVoucherReports.RefTypeVoucher =
                        RefTypeUsingDisplayReport == 0 ? BaseRefTypeId : RefTypeUsingDisplayReport;
                    frmVoucherReports.RefId = KeyValue;
                    //IList<ReportListModel> reportLists = _reportList.FindAll(item => item.RefType == (int)RefTypeUsingDisplayReport);
                    //frmXtraPrintVoucherByLot.InitComboData(reportLists);
                    //frmXtraPrintVoucherByLot.RefID = int.Parse(KeyValue);
                    if (frmVoucherReports.ShowDialog() == DialogResult.OK)
                    {
                        //var refIds = frmXtraPrintVoucherByLot.SelectedVoucher;
                        //var reportVoucherId = frmXtraPrintVoucherByLot.ReportID;
                        //reportHelper.CommonVariable = new GlobalVariable
                        //{
                        //    RefIdList = refIds,
                        //    RefType = (int)BaseRefTypeId
                        //};

                        //if (reportVoucherId != null)
                        //{
                        //    reportHelper.PrintPreviewReport(null, reportVoucherId, false);
                        //}
                    }
                }
                //var reportHelper = new ReportHelper();
                //_reportList = _reportListPresenter.GetReportsByRefType((int)RefTypeUsingDisplayReport);
                //reportHelper.ReportLists = _reportList;
                //if (printType == 0)
                //{
                //    reportHelper.CommonVariable = new GlobalVariable();
                //    var reportListModel = _reportList.FirstOrDefault(item => item.PrintVoucherDefault);
                //    if (reportListModel != null)
                //    {
                //        reportHelper.PrintPreviewReport(null, reportListModel.ReportId, false);
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("Bạn chưa chọn mặc định chứng từ!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                //else if (printType == 1)
                //{
                //    reportHelper.CommonVariable = new GlobalVariable();
                //    var reportListModel = _reportList.Find(item => item.RefType == (int)RefTypeUsingDisplayReport && item.PrintVoucherDefault);
                //    if (reportListModel != null)
                //    {
                //        reportHelper.PrintPreviewReport(null, reportListModel.ReportId, true);
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("Bạn chưa chọn mặc định chứng từ!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //}
                //else
                //{
                //    //using (var frmXtraPrintVoucherByLot = new FrmXtraPrintVoucherByLot())
                //    //{
                //    //    frmXtraPrintVoucherByLot.RefType = RefTypeUsingDisplayReport;
                //    //    IList<ReportListModel> reportLists = _reportList.FindAll(item => item.RefType == (int)RefTypeUsingDisplayReport);
                //    //    frmXtraPrintVoucherByLot.InitComboData(reportLists);
                //    //    frmXtraPrintVoucherByLot.RefID = int.Parse(KeyValue);
                //    //    if (frmXtraPrintVoucherByLot.ShowDialog() == DialogResult.OK)
                //    //    {
                //    //        var refIds = frmXtraPrintVoucherByLot.SelectedVoucher;
                //    //        var reportVoucherId = frmXtraPrintVoucherByLot.ReportID;
                //    //        reportHelper.CommonVariable = new GlobalVariable
                //    //        {
                //    //            RefIdList = refIds,
                //    //            RefType = (int)BaseRefTypeId
                //    //        };

                //    //        if (reportVoucherId != null)
                //    //        {
                //    //            reportHelper.PrintPreviewReport(null, reportVoucherId, false);
                //    //        }
                //    //    }
                //    //}
                //}

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
        /// Refreshes the voucher.
        /// </summary>
        protected virtual void RefreshVoucher()
        {
            try
            {
                ShowData();
                ReloadGrid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds the new row item.
        /// </summary>
        protected virtual void AddNewRowItem()
        {
            grdAccountingView.AddNewRow();
            grdAccountingDetailView.AddNewRow();
            grdTaxView.AddNewRow();
            grdDetailByInventoryItemView.AddNewRow();
        }

        /// <summary>
        /// LinhMC create to copy selected rows
        /// iterate cells and compose a tab delimited string of cell values
        /// LinhMC modify 26/8/2015: thay result += view.GetRowCellDisplayText(row, view.VisibleColumns[j]);
        /// bằng: result += view.GetRowCellValue(row, view.VisibleColumns[j]);
        /// Nguyên nhân thay: dữ liệu được lấy chỉ là text được hiển thị mà không phải là giá trị
        /// nếu gặp trường hợp dữ liệu 1 cột EditValue là kiểu số, hiển thị là kiểu text sẽ phát sinh lỗi
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private string GetSelectedValues(GridView view)
        {
            if (view.SelectedRowsCount == 0)
                return "";

            const string cellDelimiter = "\t";
            const string lineDelimiter = "\r\n";
            string result = "";

            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {
                int row = view.GetSelectedRows()[i];

                // TUDT comment để có thể copy được dữ liệu cho tab Thống kê - Ngày 18/12/2017
                //for (int j = 0; j < view.VisibleColumns.Count; j++) 
                //{
                //    result += view.GetRowCellValue(row, view.VisibleColumns[j]);
                //    if (j != view.VisibleColumns.Count - 1)
                //        result += cellDelimiter;
                //}
                //if (i != 0)
                //    result += lineDelimiter;
                for (int j = 0; j < view.Columns.Count; j++)
                {
                    result += view.GetRowCellValue(row, view.Columns[j]);
                    if (j != view.Columns.Count - 1)
                        result += cellDelimiter;
                }
                if (i != 0)
                    result += lineDelimiter;
            }
            return result;
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected virtual void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            //var view = (GridView)sender;
            //string masterAccountNumber;
            //switch (BaseRefTypeId)
            //{
            //    case RefType.PaymentCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.PaymentDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //}

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData == null || !clipboardData.GetDataPresent(_typeOfModel))
                return;
            var data = clipboardData.GetData(_typeOfModel);
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(_typeOfModel.GetProperties());
            foreach (
                var gridColumn in
                grdAccountingView.Columns.Cast<GridColumn>()
                    .Where(gridColumn => gridColumn.Visible)
                    .OrderBy(x => x.VisibleIndex))
            {
                var property =
                (from propertyInfo in propertyInfos
                 where propertyInfo.Name == gridColumn.FieldName
                 select propertyInfo).First();
                grdAccountingView.SetRowCellValue(e.RowHandle, gridColumn, property.GetValue(data, null));
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected virtual void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            //var view = (GridView)sender;
            //string masterAccountNumber;
            //switch (BaseRefTypeId)
            //{
            //    case RefType.PaymentCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.PaymentDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //}

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData == null || !clipboardData.GetDataPresent(_typeOfModel))
                return;
            var data = clipboardData.GetData(_typeOfModel);
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(_typeOfModel.GetProperties());
            foreach (
                var gridColumn in
                grdAccountingDetailView.Columns.Cast<GridColumn>()
                    .Where(gridColumn => gridColumn.Visible)
                    .OrderBy(x => x.VisibleIndex))
            {
                var property =
                (from propertyInfo in propertyInfos
                 where propertyInfo.Name == gridColumn.FieldName
                 select propertyInfo).First();
                grdAccountingDetailView.SetRowCellValue(e.RowHandle, gridColumn, property.GetValue(data, null));
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail by tax.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected virtual void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            //var view = (GridView)sender;
            //string masterAccountNumber;
            //switch (BaseRefTypeId)
            //{
            //    case RefType.PaymentCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.PaymentDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //}

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData == null || !clipboardData.GetDataPresent(_typeOfModel))
                return;
            var data = clipboardData.GetData(_typeOfModel);
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(_typeOfModel.GetProperties());
            foreach (
                var gridColumn in
                grdTaxView.Columns.Cast<GridColumn>()
                    .Where(gridColumn => gridColumn.Visible)
                    .OrderBy(x => x.VisibleIndex))
            {
                var property =
                (from propertyInfo in propertyInfos
                 where propertyInfo.Name == gridColumn.FieldName
                 select propertyInfo).First();
                grdTaxView.SetRowCellValue(e.RowHandle, gridColumn, property.GetValue(data, null));
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail by inventory item.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected virtual void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            //var view = (GridView)sender;
            //string masterAccountNumber;
            //switch (BaseRefTypeId)
            //{
            //    case RefType.PaymentCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptCash:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
            //            ? "11121"
            //            : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.PaymentDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
            //        break;
            //    case RefType.ReceiptDeposite:
            //        masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
            //            ? "11221"
            //            : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
            //        view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
            //        break;
            //}

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData == null || !clipboardData.GetDataPresent(_typeOfModel))
                return;
            var data = clipboardData.GetData(_typeOfModel);
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(_typeOfModel.GetProperties());
            foreach (
                var gridColumn in
                grdDetailByInventoryItemView.Columns.Cast<GridColumn>()
                    .Where(gridColumn => gridColumn.Visible)
                    .OrderBy(x => x.VisibleIndex))
            {
                var property =
                (from propertyInfo in propertyInfos
                 where propertyInfo.Name == gridColumn.FieldName
                 select propertyInfo).First();
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, gridColumn, property.GetValue(data, null));
            }
        }

        /// <summary>
        /// LinhMC
        /// Initializes the new row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected void InitCopyNewRow(InitNewRowEventArgs e, GridView view)
        {
            IDataObject data = Clipboard.GetDataObject();

            string s = "";
            if (data != null && data.GetDataPresent(DataFormats.UnicodeText))
                s = data.GetData(DataFormats.UnicodeText).ToString();

            string[] dataRow = s.Split('\t');
            // TUDT comment để có thể copy được dữ liệu cho tab Thống kê - Ngày 18/12/2017
            //for (int j = 0; j < view.Columns.Count; j++)
            //{
            //    Type type = view.Columns[j].ColumnType;

            //    if (type != typeof(string) && string.IsNullOrEmpty(dataRow[j]))
            //        continue;
            //    view.SetRowCellValue(e.RowHandle, view.Columns[j], dataRow[j]);
            //}

            for (int j = 0; j < view.Columns.Count; j++)
            {
                Type type = view.Columns[j].ColumnType;

                if (type != typeof(string) && string.IsNullOrEmpty(dataRow[j]))
                    continue;
                view.SetRowCellValue(e.RowHandle, view.Columns[j], dataRow[j]);
            }

            view.FocusedRowHandle = e.RowHandle;
        }

        /// <summary>
        /// LinhMC
        /// Copies the and paste row item.
        /// </summary>
        /// <param name="view">The view.</param>
        protected virtual void CopyAndPasteRowItem(GridView view)
        {
            if (ActionMode != ActionModeVoucherEnum.None)
            {
                IsCopyRow = true;
                string selectedCellsText = GetSelectedValues(view);
                Clipboard.SetDataObject(selectedCellsText);

                if (!string.IsNullOrEmpty(selectedCellsText))
                {
                    view.AddNewRow();
                }
                IsCopyRow = false;
                view.CloseEditor();
                view.UpdateCurrentRow();
            }
        }

        /// <summary>
        /// LinhMC: don't use this method
        /// Copies the row item.
        /// </summary>
        protected virtual void CopyRowItem()
        {
            try
            {
                grdAccountingView.AddNewRow();
                for (int i = 0; i < grdAccountingView.RowCount - 1; i++)
                {
                    for (int ii = 0; ii < grdAccountingView.Columns.Count; ii++)
                    {
                        if (grdAccountingView.Columns[ii].UnboundType != UnboundColumnType.Decimal &&
                            grdAccountingView.Columns[ii].Visible)
                            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle,
                                grdAccountingView.Columns[ii],
                                grdAccountingView.GetDisplayTextByColumnValue(grdAccountingView.Columns[ii],
                                    grdAccountingView.GetRowCellValue(i, grdAccountingView.Columns[ii])));
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
        /// Initializes the reference information.
        /// </summary>
        protected virtual void InitRefInfo()
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew && ActionMode != ActionModeVoucherEnum.DuplicateVoucher)
                return;
            dtPostDate.EditValue = BasePostedDate;
            dtRefDate.EditValue = BasePostedDate;
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected virtual void SetEnableGroupBox(bool isEnable)
        {
            barButtonAddNewRowItem.Enabled = isEnable;
            barButtonDeleteRowItem.Enabled = isEnable;
        }

        /// <summary>
        /// Initializes the compare data.
        /// </summary>
        protected virtual void InitCompareData()
        {

        }

        /// <summary>
        /// Confirms the save data changed.
        /// </summary>
        private void ConfirmSaveDataChanged()
        {
            GridViewCloseEditor();
            if (ActionMode != ActionModeVoucherEnum.None && GetDataChanged())
            {
                if (
                    XtraMessageBox.Show("Dữ liệu đã thay đổi bạn có muốn lưu lại không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Grids the view close editor.
        /// </summary>
        /// <returns></returns>
        protected virtual bool GridViewCloseEditor()
        {
            gridViewMaster.CloseEditor();
            grdAccountingView.CloseEditor();
            grdAccountingDetailView.CloseEditor();
            grdTaxView.CloseEditor();
            grdDetailByInventoryItemView.CloseEditor();
            return gridViewMaster.UpdateCurrentRow() && grdAccountingView.UpdateCurrentRow() &&
                   grdDetailByInventoryItemView.UpdateCurrentRow()
                   && grdAccountingDetailView.UpdateCurrentRow() && grdTaxView.UpdateCurrentRow();
        }

        /// <summary>
        /// Gets the data changed.
        /// LinhMC: 21/10/2015
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetDataChanged()
        {
            return false;
        }

        /// <summary>
        /// Initializes the core data.
        /// </summary>
        protected virtual void InitCoreData()
        {
            _refTypesPresenter.Display();
            _currenciesPresenter.DisplayActive();
            if (lkAccountingObjectCategory.Visible)
            {
                _accountingObjectCategoryPresenter.Display();
            }
        }

        /// <summary>
        /// Grids the purchase cell value changed.
        /// </summary>
        protected virtual void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
        /// <summary>
        /// Grids the purchase Show editor
        /// </summary>
        protected virtual void GridPurchaseShowEditor(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
        protected virtual void GridDetailByInventoryItemViewMouseDown(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Grids the accounting detail cell value changed.
        /// </summary>grdDetailByInventoryItem
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void GridAccountingDetailCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }

        /// <summary>
        /// Grids the detail by inventory item value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void GridDetailByInventoryItemValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
        protected virtual void GridAccountingMouseDown(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Grids the view master cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void GridViewMasterCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

        }
        protected virtual void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
        }
        /// <summary>
        /// Calculates the grid master after deleted row.
        /// </summary>
        protected virtual void CalculateGridMasterAfterDeletedRow(DevExpress.XtraGrid.Views.Grid.GridView grdView)
        {
            decimal totalAmountOC = 0;
            decimal totalAmount = 0;
            decimal totalAmountOCOld = gridViewMaster.Columns.ColumnByFieldName("TotalAmountOC") == null || gridViewMaster.GetRowCellValue(0, "TotalAmountOC") == null
                        ? 0
                        : (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC");
            grdAccounting.RefreshDataSource();
            for (var i = 0; i < grdView.RowCount; i++)
            {
                var amountOC = grdView.Columns.ColumnByFieldName(SAmountOCEx) != null ? grdView.GetRowCellValue(i, SAmountOCEx) : 0;
                var amount = grdView.Columns.ColumnByFieldName(SAmountEx) != null ? grdView.GetRowCellValue(i, SAmountEx) : 0;
                if (amountOC != null)
                    totalAmountOC += (decimal)amountOC;
                if (amount != null)
                    totalAmount += (decimal)amount;
            }
            if (totalAmountOCOld != totalAmountOC)
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
            gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmount);
        }

        #endregion

        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBaseVoucherDetail" /> class.
        /// </summary>
        public FrmXtraBaseVoucherDetail()
        {
            InitializeComponent();

            _lockPresenter = new LockPresenter(this);
            _autoIDPresenter = new AutoIDPresenter(this);
            _calculateClosingPresenter = new CalculateClosingPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);

            _accountingObjectCategoryPresenter = new AccountingObjectCategoriesPresenter(this);
            Model = new Model.Model();
            dsView = new Dictionary<string, GridView>
            {
                {"0", grdAccountingDetailView},
                {"1", grdDetailByInventoryItemView},
                {"2", grdAccountingView},
                {"3", grdTaxView}
            };
        }


        /// <summary>
        /// Handles the Load event of the FrmXtraBaseVoucherDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmXtraBaseVoucherDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;
                WindowState = FormWindowState.Maximized;
                InitializeLayout();
                InitCoreData();
                ShowData();
                GeneratedBaseRefNo();
                //SetNumericFormatControl(grdAccountingView, true);
                _reportListPresenter = new ReportListPresenter(this);
                _refTypesPresenter.Display();

                InitCompareData();
                //dsView = new Dictionary<string, GridView> { { "0", grdAccountingDetailView }, { "1", grdDetailByInventoryItemView }, { "2", grdAccountingView }, { "3", grdTaxView } };


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs" /> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonFirstItem":
                    MoveFirstVoucher();
                    break;
                case "barButtonPreviousItem":
                    MovePreviousVoucher();
                    break;
                case "barButtonNextItem":
                    MoveNextVoucher();
                    break;
                case "barButtonLastItem":
                    MoveLastVoucher();
                    break;
                case "barButtonAddNewItem":
                    {
                        if ((_lockPresenter.CheckLockDate(KeyValue, (int)BaseRefTypeId)))
                        {
                            XtraMessageBox.Show("Chứng từ hiện tại đang bị khóa sổ. Bạn phải mở sổ để thêm chứng từ này!.",
                                "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        AddNewVoucher();
                        break;
                    }

                case "barButtonDuplicateItem":
                    DuplicateVoucher();
                    break;
                case "barButtonEditItem":
                    if (!ValidEdit())
                        break;
                    {
                        if ((_lockPresenter.CheckLockDate(KeyValue, (int)BaseRefTypeId)))
                        {
                            XtraMessageBox.Show("Chứng từ hiện tại bị khóa sổ. Bạn phải mở sổ để sửa chứng từ này!.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        EditVoucher();
                        break;
                    }


                case "barButtonDeleteItem":
                    if (Convert.ToDateTime(GlobalVariable.PostedDate) > Convert.ToDateTime(GlobalVariable.LockVoucherDateTo) || Convert.ToDateTime(GlobalVariable.PostedDate) < Convert.ToDateTime(GlobalVariable.LockVoucherDateFrom))
                    {
                        DeleteItem();
                        break;
                    }
                    else
                    {
                        if ((_lockPresenter.CheckLockDate(KeyValue, (int)BaseRefTypeId)))
                        {
                            XtraMessageBox.Show("Chứng từ hiện tại đang bị khóa sổ. Bạn phải mở sổ để xóa chứng từ này!.",
                                "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        DeleteItem();
                        break;
                    }

                case "barButtonSaveItem":
                    Save();
                    break;
                case "barButtonCancelItem":
                    CancelVoucher();
                    break;
                case "barButtonRefeshItem":
                    RefreshVoucher();
                    break;
                case "barButtonPrintItem":
                    PrintVoucher();
                    break;
                case "barButtonHelpItem":
                    ShowHelp();
                    break;
                case "barButtonCloseItem":
                    Close();
                    break;
                case "barButtonDeleteRowItem":
                    DeleteRowItem();
                    break;
                case "barButtonAddNewRowItem":
                    if (tabMain.SelectedTabPage.Equals(tabAccounting))
                    {
                        CopyAndPasteRowItem(grdAccountingView);
                        AddNewRowItemInBandedGridView();
                    }
                    else if (tabMain.SelectedTabPage.Equals(tabInventoryItem))
                        CopyAndPasteRowItem(grdDetailByInventoryItemView);
                    else if (tabMain.SelectedTabPage.Equals(tabTax))
                        CopyAndPasteRowItem(grdTaxView);
                    break;
                case "barButtonAutoBusinessRowItem":
                    using (var frmAutoBusiness = new FrmAutoBusiness())
                    {
                        /*TungDQ: tạm comment lại để không lỗi*/
                        frmAutoBusiness.RefTypeId = (int)BaseRefTypeId;
                        frmAutoBusiness.PostAutoBusinessHandler += FrmXtraBaseVoucherDetail_PostAutoBusiness;
                        var dialog = frmAutoBusiness.ShowDialog();

                        if (dialog == DialogResult.OK)
                            SetAutoNumber();
                    }
                    break;
                case nameof(barButtonPaymentSalary):
                case nameof(barButtonSalary):
                    ShowFormUtility();
                    break;
                case nameof(barButtonPaymentInsurance):
                    ShowBAWithDrawDetail_TT_BH();
                    break;
                case nameof(barButtonCostInsurance):
                    ShowVoucherList();
                    break;


            }
        }


        /// <summary>
        /// Handles the PopupMenuShowing event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdAccountingView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid)
                return;
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupGridDetailMenu.ShowPopup(grdAccounting.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdAccountingView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)

        {
            var viewInfo = (GridViewInfo)grdAccountingView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec,
                    e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the gridViewMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs" /> instance containing the event data.</param>
        private void gridViewMaster_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)gridViewMaster.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the Modified event of the dtPostDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dtPostDate_Modified(object sender, EventArgs e)
        {
            //dtRefDate.EditValue = dtPostDate.EditValue;


        }

        /// <summary>
        /// Handles the Leave event of the dtPostDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dtPostDate_Leave(object sender, EventArgs e)
        {
            //Valid_dtPostedDate();
        }

        /// <summary>
        /// Handles the InitNewRow event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                if (view != null)
                {
                    SetDefaultValue(view);
                    SetDetailFromMaster(view, 0, AutoAccountingObjectId, AutoBankId, AutoProjectId);
                }
                if (!IsCopyRow)
                {
                    InitDetailRow(e, view);
                }
                else
                {
                    InitCopyNewRow(e, view);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Clipboard.Clear();
            }
        }

        /// <summary>
        /// Gán 1 số giá trị mặc định theo tùy chọn
        /// </summary>
        /// <param name="view"></param>
        protected virtual void SetDefaultValue(GridView view)
        {
            var dataSource = view.DataSource;
            if (dataSource != null && dataSource.GetType() == typeof(BindingSource))
            {
                var bindingSource = (BindingSource)dataSource;
                var currentValue = bindingSource.Current;
                if (currentValue != null)
                {
                    var type = currentValue.GetType();
                    List<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

                    var _budgetSourceId = nameof(BUTransferDetailModel.BudgetSourceId); // Nguồn
                    var _budgetChapterCode = nameof(BUTransferDetailModel.BudgetChapterCode); // Chương
                    var _budgetKindItemCode = nameof(BUTransferDetailModel.BudgetKindItemCode); // Loại khoản
                    var _budgetSubKindItemCode = nameof(BUTransferDetailModel.BudgetSubKindItemCode); // Khoản
                                                                                                      //var _cashWithdrawTypeId = nameof(BUTransferDetailModel.CashWithDrawTypeId); // Nghiệp vụ
                                                                                                      //var _methodDistributeId = nameof(BUTransferDetailModel.MethodDistributeId); // Cấp phát

                    var _debitAccount = nameof(BUTransferDetailModel.DebitAccount); // Tài khoản nợ
                    var _creditAccount = nameof(BUTransferDetailModel.CreditAccount); // Tài khoản có

                    if (view.Columns["CurrencyId"] != null)
                    {
                        view.SetFocusedRowCellValue("CurrencyId", GlobalVariable.MainCurrencyId);
                    }

                    if (view.Columns["ExchangeRate"] != null)
                    {
                        view.SetFocusedRowCellValue("ExchangeRate", 1);
                    }

                    // Nguồn mặc định
                    if (props.Exists(m => m.Name.Equals(_budgetSourceId)))
                    {
                        view.SetFocusedRowCellValue(_budgetSourceId, GlobalVariable.DefaultBudgetSourceID);
                    }

                    // Chương mặc định
                    if (props.Exists(m => m.Name.Equals(_budgetChapterCode)))
                    {
                        view.SetFocusedRowCellValue(_budgetChapterCode, GlobalVariable.DefaultBudgetChapterCode);
                    }

                    // Loại khoản ngầm định
                    if (props.Exists(m => m.Name.Equals(_budgetKindItemCode)))
                    {
                        view.SetFocusedRowCellValue(_budgetKindItemCode, GlobalVariable.DefaultBudgetKindItemCode);
                    }

                    // Khoản ngầm định
                    if (props.Exists(m => m.Name.Equals(_budgetSubKindItemCode)))
                    {
                        view.SetFocusedRowCellValue(_budgetSubKindItemCode,
                            GlobalVariable.DefaultBudgetSubKindItemCode);
                    }

                    //// Nghiệp vụ ngầm định
                    //if (props.Exists(m => m.Name.Equals(_cashWithdrawTypeId)))
                    //{
                    //    view.SetFocusedRowCellValue(_cashWithdrawTypeId, GlobalVariable.DefaultCashWithDrawTypeID);
                    //}
                    //else if (props.Exists(m => m.Name.Equals(nameof(CashWithdrawTypeModel.CashWithdrawTypeId))))
                    //{
                    //    view.SetFocusedRowCellValue(nameof(CashWithdrawTypeModel.CashWithdrawTypeId),
                    //        GlobalVariable.DefaultCashWithDrawTypeID);
                    //}

                    // Cấp phát ngầm định
                    //if (props.Exists(m => m.Name.Equals(_methodDistributeId)))
                    //{
                    //    view.SetFocusedRowCellValue(_methodDistributeId, GlobalVariable.DefaultMethodDistributeID);
                    //}

                    var defaultDebitAccount = BusinessExtension.DefaultDebitAccount(this.AccountLists?.ToList(),
                        (int)BaseRefTypeId, RefTypes.ToList());
                    var defaultCreditAccount = BusinessExtension.DefaultCreditAccount(this.AccountLists?.ToList(),
                        (int)BaseRefTypeId, RefTypes.ToList());
                    // Tài khoản nợ ngầm định
                    if (props.Exists(m => m.Name.Equals(_debitAccount)) && defaultDebitAccount != null)
                    {
                        view.SetFocusedRowCellValue(_debitAccount, defaultDebitAccount?.AccountNumber);
                    }

                    // Tài khoản có ngầm định
                    if (props.Exists(m => m.Name.Equals(_creditAccount)) && defaultCreditAccount != null)
                    {
                        view.SetFocusedRowCellValue(_creditAccount, defaultCreditAccount?.AccountNumber);
                    }
                }
                else
                {
                    view.AddNewRow();
                }
            }

        }

        protected void SetDetailFromMaster(GridView view, int action, string accountingObjectValue, string bankValue, string projectValue)
        {

            var _accountingObjectId = nameof(AccountingObjectModel.AccountingObjectId); // Đối tượng
            var _bankId = nameof(BankModel.BankId); // Ngân hàng
            var _projectId = nameof(ProjectModel.ProjectId); // CTMT,Dự án
                                                             //grdAccounting.ForceInitialize();
                                                             //grdAccountingDetail.ForceInitialize();
                                                             //grdDetailByInventoryItem.ForceInitialize();
            if (action == 0) //Trường hợp thêm dòng mới
            {
                var dataSource = view.DataSource;
                if (dataSource != null && dataSource.GetType() == typeof(BindingSource))
                {
                    var bindingSource = (BindingSource)dataSource;
                    var currentValue = bindingSource.Current;
                    if (currentValue != null)
                    {
                        var type = currentValue.GetType();
                        List<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
                        // Đối tượng
                        if (props.Exists(m => m.Name.Equals(_accountingObjectId)) ||
                            !string.IsNullOrEmpty(accountingObjectValue))
                        {
                            view.SetFocusedRowCellValue(_accountingObjectId, accountingObjectValue);
                        }

                        // Ngân hàng
                        if (props.Exists(m => m.Name.Equals(_bankId)) || !string.IsNullOrEmpty(bankValue))
                        {
                            view.SetFocusedRowCellValue(_bankId, bankValue);
                        }

                        // CTMT Dự án
                        if (props.Exists(m => m.Name.Equals(_projectId)) || !string.IsNullOrEmpty(projectValue))
                        {
                            view.SetFocusedRowCellValue(_projectId, projectValue);
                        }
                    }
                }
            }

            else

            {
                grdAccounting.ForceInitialize();
                grdAccountingDetail.ForceInitialize();
                grdDetailByInventoryItem.ForceInitialize();

                if (action == 1) //Trường hợp update lại toàn bộ đối tượng trên lưới khi thay đổi master
                {
                    foreach (GridView grdView in dsView.Values)
                    {
                        if (grdView.Columns.ColumnByFieldName(_accountingObjectId) != null &&
                            !string.IsNullOrEmpty(accountingObjectValue))
                        {
                            if (grdView.Columns.ColumnByFieldName(_accountingObjectId).Visible)
                            {
                                for (int i = 0; i < grdView.RowCount; i++)
                                {
                                    // Đối tượng
                                    //grdView.SetRowCellValue(i, _accountingObjectId, accountingObjectValue);
                                    //}
                                    grdView.SetRowCellValue(i, _accountingObjectId, accountingObjectValue);

                                }
                            }
                        }
                    }
                }
                else if (action == 2) //Trường hợp update lại toàn bộ tk ngân hàng trên lưới khi thay đổi master
                {

                    foreach (GridView grdView in dsView.Values)
                    {
                        if (grdView.Columns.ColumnByFieldName(_bankId) != null &&
                            !string.IsNullOrEmpty(bankValue))
                        {
                            if (grdView.Columns.ColumnByFieldName(_bankId).Visible)
                            {
                                for (int i = 0; i < grdView.RowCount; i++)
                                {
                                    // TK Ngân hàng
                                    grdView.SetRowCellValue(i, _bankId, bankValue);

                                }
                            }
                        }
                    }

                }
                else if (action == 3) //Trường hợp update lại toàn bộ CTMT dự án trên lưới khi thay đổi master
                {

                    foreach (GridView grdView in dsView.Values)
                    {
                        if (grdView.Columns.ColumnByFieldName(_projectId) != null &&
                            !string.IsNullOrEmpty(projectValue))
                        {
                            if (grdView.Columns.ColumnByFieldName(_projectId).Visible)
                            {
                                for (int i = 0; i < grdView.RowCount; i++)
                                {
                                    // CTMT Dự án
                                    grdView.SetRowCellValue(i, _projectId, projectValue);
                                }
                            }
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Handles the FormClosing event of the FrmXtraBaseVoucherDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FrmXtraBaseVoucherDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmSaveDataChanged();
        }

        /// <summary>
        /// Handles the ButtonClick event of the txtDescription_Properties control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs" /> instance containing the event data.</param>
        protected void txtDescription_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (grdAccountingView.RowCount > 0)
            {
                txtDescription.Text = "";
                for (int i = 0; i < grdAccountingView.RowCount; i++)
                {
                    var description = grdAccountingView.GetRowCellValue(i, "Description");
                    if (description == null) description = grdAccountingView.GetRowCellValue(i, "ItemName");
                    if (description != null)
                        txtDescription.Text = string.IsNullOrEmpty(txtDescription.Text)
                            ? description.ToString()
                            : txtDescription.Text + ", " + description;
                }
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the gridViewMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void gridViewMaster_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SAmountEx))
                SAmountEx = "Amount";
            if (string.IsNullOrEmpty(SAmountOCEx))
                SAmountOCEx = "AmountOC";
            if (string.IsNullOrEmpty(SAmountExParallel))
                SAmountExParallel = SAmountEx;
            if (string.IsNullOrEmpty(SAmountOCExParallel))
                SAmountOCExParallel = SAmountOCEx;
            BaseEdit edit = (sender as GridView).ActiveEditor;
            if (DesignMode) return;
            if (e.Column.FieldName == "CurrencyCode")
            {
                // ẩn hiện cột số tiền quy đổi 
                // ẩn hiện cột số tiền quy đổi của hạch toán đồng thời và mở rộng grid của master khi cột số tiền quy đổi không phải là amount 
                // by ngoc pt
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    HidenGridViewByCurrencyCode(e.Value.ToString(), SAmountEx, SAmountExParallel);
                     HiddenParallelAndOpenByCurrencyCode(sender, e);
                }
                if (e.Value == null)
                {
                    gridViewMaster.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                    gridViewMaster.SetRowCellValue(0, "ExchangeRate", 1);

                    gridViewMaster.Columns["CurrencyCode"].OptionsColumn.AllowEdit = true;
                    gridViewMaster.SetRowCellValue(0, "CurrencyCode", GlobalVariable.MainCurrencyId);
                }
                else if (e.Value.Equals(GlobalVariable.MainCurrencyId))
                {
                    gridViewMaster.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                    gridViewMaster.SetRowCellValue(0, "ExchangeRate", 1);
                }
                else
                {
                    gridViewMaster.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                }
            }
            if (e.Column.FieldName == "ExchangeRate" || e.Column.FieldName == "TotalAmountOC")
            {
                try
                {
                    var exchangeRate = gridViewMaster.Columns.ColumnByFieldName("ExchangeRate") == null || gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null
                    ? 0
                    : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                    var totalAmount = gridViewMaster.Columns.ColumnByFieldName("TotalAmountOC") == null || gridViewMaster.GetRowCellValue(0, "TotalAmountOC") == null
                        ? 0
                        : (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC");
                    exchangeRate = exchangeRate == 0 ? 1 : exchangeRate;
                    if (edit != null && e.Column.FieldName == "ExchangeRate")
                    {
                        checkLoad = true;
                        if (checkLoad)
                        {
                            SetAmountByExchangeRate(exchangeRate, grdAccountingView, SAmountOCEx, SAmountEx);
                            SetAmountByExchangeRate(exchangeRate, grdDetailByInventoryItemView, SAmountOCEx, SAmountEx);
                            if (grdViewParallel != null)
                                SetAmountByExchangeRate(exchangeRate, grdViewParallel, SAmountOCExParallel, SAmountExParallel);
                            SetAmountByExchangeRate(sender, e);
                            checkLoad = true;
                        }
                    }

                    gridViewMaster.SetRowCellValue(0, "TotalAmount", exchangeRate * totalAmount);

                }
                catch (Exception)
                {
                }

            }
            GridViewMasterCellValueChanged(sender, e);
        }

        /// <summary>
        /// Set lai co so tien khi thay doi don gia tren gridViewMaster
        /// </summary>
        public void SetAmountByExchangeRate(decimal exchangeRate, DevExpress.XtraGrid.Views.Grid.GridView grdView, string AmountOC, string Amount)
        {
            try
            {
                for (var i = 0; i < grdView.RowCount; i++)
                {
                    var amountOC = (grdView.Columns.ColumnByFieldName(AmountOC) == null || grdView.GetRowCellValue(i, AmountOC) == null)
                         ? 0
                        : (decimal)grdView.GetRowCellValue(i, AmountOC);
                    if (amountOC * exchangeRate > 0)
                    {
                        grdView.SetRowCellValue(i, Amount, (decimal)(amountOC * exchangeRate));
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Set lai co so tien khi thay doi don gia tren gridViewMaster
        /// </summary>
        protected virtual void SetAmountByExchangeRate(object sender, CellValueChangedEventArgs e)
        {

        }
        /// <summary>
        /// LinhMC thêm ngày 31/12/2014 - The day end of year
        /// Để valid dữ liệu trong trường hợp người dùng đã lưu dữ liệu từ trước nhưng có thay đổi theo dõi chi tiết theo 1 yếu tố nào đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// LinhMC thêm ngày 31/12/2014 - The day end of year
        /// Để valid dữ liệu trong trường hợp người dùng đã lưu dữ liệu từ trước nhưng có thay đổi theo dõi chi tiết theo 1 yếu tố nào đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdAccountingView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateDetailBy();
        }

        /// <summary>
        /// Handles the KeyDown event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdAccountingView_KeyDown(object sender, KeyEventArgs e)

        {
            var view = sender as GridView;
            if (view != null &&
                (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.Enter) &&
                 ActionMode != ActionModeVoucherEnum.None))
            {
                CopyAndPasteRowItem(view);
                e.Handled = true;
            }
        }
        private void grdDetailByInventoryItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("Delete row?", "Confirmation", MessageBoxButtons.YesNo) !=
                  DialogResult.Yes)
                    return;
                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
            }
        }


        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SAmountEx))
                SAmountEx = "Amount";
            if (string.IsNullOrEmpty(SAmountOCEx))
                SAmountOCEx = "AmountOC";
            if (string.IsNullOrEmpty(SAmountExParallel))
                SAmountExParallel = SAmountEx;
            if (string.IsNullOrEmpty(SAmountOCExParallel))
                SAmountOCExParallel = SAmountOCEx;
            if (DesignMode) return;
            if (e.Column.FieldName == SAmountOCEx)
            {
                var amountOC = (grdAccountingView.Columns.ColumnByFieldName(SAmountOCEx) == null || grdAccountingView.GetRowCellValue(e.RowHandle, SAmountOCEx) == null)
                    ? 0
                    : (decimal)grdAccountingView.GetRowCellValue(e.RowHandle, SAmountOCEx);
                var exchangeRate = (gridViewMaster.Columns.ColumnByFieldName("ExchangeRate") == null || gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null)
                    ? 0
                    : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdAccountingView.SetRowCellValue(e.RowHandle, SAmountEx, exchangeRate * amountOC);

                decimal totalAmountOC = 0;
                for (var i = 0; i < grdAccountingView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmountOC += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmountOC += decimal.Parse(rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountOCEx).GetValue(rowVoucher, null) == null ? "0" : rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountOCEx).GetValue(rowVoucher, null).ToString());
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmountOC += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);

            }
            //Tunv 
            if (e.Column.FieldName == SAmountEx)
            {
                decimal totalAmount = 0;
                //grdAccounting.RefreshDataSource();
                for (var i = 0; i < grdAccountingView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmount += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmount += decimal.Parse(rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountEx).GetValue(rowVoucher, null) == null ? "0" : rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountEx).GetValue(rowVoucher, null).ToString());
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmount += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmount);
            }
            //cho phep cac thanh con chen them
            GridAccountingCellValueChanged(sender, e);
        }

        private void grdAccountingView_MouseDown(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;
            GridAccountingMouseDown(sender, e);
        }
        /// <summary>
        /// FRMs the xtra base voucher detail post automatic business.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="autoBusinessModel">The automatic business model.</param>
        public void FrmXtraBaseVoucherDetail_PostAutoBusiness(object sender, AutoBusinessModel autoBusinessModel)
        {
            AutoBusinessModel = autoBusinessModel;
        }

        #endregion

        #region IReportView Members

        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        public List<ReportListModel> ReportLists
        {
            get { return _reportList; }
            set { _reportList = value; }
        }
        public IList<AccountingObjectCategoryModel> AccountingObjectCategories
        {
            set
            {
                value.Add(
                    new AccountingObjectCategoryModel
                    {
                        AccountingObjectCategoryCode = "NV",
                        AccountingObjectCategoryName = "Nhân Viên",
                        AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000",
                        IsActive = true,
                        IsSystem = false
                    }
                );
                lkAccountingObjectCategory.Properties.DataSource = value;
                lkAccountingObjectCategory.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryCode",
                        ColumnCaption = "Mã loại đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryName",
                        ColumnCaption = "Tên loại đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkAccountingObjectCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkAccountingObjectCategory.Properties.SortColumnIndex = column.ColumnPosition;
                        lkAccountingObjectCategory.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        lkAccountingObjectCategory.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                lkAccountingObjectCategory.Properties.DisplayMember = "AccountingObjectCategoryCode";
                lkAccountingObjectCategory.Properties.ValueMember = "AccountingObjectCategoryId";


            }
        }
        #endregion

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Res the fresh control.
        /// </summary>
        protected virtual void ReFreshControl()
        {

        }

        /// <summary>
        /// ThangNk 28/08/2015
        /// </summary>
        /// <param name="accountcode">Tài khoản tính dư tồn</param>
        /// <param name="currencyCode">The currency code.</param>
        public void ShowBarAmountExist(string accountcode, string currencyCode)
        {
            barAmountExist.Visibility = BarItemVisibility.Always;
            barAmountExist.Caption = @"Dư tồn:" +
                                     String.Format("{0:C}",
                                         _calculateClosingPresenter.AmountExist(accountcode, currencyCode));
        }

        #region Grid View Accounting Detail

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdAccountingDetailView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec,
                    e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                if (view != null)
                {
                    SetDefaultValue(view);
                    SetDetailFromMaster(view, 0, AutoAccountingObjectId, AutoBankId, AutoProjectId);
                }
                if (!IsCopyRow)
                {
                    InitDetailRowForAcountingDetail(e, view);
                }
                else
                {
                    InitCopyNewRow(e, view);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clipboard.Clear();
            }
        }

        /// <summary>
        /// Handles the InvalidRowException event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InvalidRowExceptionEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        /// <summary>
        /// Handles the RowCountChanged event of the grdAccoDuntingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateDetailByForAccountingDetail();
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid)
                return;
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupGridDetailMenu.ShowPopup(grdAccountingDetail.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode) return;
            try
            {
                //cho phep cac thanh con chen them
                GridAccountingDetailCellValueChanged(sender, e);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Grid View Tax

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdTaxView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdTaxView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)

        {
            var viewInfo = (GridViewInfo)grdTaxView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec,
                    e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdTaxView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdTaxView_InitNewRow(object sender, InitNewRowEventArgs e)

        {
            try
            {
                var view = (GridView)sender;
                if (view != null)
                {
                    SetDefaultValue(view);
                    SetDetailFromMaster(view, 0, AutoAccountingObjectId, AutoBankId, AutoProjectId);
                }
                if (!IsCopyRow)
                {
                    InitDetailRowForAcountingDetailByTax(e, view);
                }
                else
                {
                    InitCopyNewRow(e, view);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clipboard.Clear();
            }
        }

        /// <summary>
        /// Handles the RowCountChanged event of the grdTaxView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdTaxView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateDetailByForDetailTax();
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdTaxView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdTaxView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode) return;
            GridTaxCellValueChanged(sender, e);
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdTaxView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdTaxView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid)
                return;
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    grdTaxViewPopupMenuShowing(hitInfo, e, grdTax, view, popupGridDetailMenuByTax);
                }
            }
        }

        /// <summary>
        /// Popups the menu showing.
        /// </summary>
        protected virtual void grdTaxViewPopupMenuShowing(GridHitInfo hitInfo, PopupMenuShowingEventArgs e,
            GridControl gridControl, GridView gridView, PopupMenu popupMenu)
        {
            gridView.FocusedRowHandle = hitInfo.RowHandle;
            popupMenu.ShowPopup(gridControl.PointToScreen(e.Point));
        }

        #endregion

        #region  grd Detail By InventoryItem

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        protected virtual void grdDetailByInventoryItemView_CustomDrawColumnHeader(object sender,
            ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)grdDetailByInventoryItemView.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null)
                return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible)
                        continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec,
                    e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                if (view != null)
                {
                    SetDefaultValue(view);
                    SetDetailFromMaster(view, 0, AutoAccountingObjectId, AutoBankId, AutoProjectId);
                }
                if (!IsCopyRow)
                {
                    InitDetailRowForAcountingDetailByInventoryItem(e, view);
                }
                else
                {
                    InitCopyNewRow(e, view);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clipboard.Clear();
            }
        }

        /// <summary>
        /// Handles the RowCountChanged event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_RowCountChanged(object sender, EventArgs e)
        {
            UpdateDetailByForDetailInventoryItem();
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SAmountEx))
                SAmountEx = "Amount";
            if (string.IsNullOrEmpty(SAmountOCEx))
                SAmountOCEx = "AmountOC";
            if (string.IsNullOrEmpty(SAmountExParallel))
                SAmountExParallel = SAmountEx;
            if (string.IsNullOrEmpty(SAmountOCExParallel))
                SAmountOCExParallel = SAmountOCEx;
            if (DesignMode) return;
            if (e.Column.FieldName == SAmountOCEx)
            {
                var amountOC = grdDetailByInventoryItemView.Columns.ColumnByFieldName(SAmountOCEx) == null || grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, SAmountOCEx) == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, SAmountOCEx);
                var exchangeRate = gridViewMaster.Columns.ColumnByFieldName("ExchangeRate") == null || gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null
                    ? 0
                    : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, SAmountEx, exchangeRate * amountOC);

                decimal totalAmountOC = 0;
                for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmountOC += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmountOC += decimal.Parse(rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountOCEx).GetValue(rowVoucher, null) == null ? "0" : rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountOCEx).GetValue(rowVoucher, null).ToString());
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmountOC += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
            }
            if (e.Column.FieldName == SAmountEx)
            {
                decimal totalAmount = 0;
                //grdAccounting.RefreshDataSource();
                for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmount += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var a = rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountEx).GetValue(rowVoucher, null);
                            totalAmount += decimal.Parse(rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountEx).GetValue(rowVoucher, null) == null ? "0" : rowVoucher.GetType().GetProperties().First(o => o.Name == SAmountEx).GetValue(rowVoucher, null).ToString());
                        }

                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmount += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmount);
            }
            GridPurchaseCellValueChanged(sender, e);
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs"/> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid)
                return;
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupGridDetailMenu.ShowPopup(grdDetailByInventoryItem.PointToScreen(e.Point));
                }
            }
        }

        #endregion

        internal class MasterGrid
        {
            public string CurrencyCode { get; set; }

            public decimal TotalAmount { get; set; }

            public decimal ExchangeRate { get; set; }

            public decimal TotalAmountOC { get; set; }
        }

        /// <summary>
        /// Handles the ShownEditor event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_ShownEditor(object sender, EventArgs e)
        {

            var view = (GridView)sender;
            if (view.IsNewItemRow(view.FocusedRowHandle))
            {

            }
            GridPurchaseShowEditor(sender, e);
        }

        public void Valid_dtPostedDate()
        {
            try
            {
                if (DateTime.Parse(dtPostDate.Text) < DateTime.Parse(GlobalVariable.SystemDate))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostedDateLessSysemDate"),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the barLargeButtonUtility control.
        /// </summary>upda
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void barLargeButtonUtility_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// Adjusts the size of the control.
        /// KienNT tính lại kích thước các control
        /// </summary>
        /// <param name="panel1">The panel1.</param>
        /// <param name="isPanel">if set to <c>true</c> [is panel].</param>
        /// <param name="isGrdMaster">if set to <c>true</c> [is GRD master].</param>
        protected virtual void AdjustControlSize(Panel panel1, bool isPanel, bool isGrdMaster)
        {
            if (isPanel == true)
            {
                int formHeight = this.Height;
                int grVoucherHeight = groupVoucher.Height;
                int ygrVoucherHeight = groupVoucher.Location.Y;
                int yMaster = grVoucherHeight + ygrVoucherHeight + 7;
                int grMasterHeigh = 0;
                int ytabMain = 0;
                int grdLayoutHeight = 0;
                int tabMainHeight = 0;
                int tabMainWith = 0;
                int ypanel1 = 0;
                int panel1Height = 0;
                if (isGrdMaster == true)
                {
                    grMasterHeigh = grdMaster.Height;
                    grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, tabMainHeight - 70);
                    tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                }

                else

                {
                    //grMasterHeigh = grdMaster.Height;
                    //grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, tabMainHeight - 70);
                    tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                }

            }
        }
        public bool IsHiddenAmount
        {
            get
            {
                var currencyCode = gridViewMaster.GetRowCellValue(0, "CurrencyCode");
                return !currencyCode.Equals(GlobalVariable.MainCurrencyId);
            }
        }
        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            //dtRefDate.EditValue = dtPostDate.EditValue;
        }

        protected virtual void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected virtual string AccountingObjectCategoryId
        {
            get
            {
                return lkAccountingObjectCategory.EditValue == null
                    ? null
                    : lkAccountingObjectCategory.EditValue.ToString();
            }
            set { lkAccountingObjectCategory.EditValue = value; }
        }

        protected virtual void ShowAccountingObjectDetail()
        {
            try
            {
                using (var frmDetail = new FrmXtraAccountingObjectDetail())
                {
                    //frmDetail.KeyFieldName = "AccountId";
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    frmDetail.HelpTopicId = HelpTopicId;
                    frmDetail.KeyValue = null;
                    //frmDetail.ShowDialog();
                    //if (frmDetail.CloseBox)
                    //{
                    //    if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                    //    {
                    //        cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboObjectCode_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowAccountingObjectDetail();
            if (e.Button.Index == 2)
            {
                cboObjectCode.EditValue = null;
                cboObjectName.EditValue = null;
                txtAddress.EditValue = null;
            }
        }

        private void cboBank_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowBankDetail();
        }

        protected virtual void ShowBankDetail()
        {
        }
        public void HidenGridViewByCurrencyCode(string currencyCode, string Amount, string AmountParallel)
        {
            bool visibale = !currencyCode.Equals("VND");
            ShowAmountByCurrencyCode(grdDetailByInventoryItemView, Amount, visibale);
            ShowAmountByCurrencyCode(grdAccountingDetailView, Amount, visibale);
            ShowAmountByCurrencyCode(grdTaxView, Amount, visibale);
            ShowAmountByCurrencyCode(grdAccountingView, Amount, visibale);
            ShowAmountByCurrencyCode(grdViewParallel, AmountParallel, visibale);
        }

        public void ShowAmountByCurrencyCode(GridView gridView, string columnName, bool visible)
        {
            if (gridView == null)
                return;
            if (gridView.Columns.ColumnByFieldName(columnName) != null)
            {
                gridView.Columns.ColumnByFieldName(columnName).Visible = visible;
            }
        }
        public void HiddenColumnGridView(GridView gridView, string columnName)
        {
            if (gridView.Columns.ColumnByFieldName(columnName) != null)
            {
                gridView.Columns.ColumnByFieldName(columnName).Visible = false;
            }
        }

        private void grdDetailByInventoryItemView_MouseDown(object sender, MouseEventArgs e)
        {
            if (DesignMode) return;
            GridDetailByInventoryItemViewMouseDown(sender, e);
        }

        private void grdAccountingView_ShownEditor(object sender, EventArgs e)
        {
            if (DesignMode) return;
            GridPurchaseShowEditor(sender, e);
        }

        private void grdAccountingView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        private void grdAccountingView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //ValidateGridView(sender, e);
        }

        private void grdDetailByInventoryItemView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grdDetailByInventoryItemView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            //e.Valid = ValidateGridView(sender, e);
        }

        private bool CheckExistValidateGridView()
        {
            bool flag = false;
            flag = CheckValidateGridView(grdDetailByInventoryItemView);
            if (!flag)
                flag = CheckValidateGridView(grdAccountingView);
            return flag;
        }
        private bool CheckValidateGridView(GridView gv)
        {
            for (int i = 0; i < gv.DataRowCount; i++)
            {
                gv.FocusedRowHandle = i;
                foreach (DevExpress.XtraGrid.Columns.GridColumn cl in gv.Columns)
                {
                    if (cl.Visible)
                    {
                        string strErr = gv.GetColumnError(cl);
                        if (!string.IsNullOrEmpty(strErr))
                        {
                            XtraMessageBox.Show(strErr,
                                             ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                            gv.FocusedColumn = cl;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #region simulated mouse click
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public virtual void ClickSomePoint()
        {

            // get mouse position
            System.Drawing.Point screenPos = System.Windows.Forms.Cursor.Position;

            // create X,Y point (0,0) explicitly with System.Drawing 
            System.Drawing.Point leftTop = new System.Drawing.Point(23, 415);

            // set mouse position
            Cursor.Position = leftTop;

            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        #endregion

    }

}



