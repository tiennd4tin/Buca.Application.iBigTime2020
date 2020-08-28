﻿/***********************************************************************
 * <copyright file="FrmXtraBaseCategoryDetail.cs" company="BUCA JSC">
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
 * 27/8/2015: LINHMC   Đưa phần nhật ký vào form base ghi lại thao tác người dùng
 * ************************************************************************/

using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail
{
    public partial class FrmXtraBaseCategoryDetail : XtraForm, IAudittingLogView
    {
        #region Variables

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// Gets or sets the e action mode.
        /// </summary>
        /// <value>
        /// The e action mode.
        /// </value>
        public ActionModeEnum ActionMode;

        /// <summary>
        /// The key for send
        /// </summary>
        protected string KeyForSend;

        /// <summary>
        /// Gets or sets the exchange rate decimal digits.
        /// </summary>
        /// <value>
        /// The exchange rate decimal digits.
        /// </value>
        protected string ExchangeRateDecimalDigits { get; set; }

        /// <summary>
        /// The currency accounting
        /// </summary>
        protected string CurrencyAccounting;

        /// <summary>
        /// The currency accounting usd
        /// </summary>
        protected string CurrencyLocal;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>
        /// The key value.
        /// </value>
        public string KeyValue { get; set; }

        public string TableCode { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        public int HelpTopicId { get; set; }

        /// <summary>
        /// Gets or sets the binding source detail.
        /// </summary>
        /// <value>
        /// The binding source detail.
        /// </value>
        public BindingSource BindingSourceDetail { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            Text = ActionMode == ActionModeEnum.AddNew ? string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption) : string.Format(ResourceHelper.GetResourceValueByName("ResEditText"), FormCaption);
            ExchangeRateDecimalDigits = GlobalVariable.ExchangeRateDecimalDigits;
            CurrencyAccounting = GlobalVariable.MainCurrencyId;
            CurrencyLocal = GlobalVariable.CurrencyLocal;
            InitControls();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        protected virtual void CloseForm()
        {
            using (new FrmBaseList())
            {
                if (PostKeyValue != null)
                    PostKeyValue(this, KeyForSend);
                Close();
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

        #endregion

        #region Functions overrides

        /// <summary>
        /// Shows the help.
        /// </summary>
        protected virtual void ShowHelp()
        {
            if (!File.Exists("BigTime.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BigTime.CHM", HelpNavigator.TopicId, Convert.ToString(HelpTopicId));
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
        /// Focuses the control.
        /// </summary>
        protected virtual void InitControls()
        {
        }

        /// <summary>
        /// Bindings the data to control.
        /// </summary>
        /// <param name="oContainer">The o container.</param>
        public virtual void BindingDataToControl(Control oContainer)
        {
            try
            {
                if (BindingSourceDetail == null)
                    return;
                foreach (Control oControl in oContainer.Controls)
                {
                    var strTag = (string)oControl.Tag;
                    if (!string.IsNullOrEmpty(strTag))
                    {
                        if (ReferenceEquals(oControl.GetType(), typeof(TextEdit)) || ReferenceEquals(oControl.GetType(), typeof(LabelControl)))
                        {
                            oControl.DataBindings.Add("Text", BindingSourceDetail, strTag);
                        }
                        else
                        {
                            if (oControl.GetType().GetProperty("Checked") != null)
                            {
                                oControl.DataBindings.Add("Checked", BindingSourceDetail, strTag);
                            }
                            else
                            {
                                oControl.DataBindings.Add(
                                    oControl.GetType() == typeof(ComboBoxEdit) ? "SelectedIndex" : "EditValue",
                                    BindingSourceDetail, strTag);
                            }
                        }
                    }
                    else
                    {
                        if (oControl.Controls.Count > 0)
                        {
                            BindingDataToControl(oControl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Formats the control.
        /// </summary>
        protected void FormatControl(Control oContainer)
        {
            var numberDecimalDigits = GlobalVariable.NumberDecimalDigits ?? "0";
            var exchangeRateDecimalDigits = GlobalVariable.ExchangeRateDecimalDigits ?? "2";
            var percentDecimalDigits = GlobalVariable.PercentDecimalDigits ?? "2";
            var currencyDecimalDigits = GlobalVariable.CurrencyDecimalDigits;

            foreach (Control control in oContainer.Controls)
            {
                if (control.GetType() == typeof(DateEdit))
                {

                    ((DateEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((DateEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(SpinEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.Numeric;
                        ((SpinEdit)control).Properties.Mask.EditMask = @"n" + numberDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((SpinEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "c" + exchangeRateDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.Numeric;
                        ((SpinEdit)control).Properties.EditMask = @"P" + percentDecimalDigits;
                        ((SpinEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                    }
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.Numeric;
                        ((SpinEdit)control).Properties.Mask.EditMask = @"c" + currencyDecimalDigits;
                    }
                    ((SpinEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((SpinEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(CalcEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = @"n" + GlobalVariable.NumberDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((CalcEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((CalcEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "c" + exchangeRateDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision = int.Parse(exchangeRateDecimalDigits);
                    }
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = @"P" + percentDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = @"c" + currencyDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision = currencyDecimalDigits;
                    }
                    ((CalcEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((CalcEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.Controls.Count > 0)
                {
                    FormatControl(control);
                }
            }
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (!DesignMode)
            {
                var currencyDecimalDigits = GlobalVariable.CurrencyDecimalDigits;
                var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit();
                foreach (GridColumn oCol in gridView.Columns)
                {
                    if (!oCol.Visible)
                        continue;
                    switch (oCol.UnboundType)
                    {
                        case UnboundColumnType.Decimal:
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + currencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            //LinhMC thêm 24/8/2015:
                            repositoryCurrencyCalcEdit.Precision = currencyDecimalDigits;
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
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                            break;

                        case UnboundColumnType.DateTime:
                            oCol.DisplayFormat.FormatString =
                                Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBaseCategoryDetail"/> class.
        /// </summary>
        public FrmXtraBaseCategoryDetail()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraBaseCategoryDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraBaseCategoryDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode)
                    return;
                InitializeLayout();
                InitData();
                FormatControl(this);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected string GetAutoNumber()
        {
            if (!string.IsNullOrEmpty(TableCode))
            {
                //var objAutoNumberList = new Model.Model().GetAutoNumberList(TableCode);
                //string str = @"00000000000000000000000000000";
                //str = str.Substring(0, objAutoNumberList.LengthOfValue - objAutoNumberList.Value.ToString(CultureInfo.InvariantCulture).Length);
                //return (objAutoNumberList.Prefix + str + objAutoNumberList.Value);
            }
            return "";
        }

        /// <summary>
        /// Handles the Click event of the btnHelp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidData())
                {
                    var result = SaveData();
                    if (!string.IsNullOrEmpty(result))
                    {
                        SaveAuditingLog();//LINHMC ADD 27/8/2012
                        KeyForSend = ActionMode == ActionModeEnum.AddNew ? result : KeyValue;
                        CloseForm();
                    }
                    else
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// In thẻ
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintFixAsset_Click(object sender, EventArgs e)
        {
            PrintFixAsset(sender, e);
        }

        protected virtual void PrintFixAsset(object sender, EventArgs e)
        {

        }
        #endregion

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        //    public int EventId { get; set; }

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
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    case ActionModeEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    case ActionModeEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    default:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
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


        public string EventId { get; set; }


        #endregion
    }
}