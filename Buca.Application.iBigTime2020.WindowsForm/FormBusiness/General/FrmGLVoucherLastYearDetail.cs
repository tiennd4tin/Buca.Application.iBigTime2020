﻿/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    13/12/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using DevExpress.CodeParser;
using DevExpress.XtraEditors.ViewInfo;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General
{
    /// <summary>
    /// FrmGLVoucherLastYearDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.General.IGLVoucherLastYearView" />
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
    public partial class FrmGLVoucherLastYearDetail : FrmXtraBaseVoucherDetail, IGLVoucherLastYearView, IAccountingObjectsView,
                                              IBudgetSourcesView, IAccountsView, IGLVouchersLastYearView,
                                              IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView,
                                              ICashWithdrawTypesView, IBanksView, IActivitysView, IProjectsView,
                                              IFundStructuresView, IPurchasePurposesView,
                                              IInvoiceTypiesView, IBudgetExpensesView, IContractsView, ICapitalPlansView
    {
        #region Presenter

        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;

        private readonly GLVoucherLastYearPresenter _gLVoucherLastYearPresenter;
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
        private readonly IModel _model;
        private List<BudgetItemModel> _budgetItemModels;
        private List<AccountModel> _accountModels;
        private readonly BanksPresenter _banksPresenter;
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

        #endregion

        #region Form Event

        /// <summary>
        /// Handles the Load event of the FrmGLVoucherLastYearDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmGLVoucherLastYearDetail_Load(object sender, EventArgs e)
        {
            RefTypeUsingDisplayReport = BuCA.Enum.RefType.GLVoucherLastYear;
        }
        private readonly GLVouchersLastYearPresenter _glVouchersLastYearPresenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmGLVoucherLastYearDetail"/> class.
        /// </summary>
        public FrmGLVoucherLastYearDetail()
        {
            InitializeComponent();
            _glVouchersLastYearPresenter = new GLVouchersLastYearPresenter(this);
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
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
            _model = new Model.Model();

            _gLVoucherLastYearPresenter = new GLVoucherLastYearPresenter(this);
            grdViewParallel = grdViewAccountingParallel;
        }

        #region--Check validate form detail
        private void GrdAccountingView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            InitDetailRow(e, grdAccountingView);
        }
        #endregion

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(8, 202);
            tabMain.Location = new Point(8, 280);
            tabMain.SelectedTabPage = tabAccounting;
            dtPostDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            dtRefDate.Properties.Mask.EditMask = @"dd/MM/yyyy";
            grdAccountingParallel.DataSource = bindingSourceDetailParallel;
        }
        private void FrmBAWithDrawDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, true, true);
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
                if (isGrdMaster == true)
                {
                    grMasterHeigh = grdMaster.Height;
                    // grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, (formHeight - 315) / 2);
                    // tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 15;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                    panel1.Size = new Size(tabMainWith, ((formHeight - 315) / 2) - 35);
                }

                else

                {
                    //grMasterHeigh = grdMaster.Height;
                    //grdMaster.Location = new Point(6, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = tabMain.Width;
                    tabMain.Size = new Size(tabMainWith, tabMainHeight - 70);
                    tabMain.Location = new Point(6, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7;
                    panel1Height = grdLayoutHeight - tabMainHeight;
                    panel1.Height = panel1Height;
                    panel1.Location = new Point(6, ypanel1);
                }

            }
        }
        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            base.SetEnableGroupBox(isEnable);
            grdViewAccountingParallel.OptionsBehavior.Editable = isEnable;
            grdViewAccountingParallel.OptionsBehavior.ReadOnly = !isEnable;
            grdViewAccountingParallel.FocusRectStyle = DrawFocusRectStyle.None;
            grdViewAccountingParallel.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            grdViewAccountingParallel.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _glVouchersLastYearPresenter.Display((int)BuCA.Enum.RefType.GLVoucherLastYear);
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _budgetExpensesPresenter.DisplayActive();
            _banksPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayActive(true);
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayByIsDetail(GlobalVariable.IsPostToParentAccount);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _activitysPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _purchasePurposesPresenter.DisplayByIsActive(true);
            _invoiceTypiesPresenter.Display();
            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((GLVoucherModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((GLVoucherModel)MasterBindingSource.Current).RefId;
            }

            if (ActionMode != ActionModeVoucherEnum.AddNew) _gLVoucherLastYearPresenter.Display(KeyValue, true, true);

            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.GLVoucherLastYear;
        }
        public IList<GLVoucherModel> GLVouchers
        {
            get { return null; }
            set
            {
                if (value != null && value.Count() > 0)
                {
                    if (Details == null) Details = new List<GLVoucherDetailModel>();
                    foreach (var item in value)
                    {
                        var details = _model.GetGLVoucherDetail(item.RefId);
                        Details.AddRange(details.GLVoucherDetails);
                    }
                }
            }
        }
        public List<GLVoucherDetailModel> Details { get; set; }
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
            var paymentVoucherDetails = GLVoucherDetails;
            if (paymentVoucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
            }
            //foreach (var glVoucherDetail in GLVoucherDetails)
            //{

            //    if (glVoucherDetail.DebitAccount == null && glVoucherDetail.CreditAccount == null)
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDebit"),
            //            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        return false;
            //    }

            //    //Nếu không phải định khoản đơn bên Có
            //    if (glVoucherDetail.DebitAccount == null && !glVoucherDetail.CreditAccount.StartsWith("0"))
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDebit"),
            //            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        return false;
            //    }

            //    //Nếu không phải định khoản đơn bên Nợ
            //    if (glVoucherDetail.CreditAccount == null && !glVoucherDetail.DebitAccount.StartsWith("0"))
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherCredit"),
            //            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);
            //        return false;
            //    }
            #endregion

            //    //# region Check detail by DebitAccount

            //    //if (!string.IsNullOrEmpty(glVoucherDetail.DebitAccount))
            //    //{
            //    //    var debitAccount = _accountModels.FirstOrDefault(c => c.AccountNumber == glVoucherDetail.DebitAccount);
            //    //    var isError = debitAccount.ValidDetailGLVoucherLastYear(glVoucherDetail.BudgetSourceId, glVoucherDetail.BudgetChapterCode, glVoucherDetail.BudgetSubKindItemCode,
            //    //        glVoucherDetail.BudgetItemCode, glVoucherDetail.BudgetSubItemCode, glVoucherDetail.MethodDistributeId,
            //    //        glVoucherDetail.AccountingObjectId, glVoucherDetail.ActivityId, glVoucherDetail.ProjectId, null, null, null);
            //    //    if (!isError)
            //    //        return false;
            //    //}
            //    //#endregion

            //    //# region Check detail by CreditAccount

            //    //if (!string.IsNullOrEmpty(glVoucherDetail.CreditAccount))
            //    //{
            //    //    var creditAccount = _accountModels.FirstOrDefault(c => c.AccountNumber == glVoucherDetail.CreditAccount);
            //    //    var isError = creditAccount.ValidDetailGLVoucherLastYear(glVoucherDetail.BudgetSourceId, glVoucherDetail.BudgetChapterCode, glVoucherDetail.BudgetSubKindItemCode,
            //    //        glVoucherDetail.BudgetItemCode, glVoucherDetail.BudgetSubItemCode, glVoucherDetail.MethodDistributeId,
            //    //        glVoucherDetail.AccountingObjectId, glVoucherDetail.ActivityId, glVoucherDetail.ProjectId, "0", null, null);
            //    //    if (!isError)
            //    //        return false;
            //    //}
            //    //#endregion
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
                view.SetRowCellValue(e.RowHandle, "CashWithDrawTypeId", 25);//AnhNT: Set = 25 là nghiệp vụ kết chuyển, phần này của riêng chứng từ => cần phải set cứng.
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
                view.SetRowCellValue(e.RowHandle, "AccountingObjectId", cboObjectCode.EditValue);
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

            var result = new DialogResult();
            if (GLVoucherDetailParalles.Count > 0)
            {
                result = XtraMessageBox.Show("Bạn có muốn cập nhật lại định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show("Bạn có muốn sinh tự động định khoản đồng thời không?", "Định khoản đồng thời",
             MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            return result == DialogResult.OK ? _gLVoucherLastYearPresenter.Save(true) : _gLVoucherLastYearPresenter.Save(false);
        }

        /// <summary>
        /// Reloads the parallel grid.
        /// </summary>
        protected override void ReloadParallelGrid()
        {
            _gLVoucherLastYearPresenter.Display(KeyValue, true, true);
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new GLVoucherPresenter(null).Delete(KeyValue);
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
                    var parentId = _budgetItemModels.FirstOrDefault(b => b.BudgetItemCode == e.Value.ToString()).ParentId;
                    var budgetItemCode = _budgetItemModels.FirstOrDefault(b => b.BudgetItemId == parentId).BudgetItemCode;
                    grdAccountingView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode);
                }

                //if (e.Column.FieldName == "ProjectId" && e.Value != null)
                //{
                //    var values = OldContracts.Where(w => w.ProjectId == e.Value.ToString()).ToList();
                //    _gridLookUpEditContract.DataSource = values;

                //}
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
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    if (e.Column.FieldName == "DebitAccount")
                    {
                        var debitAccount = grdAccountingView.GetRowCellValue(e.RowHandle, "DebitAccount");
                        if (debitAccount != null)
                        {
                            GridColumn detailDebitAccountColumn = grdAccountingDetailView.Columns["DebitAccount"];
                            if (e.Value != null)
                            {
                                grdAccountingDetailView.SetRowCellValue(e.RowHandle, detailDebitAccountColumn, debitAccount);
                            }
                        }
                    }

                    if (e.Column.FieldName == "CreditAccount")
                    {
                        var creditAccount = grdAccountingView.GetRowCellValue(e.RowHandle, "CreditAccount");
                        if (creditAccount != null)
                        {
                            GridColumn detailCreditAccountColumn = grdAccountingDetailView.Columns["CreditAccount"];
                            if (e.Value != null)
                            {
                                grdAccountingDetailView.SetRowCellValue(e.RowHandle, detailCreditAccountColumn,
                                                                        creditAccount);
                            }
                        }
                    }

                    if (e.Column.FieldName == "Description")
                    {
                        var description = grdAccountingView.GetRowCellValue(e.RowHandle, "Description");
                        GridColumn detailDescriptionColumn = grdAccountingDetailView.Columns["Description"];
                        //GridColumn taxDescriptionColumn = grdTaxView.Columns["Description"];
                        if (e.Value != null)
                        {
                            grdAccountingDetailView.SetRowCellValue(e.RowHandle, detailDescriptionColumn, description);
                        }
                    }

                    if (e.Column.FieldName == "AmountOC")
                    {
                        var amount = grdAccountingView.GetRowCellValue(e.RowHandle, "AmountOC");
                        if (amount != null)
                        {
                            GridColumn amountColumn = grdAccountingView.Columns["AmountOC"];
                            GridColumn detailAmountColumn = grdAccountingDetailView.Columns["AmountOC"];

                            if (e.Value == null)
                            {
                                grdAccountingView.SetRowCellValue(e.RowHandle, amountColumn, 0);
                            }
                            else
                            {
                                grdAccountingDetailView.SetRowCellValue(e.RowHandle, detailAmountColumn, amount);
                            }
                        }
                    }

                    if (e.Column.FieldName == "BudgetSubItemCode")
                    {
                        GridColumn budgetItemCode = grdAccountingDetailView.Columns["BudgetItemCode"];
                        if (e.Value != null)
                        {
                            var budgetSubItem = _model.GetBudgetItemByCode((string)e.Value);
                            if (budgetSubItem != null)
                            {
                                var budgetItem = _model.GetBudgetItem(budgetSubItem.ParentId);
                                grdAccountingView.SetRowCellValue(e.RowHandle, budgetItemCode, budgetItem.BudgetItemCode);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
        }
                
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
            grdAccountingDetailView.SetRowCellValue(grdAccountingDetailView.FocusedRowHandle, creditAccountingObjectId, null);
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
        /// Handles the ProcessGridKey event of the grdMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdMaster_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    if (e.KeyCode == Keys.Tab)
                    {

                        GridControl grid = sender as GridControl;

                        GridView view = grid.FocusedView as GridView;

                        if ((e.Modifiers == Keys.None && view.IsLastRow && view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)

                            || (e.Modifiers == Keys.Shift && view.IsFirstRow && view.FocusedColumn.VisibleIndex == 0))
                        {

                            if (view.IsEditing)

                                view.CloseEditor();

                            tabAccounting.Focus();
                            grdAccountingView.FocusedColumn = grdAccountingView.Columns[0];

                            e.Handled = true;

                        }

                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
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
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 0 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "Amount", exchangeRate * amountOC);
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

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

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
            get { return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount"); }
            set { gridViewMaster.SetRowCellValue(0, "TotalAmount", value); }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC
        {
            get { return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC"); }
            set { gridViewMaster.SetRowCellValue(0, "TotalAmountOC", value); }
        }

        /// <summary>
        /// Gets or sets the parent reference identifier.
        /// </summary>
        /// <value>
        /// The parent reference identifier.
        /// </value>
        public string ParentRefId { get; set; }

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
        /// Gets or sets the advance payment order.
        /// </summary>
        /// <value>
        /// The advance payment order.
        /// </value>
        public int? AdvancePaymentOrder { get; set; }

        /// <summary>
        /// Gets or sets the gl voucher details.
        /// </summary>
        /// <value>
        /// The gl voucher details.
        /// </value>
        public IList<GLVoucherDetailModel> GLVoucherDetails
        {
            get
            {
                var glVoucherDetails = new List<GLVoucherDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    decimal totalAmount = 0;
                    decimal totalAmountOC = 0;
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (GLVoucherDetailModel)grdAccountingView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var budgetKindItemCode = "";
                            if (!string.IsNullOrEmpty(rowVoucher.BudgetSubKindItemCode))
                            {
                                var budgetSubKindItem =
                                    _budgetSubKindItemModels.FirstOrDefault(
                                        b => b.BudgetKindItemCode == rowVoucher.BudgetSubKindItemCode);
                                if (budgetSubKindItem == null)
                                    budgetKindItemCode = null;
                                else
                                {
                                    var budgetKindItem =
                                        _budgetKindItemModels.FirstOrDefault(
                                            b => b.BudgetKindItemId == budgetSubKindItem.ParentId);
                                    budgetKindItemCode = budgetKindItem == null
                                                             ? null
                                                             : budgetKindItem.BudgetKindItemCode;
                                }
                            }
                            var item = new GLVoucherDetailModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                DebitAccount = rowVoucher.DebitAccount,
                                CreditAccount = rowVoucher.CreditAccount,
                                Amount =
                                        ExchangeRate == null
                                            ? rowVoucher.AmountOC
                                            : (decimal)(rowVoucher.AmountOC * ExchangeRate),
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                ProjectId = rowVoucher.ProjectId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                SortOrder = i,
                                BudgetExpenseId = rowVoucher.BudgetExpenseId,
                                Approved = rowVoucher.Approved,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                            };
                            totalAmount += item.Amount;
                            totalAmountOC += item.AmountOC;
                            glVoucherDetails.Add(item);
                        }
                        TotalAmount = totalAmount;
                        TotalAmountOC = totalAmountOC;
                    }
                }

                if (glVoucherDetails.Count > 0)
                {
                    if (grdAccountingDetailView.DataSource != null && grdAccountingDetailView.RowCount > 0)
                    {
                        for (var i = 0; i < grdAccountingDetailView.RowCount; i++)
                        {
                            var rowVoucher = (GLVoucherDetailModel)grdAccountingDetailView.GetRow(i);
                            if (rowVoucher != null)
                            {
                                glVoucherDetails[i].AccountingObjectId = rowVoucher.AccountingObjectId;
                                glVoucherDetails[i].ActivityId = rowVoucher.ActivityId;
                                glVoucherDetails[i].ProjectId = rowVoucher.ProjectId;
                                glVoucherDetails[i].SortOrder = i;
                            }
                        }
                    }
                }

                return glVoucherDetails;
            }

            set
            {
                foreach (var item in value)
                {
                    item.CashWithDrawTypeId = 5;
                }
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<GLVoucherDetailModel>();
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
                                ColumnWith = 200,
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
                                AllowEdit = true,
                                ColumnType = UnboundColumnType.Decimal
                            },
                         new XtraColumn
                            {
                                ColumnName = "Amount",
                                ColumnVisible = true,
                                ColumnWith = 100,
                                ColumnCaption = "Số tiền quy đổi",
                                ColumnPosition = 5,
                                IsSummnary = true,
                                AllowEdit = true,
                                ColumnType = UnboundColumnType.Decimal
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetSourceId",
                                ColumnVisible = true,
                                ColumnWith = 150,
                                ColumnCaption = "Nguồn",
                                ColumnPosition = 6,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBudgetSource
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetChapterCode",
                                ColumnVisible = true,
                                ColumnWith = 80,
                                ColumnCaption = "Chương",
                                ColumnPosition = 7,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBudgetChapter
                            },
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn
                            {
                                ColumnName = "BudgetSubKindItemCode",
                                ColumnVisible = true,
                                ColumnWith = 80,
                                ColumnCaption = "Khoản",
                                ColumnPosition = 8,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBudgetSubKindItem
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetSubItemCode",
                                ColumnVisible = true,
                                ColumnWith = 80,
                                ColumnCaption = "Tiểu mục",
                                ColumnPosition = 9,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBudgetSubItem
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnVisible = true,
                                ColumnWith = 80,
                                ColumnCaption = "Mục",
                                ColumnPosition = 10,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBudgetItem
                            },

                        new XtraColumn
                            {
                                ColumnName = "MethodDistributeId",
                                ColumnVisible = false,
                            },
                        new XtraColumn
                            {
                                ColumnName = "CashWithDrawTypeId",
                                ColumnVisible = true,
                                ColumnWith = 120,
                                ColumnCaption = "Nghiệp vụ",
                                ColumnPosition = 11,
                                AllowEdit = false,
                                RepositoryControl = _gridLookUpEditCashWithdrawType
                            },
                        new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CreditAccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentRefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        new XtraColumn
                            {
                                ColumnName = "ProjectId",
                                ColumnVisible = true,
                                ColumnWith = 120,
                                ColumnCaption = "Dự án",
                                ColumnPosition = 12,
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
                            ColumnPosition = 13,
                            AllowEdit = true
                        },
                        new XtraColumn
                        {
                            ColumnName = "CapitalPlanId",
                            ColumnVisible = true,
                            RepositoryControl = _gridLookUpEditCapitalPlan,
                            ColumnWith = 130,
                            ColumnCaption = "Kế hoạch vốn",
                            ColumnPosition = 14,
                            AllowEdit = true
                        },
                        new XtraColumn
                            {
                                ColumnName = "BankAccount",
                                ColumnVisible = true,
                                ColumnWith = 130,
                                ColumnCaption = "Tài khoản NH,KB",
                                ColumnPosition = 15,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditBank
                            },
                        new XtraColumn   {
                                ColumnName = "Approved",
                                ColumnVisible = false,
                                ColumnWith = 120,
                                ColumnCaption = "Phê duyệt",
                                ColumnPosition = 16,
                                AllowEdit = true,
                                Alignment = HorzAlignment.Center
                            },
                        new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TopicId", ColumnVisible = false}

                    };
                XtraColumnCollectionHelper<GLVoucherDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
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
                                ColumnWith = 200,
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
                                AllowEdit = true,
                                ColumnType = UnboundColumnType.Decimal
                            },
                                              new XtraColumn
                            {
                                ColumnName = "Amount",
                                ColumnVisible = true,
                                ColumnWith = 100,
                                ColumnCaption = "Số tiền quy đổi",
                                ColumnPosition = 4,
                                IsSummnary = true,
                                AllowEdit = true,
                                ColumnType = UnboundColumnType.Decimal
                            },
                        new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn
                            {
                                ColumnName = "ActivityId",
                                ColumnVisible = true,
                                ColumnWith = 120,
                                ColumnCaption = "Hoạt động",
                                ColumnPosition = 8,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditActivity
                            },
                        new XtraColumn
                            {
                                ColumnName = "AccountingObjectId",
                                ColumnVisible = true,
                                ColumnWith = 120,
                                ColumnCaption = "Đối tượng",
                                ColumnPosition = 9,
                                AllowEdit = true,
                                RepositoryControl = _gridLookUpEditAccountingObject
                            },
                        new XtraColumn
                        {
                            ColumnName = "BudgetExpenseId",
                            ColumnVisible = true,
                            ColumnWith = 200,
                            ColumnCaption = "Phí lệ phí",
                            ColumnPosition = 10,
                            AllowEdit = true,
                            RepositoryControl = _gridLookUpBudgetExpense
                        },

                        new XtraColumn {ColumnName = "CreditAccountingObjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Approved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentRefDetailId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        //new XtraColumn
                        //    {
                        //        ColumnName = "FundStructureId",
                        //        ColumnVisible = true,
                        //        ColumnWith = 120,
                        //        ColumnCaption = "Khoản chi",
                        //        ColumnPosition = 12,
                        //        AllowEdit = true,
                        //        RepositoryControl = _gridLookUpEditFundStructure,
                        //        IsLastColumn = true
                        //    },
                        new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TopicId", ColumnVisible = false}
                    };
                XtraColumnCollectionHelper<GLVoucherDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingDetailView);
                SetNumericFormatControl(grdAccountingDetailView, true);
                grdAccountingDetailView.OptionsView.ShowFooter = false;

                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the gl voucher detail taxes.
        /// </summary>
        /// <value>
        /// The gl voucher detail taxes.
        /// </value>
        public IList<GLVoucherDetailTaxModel> GLVoucherDetailTaxes
        {
            get
            {
                var paymentDetailTaxes = new List<GLVoucherDetailTaxModel>();
                if (grdTaxView.DataSource != null && grdTaxView.RowCount > 0)
                {
                    for (var i = 0; i < grdTaxView.RowCount; i++)
                    {
                        var rowVoucher = (GLVoucherDetailTaxModel)grdTaxView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new GLVoucherDetailTaxModel
                            {
                                Description = rowVoucher.Description == null ? null : rowVoucher.Description.Trim(),
                                VATAmount = rowVoucher.VATAmount,
                                VATRate = rowVoucher.VATRate,
                                TurnOver = rowVoucher.TurnOver,
                                InvType = rowVoucher.InvType,
                                InvDate = rowVoucher.InvDate,
                                InvNo = rowVoucher.InvNo == null ? null : rowVoucher.InvNo.Trim(),
                                PurchasePurposeId = rowVoucher.PurchasePurposeId,
                                AccountingObjectId = rowVoucher.AccountingObjectId,
                                CompanyTaxCode = rowVoucher.CompanyTaxCode == null ? null : rowVoucher.CompanyTaxCode.Trim(),
                                InvoiceTypeCode = rowVoucher.InvoiceTypeCode == null ? null : rowVoucher.InvoiceTypeCode.Trim(),
                                SortOrder = i
                            };
                            paymentDetailTaxes.Add(item);
                        }
                    }
                }
                return paymentDetailTaxes;
            }

            set
            {
                bindingSourceDetailByTax.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<GLVoucherDetailTaxModel>();
                grdTaxView.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
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
                    RepositoryControl = _repositoryVATRate
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TurnOver",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Giá tính thuế",
                    ColumnPosition = 4,
                    IsSummnary = true,
                    AllowEdit = true,
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
                    RepositoryControl = _gridLookUpEditInvoiceType
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InvoiceTypeCode",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Mẫu số HĐ",
                    ColumnPosition = 6,
                    AllowEdit = true
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
                    ColumnVisible = true,
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
                    ColumnCaption = "Tên đối tượng",
                    ColumnPosition = 12,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditAccountingObject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectAddress",
                    ColumnVisible = false,
                    ColumnWith = 150,
                    ColumnCaption = "Địa chỉ",
                    ColumnPosition = 13,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditAccountingObject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CompanyTaxCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mã số thuế",
                    ColumnPosition = 14,
                    AllowEdit = true,
                    IsLastColumn = true
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });

                grdTaxView = InitGridLayout(columnsCollection, grdTaxView);
                SetNumericFormatControl(grdTaxView, true);
                grdTaxView.OptionsView.ShowFooter = false;
            }
        }

        /// <summary>
        /// Gets or sets the gl voucher detail paralles.
        /// </summary>
        /// <value>The gl voucher detail paralles.</value>
        public IList<GLVoucherDetailParallelModel> GLVoucherDetailParalles
        {
            get
            {
                grdAccountingParallel.RefreshDataSource();
                var voucherDetailParalles = new List<GLVoucherDetailParallelModel>();
                if (grdViewAccountingParallel.DataSource != null && grdViewAccountingParallel.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (GLVoucherDetailParallelModel)grdViewAccountingParallel.GetRow(i);
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
                            var item = new GLVoucherDetailParallelModel()
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
                            voucherDetailParalles.Add(item);
                            //TotalAmount += item.Amount;
                            //TotalAmountOC += item.Amount;
                        }
                    }
                }
                return voucherDetailParalles;

            }
            set
            {

                bindingSourceDetailParallel.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<GLVoucherDetailParallelModel>();
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
                        ColumnCaption = "Dự án",
                        ColumnPosition = 14,
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
                        ColumnPosition = 15,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "CapitalPlanId",
                        ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 130,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 15,
                        AllowEdit = true
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
                    new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false}
                };

                grdViewAccountingParallel.InitGridLayout(columnsCollection);
                SetNumericFormatControl(grdViewAccountingParallel, true);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                #endregion
            }
        }


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
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();
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

                    //XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceModels, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
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

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    //_gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";


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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetSubItem.DisplayMember = "BudgetItemCode";
                    //_gridLookUpEditBudgetSubItem.ValueMember = "BudgetItemCode";

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
        /// <value>The banks.</value>

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        public IList<BankModel> Banks
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BankModel>();

                    var gridColumnsCollection = new List<XtraColumn>();

                    //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                    //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                    //XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
                    _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
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
                                ColumnCaption = "Mã đối tượng",
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
                    //XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
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

        #region BudgetExpenses
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                if (value == null)
                    value = new List<BudgetExpenseModel>();

                //_gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
                //_gridLookUpBudgetExpense = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetExpenseView, value, "BudgetExpenseName", "BudgetExpenseId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseCode", ColumnCaption = "Mã lệ phí", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 0 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseName", ColumnCaption = "Tên phí, lệ phí", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 1 });

                // XtraColumnCollectionHelper<BudgetExpenseModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetExpenseView);

                _gridLookUpEditBudgetExpenseView = XtraColumnCollectionHelper<BudgetExpenseModel>.CreateGridViewReponsitory();
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


        #region Contract

        public List<ContractModel> OldContracts { get; set; }
        /// <summary>
        /// Contract
        /// </summary>
        public IList<ContractModel> Contracts
        {
            set
            {
                OldContracts = value.ToList();
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

                    _gridLookUpEditInvoiceTypeView = XtraColumnCollectionHelper<InvoiceTypeModel>.CreateGridViewReponsitory();
                    _gridLookUpEditInvoiceType = XtraColumnCollectionHelper<InvoiceTypeModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditInvoiceTypeView, value, "InvoiceTypeCode", "InvoiceTypeId", gridColumnsCollection);
                    XtraColumnCollectionHelper<InvoiceTypeModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditInvoiceTypeView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public bool Approved { get; set; }
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }
        public string ProjectIds { get; set; } = "";
        private void btSelectProject_Click(object sender, EventArgs e)
        {
            var frmSelectProject = new FrmChooseProjects(this.Details);
            frmSelectProject.ShowDialog();
            if (frmSelectProject.DialogResult == DialogResult.OK)
            {
                var projectIds = frmSelectProject.ProjectIds;
                if (projectIds.Count() == 0)
                {
                    XtraMessageBox.Show(@"Vui lòng chọn ít nhất một dự án", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _gLVoucherLastYearPresenter.DisplayTranfer((int)BaseRefTypeId, DateTime.Parse(GlobalVariable.PostedDate), false, string.Join(",", projectIds.ToArray()));

                    //for (int i = 0; i < projectIds.Count; i++)
                    //{
                    //    var values = OldContracts.Where(w => w.ProjectId == projectIds[i]).ToList();
                    //    _gridLookUpEditContract.DataSource = values;
                    //}
                }

            }

        }
        protected override void GridPurchaseShowEditor(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            GLVoucherDetailModel data = view.GetFocusedRow() as GLVoucherDetailModel;
            if (view.FocusedColumn.FieldName == "ContractId" && view.ActiveEditor is GridLookUpEdit)
            {
                GridLookUpEdit editor = view.ActiveEditor as GridLookUpEdit;
                if (data != null && !string.IsNullOrEmpty(data.ProjectId))
                {
                    var contracts = OldContracts.Where(x => x.ProjectId == data.ProjectId).ToList();
                    if (contracts == null || contracts.Count == 0) editor.Properties.DataSource = OldContracts;
                    else
                    {
                        editor.Properties.DataSource = contracts;
                    }
                }
                else
                {
                    editor.Properties.DataSource = OldContracts;
                }
            }
        }
    }
}
