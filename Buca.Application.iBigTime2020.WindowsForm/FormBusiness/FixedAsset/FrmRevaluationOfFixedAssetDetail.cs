/***********************************************************************
 * <copyright file="FrmFADecrementDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, November 1, 2017
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
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.IncrementDecrement;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using System.Data;
using System.Globalization;
using Buca.Application.iBigTime2020.Model;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.IncrementDecrement;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement
{

    /// <summary>
    /// FrmRevaluationOfFixedAssetDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IdepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.IncrementDecrement.IFAAdjustmentView" />
    public partial class FrmRevaluationOfFixedAssetDetail : FrmXtraBaseVoucherDetail, IFixedAssetsView,
        IDepartmentsView, IAccountsView, IAccountingObjectsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView,
        IBudgetItemsView, ICashWithdrawTypesView, IActivitysView, IProjectsView, IFundStructuresView, IBanksView,
        IFAAdjustmentView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {
        /// <summary>
        /// The fixed asset ledger DAO
        /// </summary>
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        /// <summary>
        /// The fa adjustment detail fa DAO
        /// </summary>
        private static readonly IFAAdjustmentDetailFADao FAAdjustmentDetailFADao = DataAccess.DataAccess.FAAdjustmentDetailFADao;

        #region Presenter

        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;

        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        /// <summary>
        /// The f a adjustment presenter
        /// </summary>
        private readonly FAAdjustmentPresenter _fAAdjustmentPresenter;


        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;


        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;


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
        /// The fixed assets presenter
        /// </summary>
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The fixed asset models
        /// </summary>
        private List<FixedAssetModel> _fixedAssetModels;


        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;
        /// <summary>
        /// The budget item models
        /// </summary>
        private List<BudgetItemModel> _budgetItemModels;
        /// <summary>
        /// The budget sub item models
        /// </summary>
        private List<BudgetItemModel> _budgetSubItemModels;

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;
        List<AccountModel> _listAccounts;

        #endregion

        #region RepositoryItemLookUpEdit
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;

        private RepositoryItemGridLookUpEdit _gridLookUpBudgetExpense;
        private GridView _gridLookUpEditBudgetExpenseView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        /// The grId look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;

        /// <summary>
        /// The grId look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditBankView;
        /// <summary>
        /// The grId look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grId look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grId look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        /// The grId look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

        /// <summary>
        /// The repository method distribute Identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grId look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;

        /// <summary>
        /// The grId look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditFixedAssetView;

        /// <summary>
        /// The grId look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;

        /// <summary>
        /// The grId look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        /// <summary>
        /// The grId look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;

        /// <summary>
        /// The grId look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The grId look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grId look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grId look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        /// The grId look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The grId look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;

        /// <summary>
        /// The grId look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The grId look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        /// <summary>
        /// The grId look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        /// The grId look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The grId look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grId look up edit activity
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        /// <summary>
        /// The grId look up edit activity view
        /// </summary>
        private GridView _gridLookUpEditActivityView;

        /// <summary>
        /// The grId look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grId look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The repository decrease reason Identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryDecreaseReasonId;

        /// <summary>
        /// The account models
        /// </summary>
        private List<AccountModel> _accountModels;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRevaluationOfFixedAssetDetail"/> class.
        /// </summary>
        public FrmRevaluationOfFixedAssetDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _fAAdjustmentPresenter = new FAAdjustmentPresenter(this);
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
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _model = new Model.Model();
            grdViewParallel = grdViewAccountingParallel;
            
        }

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabMain.Location = new Point(8, 179);
            tabrevaluation.PageVisible = false;
            tabrevaluation.TabIndex = 0;
            tabMain.SelectedTabPage = tabrevaluation;
            grdAccounting.Visible = true;
            grdAccountingDetail.Visible = false;
            txtDescription.Properties.AutoHeight = false;
            txtDescription.Height = 46;
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>

        /// <summary>
        /// ValIds the data.
        /// </summary>
        /// <returns></returns>
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
            var fAAdjustmentDetails = FAAdjustmentDetails;
            if (fAAdjustmentDetails.Count == 0)
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
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetExpensesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _accountingObjectsPresenter.DisplayActive(true);
            _departmentsPresenter.DisplayActive();
            _fixedAssetsPresenter.DisplayForDecrement(true, basePostedDate);
            _budgetSourcesPresenter.DisplayActive();
            _projectsPresenter.DisPlayForFAIncrementDecrement();
            _fundStructuresPresenter.DisplayActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((FAAdjustmentModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((FAAdjustmentModel)MasterBindingSource.Current).RefId;
            }

            _fAAdjustmentPresenter.Display(KeyValue, true,true);


            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.RevaluationOfFixedAsset;
        }
        /// <summary>
        /// Enable the control.
        /// </summary>
        protected override void EnableControl()
        {
            cboObjectCode.EditValue = true;
        }
        /// <summary>
        /// Refresh Navigation Button.
        /// </summary>
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();
            cboObjectCode.EditValue = false;
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
            if (FAAdjustmentDetailParallels.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _fAAdjustmentPresenter.Save(true) : _fAAdjustmentPresenter.Save(false);

        }
        protected override void ReloadParallelGrid()
        {
            _fAAdjustmentPresenter.Display(KeyValue);
        }
        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new FAAdjustmentPresenter(null).Delete(KeyValue);
        }

        /// <summary>
        /// GrIds the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string textError = "";
            IModel model = new Model.Model();

            if (e.Column.FieldName == "FixedAssetId")
            {
                //var fixedAssetId = grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId");
                //var fixedAsset = _fixedAssetModels.FirstOrDefault(x => x.FixedAssetId == fixedAssetId);
                //var amount = fixedAsset == null ? 0 : fixedAsset.OrgPrice;
                //var description = fixedAsset == null ? "" : "Ghi giảm TSCĐ " + fixedAsset.FixedAssetName;
                //grdAccountingView.SetRowCellValue(e.RowHandle, "Description", description);
                //grdAccountingView.SetRowCellValue(e.RowHandle, "Amount", amount);
            }
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var _budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetSubItemModel = _budgetSubItemModels.FirstOrDefault(x => x.BudgetItemCode == _budgetSubItemCode);
                var budgetItemModel = _budgetItemModels.FirstOrDefault(x => budgetSubItemModel != null && x.BudgetItemId == budgetSubItemModel.ParentId);
                var _budgetItemCode = budgetItemModel == null ? "" : budgetItemModel.BudgetItemCode;
                grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
            }
 
        }

        #endregion

        #region private helper

        /// <summary>
        /// Initializes the grId layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGrIdLayout(List<XtraColumn> columnsCollection, GridView grdView)
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

            var decreaseReason = typeof(DecreaseReason).ToList();
            _repositoryDecreaseReasonId = new RepositoryItemLookUpEdit
            {
                DataSource = decreaseReason,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryDecreaseReasonId.PopulateColumns();
            _repositoryDecreaseReasonId.Columns["Key"].Visible = false;
        }

        #endregion

        #region FAAdjustmentDetails

        /// <summary>
        /// Gets or sets the fa adjustment details.
        /// </summary>
        /// <value>
        /// The fa adjustment details.
        /// </value>
        public IList<FAAdjustmentDetailModel> FAAdjustmentDetails
        {
            get
            {
                var fAAdjustmentDetails = new List<FAAdjustmentDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (FAAdjustmentDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new FAAdjustmentDetailModel
                            {
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ProjectId = rowVoucher.ProjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                BankId = rowVoucher.BankId,
                                ActivityId = rowVoucher.ActivityId,
                                FundStructureId =rowVoucher.FundStructureId
                            };
                            fAAdjustmentDetails.Add(item);
                        }
                    }
                }
                if (fAAdjustmentDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (FAAdjustmentDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                fAAdjustmentDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                fAAdjustmentDetails[i].ActivityId = rowVoucher.ActivityId;
                                fAAdjustmentDetails[i].ProjectId = rowVoucher.ProjectId;
                                fAAdjustmentDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                fAAdjustmentDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                                fAAdjustmentDetails[i].SortOrder = i;
                                fAAdjustmentDetails[i].ContractId = rowVoucher.ContractId;
                                fAAdjustmentDetails[i].CapitalPlanId = rowVoucher.CapitalPlanId;
                                fAAdjustmentDetails[i].BankId = rowVoucher.BankId;
                                fAAdjustmentDetails[i].ActivityId = rowVoucher.ActivityId;
                            }
                        }
                    }
                }
                return fAAdjustmentDetails;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<FAAdjustmentDetailModel>();
                //  bindingSourceDetail.DataSource = value ?? new List<FAIncrementDecrementDetailModel>();
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 150,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Chương",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Mục",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },

                     //new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false,},
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn { ColumnName = "CashWithDrawTypeId",ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType },
                   new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },

                     new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 15,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },

                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false },
                    //new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ParentRefDetailId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrgRefNo", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrgRefDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TopicId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                     new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false },
                       new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false },
                    //new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                 };
                grdAccountingView = InitGrIdLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion

                #region columns for grdAccountingDetailView
                columnsCollection = new List<XtraColumn>
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
                        RepositoryControl = _gridLookUpEditAccount,
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
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    
                    new XtraColumn
                    {
                        ColumnName = "ProjectId", ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 6,
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
                        ColumnPosition = 7,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 7,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 8,           
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpBudgetExpense
                    },
                    new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetProvideCode",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetSourceId",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn{ColumnName = "BudgetSubKindItemCode",ColumnVisible = false},
                    new XtraColumn { ColumnName = "MethodDistributeId",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetItemCode",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetSubItemCode",ColumnVisible = false},
                    new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false },
                  //  new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    //new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TopicId", ColumnVisible = false },
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                };
                grdAccountingDetailView = InitGrIdLayout(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion
            }
        }
        #endregion



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
                try
                {
                    _fixedAssetModels = value.ToList();
                    cboObjectCode.Properties.DataSource = value;
                    cboObjectCode.Properties.PopulateColumns();
                    _fixedAssetModels = value.ToList();
                    _gridLookUpEditFixedAssetView = new GridView();
                    _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(400, 150);

                    _gridLookUpEditFixedAsset.View.BestFitColumns();

                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);
                    _fixedAssetModels = value.ToList();
                    var grIdColumnsCollection = new List<XtraColumn>();
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetCode",
                        ColumnCaption = "Mã tài sản",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnPosition = 1
                    });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetName",
                        ColumnCaption = "Tên tài sản",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "GuaranteeDuration", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsSecondHand", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "LastState", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedReason", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationValueCaculated", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDepreciationAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingLifeTime", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "EndYear", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CreditDepreciationAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DebitDepreciationAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAssetTransfer", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationTimeCaculated", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "RevenueAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Source", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "UsingRatio", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationPeriod", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationLifeTime", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationRate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationCreditAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDebitAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDevaluationAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetDetailAccessories", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetVoucherAttachs", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "EndDevaluationDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDebitAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationCreditAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDevaluationAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });


                    //foreach (var column in grIdColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    //_gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";

                    foreach (var column in grIdColumnsCollection)
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
                    cboObjectCode.Properties.DisplayMember = "FixedAssetCode";
                    cboObjectCode.Properties.ValueMember = "FixedAssetId";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region IView Extens
        public List<BankModel> OldBanks { get; set; }
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
                OldBanks = value.ToList();
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                if (value == null)
                    value = new List<BudgetExpenseModel>();

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseCode", ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseName", ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId", gridColumnsCollection);
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
                else
                {
                    var data = value.Where(o => o.IsParent == false && o.Inactive == true).ToList();
                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureCode), ColumnCaption = "Mã khoản chi", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FundStructureModel.FundStructureName), ColumnCaption = "Tên khoản chi", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, data, nameof(FundStructureModel.FundStructureCode), nameof(FundStructureModel.FundStructureId), gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
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
                    _budgetItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                    _budgetSubItemModels = value.Where(v => v.BudgetItemType == 3).ToList();

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

        #region Departments

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null)
                    return;
                // _listFixedAsset = value.ToList();

                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentCode), ColumnCaption = "Mã phòng/ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentName), ColumnCaption = "Tên phòng/ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, nameof(DepartmentModel.DepartmentName), nameof(DepartmentModel.DepartmentId), gridColumnsCollection);
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
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
                    _listAccounts = value.ToList();
                    // Tudt comment để chạy được project (do đoạn code này đang lỗi)
                    _accountModels = value.ToList();

                    var debitAccounts = value.ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var creditAccounts = value.ToList().CreditAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var parallelAccounts = value.ToList().ParallelAccounts();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Số tài khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });


                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

                    _gridLookUpEditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountView);

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

                    _gridLookUpEditAccountingObject.DataSource = value;
                    _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                    var grIdColumnsCollection = new List<XtraColumn>();
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryId",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IdentificationNumber",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FamilyDeductionAmount",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "NumberFamilyDependent",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPayInsuranceOnSalary",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsUnEmploymentInsurance",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPaidInsuranceForPayrollItem",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    grIdColumnsCollection.Add(
                        new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "OrganizationManageFee",
                        ColumnVisible = false
                    });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                    grIdColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });

                    foreach (var column in grIdColumnsCollection)
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
                    _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", grIdColumnsCollection);
                    XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(grIdColumnsCollection, _gridLookUpEditAccountingObjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
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
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityCode", "ActivityId", gridColumnsCollection);

                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                _gridLookUpEditActivity.EndUpdate();
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


        //public decimal? UnitPrice
        //{
        //    get { return calcUnitPrice.Value; }
        //    set { calcUnitPrice.Value = value; }
        //}

        /// <summary>
        /// Gets or sets the reference Identifier.
        /// </summary>
        /// <value>
        /// The reference Identifier.
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
                return FAAdjustmentDetails.Sum(x => x.Amount);
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the generated reference Identifier.
        /// </summary>
        /// <value>
        /// The generated reference Identifier.
        /// </value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset Identifier.
        /// </summary>
        /// <value>
        /// The fixed asset Identifier.
        /// </value>
        public string FixedAssetId
        {
            get { return cboObjectCode.EditValue == null ? null : cboObjectCode.EditValue.ToString(); }
            set { cboObjectCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName
        {
            get { return txtContactName.Text.Trim(); }
            set { txtContactName.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FrmRevaluationOfFixedAssetDetail"/> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>
        /// The post version.
        /// </value>
        public int PostVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>
        /// The edit version.
        /// </value>
        public int? EditVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the applied year.
        /// </summary>
        /// <value>
        /// The applied year.
        /// </value>
        public int AppliedYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end year.
        /// </summary>
        /// <value>
        /// The end year.
        /// </value>
        public int EndYear
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fa reference order.
        /// </summary>
        /// <value>
        /// The fa reference order.
        /// </value>
        public int FARefOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end devaluation date.
        /// </summary>
        /// <value>
        /// The end devaluation date.
        /// </value>
        public DateTime EndDevaluationDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }
        //---------------
        /// <summary>
        /// Gets or sets the new org price.
        /// </summary>
        /// <value>
        /// The new org price.
        /// </value>
        public decimal NewOrgPrice
        {
            get { return txtOriginalPriceEdit.Value; }
            set { txtOriginalPriceEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old org price.
        /// </summary>
        /// <value>
        /// The old org price.
        /// </value>
        public decimal OldOrgPrice
        {
            get { return txtOriginalpriceOld.Value; }
            set { txtOriginalpriceOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference org price.
        /// </summary>
        /// <value>
        /// The difference org price.
        /// </value>
        public decimal DiffOrgPrice
        {
            get { return txtOriginalpriceDifference.Value; }
            set { txtOriginalpriceDifference.Value = value; }
        }

        /// <summary>
        /// Gets or sets the new devaluation amount.
        /// </summary>
        /// <value>
        /// The new devaluation amount.
        /// </value>
        public decimal NewDevaluationAmount
        {
            get { return txtDevaluationEdit.Value; }
            set { txtDevaluationEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old devaluation amount.
        /// </summary>
        /// <value>
        /// The old devaluation amount.
        /// </value>
        public decimal OldDevaluationAmount
        {
            get { return txtDevaluationOld.Value; }
            set { txtDevaluationOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference devaluation amount.
        /// </summary>
        /// <value>
        /// The difference devaluation amount.
        /// </value>
        public decimal DiffDevaluationAmount
        {
            get { return txtDevaluationDifference.Value; }
            set { txtDevaluationDifference.Value = value; }
        }

        public decimal NewAnnualDepreciationAmount
        {
            get { return txtDepreciationEdit.Value; }
            set { txtDepreciationEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the new accum depreciation amount.
        /// </summary>
        /// <value>
        /// The new accum depreciation amount.
        /// </value>
        public decimal NewAccumDepreciationAmount
        {
            get {  return txtAtrophyDepreciationEdit.Value; }
            set { txtAtrophyDepreciationEdit.Value = value; }
        }

        public decimal DiffAnnualDepreciationAmount
        {
            get { return txtDepreciationDifference.Value; }
            set { txtDepreciationDifference.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old accum depreciation amount.
        /// </summary>
        /// <value>
        /// The old accum depreciation amount.
        /// </value>
        public decimal OldAccumDevaluationAmount
        {
            get { return txtAccumulatedDepreciationOld.Value; }
            set { txtAccumulatedDepreciationOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference accum depreciation amount.
        /// </summary>
        /// <value>
        /// The difference accum depreciation amount.
        /// </value>
        public decimal DiffAccumDepreciationAmount
        {
            get { return txtAccumulatedDepreciationDifference.Value; }
            set { txtAccumulatedDepreciationDifference.Value = value; }
        }

        /// <summary>
        /// Gets or sets the new accum devaluation amount.
        /// </summary>
        /// <value>
        /// The new accum devaluation amount.
        /// </value>
        public decimal NewAccumDevaluationAmount
        {
            get {  return txtAccumulatedDepreciationEdit.Value; }
            set {  txtAccumulatedDepreciationEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old accum devaluation amount.
        /// </summary>
        /// <value>
        /// The old accum devaluation amount.
        /// </value>
        public decimal OldAccumDepreciationAmount
        {
            get { return txtAtrophyDepreciationOld.Value; }
            set { txtAtrophyDepreciationOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference accum devaluation amount.
        /// </summary>
        /// <value>
        /// The difference accum devaluation amount.
        /// </value>
        public decimal DiffAccumDevaluationAmount
        {
            get { return txtAtrophyDepreciationDifference.Value; }
            set { txtAtrophyDepreciationDifference.Value = value; }
        }

        /// <summary>
        /// Gets or sets the new remaining amount.
        /// </summary>
        /// <value>
        /// The new remaining amount.
        /// </value>
        public decimal NewRemainingAmount
        {
            get { return txtResidualValueEdit.Value; }
            set { txtResidualValueEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old remaining amount.
        /// </summary>
        /// <value>
        /// The old remaining amount.
        /// </value>
        public decimal OldRemainingAmount
        {
            get { return txtResidualValueOld.Value; }
            set { txtResidualValueOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference remaining amount.
        /// </summary>
        /// <value>
        /// The difference remaining amount.
        /// </value>
        public decimal DiffRemainingAmount
        {
            get { return txtResidualValueDifference.Value; }
            set { txtResidualValueDifference.Value = value; }
        }

        /// <summary>
        /// Gets or sets the new quantity.
        /// </summary>
        /// <value>
        /// The new quantity.
        /// </value>
        public decimal NewQuantity
        {
            get { return txtQuantityEdit.Value; }
            set { txtQuantityEdit.Value = value; }
        }

        /// <summary>
        /// Gets or sets the old quantity.
        /// </summary>
        /// <value>
        /// The old quantity.
        /// </value>
        public decimal OldQuantity
        {

            get { return txtQuantityOld.Value; }
            set { txtQuantityOld.Value = value; }
        }

        /// <summary>
        /// Gets or sets the difference quantity.
        /// </summary>
        /// <value>
        /// The difference quantity.
        /// </value>
        public decimal DiffQuantity
        {
            get { return txtQuantityDifference.Value; }
            set { txtQuantityDifference.Value = value; }
        }

        public decimal OldAnnualDepreciationAmount
        {
            get { return txtDepreciationOld.Value; }
            set { txtDepreciationOld.Value = value; }
        }
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
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal? ExchangeRate
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
        public IList<FAAdjustmentDetailParallelModel> FAAdjustmentDetailParallels
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var paymentDetailParallels = new List<FAAdjustmentDetailParallelModel>();
                if (grdAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdViewAccountingParallel.RowCount; i++)
                    {
                        var rowVoucher = (FAAdjustmentDetailParallelModel)grdViewAccountingParallel.GetRow(i);
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
                            var item = new FAAdjustmentDetailParallelModel
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
                                BankId = rowVoucher.BankId,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                SortOrder = i,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                ProjectId = rowVoucher.ProjectId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                ActivityId = rowVoucher.ActivityId,
                                FundStructureId = rowVoucher.FundStructureId
                            };
                            paymentDetailParallels.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return paymentDetailParallels;

            }
            set
            {
                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<FAAdjustmentDetailParallelModel>();
                grdViewAccountingParallel.PopulateColumns(value);

                #region columns for grdViewAccountingParallel

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    //new XtraColumn
                    //{
                    //    ColumnName = "AutoBusinessId",
                    //    ColumnVisible = true,
                    //    RepositoryControl = _gridLookUpEditA,
                    //    ColumnWith = 200,
                    //    ColumnCaption = "ĐK tự động",
                    //    ColumnPosition = 1,
                    //    AllowEdit = true,
                    //},
                     new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 150,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Chương",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Mục",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    //new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false,},
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn { ColumnName = "CashWithDrawTypeId",ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType },
                   new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Tài khoản NH,KB",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },

                     new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },

                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false },
                    //new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ParentRefDetailId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrgRefNo", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrgRefDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TopicId", ColumnVisible = false },
                    //new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                };

                grdViewAccountingParallel.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        #endregion

        /// <summary>
        /// Handles the Load event of the FrmRevaluationOfFixedAssetDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmRevaluationOfFixedAssetDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, false);
        }

        #region Control events

        /// <summary>
        /// Handles the KeyDown event of the txtOriginalPriceEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void txtOriginalPriceEdit_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    txtOriginalpriceDifference.Value = txtOriginalPriceEdit.Value - txtOriginalpriceOld.Value;
            //}
            //catch { }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;

            if (cboObjectCode.EditValue == FixedAssetId)
            {
                if (ActionMode == ActionModeVoucherEnum.Edit)
                {
                    return;
                }
            }

            var fixedAssetName = (string)cboObjectCode.GetColumnValue("FixedAssetName");
            txtContactName.Text = fixedAssetName;
            txtDescription.Text = "Đánh giá lại TSCĐ " + fixedAssetName;
            var fixedAssetId = (string)cboObjectCode.GetColumnValue("FixedAssetId");
            FixedAssetId = fixedAssetId;
            FixedAssetName = fixedAssetName;

            // Lấy thông tin tài sản đánh giá

            // var listFAAdjustmentDetailFA = FAAdjustmentDetailFADao.GetFAAdjustmentDetailFAByFixedAssetId(fixedAssetId);
            var fixedAssetDictionary = _fixedAssetModels.Where(x => x.FixedAssetId == fixedAssetId).ToList();
            var fixedAssets = _model.GetFixedAssetsForAdjustment(fixedAssetId, PostedDate, RefType, true);
            if (fixedAssets != null)
            {
                foreach (var fixedAsset in fixedAssets)
                {
                    OldOrgPrice = fixedAsset.OrgPrice;
                    NewOrgPrice = fixedAsset.OrgPrice;
                    DiffOrgPrice = NewOrgPrice - OldOrgPrice;
                    OldDevaluationAmount = fixedAsset.DevaluationAmount;
                    NewDevaluationAmount = fixedAsset.DevaluationAmount;
                    //DiffDevaluationAmount = 0;
                    OldAccumDepreciationAmount = fixedAsset.AccumDepreciationAmount;
                    NewAccumDepreciationAmount = fixedAsset.AccumDepreciationAmount;
                    DiffAccumDepreciationAmount = 0;
                    OldAccumDevaluationAmount = fixedAsset.AccumDevaluationAmount;
                    NewAccumDevaluationAmount = fixedAsset.AccumDevaluationAmount;
                    //DiffAccumDevaluationAmount = 0;
                    OldRemainingAmount = fixedAsset.OrgPrice - fixedAsset.AccumDevaluationAmount - fixedAsset.AccumDepreciationAmount;
                    NewRemainingAmount = fixedAsset.OrgPrice - NewAccumDepreciationAmount - NewAccumDevaluationAmount;
                    //NewRemainingAmount = fixedAsset.OrgPrice - fixedAsset.AccumDevaluationAmount - fixedAsset.AccumDepreciationAmount;
                    //OldRemainingAmount = fixedAsset.OrgPrice - fixedAsset.AccumDevaluationAmount - fixedAsset.AccumDepreciationAmount;
                    OldQuantity = fixedAsset.Quantity;
                    NewQuantity = fixedAsset.Quantity;
                    //DiffQuantity = 0;
                    OldAnnualDepreciationAmount = fixedAsset.OrgPrice - fixedAsset.DevaluationAmount;
                    NewAnnualDepreciationAmount = fixedAsset.OrgPrice - fixedAsset.DevaluationAmount;
                    //DiffAnnualDepreciationAmount = 0;
                    DiffRemainingAmount = DiffOrgPrice - DiffAccumDepreciationAmount - DiffAccumDevaluationAmount;
                }
                //txtDepreciationEdit.Value = NewOrgPrice - NewDevaluationAmount;

            }
        }

        /// <summary>
        /// Handles the Click event of the cboGenerate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboGenerate_Click(object sender, EventArgs e)
        {
            var faAdjustmentDetails = new List<FAAdjustmentDetailModel>();

            if (txtOriginalpriceDifference.Value > 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = (string)cboObjectCode.GetColumnValue("OrgPriceAccount"),
                    CreditAccount = null,
                    Amount = txtOriginalpriceDifference.Value,
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            else if (txtOriginalpriceDifference.Value < 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = null,
                    CreditAccount = (string)cboObjectCode.GetColumnValue("OrgPriceAccount"),
                    Amount = Math.Abs(txtOriginalpriceDifference.Value),
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            if (txtAccumulatedDepreciationDifference.Value > 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = (string)cboObjectCode.GetColumnValue("DevaluationDebitAccount"),
                    CreditAccount = (string)cboObjectCode.GetColumnValue("DevaluationCreditAccount"),
                    Amount = txtAccumulatedDepreciationDifference.Value,
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            else if (txtAccumulatedDepreciationDifference.Value < 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = (string)cboObjectCode.GetColumnValue("DevaluationCreditAccount"),
                    CreditAccount = (string)cboObjectCode.GetColumnValue("DevaluationDebitAccount"),
                    Amount = Math.Abs(txtAccumulatedDepreciationDifference.Value),
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            if (txtAtrophyDepreciationDifference.Value > 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = (string)cboObjectCode.GetColumnValue("DebitDepreciationAccount"),
                    CreditAccount = (string)cboObjectCode.GetColumnValue("CreditDepreciationAccount"),
                    Amount = txtAtrophyDepreciationDifference.Value,
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            else if (txtAtrophyDepreciationDifference.Value < 0)
            {
                var faAdjustmentDetail = new FAAdjustmentDetailModel
                {
                    Description = "Đánh giá lại TSCĐ " + (string)cboObjectCode.GetColumnValue("FixedAssetName"),
                    DebitAccount = (string)cboObjectCode.GetColumnValue("CreditDepreciationAccount"),
                    CreditAccount = (string)cboObjectCode.GetColumnValue("DebitDepreciationAccount"),
                    Amount = Math.Abs(txtAtrophyDepreciationDifference.Value),
                    BudgetChapterCode = (string)cboObjectCode.GetColumnValue("BudgetChapterCode"),
                    BudgetSubKindItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubKindItemCode"),
                    BudgetItemCode = (string)cboObjectCode.GetColumnValue("BudgetItemCode"),
                    BudgetSubItemCode = (string)cboObjectCode.GetColumnValue("BudgetSubItemCode"),
                    BudgetSourceId = (string)cboObjectCode.GetColumnValue("BudgetSourceId")
                };
                faAdjustmentDetails.Add(faAdjustmentDetail);
            }
            FAAdjustmentDetails = faAdjustmentDetails;
            grdAccountingView.Focus();
            tabMain.SelectedTabPage = tabAccounting;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtOriginalPriceEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtOriginalPriceEdit_EditValueChanged(object sender, EventArgs e)
        {
            NewRemainingAmount = NewOrgPrice - NewAccumDepreciationAmount - NewAccumDevaluationAmount;
            var newValue = txtOriginalPriceEdit.Value;
            var oldvalue = txtOriginalpriceOld.Value;
            txtOriginalpriceDifference.Value = newValue - oldvalue;
            NewAnnualDepreciationAmount = NewOrgPrice - txtDevaluationEdit.Value;
            DiffDevaluationAmount = txtDevaluationEdit.Value - txtDevaluationOld.Value;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtAccumulatedDepreciationEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtAccumulatedDepreciationEdit_EditValueChanged(object sender, EventArgs e)
        {
            var newValue = txtAccumulatedDepreciationEdit.Value;
            var oldvalue = txtAccumulatedDepreciationOld.Value;
            txtAccumulatedDepreciationDifference.Value = newValue - oldvalue;
            txtResidualValueEdit.Value = txtOriginalPriceEdit.Value - txtAccumulatedDepreciationEdit.Value -
                                         txtAtrophyDepreciationEdit.Value;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtAtrophyDepreciationEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtAtrophyDepreciationEdit_EditValueChanged(object sender, EventArgs e)
        {
            OldAnnualDepreciationAmount = OldOrgPrice - txtDevaluationOld.Value;
            var newValue = txtAtrophyDepreciationEdit.Value;
            var oldvalue = txtAtrophyDepreciationOld.Value;
            txtAtrophyDepreciationDifference.Value = newValue - oldvalue;
            txtResidualValueEdit.Value = txtOriginalPriceEdit.Value - txtAccumulatedDepreciationEdit.Value -
                                         txtAtrophyDepreciationEdit.Value;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtResidualValueEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtResidualValueEdit_EditValueChanged(object sender, EventArgs e)
        {
            var newValue = txtResidualValueEdit.Value;
            var oldvalue = txtResidualValueOld.Value;
            txtResidualValueDifference.Value = newValue - oldvalue;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtQuantityEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtQuantityEdit_EditValueChanged(object sender, EventArgs e)
        {
            var newValue = txtQuantityEdit.Value;
            var oldvalue = txtQuantityOld.Value;
            txtQuantityDifference.Value = newValue - oldvalue;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDevaluationEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtDevaluationEdit_EditValueChanged(object sender, EventArgs e)
        {
            NewOrgPrice = txtDevaluationEdit.Value + txtDepreciationEdit.Value;
            //txtOriginalPriceEdit.Value = txtDevaluationEdit.Value + txtDepreciationEdit.Value;
            //var newValue = txtDevaluationEdit.Value;
            //var oldvalue = txtDevaluationOld.Value;
            //txtDevaluationDifference.Value = newValue - oldvalue;
        }

        /// <summary>
        /// Handles the 1 event of the txtDepreciationEdit_EditValueChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void txtDepreciationEdit_EditValueChanged_1(object sender, EventArgs e)
        {

            //txtOriginalpriceDifference.Value = txtDepreciationDifference.Value + txtDevaluationDifference.Value;
        }

        #endregion

        private void txtDepreciationEdit_EditValueChanged(object sender, EventArgs e)
        {
            DiffAnnualDepreciationAmount = txtDepreciationEdit.Value - txtDepreciationOld.Value;
            txtOriginalPriceEdit.Value = txtDevaluationEdit.Value + txtDepreciationEdit.Value;
            //var newValue = txtDepreciationEdit.Value;
            //var oldvalue = txtDepreciationOld.Value;
            txtDepreciationDifference.Value = txtDepreciationEdit.Value - (OldOrgPrice - OldDevaluationAmount);//Double click from master
            txtResidualValueEdit.Value = txtOriginalPriceEdit.Value - txtAccumulatedDepreciationEdit.Value -
                                         txtAtrophyDepreciationEdit.Value;
        }

        private void txtDepreciationOld_EditValueChanged(object sender, EventArgs e)
        {
            txtDepreciationDifference.Value = txtDepreciationEdit.Value - (OldOrgPrice - OldDevaluationAmount);//Click Edit from master
        }

        private void txtDepreciationDifference_EditValueChanged(object sender, EventArgs e)
        {
           // txtDepreciationDifference.Value = txtDepreciationEdit.Value - txtDepreciationOld.Value;
        }

        protected override void AdjustControlSize(Panel panel1, bool isPanel, bool isGrdMaster)
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
                grMasterHeigh = grdMaster.Height;
                // grdMaster.Location = new Point(6, yMaster);
                ytabMain = yMaster + grMasterHeigh + 7;
                grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                tabMainHeight = ((grdLayoutHeight / 10) * 6 - 30);
                tabMainWith = tabMain.Width;
                tabMain.Size = new Size(tabMainWith, (formHeight - 300) / 2 -40);
                // tabMain.Location = new Point(6, ytabMain);

                ypanel1 = ytabMain + tabMainHeight + 15;
                panel1Height = grdLayoutHeight - tabMainHeight;
                panel1.Height = panel1Height;
                panel1.Location = new Point(6, ypanel1);
                panel1.Size = new Size(tabMainWith, ((formHeight - 300) / 2) - 35);
            }
        }

        private void FrmRevaluationOfFixedAssetDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, false);
        }

        private void txtAccumulatedDepreciationOld_EditValueChanged(object sender, EventArgs e)
        {
            txtAccumulatedDepreciationDifference.Value =
                txtAccumulatedDepreciationEdit.Value - txtAccumulatedDepreciationOld.Value;
        }
        
        /// <summary>
        /// Enable các textbox nhập giá trị nếu sửa
        /// </summary>
        /// <param name="isEnable"></param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
            cboObjectCode.EditValue = isEnable;
        }

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        private void tabMain_Click(object sender, EventArgs e)
        {

        }

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
                var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
            }
        }
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
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                //grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(FAAdjustmentDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
