using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.General;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.ParameterReportForm;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using System.Reflection;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using DevExpress.XtraEditors.Mask;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General
{
    /// <summary>
    /// FrmGLVoucherListDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.General.IGLVoucherListView" />
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
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInvoiceTypiesView" />
    public partial class FrmGLVoucherListDetail : FrmXtraBaseVoucherDetail, IGLVoucherListView, IAccountingObjectsView,
                                              IBudgetSourcesView, IAccountsView,
                                              IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView,
                                              ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView,
                                              IFundStructuresView, IPurchasePurposesView,
                                              IInvoiceTypiesView
    {
        #region Presenter

        private readonly GLVoucherListPresenter _glVoucherListPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
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
        private readonly InvoiceTypiesPresenter _invoiceTypiesPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly IModel _model;
        private List<BudgetItemModel> BudgetItemModels;

        private IList<GLVoucherListDetailModel> listDetail;

        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

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

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccountingObject;
        private GridView _gridLookUpEditCreditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        private RepositoryItemLookUpEdit _repositoryVATRate;
        private RepositoryItemLookUpEdit _repositoryInvType;

        private RepositoryItemGridLookUpEdit _gridLookUpEditPurchasePurpose;
        private GridView _gridLookUpEditPurchasePurposeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInvoiceType;
        private GridView _gridLookUpEditInvoiceTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditRefType;
        private GridView _gridLookUpEditRefTypeView;

        #endregion

        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmGLVoucherDetail"/> class.
        /// </summary>
        public FrmGLVoucherListDetail()
        {
            InitializeComponent();
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
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
            _invoiceTypiesPresenter = new InvoiceTypiesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _model = new Model.Model();

            _glVoucherListPresenter = new GLVoucherListPresenter(this);
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            tabMain.SelectedTabPage = tabAccounting;   
            dtPostDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            dtRefDate.Properties.Mask.EditMask = @"dd/MM/yyyy";

        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.Display();
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _invoiceTypiesPresenter.Display();
            _refTypesPresenter.Display();
            InitRepositoryControlData();

            //SetEnableGroupBox(false);
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((GLVoucherListModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource.Current != null && KeyValue == null)
                    KeyValue = ((GLVoucherListModel)MasterBindingSource.Current).RefId;
            }
    
            _glVoucherListPresenter.Display(KeyValue);

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.GLVoucherList;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");

            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var paymentVoucherDetails = GlVoucherListDetails;
            if (paymentVoucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
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
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
        {
            try
            {
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return _glVoucherListPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new GLVoucherListPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
               
                if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = BudgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var budgetItemCode = BudgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grids the tax cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridTaxCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                grdTax.RefreshDataSource();
                if (e.Column.FieldName == "VATAmount")
                {
                    var vatRate = grdTaxView.GetRowCellValue(e.RowHandle, "VATRate") == null ? 0 : (decimal)grdTaxView.GetRowCellValue(e.RowHandle, "VATRate");
                    var vatAmount = grdTaxView.GetRowCellValue(e.RowHandle, "VATAmount") == null ? 0 : (decimal)grdTaxView.GetRowCellValue(e.RowHandle, "VATAmount");
                    var turnOver = vatRate * vatAmount / 100;
                    grdTaxView.SetRowCellValue(0, "TurnOver", turnOver);
                }
                if (e.Column.FieldName == "VATRate")
                {
                    var vatRate = grdTaxView.GetRowCellValue(e.RowHandle, "VATRate") == null ? 0 : (decimal)grdTaxView.GetRowCellValue(e.RowHandle, "VATRate");
                    var vatAmount = grdTaxView.GetRowCellValue(e.RowHandle, "VATAmount") == null ? 0 : (decimal)grdTaxView.GetRowCellValue(e.RowHandle, "VATAmount");
                    var turnOver = vatRate * vatAmount / 100;
                    grdTaxView.SetRowCellValue(0, "TurnOver", turnOver);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var columWidth = 0;
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
                    columWidth += column.ColumnWith;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                    if (column.ColumnPosition == 11)
                    {
                        grdView.Columns[column.ColumnName].Width = grid.Width - columWidth + column.ColumnWith;
                    }
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

            var vatRates = new Dictionary<string, string> { { "0", "0%" }, { "10", "10%" }, { "15", "15%" }, { "", "KCT" } };
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

        #region Control Event

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditDebitAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var account = grdAccountingView.Columns["DebitAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, account, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditCreditAccountView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditCreditAccountView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var account = grdAccountingView.Columns["CreditAccount"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, account, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSourceView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSourceView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetSourceId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetChapterView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetChapterView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetSubItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetSubKindItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditCashWithdrawTypeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["CashWithDrawTypeId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditBankView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBankView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BankId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditActivityView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditActivityView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["ActivityId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditProjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditProjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["ProjectId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditFundStructureView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditFundStructureView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["FundStructureId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditAccountingObjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditAccountingObjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var accountingObjectId = grdAccountingDetailView.Columns["AccountingObjectId"];
            grdAccountingDetailView.SetRowCellValue(grdAccountingDetailView.FocusedRowHandle, accountingObjectId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditCreditAccountingObjectView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditCreditAccountingObjectView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var creditAccountingObjectId = grdAccountingDetailView.Columns["CreditAccountingObjectId"];
            grdAccountingDetailView.SetRowCellValue(grdAccountingDetailView.FocusedRowHandle, creditAccountingObjectId,
                                                    null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditPurchasePurposeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditPurchasePurposeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var fundStructureId = grdTaxView.Columns["PurchasePurposeId"];
            grdTaxView.SetRowCellValue(grdTaxView.FocusedRowHandle, fundStructureId, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the KeyDown event of the _gridLookUpEditInvoiceTypeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void _gridLookUpEditInvoiceTypeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var invoiceType = grdTaxView.Columns["InvType"];
            grdTaxView.SetRowCellValue(grdTaxView.FocusedRowHandle, invoiceType, null);
            e.Handled = true;
        }


        /// <summary>
        /// Handles the Click event of the labelControl5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnSelectVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectVoucher_Click(object sender, EventArgs e)
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew && ActionMode != ActionModeVoucherEnum.Edit)
                return;

            using (var frmParam = new FrmGLVoucherListParamater(GlVoucherListDetails))
            {
                frmParam.Text = @"Chọn chứng từ";
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    //listDetail = frmParam.GlVoucherListDetailModels;
                    listDetail = GlVoucherListDetails;
                    foreach (GLVoucherListDetailModel item in frmParam.GlVoucherListDetailModels)
                        listDetail.Add(item);
                    grdAccounting.DataSource = listDetail;
                    grdAccounting.RefreshDataSource();
                    grdAccountingView.RefreshData();

                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeleteVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            grdAccountingView.DeleteSelectedRows();
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            base.SetEnableGroupBox(isEnable);
            EnableControlsInGroup(groupObject, isEnable);
            btnSelectVoucher.Enabled = isEnable;
            btnDeleteVoucher.Enabled = isEnable;
            btnViewDetail.Enabled = isEnable;
        }

        #endregion

        #region Property

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
            get
            {
                return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null
                           ? GlobalVariable.MainCurrencyId
                           : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString();
            }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public string VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the setup.
        /// </summary>
        /// <value>
        /// The type of the setup.
        /// </value>
        public int SetupType { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
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
            get { return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount"); }
            set { gridViewMaster.SetRowCellValue(0, "TotalAmount", value); }
        }
        /// <summary>
        /// Gets or sets the parent reference identifier.
        /// </summary>
        /// <value>
        /// The parent reference identifier.
        /// </value>
        public string ParentRefId { get; set; }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int EditVersion { get; set; }
        #endregion

        #region IViews

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
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

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
                    
                    //XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceName";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

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
                    #region DebitAccount

                    _gridLookUpEditDebitAccountView = new GridView();
                    _gridLookUpEditDebitAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAccount.View.BestFitColumns();
                    _gridLookUpEditDebitAccount.KeyDown += _gridLookUpEditDebitAccountView_KeyDown;

                    var debitAccount = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    _gridLookUpEditDebitAccount.DataSource = debitAccount;
                    _gridLookUpEditDebitAccountView.PopulateColumns(debitAccount);

                    #endregion

                    #region CreditAccount

                    _gridLookUpEditCreditAccountView = new GridView();
                    _gridLookUpEditCreditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCreditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCreditAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditCreditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCreditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCreditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditCreditAccount.View.BestFitColumns();
                    _gridLookUpEditCreditAccount.KeyDown += _gridLookUpEditCreditAccountView_KeyDown;

                    var creditAccount = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    _gridLookUpEditCreditAccount.DataSource = creditAccount;
                    _gridLookUpEditCreditAccountView.PopulateColumns(creditAccount);

                    #endregion

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Số tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountCategoryKind",
                        ColumnVisible = false,
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSource",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetChapter",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetKindItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSubItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByMethodDistribute",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByAccountingObject",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByInventoryItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByProjectActivity",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayOnAccountBalanceSheet",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayBalanceOnReport",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByCurrency",
                        ColumnVisible = false
                    });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Width = column.ColumnWith;

                    //        _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditCreditAccountView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Visible = false;
                    //        _gridLookUpEditCreditAccountView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //}
                    //_gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditDebitAccount.ValueMember = "AccountNumber";
                    //_gridLookUpEditCreditAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditCreditAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccount, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, creditAccount, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);

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
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();
                    _gridLookUpEditBudgetChapter.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetChapter.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetChapter.NullText = "";
                    _gridLookUpEditBudgetChapter.KeyDown += _gridLookUpEditBudgetChapterView_KeyDown;

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

                    ////foreach (var column in gridColumnsCollection)
                    ////{
                    ////    if (column.ColumnVisible)
                    ////    {
                    ////        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    ////        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                    ////            column.ColumnPosition;
                    ////        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                    ////    }
                    ////    else
                    ////        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    ////}
                    ////_gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    ////_gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
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
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();
                    _gridLookUpEditBudgetSubKindItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSubKindItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSubKindItem.NullText = "";
                    _gridLookUpEditBudgetSubKindItem.KeyDown += _gridLookUpEditBudgetSubKindItemView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                    //            column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    //_gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
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
                    BudgetItemModels = value.ToList();
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
                    };
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetItem.View.BestFitColumns();
                    _gridLookUpEditBudgetItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetItem.NullText = "";
                    _gridLookUpEditBudgetItem.KeyDown += _gridLookUpEditBudgetItemView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";

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
                    _gridLookUpEditBudgetSubItem.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSubItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSubItem.NullText = "";
                    _gridLookUpEditBudgetSubItem.KeyDown += _gridLookUpEditBudgetSubItemView_KeyDown;

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

                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
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
                    };
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCashWithdrawType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);

                    _gridLookUpEditCashWithdrawType.View.BestFitColumns();
                    _gridLookUpEditCashWithdrawType.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditCashWithdrawType.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditCashWithdrawType.NullText = "";
                    _gridLookUpEditCashWithdrawType.KeyDown += _gridLookUpEditCashWithdrawTypeView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Caption =
                    //            column.ColumnCaption;
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditCashWithdrawTypeView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditCashWithdrawType.DisplayMember = "CashWithdrawTypeName";
                    //_gridLookUpEditCashWithdrawType.ValueMember = "CashWithdrawTypeId";

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
        /// <value>The banks.</value>
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
                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

               // XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);

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
                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                    AllowNullInput = DefaultBoolean.True
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(268, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.KeyDown += _gridLookUpEditAccountingObjectView_KeyDown;

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                var columnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                            {
                                ColumnName = "AccountingObjectCode",
                                ColumnCaption = "Mã Đối tượng",
                                ColumnVisible = true,
                                ColumnWith = 120,
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
                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                //            column.ColumnPosition;
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else
                //    {
                //        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                //    }
                //}
                //_gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                //_gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);


                #region Lookup edit accounting objects

                _gridLookUpEditCreditAccountingObjectView = new GridView();
                _gridLookUpEditCreditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditCreditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditCreditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditCreditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditCreditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditCreditAccountingObject.PopupFormSize = new Size(368, 150);

                _gridLookUpEditCreditAccountingObject.View.BestFitColumns();
                _gridLookUpEditCreditAccountingObject.TextEditStyle = TextEditStyles.Standard;
                _gridLookUpEditCreditAccountingObject.AllowNullInput = DefaultBoolean.True;
                _gridLookUpEditCreditAccountingObject.NullText = "";
                _gridLookUpEditCreditAccountingObject.KeyDown += _gridLookUpEditCreditAccountingObjectView_KeyDown;

                _gridLookUpEditCreditAccountingObject.DataSource = value;
                _gridLookUpEditCreditAccountingObjectView.PopulateColumns(value);

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        _gridLookUpEditCreditAccountingObjectView.Columns[column.ColumnName].Caption =
                //            column.ColumnCaption;
                //        _gridLookUpEditCreditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                //            column.ColumnPosition;
                //        _gridLookUpEditCreditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else
                //        _gridLookUpEditCreditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                //}
                //_gridLookUpEditCreditAccountingObject.DisplayMember = "AccountingObjectCode";
                //_gridLookUpEditCreditAccountingObject.ValueMember = "AccountingObjectId";

                _gridLookUpEditCreditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditCreditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditCreditAccountingObjectView);


                #endregion
            }
        }

        #endregion

        #region Activities

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
                    };
                    _gridLookUpEditActivity.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditActivity.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditActivity.PopupFormSize = new Size(380, 150);

                    _gridLookUpEditActivity.View.BestFitColumns();
                    _gridLookUpEditActivity.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditActivity.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditActivity.NullText = "";
                    _gridLookUpEditActivity.KeyDown += _gridLookUpEditActivityView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditActivityView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditActivityView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditActivityView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditActivityView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditActivity.DisplayMember = "ActivityName";
                    //_gridLookUpEditActivity.ValueMember = "ActivityId";

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
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();
                    _gridLookUpEditProject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditProject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditProject.NullText = "";
                    _gridLookUpEditProject.KeyDown += _gridLookUpEditProjectView_KeyDown;

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

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";

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
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();
                    _gridLookUpEditFundStructure.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditFundStructure.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditFundStructure.NullText = "";
                    _gridLookUpEditFundStructure.KeyDown += _gridLookUpEditFundStructureView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    //_gridLookUpEditFundStructure.ValueMember = "FundStructureId";

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
        /// Sets the purchase purposes.
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
                    _gridLookUpEditPurchasePurpose.TextEditStyle = TextEditStyles.Standard;
                    //_gridLookUpEditPurchasePurpose.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditPurchasePurpose.NullText = "";
                    _gridLookUpEditPurchasePurpose.KeyDown += _gridLookUpEditPurchasePurposeView_KeyDown;

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditPurchasePurposeView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditPurchasePurpose.DisplayMember = "PurchasePurposeName";
                    //_gridLookUpEditPurchasePurpose.ValueMember = "PurchasePurposeId";

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

        #region InvoiceTypies
        /// <summary>
        /// Sets the invoice form number categories.
        /// </summary>
        /// <value>
        /// The invoice form number categories.
        /// </value>
        public IList<InvoiceTypeModel> InvoiceTypies
        {
            set
            {
                try
                {
                    _gridLookUpEditInvoiceTypeView = new GridView();
                    _gridLookUpEditInvoiceTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInvoiceType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInvoiceTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True
                    };
                    _gridLookUpEditInvoiceType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInvoiceType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInvoiceType.PopupFormSize = new Size(410, 150);
                    _gridLookUpEditInvoiceType.View.BestFitColumns();
                    _gridLookUpEditInvoiceType.KeyDown += _gridLookUpEditInvoiceTypeView_KeyDown;

                    _gridLookUpEditInvoiceType.DataSource = value;
                    _gridLookUpEditInvoiceTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InvoiceTypeId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InvoiceTypeCode",
                        ColumnCaption = "Mã loại",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InvoiceTypeName",
                        ColumnCaption = "Tên loại",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 300
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditInvoiceTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditInvoiceTypeView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditInvoiceTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditInvoiceTypeView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //}
                    //_gridLookUpEditInvoiceType.DisplayMember = "InvoiceTypeCode";
                    //_gridLookUpEditInvoiceType.ValueMember = "InvoiceTypeId";

                    //_gridLookUpEditInvoiceTypeView = XtraColumnCollectionHelper<InvoiceTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInvoiceType = XtraColumnCollectionHelper<InvoiceFormNumberModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceTypeView, value, "InvoiceTypeCode", "InvoiceTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InvoiceTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInvoiceTypeView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region GlVoucherListDetails
        public IList<GLVoucherListDetailModel> GlVoucherListDetails
        {
            get
            {
                var glVoucherListDetails = new List<GLVoucherListDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountOC = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (GLVoucherListDetailModel)grdAccountingView.GetRow(i);
                        
                        if (rowVoucher != null)
                        {
                            rowVoucher.SortOrder = i;
                            totalAmount += rowVoucher.Amount;// item.Amount;
                            glVoucherListDetails.Add(rowVoucher);// (item);
                        }
                        TotalAmount = totalAmount;
                    }
                }

                if (glVoucherListDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (GLVoucherListDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {

                            }
                        }
                    }
                }

                return glVoucherListDetails;
            }

            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<GLVoucherListDetailModel>();
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);

                if (listDetail != null)
                {
                    bindingSourceDetail.DataSource = listDetail ?? new List<GLVoucherListDetailModel>();
                    grdAccountingView.PopulateColumns(listDetail);
                    grdAccountingDetailView.PopulateColumns(listDetail);
                }
                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefNoTotal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailRefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDateTotal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    new XtraColumn {ColumnName = "DetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EntryType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailRefType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefNoCount", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "RefNo",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số CT",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                      new XtraColumn
                    {
                        ColumnName = "RefDate",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Ngày lập",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },
                         new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 3,
                        AllowEdit = true,
                    },
                       new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 4,
                        AllowEdit = true,
                    },
                       new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Loại tiền",
                        ColumnPosition = 5,
                        AllowEdit = true,
                    },
                       new XtraColumn
                    {
                        ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnVisible = true,
                        ColumnWith = 70,
                        ColumnPosition = 6,
                        IsNumeric = true,
                        AllowEdit = true,
                    },
                        new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                         new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },

                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView, grdAccounting);
                XtraColumnCollectionHelper<GLVoucherListDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;

                #endregion
            }
        }

        #endregion

        #endregion

        #region Xem chi tiết chứng từ
        /// <summary>
        /// Xem chi tiết chứng từ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            var item = (GLVoucherListDetailModel)grdAccountingView.GetFocusedRow();
            if (item == null)
                return;
            ShowFormDetail(item);
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        /// <param name="item">The item.</param>
        void ShowFormDetail(GLVoucherListDetailModel item)
        {
            FrmBaseVoucherList frmList = new FrmBaseVoucherList();
            try
            {
                FrmXtraBaseVoucherDetail frmDetail = null;

                switch (item.DetailRefType)
                {
                    case (int)BuCA.Enum.RefType.BUPlanReceiptEarlyYear: //51
                    case (int)BuCA.Enum.RefType.BUPlanReceiptAddition: //52
                        frmDetail = new FrmBUPlanReceiptDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawCash: //54
                        frmDetail = new FrmBUPlanWithdrawCashDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawTransfer: //55
                        frmDetail = new FrmBUPlanWithDrawTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUTransfer: //56
                        frmDetail = new FrmBUTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUVoucherList: //63
                        frmDetail = new FrmBUVoucherListDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanCancel: //69
                        frmDetail = new FrmBUPlanCancelDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUBudgetReserve: //73
                        frmDetail = new FrmBUBudgetReserveDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceipt: //101
                        frmDetail = new FrmCAReceiptDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceiptEstimate: //105
                        frmDetail = new FrmCAReceiptEstimateDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAPayment: //106
                        frmDetail = new FrmCAPaymentDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAPaymentTreasury: //113
                        frmDetail = new FrmCAPaymentTreasuryDetail();
                        break;

                    case (int)BuCA.Enum.RefType.CAReceiptTreasury: //114
                        frmDetail = new FrmCAReceiptTreasuryDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BADeposit: //153
                        frmDetail = new FrmBADepositDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BAWithDraw: //157
                        frmDetail = new FrmBAWithDrawDetail();
                        break;

                    case (int)BuCA.Enum.RefType.INInward: //201
                        frmDetail = new FrmINInwardDetail();
                        break;

                    case (int)BuCA.Enum.RefType.INOutward: //202
                        frmDetail = new FrmINOutwardDetail();
                        break;

                    case (int)BuCA.Enum.RefType.SUTransfer: //207
                        frmDetail = new FrmSUTransferDetail();
                        break;

                    case (int)BuCA.Enum.RefType.FADecrement: //253
                        frmDetail = new FrmFADecrementDetail();
                        break;

                    case (int)BuCA.Enum.RefType.FADepreciation: //255
                        frmDetail = new FrmFADepreciationDetail();
                        break;

                    case (int)BuCA.Enum.RefType.GLVoucher: //401
                        frmDetail = new FrmGLVoucherDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUTransferDeposits: //561
                        frmDetail = new FrmBUTransferDepositDetail();
                        break;

                    case (int)BuCA.Enum.RefType.BUPlanWithDrawDeposit: //562
                        frmDetail = new FrmBUPlanWithDrawDepositDetail();
                        break;
                    case (int)BuCA.Enum.RefType.GLVoucherPerformanceResults: //404 : Xác định kết quả hoạt động
                        frmDetail = new FrmGLVouchersPerformanceResultsDetail();
                        break;
                    case (int)BuCA.Enum.RefType.GLVoucherLastYear: //402 : Chi phí ĐTXDCB chờ quyết toán
                        frmDetail = new FrmGLVoucherLastYearDetail();
                        break;
                    case (int)BuCA.Enum.RefType.GLVoucherEarlyYear: //403 : Quyết toán dự án hoàn thành
                        frmDetail = new FrmGLVouchersEarlyYearDetail();
                        break;
                }
                if (frmDetail == null)
                    return;
                frmDetail.ActionMode = ActionModeVoucherEnum.None;
                frmDetail.KeyValue = item.DetailRefId;
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

