/***********************************************************************
 * <copyright file="FrmBUPlanWithdrawCashDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 2, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 2, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmBUPlanWithdrawCashDetail.   
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IActivitysView" />
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUTransferView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.ICashWithdrawTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    public partial class FrmBUTransfersPayInsurranceDetail : FrmXtraBaseVoucherDetail, IBUTransferPayWageView, ICashWithdrawTypesView,
        IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView
        , IAccountsView, IBudgetItemsView, IProjectsView, IFundStructuresView, IBanksView, IAccountingObjectsView, IActivitysView, IBudgetExpensesView
    {

        #region Variable
        /// <summary>
        /// Tài khoản nợ ngầm định
        /// </summary>
        AccountModel _defaultDebitAccount;

        /// <summary>
        /// Tài khoản có ngầm định
        /// </summary>
        AccountModel _defaultCreditAccount;

        /// <summary>
        /// Danh sách tài khoản
        /// </summary>
        List<AccountModel> _listAccounts;
        #endregion

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        /// _gridLookUpEditBudgetExpense
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetExpense;
        /// <summary>
        /// _gridLookUpEditBudgetExpenseView
        /// </summary>
        private GridView _gridLookUpEditBudgetExpenseView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit cash withdraw type
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCashWithdrawType;

        /// <summary>
        /// The grid look up edit cash withdraw type view
        /// </summary>
        private GridView _gridLookUpEditCashWithdrawTypeView;

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
        /// The grid look up edit account_gridLookUpEditAccount
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The budget kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetKindItemModels;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        /// <summary>
        /// The grid look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountParallel;
        private GridView _gridLookUpEditAccountParallelView;
        private IList<BudgetItemModel> _budgetSubItemModels;
        private IList<BudgetItemModel> _budgetItemModels;

        #endregion

        #region Presenter
        private readonly BudgetExpensesPresenter _budgetExpensePresenter;

        public List<BUTransferDetailModel> ListSendSourceDetail;
        public bool IsOpenFrmBUTransferPayWageDetail;
        public BUTransferModel buTTransferModel;

        /// <summary>
        /// The b u plan withdraw presenter
        /// </summary>
        private readonly BUTransferPayWagePresenter _bUTransferPayWagePresenter;

        /// <summary>
        /// The banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        /// <summary>
        /// The cash withdraw type models
        /// </summary>
        private List<CashWithdrawTypeModel> _cashWithdrawTypeModels;

        /// <summary>
        /// The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The activitys presenter
        /// </summary>
        private readonly ActivitysPresenter _activitysPresenter;

        #endregion
        public List<SelectItemModel> Parallels { get; set; }
        /// <summary>

        /// </summary>
        public FrmBUTransfersPayInsurranceDetail()
        {
            InitializeComponent();
            _bUTransferPayWagePresenter = new BUTransferPayWagePresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _budgetExpensePresenter = new BudgetExpensesPresenter(this);
            _model = new Model.Model();

        }

        #region overrides

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Visible = true;
            grdMaster.Location = new Point(7, 280);
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisPlayForFAIncrementDecrement();
            _budgetItemsPresenter.DisplayActive(true);
            _fundStructuresPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _banksPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayActive(true);
            _activitysPresenter.DisplayActive(true);
            _budgetExpensePresenter.DisplayActive();
            InitRepositoryControlData();
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                KeyValue = ((BUTransferModel)MasterBindingSource.Current).RefId;
            _bUTransferPayWagePresenter.Display(KeyValue);
            if (RefType == 0)
            {
                RefType = (int)BuCA.Enum.RefType.BUTransferPayInsurrance;
                Posted = true;

            }
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {

            }

            if (IsOpenFrmBUTransferPayWageDetail && buTTransferModel != null)
            {
                IsOpenFrmBUTransferPayWageDetail = false;
                AccountingObjectId = buTTransferModel.AccountingObjectId;
                JournalMemo = buTTransferModel.JournalMemo;
                BasePostedDate = buTTransferModel.PostedDate;
                CurrencyCode = buTTransferModel.CurrencyCode;
                ExchangeRate = (decimal)buTTransferModel.ExchangeRate;
                TotalAmount = buTTransferModel.TotalAmount;
                TotalAmountOC = buTTransferModel.TotalAmountOC;
                BUPlanWithdrawRefId = buTTransferModel.RefId;
                TargetProgramId = buTTransferModel.TargetProgramId;
                BankInfoId = buTTransferModel.BankInfoId;
                ExchangeRate = buTTransferModel.ExchangeRate;
                BUCommitmentRequestId = buTTransferModel.BUCommitmentRequestId;
                Amount = buTTransferModel.TotalAmount;
            }
        }

        public string BUPlanWithdrawRefId { get; set; }

        /// <summary>
        /// Enables the control.
        /// </summary>
        protected override void EnableControl()
        {

            // cboBankPay.Enabled = true;
            //// cboAccountingObject.Enabled = true;
            // cboBankPay.Enabled = true;
            // cboTargetProgramId.Enabled = true;
            //// txtJournalMemo.Enabled = true;
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _bUTransferPayWagePresenter.Display(KeyValue);
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupControl1, isEnable);
            EnableControlsInGroup(groupControl2, isEnable);
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if , <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
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
            var bUTransferDetails = BUTransferDetails;
            if (bUTransferDetails.Count == 0)
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
                view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
                view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 0);
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
                view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
                view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 0);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the detail row
        /// </summary>
        /// <param name="e"></param>
        /// <param name="view"></param>
        protected override void InitDetailRowForAcountingDetailByInventoryItem(InitNewRowEventArgs e, GridView view)
        {
            if (_defaultDebitAccount != null)
                view.SetRowCellValue(e.RowHandle, "DebitAccount", _defaultDebitAccount.AccountNumber);
            if (_defaultCreditAccount != null)
                view.SetRowCellValue(e.RowHandle, "CreditAccount", _defaultCreditAccount.AccountNumber);
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BUTransferPresenter(null).Delete(KeyValue);
            string refNo = new GLVoucherPresenter(null).GetGLVoucherByBUTransferRefId(KeyValue);
            if (refNo.Length > 0)
            {
                DialogResult dialog = XtraMessageBox.Show(string.Format("Bạn có muốn xóa chứng từ chung số {0} không?", refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    new GLVoucherPresenter(null).DeleteGLVoucherByBUTransferRefId(KeyValue);
                }
            }

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
            cboBankPay.Enabled = false;
            //   cboAccountingObject.Enabled = false;
            cboBankPay.Enabled = false;
            cboTargetProgramId.Enabled = false;
            //  txtJournalMemo.Enabled = false;
            //txtDocumentInclude.ReadOnly = true;
            //txtTaxCode.ReadOnly = true;
            //var result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không ?", "Định khoản đồng thời",
            // MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //return result == DialogResult.OK ? _bUTransferPayWagePresenter.Save(true) : _bUTransferPayWagePresenter.Save(false);

            var sResult = _bUTransferPayWagePresenter.Save(true);
            //Liên kết chứng từ chuyển khoản KB trả lương với chứng từ tính lương (_hay còn gọi là chứng từ chung)
            if (!string.IsNullOrEmpty(sResult))
            {
                string glVoucherRefNo = new GLVoucherPresenter(null).GetGLVoucherByBUTransferRefId(RefId);
                DialogResult dialog = DialogResult.No;
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        dialog = XtraMessageBox.Show("Bạn có muốn sinh chứng từ xác định bảo hiểm tại chứng từ chung không?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case ActionModeVoucherEnum.Edit:
                        if (!string.IsNullOrEmpty(glVoucherRefNo))

                            //  Chứng từ chuyển khoản trả lương, bảo hiểm hiện thời đã sinh chứng từ xác định lương số { số chứng từ chung}, bạn có muốn sửa chứng từ này không?”
                            dialog = XtraMessageBox.Show(string.Format("Bạn có muốn đồng bộ các thông tin đã cập nhật trên chứng từ chuyển khoản trả bảo hiểm với chứng từ chung số {0}?", this.LinkRefNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        else
                            dialog = XtraMessageBox.Show("Bạn có muốn sinh chứng từ xác định bảo hiểm tại chứng từ chung không?", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                }

                if (dialog == DialogResult.Yes)
                {
                    var frmGLVoucherDetail = new FrmGLVoucherDetail();
                    frmGLVoucherDetail.ActionMode = string.IsNullOrEmpty(glVoucherRefNo) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                    frmGLVoucherDetail.KeyValue = string.IsNullOrEmpty(gLVouchersRefId) ? null : gLVouchersRefId;
                    var _source = this.bindingSourceDetail.DataSource;
                    var _listDetail = new List<BUTransferDetailModel>();
                    if (_source != null)
                        _listDetail = (List<BUTransferDetailModel>)_source;
                    var _listDetailSend = _listDetail.Select(m => Mapper.AutoMapper(m, new GLVoucherDetailModel())).ToList();
                    var _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
                    var _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BuCA.Enum.RefType.GLVoucher, RefTypes.ToList());
                    var _list = new List<GLVoucherDetailModel>();
                    #region list sent 
                    //foreach (var rowVoucher in _listDetailSend)
                    //{

                    //    if (rowVoucher.BudgetItemCode == "6000" || rowVoucher.BudgetItemCode == "6100")
                    //    {
                    //        var row1 = new GLVoucherDetailModel()
                    //        {
                    //            Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                    //            DebitAccount = "3341",
                    //            // Amount = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.Amount * 80 / 105 : Row.Amount,
                    //            CreditAccount = rowVoucher.CreditAccount == "332" ? "332" : "",
                    //            Amount =
                    //                    ExchangeRate == null
                    //                        ? rowVoucher.AmountOC
                    //                        : (decimal)(rowVoucher.AmountOC * ExchangeRate),
                    //            AmountOC = rowVoucher.AmountOC,
                    //            BudgetSourceId = rowVoucher.BudgetSourceId,
                    //            BudgetChapterCode = rowVoucher.BudgetChapterCode,

                    //            BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                    //            BudgetItemCode = rowVoucher.BudgetItemCode,
                    //            BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                    //            MethodDistributeId = rowVoucher.MethodDistributeId,
                    //            CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                    //            ProjectId = rowVoucher.ProjectId,
                    //            AccountingObjectId = rowVoucher.AccountingObjectId,
                    //            CreditAccountingObjectId = rowVoucher.CreditAccountingObjectId,

                    //        };
                    //        _list.Add(row1);

                    //        //var row2 = new GLVoucherDetailModel()
                    //        //{
                    //        //    Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                    //        //    DebitAccount = "61111",
                    //        //    CreditAccount = "3341",
                    //        //    Amount =
                    //        //   ExchangeRate == null
                    //        // ? rowVoucher.AmountOC
                    //        // : (decimal)(rowVoucher.AmountOC * ExchangeRate),
                    //        //    AmountOC = rowVoucher.AmountOC,
                    //        //    BudgetSourceId = rowVoucher.BudgetSourceId,
                    //        //    BudgetChapterCode = rowVoucher.BudgetChapterCode,

                    //        //    BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                    //        //    BudgetItemCode = rowVoucher.BudgetItemCode,
                    //        //    BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                    //        //    MethodDistributeId = rowVoucher.MethodDistributeId,
                    //        //    CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                    //        //    ProjectId = rowVoucher.ProjectId,
                    //        //    AccountingObjectId = rowVoucher.AccountingObjectId,
                    //        //    CreditAccountingObjectId = rowVoucher.CreditAccountingObjectId,

                    //        //};
                    //        //_list.Add(row2);
                    //    }
                    //    else
                    //    {
                    //        var row0 = new GLVoucherDetailModel()
                    //        {
                    //            Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                    //            DebitAccount = "61111", 
                    //            CreditAccount = rowVoucher.CreditAccount ,
                    //            Amount =
                    //                 ExchangeRate == null
                    //                     ? rowVoucher.AmountOC
                    //                     : (decimal)(rowVoucher.AmountOC * ExchangeRate),
                    //            AmountOC = rowVoucher.AmountOC,
                    //            BudgetSourceId = rowVoucher.BudgetSourceId,
                    //            BudgetChapterCode = rowVoucher.BudgetChapterCode,

                    //            BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                    //            BudgetItemCode = rowVoucher.BudgetItemCode,
                    //            BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                    //            MethodDistributeId = rowVoucher.MethodDistributeId,
                    //            CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                    //            ProjectId = rowVoucher.ProjectId,
                    //            AccountingObjectId = rowVoucher.AccountingObjectId,
                    //            CreditAccountingObjectId = rowVoucher.CreditAccountingObjectId,

                    //        };
                    //        _list.Add(row0);
                    //    }
                    //}
                    // _listDetailSend = _list;
                    #endregion 
                    frmGLVoucherDetail.ListSendSourceDetail = _listDetailSend;
                    frmGLVoucherDetail.IsOpenFrmGLVoucherDetail = true;
                    frmGLVoucherDetail.IsPaymenInsurrance = true;
                    // Thông tin master
                    var item = new GLVoucherModel()
                    {
                        //AccountingObjectId = AccountingObjectId,
                        JournalMemo = JournalMemo,
                        PostedDate = PostedDate,
                        RefDate = RefDate,
                        CurrencyCode = CurrencyCode,
                        ExchangeRate = ExchangeRate,
                        TotalAmount = TotalAmount,
                        TotalAmountOC = TotalAmountOC,
                        RefId = sResult,
                        LinkRefNo = this.LinkRefNo,
                    };
                    frmGLVoucherDetail.gLVoucherModel = item;
                    frmGLVoucherDetail.ShowDialog();
                    gLVouchersRefId = frmGLVoucherDetail.RefId;
                    this.LinkRefNo = frmGLVoucherDetail.RefNo;
                }
            }
            return sResult;
        }

        public string gLVouchersRefId { get; set; }

        public string LinkRefNo { get; set; }

        protected override bool ValidEdit()
        {
            string glVoucherRefNo = new GLVoucherPresenter(null).GetGLVoucherByBUTransferRefId(RefId);
            if (!string.IsNullOrEmpty(glVoucherRefNo))
                //if (!string.IsNullOrEmpty(gLVouchersRefId))
                return XtraMessageBox.Show(string.Format("Chứng từ chuyển khoản kho bạc trả bảo hiểm hiện thời đã sinh chứng từ chung số {0}, bạn có muốn sửa chứng từ này không?", glVoucherRefNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            return true;
        }
        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        //protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        //{
        //    IModel model = new Model.Model();
        //    if (e.Column.FieldName == "AmountOC")
        //    {
        //        decimal totalAmountOc = 0;
        //        grdAccounting.RefreshDataSource();
        //        for (var i = 0; i < grdAccountingView.RowCount; i++)
        //        {
        //            var rowVoucher = (BUTransferDetailModel)grdAccountingView.GetRow(i);
        //            if (rowVoucher != null)
        //                totalAmountOc += rowVoucher.AmountOC;
        //        }
        //        if (IsCopyRow)
        //            totalAmountOc += (decimal)e.Value;
        //        gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOc);
        //    }
        //    if (e.Column.FieldName == "BudgetSubItemCode")
        //    {
        //        var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
        //        var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

        //        foreach (var item in budgetItem)
        //        {
        //            var budgetItemCode = model.GetBudgetItem(item.ParentId);
        //            grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
        //        }

        //    }
        //}

        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
           
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode") == null ? null : (string)grdAccountingView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetSubItem = _budgetSubItemModels.FirstOrDefault(x => x.BudgetItemCode == budgetSubItemCode);
                if (budgetSubItem != null)
                {
                    var budgetItem = _budgetItemModels.FirstOrDefault(x => x.BudgetItemId == budgetSubItem.ParentId);
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItem == null ? "" : budgetItem.BudgetItemCode);
                }
            }
        }
        #endregion

        protected override void GridPurchaseCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
           
            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = _budgetItemsPresenter.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var budgetItemCode = _budgetItemsPresenter.GetBudgetItem(item.ParentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }
            }
            if (e.Column.FieldName == "BudgetSubKindItemCode")
            {
                var budgetSubItemCode = (string)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "BudgetSubKindItemCode");
                var budgetItem = _budgetSubKindItemModels.Where(x => x.BudgetKindItemCode == budgetSubItemCode);
                foreach (var item in budgetItem)
                {
                    var budgetKindItemCode = _budgetKindItemsPresenter.GetBudgetKindItem(item.ParentId);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "BudgetKindItemCode", budgetKindItemCode.BudgetKindItemCode);
                }
            }
        }
        #region private helper

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
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

            //var vatRates = new Dictionary<string, string> { { "0", "0%" }, { "10", "10%" }, { "15", "15%" }, { "", "KCT" } };
            //_repositoryVATRate = new RepositoryItemLookUpEdit
            //{
            //    DataSource = vatRates,
            //    AllowNullInput = DefaultBoolean.True,
            //    NullText = null,
            //    NullValuePrompt = null,
            //    DisplayMember = "Value",
            //    ValueMember = "Key",
            //    ShowHeader = false
            //};

            //_repositoryVATRate.PopulateColumns();
            //_repositoryVATRate.Columns["Key"].Visible = false;

            //var invoiceTypes = typeof(InvoiceType).ToList();
            //_repositoryInvType = new RepositoryItemLookUpEdit
            //{
            //    DataSource = invoiceTypes,
            //    AllowNullInput = DefaultBoolean.True,
            //    NullText = null,
            //    NullValuePrompt = null,
            //    DisplayMember = "Value",
            //    ValueMember = "Key",
            //    ShowHeader = false
            //};
            //_repositoryInvType.PopulateColumns();
            //_repositoryInvType.Columns["Key"].Visible = false;
        }

        #endregion

        #region IView BUTransfer

        public IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }


        public bool Approved
        {
            get; set;
        }

        public IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases
        {
            get; set;
        }

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
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
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
        /// <value>The paralell reference no.</value>
        public string ParalellRefNo
        {
            get { return txtBUCommitmentRequest.Text; }
            set { txtBUCommitmentRequest.Text = value; }
        }

        /// <summary>
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        public string TargetProgramId
        {
            get { return cboTargetProgramId.EditValue == null ? null : cboTargetProgramId.EditValue.ToString(); }
            set
            {
                cboTargetProgramId.EditValue = value;
                if (cboTargetProgramId.EditValue != null)
                {
                    var targetProgramName = (string)cboTargetProgramId.GetColumnValue("ProjectName");
                    txtTargetProgramName.Text = targetProgramName;
                }
            }
        }

        ///// <summary>
        ///// Gets or sets the bank identifier.
        ///// </summary>
        ///// <value>The bank identifier.</value>
        //public string BankId
        //{
        //    get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
        //    set
        //    {
        //        cboBankPay.EditValue = value;
        //        if (cboBankPay.EditValue != null)
        //        {
        //            var address = (string)cboBankPay.GetColumnValue("BankName");
        //            txtBank.Text = address;
        //        }
        //    }
        //}

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get { return lookUpEditAccountingObject.EditValue == null ? null : lookUpEditAccountingObject.EditValue.ToString(); }
            set
            {
                lookUpEditAccountingObject.EditValue = value;
                if (lookUpEditAccountingObject.EditValue != null)
                {
                    var accountingObject = (string)lookUpEditAccountingObject.GetColumnValue("AccountingObjectName");
                    txtAccountingObjectName.Text = accountingObject;
                }
            }
        }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo
        {
            get { return txtDocumentIncluded.Text; }
            set { txtDocumentIncluded.Text = value; }
        }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
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
        /// Gets or sets the accounting object bank identifier.
        /// </summary>
        /// <value>The accounting object bank identifier.</value>
        public string AccountingObjectBankId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                    txtBankPayName.Text = address;
                }
            }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
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
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>The generated reference identifier.</value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BUPlanWithdrawEntity" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyId
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }

        /// <summary>
        /// Gets or sets the bank information identifier.
        /// </summary>
        /// <value>The bank information identifier.</value>
        public string BankInfoId
        {
            get { return cboBankPay.EditValue == null ? null : cboBankPay.EditValue.ToString(); }
            set
            {
                cboBankPay.EditValue = value;
                if (cboBankPay.EditValue != null)
                {
                    var address = (string)cboBankPay.GetColumnValue("BankName");
                    txtBank.Text = address;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object.
        /// </summary>
        /// <value>The name of the accounting object.</value>
        public string AccountingObjectName
        {
            get { return txtAccountingObjectName.Text; }
            set { txtAccountingObjectName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object address.
        /// </summary>
        /// <value>The accounting object address.</value>
        public string AccountingObjectAddress
        {
            get { return txtAccountingObjectAddress.Text; }
            set { txtAccountingObjectAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the accounting object bank account.
        /// </summary>
        /// <value>The accounting object bank account.</value>
        public string AccountingObjectBankAccount
        {
            get { return txtAccountingObjectBankAccount.Text; }
            set { txtAccountingObjectBankAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the accounting object bank.
        /// </summary>
        /// <value>The name of the accounting object bank.</value>
        public string AccountingObjectBankName
        {
            get { return txtAccountingObjectBankName.Text; }
            set { txtAccountingObjectBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document included.
        /// </summary>
        /// <value>The document included.</value>
        public string DocumentIncluded
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the inward stock reference no.
        /// </summary>
        /// <value>The inward stock reference no.</value>
        public string InwardStockRefNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the withdraw reference date.
        /// </summary>
        /// <value>The withdraw reference date.</value>
        public DateTime? WithdrawRefDate
        {
            get { return dateWithdrawRefDate.EditValue == null ? DateTime.Now : (DateTime)dateWithdrawRefDate.EditValue; }
            set { dateWithdrawRefDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the withdraw reference no.
        /// </summary>
        /// <value>The withdraw reference no.</value>
        public string WithdrawRefNo
        {
            get { return txtWithdrawRefNo.Text; }
            set { txtWithdrawRefNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the increment reference no.
        /// </summary>
        /// <value>The increment reference no.</value>
        public string IncrementRefNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total tax amount.
        /// </summary>
        /// <value>The total tax amount.</value>
        public decimal TotalTaxAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total freight amount.
        /// </summary>
        /// <value>The total freight amount.</value>
        public decimal TotalFreightAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total inward amount.
        /// </summary>
        /// <value>The total inward amount.</value>
        public decimal TotalInwardAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the edit version.
        /// </summary>
        /// <value>The edit version.</value>
        public int? EditVersion
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference order.
        /// </summary>
        /// <value>The reference order.</value>
        public int? RefOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the relation reference identifier.
        /// </summary>
        /// <value>The relation reference identifier.</value>
        public string RelationRefId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total fixed asset amount.
        /// </summary>
        /// <value>The total fixed asset amount.</value>
        public decimal TotalFixedAssetAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the bu transfer details.
        /// </summary>
        /// <value>The bu transfer details.</value>
        public IList<BUTransferDetailModel> BUTransferDetails
        {
            get
            {
                var bUTransferDetails = new List<BUTransferDetailModel>();

                #region Tab Hạch toán

                if (grdDetailByInventoryItemView.DataSource != null && grdDetailByInventoryItemView.RowCount > 0)
                {
                    for (var i = 0; i < grdDetailByInventoryItemView.RowCount; i++)
                    {
                        var rowVoucher = (BUTransferDetailModel)grdDetailByInventoryItemView.GetRow(i);
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
                            var item = new BUTransferDetailModel
                            {
                                Description = rowVoucher.Description,
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount = rowVoucher.Amount == 0 ? rowVoucher.AmountOC : rowVoucher.Amount,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                AmountOC = rowVoucher.AmountOC,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                FundStructureId = rowVoucher.FundStructureId,
                                ListItemId = rowVoucher.ListItemId,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                OrgRefNo = rowVoucher.OrgRefNo,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                BankId = rowVoucher.BankId,
                                SortOrder = i,
                                ProjectId = rowVoucher.ProjectId,
                                AccountingObjectId =rowVoucher.AccountingObjectId,
                                ActivityId  = rowVoucher.ActivityId
                            };
                            bUTransferDetails.Add(item);
                        }
                    }
                }
                #endregion

                #region Tab thống kê

                if (bUTransferDetails.Count > 0)
                {
                    if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingView.RowCount; i++)
                        {
                            var rowVoucher = (BUTransferDetailModel)grdAccountingView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bUTransferDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                bUTransferDetails[i].ActivityId = rowVoucher.ActivityId;
                                bUTransferDetails[i].FundStructureId = rowVoucher.FundStructureId;
                                bUTransferDetails[i].BudgetExpenseId = rowVoucher.BudgetExpenseId;
                                bUTransferDetails[i].ProjectId = rowVoucher.ProjectId;
                            }
                        }
                    }
                }

                #endregion

                #region Tab Hạch toán đồng thời

                if (bUTransferDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (BUTransferDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                bUTransferDetails[i].ProjectId = rowVoucher.ProjectId;
                                bUTransferDetails[i].ActivityId = rowVoucher.ActivityId;
                                bUTransferDetails[i].FundStructureId = rowVoucher.FundStructureId;
                            }
                        }
                    }
                }

                #endregion
                return bUTransferDetails;

            }
            set
            {
                // Lấy dữ liệu từ form rút dự toán truyền sang
                if (IsOpenFrmBUTransferPayWageDetail)
                {
                    value = ListSendSourceDetail;
                    ListSendSourceDetail = null;
                }
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUTransferDetailModel>();
                grdDetailByInventoryItemView.PopulateColumns(value);
                grdAccountingView.PopulateColumns(value);
                grdAccountingDetailView.PopulateColumns(value);


                #region Colunms for grdDetailByInventoryItemView

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số chứng từ gốc",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = true,
                        ColumnWith = 130,
                        ColumnCaption = "Ngày chứng từ gốc",
                        ColumnPosition = 2,
                        AllowEdit = true,
                    },

                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 3,
                        AllowEdit = true,
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
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Chương",
                        ColumnPosition = 8,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetChapter
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 9,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 10,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSubItem
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Mục",
                        ColumnPosition = 11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn {
                        ColumnName = "FundStructureId",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditFundStructure
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        RepositoryControl = _repositoryMethodDistributeId
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankId",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 14,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBank
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = true,
                        ColumnWith = 330,
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 15,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCashWithdrawType
                    },
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawDetailId", ColumnVisible = false}
                };
                grdDetailByInventoryItemView = InitGridLayout(columnsCollection, grdDetailByInventoryItemView);
                SetNumericFormatControl(grdDetailByInventoryItemView, true);
                grdDetailByInventoryItemView.OptionsView.ShowFooter = false;

                #endregion

                #region Colunms for grdAccountingView

                columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},

                    new XtraColumn
                    {
                        ColumnName = "OrgRefNo",
                        ColumnVisible = false
                    },
                     new XtraColumn
                    {
                        ColumnName = "OrgRefDate",
                        ColumnVisible = false
                    },

                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 300,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                     new XtraColumn
                    {
                        ColumnName = "CreditAccount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "TK Có",
                        ColumnPosition = 3,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccount
                    },
                    new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                        ColumnWith = 100,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },
                     new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Đối tượng",
                        ColumnPosition = 4,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditAccountingObject
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectId",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "CTMT, dự án",
                        ColumnPosition = 5,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditProject
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetExpenseId",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Phí lệ phí",
                        ColumnPosition = 6,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetExpense
                    },
                       new XtraColumn
                    {
                        ColumnName = "ActivityId",
                        ColumnVisible = true,
                        ColumnWith = 1020,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 7,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditActivity
                    },


                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
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
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn {
                        ColumnName = "BudgetItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "MethodDistributeId",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawTypeId",
                        ColumnVisible = false
                    },
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "WithdrawDetailId", ColumnVisible = false}
                };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;

                #endregion

                #region Colunms for grdAccountingDetailView

                columnsCollection = new List<XtraColumn>
                {
                        new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                         new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                         new XtraColumn {ColumnName = "AmountOC", ColumnVisible = false},
                         new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
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
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "WithdrawRefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive).ToList();
                    
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
                    _listAccounts = value.ToList();

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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                cboTargetProgramId.Properties.DataSource = value;

                cboTargetProgramId.Properties.PopulateColumns();
                XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboTargetProgramId);

                cboTargetProgramId.Properties.DisplayMember = "ProjectCode";
                cboTargetProgramId.Properties.ValueMember = "ProjectId";
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

                cboBankPay.Properties.DataSource = value;
                cboBankPay.Properties.PopulateColumns();
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBankPay);

                cboBankPay.Properties.DisplayMember = "BankAccount";
                cboBankPay.Properties.ValueMember = "BankId";
            }
        }

        #endregion

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                lookUpEditAccountingObject.Properties.DataSource = value;
                lookUpEditAccountingObject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đơn vị",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đơn vị",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 330
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
                    new XtraColumn {ColumnName = "OrganizationManageFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryManageFee", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpEditAccountingObject.Properties.SortColumnIndex = column.ColumnPosition;
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        lookUpEditAccountingObject.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                lookUpEditAccountingObject.Properties.DisplayMember = "AccountingObjectCode";
                lookUpEditAccountingObject.Properties.ValueMember = "AccountingObjectId";

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

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectCode";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                //Filter cho gridview
                _gridLookUpEditAccountingObjectView = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridViewReponsitory();
                _gridLookUpEditAccountingObject = XtraColumnCollectionHelper<AccountingObjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountingObjectView, value, "AccountingObjectCode", "AccountingObjectId", columnsCollection);
                XtraColumnCollectionHelper<AccountingObjectModel>.ShowXtraColumnInGridView(columnsCollection, _gridLookUpEditAccountingObjectView);

                #endregion
            }
        }

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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(ActivityModel.ActivityName), ColumnCaption = "Công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, nameof(ActivityModel.ActivityName), nameof(ActivityModel.ActivityId), gridColumnsCollection);
                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
            }
        }

        #endregion

        public IList<BUTransferDetailParallelModel> BuTransferDetailParallel
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var withDrawDetailParallels = new List<BUTransferDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUTransferDetailParallelModel)grdViewAccountingParallel.GetRow(i);
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
                            var item = new BUTransferDetailParallelModel()
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
                                SortOrder = rowVoucher.SortOrder ?? i,
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
                bindingSourceDetailParallel.DataSource = value ?? new List<BUTransferDetailParallelModel>();
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
                        ColumnWith = 300,
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
                        ColumnWith = 120,
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
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false}, //chon thang subkinditem la ra kinditem
                    new XtraColumn {
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
                    new XtraColumn {
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
                    new XtraColumn {
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
                        RepositoryControl = _gridLookUpEditBudgetExpense
                    },
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
                };

                grdViewAccountingParallel.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                #endregion
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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseCode), ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BudgetExpenseModel.BudgetExpenseName), ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                _gridLookUpEditBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, nameof(BudgetExpenseModel.BudgetExpenseName), nameof(BudgetExpenseModel.BudgetExpenseId), gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);
            }
        }
        #endregion		
        #endregion

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

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
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
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the InitNewRow event of the grdViewAccountingParallel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs"/> instance containing the event data.</param>
        private void grdViewAccountingParallel_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetSourceId), GlobalVariable.DefaultBudgetSourceID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetChapterCode), GlobalVariable.DefaultBudgetChapterCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetKindItemCode), GlobalVariable.DefaultBudgetKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.BudgetSubKindItemCode), GlobalVariable.DefaultBudgetSubKindItemCode);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.CashWithdrawTypeId), GlobalVariable.DefaultCashWithDrawTypeID);
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, nameof(BUTransferDetailParallelModel.MethodDistributeId), GlobalVariable.DefaultMethodDistributeID);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event control

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountingObjectName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");

            cboObjectName.Text = accountingObjectName;
            txtAddress.Text = address;
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
            cboBank.Text = bankName;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboAccountingObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboAccountingObject_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditAccountingObject.EditValue == null)
                return;
            var accountingObjectName = (string)lookUpEditAccountingObject.GetColumnValue("AccountingObjectName");

            txtAccountingObjectName.Text = accountingObjectName;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboTargetProgramId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboTargetProgramId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTargetProgramId.EditValue == null)
                return;
            var projectName = (string)cboTargetProgramId.GetColumnValue("ProjectName");

            txtTargetProgramName.Text = projectName;

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoProjectId = TargetProgramId;
                SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBankPay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBankPay_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankPay.EditValue == null)
                return;
            var bankName = (string)cboBankPay.GetColumnValue("BankName");
            txtBankPayName.Text = bankName;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoBankId = BankInfoId;
                SetDetailFromMaster(grdAccountingView, 2, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditAccountingObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookUpEditAccountingObject_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditAccountingObject.EditValue == null)
                return;
            var accountingObjectName = (string)lookUpEditAccountingObject.GetColumnValue("AccountingObjectName");
            var accountingObjectAddress = (string)lookUpEditAccountingObject.GetColumnValue("Address");
            var bankAccount = (string)lookUpEditAccountingObject.GetColumnValue("BankAccount");
            var bankName = (string)lookUpEditAccountingObject.GetColumnValue("BankName");

            txtAccountingObjectName.Text = accountingObjectName;
            txtAccountingObjectAddress.Text = accountingObjectAddress;
            txtAccountingObjectBankAccount.Text = bankAccount;
            txtAccountingObjectBankName.Text = bankName;

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankInfoId, TargetProgramId);
            }
        }

        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBUTransfersPayInsurranceDetail_Load(object sender, EventArgs e)
        {
            _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
            _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BaseRefTypeId, RefTypes.ToList());
            AutoProjectId = TargetProgramId;
            AutoBankId = BankInfoId;
            AutoAccountingObjectId = AccountingObjectId;
        }

        private void grdAccountingParallel_Click(object sender, EventArgs e)
        {

        }

        protected override void SetAutoNumber()
        {
            try
            {
                grdDetailByInventoryItemView.AddNewRow();
                var rowHandle = grdDetailByInventoryItemView.GetSelectedRows()[0];
                if (AutoBusinessModel.BudgetSourceId != (new Guid()).ToString())
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSourceId", AutoBusinessModel.BudgetSourceId);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetChapterCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetChapterCode", AutoBusinessModel.BudgetChapterCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetKindItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetKindItemCode", AutoBusinessModel.BudgetKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubKindItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubKindItemCode", AutoBusinessModel.BudgetSubKindItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetSubItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetSubItemCode", AutoBusinessModel.BudgetSubItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.BudgetItemCode))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "BudgetItemCode", AutoBusinessModel.BudgetItemCode);
                if (!string.IsNullOrEmpty(AutoBusinessModel.AutoBusinessName))
                    grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "Description", AutoBusinessModel.AutoBusinessName);
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "DebitAccount", AutoBusinessModel.DebitAccount.Replace("\r\n", ""));
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CreditAccount", AutoBusinessModel.CreditAccount.Replace("\r\n", ""));
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "MethodDistributeId", AutoBusinessModel.MethodDistributeId);
                grdDetailByInventoryItemView.SetRowCellValue(rowHandle, "CashWithDrawTypeId", AutoBusinessModel.CashWithDrawTypeId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        private void FrmBUTransfersPayInsurranceDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, true);
        }

        private void grdDetailByInventoryItemView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode)
                return;
            if (e.Column.FieldName == "AmountOC")
            {
                var amountOC = grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)grdDetailByInventoryItemView.GetRowCellValue(e.RowHandle, "AmountOC");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 0 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
            }
        }

        /// <summary>
        /// thêm mới ctmt
        /// </summary>
        private void cboTargetProgramId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmProjectDetail frmProjectDetail = new FrmProjectDetail();
                frmProjectDetail.ShowDialog();
                if (frmProjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                    {
                        _projectsPresenter.Display();
                        cboTargetProgramId.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Button thêm mới bank
        /// </summary>
        private void cboBankPay_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        cboBankPay.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }

        /// <summary>
        /// Button thêm mới đối tượng
        /// </summary>
        private void lookUpEditAccountingObject_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                using (var form = new FrmDialogCustom("Bạn muốn thêm loại đối tượng nào?", new string[] { "Đối tượng", "Cán bộ" }))
                {
                    form.ShowDialog();
                    switch (form.Result)
                    {
                        case 1:
                            using (var frmDetail = new FrmXtraAccountingObjectDetail())
                            {
                                frmDetail.ShowDialog();
                                if (frmDetail.CloseBox)
                                {
                                    if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                                    {
                                        _accountingObjectsPresenter.Display();
                                        lookUpEditAccountingObject.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                                    }
                                }
                            }
                            break;
                        case 2:
                            using (var frmDetail = new FrmEmployeeDetail())
                            {
                                frmDetail.ShowDialog();
                                if (frmDetail.CloseBox)
                                {
                                    if (!string.IsNullOrEmpty(GlobalVariable.EmployeeIDDetailForm))
                                    {
                                        _accountingObjectsPresenter.Display();
                                        lookUpEditAccountingObject.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                    //MessageBox.Show(form.Result.ToString());
                }
            }
        }
        #endregion

    }
}
