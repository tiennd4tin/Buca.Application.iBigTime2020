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

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.IncrementDecrement.IFAIncrementDecrementView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmFADecrementDetail : FrmXtraBaseVoucherDetail, IFAIncrementDecrementView, IFixedAssetsView,
        IDepartmentsView, IAccountsView, IAccountingObjectsView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, ICashWithdrawTypesView, IActivitysView, IProjectsView, IFundStructuresView
    {
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;

        #region Presenter

        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly FAIncrementDecrementPresenter _fAIncrementDecrementPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        ///     The departments presenter
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
        ///     The inventory items presenter
        /// </summary>
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;

        /// <summary>
        /// The fixed asset models
        /// </summary>
        private List<FixedAssetModel> _fixedAssetModels;
        private List<FixedAssetModel> _fixedAssetModelsTemp;//Biến tạm dành cho Edit mode

        /// <summary>
        ///     The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;

        private List<BudgetItemModel> _budgetItemModels;
        private List<BudgetItemModel> _budgetSubItemModels;

        private List<FAIncrementDecrementDetailModel> _FAIncrementDecrementDetailList;
        public bool IsTwoRow;
        public List<FAIncrementDecrementDetailModel> ListSourceDetail;
        private readonly IModel _model;
        private bool isSetIncreDecre = false;
        private int SortOrderTemp = 0;
        #endregion

        #region Tài khoản ngầm định
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;
        #endregion

        #region RepositoryItemLookUpEdit

        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;

        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditFixedAssetView;

        /// <summary>
        /// The grid look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;

        /// <summary>
        /// The grid look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCreditAccount;
        private GridView _gridLookUpEditCreditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditTaxAccount;
        private GridView _gridLookUpEditTaxAccountView;

        /// <summary>
        /// The grid look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;

        /// <summary>
        /// The grid look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        /// The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;

        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;

        /// <summary>
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grid look up edit activity
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        /// <summary>
        /// The grid look up edit activity view
        /// </summary>
        private GridView _gridLookUpEditActivityView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemLookUpEdit _repositoryDecreaseReasonId;

        private List<AccountModel> _accountModels;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmFADecrementDetail"/> class.
        /// </summary>
        public FrmFADecrementDetail()
        {
            InitializeComponent();
            _fAIncrementDecrementPresenter = new FAIncrementDecrementPresenter(this);
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
        }

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = false;
            tabMain.Location = new Point(6, 180);
            tabMain.SelectedTabPage = tabAccounting;
            grdAccounting.Visible = true;
            txtDescription.Properties.AutoHeight = false;
            txtDescription.Height = 80;
        }



        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //grdAccounting.DataSource = null;
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _accountingObjectsPresenter.DisplayActive(true);
            _departmentsPresenter.DisplayActive();
            if(KeyValue != null && KeyValue != Guid.Empty.ToString())
            {

                _fixedAssetsPresenter.DisplayByActiveDecre(true, KeyValue);
            }
            else
            {

                _fixedAssetsPresenter.DisplayByActive(true);
            }
            _budgetSourcesPresenter.DisplayActive();
            _projectsPresenter.DisPlayForFAIncrementDecrement();
            _fundStructuresPresenter.DisplayActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((FAIncrementDecrementModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((FAIncrementDecrementModel)MasterBindingSource.Current).RefId;
            }

            _fAIncrementDecrementPresenter.Display(KeyValue, true);
            InitRefInfo();
            dtPostDate.EditValue = dtPostDate.EditValue.ToString().StartsWith("01/01/0001")//AnhNT: khắc phục lỗi dtpostedate = null
                ? DateTime.Now
                : dtPostDate.EditValue;
          //  _fixedAssetsPresenter.DisplayForDecrement(true, DateTime.Parse(dtPostDate.EditValue.ToString()));

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.FADecrement;

        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if XXXX, <c>false</c> otherwise.
        /// </returns>
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
            var fAIncrementDecrementDetails = FAIncrementDecrementDetails;
            if (fAIncrementDecrementDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var fAIncrementDecrementDetail in fAIncrementDecrementDetails)
            {
                if (string.IsNullOrEmpty(fAIncrementDecrementDetail.FixedAssetId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetIdRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(fAIncrementDecrementDetail.DepartmentId))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentIdRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrEmpty(fAIncrementDecrementDetail.DebitAccount))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitAccountRequired"), detailContent,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return false;
                }
                if (fAIncrementDecrementDetail.CreditAccount == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
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

        /// <summary>
        /// Initializes the detail row for acounting detail.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRowForAcountingDetail(InitNewRowEventArgs e, GridView view)
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
            //txtDocumentInclude.ReadOnly = true;
            //txtTaxCode.ReadOnly = true;
            IsTwoRow = false;
            return _fAIncrementDecrementPresenter.Save();
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new FAIncrementDecrementPresenter(null).Delete(KeyValue);
        }

        //   List<GLVoucherDetailModel> ListSendSourceDetail;
        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        /// 
        /// 
        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            string textError = "";
            IModel model = new Model.Model();


            if (e.Column.FieldName == "FixedAssetId")

            {
                string fixedAssetId = grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId");
                bool checkFA = ListSourceDetail.Any(x => x.FixedAssetId == fixedAssetId);
                
                fixedAssetId = "," + fixedAssetId + ",";
                var FixedAssetLedgerData = FixedAssetLedgerDao.PostFixedAsset_GetLastedInfoForPost_ByFixedAssetId(fixedAssetId, PostedDate, 1, true);
                //var source = ListSourceDetail;
                //var _list = new List<FAIncrementDecrementDetailModel>();

                if (!checkFA)
                {
                    var fixedAssetFirst = OldFixedAssets.FirstOrDefault(x => fixedAssetId.Contains(x.FixedAssetId));
                    //if (fixedAssetFirst != null && !string.IsNullOrEmpty(fixedAssetFirst.DepartmentId))
                    //{
                    //   grdAccountingView.SetRowCellValue(e.RowHandle, "DepartmentId", fixedAssetFirst.DepartmentId);
                    //}

                    if (ListSourceDetail != null)
                        _FAIncrementDecrementDetailList = ListSourceDetail;
                    else
                        _FAIncrementDecrementDetailList = new List<FAIncrementDecrementDetailModel>();
                    foreach (var Detail in FixedAssetLedgerData)
                    {
                        var fixedAssetModel =
                            _fixedAssetModels.FirstOrDefault(c => c.FixedAssetId == Detail.FixedAssetId);
                        int sortOrder = ListSourceDetail.Count == 0 ? 0 : ListSourceDetail.Max(x => x.SortOrder).Value + 1;
                        // nguyeen gia  = hao mon + khau hao (luy ke)
                        if (Detail.OrgPriceDebitAmount ==
                            Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount)
                        {
                            var row1 = new FAIncrementDecrementDetailModel()
                            {
                                FixedAssetId = Detail.FixedAssetId,
                                DepartmentId = fixedAssetFirst.DepartmentId,
                                Description = fixedAssetModel.FixedAssetName,
                                Amount = Detail.OrgPriceDebitAmount,
                                SortOrder = sortOrder,
                                DebitAccount = fixedAssetModel.CreditDepreciationAccount,
                                CreditAccount = fixedAssetModel.OrgPriceAccount,
                                BudgetSourceId = GlobalVariable.DefaultBudgetSourceID,
                                BudgetChapterCode =
                                    fixedAssetModel.BudgetChapterCode ?? GlobalVariable.DefaultBudgetChapterCode,
                                BudgetSubKindItemCode =
                                    fixedAssetModel.BudgetSubKindItemCode ??
                                    GlobalVariable.DefaultBudgetSubKindItemCode,
                                BudgetKindItemCode =
                                    fixedAssetModel.BudgetKindItemCode ?? GlobalVariable.DefaultBudgetKindItemCode,
                                BudgetItemCode = fixedAssetModel.BudgetItemCode,
                                BudgetSubItemCode = fixedAssetModel.BudgetSubItemCode,
                                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                                Quantity = (int)Detail.Quantity,
                            };

                            _FAIncrementDecrementDetailList.Add(row1);
                            //FAIncrementDecrementDetails.Add(row1);

                            ListSourceDetail = _FAIncrementDecrementDetailList;
                            FAIncrementDecrementDetails = ListSourceDetail;
                            grdAccountingView.MoveLast();
                        }

                        //  hao mon + khau hao (luy ke) =  0
                        if (Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount == 0)
                        {
                            var row1 = new FAIncrementDecrementDetailModel()
                            {
                                FixedAssetId = Detail.FixedAssetId,
                                DepartmentId = Detail.DepartmentId,
                                Description = fixedAssetModel.FixedAssetName,
                                Amount = Detail.OrgPriceDebitAmount,
                                SortOrder = sortOrder,
                                DebitAccount = fixedAssetModel.CapitalAccount,
                                CreditAccount = fixedAssetModel.OrgPriceAccount,
                                BudgetSourceId = GlobalVariable.DefaultBudgetSourceID,
                                BudgetChapterCode =
                                    fixedAssetModel.BudgetChapterCode ?? GlobalVariable.DefaultBudgetChapterCode,
                                BudgetSubKindItemCode =
                                    fixedAssetModel.BudgetSubKindItemCode ??
                                    GlobalVariable.DefaultBudgetSubKindItemCode,
                                BudgetKindItemCode =
                                    fixedAssetModel.BudgetKindItemCode ?? GlobalVariable.DefaultBudgetKindItemCode,
                                BudgetItemCode = fixedAssetModel.BudgetItemCode,
                                BudgetSubItemCode = fixedAssetModel.BudgetSubItemCode,
                                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                                Quantity = (int)Detail.Quantity
                            };

                            _FAIncrementDecrementDetailList.Add(row1);

                            ListSourceDetail = _FAIncrementDecrementDetailList;

                            FAIncrementDecrementDetails = ListSourceDetail;
                            grdAccountingView.MoveLast();

                        }

                        // nguyen gia  khac  hao mon + khau hao (luy ke)
                        if (Detail.OrgPriceDebitAmount !=
                            Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount &&
                            Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount != 0)
                        {
                            IsTwoRow = true;
                            var row1 = new FAIncrementDecrementDetailModel()
                            {
                                FixedAssetId = Detail.FixedAssetId,
                                DepartmentId = Detail.DepartmentId,
                                Description = fixedAssetModel.FixedAssetName,
                                Amount = Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount,
                                SortOrder = sortOrder,
                                DebitAccount = fixedAssetModel.CreditDepreciationAccount,
                                CreditAccount = fixedAssetModel.OrgPriceAccount,
                                BudgetSourceId = GlobalVariable.DefaultBudgetSourceID,
                                BudgetChapterCode =
                                    fixedAssetModel.BudgetChapterCode ?? GlobalVariable.DefaultBudgetChapterCode,
                                BudgetSubKindItemCode =
                                    fixedAssetModel.BudgetSubKindItemCode ??
                                    GlobalVariable.DefaultBudgetSubKindItemCode,
                                BudgetKindItemCode =
                                    fixedAssetModel.BudgetKindItemCode ?? GlobalVariable.DefaultBudgetKindItemCode,
                                BudgetItemCode = fixedAssetModel.BudgetItemCode,
                                BudgetSubItemCode = fixedAssetModel.BudgetSubItemCode,
                                MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                                CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                                Quantity = (int)Detail.Quantity,

                            };

                            _FAIncrementDecrementDetailList.Add(row1);

                            if (fixedAssetModel != null)
                            {
                                var row2 = new FAIncrementDecrementDetailModel()
                                {
                                    SortOrder = sortOrder,
                                    FixedAssetId = Detail.FixedAssetId,
                                    DepartmentId = Detail.DepartmentId,
                                    Description = fixedAssetModel.FixedAssetName,
                                    Amount = Detail.OrgPriceDebitAmount -
                                             (Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount),
                                    DebitAccount = fixedAssetModel.CapitalAccount,
                                    CreditAccount = fixedAssetModel.OrgPriceAccount,
                                    BudgetSourceId = GlobalVariable.DefaultBudgetSourceID,
                                    BudgetChapterCode =
                                        fixedAssetModel.BudgetChapterCode ?? GlobalVariable.DefaultBudgetChapterCode,
                                    BudgetSubKindItemCode =
                                        fixedAssetModel.BudgetSubKindItemCode ??
                                        GlobalVariable.DefaultBudgetSubKindItemCode,
                                    BudgetKindItemCode =
                                        fixedAssetModel.BudgetKindItemCode ?? GlobalVariable.DefaultBudgetKindItemCode,
                                    BudgetItemCode = fixedAssetModel.BudgetItemCode,
                                    BudgetSubItemCode = fixedAssetModel.BudgetSubItemCode,
                                    MethodDistributeId = GlobalVariable.DefaultMethodDistributeID,
                                    CashWithDrawTypeId = GlobalVariable.DefaultCashWithDrawTypeID,
                                    Quantity = (int)Detail.Quantity
                                };

                                _FAIncrementDecrementDetailList.Add(row2);
                                //FAIncrementDecrementDetails.Add(row2);
                            }

                            ListSourceDetail = _FAIncrementDecrementDetailList;
                            FAIncrementDecrementDetails = ListSourceDetail;
                            grdAccountingView.MoveLast();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Tài sản bạn chọn đã tồn tại trên chứng từ ! Vui lòng chọn tài sản khác", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
          //      FAIncrementDecrementDetails = ListSourceDetail;
              //  grdAccounting.Refresh();
              //  grdAccounting.RefreshDataSource();
            }

            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var _budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetSubItemModel = _budgetSubItemModels.FirstOrDefault(x => x.BudgetItemCode == _budgetSubItemCode);
                var budgetItemModel = _budgetItemModels.FirstOrDefault(x => budgetSubItemModel != null && x.BudgetItemId == budgetSubItemModel.ParentId);
                var _budgetItemCode = budgetItemModel == null ? "" : budgetItemModel.BudgetItemCode;
                grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", _budgetItemCode);
            }
            //Thay đổi số lượng
            if (e.Column.FieldName == "Quantity")
            {
                FixedAssetModel item = _fixedAssetModels.FirstOrDefault(x =>
                        x.FixedAssetId == grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId").ToString());

                decimal amountPerOne = 0;// item.OrgPrice / item.Quantity;
                var quantityMax = item.Quantity;
                if ((int)grdAccountingView.GetRowCellValue(e.RowHandle, e.Column.FieldName) > quantityMax && quantityMax != 0)
                {
                    grdAccountingView.SetRowCellValue(e.RowHandle, e.Column.FieldName, quantityMax);
                    return;
                }
                string fixedAssetId = grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId");
               // var itemCurrent = ActionMode != ActionModeVoucherEnum.AddNew ? FixedAssetLedgerDao.GetFixedAssetLedger_ByFixedAssetId(fixedAssetId).Where(x => x.RefNo == RefNo).ToList()[0] : null;

                var FixedAssetLedgerData =
                    FixedAssetLedgerDao.PostFixedAsset_GetLastedInfoForPost_ByFixedAssetId(fixedAssetId, PostedDate,
                        1, true, KeyValue);
                if (ActionMode == ActionModeVoucherEnum.Edit || ActionMode == ActionModeVoucherEnum.None)
                {
                    if (FixedAssetLedgerData != null && FixedAssetLedgerData.Count > 0)
                    {
                        FixedAssetLedgerData[0].OrgPriceDebitAmount =
                       FixedAssetLedgerData[0].OrgPriceDebitAmount +
                       (_fixedAssetModels.FirstOrDefault(x => x.FixedAssetId == fixedAssetId).OrgPrice -
                        FixedAssetLedgerData[0].OrgPriceDebitAmount);
                    }

                }
                foreach (var Detail in FixedAssetLedgerData)
                {
                    var fixedAssetModel =
                        _fixedAssetModels.FirstOrDefault(c => c.FixedAssetId == Detail.FixedAssetId);
                    if (Detail.OrgPriceDebitAmount ==
                        Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount)
                    {
                       if(item.Quantity != 0) amountPerOne = Detail.OrgPriceDebitAmount / item.Quantity;
                    }
                    if (Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount == 0)
                    {
                        if (item.Quantity != 0) amountPerOne = Detail.OrgPriceDebitAmount / item.Quantity;
                    }
                    if (Detail.OrgPriceDebitAmount !=
                        Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount &&
                        Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount != 0)
                    {
                        if (grdAccountingView.GetRowCellValue(e.RowHandle, "DebitAccount").ToString().StartsWith("214"))
                            amountPerOne = ActionMode == ActionModeVoucherEnum.AddNew ? (Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount) / item.Quantity : (((Detail.DepreciationCreditAmount / Detail.Quantity) + (Detail.DevaluationCreditAmount / Detail.Quantity)));
                        if (fixedAssetModel != null)
                        {
                            if (grdAccountingView.GetRowCellValue(e.RowHandle, "DebitAccount").ToString().StartsWith("366"))
                                amountPerOne = ActionMode == ActionModeVoucherEnum.AddNew ? (Detail.OrgPriceDebitAmount -
                                                (Detail.DepreciationCreditAmount + Detail.DevaluationCreditAmount)) / item.Quantity :
                                    (Detail.OrgPriceDebitAmount / item.Quantity -
                                     (((Detail.DepreciationCreditAmount / Detail.Quantity) + (Detail.DevaluationCreditAmount / Detail.Quantity))));
                        }
                    }
                }

                grdAccountingView.SetRowCellValue(e.RowHandle, "Amount",
                    (amountPerOne * (int)grdAccountingView.GetRowCellValue(e.RowHandle, e.Column.FieldName)));
                try
                {
                    for (int i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        if (grdAccountingView.GetRowCellValue(e.RowHandle, "FixedAssetId").ToString().Equals(grdAccountingView.GetRowCellValue(i, "FixedAssetId").ToString()))
                        {
                            if (grdAccountingView.GetRowCellValue(e.RowHandle, "Quantity").ToString() !=
                                grdAccountingView.GetRowCellValue(i, "Quantity").ToString())
                            {
                                grdAccountingView.SetRowCellValue(i, "Quantity", (int)grdAccountingView.GetRowCellValue(e.RowHandle, e.Column.FieldName));
                                break;
                            }
                        }
                    }
                }
                catch
                {

                }

            }
        }

       



        protected override void DeleteRowItem()
        {
            //base.DeleteRowItem();
            base.DeleteRowItem();
            ListSourceDetail = FAIncrementDecrementDetails.ToList();
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

        #region FAIncrementDecrement

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
                return FAIncrementDecrementDetails.Sum(x => x.Amount);

            }
            set { }
        }

        /// <summary>
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>
        /// The generated reference identifier.
        /// </value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets the fa increment decrement details.
        /// </summary>
        /// <value>
        /// The fa increment decrement details.
        /// </value>
        public List<FAIncrementDecrementDetailModel> OldFAIncrementDecrementDetails { get; set; }
        public IList<FAIncrementDecrementDetailModel> FAIncrementDecrementDetails
        {
            get
            {
                var fAIncrementDecrementDetails = new List<FAIncrementDecrementDetailModel>();

                //if (IsTwoRow == true)
                //{
                //    fAIncrementDecrementDetails = ListSourceDetail;
                //}
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (FAIncrementDecrementDetailModel)grdAccountingView.GetRow(i);
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
                            var item = new FAIncrementDecrementDetailModel
                            {
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                ActivityId = rowVoucher.ActivityId,
                                DepartmentId = rowVoucher.DepartmentId,
                                BankId = rowVoucher.BankId,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                DecreaseReasonId = rowVoucher.DecreaseReasonId,
                                FixedAssetId = rowVoucher.FixedAssetId,
                                FundStructureId = rowVoucher.FundStructureId,
                                ListItemId = rowVoucher.ListItemId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                ProjectActivityEAId = rowVoucher.ProjectActivityEAId,
                                ProjectActivityId = rowVoucher.ProjectActivityId,
                                ProjectExpenseEAId = rowVoucher.ProjectExpenseEAId,
                                ProjectId = rowVoucher.ProjectId,
                                SortOrder = i,
                                Quantity = rowVoucher.Quantity,
                            };
                            fAIncrementDecrementDetails.Add(item);
                        }
                    }
                }
                if (fAIncrementDecrementDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (FAIncrementDecrementDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                fAIncrementDecrementDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                fAIncrementDecrementDetails[i].ActivityId = rowVoucher.ActivityId;
                                fAIncrementDecrementDetails[i].ProjectId = rowVoucher.ProjectId;
                                fAIncrementDecrementDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                fAIncrementDecrementDetails[i].SortOrder =i;
                            }
                        }
                    }
                }
                return fAIncrementDecrementDetails;
            }
            set
            {

                OldFAIncrementDecrementDetails = value.ToList();
                if (IsTwoRow == true)
                {
                    value = ListSourceDetail.OrderBy(c => c.SortOrder).ToList();
                    // ListSourceDetail = null;
                    bindingSourceDetail.DataSource = ListSourceDetail;
                    grdAccountingView.PopulateColumns(ListSourceDetail);
                    grdAccountingDetailView.PopulateColumns(ListSourceDetail);
                }
                ListSourceDetail = value.ToList();
                //ListSourceDetail.ForEach(item =>
                //{
                //    if (item.Quantity == null) item.Quantity = 0;
                //   var _fixedAssetModelFirst = _fixedAssetModels.FirstOrDefault(f => f.FixedAssetId == item.FixedAssetId);
                //if(_fixedAssetModelFirst != null)
                //    {
                //        _fixedAssetModelFirst.Quantity += decimal.Parse(item.Quantity.ToString());
                //    }
                //});
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<FAIncrementDecrementDetailModel>();
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
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 80,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DepartmentId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDepartment,
                        ColumnWith = 80,
                        ColumnCaption = "Phòng/Ban",
                        ColumnPosition = 3,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 80,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCreditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Integer
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn{ColumnName = "AccountingObjectId",ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetProvideCode",ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "Chương",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn { ColumnName = "CashWithDrawTypeId",ColumnVisible = false,
                        ColumnWith = 80,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType },
                    new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "DecreaseReasonId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false }

                };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
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
                        ColumnName = "FixedAssetId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditFixedAsset,
                        ColumnWith = 80,
                        ColumnCaption = "Mã tài sản",
                        ColumnPosition = 1,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                    new XtraColumn{ColumnName = "DepartmentId",ColumnVisible = false},
                    new XtraColumn {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "Hoạt động SN",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId", ColumnVisible = true,
                        ColumnWith = 180,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn{ColumnName = "DebitAccount",ColumnVisible = false},
                    new XtraColumn{ColumnName = "CreditAccount",ColumnVisible = false},
                    new XtraColumn{ColumnName = "Amount",ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetProvideCode",ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetSourceId",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetChapterCode",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetKindItemCode",ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn{ColumnName = "BudgetSubKindItemCode",ColumnVisible = false},
                    new XtraColumn { ColumnName = "MethodDistributeId",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetItemCode",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetSubItemCode",ColumnVisible = false},
                    new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "DecreaseReasonId",
                        ColumnVisible = true,
                        RepositoryControl = _repositoryDecreaseReasonId,
                        ColumnCaption = "Lý do ghi giảm",
                        ColumnWith = 120,
                        AllowEdit = true,
                        ColumnPosition = 9
                    },
                    new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Quantity", ColumnVisible = false },
                };
                grdAccountingDetailView = InitGridLayout(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        #endregion

        #region IView Extens
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
        public List<DepartmentModel> OldDepartments { get; set; } = new List<DepartmentModel>();
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
                OldDepartments = value.ToList();
                _gridLookUpEditDepartmentView = XtraColumnCollectionHelper<DepartmentModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentCode), ColumnCaption = "Mã phòng/ban", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(DepartmentModel.DepartmentName), ColumnCaption = "Tên phòng/ban", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditDepartment = XtraColumnCollectionHelper<DepartmentModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDepartmentView, value, nameof(DepartmentModel.DepartmentName), nameof(DepartmentModel.DepartmentId), gridColumnsCollection);
                XtraColumnCollectionHelper<DepartmentModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDepartmentView);
            }
        }
        #endregion

        #region Accounts
        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<AccountModel>();
                    this.AccountLists = value;
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

                    _gridLookUpEditCreditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditCreditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditCreditAccountView, creditAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditCreditAccountView);

                    _gridLookUpEditAccountParallelView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccountParallel = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountParallelView, parallelAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountParallelView);

                    _gridLookUpEditTaxAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditTaxAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditTaxAccountView, value, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditTaxAccountView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (value == null)
                    return;
                // _listFixedAsset = value.ToList();

                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectCode), ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectName), ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, nameof(AccountingObjectModel.AccountingObjectCode), nameof(AccountingObjectModel.AccountingObjectId), gridColumnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountingObjectView);
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

                    if (value == null)
                        value = new List<BudgetKindItemModel>();

                    value = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemCode), ColumnCaption = "Mã khoản", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetKindItemModel.BudgetKindItemName), ColumnCaption = "Tên khoản", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, nameof(BudgetKindItemModel.BudgetKindItemCode), nameof(BudgetKindItemModel.BudgetKindItemCode), gridColumnsCollection);
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

        #region FixedAssets
        public List<FixedAssetModel> OldFixedAssets { get; set; } = new List<FixedAssetModel>();
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
                    _fixedAssetModelsTemp = value.ToList();

                    #region Cộng lại các giá trị của TSCD với trường hợp sửa
                    if (ActionMode == ActionModeVoucherEnum.Edit || ActionMode == ActionModeVoucherEnum.None)
                    {
                        var a = FAIncrementDecrementDetails;
                        var count = -1;
                        bool qltyPlus = false;
                        foreach (var item in _fixedAssetModels)
                        {
                            qltyPlus = false;
                            count++;
                            foreach (var item2 in FAIncrementDecrementDetails)
                            {
                                if (item.FixedAssetId.Equals(item2.FixedAssetId))
                                {
                                    var FixedAssetLedgerData =
                                        FixedAssetLedgerDao.PostFixedAsset_GetLastedInfoForPost_ByFixedAssetId(item.FixedAssetId, PostedDate,
                                            1, true);
                                    if (!qltyPlus)
                                    {

                                        item.Quantity = _fixedAssetModelsTemp[count].Quantity + (int)item2.Quantity;
                                        qltyPlus = true;
                                    }
                                    item.OrgPrice = _fixedAssetModels[count].OrgPrice +
                                                                     (int)item2.Amount;
                                    //break;
                                }
                            }
                        }
                    }
                    #endregion

                    if (value == null)
                        return;
                    // _listFixedAsset = value.ToList();
                    OldFixedAssets = value.ToList();
                    _gridLookUpEditFixedAssetView = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridViewReponsitory();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetCode), ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(FixedAssetModel.FixedAssetName), ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    _gridLookUpEditFixedAsset = XtraColumnCollectionHelper<FixedAssetModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFixedAssetView, value, nameof(FixedAssetModel.FixedAssetCode), nameof(FixedAssetModel.FixedAssetId), gridColumnsCollection);
                    XtraColumnCollectionHelper<FixedAssetModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFixedAssetView);
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

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                //_gridLookUpEditActivity.PopupFormSize = new Size(268, 150);
                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ActivityModel.ActivityName), ColumnCaption = "Hoạt động sự nghiệp", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

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

        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;

        }
    }
}
