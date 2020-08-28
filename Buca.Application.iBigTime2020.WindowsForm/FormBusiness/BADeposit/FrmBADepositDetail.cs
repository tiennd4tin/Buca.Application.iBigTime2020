/***********************************************************************
 * <copyright file="FrmBADepositDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Friday, October 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Deposit;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.View.Deposit;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber;
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusiness;
using DevExpress.CodeParser;
using System.Runtime.InteropServices;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit
{
    /// <summary>
    /// FrmBADepositDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Deposit.IBADepositView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IPurchasePurposesView" />
    public partial class FrmBADepositDetail : FrmXtraBaseVoucherDetail, IBADepositView, IAccountingObjectsView, IBudgetSourcesView, IAccountsView,
        IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView, IFundStructuresView, IPurchasePurposesView, IBudgetExpensesView
        , IInvoiceFormNumbersView, IContractsView, ICapitalPlansView, IAutoBusinessesView
    {
        #region Tài khoản ngầm định
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;
        private IList<BudgetItemModel> _budgetItemModels2;
        #endregion
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAutoBusiness;
        private GridView _gridLookUpEditDebitAutoBusinessView;

        #region RepositoryItemGridLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxRate;
        private GridView _gridLookUpEditTaxRateView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInvoiceFormNumber;
        private GridView _gridLookUpEditInvoiceFormNumberView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;
        private GridView _gridLookUpEditCashWithdrawTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;

        private GridView _gridLookUpEditPurchasePurposeView;

        private RepositoryItemLookUpEdit _repositoryInvType;

        private IList<AccountModel> _accountModels;
        private List<BudgetItemModel> _budgetSubItemModels;

        private List<BudgetSourceModel> _budgetSourceModels;
        private List<ContractModel> _contractModels;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        #endregion

        #region Presenter
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;

        private readonly BudgetExpensesPresenter _budgetExpensePresenter;

        private readonly InvoiceFormNumbersPresenter _invoiceFormNumbersPresenter;
        private readonly AutoBusinessesPresenter _autoBusinessPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The b a deposit presenter
        /// </summary>
        private readonly BADepositPresenter _bADepositPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The activitys presenter
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;

        /// <summary>
        /// The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The purchase purposes presenter
        /// </summary>
        private readonly PurchasePurposesPresenter _purchasePurposesPresenter;
        private readonly IModel _model;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBADepositDetail" /> class.
        /// </summary>
        public FrmBADepositDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _bADepositPresenter = new BADepositPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _purchasePurposesPresenter = new PurchasePurposesPresenter(this);
            _invoiceFormNumbersPresenter = new InvoiceFormNumbersPresenter(this);
            _budgetExpensePresenter = new BudgetExpensesPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            _model = new Model.Model();
            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            // Tab thuế chung source với các tab khác
            // grdTax.DataSource = bindingSourceDetail;
            // AutoProjectId = TargetProgramId;
            grdViewParallel = grdViewAccountingParallel;
        }

        #region--Check validate form detail
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        #endregion

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(6, 196);
            tabMain.Location = new Point(6, 254);
            tabMain.SelectedTabPage = tabAccounting;
            //Tintv ẩn tab Thốn kế và thuế
            tabMain.TabPages[4].PageVisible = false;
            tabMain.TabPages[3].PageVisible = false;
            txtAddress.Enabled = true;
            labelControl9.Visible = false;
            txtContactName.Visible = false;
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
            grdTax.DataSource = bindingSourceDetail;
            //groupObject.Height = 143;
            //groupVoucher.Height = 143;
            
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _banksPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _invoiceFormNumbersPresenter.Display();
            _budgetExpensePresenter.DisplayActive();

            _autoBusinessPresenter.DisplayActive();

            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                KeyValue = ((BADepositModel)MasterBindingSource.Current).RefId;
                txtBankName.EditValue = null;
            }
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((BADepositModel)MasterBindingSource.Current).RefId;
            }

            _bADepositPresenter.Display(KeyValue, true, false, false, true);

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BADeposit;
            AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
        }
       
        /// <summary>
        /// Enable control.
        /// </summary>
        protected override void EnableControl()
        {
            ClickSomePoint();
            cboObjectCode.Enabled = true;
            cboBank.Enabled = true;
        }
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();
            cboObjectCode.Enabled = false;
            cboBank.Enabled = false;
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
        protected override bool ValidData()
        {
            grdAccountingView.CloseEditor();
            grdAccountingDetailView.CloseEditor();
            grdTaxView.CloseEditor();
            grdDetailByInventoryItemView.CloseEditor();

            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            //if (AccountingObjectId == null)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), detailContent,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboObjectCode.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var bADepositDetails = BADepositDetails;
            if (bADepositDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var bADepositDetail in bADepositDetails)
            {
                var creditAccount =
                    _accountModels.FirstOrDefault(x => x.AccountNumber.Equals(bADepositDetail.CreditAccount));
                var debitAccount =
                 _accountModels.FirstOrDefault(x => x.AccountNumber.Equals(bADepositDetail.DebitAccount));
                if (string.IsNullOrEmpty(bADepositDetail.BankId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherBankEmpty"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
                }
                if (bADepositDetail.Amount == 0)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAmountRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (creditAccount != null)
                {

                    if (creditAccount.DetailByBudgetSource)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSourceId))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceIdRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (creditAccount.DetailByBudgetChapter)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetChapterCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (creditAccount.DetailByBudgetKindItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSubKindItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubKindItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (creditAccount.DetailByBudgetItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (creditAccount.DetailByBudgetSubItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSubItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    //if (creditAccount.DetailByMethodDistribute)
                    //{
                    //    if (!bADepositDetail.MethodDistributeId.HasValue)
                    //    {
                    //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResMethodDistributeIdRequired"), detailContent,
                    //            MessageBoxButtons.OK,
                    //            MessageBoxIcon.Error);
                    //        return false;
                    //    }
                    //}
                }


                if (debitAccount != null)
                {
                    if (debitAccount.DetailByBudgetSource)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSourceId))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceIdRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (debitAccount.DetailByBudgetChapter)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetChapterCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (debitAccount.DetailByBudgetKindItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSubKindItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubKindItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (debitAccount.DetailByBudgetItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (debitAccount.DetailByBudgetSubItem)
                    {
                        if (string.IsNullOrEmpty(bADepositDetail.BudgetSubItemCode))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubItemCodeRequired"), detailContent,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    //if (debitAccount.DetailByMethodDistribute)
                    //{
                    //    if (!bADepositDetail.MethodDistributeId.HasValue)
                    //    {
                    //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResMethodDistributeIdRequired"), detailContent,
                    //            MessageBoxButtons.OK,
                    //            MessageBoxIcon.Error);
                    //        return false;
                    //    }
                    //}
                }
            }
            return true;
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount?.AccountNumber);
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount?.AccountNumber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// InitNewRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BADepositDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CellValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 0 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }

            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels2.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels2.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }
        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            IModel model = new Model.Model();

            var budgetSourceId = (grdAccountingView.Columns.ColumnByFieldName("BudgetSourceId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSourceId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSourceId").ToString();
            var budgetChapterCode = (grdAccountingView.Columns.ColumnByFieldName("BudgetChapterCode") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetChapterCode") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetChapterCode").ToString();
            var budgetKindItemCode = (grdAccountingView.Columns.ColumnByFieldName("BudgetSubKindItemCode") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubKindItemCode") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubKindItemCode").ToString();
            var budgetItemCode = (grdAccountingView.Columns.ColumnByFieldName("BudgetItemCode") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetItemCode") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetItemCode").ToString();
            var budgetSubItemCode = (grdAccountingView.Columns.ColumnByFieldName("BudgetSubItemCode") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode").ToString();
            var methodDistributeId = (grdAccountingView.Columns.ColumnByFieldName("MethodDistributeId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "MethodDistributeId") == null) ? 0 : (Int32)grdAccountingView.GetRowCellValue(e.RowHandle, "MethodDistributeId");
            var accountingObjectId = (grdAccountingView.Columns.ColumnByFieldName("AccountingObjectId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "AccountingObjectId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "AccountingObjectId").ToString();
            var activityId = (grdAccountingView.Columns.ColumnByFieldName("ActivityId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "ActivityId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "ActivityId").ToString();
            var projectId = (grdAccountingView.Columns.ColumnByFieldName("ProjectId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "ProjectId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "ProjectId").ToString();
            var bankId = (grdAccountingView.Columns.ColumnByFieldName("BankId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "BankId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "BankId").ToString();
            var contractId = (grdAccountingView.Columns.ColumnByFieldName("ContractId") == null || grdAccountingView.GetRowCellValue(e.RowHandle, "ContractId") == null) ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "ContractId").ToString();

            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels2?.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString())?.ParentId;
                var _budgetItemCode = _budgetItemModels2?.FirstOrDefault(b => b.BudgetItemId == parentId)?.BudgetItemCode;
                grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
            }
            if (e.Column.FieldName == "ProjectId")
            {
                var project = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "ProjectId");
                var contracts = _contractModels.Where(x => x.ProjectId == project).ToList();
                if (contracts == null || contracts.Count == 0) _gridLookUpEditContract.DataSource = _contractModels.ToList();
                else
                {
                    _gridLookUpEditContract.DataSource = contracts;

                }


            }
            if (e.Column.FieldName == "AutoBusinessId")
            {
                var autoBusinessId = grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId") == null ? string.Empty : grdAccountingView.GetRowCellValue(e.RowHandle, "AutoBusinessId").ToString();
                if (autoBusinessId != string.Empty)
                {
                    var autoBusiness = (AutoBusinessModel)_gridLookUpEditDebitAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    // && autoBusiness.RefTypeId == (int)BaseRefTypeId
                    if (autoBusiness != null)
                    {

                        if (autoBusiness.BudgetSourceId == "00000000-0000-0000-0000-000000000000") grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", null);
                        else
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSourceId", autoBusiness.BudgetSourceId);

                        grdAccountingView.SetRowCellValue(e.RowHandle, "DebitAccount", autoBusiness.DebitAccount);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "CreditAccount", autoBusiness.CreditAccount);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "Description", autoBusiness.AutoBusinessName);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetChapterCode", autoBusiness.BudgetChapterCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", autoBusiness.BudgetKindItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", autoBusiness.BudgetSubKindItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetSubItemCode", autoBusiness.BudgetSubItemCode);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "MethodDistributeID", autoBusiness.MethodDistributeId);
                        grdAccountingView.SetRowCellValue(e.RowHandle, "CashWithDrawTypeID", autoBusiness.CashWithDrawTypeId);
                    }
                }
            }

            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case nameof(BADepositDetailModel.AmountOC):
                    decimal turnOver = Convert.ToDecimal((e.Value ?? 0));
                    view.SetFocusedRowCellValue(nameof(BADepositDetailModel.TurnOver), turnOver);

                    decimal vatRate = Convert.ToDecimal((view.GetFocusedRowCellValue(nameof(BADepositDetailModel.VATRate)) ?? 0));
                    if (vatRate < 0)
                        vatRate = 0;

                    view.SetFocusedRowCellValue(nameof(BADepositDetailModel.VATAmount), turnOver * vatRate / 100);
                    break;
            }
        }

        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            switch (e.Column.FieldName)
            {
                case nameof(BADepositDetailModel.VATRate):
                    decimal turnOver = Convert.ToDecimal((view.GetFocusedRowCellValue(nameof(BADepositDetailModel.TurnOver)) ?? 0));

                    decimal vatRate = Convert.ToDecimal((e.Value ?? 0));
                    if (vatRate < 0)
                        vatRate = 0;

                    view.SetFocusedRowCellValue(nameof(BADepositDetailModel.VATAmount), turnOver * vatRate / 100);
                    break;
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;

            var result = new DialogResult();
            if (BADepositDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            return result == DialogResult.OK ? _bADepositPresenter.Save(true) : _bADepositPresenter.Save(false);
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _bADepositPresenter.Display(KeyValue, true, false, false, true);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboObjectCode.Enabled = isEnable;
            cboBank.Enabled = isEnable;
        }

        protected override void DeleteVoucher()
        {
            _bADepositPresenter.Delete(KeyValue);
        }

        #endregion

        #region IBADepositView

        public string Payer
        {
            get { return txtPayer.Text; }
            set { txtPayer.Text = value; }
        }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    gridViewMaster.SetRowCellValue(0, "CurrencyCode", value);
            }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate
        {
            get
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    return 1;
                return (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
            }
            set
            {
                if (CurrencyCode == GlobalVariable.MainCurrencyId)
                    value = 1;
                gridViewMaster.SetRowCellValue(0, "ExchangeRate", value);
            }
        }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the outward reference no.
        /// </summary>
        /// <value>
        /// The outward reference no.
        /// </value>
        public string OutwardRefNo { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public string AccountingObjectId
        {
            get { return cboObjectCode.EditValue == null ? null : cboObjectCode.EditValue.ToString(); }
            set
            {
                cboObjectCode.EditValue = value;
                if (cboObjectCode.EditValue != null)
                {
                    var address = (string)cboObjectCode.GetColumnValue("Address");
                    txtAddress.Text = address;
                }
            }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public string BankId
        {
            get { return cboBank.EditValue == null ? null : cboBank.EditValue.ToString(); }
            set
            {
                cboBank.EditValue = value;
                if (!string.IsNullOrEmpty(value))
                {
                    var bankName = (string)cboBank.GetColumnValue("BankName");
                    txtBankName.Text = bankName;
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the inv.
        /// </summary>
        /// <value>
        /// The type of the inv.
        /// </value>
        public int? InvType { get; set; }

        /// <summary>
        /// Gets or sets the inv date.
        /// </summary>
        /// <value>
        /// The inv date.
        /// </value>
        public DateTime? InvDate { get; set; }

        /// <summary>
        /// Gets or sets the inv series.
        /// </summary>
        /// <value>
        /// The inv series.
        /// </value>
        public string InvSeries { get; set; }

        /// <summary>
        /// Gets or sets the inv no.
        /// </summary>
        /// <value>
        /// The inv no.
        /// </value>
        public string InvNo { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount
        {
            get
            {
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount");
            }
            set
            {
                gridViewMaster.SetRowCellValue(0, "TotalAmount", value);
            }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC
        {
            get
            {
                return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC");
            }
            set
            {
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", value);
            }
        }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>
        /// The total tax amount.
        /// </value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total outward amount.
        /// </summary>
        /// <value>
        /// The total outward amount.
        /// </value>
        public decimal TotalOutwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BADepositEntity" /> is reconciled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if reconciled; otherwise, <c>false</c>.
        /// </value>
        public bool Reconciled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BADepositEntity" /> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        public int? PostVersion { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion { get; set; }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>
        /// The reference order.
        /// </value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the invoice form.
        /// </summary>
        /// <value>
        /// The invoice form.
        /// </value>
        public int? InvoiceForm { get; set; }

        /// <summary>
        /// Gets or sets the invoice form number identifier.
        /// </summary>
        /// <value>
        /// The invoice form number identifier.
        /// </value>
        public string InvoiceFormNumberId { get; set; }

        /// <summary>
        /// Gets or sets the inv series prefix.
        /// </summary>
        /// <value>
        /// The inv series prefix.
        /// </value>
        public string InvSeriesPrefix { get; set; }

        /// <summary>
        /// Gets or sets the inv series suffix.
        /// </summary>
        /// <value>
        /// The inv series suffix.
        /// </value>
        public string InvSeriesSuffix { get; set; }

        /// <summary>
        /// Gets or sets the pay form.
        /// </summary>
        /// <value>
        /// The pay form.
        /// </value>
        public string PayForm { get; set; }

        /// <summary>
        /// Gets or sets the COM pany taxcode.
        /// </summary>
        /// <value>
        /// The COM pany taxcode.
        /// </value>
        public string ComPanyTaxcode { get; set; }

        /// <summary>
        /// Gets or sets the name of the accounting object contact.
        /// </summary>
        /// <value>
        /// The name of the accounting object contact.
        /// </value>
        public string AccountingObjectContactName { get; set; }

        /// <summary>
        /// Gets or sets the list no.
        /// </summary>
        /// <value>
        /// The list no.
        /// </value>
        public string ListNo { get; set; }

        /// <summary>
        /// Gets or sets the list date.
        /// </summary>
        /// <value>
        /// The list date.
        /// </value>
        public DateTime? ListDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attach list.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is attach list; otherwise, <c>false</c>.
        /// </value>
        public bool IsAttachList { get; set; }

        /// <summary>
        /// Gets or sets the list common name inventory.
        /// </summary>
        /// <value>
        /// The list common name inventory.
        /// </value>
        public string ListCommonNameInventory { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>
        /// The bu commitment request identifier.
        /// </value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the total receipt amount.
        /// </summary>
        /// <value>
        /// The total receipt amount.
        /// </value>
        public decimal TotalReceiptAmount { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit details.
        /// </summary>
        /// <value>
        /// The ba deposit details.
        /// </value>
        /// 
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.RefTypeId == (int)BuCA.Enum.RefType.BADeposit).ToList();
                    _gridLookUpEditDebitAutoBusinessView = new GridView();
                    _gridLookUpEditDebitAutoBusinessView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAutoBusiness = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAutoBusinessView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditDebitAutoBusiness.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAutoBusiness.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAutoBusiness.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAutoBusiness.View.BestFitColumns();

                    _gridLookUpEditDebitAutoBusiness.DataSource = data;
                    _gridLookUpEditDebitAutoBusinessView.PopulateColumns(data);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "AutoBusinessCode",
                            ColumnCaption = "Mã",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 150
                        },
                        new XtraColumn
                        {
                            ColumnName = "AutoBusinessName",
                            ColumnCaption = "ĐK tự động",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 300
                        },

                        new XtraColumn {ColumnName = "AutoBusinessID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefTypeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CashWithDrawTypeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},


                    };

                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditBudgetExpense.DisplayMember = "BudgetExpenseName";
                    //_gridLookUpEditBudgetExpense.ValueMember = "BudgetExpenseId";

                    _gridLookUpEditDebitAutoBusinessView = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAutoBusiness = XtraColumnCollectionHelper<AutoBusinessModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAutoBusinessView, data, "AutoBusinessCode", "AutoBusinessId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AutoBusinessModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAutoBusinessView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public IList<BADepositDetailModel> BADepositDetails
        {
            get
            {
                var bADepositDetails = new List<BADepositDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountOC = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BADepositDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode = budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new BADepositDetailModel
                            {
                                AutoBusinessId = rowVoucher.AutoBusinessId,
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                BankId = rowVoucher.BankId,
                                SortOrder = rowVoucher.SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                FundStructureId = rowVoucher.FundStructureId
                            };
                            totalAmount += item.Amount;
                            totalAmountOC += item.AmountOC;
                            bADepositDetails.Add(item);
                        }
                        //TotalAmount = totalAmount;
                        //TotalAmountOC = totalAmountOC;
                    }
                }

                if (bADepositDetails.Count > 0)
                {
                    if (grdAccountingDetail.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (BADepositDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bADepositDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bADepositDetails[i].ActivityId = rowVoucher.ActivityId;
                                bADepositDetails[i].ProjectId = rowVoucher.ProjectId;
                                bADepositDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                bADepositDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                            }
                        }
                    }
                }

                return bADepositDetails;
            }
            set
            {
                var lstSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BADepositDetailModel>();
                bindingSourceDetail.DataSource = lstSource;
                grdAccountingView.PopulateColumns(lstSource);
                grdAccountingDetailView.PopulateColumns(lstSource);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                      new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAutoBusiness,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                      new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                      new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },

                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },


                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 17,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                     new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 18,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Chương",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition = 112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },

                      new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                      new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 114,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                      new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 115,
                        AllowEdit = true
                    },
                       new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountingObject,
                        ColumnWith = 130,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true
                    },
                      new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },


                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },

                     new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 119,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                       new XtraColumn
                    {
                        ColumnName = "TotalAmount",
                        ColumnVisible = false
                    },


                    new XtraColumn
                    {
                        ColumnName = "Tax",
                        ColumnVisible = false
                    },
                };

                XtraColumnCollectionHelper<BADepositDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion

                #region columns for grdAccountingDetailView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },


                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },



                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetExpense
                    },
                };

                XtraColumnCollectionHelper<BADepositDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingDetailView);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion

                bool visibale = (CurrencyCode != "VND");
                grdAccountingView.Columns["Amount"].Visible = visibale;
            }
        }

        /// <summary>
        /// Gets or sets the ba deposit detail fixed asset entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail fixed asset entities.
        /// </value>
        public IList<BADepositDetailFixedAssetModel> BADepositDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail sale entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail sale entities.
        /// </value>
        public IList<BADepositDetailSaleModel> BADepositDetailSales { get; set; }

        /// <summary>
        /// Gets or sets the ba deposit detail tax entities.
        /// </summary>
        /// <value>
        /// The ba deposit detail tax entities.
        /// </value>
        public IList<BADepositDetailTaxModel> BADepositDetailTaxs
        {
            get
            {
                var source = (List<BADepositDetailModel>)bindingSourceDetail.DataSource;

                return source.Select(m => Mapper.AutoMapper(m, new BADepositDetailTaxModel())).ToList();
            }

            set
            {
                if (value == null)
                    value = new List<BADepositDetailTaxModel>();

                var target = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BADepositDetailTaxModel>();
                var source = ((List<BADepositDetailModel>)bindingSourceDetail.DataSource).OrderBy(s => s.SortOrder).ToList();

                for (int i = 0; i < target.Count; i++)
                {
                    Mapper.AutoMapper(target[i], source[i]);
                }

                #region columns for grdTaxView
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnWith = 220,
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 1,
                    AllowEdit = true,
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VATAmount",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Tiền thuế",
                    ColumnPosition = 2,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VATRate",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Thuế suất",
                    ColumnPosition = 3,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditTaxRate
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TurnOver",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Giá tính thuế",
                    ColumnPosition = 4,
                    IsSummnary = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvType",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Loại hóa đơn",
                    ColumnPosition = 5,
                    AllowEdit = true,
                    RepositoryControl = _repositoryInvType
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvoiceTypeCode",
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnCaption = "Mẫu số HĐ",
                    ColumnPosition = 6,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditInvoiceFormNumber
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvDate",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Ngày hóa đơn",
                    ColumnPosition = 7,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.DateTime
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvSeries",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Ký hiệu HĐ",
                    ColumnPosition = 8,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvNo",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Số hóa đơn",
                    ColumnPosition = 9,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PurchasePurposeId",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Nhóm HHDV",
                    ColumnPosition = 10,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditPurchasePurpose
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnVisible = false,
                    ColumnWith = 150,
                    ColumnCaption = "Đối tượng",
                    ColumnPosition = 11,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditAccountingObject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectName",
                    ColumnVisible = false,
                    ColumnWith = 150,
                    ColumnCaption = "Đối tượng khác",
                    ColumnPosition = 12,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectAddress",
                    ColumnVisible = false,
                    ColumnWith = 150,
                    ColumnCaption = "Địa chỉ",
                    ColumnPosition = 13,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CompanyTaxCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mã số thuế",
                    ColumnPosition = 14,
                    AllowEdit = true
                });

                XtraColumnCollectionHelper<BADepositDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdTaxView);
                grdTaxView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the ba deposit detail parallels.
        /// </summary>
        /// <value>The ba deposit detail parallels.</value>
        public IList<BADepositDetailParallelModel> BADepositDetailParallels
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var depositDetailParallels = new List<BADepositDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BADepositDetailParallelModel)grdViewAccountingParallel.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode = budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new BADepositDetailParallelModel
                            {
                                AutoBusinessID = rowVoucher.AutoBusinessID,
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithdrawTypeId = rowVoucher.CashWithdrawTypeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ActivityId = rowVoucher.ActivityId,
                                ProjectId = rowVoucher.ProjectId,
                                Approved = true,
                                SortOrder = rowVoucher.SortOrder ?? i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BankId = rowVoucher.BankId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,

                            };
                            depositDetailParallels.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return depositDetailParallels;

            }
            set
            {
                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BADepositDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AutoBusinessId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAutoBusiness,
                        ColumnWith = 200,
                        ColumnCaption = "ĐK tự động",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },
                     new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        SummaryType = SummaryItemType.Sum,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 17,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 18,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 19,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 110,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 111,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition =112,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 113,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                      new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 114,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 115,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountingObject,
                        ColumnWith = 130,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 116,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 118,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },

                      new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption ="Công việc",
                        ColumnPosition = 119,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                };

                //grdViewAccountingParallel.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(grdViewAccountingParallel, true);
                //grdViewAccountingParallel.OptionsView.ShowFooter = false;
                XtraColumnCollectionHelper<BADepositDetailParallelModel>.ShowXtraColumnInGridView(columnsCollection, grdViewAccountingParallel);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                bool visibale = (CurrencyCode != "VND");
                grdViewAccountingParallel.Columns["Amount"].Visible = visibale;
                #endregion
            }
        }

        #endregion

        #region Control Events

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            EvenChangeObjectCode();
            BADepositDetails = BADepositDetails;
        }
        void EvenChangeObjectCode()
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");
            var accountId = cboObjectCode.EditValue;
            var accountingObject = _model.GetAccountingObject(AccountingObjectId) ?? new AccountingObjectModel();
            var bank = _model.GetProjectBank(accountId.ToString()).OrderByDescending(o => o.SortBank).FirstOrDefault();

            cboObjectName.Text = accountName;
            txtAddress.Text = address;

            for (int i = 0; i < grdAccountingView.RowCount; i++)
            {
                grdAccountingView.SetRowCellValue(i, "AccountingObjectId", accountId);
                //if (bank != null)
                //{
                //    grdAccountingView.SetRowCellValue(i, "BankId", bank.BankId);
                //}
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, null);
            }
        }
        /// <summary>
        /// Handles the EditValueChanged event of the cboBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboBank_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBank.EditValue == null)
                return;
            var bankName = (string)cboBank.GetColumnValue("BankName");

            txtBankName.Text = bankName;
            for (int i = 0; i < grdAccountingView.RowCount; i++)
            {

                grdAccountingView.SetRowCellValue(i, "BankId", BankId);
            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                SetDetailFromMaster(grdAccountingView, 2, AccountingObjectId, BankId, null);
                AutoBankId = BankId;
                grdAccountingView.SetRowCellValue(1, "BankId", AutoBankId);

            }

        }

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (grdView.Columns[column.ColumnName] != null)
                {
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
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            return grdView;
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var methodDistribute = typeof(MethodDistribute).ToList();
            _repositoryMethodDistributeId = new RepositoryItemLookUpEdit
            {
                DataSource = methodDistribute,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryMethodDistributeId.PopulateColumns();
            _repositoryMethodDistributeId.Columns["Key"].Visible = false;

            // Thuế suất
            var vatRates = new Dictionary<int, string> { { 0, "0%" }, { 10, "10%" }, { 15, "15%" }, { -1, "KCT" } };  // Không chịu thế = -1 tương đương thuế suất = 0
            _gridLookUpEditTaxRateView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
            _gridLookUpEditTaxRate = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxRateView, vatRates.ToList(), "Value", "Key");
            _gridLookUpEditTaxRate.PopupFormSize = new Size(180, 150);
            var gridColumnsCollection = new List<XtraColumn>();
            gridColumnsCollection.Add(new XtraColumn { ColumnName = "Value", ColumnCaption = "Thuế suất", ColumnVisible = true, ColumnWith = 180, ColumnPosition = 1 });
            XtraColumnCollectionHelper<KeyValuePair<int, string>>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxRateView);

            var invoiceTypes = typeof(InvoiceType).ToList();
            _repositoryInvType = new RepositoryItemLookUpEdit
            {
                DataSource = invoiceTypes,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryInvType.PopulateColumns();
            _repositoryInvType.Columns["Key"].Visible = false;
        }

        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            bindingSourceDetail.ResetBindings(false);
        }
        #endregion

        #region IView

        #region BudgetSources

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {

                    _budgetSourceModels = value.ToList();
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();

                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = budgetSourceModels;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(budgetSourceModels);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Mã nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceName",
                        ColumnCaption = "Tên nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceModels, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IAccountsView

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<AccountModel>();
                    _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());

                    _accountModels = value;

                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var parallelAccounts = value.ToList().ParallelAccounts();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);

                    _gridLookUpEditAccountParallelView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountParallel = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountParallelView, parallelAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountParallelView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetChapters

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
                    _gridLookUpEditBudgetChapterView = new GridView();
                    _gridLookUpEditBudgetChapterView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetChapter = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetChapterView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnCaption = "Mã Chương",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterName",
                        ColumnCaption = "Tên Chương",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetKindItems

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnCaption = "Mã Khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemName",
                        ColumnCaption = "Tên Khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetItems

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>
        /// The BudgetItems.
        /// </value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    _budgetItemModels2 = value.ToList();
                    //var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive).ToList();
                    //_budgetItemModels = budgetItemModels;
                    //var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive).ToList();
                    //Tintv: Chỉ hiển thị Mục/Tiểu mục thuộc "Nhóm tiểu mục 0136" 
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();
                    _budgetSubItemModels = budgetSubItemModels;

                    #region BudgetItem
                    _gridLookUpEditBudgetItemView = new GridView();
                    _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetItem.View.BestFitColumns();

                    _gridLookUpEditBudgetItem.DataSource = budgetItemModels;
                    _gridLookUpEditBudgetItemView.PopulateColumns(budgetItemModels);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã Mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên Mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
                    #endregion

                    #region BudgetSubItem
                    _gridLookUpEditBudgetSubItemView = new GridView();
                    _gridLookUpEditBudgetSubItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubItem.DataSource = budgetSubItemModels;
                    _gridLookUpEditBudgetSubItemView.PopulateColumns(budgetSubItemModels);
                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã tiểu mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên tiểu mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);
                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region CashWithdrawTypeModels
        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        /// The cash withdraw type models.
        /// </value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                try
                {
                    _gridLookUpEditCashWithdrawTypeView = new GridView();
                    _gridLookUpEditCashWithdrawTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCashWithdrawType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCashWithdrawTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);

                    _gridLookUpEditCashWithdrawType.View.BestFitColumns();

                    _gridLookUpEditCashWithdrawType.DataSource = value;
                    _gridLookUpEditCashWithdrawTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeName",
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false });

                    _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, "CashWithdrawTypeName", "CashWithdrawTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Banks

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                cboBank.Properties.DataSource = value;
                cboBank.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBank);

                cboBank.Properties.DisplayMember = "BankAccount";
                cboBank.Properties.ValueMember = "BankId";


                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region AccountingObjects

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                var accountingObjects = new List<AccountingObjectModel>();
                if (!string.IsNullOrEmpty(AccountingObjectCategoryId))
                {
                    if (AccountingObjectCategoryId == "00000000-0000-0000-0000-000000000000")
                    {
                        accountingObjects = value.Where(a => a.IsEmployee == true && string.IsNullOrEmpty(a.AccountingObjectCategoryId)).OrderBy(c => c.AccountingObjectCode).ToList();
                    }
                    else
                        accountingObjects = value.Where(a => a.AccountingObjectCategoryId == AccountingObjectCategoryId).OrderBy(c => c.AccountingObjectCode).ToList();
                }
                else
                    accountingObjects = value.OrderBy(c => c.AccountingObjectCode).ToList();
                cboObjectCode.Properties.DataSource = accountingObjects;
                cboObjectCode.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "AccountingObjectBanks", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Fax", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Website", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CompanyTaxCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AreaCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactTitle", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactSex", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactMobile", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactEmail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactOfficeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactHomeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPersonal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IdentificationNumber", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueBy", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryScaleId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Insured", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LabourUnionFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FamilyDeductionAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomerVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryCoefficient", ColumnVisible = false},
                    new XtraColumn {ColumnName = "NumberFamilyDependent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryForm", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryPercentRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InsuranceAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeAO", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryGrade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBornLeave", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxDepartmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrganizationFeeCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrganizationManageFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryManageFee", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboObjectCode.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboObjectCode.Properties.SortColumnIndex = column.ColumnPosition;
                        cboObjectCode.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboObjectCode.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboObjectCode.Properties.DisplayMember = "AccountingObjectCode";
                cboObjectCode.Properties.ValueMember = "AccountingObjectId";

                #region Lookup edit accounting objects

                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = accountingObjects;
                _gridLookUpEditAccountingObjectView.PopulateColumns(accountingObjects);

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                //}
                //_gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                //_gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, accountingObjects, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

        #endregion

        #region Activitys
        /// <summary>
        /// Sets the activitys.
        /// </summary>
        /// <value>
        /// The activitys.
        /// </value>
        public IList<ActivityModel> Activitys
        {
            set
            {
                try
                {
                    _gridLookUpEditActivityView = new GridView();
                    _gridLookUpEditActivityView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditActivity = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditActivityView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditActivity.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditActivity.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditActivity.PopupFormSize = new Size(380, 150);

                    _gridLookUpEditActivity.View.BestFitColumns();

                    _gridLookUpEditActivity.DataSource = value;
                    _gridLookUpEditActivityView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityCode",
                        ColumnCaption = "Mã công việc",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 130
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityName",
                        ColumnCaption = "Tên công việc",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                    _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityCode", "ActivityId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Projects
        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    var projects = value.Where(o => o.ObjectType == 2).OrderBy(c => c.ProjectCode).ToList();
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã Dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên Dự án",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, projects, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FundStructures
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>
        /// The fund structures.
        /// </value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                try
                {
                    var data = value.Where(o => o.IsParent == false && o.Inactive == true).ToList();
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = data;
                    _gridLookUpEditFundStructureView.PopulateColumns(data);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureCode",
                        ColumnCaption = "Mã khoản chi",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên khoản chi",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, data, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IView PurchasePurposes

        /// <summary>
        /// Gets the purchase purposes.
        /// </summary>
        /// <value>
        /// The purchase purposes.
        /// </value>
        public IList<PurchasePurposeModel> PurchasePurposes
        {
            set
            {
                try
                {
                    _gridLookUpEditPurchasePurposeView = new GridView();
                    _gridLookUpEditPurchasePurposeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditPurchasePurpose = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditPurchasePurposeView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditPurchasePurpose.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditPurchasePurpose.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditPurchasePurpose.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditPurchasePurpose.View.BestFitColumns();

                    _gridLookUpEditPurchasePurpose.DataSource = value;
                    _gridLookUpEditPurchasePurposeView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasePurposeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "PurchasePurposeCode",
                        ColumnCaption = "Mã nhóm",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "PurchasePurposeName",
                        ColumnCaption = "Tên nhóm",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    _gridLookUpEditPurchasePurposeView = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditPurchasePurpose = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditPurchasePurposeView, value, "PurchasePurposeName", "PurchasePurposeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<PurchasePurposeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditPurchasePurposeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Mẫu số hóa đơn
        public IList<InvoiceFormNumberModel> InvoiceFormNumbers
        {
            set
            {
                if (value == null)
                    value = new List<InvoiceFormNumberModel>();

                _gridLookUpEditInvoiceFormNumberView = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridViewReponsitory();
                _gridLookUpEditInvoiceFormNumber = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceFormNumberView, value, "InvoiceFormNumberName", "InvoiceFormNumberCode");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberCode", ColumnCaption = "Mẫu số", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberName", ColumnCaption = "Tên mẫu", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                _gridLookUpEditInvoiceFormNumberView = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridViewReponsitory();
                _gridLookUpEditInvoiceFormNumber = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceFormNumberView, value, "InvoiceFormNumberCode", "InvoiceFormNumberId", gridColumnsCollection);
                XtraColumnCollectionHelper<InvoiceFormNumberModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInvoiceFormNumberView);

            }
        }

        #endregion

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetExpenseView = new GridView();
                    _gridLookUpEditBudgetExpenseView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetExpense = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetExpenseView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetExpense.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetExpense.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetExpense.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetExpense.View.BestFitColumns();

                    _gridLookUpEditBudgetExpense.DataSource = value;
                    _gridLookUpEditBudgetExpenseView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "BudgetExpenseCode",
                            ColumnCaption = "Mã",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetExpenseName",
                            ColumnCaption = "Phí lệ phí",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetExpenseType", ColumnVisible = false}
                    };

                    _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion


        #region Contract

        /// <summary>
        /// Contract
        /// </summary>
        public IList<ContractModel> Contracts
        {
            set
            {
                _contractModels = value.ToList();
                if (value == null)
                    value = new List<ContractModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNo", ColumnCaption = "Số hợp đồng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractName", ColumnCaption = "Tên hợp đồng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditContractView = XtraColumnCollectionHelper<ContractModel>.CreateGridViewReponsitory();
                _gridLookUpEditContract = XtraColumnCollectionHelper<ContractModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditContractView, value, "ContractName", "ContractId", gridColumnsCollection);

                XtraColumnCollectionHelper<ContractModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditContractView);
                _gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion

        #region CapitalPlan

        /// <summary>
        /// Contract
        /// </summary>
        public IList<CapitalPlanModel> CapitalPlans
        {
            set
            {

                if (value == null)
                    value = new List<CapitalPlanModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanCode", ColumnCaption = "Mã kế hoạch vốn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanName", ColumnCaption = "Tên kế hoạch vốn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditCapitalPlanView = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridViewReponsitory();
                _gridLookUpEditCapitalPlan = XtraColumnCollectionHelper<CapitalPlanModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCapitalPlanView, value, "CapitalPlanCode", "CapitalPlanId", gridColumnsCollection);

                XtraColumnCollectionHelper<CapitalPlanModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCapitalPlanView);
                _gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion

        #endregion

        #region Event control

        private void FrmBADepositDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, true);
        }

        private void FrmBADepositDetail_Load(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.AddNew) ClickSomePoint();
            var accountingObject = _model.GetAccountingObject(AccountingObjectId) ?? new AccountingObjectModel();
            if (string.IsNullOrEmpty(accountingObject.AccountingObjectCategoryId) && accountingObject.IsEmployee)

            {
                AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                AccountingObjectCategoryId = accountingObject.AccountingObjectCategoryId;
            }
        }

        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);

        }
        /// <summary>
        /// Thêm mới bank từ combobox
        /// </summary>
        protected override void ShowBankDetail()
        {
            var frmBankDetail = new FrmBankDetail();
            frmBankDetail.ShowDialog();
            if (frmBankDetail.CloseBox)
            {
                if (!String.IsNullOrEmpty(GlobalVariable.BankIDProjectDetailForm))
                {
                    _banksPresenter.DisplayActive(true);
                    BADepositDetails = BADepositDetails;
                    cboBank.EditValue = GlobalVariable.BankIDProjectDetailForm;

                }
            }
        }

        /// <summary>
        /// Thêm mới đối tượng từ combobox
        /// </summary>
        protected override void ShowAccountingObjectDetail()
        {
            if (!lkAccountingObjectCategory.ItemIndex.Equals(-1))
            {
                if (lkAccountingObjectCategory.Text.Equals("NV")) //Thêm nhân viên
                {
                    using (var frmDetail = new FrmEmployeeDetail())
                    {
                        frmDetail.ShowDialog();
                        if (frmDetail.CloseBox)
                        {
                            if (!string.IsNullOrEmpty(GlobalVariable.EmployeeIDDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                BADepositDetails = BADepositDetails;
                                cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;

                                EvenChangeObjectCode();
                                var accounting = _model.GetAccountingObject(GlobalVariable.EmployeeIDDetailForm);
                                lkAccountingObjectCategory.EditValue = accounting.AccountingObjectCategoryId;
                                cboObjectName.EditValue = accounting.AccountingObjectName;
                            }
                        }
                    }
                }
                else //Thêm đối tượng
                {
                    using (var frmDetail = new FrmXtraAccountingObjectDetail())
                    {
                        frmDetail.AccountingObjectCategoryId = lkAccountingObjectCategory.EditValue.ToString();
                        frmDetail.ShowDialog();                        
                        if (frmDetail.CloseBox)
                        {
                            if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                BADepositDetails = BADepositDetails;
                                cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;

                                EvenChangeObjectCode();
                                var accounting = _model.GetAccountingObject(GlobalVariable.AccountingObjectIDInventoryItemDetailForm);
                                lkAccountingObjectCategory.EditValue = accounting.AccountingObjectCategoryId;
                                cboObjectName.EditValue = accounting.AccountingObjectName;
                            }
                        }
                    }
                }
            }
            else
            {
                var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
                XtraMessageBox.Show("Bạn chưa chọn loại đối tượng", detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            ShowAmountByCurrencyCode(grdViewAccountingParallel, "Amount", visibale);
        }
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            BADepositDetailModel data = view.GetFocusedRow() as BADepositDetailModel;
            if (view.FocusedColumn.FieldName == "ContractId" && view.ActiveEditor is GridLookUpEdit)
            {
                GridLookUpEdit editor = view.ActiveEditor as GridLookUpEdit;
                if (data != null && !string.IsNullOrEmpty(data.ProjectId))
                {
                    var contracts = _contractModels.Where(x => x.ProjectId == data.ProjectId).ToList();
                    if (contracts == null || contracts.Count == 0) editor.Properties.DataSource = _contractModels;
                    else
                    {
                        editor.Properties.DataSource = contracts;
                    }
                }
                else
                {
                    editor.Properties.DataSource = _contractModels;
                }
            }
        }
    }
}