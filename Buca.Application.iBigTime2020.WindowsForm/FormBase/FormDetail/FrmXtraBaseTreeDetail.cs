using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
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
    /// <summary>
    /// FrmXtraBaseTreeDetail
    /// </summary>
    /// <seealso cref="DevExpress.XtraEditors.XtraForm" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAudittingLogView" />
    public partial class FrmXtraBaseTreeDetail : XtraForm, IAudittingLogView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBaseTreeDetail"/> class.
        /// </summary>
        public FrmXtraBaseTreeDetail()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }

        /// <summary>
        /// Gets the automatic number.
        /// </summary>
        /// <returns></returns>
        protected string GetAutoNumber()
        {
            if (!string.IsNullOrEmpty(TableCode))
            {
                //var objAutoNumberList = new Model.Model().GetAutoNumberList(TableCode);
                //str = str.Substring(0, objAutoNumberList.LengthOfValue - objAutoNumberList.Value.ToString(CultureInfo.InvariantCulture).Length);
                //return (objAutoNumberList.Prefix + str + objAutoNumberList.Value);
            }
            return "";
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraBaseTreeDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmXtraBaseTreeDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;
                InitializeLayout();
                InitData();
                FormatControl(this);
                if (ActionMode == ActionModeEnum.AddNew) AutoRefNo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidData())
                {
                    var result = SaveData();
                    if (!string.IsNullOrEmpty(result))
                    {
                        SaveAuditingLog(); //LINHMC ADD 27/8/2012
                        _keyForSend = ActionMode == ActionModeEnum.AddNew ? result : KeyValue;
                        if (result != "ok")
                        {
                            CloseForm();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (result == "ok")
                    { XtraMessageBox.Show("Phân quyền thành công"); }
                    else { }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message , ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Handles the Click event of the btnHelp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

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
        private string _keyForSend;

        /// <summary>
        /// The has children
        /// </summary>
        public new bool HasChildren;

        /// <summary>
        /// The currency accounting
        /// </summary>
        protected string CurrencyAccounting;

        /// <summary>
        /// The currency local
        /// </summary>
        protected string CurrencyLocal;

        /// <summary>
        /// The exchange rate decimal digits
        /// </summary>
        protected string ExchangeRateDecimalDigits;

        /// <summary>
        /// The posted date
        /// </summary>
        protected DateTime PostedDate;

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
        [Category("BaseProperty")]
        public string KeyValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the key field.
        /// </summary>
        /// <value>
        /// The name of the key field.
        /// </value>
        [Category("BaseProperty")]
        public string KeyFieldName { get; set; }

        /// <summary>
        /// Gets or sets the name of the parent.
        /// </summary>
        /// <value>
        /// The name of the parent.
        /// </value>
        [Category("BaseProperty")]
        public string ParentName { get; set; }

        /// <summary>
        /// Gets or sets the current row.
        /// </summary>
        /// <value>
        /// The current row.
        /// </value>
        [Category("BaseProperty")]
        public object CurrentNode { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [Category("BaseProperty")]
        public string TableCode { get; set; }

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
            Text = ActionMode == ActionModeEnum.AddNew
                ? string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption)
                : string.Format(ResourceHelper.GetResourceValueByName("ResEditText"), FormCaption);
            CurrencyAccounting = GlobalVariable.MainCurrencyId;
            CurrencyLocal = GlobalVariable.CurrencyLocal;
            ExchangeRateDecimalDigits = GlobalVariable.ExchangeRateDecimalDigits;
            PostedDate = GlobalVariable.PostedDate == null ? DateTime.Today : DateTime.Parse(GlobalVariable.PostedDate);
            InitControls();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            //using (new FrmBaseCategoryList())
            //{
            if (PostKeyValue != null) PostKeyValue(this, _keyForSend);
            Close();
            //}
        }

        /// <summary>
        /// Formats the control.
        /// </summary>
        /// <param name="oContainer">The o container.</param>
        protected void FormatControl(Control oContainer)
        {
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
                        ((SpinEdit)control).Properties.EditMask = "n" + GlobalVariable.NumberDecimalDigits;
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((SpinEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                        ((SpinEdit)control).Properties.EditMask = "c" + GlobalVariable.ExchangeRateDecimalDigits;
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                        ((SpinEdit)control).Properties.EditMask = "P" + GlobalVariable.PercentDecimalDigits;
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                        ((SpinEdit)control).Properties.EditMask = "c" + GlobalVariable.CurrencyDecimalDigits;
                    ((SpinEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((SpinEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(CalcEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "n" + GlobalVariable.NumberDecimalDigits;
                    }
                    else if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((CalcEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((CalcEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    else if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "c" + GlobalVariable.ExchangeRateDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision =
                            int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                    }
                    else if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "P" + GlobalVariable.PercentDecimalDigits;
                    }
                    else
                    {
                        ((CalcEdit)control).Properties.EditMask = "c" + GlobalVariable.CurrencyDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision = GlobalVariable.CurrencyDecimalDigits;
                    }
                    ((CalcEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((CalcEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.Controls.Count > 0)
                    FormatControl(control);
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
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId,
                Convert.ToString(HelpTopicId));
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected virtual bool 
            
            ValidData()
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
        /// Automatics the reference no.
        /// </summary>
        protected virtual void AutoRefNo()
        {
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
                var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit();
                foreach (GridColumn oCol in gridView.Columns)
                {
                    if (!oCol.Visible) continue;
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
            get { return string.IsNullOrEmpty(FormCaption) ? "" : CommonFunction.FirstCharToUpper(FormCaption); }
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
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue;
                    case ActionModeEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue;
                    case ActionModeEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue;
                    default:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue;
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



        public static void ShowXtraColumnInLookUpEdit<T>(List<XtraColumn> listXtraColumn, LookUpEdit lookUpEdit)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            int popUpWith = 0;

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = column.ColumnVisible;
                    if (column.ColumnVisible)
                    {
                        lookUpEdit.Properties.Columns[prop.Name].Caption = column.ColumnCaption;
                        //lookUpEdit.Properties.Columns[prop.Name].VisibleIndex = column.ColumnPosition;
                        lookUpEdit.Properties.Columns[prop.Name].Width = column.ColumnWith;
                        popUpWith += column.ColumnWith;
                    }
                }
                else
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = false;
                }
            }

            lookUpEdit.Properties.PopupWidth = popUpWith;
        }
    }
}