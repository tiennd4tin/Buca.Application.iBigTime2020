/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 01, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.FixedAsset.FixedAssetArmortization;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
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
using DevExpress.XtraEditors.Mask;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset
{
    /// <summary>
    /// FrmFADepreciationDetail
    /// </summary>
    public partial class FrmFADepreciationDetail : FrmXtraBaseVoucherDetail, IFADepreciationView, IFADepreciationsView, IFixedAssetsView, IAccountsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IActivitysView, IProjectsView, IFundStructuresView, IAccountingObjectsView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {
        #region Presenter
        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly FADepreciationPresenter _faDepreciationPresenter;
        private readonly FADepreciationsPresenter _faDepreciationsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private List<BudgetItemModel> _budgetItems;
        private List<BudgetItemModel> _budgetSubItems;
        private readonly IModel _model;
        private List<BudgetItemModel> _budgetItemModels;
        private List<AccountModel> _accountModels;
        #endregion

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

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

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemLookUpEdit _repositoryDescreiption;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;

        private GridView _gridLookUpEditFixedAssetView;

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="grid">The grid.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var totalColumnWidth = 0;
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
                    totalColumnWidth += column.ColumnWith;
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                    if (column.IsLastColumn)
                    {
                        if (grid.Width - totalColumnWidth <= column.ColumnWith)
                            grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        else
                            grdView.Columns[column.ColumnName].Width = grid.Width - totalColumnWidth + column.ColumnWith;
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


            var description = typeof(Description).ToList();
            _repositoryDescreiption = new RepositoryItemLookUpEdit
            {
                DataSource = description,
                AllowNullInput = DefaultBoolean.False,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryDescreiption.PopulateColumns();
            _repositoryDescreiption.Columns["Key"].Visible = false;
        }

        #endregion

        #region overrides

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFADepreciationDetail"/> class.
        /// </summary>
        public FrmFADepreciationDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _faDepreciationPresenter = new FADepreciationPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _faDepreciationsPresenter = new FADepreciationsPresenter(this);
            _model = new Model.Model();
           

        }



        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            tabMain.SelectedTabPage = tabInventoryItem;
            //Tintv ẩn tab Thốn kế và thuế
            tabMain.TabPages[2].PageVisible = false;

            tabMain.TabPages[3].PageVisible = false;
            dtPostDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            dtRefDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            dtPostDate.Properties.ReadOnly = true;
            dtRefDate.Properties.ReadOnly = true;
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetExpensesPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _fixedAssetsPresenter.DisplayByActive(true);
            InitRepositoryControlData();

            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fromDate = new DateTime(basePostedDate.Year, 01, 01);
            DateTime toDate = new DateTime(basePostedDate.Year, 12, 31);
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((FADepreciationModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((FADepreciationModel)MasterBindingSource.Current).RefId;
            }
     
            if (ActionMode != ActionModeVoucherEnum.AddNew)
            {

                _faDepreciationPresenter.Display(KeyValue, true);
            }
            else
            {
                ////Check chỉ cho một chứng từ trong năm
                //var faDepreciations =
                //    _faDepreciationsPresenter.GetFADepreciationsInYear((int)BuCA.Enum.RefType.FADepreciation, toDate);
                //if (faDepreciations.Count > 0)
                //{
                //    XtraMessageBox.Show("Chứng từ hao mòn năm nay đã tồn tại",
                //                        "Thông báo", MessageBoxButtons.OK,
                //                        MessageBoxIcon.Error);
                //    Close();
                //    return;
                //}
                _faDepreciationPresenter.Display(KeyValue, fromDate, toDate);
            }


            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.FADecrement;
        }

        protected override void ReloadParallelGrid()
        {
            _faDepreciationPresenter.Display(KeyValue, true);
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
            var faDepreciationDetails = FADepreciationDetails;
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (faDepreciationDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //foreach (var faDepreciationDetail in FADepreciationDetails)
            //{
            //    if (faDepreciationDetail.FixedAssetId == null)
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetIdRequired"),
            //                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //                            MessageBoxIcon.Error);
            //        return false;
            //    }
            //    //if(faDepreciationDetail.IsParallel == null || faDepreciationDetail.IsParallel == false)
            //    //{
            //    //    if (faDepreciationDetail.DebitAccount == null)
            //    //    {
            //    //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccountRequired"),
            //    //                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //    //                            MessageBoxIcon.Error);
            //    //        return false;
            //    //    }

            //    //    if (faDepreciationDetail.CreditAccount == null)
            //    //    {
            //    //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"),
            //    //                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //    //                            MessageBoxIcon.Error);
            //    //        return false;
            //    //    }
            //    //}


            //    #region Check detail by DebitAccount

            //    //if (faDepreciationDetail.DebitAccount != null)
            //    //{
            //    //    var debitAccount = _accountModels.FirstOrDefault(c => c.AccountNumber == faDepreciationDetail.DebitAccount);
            //    //    if (debitAccount == null)
            //    //        return false;
            //    //    var isError = debitAccount.ValidDetailBy(faDepreciationDetail.BudgetSourceId, faDepreciationDetail.BudgetChapterCode, faDepreciationDetail.BudgetSubKindItemCode,
            //    //        "pass", "pass", faDepreciationDetail.MethodDistributeId,
            //    //        faDepreciationDetail.AccountingObjectId, faDepreciationDetail.ActivityId, faDepreciationDetail.ProjectId, null, null, faDepreciationDetail.FixedAssetId);
            //    //    if (!isError)
            //    //        return false;
            //    //}
            //    //#endregion

            //    //# region Check detail by CreditAccount

            //    //if (faDepreciationDetail.CreditAccount != null)
            //    //{
            //    //    var creditAccount = _accountModels.FirstOrDefault(c => c.AccountNumber == faDepreciationDetail.CreditAccount);
            //    //    var isError = creditAccount.ValidDetailBy(faDepreciationDetail.BudgetSourceId, faDepreciationDetail.BudgetChapterCode, faDepreciationDetail.BudgetSubKindItemCode,
            //    //        "pass","pass", faDepreciationDetail.MethodDistributeId,
            //    //        faDepreciationDetail.AccountingObjectId, faDepreciationDetail.ActivityId, faDepreciationDetail.ProjectId, null, null, faDepreciationDetail.FixedAssetId);
            //    //    if (!isError)
            //    //        return false;
            //    //}
            //    #endregion

            //}
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
        public bool Result { get; set; }
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
            //var result = new DialogResult();
            //result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
            //   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //// generate parallel
            //Result = result == DialogResult.OK;
            return _faDepreciationPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new FADepreciationPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// Initializes the reference information.
        /// </summary>
        protected override void InitRefInfo()
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew)
            {
                dtRefDate.EditValue = new DateTime(DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year, 12, 31);
                dtPostDate.EditValue = new DateTime(DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year, 12, 31);
            }
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                string textError = "";
                IModel model = new Model.Model();

                
                if (e.Column.FieldName == "BudgetSubItemCode" && e.Value != null)
                {
                    if (string.IsNullOrEmpty(e.Value.ToString()))
                        return;
                    var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var _budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override void DeleteRowItem()
        {
            if (tabMain.SelectedTabPage.Equals(tabAccounting))
            {
                grdAccountingView.DeleteSelectedRows();
                //CalculateGridMasterAfterDeletedRow();
            }
            else if (tabMain.SelectedTabPage.Equals(tabInventoryItem))
                grdDetailByInventoryItemView.DeleteSelectedRows();
            else if (tabMain.SelectedTabPage.Equals(tabTax))
                grdTaxView.DeleteSelectedRows();

            DeleteRowItemInBandedGridView();
        }

        #endregion

        #region IView

        #region BudgetSources

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    value = new List<BudgetSourceModel>();

                _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceCode), ColumnCaption = "Mã nguồn", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetSourceModel.BudgetSourceName), ColumnCaption = "Tên nguồn", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, nameof(BudgetSourceModel.BudgetSourceCode), nameof(BudgetSourceModel.BudgetSourceId), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
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
                    AccountLists = value;
                    _accountModels = value.ToList();
                    var debitAccounts = value.ToList();
                    var creditAccounts = value.ToList();
                    //   var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    //  var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);

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
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                if (value == null)
                    value = new List<BudgetChapterModel>();

                _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetChapterModel.BudgetChapterCode), ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetChapterModel.BudgetChapterName), ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, nameof(BudgetChapterModel.BudgetChapterCode), nameof(BudgetChapterModel.BudgetChapterCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
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
                if (value == null)
                    value = new List<BudgetKindItemModel>();

                _budgetKindItemModels = value.Where(v => v.IsParent).ToList();
                _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();
                value = value.Where(v => !v.IsParent).ToList();

                _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemCode), ColumnCaption = "Mã khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemName), ColumnCaption = "Tên khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, nameof(BudgetKindItemModel.BudgetKindItemCode), nameof(BudgetKindItemModel.BudgetKindItemCode), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
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
                    _budgetItems = value.Where(v => v.BudgetItemType == 2).ToList();
                    _budgetSubItems = value.Where(v => v.BudgetItemType == 3).ToList();

                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

                    // Tiểu mục
                    _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemCode), ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemName), ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, nameof(BudgetItemModel.BudgetItemCode), nameof(BudgetItemModel.BudgetItemCode), gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                    // Mục
                    _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();

                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemCode), ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetItemModel.BudgetItemName), ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, nameof(BudgetItemModel.BudgetItemCode), nameof(BudgetItemModel.BudgetItemCode), gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
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
        /// <value>The cash withdraw type models.</value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                if (value == null)
                    value = new List<CashWithdrawTypeModel>();

                _gridLookUpEditCashWithdrawTypeView = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridViewReponsitory();
                //_gridLookUpEditCashWithdrawType.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(CashWithdrawTypeModel.CashWithdrawTypeName), ColumnCaption = "Nghiệp vụ", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 1 });

                _gridLookUpEditCashWithdrawType = XtraColumnCollectionHelper<CashWithdrawTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCashWithdrawTypeView, value, nameof(CashWithdrawTypeModel.CashWithdrawTypeName), nameof(CashWithdrawTypeModel.CashWithdrawTypeId), gridColumnsCollection);
                XtraColumnCollectionHelper<CashWithdrawTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCashWithdrawTypeView);
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

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankAccount), ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BankModel.BankName), ColumnCaption = "Tên NH, KB", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, nameof(BankModel.BankAccount), nameof(BankModel.BankId), gridColumnsCollection);
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
                try
                {
                    _gridLookUpEditAccountingObjectView = new GridView();
                    _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountingObjectView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccountingObject.View.BestFitColumns();
                    _gridLookUpEditAccountingObject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditAccountingObject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditAccountingObject.NullText = "";
                    _gridLookUpEditAccountingObject.KeyDown += _gridLookUpEditAccountingObjectView_KeyDown;

                    _gridLookUpEditAccountingObject.DataSource = value;
                    _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IdentificationNumber",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FamilyDeductionAmount",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "NumberFamilyDependent",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPayInsuranceOnSalary",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsUnEmploymentInsurance",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPaidInsuranceForPayrollItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "OrganizationManageFee",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                    _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                    //Filter cho gridview
                    _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (value == null)
                    value = new List<ActivityModel>();

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                //_gridLookUpEditActivity.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ActivityModel.ActivityName), ColumnCaption = "Công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, nameof(ActivityModel.ActivityName), nameof(ActivityModel.ActivityId), gridColumnsCollection);
                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
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
                if (value == null)
                    value = new List<ProjectModel>();

                _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ProjectModel.ProjectCode), ColumnCaption = "Mã CTMT", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ProjectModel.ProjectName), ColumnCaption = "Tên CTMT", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, nameof(ProjectModel.ProjectName), nameof(ProjectModel.ProjectId), gridColumnsCollection);
                XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
            }
        }
        #endregion

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                if (value == null)
                    value = new List<BudgetExpenseModel>();

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseCode), ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseName), ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, nameof(BudgetExpenseModel.BudgetExpenseName), nameof(BudgetExpenseModel.BudgetExpenseId), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
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
                if (value == null)
                    value = new List<FundStructureModel>();

                _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureCode), ColumnCaption = "Mã khoản chi", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureName), ColumnCaption = "Tên khoản chi", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditFundStructure = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, nameof(FundStructureModel.FundStructureCode), nameof(FundStructureModel.FundStructureId), gridColumnsCollection);
                XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
            }
        }

        #endregion

        #region FixedAssets
        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                if (value == null)
                    return;
                _listFixedAsset = value.ToList();

                _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetCode), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetName), ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, nameof(FixedAssetModel.FixedAssetCode), nameof(FixedAssetModel.FixedAssetId), gridColumnsCollection);
                XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
            }
        }
        #endregion
        public IList<FixedAssetModel> _listFixedAsset { get; set; }

        #region Contract

        /// <summary>
        /// Contract
        /// </summary>
        public IList<ContractModel> Contracts
        {
            set
            {

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


        public IList<FADepreciationModel> FADepreciations { get; set; }

        #endregion

        #region Control Events

        #region Keydown

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
            var budgetSourceCode = grdAccountingView.Columns["BudgetChapterId"];
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
            var budgetSourceCode = grdAccountingView.Columns["BudgetItemId"];
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
            var budgetSourceCode = grdAccountingView.Columns["BudgetItemId"];
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
            var budgetSourceCode = grdAccountingView.Columns["BudgetKindItemId"];
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
            var budgetSourceCode = grdAccountingView.Columns["CashWithdrawTypeId"];
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
            var budgetSourceCode = grdAccountingView.Columns["AccountingObjectId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        #endregion
        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            grdDetailByInventoryItemView_CellValueChanged(sender, e);
        }
        /// <summary>
        /// Handles the CellValueChanged event of the grdDetailByInventoryItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdDetailByInventoryItemView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "FixedAssetId")
                {
                    GridColumn fixedAssetName = grdDetailByInventoryItemView.Columns["FixedAssetName"];
                    GridColumn annualDepreciationRate = grdDetailByInventoryItemView.Columns["AnnualDepreciationRate"];
                    GridColumn annualDepreciationAmount = grdDetailByInventoryItemView.Columns["AnnualDepreciationAmount"];
                    GridColumn description = grdDetailByInventoryItemView.Columns["Description"];
                    GridColumn debitAccount = grdDetailByInventoryItemView.Columns["DebitAccount"];
                    GridColumn creditAccount = grdDetailByInventoryItemView.Columns["CreditAccount"];
                    GridColumn amount = grdDetailByInventoryItemView.Columns["Amount"];

                    GridColumn budgetSourceIdmount = grdDetailByInventoryItemView.Columns["BudgetSourceId"];
                    GridColumn budgetChapterCode = grdDetailByInventoryItemView.Columns["BudgetChapterCode"];
                    GridColumn budgetKindItemCode = grdDetailByInventoryItemView.Columns["BudgetKindItemCode"];
                    GridColumn budgetSubKindItemCode = grdDetailByInventoryItemView.Columns["BudgetSubKindItemCode"];
                    GridColumn methodDistributeId = grdDetailByInventoryItemView.Columns["MethodDistributeId"];
                    GridColumn cashWithDrawTypeId = grdDetailByInventoryItemView.Columns["CashWithDrawTypeId"];

                    if (e.Value != null)
                    {
                        var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                        if (fixedAsset != null)
                        {
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, fixedAssetName, fixedAsset.FixedAssetName);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, annualDepreciationRate, fixedAsset.DepreciationRate);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, annualDepreciationAmount, fixedAsset.PeriodDepreciationAmount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, description, "Hao mòn tài sản cố định" + fixedAsset.FixedAssetName);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, debitAccount, fixedAsset.DebitDepreciationAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, creditAccount, fixedAsset.CreditDepreciationAccount);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, amount, fixedAsset.PeriodDepreciationAmount);

                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, budgetSourceIdmount, GlobalVariable.DefaultBudgetSourceID);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, budgetChapterCode, string.IsNullOrEmpty(fixedAsset.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : fixedAsset.BudgetChapterCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, budgetKindItemCode, string.IsNullOrEmpty(fixedAsset.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : fixedAsset.BudgetKindItemCode);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, budgetSubKindItemCode, string.IsNullOrEmpty(fixedAsset.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : fixedAsset.BudgetSubKindItemCode);
                            //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, methodDistributeId, GlobalVariable.DefaultMethodDistributeID);
                            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, cashWithDrawTypeId, GlobalVariable.DefaultCashWithDrawTypeID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "FixedAssetId")
                {
                    GridColumn fixedAssetName = grdAccountingView.Columns["FixedAssetName"];
                    if (e.Value != null)
                    {
                        var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                        if (fixedAsset != null)
                        {
                            grdAccountingView.SetRowCellValue(e.RowHandle, fixedAssetName, fixedAsset.FixedAssetName);
                        }
                    }
                }
                if (e.Column.FieldName == "BudgetSubItemCode")
                {
                    var budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                    if (budgetSubItemCode != null)
                    {
                        var budgetSubItemModel = _budgetSubItems.FirstOrDefault(x => x.BudgetItemCode == budgetSubItemCode);
                        if (budgetSubItemModel != null)
                        {
                            var budgetItemModel = _budgetItems.FirstOrDefault(x => x.BudgetItemId == budgetSubItemModel.ParentId);
                            var budgetItemCode = budgetItemModel == null ? "" : budgetItemModel.BudgetItemCode;
                            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void grdAccountingDetailView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "FixedAssetId")
                {
                    GridColumn fixedAssetName = grdAccountingDetailView.Columns["FixedAssetName"];
                    if (e.Value != null)
                    {
                        var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                        if (fixedAsset != null)
                        {
                            grdAccountingDetailView.SetRowCellValue(e.RowHandle, fixedAssetName, fixedAsset.FixedAssetName);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        #region IFADepreciationView

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
        /// Gets or sets the paralell reference no.
        /// </summary>
        /// <value>
        /// The paralell reference no.
        /// </value>
        public string ParalellRefNo { get; set; }

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
                return FADepreciationDetails.Sum(x => x.Amount);

            }
            set { }
        }

        public int PeriodType { get; set; }
        public string PeriodTypeName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
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
        /// Gets or sets the fa depreciation details.
        /// </summary>
        /// <value>
        /// The fa depreciation details.
        /// </value>
        public IList<FADepreciationDetailModel> FADepreciationDetails
        {
            get
            {
                var faDepreciationDetails = new List<FADepreciationDetailModel>();
                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                    {
                        var rowVoucher = (FADepreciationDetailModel)grdDetailByInventoryItemView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new FADepreciationDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                FixedAssetId = rowVoucher.FixedAssetId,
                                FixedAssetName = rowVoucher.FixedAssetName == null ? null : rowVoucher.FixedAssetName.Trim(),
                                AnnualDepreciationRate = rowVoucher.AnnualDepreciationRate,
                                AnnualDepreciationAmount = rowVoucher.AnnualDepreciationAmount,
                                SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                IsParallel = rowVoucher.IsParallel,
                            };
                            faDepreciationDetails.Add(item);
                            //if (Result)
                            //{
                            //    var fixedAsset = _listFixedAsset.FirstOrDefault(f => f.FixedAssetId == rowVoucher.FixedAssetId);
                            //    if (fixedAsset != null && fixedAsset.DevaluationDebitAccount != null && fixedAsset.DevaluationCreditAccount != null)
                            //    {
                            //        var parallel = new FADepreciationDetailModel()
                            //        {
                            //            IsParallel = true,
                            //            Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                            //            DebitAccount = fixedAsset.DevaluationDebitAccount,
                            //            CreditAccount = fixedAsset.DevaluationCreditAccount,
                            //            Amount = rowVoucher.Amount,
                            //            FixedAssetId = rowVoucher.FixedAssetId,
                            //            FixedAssetName = rowVoucher.FixedAssetName == null ? null : rowVoucher.FixedAssetName.Trim(),
                            //            AnnualDepreciationRate = rowVoucher.AnnualDepreciationRate,
                            //            AnnualDepreciationAmount = rowVoucher.AnnualDepreciationAmount,
                            //            SortOrder = i,
                            //            AccountingObjectId = rowVoucher.AccountingObjectId,
                            //            ProjectId = rowVoucher.ProjectId,
                            //            ContractId = rowVoucher.ContractId,
                            //            CapitalPlanId = rowVoucher.CapitalPlanId,
                            //        };
                            //        faDepreciationDetails.Add(parallel);
                            //    }
                            //}
                            

                            //TotalAmount += item.Amount;
                        }
                    }
                }
                if (!Result && grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {

                    for (var i = 0; i < grdViewAccountingParallel.RowCount; i++)
                    {
                        var rowVoucher = (FADepreciationDetailModel)grdViewAccountingParallel.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new FADepreciationDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                FixedAssetId = rowVoucher.FixedAssetId,
                                FixedAssetName = rowVoucher.FixedAssetName == null ? null : rowVoucher.FixedAssetName.Trim(),
                                AnnualDepreciationRate = rowVoucher.AnnualDepreciationRate,
                                AnnualDepreciationAmount = rowVoucher.AnnualDepreciationAmount,
                                SortOrder = i,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                IsParallel = true,
                            };
                            faDepreciationDetails.Add(item);
                        }
                    }
                }
                if (faDepreciationDetails.Count > 0)
                {
                    if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingView.RowCount; i++)
                        {
                            var rowVoucher = (FADepreciationDetailModel)grdAccountingView.GetRow(i);
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

                                faDepreciationDetails[i].BudgetSourceId = rowVoucher.BudgetSourceId;
                                faDepreciationDetails[i].BudgetChapterCode = rowVoucher.BudgetChapterCode;
                                faDepreciationDetails[i].BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode;
                                faDepreciationDetails[i].BudgetKindItemCode = budgetKindItemCode;
                                faDepreciationDetails[i].BudgetItemCode = rowVoucher.BudgetItemCode;
                                faDepreciationDetails[i].BudgetSubItemCode = rowVoucher.BudgetSubItemCode;
                                faDepreciationDetails[i].CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId;
                                faDepreciationDetails[i].MethodDistributeId = rowVoucher.MethodDistributeId;
                                faDepreciationDetails[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                                faDepreciationDetails[i].ContractId = rowVoucher.ContractId;
                                faDepreciationDetails[i].SortOrder = i;
                            }
                        }
                    }
                }

                if (faDepreciationDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (FADepreciationDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                faDepreciationDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                faDepreciationDetails[i].ActivityId = rowVoucher.ActivityId;
                                faDepreciationDetails[i].ProjectId = rowVoucher.ProjectId;
                                faDepreciationDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                faDepreciationDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                                faDepreciationDetails[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                                faDepreciationDetails[i].ContractId = rowVoucher.ContractId;
                                faDepreciationDetails[i].SortOrder = i;
                            }
                        }
                    }
                }

                return faDepreciationDetails;
            }

            set
            {
                var data = new List<FADepreciationDetailModel>();
                var fixedAssets = value.ToList();

                foreach (var fixedAsset in fixedAssets)
                {
                    var fixedAssetFirst = _listFixedAsset.FirstOrDefault(f => f.FixedAssetId == fixedAsset.FixedAssetId);
                    var item = new FADepreciationDetailModel
                    {
                        RefDetailId = fixedAsset.RefDetailId,
                        RefId = fixedAsset.RefId,
                        FixedAssetId = fixedAsset.FixedAssetId,
                        FixedAssetName = fixedAsset.FixedAssetName,
                        FixedAssetCode = fixedAssetFirst.FixedAssetCode,
                        OrgPrice = fixedAsset.OrgPrice,
                        AnnualDepreciationRate = fixedAsset.AnnualDepreciationRate,
                        AnnualDepreciationAmount = fixedAsset.AnnualDepreciationAmount,
                        Description = fixedAsset.Description,
                        DebitAccount = fixedAsset.DebitAccount,
                        CreditAccount = fixedAsset.CreditAccount,
                        Amount = fixedAsset.Amount,
                        BudgetSourceId = string.IsNullOrEmpty(fixedAsset.BudgetSourceId) ? GlobalVariable.DefaultBudgetSourceID : fixedAsset.BudgetSourceId,
                        BudgetChapterCode = string.IsNullOrEmpty(fixedAsset.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : fixedAsset.BudgetChapterCode,
                        //MethodDistributeId = fixedAsset.MethodDistributeId ?? GlobalVariable.DefaultMethodDistributeID,
                        CashWithDrawTypeId = fixedAsset.CashWithDrawTypeId ?? GlobalVariable.DefaultCashWithDrawTypeID,
                        AccountingObjectId = fixedAsset.AccountingObjectId,
                        ActivityId = fixedAsset.ActivityId,
                        ProjectId = fixedAsset.ProjectId,
                        ProjectActivityId = fixedAsset.ProjectActivityId,
                        ProjectExpenseId = fixedAsset.ProjectExpenseId,
                        TaskId = fixedAsset.TaskId,
                        FundStructureId = fixedAsset.FundStructureId,
                        ProjectExpenseEAId = fixedAsset.ProjectExpenseEAId,
                        ProjectActivityEAId = fixedAsset.ProjectActivityEAId,
                        BudgetProvideCode = fixedAsset.BudgetProvideCode,
                        TopicId = fixedAsset.TopicId,
                        DepartmentId = fixedAsset.DepartmentId,
                        DevaluationAmount = fixedAsset.DevaluationAmount,
                        BudgetKindItemCode = string.IsNullOrEmpty(fixedAsset.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : fixedAsset.BudgetKindItemCode,
                        BudgetSubKindItemCode = string.IsNullOrEmpty(fixedAsset.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : fixedAsset.BudgetSubKindItemCode,
                        BudgetSubItemCode = fixedAsset.BudgetSubItemCode,
                        BudgetItemCode = fixedAsset.BudgetItemCode,
                        BudgetDetailItemCode = fixedAsset.BudgetDetailItemCode,
                        ListItemId = fixedAsset.ListItemId,
                        BudgetExpenseId = fixedAsset.BudgetExpenseId,
                        SortOrder = fixedAsset.SortOrder,
                        ContractId = fixedAsset.ContractId,
                        CapitalPlanId = fixedAsset.CapitalPlanId,
                        IsParallel = fixedAsset.IsParallel
                    };
                    data.Add(item);
                    if (KeyValue == null)
                    {

                        if (fixedAssetFirst != null && (fixedAssetFirst.DevaluationDebitAccount != null || fixedAssetFirst.DevaluationCreditAccount != null))
                        {
                            var parallel = new FADepreciationDetailModel()
                            {
                                RefDetailId = fixedAsset.RefDetailId,
                                RefId = fixedAsset.RefId,
                                FixedAssetId = fixedAsset.FixedAssetId,
                                FixedAssetCode = fixedAssetFirst.FixedAssetCode,
                                FixedAssetName = fixedAsset.FixedAssetName,
                                OrgPrice = fixedAsset.OrgPrice,
                                AnnualDepreciationRate = fixedAsset.AnnualDepreciationRate,
                                AnnualDepreciationAmount = fixedAsset.AnnualDepreciationAmount,
                                Description = fixedAsset.Description,
                                DebitAccount = fixedAssetFirst.DevaluationDebitAccount,
                                CreditAccount = fixedAssetFirst.DevaluationCreditAccount,
                                Amount = fixedAsset.Amount,
                                BudgetSourceId = string.IsNullOrEmpty(fixedAsset.BudgetSourceId) ? GlobalVariable.DefaultBudgetSourceID : fixedAsset.BudgetSourceId,
                                BudgetChapterCode = string.IsNullOrEmpty(fixedAsset.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : fixedAsset.BudgetChapterCode,
                                //MethodDistributeId = fixedAsset.MethodDistributeId ?? GlobalVariable.DefaultMethodDistributeID,
                                CashWithDrawTypeId = fixedAsset.CashWithDrawTypeId ?? GlobalVariable.DefaultCashWithDrawTypeID,
                                AccountingObjectId = fixedAsset.AccountingObjectId,
                                ActivityId = fixedAsset.ActivityId,
                                ProjectId = fixedAsset.ProjectId,
                                ProjectActivityId = fixedAsset.ProjectActivityId,
                                ProjectExpenseId = fixedAsset.ProjectExpenseId,
                                TaskId = fixedAsset.TaskId,
                                FundStructureId = fixedAsset.FundStructureId,
                                ProjectExpenseEAId = fixedAsset.ProjectExpenseEAId,
                                ProjectActivityEAId = fixedAsset.ProjectActivityEAId,
                                BudgetProvideCode = fixedAsset.BudgetProvideCode,
                                TopicId = fixedAsset.TopicId,
                                DepartmentId = fixedAsset.DepartmentId,
                                DevaluationAmount = fixedAsset.DevaluationAmount,
                                BudgetKindItemCode = string.IsNullOrEmpty(fixedAsset.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : fixedAsset.BudgetKindItemCode,
                                BudgetSubKindItemCode = string.IsNullOrEmpty(fixedAsset.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : fixedAsset.BudgetSubKindItemCode,
                                BudgetSubItemCode = fixedAsset.BudgetSubItemCode,
                                BudgetItemCode = fixedAsset.BudgetItemCode,
                                BudgetDetailItemCode = fixedAsset.BudgetDetailItemCode,
                                ListItemId = fixedAsset.ListItemId,
                                BudgetExpenseId = fixedAsset.BudgetExpenseId,
                                SortOrder = fixedAsset.SortOrder,
                                ContractId = fixedAsset.ContractId,
                                CapitalPlanId = fixedAsset.CapitalPlanId,
                                IsParallel = true
                            };
                            data.Add(parallel);
                        }
                    }
                }
               
                var dataNotParallel = data.OrderBy(o => o.FixedAssetCode).ThenBy(t => t.IsParallel).ToList();
                var dataParallel = data.Where(d => d.IsParallel == true).OrderBy(c => c.SortOrder).ToList() ?? new List<FADepreciationDetailModel>();
                bindingSourceDetail.DataSource = dataNotParallel;
                bindingSourceParallel.DataSource = dataParallel;
                grdViewAccountingParallel.PopulateColumns(dataParallel);
                grdAccountingView.PopulateColumns(dataNotParallel);
                grdDetailByInventoryItemView.PopulateColumns(dataNotParallel);
                grdAccountingDetailView.PopulateColumns(dataNotParallel);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                             new XtraColumn {ColumnName = "FixedAssetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Mã tài sản", ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset},
                    new XtraColumn {ColumnName = "FixedAssetName", ColumnVisible = true, ColumnWith = 250, ColumnCaption = "Tên tài sản", ColumnPosition = 2, AllowEdit = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationRate", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Tỉ lệ hao mòn", ColumnPosition = 3, AllowEdit = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false, ColumnWith = 120, ColumnCaption = "Số hao mòn năm", ColumnPosition = 4, AllowEdit = false, ColumnType = UnboundColumnType.Decimal},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = true, ColumnWith = 300, ColumnCaption = "Diễn giải", ColumnPosition = 5, AllowEdit = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Nợ", ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditDebitAccount},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Có", ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditCreditAccount},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = true, ColumnWith = 151, ColumnCaption = "Số tiền", ColumnPosition = 8, AllowEdit = true, ColumnType = UnboundColumnType.Decimal},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                       new XtraColumn {ColumnName = "IsParallel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DevaluationAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DevaluationAmount", ColumnVisible = false},
                     new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                      new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false}

                };
                grdDetailByInventoryItemView = InitGridLayout(columnsCollection, grdDetailByInventoryItemView, grdDetailByInventoryItem);
                SetNumericFormatControl(grdDetailByInventoryItemView, true);
                grdDetailByInventoryItemView.OptionsView.ShowFooter = false;

                grdViewAccountingParallel = InitGridLayout(columnsCollection, grdViewAccountingParallel, grdAccountingParallel);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;

                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                repositoryNumberCalcEdit.Mask.EditMask = @"n2";
                repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                grdDetailByInventoryItemView.Columns["AnnualDepreciationRate"].ColumnEdit = repositoryNumberCalcEdit;
                grdViewAccountingParallel.Columns["AnnualDepreciationRate"].ColumnEdit = repositoryNumberCalcEdit;
                #endregion

                #region grdDetailByItemInventory
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                           new XtraColumn {ColumnName = "FixedAssetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Mã tài sản", ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset},
                    new XtraColumn {ColumnName = "FixedAssetName", ColumnVisible = true, ColumnWith = 250, ColumnCaption = "Tên tài sản", ColumnPosition = 2, AllowEdit = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Nguồn", ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSource},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Chương", ColumnPosition = 4, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetChapter},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Khoản", ColumnPosition = 5, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubKindItem},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Mục", ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetItem},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Tiểu Mục", ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditBudgetSubItem},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = true, ColumnWith = 120, ColumnCaption = "Cấp phát", ColumnPosition = 8, AllowEdit = true, RepositoryControl = _repositoryMethodDistributeId},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = true, ColumnWith = 171, ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, AllowEdit = true, RepositoryControl = _gridLookUpEditCashWithdrawType, IsLastColumn = true},
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DevaluationAmount", ColumnVisible = false}

                };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView, grdAccounting);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion

                #region columns for grdAccountingDetailView
                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                     new XtraColumn {ColumnName = "FixedAssetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Mã tài sản", ColumnPosition = 1, AllowEdit = true, RepositoryControl = _gridLookUpEditFixedAsset},
                    new XtraColumn {ColumnName = "FixedAssetName", ColumnVisible = true, ColumnWith = 340, ColumnCaption = "Tên tài sản", ColumnPosition = 2, AllowEdit = false},
                    new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = true, ColumnWith = 180, ColumnCaption = "Đối tượng", ColumnPosition = 3, AllowEdit = true, RepositoryControl = _gridLookUpEditAccountingObject},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = true, ColumnWith = 180, ColumnCaption = "Hoạt động SN", ColumnPosition = 4, AllowEdit = true, RepositoryControl = _gridLookUpEditActivity},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = true, ColumnWith = 180, ColumnCaption = "Dự án", ColumnPosition = 5, AllowEdit = true, RepositoryControl = _gridLookUpEditProject},
                    new XtraColumn
                    {
                        ColumnName = "ContractId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 130,
                        ColumnCaption = "Hợp đồng",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 6,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = true, ColumnWith = 181, ColumnCaption = "Khoản chi", ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditFundStructure, IsLastColumn = true},
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DevaluationAmount", ColumnVisible = false}
                };
                grdAccountingDetailView = InitGridLayout(columnsCollection, grdAccountingDetailView, grdAccountingDetail);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion
            }
        }
        #endregion
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;

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
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "FixedAssetId")
                {
                    GridColumn fixedAssetName = grdViewAccountingParallel.Columns["FixedAssetName"];
                    GridColumn annualDepreciationRate = grdViewAccountingParallel.Columns["AnnualDepreciationRate"];
                    GridColumn annualDepreciationAmount = grdViewAccountingParallel.Columns["AnnualDepreciationAmount"];
                    GridColumn description = grdViewAccountingParallel.Columns["Description"];
                    GridColumn debitAccount = grdViewAccountingParallel.Columns["DebitAccount"];
                    GridColumn creditAccount = grdViewAccountingParallel.Columns["CreditAccount"];
                    GridColumn amount = grdViewAccountingParallel.Columns["Amount"];

                    GridColumn budgetSourceIdmount = grdViewAccountingParallel.Columns["BudgetSourceId"];
                    GridColumn budgetChapterCode = grdViewAccountingParallel.Columns["BudgetChapterCode"];
                    GridColumn budgetKindItemCode = grdViewAccountingParallel.Columns["BudgetKindItemCode"];
                    GridColumn budgetSubKindItemCode = grdViewAccountingParallel.Columns["BudgetSubKindItemCode"];
                    GridColumn methodDistributeId = grdViewAccountingParallel.Columns["MethodDistributeId"];
                    GridColumn cashWithDrawTypeId = grdViewAccountingParallel.Columns["CashWithDrawTypeId"];

                    if (e.Value != null)
                    {
                        var fixedAsset = (FixedAssetModel)_gridLookUpEditFixedAsset.GetRowByKeyValue(e.Value);
                        if (fixedAsset != null)
                        {
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, fixedAssetName, fixedAsset.FixedAssetName);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, annualDepreciationRate, fixedAsset.DepreciationRate);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, annualDepreciationAmount, fixedAsset.PeriodDepreciationAmount);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, description, "Hao mòn tài sản cố định" + fixedAsset.FixedAssetName);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, debitAccount, fixedAsset.DevaluationDebitAccount);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, creditAccount, fixedAsset.DevaluationCreditAccount);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, amount, fixedAsset.PeriodDepreciationAmount);

                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, budgetSourceIdmount, GlobalVariable.DefaultBudgetSourceID);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, budgetChapterCode, string.IsNullOrEmpty(fixedAsset.BudgetChapterCode) ? GlobalVariable.DefaultBudgetChapterCode : fixedAsset.BudgetChapterCode);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, budgetKindItemCode, string.IsNullOrEmpty(fixedAsset.BudgetKindItemCode) ? GlobalVariable.DefaultBudgetKindItemCode : fixedAsset.BudgetKindItemCode);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, budgetSubKindItemCode, string.IsNullOrEmpty(fixedAsset.BudgetSubKindItemCode) ? GlobalVariable.DefaultBudgetSubKindItemCode : fixedAsset.BudgetSubKindItemCode);
                            //grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, methodDistributeId, GlobalVariable.DefaultMethodDistributeID);
                            grdViewAccountingParallel.SetRowCellValue(e.RowHandle, cashWithDrawTypeId, GlobalVariable.DefaultCashWithDrawTypeID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        private void FrmFADepreciationDetail_Load(object sender, EventArgs e)
        {
        }
    }
}
