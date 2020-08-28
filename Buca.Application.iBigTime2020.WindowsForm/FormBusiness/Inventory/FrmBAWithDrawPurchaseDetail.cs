/***********************************************************************
 * <copyright file="FrmBAWithDrawPurchaseDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   QuyenNH
 * Email:    quyennh@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// FrmBAWithDrawPurchaseDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Deposit.IBAWithDrawView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IStocksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IPurchasePurposesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    public partial class FrmBAWithDrawPurchaseDetail : FrmXtraBaseVoucherDetail, IAccountingObjectsView,
        IBAWithDrawView, IInventoryItemsView, IStocksView,
        IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView,
        ICashWithdrawTypesView, IActivitysView,
        IProjectsView, IFundStructuresView, IPurchasePurposesView, IBanksView, IBudgetExpensesView
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
        private IList<BudgetItemModel> _budgetItemModels;

        #endregion
        public List<SelectItemModel> Parallels { get; set; }
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly BAWithDrawPresenter _bAWithDrawPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly PurchasePurposesPresenter _purchasePurposesPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private IList<AccountModel> _accountModels;
        private string _mainCurrencyId;
        private decimal _exchangeRateDefault;
        private readonly IModel _model;

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxAccount;
        private GridView _gridLookUpEditTaxAccountView;

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

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;
        private GridView _gridLookUpEditPurchasePurposeView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemLookUpEdit _repositoryVATRate;
        private RepositoryItemLookUpEdit _repositoryInvType;

        #endregion

        public FrmBAWithDrawPurchaseDetail()
        {
            InitializeComponent();
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _bAWithDrawPresenter = new BAWithDrawPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _purchasePurposesPresenter = new PurchasePurposesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            AutoAccountingObjectId = AccountingObjectId;
            AutoBankId = BankId;
            lkAccountingObjectCategory.Visible = true;
            lbAccountingObjectCategory.Visible = true;
            _model = new Model.Model();
        }

        #region overrides function

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BAWithDrawPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;

            var result = new DialogResult();
            if (BAWithDrawDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _bAWithDrawPresenter.Save(true) : _bAWithDrawPresenter.Save(false);
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _bAWithDrawPresenter.Display(KeyValue, false, false, true, false, false);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupObjectPayment, isEnable);
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition =
                !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            IModel model = new Model.Model();
            if (e.Column.FieldName == "InventoryItemId")
            {
                var itemid = (string)grdAccountingView.GetRowCellValue(e.RowHandle, "InventoryItemId");
                var Item = model.GetInventoryItem(itemid);
                grdAccountingView.SetRowCellValue(e.RowHandle, "DebitAccount", Item.InventoryAccount);
                grdAccountingView.SetRowCellValue(e.RowHandle, "StockId", Item.DefaultStockId);
            }
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var budgetItemCode = model.GetBudgetItem(item.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }

            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabMain.SelectedTabPage = tabInventoryItem;
            grdTax.DataSource = bindingSourceDetail;
            cboBankAccount.Focus();
            tabInventoryItem.TabIndex = 1;
            tabTax.TabIndex = 2;
            tabAccounting.TabIndex = 3;
            tabAccountingDetail.TabIndex = 4;
            labelControl8.Visible = false;
            txtDescription.Visible = false;
            lblBankAccount.Visible = false;
            cboBank.Visible = false;
            cboBankAccount.Focus();
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            InitRepositoryControlData();
            _accountingObjectsPresenter.DisplayActive(true);
            _inventoryItemsPresenter.DisplayByIsToolAndIsStock(true);
            _stocksPresenter.DisplayByIsActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetExpensesPresenter.DisplayActive();
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((BAWithDrawModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((BAWithDrawModel)MasterBindingSource.Current).RefId;
            }

            _bAWithDrawPresenter.Display(KeyValue, false, false, true, false, false);
            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BAWithDrawPurchase;
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                CurrencyCode = GlobalVariable.MainCurrencyId;
                ExchangeRate = 1;
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            if (AccountingObjectId == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboObjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(InwardRefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInwardRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInwardRefNo.Focus();
                return false;
            }
            var bAWithDrawDetailPurchases = BAWithDrawDetailPurchases;
            if (bAWithDrawDetailPurchases.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var bawithDraw in BAWithDrawDetailPurchases)
            {
                if (bawithDraw.InventoryItemId == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemId"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (bawithDraw.StockId == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }

                if (bawithDraw.CreditAccount == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherCredit"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Grids the purchase cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "InventoryItemId")
            {
                var inventoryItemModel = (InventoryItemModel)_gridLookUpEditInventoryItem.GetRowByKeyValue(e.Value);
                var inventoryItemName = inventoryItemModel == null ? "" : inventoryItemModel.InventoryItemName;
                var unit = inventoryItemModel == null ? "" : inventoryItemModel.Unit;
                var accountdebit = inventoryItemModel == null ? "" : inventoryItemModel.InventoryAccount;
                var stockid = inventoryItemModel == null ? "" : inventoryItemModel.DefaultStockId;
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Description", inventoryItemName);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Unit", unit);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DebitAccount", accountdebit);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "StockId", stockid);
            }
            if (e.Column.FieldName == "Quantity")
            {
                var unitPrice = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice") == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * unitPrice);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount",
                    (decimal)e.Value * unitPrice);
            }
            if (e.Column.FieldName == "UnitPrice")
            {
                var quantity = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", (decimal)e.Value * quantity);
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount", (decimal)e.Value * quantity);
            }
        }

        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "TaxRate")
            {
                var amount = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount") == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Amount");
                var taxRate = e.Value ?? 0;
                var taxAmount = (amount * Convert.ToDecimal(taxRate)) / 100;
                grdTaxView.SetRowCellValue(e.RowHandle, "TaxAmount", taxAmount);
            }

            else if (e.Column.FieldName.Equals("TaxAmount"))
            {
                decimal taxAmount = (decimal)(e.Value ?? 0);
                // Update InwardAmount
                decimal quantity = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity") == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "Quantity");
                decimal unitPrice = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice") == null
                    ? 0
                    : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "UnitPrice");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "InwardAmount",
                    taxAmount + quantity * unitPrice);
            }
        }


        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
        }

        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
        }

        /// <summary>
        /// Initializes the detail row for acounting detail by tax.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetailByTax(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                if (_defaultDebitAccount != null)
                    view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
                if (_defaultCreditAccount != null)
                    view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ICAPaymentView

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate
        {
            get { return dtPostDate.EditValue == null ? DateTime.Now : (DateTime)dtPostDate.EditValue; }
            set { dtPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo
        {
            get { return txtRefNo.Text.Trim(); }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode
        {
            get { return string.IsNullOrEmpty(_mainCurrencyId) ? GlobalVariable.MainCurrencyId : _mainCurrencyId; }
            set { _mainCurrencyId = value; }
        }
        public string AccountingObjectBankAccount
        {
            get { return cboAccountObject.EditValue == null ? null : cboAccountObject.EditValue.ToString(); }
            set
            {
                cboAccountObject.EditValue = value;
                if (cboAccountObject.EditValue != null)
                {
                    var name = (string)cboAccountObject.GetColumnValue("BankName");
                    txtContactName.Text = name;
                }
            }
        }
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate
        {
            get { return _exchangeRateDefault == 0 ? 1 : _exchangeRateDefault; }
            set { _exchangeRateDefault = value; }
        }

        /// <summary>
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo { get; set; }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        public string IncrementRefNo { get; set; }

        /// <summary>
        /// Gets or sets the inward reference no.
        /// </summary>
        /// <value>The inward reference no.</value>
        public string InwardRefNo

        {
            get { return txtInwardRefNo.Text.Trim(); }
            set { txtInwardRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get { return cboObjectCode.EditValue == null ? null : cboObjectCode.EditValue.ToString(); }
            set { cboObjectCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo
        {
            get { return txtDocumentIncluded.Text.Trim(); }
            set { txtDocumentIncluded.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId
        {
            get { return cboBankAccount.EditValue == null ? null : cboBankAccount.EditValue.ToString(); }
            set { cboBankAccount.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount { get; set; }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        public decimal TotalFreightAmount { get; set; }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        public decimal TotalInwardAmount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value><c>true</c> if [posted]; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the reconciled.
        /// </summary>
        /// <value>
        /// The reconciled.
        /// </value>
        public bool? Reconciled { get; set; }

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
        /// <value>The reference order.</value>
        public int? RefOrder { get; set; }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId { get; set; }
        public int RelationType { get; set; }

        /// <summary>
        /// Gets or sets the total payment amount.
        /// </summary>
        /// <value>The total payment amount.</value>
        public decimal TotalPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw details.
        /// </summary>
        /// <value>
        /// The ba with draw details.
        /// </value>
        public IList<BAWithDrawDetailModel> BAWithDrawDetails { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw detail fixed assets.
        /// </summary>
        /// <value>
        /// The ba with draw detail fixed assets.
        /// </value>
        public IList<BAWithDrawDetailFixedAssetModel> BAWithDrawDetailFixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the ba withdraw detail salarys.
        /// </summary>
        /// <value>
        /// The ba withdraw detail salarys.
        /// </value>
        public IList<BAWithdrawDetailSalaryModel> BAWithdrawDetailSalarys { get; set; }

        /// <summary>
        /// Gets or sets the ba withdraw detail taxs.
        /// </summary>
        /// <value>
        /// The ba withdraw detail taxs.
        /// </value>
        public IList<BAWithdrawDetailTaxModel> BAWithdrawDetailTaxs { get; set; }

        /// <summary>
        /// Gets or sets the ba with draw detail purchases.
        /// </summary>
        /// <value>
        /// The ba with draw detail purchases.
        /// </value>
        public IList<BAWithDrawDetailPurchaseModel> BAWithDrawDetailPurchases
        {
            get
            {
                var bAWithDrawDetailPurchases = new List<BAWithDrawDetailPurchaseModel>();
                TotalAmount = 0;
                TotalAmountOC = 0;
                TotalTaxAmount = 0;
                TotalInwardAmount = 0;
                TotalPaymentAmount = 0;
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BAWithDrawDetailPurchaseModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b =>
                                    b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b =>
                                        b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode =
                                        budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new BAWithDrawDetailPurchaseModel
                            {
                                InventoryItemId = rowVoucher.InventoryItemId,
                                Description =
                                    string.IsNullOrEmpty(rowVoucher.Description)
                                        ? string.Empty
                                        : rowVoucher.Description.Trim(),
                                StockId = rowVoucher.StockId,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Unit = rowVoucher.Unit,
                                Quantity = rowVoucher.Quantity,
                                UnitPrice = rowVoucher.UnitPrice,
                                QuantityConvert = rowVoucher.QuantityConvert,
                                UnitPriceConvert = rowVoucher.UnitPriceConvert,
                                Amount = rowVoucher.Amount,
                                TaxRate = rowVoucher.TaxRate,
                                TaxAmount = rowVoucher.TaxAmount,
                                TaxAccount = rowVoucher.TaxAccount,
                                InvType = rowVoucher.InvType,
                                InvDate = rowVoucher.InvDate,
                                InvSeries = rowVoucher.InvSeries,
                                InvNo = rowVoucher.InvNo,
                                PurchasePurposeId = rowVoucher.PurchasePurposeId,
                                FreightAmount = rowVoucher.FreightAmount,
                                InwardAmount = rowVoucher.InwardAmount,
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
                                ProjectActivityId = rowVoucher.ProjectActivityId,
                                FundId = rowVoucher.FundId,
                                ListItemId = rowVoucher.ListItemId,
                                ExpiryDate = rowVoucher.ExpiryDate,
                                LotNo = rowVoucher.LotNo,
                                SortOrder = i,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                InvoiceTypeCode = rowVoucher.InvoiceTypeCode,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                FundStructureId = rowVoucher.FundStructureId,
                                ProjectActivityEAId = rowVoucher.ProjectActivityEAId,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BankId = rowVoucher.BankId
                               
                               
                            };
                            TotalAmount += rowVoucher.Amount;
                            TotalInwardAmount += rowVoucher.InwardAmount;
                            bAWithDrawDetailPurchases.Add(item);
                        }
                    }
                }

                if (bAWithDrawDetailPurchases.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (BAWithDrawDetailPurchaseModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bAWithDrawDetailPurchases[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bAWithDrawDetailPurchases[i].ActivityId = rowVoucher.ActivityId;
                                bAWithDrawDetailPurchases[i].ProjectId = rowVoucher.ProjectId;
                                bAWithDrawDetailPurchases[i].FundStructureId = rowVoucher.FundStructureId;
                                bAWithDrawDetailPurchases[i].SortOrder = i;
                            }
                        }
                    }
                }

                return bAWithDrawDetailPurchases;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ??
                                                 new List<BAWithDrawDetailPurchaseModel>();
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdTaxView.PopulateColumns(value);

                #region columns for grdAccountingView

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 210,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditStock,
                        ColumnWith = 100,
                        ColumnCaption = "Kho",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "ĐVT",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnPosition = 7,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 8,
                        ColumnType = UnboundColumnType.Decimal,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Thành tiền",
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "InvType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvSeries", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PurchasePurposeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Giá trị nhập kho",
                        ColumnType = UnboundColumnType.Decimal,
                        ColumnPosition = 10,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithdrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    // new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InvoiceTypeCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    // new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}
                };

                //grdDetailByInventoryItemView = InitGridLayout(columnsCollection, grdDetailByInventoryItemView);
                //SetNumericFormatControl(grdDetailByInventoryItemView, true);
                //grdDetailByInventoryItemView.OptionsView.ShowFooter = false;
                XtraColumnCollectionHelper<BAWithDrawDetailPurchaseModel>.ShowXtraColumnInGridView(columnsCollection,
                    grdDetailByInventoryItemView);

                #endregion

                #region columns for grdTaxView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thuế suất",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _repositoryVATRate
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiền thuế",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditTaxAccount,
                        ColumnWith = 100,
                        ColumnCaption = "TK thuế",
                        ColumnPosition = 5,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Loại HĐ",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _repositoryInvType
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnWith = 100,
                        ColumnCaption = "Ngày HĐ",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.DateTime
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Mẫu số HĐ",
                        ColumnPosition = 8,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nhóm HHDV",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditPurchasePurpose
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số HĐ",
                        ColumnPosition = 11,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithdrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}
                };

                grdTaxView = InitGridLayout(columnsCollection, grdTaxView);
                SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = false;

                #endregion

                #region columns for grdAccountingView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 280,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Chương",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnVisible = false
                    }, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Mục",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },

                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = true,
                        ColumnWith = 110,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    // new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    // new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}
                };

                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;

                #endregion

                #region columns for grdAccountingDetailView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InventoryItemId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditInventoryItem,
                        ColumnWith = 150,
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 280,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                    new XtraColumn
                    {
                        ColumnName = "StockId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxRate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "TaxAccount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvType",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvDate",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvSeries",
                        ColumnWith = 100,
                        ColumnCaption = "Ký hiệu HĐ",
                        ColumnPosition = 9,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "PurchasePurposeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "InvNo",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "InwardAmount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnVisible = false
                    }, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LotNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                    // new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false}
                };

                grdAccountingDetailView = InitGridLayout(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;

                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the ba with draw detail parallels.
        /// </summary>
        /// <value>The ba with draw detail parallels.</value>
        public IList<BAWithDrawDetailParallelModel> BAWithDrawDetailParallels
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var withDrawDetailParallels = new List<BAWithDrawDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BAWithDrawDetailParallelModel)grdViewAccountingParallel.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem = _budgetSubKindItemModels.FirstOrDefault(b =>
                                    b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem = _budgetKindItemModels.FirstOrDefault(b =>
                                        b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode =
                                        budgetKindItem == null ? null : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new BAWithDrawDetailParallelModel()
                            {
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
                                SortOrder = i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                BankId = rowVoucher.BankId,
                                FundStructureId = rowVoucher.FundStructureId
                            };
                            withDrawDetailParallels.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return withDrawDetailParallels;

            }
            set
            {
                bindingSourceDetailParallel.DataSource =
                    value.OrderBy(c => c.SortOrder).ToList() ?? new List<BAWithDrawDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditAccountParallel,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountParallel
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnVisible = false
                    }, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Mục",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 15,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Phí, lệ phí",
                        ColumnPosition = 16,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
                };

                //grdViewAccountingParallel.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(grdViewAccountingParallel, true);
                XtraColumnCollectionHelper<BAWithDrawDetailParallelModel>.ShowXtraColumnInGridView(columnsCollection,
                    grdViewAccountingParallel);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;

                #endregion
            }
        }

        #endregion

        #region private helper

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
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
                    //if ((column.ColumnPosition == 1) | (column.ColumnPosition == 3))
                    //{
                    //    grdView.Columns[column.ColumnName].AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                    //    grdView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    //}
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
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

            var vatRates =
                new Dictionary<string, string> { { "0", "0%" }, { "5", "5%" }, { "10", "10%" }, { "15", "15%" }, { "", "KCT" } };
            _repositoryVATRate = new RepositoryItemLookUpEdit
            {
                DataSource = vatRates,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryVATRate.PopulateColumns();
            _repositoryVATRate.Columns["Key"].Visible = false;

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

        #endregion

        #region IViews

        #region banks

        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                cboBankAccount.Properties.DataSource = value;
                cboBankAccount.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBankAccount);

                cboBankAccount.Properties.DisplayMember = "BankAccount";
                cboBankAccount.Properties.ValueMember = "BankId";
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                //Filter cho gridview
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #endregion

        #region BudgetSources

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
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

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
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                    //Filter cho gridview
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetChapters

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
                    //Filter cho gridview
                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetKindItems

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
                    _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";
                    //Filter cho gridview
                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetItems

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    _budgetItemModels = value.ToList();
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

                    #region BudgetItem

                    _gridLookUpEditBudgetItemView = new GridView();
                    _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode"; ;
                    //Filter cho gridview
                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, value, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";
                    //Filter cho gridview
                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, value, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                    #endregion
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region CashWithdrawTypeModels

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
                    _gridLookUpEditCashWithdrawTypeView = new GridView();
                    _gridLookUpEditCashWithdrawTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCashWithdrawType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCashWithdrawTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);

                    _gridLookUpEditCashWithdrawType.View.BestFitColumns();

                    _gridLookUpEditCashWithdrawType.DataSource = value;
                    _gridLookUpEditCashWithdrawTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeName",
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 350
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditCashWithdrawType.DisplayMember = "CashWithdrawTypeName";
                    _gridLookUpEditCashWithdrawType.ValueMember = "CashWithdrawTypeId";
                    //Filter cho gridview
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

        #region AccountingObjects

        /// <summary>
        ///     Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
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
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 135,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 280
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
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
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
                    ShowDropDown = ShowDropDown.SingleClick,
                    ImmediatePopup = true
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(440, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                            column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                //Filter cho gridview
                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectName", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

        #endregion

        #region Activitys

        /// <summary>
        /// Sets the activitys.
        /// </summary>
        /// <value>The activitys.</value>
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                        ColumnCaption = "Mã hoạt động SN",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 130
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ActivityName",
                        ColumnCaption = "Tên hoạt động SN",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditActivityView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditActivityView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditActivity.DisplayMember = "ActivityName";
                    _gridLookUpEditActivity.ValueMember = "ActivityId";
                    //Filter cho gridview
                    _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                    _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityName", "ActivityId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Projects

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã CTMT, dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên CTMT, dự án",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectEnglishName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDetailbyActivityAndExpense",
                        ColumnVisible = false
                    });
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
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                    //Filter cho gridview
                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region FundStructures

        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                try
                {
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                    //Filter cho gridview
                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region PurchasePurposes

        /// <summary>
        /// Gets the purchase purposes.
        /// </summary>
        /// <value>The purchase purposes.</value>
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
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
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
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditPurchasePurpose.DisplayMember = "PurchasePurposeName";
                    _gridLookUpEditPurchasePurpose.ValueMember = "PurchasePurposeId";
                    //Filter cho gridview
                    _gridLookUpEditPurchasePurposeView = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditPurchasePurpose = XtraColumnCollectionHelper<PurchasePurposeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditPurchasePurposeView, value, "PurchasePurposeName", "PurchasePurposeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<PurchasePurposeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditPurchasePurposeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                _gridLookUpEditBudgetExpenseView = new GridView();
                _gridLookUpEditBudgetExpenseView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpBudgetExpense = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditBudgetExpenseView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpBudgetExpense.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpBudgetExpense.View.OptionsView.ShowIndicator = false;
                _gridLookUpBudgetExpense.PopupFormSize = new Size(368, 150);

                _gridLookUpBudgetExpense.View.BestFitColumns();

                _gridLookUpBudgetExpense.DataSource = value;
                _gridLookUpEditBudgetExpenseView.PopulateColumns(value);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseCode",
                    ColumnCaption = "Mã phí, lệ phí",
                    ColumnPosition = 0,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                gridColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseName",
                    ColumnCaption = "Tên phí, lệ phí",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseType", ColumnVisible = false });
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditBudgetExpenseView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpBudgetExpense.DisplayMember = "BudgetExpenseName";
                _gridLookUpBudgetExpense.ValueMember = "BudgetExpenseId";
                //Filter cho gridview
                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);

            }
        }
        #endregion


        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    _gridLookUpEditInventoryItemView = new GridView();
                    _gridLookUpEditInventoryItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInventoryItem.View.BestFitColumns();

                    _gridLookUpEditInventoryItem.DataSource = value;
                    _gridLookUpEditInventoryItemView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã VT,HH",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên VT,HH",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInventoryItem.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditInventoryItem.ValueMember = "InventoryItemId";
                    //Filter cho gridview
                    _gridLookUpEditInventoryItemView = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInventoryItem = XtraColumnCollectionHelper<InventoryItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInventoryItemView, value, "InventoryItemCode", "InventoryItemId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInventoryItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                try
                {
                    _gridLookUpEditStockView = new GridView();
                    _gridLookUpEditStockView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditStock = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditStockView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditStock.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditStock.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditStock.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditStock.View.BestFitColumns();

                    _gridLookUpEditStock.DataSource = value;
                    _gridLookUpEditStockView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockCode",
                        ColumnCaption = "Mã kho",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockName",
                        ColumnCaption = "Tên kho",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultAccountNumber",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditStockView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditStockView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditStockView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditStockView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditStock.DisplayMember = "StockName";
                    _gridLookUpEditStock.ValueMember = "StockId";
                    //Filter cho gridview
                    _gridLookUpEditStockView = XtraColumnCollectionHelper<StockModel>.CreateGridViewReponsitory();
                    _gridLookUpEditStock = XtraColumnCollectionHelper<StockModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditStockView, value, "StockName", "StockId", gridColumnsCollection);
                    XtraColumnCollectionHelper<StockModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditStockView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                    _defaultDebitAccount =
                        BusinessExtension.DefaultDebitAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());
                    _defaultCreditAccount =
                        BusinessExtension.DefaultCreditAccount(value.ToList(), (int)BaseRefTypeId, RefTypes.ToList());

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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string ReceiveName { get; set; }
        public string ReceiveId { get; set; }
        public DateTime? ReceiveIssueDate { get; set; }
        public string ReceiveIssueLocation { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");
            var bankaccount = (string)cboObjectCode.GetColumnValue("BankAccount");
            var bankname = (string)cboObjectCode.GetColumnValue("BankName");
            txtAddress.Text = address;
            cboObjectName.Text = accountName;
            cboAccountObject.Text = bankaccount;
            txtContactName.Text = bankname;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingDetailView, 1, AccountingObjectId, BankId, null);
            }

        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBankAccount control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBankAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankAccount.EditValue == null)
                return;
            var bankName = (string) cboBankAccount.GetColumnValue("BankName");
            txtBankName.Text = bankName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {

                AutoBankId = BankId;
                SetDetailFromMaster(grdAccountingDetailView, 2, AccountingObjectId, BankId, null);
            }
        }
    

        #region grdViewAccountingParallel

        /// <summary>
        /// Handles the CellValueChanged event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }
            if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                    return;
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
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
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>grdViewAccountingParallel_CellValueChanged
        /// Handles the InitNewRow event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BAWithDrawDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmBAWithDrawPurchaseDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, false);
        }
        protected override void LkAccountingObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            _accountingObjectsPresenter.DisplayActive(true);
        }

        private void FrmBAWithDrawPurchaseDetail_Load(object sender, EventArgs e)
        {
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
                                cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;
                            }
                        }
                    }
                }
                else //Thêm đối tượng
                {
                    using (var frmDetail = new FrmXtraAccountingObjectDetail())
                    {
                        frmDetail.ShowDialog();
                        if (frmDetail.CloseBox)
                        {
                            if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                            {
                                _accountingObjectsPresenter.Display();
                                cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
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

        private void cboBankAccount_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBankDetail = new FrmBankDetail();
                frmBankDetail.ShowDialog();
                if (frmBankDetail.CloseBox)
                {
                    if (!String.IsNullOrEmpty(GlobalVariable.BankIDProjectDetailForm))
                    {
                        _banksPresenter.DisplayActive(true);
                        cboBankAccount.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
        #endregion

        //protected override void ShowAccountingObjectDetail()
        //{
        //    using (var frmDetail = new FrmXtraAccountingObjectDetail())
        //    {
        //        frmDetail.ShowDialog();
        //        if (frmDetail.CloseBox)
        //        {
        //            if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
        //            {
        //                _accountingObjectsPresenter.Display();
        //                cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
        //                var accountingObject = _model.GetAccountingObject(AccountingObjectId) ?? new AccountingObjectModel();
        //                if (string.IsNullOrEmpty(accountingObject.AccountingObjectCategoryId) && accountingObject.IsEmployee)

        //                {
        //                    AccountingObjectCategoryId = "00000000-0000-0000-0000-000000000000";
        //                }
        //                else
        //                {
        //                    AccountingObjectCategoryId = accountingObject.AccountingObjectCategoryId;
        //                }
        //            }
        //        }
        //    }
        //}


    }
}