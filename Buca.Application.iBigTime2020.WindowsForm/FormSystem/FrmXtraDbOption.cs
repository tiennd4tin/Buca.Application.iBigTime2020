/***********************************************************************
 * <copyright file="FrmXtraFormDbOption.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoNumber;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.DBOption;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using DevExpress.XtraBars;
using Buca.Application.iBigTime2020.WindowsForm.Code;

namespace Buca.Application.iBigTime2020.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraFormDbOption
    /// </summary>
    public partial class FrmXtraFormDbOption : XtraForm, IDBOptionsView, IBudgetChaptersView, IAutoNumbersView, IBudgetSourcesView,
        IBudgetKindItemsView, ICashWithdrawTypesView
    {
        #region Presenters

        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly AutoNumbersPresenter _autoNumbersPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        #endregion

        #region Variable

        private readonly IModel _model;
        #endregion

        #region Functions

        /// <summary>
        /// Sets the general format.
        /// </summary>
        private void SetGeneralFormat()
        {
            var numberDecimalDigits = int.Parse(spinNumberDecimalDigits.EditValue.ToString());
            var percentDecimalDigits = int.Parse(spinPercentDecimalDigits.EditValue.ToString());
            var exchangeRateDecimalDigits = int.Parse(spinExchangeRateDecimalDigits.EditValue.ToString());
            var amountOCDecimalDigits = int.Parse(spinAmountOCDecimalDigits.EditValue.ToString());

            var generalDecimalSeparator = "";
            switch (cboGeneralDecimalSeparator.SelectedIndex)
            {
                case 0:
                    generalDecimalSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 1:
                    generalDecimalSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 2:
                    generalDecimalSeparator = " ";
                    break;
            }

            var generalGroupSeparator = "";
            switch (cboGeneralGroupSeparator.SelectedIndex)
            {
                case 0:
                    generalGroupSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 1:
                    generalGroupSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 2:
                    generalGroupSeparator = " ";
                    break;
            }

            var defaultValue = "1" + generalDecimalSeparator + "234" + generalDecimalSeparator + "456" + generalDecimalSeparator + "789";

            #region number currency digits

            if (numberDecimalDigits > 0)
            {
                lblNumberDecimalDigits.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < numberDecimalDigits; i++)
                    lblNumberDecimalDigits.Text += @"0";
            }
            else
            {
                lblNumberDecimalDigits.Text = defaultValue;
            }

            var numberNegativePattern = cboNumberNegativePattern.SelectedIndex;
            if (cboNumberNegativePattern.EditValue != null)
            {
                switch (numberNegativePattern)
                {
                    case 0:
                        lblNumberDecimalDigits.Text = @"(" + lblNumberDecimalDigits.Text + @")";
                        break;
                    case 1:
                        lblNumberDecimalDigits.Text = @"-" + lblNumberDecimalDigits.Text;
                        break;
                    case 2:
                        lblNumberDecimalDigits.Text = @"- " + lblNumberDecimalDigits.Text;
                        break;
                    case 3:
                        lblNumberDecimalDigits.Text = lblNumberDecimalDigits.Text + @"-";
                        break;
                    case 4:
                        lblNumberDecimalDigits.Text = lblNumberDecimalDigits.Text + @" -";
                        break;
                }
            }

            #endregion

            #region Percent Decimal digits

            if (percentDecimalDigits > 0)
            {
                lblPercentDecimalDigits.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < percentDecimalDigits; i++)
                    lblPercentDecimalDigits.Text += @"0";
            }
            else
            {
                lblPercentDecimalDigits.Text = defaultValue;
            }

            #endregion

            #region Exchange Rate Decimal Digits

            if (exchangeRateDecimalDigits > 0)
            {
                lblExchangeRateDecimalDigits.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < exchangeRateDecimalDigits; i++)
                    lblExchangeRateDecimalDigits.Text += @"0";
            }
            else
            {
                lblExchangeRateDecimalDigits.Text = defaultValue;
            }

            #endregion

            #region AmountOC Decimal Digits

            if (amountOCDecimalDigits > 0)
            {
                lblAmountOCDecimalDigits.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < amountOCDecimalDigits; i++)
                    lblAmountOCDecimalDigits.Text += @"0";
            }
            else
            {
                lblAmountOCDecimalDigits.Text = defaultValue;
            }

            #endregion
        }

        /// <summary>
        /// Sets the currency format.
        /// </summary>
        private void SetCurrencyFormat()
        {
            var currencyDecimalDigits = int.Parse(spinCurrencyDecimalDigits.EditValue.ToString());
            var currencyUnitPriceDigits = int.Parse(spinCurrencyUnitPriceDigits.EditValue.ToString());
            var currencySymbol = cboCurrencySymbol.SelectedIndex == 0 ? "" : cboCurrencySymbol.Text;

            var generalDecimalSeparator = "";
            switch (cboGeneralGroupSeparator.SelectedIndex)
            {
                case 0:
                    generalDecimalSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 1:
                    generalDecimalSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 2:
                    generalDecimalSeparator = " ";
                    break;
            }

            var generalGroupSeparator = "";
            switch (cboGeneralDecimalSeparator.SelectedIndex)
            {
                case 0:
                    generalGroupSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 1:
                    generalGroupSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 2:
                    generalGroupSeparator = " ";
                    break;
            }

            var defaultValue = "1" + generalDecimalSeparator + "234" + generalDecimalSeparator + "456" + generalDecimalSeparator + "789";

            #region currency digits

            if (currencyDecimalDigits > 0)
            {
                lblCurrencyNegativePattern.Text = defaultValue + generalGroupSeparator;
                lblCurrencyPositivePattern.Text = defaultValue + generalGroupSeparator;

                for (var i = 0; i < currencyDecimalDigits; i++)
                {
                    lblCurrencyNegativePattern.Text += @"0";
                    lblCurrencyPositivePattern.Text += @"0";
                }
            }
            else
            {
                lblCurrencyNegativePattern.Text = defaultValue;
                lblCurrencyPositivePattern.Text = defaultValue;
            }

            var currencyNegativePattern = cboCurrencyNegativePattern.SelectedIndex;
            if (cboCurrencyNegativePattern.EditValue != null)
            {
                switch (currencyNegativePattern)
                {
                    case 0:
                        lblCurrencyNegativePattern.Text = @"(" + currencySymbol + lblCurrencyNegativePattern.Text + @")";
                        break;
                    case 1:
                        lblCurrencyNegativePattern.Text = @"-" + currencySymbol + lblCurrencyNegativePattern.Text;
                        break;
                    case 2:
                        lblCurrencyNegativePattern.Text = currencySymbol + @"-" + lblCurrencyNegativePattern.Text;
                        break;
                    case 3:
                        lblCurrencyNegativePattern.Text = currencySymbol + lblCurrencyNegativePattern.Text + @"-";
                        break;
                    case 4:
                        lblCurrencyNegativePattern.Text = @"(" + lblCurrencyNegativePattern.Text + currencySymbol + @")";
                        break;
                    case 5:
                        lblCurrencyNegativePattern.Text = @"-" + lblCurrencyNegativePattern.Text + @" " + currencySymbol;
                        break;
                    case 6:
                        lblCurrencyNegativePattern.Text = lblCurrencyNegativePattern.Text + @"-" + currencySymbol;
                        break;
                    case 7:
                        lblCurrencyNegativePattern.Text = lblCurrencyNegativePattern.Text + @" " + currencySymbol + @"-";
                        break;
                    case 8:
                        lblCurrencyNegativePattern.Text = @"-" + lblCurrencyNegativePattern.Text + @" " + currencySymbol;
                        break;
                    case 9:
                        lblCurrencyNegativePattern.Text = @"-" + currencySymbol + @" " + lblCurrencyNegativePattern.Text;
                        break;
                    case 10:
                        lblCurrencyNegativePattern.Text = lblCurrencyNegativePattern.Text + @" " + currencySymbol + @"-";
                        break;
                    case 11:
                        lblCurrencyNegativePattern.Text = currencySymbol + @" " + lblCurrencyNegativePattern.Text + @"-";
                        break;
                    case 12:
                        lblCurrencyNegativePattern.Text = currencySymbol + @"-" + lblCurrencyNegativePattern.Text;
                        break;
                    case 13:
                        lblCurrencyNegativePattern.Text = lblCurrencyNegativePattern.Text + @"- " + currencySymbol;
                        break;
                    case 14:
                        lblCurrencyNegativePattern.Text = @"(" + currencySymbol + @" " + lblCurrencyNegativePattern.Text + @")";
                        break;
                    case 15:
                        lblCurrencyNegativePattern.Text = @"(" + lblCurrencyNegativePattern.Text + @" " + currencySymbol + @")";
                        break;
                }
            }

            var currencyPositivePattern = cboCurrencyPositivePattern.SelectedIndex;
            if (cboCurrencyPositivePattern.EditValue != null)
            {
                switch (currencyPositivePattern)
                {
                    case 0:
                        lblCurrencyPositivePattern.Text = currencySymbol + lblCurrencyPositivePattern.Text;
                        break;
                    case 1:
                        lblCurrencyPositivePattern.Text = lblCurrencyPositivePattern.Text + currencySymbol;
                        break;
                    case 2:
                        lblCurrencyPositivePattern.Text = currencySymbol + @" " + lblCurrencyPositivePattern.Text;
                        break;
                    case 3:
                        lblCurrencyPositivePattern.Text = lblCurrencyPositivePattern.Text + @" " + currencySymbol;
                        break;
                }
            }

            #endregion

            #region Currency Unit Price Digits

            if (currencyUnitPriceDigits > 0)
            {
                lblCurrencyUnitPriceDigits.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < currencyUnitPriceDigits; i++)
                    lblCurrencyUnitPriceDigits.Text += @"0";
            }
            else
            {
                lblCurrencyUnitPriceDigits.Text = defaultValue;
            }

            #endregion
        }

        private void SetCurrencyFormatInReport()
        {
            var currencyDecimalDigitsInReport = int.Parse(spinCurrencyDecimalDigitsInReport.EditValue.ToString());
            var currencyUnitPriceDigitsInReport = int.Parse(spinCurrencyUnitPriceDigitsInReport.EditValue.ToString());
            var currencySymbolInReport = cboCurrencySymbolInReport.SelectedIndex == 0 ? "" : cboCurrencySymbolInReport.Text;

            var generalDecimalSeparator = "";
            switch (cboGeneralGroupSeparator.SelectedIndex)
            {
                case 0:
                    generalDecimalSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 1:
                    generalDecimalSeparator = cboGeneralGroupSeparator.Text;
                    break;
                case 2:
                    generalDecimalSeparator = " ";
                    break;
            }

            var generalGroupSeparator = "";
            switch (cboGeneralDecimalSeparator.SelectedIndex)
            {
                case 0:
                    generalGroupSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 1:
                    generalGroupSeparator = cboGeneralDecimalSeparator.Text;
                    break;
                case 2:
                    generalGroupSeparator = " ";
                    break;
            }

            var defaultValue = "1" + generalDecimalSeparator + "234" + generalDecimalSeparator + "456" + generalDecimalSeparator + "789";

            #region currency digits

            if (currencyDecimalDigitsInReport > 0)
            {
                lblCurrencyNegativePatternInReport.Text = defaultValue + generalGroupSeparator;
                lblCurrencyPositivePatternInReport.Text = defaultValue + generalGroupSeparator;

                for (var i = 0; i < currencyDecimalDigitsInReport; i++)
                {
                    lblCurrencyNegativePatternInReport.Text += @"0";
                    lblCurrencyPositivePatternInReport.Text += @"0";
                }
            }
            else
            {
                lblCurrencyNegativePatternInReport.Text = defaultValue;
                lblCurrencyPositivePatternInReport.Text = defaultValue;
            }

            var currencyNegativePatternInReport = cboCurrencyNegativePatternInReport.SelectedIndex;
            if (cboCurrencyNegativePatternInReport.EditValue != null)
            {
                switch (currencyNegativePatternInReport)
                {
                    case 0:
                        lblCurrencyNegativePatternInReport.Text = @"(" + currencySymbolInReport + lblCurrencyNegativePatternInReport.Text + @")";
                        break;
                    case 1:
                        lblCurrencyNegativePatternInReport.Text = @"-" + currencySymbolInReport + lblCurrencyNegativePatternInReport.Text;
                        break;
                    case 2:
                        lblCurrencyNegativePatternInReport.Text = currencySymbolInReport + @"-" + lblCurrencyNegativePatternInReport.Text;
                        break;
                    case 3:
                        lblCurrencyNegativePatternInReport.Text = currencySymbolInReport + lblCurrencyNegativePatternInReport.Text + @"-";
                        break;
                    case 4:
                        lblCurrencyNegativePatternInReport.Text = @"(" + lblCurrencyNegativePatternInReport.Text + currencySymbolInReport + @")";
                        break;
                    case 5:
                        lblCurrencyNegativePatternInReport.Text = @"-" + lblCurrencyNegativePatternInReport.Text + @" " + currencySymbolInReport;
                        break;
                    case 6:
                        lblCurrencyNegativePatternInReport.Text = lblCurrencyNegativePatternInReport.Text + @"-" + currencySymbolInReport;
                        break;
                    case 7:
                        lblCurrencyNegativePatternInReport.Text = lblCurrencyNegativePatternInReport.Text + @" " + currencySymbolInReport + @"-";
                        break;
                    case 8:
                        lblCurrencyNegativePatternInReport.Text = @"-" + lblCurrencyNegativePatternInReport.Text + @" " + currencySymbolInReport;
                        break;
                    case 9:
                        lblCurrencyNegativePatternInReport.Text = @"-" + currencySymbolInReport + @" " + lblCurrencyNegativePatternInReport.Text;
                        break;
                    case 10:
                        lblCurrencyNegativePatternInReport.Text = lblCurrencyNegativePatternInReport.Text + @" " + currencySymbolInReport + @"-";
                        break;
                    case 11:
                        lblCurrencyNegativePatternInReport.Text = currencySymbolInReport + @" " + lblCurrencyNegativePatternInReport.Text + @"-";
                        break;
                    case 12:
                        lblCurrencyNegativePatternInReport.Text = currencySymbolInReport + @"-" + lblCurrencyNegativePatternInReport.Text;
                        break;
                    case 13:
                        lblCurrencyNegativePatternInReport.Text = lblCurrencyNegativePatternInReport.Text + @"- " + currencySymbolInReport;
                        break;
                    case 14:
                        lblCurrencyNegativePatternInReport.Text = @"(" + currencySymbolInReport + @" " + lblCurrencyNegativePatternInReport.Text + @")";
                        break;
                    case 15:
                        lblCurrencyNegativePatternInReport.Text = @"(" + lblCurrencyNegativePatternInReport.Text + @" " + currencySymbolInReport + @")";
                        break;
                }
            }

            var currencyPositivePatternInReport = cboCurrencyPositivePatternInReport.SelectedIndex;
            if (cboCurrencyPositivePatternInReport.EditValue != null)
            {
                switch (currencyPositivePatternInReport)
                {
                    case 0:
                        lblCurrencyPositivePatternInReport.Text = currencySymbolInReport + lblCurrencyPositivePatternInReport.Text;
                        break;
                    case 1:
                        lblCurrencyPositivePatternInReport.Text = lblCurrencyPositivePatternInReport.Text + currencySymbolInReport;
                        break;
                    case 2:
                        lblCurrencyPositivePatternInReport.Text = currencySymbolInReport + @" " + lblCurrencyPositivePatternInReport.Text;
                        break;
                    case 3:
                        lblCurrencyPositivePatternInReport.Text = lblCurrencyPositivePatternInReport.Text + @" " + currencySymbolInReport;
                        break;
                }
            }

            #endregion

            #region Currency Unit Price Digits

            if (currencyUnitPriceDigitsInReport > 0)
            {
                lblCurrencyUnitPriceDigitsInReport.Text = defaultValue + generalGroupSeparator;
                for (var i = 0; i < currencyUnitPriceDigitsInReport; i++)
                    lblCurrencyUnitPriceDigitsInReport.Text += @"0";
            }
            else
            {
                lblCurrencyUnitPriceDigitsInReport.Text = defaultValue;
            }

            #endregion
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraFormDbOption" /> class.
        /// </summary>
        public FrmXtraFormDbOption()
        {

            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _autoNumbersPresenter = new AutoNumbersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraFormDbOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmXtraFormDbOption_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _autoNumbersPresenter.Display();
                _budgetSourcesPresenter.DisplayActive();
                _budgetChaptersPresenter.DisplayByIsActive(true);
                _budgetKindItemsPresenter.DisplayActive();
                _cashWithdrawTypesPresenter.DisplayList();
                _dbOptionsPresenter.Display();

                SetGeneralFormat();
                SetCurrencyFormat();
                SetCurrencyFormatInReport();

                Cursor.Current = Cursors.Default;
                //Ẩn hình thức" Tổng hợp"
                cboAccountingBooksType.Properties.Items.RemoveAt(3);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var message = _dbOptionsPresenter.Save();
                if (message != null)
                    XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    _autoNumbersPresenter.Save();
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataSuccess"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GlobalVariable.Register();

                SetGeneralFormat();
                SetCurrencyFormat();
                SetCurrencyFormatInReport();
              

                Thread.CurrentThread.CurrentCulture = new CultureInfo(ResourceHelper.ResourceLanguage)
                {
                    NumberFormat =
                    {
                        CurrencySymbol = GlobalVariable.CurrencySymbol ?? "" ,
                       
                        CurrencyDecimalSeparator = GlobalVariable.GeneralDecimalSeparator,
                        CurrencyGroupSeparator = GlobalVariable.GeneralGroupSeparator,
                        CurrencyDecimalDigits = GlobalVariable.CurrencyDecimalDigits,

                        NumberDecimalSeparator = GlobalVariable.GeneralDecimalSeparator,
                        NumberGroupSeparator = GlobalVariable.GeneralGroupSeparator
                    }
                };
                Cursor.Current = Cursors.Default;


                MainRibbonForm RIB = new MainRibbonForm();
                // Visible chứng từ ghi sổ
                if (GlobalVariable.AccountingBooksType == 2)
                {
                    RIB.barButtonGLVoucherList.Visibility = BarItemVisibility.Always;
                    //XtraMessageBox.Show("Khởi động lại phần mềm để hoàn tất chức năng chứng từ ghi sổ",
                   // ResourceHelper.GetResourceValueByName(""), MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                { RIB.barButtonGLVoucherList.Visibility = BarItemVisibility.Never; }
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnBackupPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void txtPathBackup_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        txtPathBackup.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region General Format

        /// <summary>
        /// Handles the Click event of the btnDefaultGeneral control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDefaultGeneral_Click(object sender, EventArgs e)
        {
            cboGeneralGroupSeparator.SelectedIndex = 0;
            cboGeneralDecimalSeparator.SelectedIndex = 1;
            spinNumberDecimalDigits.EditValue = 0;
            cboNumberNegativePattern.SelectedIndex = 1;
            spinPercentDecimalDigits.EditValue = 2;
            spinExchangeRateDecimalDigits.EditValue = 0;
            spinAmountOCDecimalDigits.EditValue = 0;
            SetGeneralFormat();
        }

        /// <summary>
        /// Handles the Click event of the btnShowDemo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnShowDemo_Click(object sender, EventArgs e)
        {
            SetGeneralFormat();
        }

        #endregion

        #region Formant Currency

        /// <summary>
        /// Handles the Click event of the btnDemoFormantCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDemoFormantCurrency_Click(object sender, EventArgs e)
        {
            SetCurrencyFormat();
            SetCurrencyFormatInReport();
        }

        /// <summary>
        /// Handles the Click event of the btnDefaultCurrencyFormat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDefaultCurrencyFormat_Click(object sender, EventArgs e)
        {
            spinCurrencyDecimalDigits.EditValue = 0;
            cboCurrencySymbol.SelectedIndex = 0;
            cboCurrencyNegativePattern.SelectedIndex = 4;
            cboCurrencyPositivePattern.SelectedIndex = 1;
            spinCurrencyUnitPriceDigits.EditValue = 0;

            spinCurrencyDecimalDigitsInReport.EditValue = 0;
            cboCurrencySymbolInReport.SelectedIndex = 0;
            cboCurrencyNegativePatternInReport.SelectedIndex = 4;
            cboCurrencyPositivePatternInReport.SelectedIndex = 1;
            spinCurrencyUnitPriceDigitsInReport.EditValue = 0;

            SetCurrencyFormat();
            SetCurrencyFormatInReport();
        }

        #endregion

        #region Font events

        /// <summary>
        /// Handles the Click event of the btnCompanyCodeFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyCodeFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyNameFont.ShowDialog();
            if (result != DialogResult.OK)
                return;
            var font = dlgCompanyNameFont.Font;
            txtCompanyCodeFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the Click event of the btnCompanyNameFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyNameFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyNameFont.ShowDialog();
            if (result != DialogResult.OK)
                return;
            var font = dlgCompanyNameFont.Font;
            txtCompanyNameFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the Click event of the btnCompanyAddressFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyAddressFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyNameFont.ShowDialog();
            if (result != DialogResult.OK)
                return;
            var font = dlgCompanyNameFont.Font;
            txtCompanyAddressFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the Click event of the btnOwnerCompanyNameFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOwnerCompanyNameFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyNameFont.ShowDialog();
            if (result != DialogResult.OK)
                return;
            var font = dlgCompanyNameFont.Font;
            txtOwnerCompanyNameFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the EditValueChanged event of the grdDefaultBudgetSubKindItemCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdDefaultBudgetSubKindItemCode_EditValueChanged(object sender, EventArgs e)
        {
            var budgetSubKindItemCode = CommonFunction.ConvertToString(grdDefaultBudgetSubKindItemCode.EditValue);
            var budgetSubKindItem = _model.GetBudgetKindItemsByCodeIncludeParentCode(budgetSubKindItemCode);
            if (budgetSubKindItem != null)
            {
                grdDefaultBudgetKindItemCode.EditValue = budgetSubKindItem.ParentId;
            }
        }

        #endregion

        #region Views

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetChapterModel>();
                    //var budgetChapterTemplate = value.Where(c => c.BudgetChapterCode == "160" || c.BudgetChapterCode == "170" ||
                    //                     c.BudgetChapterCode == "422" || c.BudgetChapterCode == "423" ||
                    //                     c.BudgetChapterCode == "623" || c.BudgetChapterCode == "823").ToList();
                    grdDefaultBudgetChapterCode.Properties.DataSource = value;
                    grdDefaultBudgetChapterCodeView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetChapterCode",
                            ColumnCaption = "Mã Chương",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 130
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetChapterName",
                            ColumnCaption = "Tên Chương",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 265
                        },
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdDefaultBudgetChapterCodeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdDefaultBudgetChapterCodeView.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdDefaultBudgetChapterCodeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        }
                        else
                            grdDefaultBudgetChapterCodeView.Columns[column.ColumnName].Visible = false;
                    }
                    grdDefaultBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                    grdDefaultBudgetChapterCode.Properties.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.IsParent == false).ToList();
                    grdDefaultBudgetSourceId.Properties.DataSource = data;
                    grdDefaultBudgetSourceIdView.PopulateColumns(data);
                    grdDefaultBudgetSourceIdView.OptionsView.ShowIndicator = false;
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceCode",
                            ColumnCaption = "Mã nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnPosition = 1
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceName",
                            ColumnCaption = "Tên nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 245,
                            ColumnPosition = 2
                        },
                        new XtraColumn {ColumnName = "BudgetSourceCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSavingExpenses", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceProperty", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankAccountId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PayableBankAccountId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSelfControl", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceType", ColumnVisible = false}
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdDefaultBudgetSourceIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdDefaultBudgetSourceIdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdDefaultBudgetSourceIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            grdDefaultBudgetSourceIdView.Columns[column.ColumnName].Visible = false;
                    }
                    grdDefaultBudgetSourceId.Properties.DisplayMember = "BudgetSourceName";
                    grdDefaultBudgetSourceId.Properties.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetKindItemModel>();
                    //var budgetKindItemModels = value.Where(v => v.BudgetKindItemCode == "250" || v.BudgetKindItemCode == "370" ||
                    //                                            v.BudgetKindItemCode == "460" || v.BudgetKindItemCode == "490" ||
                    //                                            v.BudgetKindItemCode == "520").ToList();
                    //var budgetSubKindItemModels = value.Where(v => v.BudgetKindItemCode == "251" || v.BudgetKindItemCode == "373" ||
                    //                                                v.BudgetKindItemCode == "463" || v.BudgetKindItemCode == "494" ||
                    //                                                v.BudgetKindItemCode == "521" || v.BudgetKindItemCode == "534").ToList();
                    var budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                    var budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    grdDefaultBudgetKindItemCode.Properties.DataSource = budgetKindItemModels;
                    grdDefaultBudgetKindItemCodeView.PopulateColumns(budgetKindItemModels);

                    grdDefaultBudgetSubKindItemCode.Properties.DataSource = budgetSubKindItemModels;
                    grdDefaultBudgetSubKindItemCodeView.PopulateColumns(budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "BudgetKindItemId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemCode",
                            ColumnCaption = "Mã Khoản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetKindItemName",
                            ColumnCaption = "Tên Khoản",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 295
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdDefaultBudgetKindItemCodeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdDefaultBudgetKindItemCodeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdDefaultBudgetKindItemCodeView.Columns[column.ColumnName].Width = column.ColumnWith;

                            grdDefaultBudgetSubKindItemCodeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdDefaultBudgetSubKindItemCodeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdDefaultBudgetSubKindItemCodeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            grdDefaultBudgetKindItemCodeView.Columns[column.ColumnName].Visible = false;
                            grdDefaultBudgetSubKindItemCodeView.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    grdDefaultBudgetKindItemCode.Properties.DisplayMember = "BudgetKindItemCode";
                    grdDefaultBudgetKindItemCode.Properties.ValueMember = "BudgetKindItemCode";

                    grdDefaultBudgetSubKindItemCode.Properties.DisplayMember = "BudgetKindItemCode";
                    grdDefaultBudgetSubKindItemCode.Properties.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>The cash withdraw type models.</value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                try
                {
                    grdDefaultCashWithDrawTypeId.Properties.DataSource = value;
                    grdDefaultCashWithDrawTypeIdView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "CashWithdrawTypeId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "CashWithdrawTypeName",
                            ColumnCaption = "Nghiệp vụ",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "CashWithdrawNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SubSystemId", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdDefaultCashWithDrawTypeIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdDefaultCashWithDrawTypeIdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdDefaultCashWithDrawTypeIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            grdDefaultCashWithDrawTypeIdView.Columns[column.ColumnName].Visible = false;
                    }
                    grdDefaultCashWithDrawTypeId.Properties.DisplayMember = "CashWithdrawTypeName";
                    grdDefaultCashWithDrawTypeId.Properties.ValueMember = "CashWithdrawTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gets or sets the database options.
        /// </summary>
        /// <value>
        /// The database options.
        /// </value>
        public IList<DBOptionModel> DBOptions
        {
            get
            {
                var generalDecimalSeparator = "";
                switch (cboGeneralDecimalSeparator.SelectedIndex)
                {
                    case 0:
                        generalDecimalSeparator = cboGeneralDecimalSeparator.Text;
                        break;
                    case 1:
                        generalDecimalSeparator = cboGeneralDecimalSeparator.Text;
                        break;
                    case 2:
                        generalDecimalSeparator = " ";
                        break;
                }

                var generalGroupSeparator = "";
                switch (cboGeneralGroupSeparator.SelectedIndex)
                {
                    case 0:
                        generalGroupSeparator = cboGeneralGroupSeparator.Text;
                        break;
                    case 1:
                        generalGroupSeparator = cboGeneralGroupSeparator.Text;
                        break;
                    case 2:
                        generalGroupSeparator = " ";
                        break;
                }

                var dbOptions = new List<DBOptionModel>
                {
                    //company ìnfo
                    new DBOptionModel { OptionId = "CompanyCode", OptionValue = txtCompanyCode.Text },
                    new DBOptionModel { OptionId = "CompanyName", OptionValue = txtCompanyName.Text },
                    new DBOptionModel { OptionId = "CompanyAdrress", OptionValue = txtCompanyAdrress.Text },
                    new DBOptionModel { OptionId = "CompanyDistrict", OptionValue = txtCompanyDistrict.Text },
                    new DBOptionModel { OptionId = "CompanyProvince", OptionValue = txtCompanyProvince.Text },
                    new DBOptionModel { OptionId = "OwnerCompanyName", OptionValue = txtOwnerCompanyName.Text },
                    new DBOptionModel { OptionId = "AreaCode", OptionValue = txtAreaCode.Text },
                    new DBOptionModel { OptionId = "CompanyTaxCode", OptionValue = txtCompanyTaxCode.Text },
                    new DBOptionModel { OptionId = "CompanyTel", OptionValue = txtCompanyTel.Text },
                    new DBOptionModel { OptionId = "CompanyFax", OptionValue = txtCompanyFax.Text },
                    new DBOptionModel { OptionId = "BankAccountNumner", OptionValue = txtBankAccountNumner.Text },
                    new DBOptionModel { OptionId = "CompanyBankAccountNo", OptionValue = txtCompanyBankAccountNo.Text },
                    new DBOptionModel { OptionId = "CompanyBankAdrress", OptionValue = txtCompanyBankAdrress.Text },
                    new DBOptionModel { OptionId = "CompanyBankName", OptionValue = txtCompanyBankName.Text },

                    //tuy chon chung
                     new DBOptionModel { OptionId = "IsPostToParentAccount", OptionValue = chkIsPostToParentAccount.EditValue.ToString(), ValueType = 3,
                        Description = "True- Cho phép định khoản vào tài khoản tổng hợp. False- Không cho phép định khoản vào tài khoản tổng hợp", IsSystem = false },
                    new DBOptionModel { OptionId = "IsPaymentNegativeFund", OptionValue = chkIsPaymentNegativeFund.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép chi tiền khi quỹ âm. False- không cho phép chi tiền khi quỹ âm", IsSystem = false },
                    new DBOptionModel { OptionId = "IsDepositeNegavtiveFund", OptionValue = chkIsDepositeNegavtiveFund.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép chi tiền gửi khi quỹ âm. False- không cho phép chi tiền gửi khi quỹ âm", IsSystem = false },
                    new DBOptionModel { OptionId = "IsOutwardNegativeStock", OptionValue = chkIsOutwardNegativeStock.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép xuất kho khi hết hàng. False- không cho phép xuất kho khi hết hàng", IsSystem = false },
                    new DBOptionModel { OptionId = "AccountingBooksType", OptionValue = cboAccountingBooksType.SelectedIndex.ToString() },
                    new DBOptionModel {OptionId = "VoucherShowType", OptionValue = cboVoucherShowsType.SelectedIndex.ToString()},

                    //dinh dang so
                    new DBOptionModel { OptionId = "GeneralDecimalSeparator", OptionValue = generalDecimalSeparator },
                    new DBOptionModel { OptionId = "GeneralGroupSeparator", OptionValue = generalGroupSeparator },
                    new DBOptionModel { OptionId = "NumberDecimalDigits", OptionValue = spinNumberDecimalDigits.Text },
                    new DBOptionModel { OptionId = "NumberNegativePattern", OptionValue = cboNumberNegativePattern.SelectedIndex.ToString() },
                    new DBOptionModel { OptionId = "PercentDecimalDigits", OptionValue = spinPercentDecimalDigits.Text },
                    new DBOptionModel { OptionId = "ExchangeRateDecimalDigits", OptionValue = spinExchangeRateDecimalDigits.Text },
                    new DBOptionModel { OptionId = "AmountOCDecimalDigits", OptionValue = spinAmountOCDecimalDigits.Text },

                    //dinh dang so tien
                    new DBOptionModel { OptionId = "CurrencyDecimalDigits", OptionValue = spinCurrencyDecimalDigits.Text },
                    new DBOptionModel { OptionId = "CurrencySymbol", OptionValue = cboCurrencySymbol.SelectedIndex == 0 ? "":cboCurrencySymbol.Text },
                    new DBOptionModel { OptionId = "CurrencyNegativePattern", OptionValue = cboCurrencyNegativePattern.SelectedIndex.ToString() },
                    new DBOptionModel { OptionId = "CurrencyPositivePattern", OptionValue = cboCurrencyPositivePattern.SelectedIndex.ToString() },
                    new DBOptionModel { OptionId = "CurrencyUnitPriceDigits", OptionValue = spinCurrencyUnitPriceDigits.EditValue.ToString() },

                    //dinh dang so tien tren report
                    new DBOptionModel { OptionId = "CurrencyDecimalDigitsInReport", OptionValue = spinCurrencyDecimalDigitsInReport.Text },
                    new DBOptionModel { OptionId = "CurrencySymbolInReport", OptionValue = cboCurrencySymbolInReport.SelectedIndex == 0 ? "":cboCurrencySymbolInReport.Text },
                    new DBOptionModel { OptionId = "CurrencyNegativePatternInReport", OptionValue = cboCurrencyNegativePatternInReport.SelectedIndex.ToString() },
                    new DBOptionModel { OptionId = "CurrencyPositivePatternInReport", OptionValue = cboCurrencyPositivePatternInReport.SelectedIndex.ToString() },
                    new DBOptionModel { OptionId = "CurrencyUnitPriceDigitsInReport", OptionValue = spinCurrencyUnitPriceDigitsInReport.EditValue.ToString() },

                    //font
                    new DBOptionModel { OptionId = "CompanyCodeFont", OptionValue = txtCompanyCodeFont.Text },
                    new DBOptionModel { OptionId = "CompanyNameFont", OptionValue = txtCompanyNameFont.Text },
                    new DBOptionModel { OptionId = "CompanyAddressFont", OptionValue = txtCompanyAddressFont.Text },
                    new DBOptionModel { OptionId = "OwnerCompanyNameFont", OptionValue = txtOwnerCompanyNameFont.Text },

                    //chu ky report
                    new DBOptionModel { OptionId = "CompanyAccountant", OptionValue = txtCompanyAccountant.Text },
                    new DBOptionModel { OptionId = "CompanyAccountantTitle", OptionValue = txtCompanyAccountantTitle.Text },
                    new DBOptionModel { OptionId = "CompanyCashier", OptionValue = txtCompanyCashier.Text },
                    new DBOptionModel { OptionId = "CompanyCashierTitle", OptionValue = txtCompanyCashierTitle.Text },
                    new DBOptionModel { OptionId = "CompanyChiefAccountant", OptionValue = txtCompanyChiefAccountant.Text },
                    new DBOptionModel { OptionId = "CompanyChiefAccountantTitle", OptionValue = txtCompanyChiefAccountantTitle.Text },
                    new DBOptionModel { OptionId = "CompanyReportPreparer", OptionValue = txtCompanyReportPreparer.Text },
                    new DBOptionModel { OptionId = "CompanyReportPreparerTitle", OptionValue = txtCompanyReportPreparerTitle.Text },
                    new DBOptionModel { OptionId = "CompanyStoreKeeper", OptionValue = txtCompanyStoreKeeper.Text },
                    new DBOptionModel { OptionId = "CompanyStoreKeeperTitle", OptionValue = txtCompanyStoreKeeperTitle.Text },
                    new DBOptionModel { OptionId = "CompanyDirector", OptionValue = txtCompanyDirector.Text },
                    new DBOptionModel { OptionId = "CompanyDirectorTitle", OptionValue = txtCompanyDirectorTitle.Text },

                    //danh muc ngam dinh
                    new DBOptionModel { OptionId = "DefaultBudgetChapterCode", OptionValue = CommonFunction.ConvertToString(grdDefaultBudgetChapterCode.EditValue) },
                    new DBOptionModel { OptionId = "DefaultBudgetKindItemCode", OptionValue = CommonFunction.ConvertToString(grdDefaultBudgetKindItemCode.EditValue) },
                    new DBOptionModel { OptionId = "DefaultBudgetSourceID", OptionValue = CommonFunction.ConvertToString(grdDefaultBudgetSourceId.EditValue) },
                    new DBOptionModel { OptionId = "DefaultBudgetSubKindItemCode", OptionValue = CommonFunction.ConvertToString(grdDefaultBudgetSubKindItemCode.EditValue) },
                    new DBOptionModel { OptionId = "DefaultCashWithDrawTypeID", OptionValue = CommonFunction.ConvertToString(grdDefaultCashWithDrawTypeId.EditValue) },
                    //new DBOptionModel { OptionId = "DefaultMethodDistributeID", OptionValue = CommonFunction.ConvertToString(cboDefaultMethodDistributeId.SelectedIndex) },
                    new DBOptionModel { OptionId = "DefaultCostMethod", OptionValue = CommonFunction.ConvertToString(cboDefaultCostMethod.SelectedIndex) },
                    new DBOptionModel { OptionId = "AutoBackup", OptionValue = cboAutoBackup.SelectedIndex == 0 ? "True": "False" },
                    new DBOptionModel { OptionId = "PathBackup", OptionValue = txtPathBackup.Text },

                    new DBOptionModel { OptionId = "PathXML", OptionValue = txtPathXML.Text },
            };
                return dbOptions;
            }
            set
            {
                if (value == null)
                    return;
                lblVersionDB.Text = string.Format(lblVersionDB.Text,
                    (from dbOption in value where dbOption.OptionId == "Version" select dbOption.OptionValue)
                    .First());
                //company info
                txtCompanyCode.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCode" select dbOption.OptionValue).First();
                txtCompanyName.EditValue = GlobalVariable.CompanyName;
                txtCompanyAdrress.EditValue = GlobalVariable.CompanyAddress;
                txtCompanyDistrict.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyDistrict" select dbOption.OptionValue).First();
                txtCompanyProvince.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyProvince" select dbOption.OptionValue).First();
                txtOwnerCompanyName.EditValue = GlobalVariable.OwnerCompanyName;
                txtAreaCode.EditValue = (from dbOption in value where dbOption.OptionId == "AreaCode" select dbOption.OptionValue).First();
                txtCompanyTaxCode.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyTaxCode" select dbOption.OptionValue).First();
                txtCompanyTel.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyTel" select dbOption.OptionValue).First();
                txtCompanyFax.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyFax" select dbOption.OptionValue).First();
                txtBankAccountNumner.EditValue = (from dbOption in value where dbOption.OptionId == "BankAccountNumner" select dbOption.OptionValue).First();
                txtCompanyBankAccountNo.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyBankAccountNo" select dbOption.OptionValue).First();
                txtCompanyBankAdrress.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyBankAdrress" select dbOption.OptionValue).First();
                txtCompanyBankName.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyBankName" select dbOption.OptionValue).First();

                //tuy chon chung
                chkIsPostToParentAccount.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPostToParentAccount" select dbOption.OptionValue).First());
                chkIsPaymentNegativeFund.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeFund" select dbOption.OptionValue).First());
                chkIsDepositeNegavtiveFund.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDepositeNegavtiveFund" select dbOption.OptionValue).First());
                chkIsOutwardNegativeStock.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsOutwardNegativeStock" select dbOption.OptionValue).First());
                cboAccountingBooksType.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "AccountingBooksType" select dbOption.OptionValue).First());
                cboVoucherShowsType.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "VoucherShowType" select dbOption.OptionValue).First() == null ? "0" : (from dbOption in value where dbOption.OptionId == "VoucherShowType" select dbOption.OptionValue).First());
                //tuy chon dinh dang so
                var generalDecimalSeparator = (from dbOption in value where dbOption.OptionId == "GeneralDecimalSeparator" select dbOption.OptionValue).First();
                switch (generalDecimalSeparator)
                {
                    case ".":
                        cboGeneralDecimalSeparator.SelectedIndex = 0;
                        break;
                    case ",":
                        cboGeneralDecimalSeparator.SelectedIndex = 1;
                        break;
                    case " ":
                        cboGeneralDecimalSeparator.SelectedIndex = 2;
                        break;
                }

                var generalGroupSeparator = (from dbOption in value where dbOption.OptionId == "GeneralGroupSeparator" select dbOption.OptionValue).First();
                switch (generalGroupSeparator)
                {
                    case ".":
                        cboGeneralGroupSeparator.SelectedIndex = 0;
                        break;
                    case ",":
                        cboGeneralGroupSeparator.SelectedIndex = 1;
                        break;
                    case " ":
                        cboGeneralGroupSeparator.SelectedIndex = 2;
                        break;
                }
                spinNumberDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "NumberDecimalDigits" select dbOption.OptionValue).First();
                cboNumberNegativePattern.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "NumberNegativePattern" select dbOption.OptionValue).First());
                spinPercentDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "PercentDecimalDigits" select dbOption.OptionValue).First();
                spinExchangeRateDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "ExchangeRateDecimalDigits" select dbOption.OptionValue).First();
                spinAmountOCDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "AmountOCDecimalDigits" select dbOption.OptionValue).First();

                //dinh dang so tien
                spinCurrencyDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalDigits" select dbOption.OptionValue).First();
                var currencySymbol = (from dbOption in value where dbOption.OptionId == "CurrencySymbol" select dbOption.OptionValue).First();
                if (string.IsNullOrEmpty(currencySymbol))
                    cboCurrencySymbol.SelectedIndex = 0;
                else
                    cboCurrencySymbol.Text = currencySymbol;
                cboCurrencyNegativePattern.SelectedIndex =
                    int.Parse((from dbOption in value where dbOption.OptionId == "CurrencyNegativePattern" select dbOption.OptionValue).First());
                cboCurrencyPositivePattern.SelectedIndex =
                    int.Parse((from dbOption in value where dbOption.OptionId == "CurrencyPositivePattern" select dbOption.OptionValue).First());
                spinCurrencyUnitPriceDigits.EditValue = (from dbOption in value where dbOption.OptionId == "CurrencyUnitPriceDigits" select dbOption.OptionValue).First();

                //dinh dang so tien tren report
                spinCurrencyDecimalDigitsInReport.EditValue = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalDigitsInReport" select dbOption.OptionValue).First();
                var currencySymbolInReport = (from dbOption in value where dbOption.OptionId == "CurrencySymbolInReport" select dbOption.OptionValue).First();
                if (string.IsNullOrEmpty(currencySymbolInReport))
                    cboCurrencySymbolInReport.SelectedIndex = 0;
                else
                    cboCurrencySymbolInReport.Text = currencySymbolInReport;

                cboCurrencyNegativePatternInReport.SelectedIndex =
                    int.Parse((from dbOption in value where dbOption.OptionId == "CurrencyNegativePatternInReport" select dbOption.OptionValue).First());
                cboCurrencyPositivePatternInReport.SelectedIndex =
                    int.Parse((from dbOption in value where dbOption.OptionId == "CurrencyPositivePatternInReport" select dbOption.OptionValue).First());
                spinCurrencyUnitPriceDigitsInReport.EditValue = (from dbOption in value where dbOption.OptionId == "CurrencyUnitPriceDigitsInReport" select dbOption.OptionValue).First();

                //font
                txtCompanyCodeFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCodeFont" select dbOption.OptionValue).First();
                txtCompanyNameFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyNameFont" select dbOption.OptionValue).First();
                txtCompanyAddressFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAddressFont" select dbOption.OptionValue).First();
                txtOwnerCompanyNameFont.EditValue = (from dbOption in value where dbOption.OptionId == "OwnerCompanyNameFont" select dbOption.OptionValue).First();

                //chu ky report
                txtCompanyDirector.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyDirector" select dbOption.OptionValue).First();
                txtCompanyDirectorTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyDirectorTitle" select dbOption.OptionValue).First();
                txtCompanyReportPreparer.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparer" select dbOption.OptionValue).First();
                txtCompanyReportPreparerTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparerTitle" select dbOption.OptionValue).First();
                txtCompanyStoreKeeper.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeper" select dbOption.OptionValue).First();
                txtCompanyStoreKeeperTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeperTitle" select dbOption.OptionValue).First();
                txtCompanyCashier.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCashier" select dbOption.OptionValue).First();
                txtCompanyCashierTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCashierTitle" select dbOption.OptionValue).First();
                txtCompanyAccountant.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAccountant" select dbOption.OptionValue).First();
                txtCompanyAccountantTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAccountantTitle" select dbOption.OptionValue).First();
                txtCompanyChiefAccountant.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyChiefAccountant" select dbOption.OptionValue).First();
                txtCompanyChiefAccountantTitle.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyChiefAccountantTitle" select dbOption.OptionValue).First();

                //thiet lap ngam dinh
                grdDefaultBudgetChapterCode.EditValue =
                    (from dbOption in value where dbOption.OptionId == "DefaultBudgetChapterCode" select dbOption.OptionValue).First();
                grdDefaultBudgetKindItemCode.EditValue =
                    (from dbOption in value where dbOption.OptionId == "DefaultBudgetKindItemCode" select dbOption.OptionValue).First();
                grdDefaultBudgetSourceId.EditValue =
                    (from dbOption in value where dbOption.OptionId == "DefaultBudgetSourceID" select dbOption.OptionValue).First();
                grdDefaultBudgetSubKindItemCode.EditValue =
                    (from dbOption in value where dbOption.OptionId == "DefaultBudgetSubKindItemCode" select dbOption.OptionValue).First();
                grdDefaultCashWithDrawTypeId.EditValue =
                    (from dbOption in value where dbOption.OptionId == "DefaultCashWithDrawTypeID" select dbOption.OptionValue).First();
                //cboDefaultMethodDistributeId.SelectedIndex =
                //    int.Parse(value.FirstOrDefault(c => c.OptionId == "DefaultMethodDistributeID").OptionValue);
                cboDefaultCostMethod.SelectedIndex =
                    int.Parse(value.FirstOrDefault(c => c.OptionId == "DefaultCostMethod").OptionValue);

                //auto backup
                var option = bool.Parse(value.FirstOrDefault(v => v.OptionId == "AutoBackup").OptionValue);
                cboAutoBackup.SelectedIndex = option ? 0 : 1;
                txtPathBackup.EditValue = (from dbOption in value where dbOption.OptionId == "PathBackup" select dbOption.OptionValue).First();
                txtPathXML.EditValue = (from dbOption in value where dbOption.OptionId == "PathXML" select dbOption.OptionValue).First();
            }
        }

        /// <summary>
        /// Gets or sets the automatic numbers.
        /// </summary>
        /// <value>
        /// The automatic numbers.
        /// </value>
        public IList<AutoIDModel> AutoNumbers
        {
            get
            {
                var autoIds = new List<AutoIDModel>();
                if (grdDetail.DataSource != null && gridViewDetail.DataRowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.DataRowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            autoIds.Add(new AutoIDModel
                            {
                                RefTypeCategoryId = (int)gridViewDetail.GetRowCellValue(i, "RefTypeCategoryId"),
                                Prefix = (string)gridViewDetail.GetRowCellValue(i, "Prefix"),
                                Suffix = (string)gridViewDetail.GetRowCellValue(i, "Suffix"),
                                Value = (int)gridViewDetail.GetRowCellValue(i, "Value"),
                                LengthOfValue = (int)gridViewDetail.GetRowCellValue(i, "LengthOfValue"),
                            });
                        }
                    }
                }
                return autoIds.ToList();
            }
            set
            {
                var autoIds = value.Where(c => c.RefTypeCategoryId != 30 && c.RefTypeCategoryId != 207 && c.RefTypeCategoryId != 500).ToList();

                bindingSourceDetail.DataSource = autoIds;
                gridViewDetail.PopulateColumns(autoIds);

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "RefTypeCategoryName",
                        ColumnCaption = "Loại chứng từ, danh mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 120,
                        AllowEdit = false,
                        ToolTip = "Giá trị số tự động tăng theo tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "Prefix",
                        ColumnCaption = "Tiền tố",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 50,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Value",
                        ColumnCaption = "Giá trị",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 60,
                        AllowEdit = true,
                        ToolTip = "Giá trị số tự động tăng theo tiền hạch toán"
                    },
                    new XtraColumn
                    {
                        ColumnName = "LengthOfValue",
                        ColumnCaption = "Tổng số ký tự phần số",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 120,
                        AllowEdit = true,
                        ToolTip = "Tổng số ký tự phần số"
                    },
                    new XtraColumn
                    {
                        ColumnName = "Suffix",
                        ColumnCaption = "Hậu tố",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 50,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "RefTypeCategoryId", ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "IsSystem", ColumnVisible = false
                    }
                };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        #endregion

        private void grdDefaultBudgetSourceId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            grdDefaultBudgetSourceId.EditValue = null;
            e.Handled = true;
        }

        private void grdDefaultBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            grdDefaultBudgetChapterCode.EditValue = null;
            e.Handled = true;
        }

        private void grdDefaultBudgetSubKindItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            grdDefaultBudgetSubKindItemCode.EditValue = null;
            grdDefaultBudgetKindItemCode.EditValue = null;
            e.Handled = true;
        }

        private void grdDefaultCashWithDrawTypeId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            grdDefaultCashWithDrawTypeId.EditValue = 0;
            e.Handled = true;
        }

        private void cboDefaultMethodDistributeId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
            //    return;
            //cboDefaultMethodDistributeId.EditValue = null;
            //e.Handled = true;
        }

        private void txtPathXML_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        txtPathXML.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}