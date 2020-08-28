using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
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
using Buca.Application.iBigTime2020.Model.DataTransferObjectMapper;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate.AutoVoucher;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Employee;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using Buca.Application.iBigTime2020.WindowsForm.FormSystem;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    public partial class FrmBUPlanWithDrawTransferInsurranceDetail : FrmXtraBaseVoucherDetail, IProjectsView, IBUPlanWithdrawTransferInsurranceView,
        IBanksView, IAccountingObjectsView,
        ICashWithdrawTypesView, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, IFundStructuresView, IAccountsView, IBUCommitmentRequestsView
    {
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BUPlanWithdrawTransferInsurrancePresenter _planWithdrawTransferInsurrancePresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BUCommitmentRequestsPresenter _buCommitmentRequestsPresenter;
        private readonly IModel _model;
        private List<BudgetItemModel> BudgetItemModels;
        List<AccountModel> _listAccounts;

        public List<BUPlanWithdrawDetailModel> ListSendSourceDetail;
        public bool IsOpenFromBUPlanWithdrawTransferInsurrancetDetail;
        public BAWithDrawModel bAWithdrawModel;

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>The cash withdraw type models.</value>
        private List<CashWithdrawTypeModel> _cashWithdrawTypeModels;
        private List<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetKindItemModel> _budgetSubKindItemModels;


        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;


        #endregion

        #region Overide

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _projectsPresenter.DisplayByObjectType("1");
            _banksPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _fundStructuresPresenter.DisplayActive(true);
            _buCommitmentRequestsPresenter.Display();
            if (MasterBindingSource != null) if (MasterBindingSource.Current != null)
                KeyValue = ((BUPlanWithdrawModel)MasterBindingSource.Current).RefId;
            _planWithdrawTransferInsurrancePresenter.Display(KeyValue, true);

            if (RefType == 0)
            {
                RefType = (int)BuCA.Enum.RefType.BUPlanWithdrawTransferInsurrance;
                rndCashWithDrawType.SelectedIndex = 2;
                Posted = true;
            }
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(12, 328);
            tabMain.SelectedTabPage = tabAccounting;
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
            //txtDocumentInclude.ReadOnly = true;
            //txtTaxCode.ReadOnly = true;
            var sResult = _planWithdrawTransferInsurrancePresenter.Save();
            // Liên kết chuyển khoản trả lương BẢO hiểm
            try
            {
                var frmBUTransfersPayWageDetail = new FrmBUTransfersPayWageDetail();
                var bUTransfersPayWageRef = _model.GetBUTransferByBUPlanWithdrawRefId(RefId);
                if (bUTransfersPayWageRef != null)
                    bUTransfersPayWageRefID = bUTransfersPayWageRef.RefId;
                frmBUTransfersPayWageDetail.ActionMode = string.IsNullOrEmpty(bUTransfersPayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmBUTransfersPayWageDetail.KeyValue = string.IsNullOrEmpty(bUTransfersPayWageRefID) ? null : bUTransfersPayWageRefID;

                var frmAutoVoucher = new FrmAutoVoucher();
                
                var _source = this.bindingSourceDetail.DataSource;
                var _listDetail = new List<BUPlanWithdrawDetailModel>();
                if (_source != null)
                    _listDetail = (List<BUPlanWithdrawDetailModel>)_source;
                var _listDetailSend1 = _listDetail.Select(m => Mapper.AutoMapper(m, new BUTransferDetailModel())).ToList();
                var _listDetailSend2 = _listDetail.Select(m => Mapper.AutoMapper(m, new BUTransferDetailModel())).ToList();
                var _defaultDebitAccount = BusinessExtension.DefaultDebitAccount(_listAccounts, (int)BuCA.Enum.RefType.BUTransferPayWage, RefTypes.ToList());
                var _defaultCreditAccount = BusinessExtension.DefaultCreditAccount(_listAccounts, (int)BuCA.Enum.RefType.BUTransferPayWage, RefTypes.ToList());
                _listDetailSend1 = _listDetailSend1.Select(m =>
                {
                    m.DebitAccount = _defaultDebitAccount.AccountNumber;
                    if (rndCashWithDrawType.SelectedIndex == 0)
                    { m.CreditAccount = "3371"; }
                    if (rndCashWithDrawType.SelectedIndex == 1)
                    { m.CreditAccount = "3371"; }
                    if (rndCashWithDrawType.SelectedIndex == 2)
                    { m.CreditAccount = "5111"; }
                    m.CashWithDrawTypeId = CashWithDrawType;
                    m.MethodDistributeId = (int)MethodDistribute.Estimate;
                    m.AccountingObjectId = AccountingObjectId;
                    return m;
                }).ToList();

                //sinh 3 dòng chứng từ chuuyển khoản bảo hiểm
                var _list = new List<BUTransferDetailModel>();
                foreach (var Row in _listDetailSend2)
                {
                    if (Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100")
                    {
                        var row1 = new BUTransferDetailModel()
                        {
                            OrgRefNo = Row.OrgRefNo,
                            OrgRefDate = Row.OrgRefDate,
                            BudgetSourceId = Row.BudgetSourceId,
                            BudgetChapterCode = Row.BudgetChapterCode,
                            //BudgetKindItemCode = budgetKindItemCode,
                            BudgetSubKindItemCode = Row.BudgetSubKindItemCode,
                            BudgetItemCode = Row.BudgetItemCode,
                            BudgetSubItemCode = Row.BudgetSubItemCode,
                            Amount = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.Amount * 80 / 105 : Row.Amount,
                            AmountOC = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.AmountOC * 80 / 105 : Row.AmountOC,
                            ProjectId = Row.ProjectId,
                            ActivityId = Row.ActivityId,
                            FundStructureId = Row.FundStructureId,
                            Description = "8% BHXH",
                            // DebitAccount = _defaultDebitAccount.AccountNumber,
                            DebitAccount = "3321",
                            CreditAccount = rndCashWithDrawType.SelectedIndex == 0 || rndCashWithDrawType.SelectedIndex == 1 ? "3371" : _defaultCreditAccount?.AccountNumber,
                            CashWithDrawTypeId = CashWithDrawType,
                            MethodDistributeId = (int)MethodDistribute.Estimate,
                            AccountingObjectId = Row.AccountingObjectId

                    };
                        _list.Add(row1);

                        var row2 = new BUTransferDetailModel()
                        {
                            OrgRefNo = Row.OrgRefNo,
                            OrgRefDate = Row.OrgRefDate,
                            BudgetSourceId = Row.BudgetSourceId,
                            BudgetChapterCode = Row.BudgetChapterCode,
                            BudgetSubKindItemCode = Row.BudgetSubKindItemCode,
                            BudgetItemCode = Row.BudgetItemCode,
                            BudgetSubItemCode = Row.BudgetSubItemCode,
                            Amount = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.Amount * 15 / 105 : Row.Amount,
                            AmountOC = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.AmountOC * 15 / 105 : Row.AmountOC,
                            // AmountOC = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.AmountOC * 3 / 200 : Row.AmountOC,
                            ProjectId = Row.ProjectId,
                            ActivityId = Row.ActivityId,
                            FundStructureId = Row.FundStructureId,
                            Description = "1,5 % BHYT",
                            CreditAccount = rndCashWithDrawType.SelectedIndex == 0 || rndCashWithDrawType.SelectedIndex == 1 ? "3371" : _defaultCreditAccount?.AccountNumber,
                            //DebitAccount = _defaultDebitAccount.AccountNumber
                            DebitAccount = "3322",
                            CashWithDrawTypeId = CashWithDrawType,
                            MethodDistributeId = (int)MethodDistribute.Estimate,
                            AccountingObjectId = Row.AccountingObjectId
                        };
                        _list.Add(row2);
                        var row3 = new BUTransferDetailModel()
                        {
                            OrgRefNo = Row.OrgRefNo,
                            OrgRefDate = Row.OrgRefDate,
                            BudgetSourceId = Row.BudgetSourceId,
                            BudgetChapterCode = Row.BudgetChapterCode,
                            //  BudgetKindItemCode = budgetKindItemCode,
                            BudgetSubKindItemCode = Row.BudgetSubKindItemCode,
                            BudgetItemCode = Row.BudgetItemCode,
                            BudgetSubItemCode = Row.BudgetSubItemCode,
                            Amount = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.Amount * 10 / 105 : Row.Amount,
                            AmountOC = Row.BudgetItemCode == "6000" || Row.BudgetItemCode == "6100" ? Row.AmountOC * 10 / 105 : Row.AmountOC,
                            ProjectId = Row.ProjectId,
                            ActivityId = Row.ActivityId,
                            FundStructureId = Row.FundStructureId,
                            Description = "1% BHTN",
                            CreditAccount = rndCashWithDrawType.SelectedIndex == 0 || rndCashWithDrawType.SelectedIndex == 1 ? "3371" : _defaultCreditAccount?.AccountNumber,
                            DebitAccount = "3324",
                            CashWithDrawTypeId = CashWithDrawType,
                            MethodDistributeId = (int)MethodDistribute.Estimate,
                            AccountingObjectId = Row.AccountingObjectId
                        };
                        _list.Add(row3);
                    }
                    else
                    {
                        var row0 = new BUTransferDetailModel()
                        {
                            OrgRefNo = Row.OrgRefNo,
                            OrgRefDate = Row.OrgRefDate,
                            BudgetSourceId = Row.BudgetSourceId,
                            BudgetChapterCode = Row.BudgetChapterCode,
                            //BudgetKindItemCode = budgetKindItemCode,
                            BudgetSubKindItemCode = Row.BudgetSubKindItemCode,
                            BudgetItemCode = Row.BudgetItemCode,
                            BudgetSubItemCode = Row.BudgetSubItemCode,
                            Amount = Row.Amount,
                            AmountOC = Row.AmountOC,
                            ProjectId = Row.ProjectId,
                            ActivityId = Row.ActivityId,
                            FundStructureId = Row.FundStructureId,
                            Description = Row.Description,
                            //  DebitAccount = "3321",
                            DebitAccount = Row.BudgetItemCode == "6300" ? "3321" : Row.DebitAccount,
                            CreditAccount = rndCashWithDrawType.SelectedIndex == 0 || rndCashWithDrawType.SelectedIndex == 1 ? "3371" : "5111",
                            CashWithDrawTypeId = CashWithDrawType,
                            MethodDistributeId = (int)MethodDistribute.Estimate,
                            AccountingObjectId = Row.AccountingObjectId
                        };
                        _list.Add(row0);
                    }

                }
                _listDetailSend2 = _list;
                frmAutoVoucher.ListSendSourceDetail1 = _listDetailSend1;
                frmAutoVoucher.ListSendSourceDetail2 = _listDetailSend2;
                frmAutoVoucher.IsOpenFrmBUTransferPayWageDetail = true;
                //bUTransfersPayWageRefID = frmBUTransfersPayWageDetail.RefId;


                // Thông tin master
                var item = new BUTransferModel()
                {
                    AccountingObjectId = AccountingObjectId,
                    JournalMemo = JournalMemo,
                    PostedDate = PostedDate,
                    RefDate = RefDate,
                    CurrencyCode = CurrencyCode,
                    ExchangeRate = ExchangeRate ?? 0,
                    TotalAmount = TotalAmount,
                    TotalAmountOC = TotalAmountOC,
                    RefId = sResult,
                    TargetProgramId = TargetProgramId,
                    BankInfoId = BankId,
                    BUCommitmentRequestId = BUCommitmentRequestId
                };
                frmAutoVoucher.buTTransferModel = item;
                frmAutoVoucher.PayWageRefID = bUTransfersPayWageRefID;
                frmAutoVoucher.ActionMode = string.IsNullOrEmpty(bUTransfersPayWageRefID) ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                frmAutoVoucher.ShowDialog();
            }
            //}
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sResult;
        }

        protected override bool ValidEdit()
        {
            var buTransfers = _model.GetBUTransferByBUPlanWithdrawRefId(RefId);
            if (buTransfers != null)
                if (!string.IsNullOrEmpty(buTransfers.RefId))
                    return XtraMessageBox.Show(string.Format("Chứng từ rút dự toán chuyển khoản trả lương, bảo hiểm đã phát sinh chứng từ chuyển khoản kho bạc trả lương, bảo hiểm số {0}. Bạn có muốn sửa giấy rút này không?", buTransfers.RefNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
            return true;
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
            var voucherDetails = BUPlanWithdrawDetails;
            if (voucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            foreach (var item in voucherDetails)
            {
                if (string.IsNullOrEmpty(item.BudgetSubKindItemCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubKindItemCodeNull"),
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    return false;
                }


                if (string.IsNullOrEmpty(item.BudgetChapterCode))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodenull"),
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Grids the accounting cell value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
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
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected override void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            try
            {
                //view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                //view.SetRowCellValue(e.RowHandle, "Amount", 0);
                //view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                //view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                //view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                //view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 6);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            EnableControlsInGroup(groupboxMain, isEnable);
        }

        #endregion

        #region IView

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
                    _listAccounts = value.ToList();

                    _gridLookUpEditAccountView = new GridView();
                    _gridLookUpEditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccount.View.BestFitColumns();

                    _gridLookUpEditAccount.DataSource = value;
                    _gridLookUpEditAccountView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "AccountNumber",
                            ColumnCaption = "Số tài khoản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "AccountName",
                            ColumnCaption = "Tên tài khỏan",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountCategoryKind", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "AccountForeignName",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetSource",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetChapter",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetKindItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByBudgetSubItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByMethodDistribute",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByAccountingObject",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByActivity", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByProject", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByTask", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailBySupply", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByInventoryItem",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "DetailByFixedAsset",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "DetailByProjectActivity",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "DetailByInvestor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "IsDisplayOnAccountBalanceSheet",
                            ColumnVisible = false
                        },
                        new XtraColumn
                        {
                            ColumnName = "IsDisplayBalanceOnReport",
                            ColumnVisible = false
                        }
                    };

                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                    //    }
                    //_gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditAccount.ValueMember = "AccountNumber";
                    _gridLookUpEditAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditAccountView, value, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditAccountView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                    var projects = value.Where(v => v.IsActive && !v.IsParent).ToList();
                    cboTargetProgramId.Properties.DataSource = projects;
                    cboTargetProgramId.Properties.PopulateColumns();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã CTMT",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên CTMT",
                        ColumnVisible = true,
                        ColumnWith = 330,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    cboTargetProgramId.Properties.DisplayMember = "ProjectCode";
                    cboTargetProgramId.Properties.ValueMember = "ProjectId";

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
                    _gridLookUpEditProject.PopupFormSize = new Size(468, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);

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
                    //_gridLookUpEditProject.ValueMember = "ProjectCode";
                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, projects, "ProjectCode", "ProjectCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

                cboBankId.Properties.DataSource = value;
                cboBankId.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cboBankId);

                cboBankId.Properties.DisplayMember = "BankAccount";
                cboBankId.Properties.ValueMember = "BankId";
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

             //   XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);

                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
            }
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                cboObjectCode.Properties.DataSource = value;
                cboObjectCode.Properties.PopulateColumns();

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
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false }
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



            }
        }

        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>The cash withdraw type models.</value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set { _cashWithdrawTypeModels = value.ToList(); }
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
                    //_gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    //_gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, value, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    //_gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";

                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, value, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BudgetItemModels = value.ToList();
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();

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
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";

                    _gridLookUpEditFundStructureView = XtraColumnCollectionHelper<FundStructureModel>.CreateGridViewReponsitory();
                    _gridLookUpEditFundStructure = XtraColumnCollectionHelper<FundStructureModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditFundStructureView, value, "FundStructureCode", "FundStructureId", gridColumnsCollection);
                    XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);


                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IBUPlanWithdrawView

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the cash with draw.
        /// </summary>
        /// <value>The type of the cash with draw.</value>
        public int CashWithDrawType
        {
            get
            {
                var value = rndCashWithDrawType.Properties.Items[rndCashWithDrawType.SelectedIndex].Value;
                var cashWithdrawModel = _cashWithdrawTypeModels.FirstOrDefault(c => c.CashWithdrawNo == value.ToString());
                return cashWithdrawModel != null ? cashWithdrawModel.CashWithdrawTypeId : 0;
            }
            set
            {
                var cashWithdrawModel = _cashWithdrawTypeModels.FirstOrDefault(c => c.CashWithdrawTypeId == value);
                if (cashWithdrawModel != null)
                    rndCashWithDrawType.EditValue = cashWithdrawModel.CashWithdrawNo;
                else
                    rndCashWithDrawType.SelectedIndex = 0;
            }
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
        /// Gets or sets the target program identifier.
        /// </summary>
        /// <value>The target program identifier.</value>
        public string TargetProgramId
        {
            get
            {
                return cboTargetProgramId.EditValue == null ? null : cboTargetProgramId.EditValue.ToString();

            }
            set { cboTargetProgramId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId
        {
            get { return cboBankId.EditValue == null ? null : cboBankId.EditValue.ToString(); }
            set { cboBankId.EditValue = value; }
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
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public decimal TotalAmount
        {
            get { return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmount"); }
            set { gridViewMaster.SetRowCellValue(0, "TotalAmount", value); }
        }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        public decimal TotalAmountOC
        {
            get { return (decimal)gridViewMaster.GetRowCellValue(0, "TotalAmountOC"); }
            set { gridViewMaster.SetRowCellValue(0, "TotalAmountOC", value); }
        }

        /// <summary>
        /// Gets or sets the generated reference identifier.
        /// </summary>
        /// <value>
        /// The generated reference identifier.
        /// </value>
        public string GeneratedRefId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="!:BUPlanWithdrawEntity" /> is posted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if posted; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId
        {
            get { return cboBUCommitmentRequestId.EditValue == null ? null : cboBUCommitmentRequestId.EditValue.ToString(); }
            set
            {
                cboBUCommitmentRequestId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the b u transfers pay wage reference identifier.
        /// </summary>
        /// <value>
        /// The b u transfers pay wage reference identifier.
        /// </value>
        public string bUTransfersPayWageRefID { get; set; }

        /// <summary>
        /// Gets or sets the ibu plan withdraw details.
        /// </summary>
        /// <value>The ibu plan withdraw details.</value>
        public IList<BUPlanWithdrawDetailModel> BUPlanWithdrawDetails
        {
            get
            {
                var planWithdrawDetails = new List<BUPlanWithdrawDetailModel>();
                grdAccountingView.CloseEditor();
                if (grdAccountingView.DataSource != null && grdAccountingView.DataRowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUPlanWithdrawDetailModel)grdAccountingView.GetRow(i);
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
                            var item = new BUPlanWithdrawDetailModel
                            {
                                OrgRefNo = rowVoucher.OrgRefNo,
                                OrgRefDate = rowVoucher.OrgRefDate,
                                Description = rowVoucher.Description,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                ProjectId = rowVoucher.ProjectId,
                                FundStructureId = rowVoucher.FundStructureId,
                                BankId = rowVoucher.BankId,
                                SortOrder = i
                            };
                            planWithdrawDetails.Add(item);
                        }
                    }
                }

                return planWithdrawDetails;
            }
            set
            {
                if (IsOpenFromBUPlanWithdrawTransferInsurrancetDetail)
                {
                    value = ListSendSourceDetail;
                    ListSendSourceDetail = null;
                }

                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUPlanWithdrawDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefNo",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Số chứng từ gốc",
                    ColumnPosition = 1,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefDate",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Ngày chứng từ gốc",
                    ColumnPosition = 2,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.DateTime
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Nội dung thanh toán",
                    ColumnPosition = 3,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 4,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetSource
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Chương",
                    ColumnPosition = 5,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetChapter
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Khoản",
                    ColumnPosition = 6,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetSubKindItem
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Tiểu mục",
                    ColumnPosition = 7,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetSubItem
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Mục",
                    ColumnPosition = 8,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBudgetItem
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 9,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 10,
                    IsSummnary = true,
                    AllowEdit = false,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "CTMT, Dự án",
                    ColumnPosition = 11,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditProject
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BankId",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "TK Ngân hàng",
                    ColumnPosition = 11,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditBank
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });

                XtraColumnCollectionHelper<BUPlanWithdrawDetailModel>.ShowXtraColumnInGridView(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                grdAccountingView.OptionsView.ShowFooter = false;
                #endregion
            }
        }

        /// <summary>
        /// Gets or sets the accounting object bank identifier.
        /// </summary>
        /// <value>The accounting object bank identifier.</value>
        public string AccountingObjectBankId
        {
            get { return cboBankId.EditValue == null ? null : cboBankId.EditValue.ToString(); }
            set { value = BankId; }
        }

        /// <summary>
        /// Sets the bu commitment requests.
        /// </summary>
        /// <value>
        /// The bu commitment requests.
        /// </value>
        public IList<BUCommitmentRequestModel> BUCommitmentRequests
        {
            set
            {
                cboBUCommitmentRequestId.Properties.DataSource = value;
                cboBUCommitmentRequestId.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "RefNo",
                        ColumnCaption = "Số chứng từ",
                        ColumnVisible = true,
                        ColumnPosition = 1,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "RefDate",
                        ColumnCaption = "Ngày chứng từ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 330
                    },
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TABMISCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractFrameNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceKind", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsForeignCurrency", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Posted", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EditVersion", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostVersion", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectInvestmentCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectInvestmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SignDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContractAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PrevYearCommitmentAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BUCommitmentRequestDetails", ColumnVisible = false}
                };
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBUCommitmentRequestId.Properties.SortColumnIndex = column.ColumnPosition;
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboBUCommitmentRequestId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboBUCommitmentRequestId.Properties.DisplayMember = "RefNo";
                cboBUCommitmentRequestId.Properties.ValueMember = "RefId";
            }
        }

        #endregion

        #region Form EVents

        /// <summary 
        /// </summary>
        public FrmBUPlanWithDrawTransferInsurranceDetail()
        {
            InitializeComponent();

            _projectsPresenter = new ProjectsPresenter(this);
            _planWithdrawTransferInsurrancePresenter = new BUPlanWithdrawTransferInsurrancePresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _buCommitmentRequestsPresenter = new BUCommitmentRequestsPresenter(this);
            _model = new Model.Model();
        }

        /// <summary>
        /// Handles the Load event of the FrmBUPlanWithDrawTransferInsurranceDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmBUPlanWithDrawTransferInsurranceDetail_Load(object sender, EventArgs e)
        {
            RefTypeUsingDisplayReport = BuCA.Enum.RefType.BUPlanWithdrawTransferInsurrance;
            AutoProjectId = TargetProgramId;
            AutoBankId = BankId;
            AutoAccountingObjectId = AccountingObjectId;
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
                SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboBankId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboBankId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboBankId.EditValue == null)
                return;
            var bankName = (string)cboBankId.GetColumnValue("BankName");

            txtBankName.Text = bankName;

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {

                AutoBankId = BankId;
                SetDetailFromMaster(grdAccountingView, 2, AccountingObjectId, BankId, TargetProgramId);
            }

        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboObjectCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null)
                return;
            var accountingObjectName = (string)cboObjectCode.GetColumnValue("AccountingObjectName");
            var address = (string)cboObjectCode.GetColumnValue("Address");
            var bankAccount = (string)cboObjectCode.GetColumnValue("BankAccount");
            var bankName = (string)cboObjectCode.GetColumnValue("BankName");

            cboObjectName.Text = accountingObjectName;
            txtAddress.Text = address;
            txtAccountingObjectBankAccount.Text = bankAccount;
            txtAccountingObjectBankName.Text = bankName;

            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {

                AutoAccountingObjectId = AccountingObjectId;
                SetDetailFromMaster(grdAccountingView, 1, AccountingObjectId, BankId, TargetProgramId);
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

        #endregion

        #region override
        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        protected override void DeleteVoucher()
        {
            new BUPlanWithdrawPresenter(null).Delete(KeyValue);
            var buTranser = _model.GetBUTransferByBUPlanWithdrawRefId(KeyValue);
            if (buTranser != null)
            {
                int refType = buTranser.RefType;
                var refTypeName = "";
                var glRefTypeName = "";
                if (refType == (int)BuCA.Enum.RefType.BUTransferPayWage)
                {
                    refTypeName = "Chuyển khoản kho bạc trả lương";
                    glRefTypeName = "Xác định lương";
                }
                if (refType == (int)BuCA.Enum.RefType.BUTransferPayInsurrance)
                {
                    refTypeName = "Chuyển khoản kho bạc trả bảo hiểm";
                    glRefTypeName = "Xác định bảo hiểm";
                }

                string refNo = buTranser.RefNo;
                if (refNo.Length > 0)
                {
                    DialogResult dialog = XtraMessageBox.Show(string.Format("Chứng từ rút dự toán chuyển khoản trả lương, bảo hiểm có liên kết với chứng từ {0}. Bạn có muốn xóa chứng từ {1} số {2} không?", refTypeName, refTypeName, refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialog == DialogResult.Yes)
                    {
                        string glVoucherRefNo = new GLVoucherPresenter(null).GetGLVoucherByBUTransferRefId(buTranser.RefId);
                        if (glVoucherRefNo.Length > 0)
                        {
                            DialogResult glVoucharDialog = XtraMessageBox.Show(string.Format("Chứng từ {0} có liên kết với chứng từ {1}. Bạn có muốn xóa chứng từ chung số {2} không?", refTypeName, glRefTypeName, glVoucherRefNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (glVoucharDialog == DialogResult.Yes)
                            {
                                new GLVoucherPresenter(null).DeleteGLVoucherByBUTransferRefId(buTranser.RefId);
                            }
                        }
                        new BUTransferPresenter(null).DeleteBUTransferByBUTransferRefId(KeyValue);
                    }
                }
            }
        }

        /// <summary>
        /// Enables the control.
        /// </summary>
        protected override void EnableControl()
        {
            rndCashWithDrawType.Enabled = true;
            cboTargetProgramId.Enabled = true;
            cboBankId.Enabled = true;
        }

        /// <summary>
        /// Refreshes the navigation button.
        /// </summary>
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();

            rndCashWithDrawType.Enabled = false;
            cboTargetProgramId.Enabled = false;
            cboBankId.Enabled = false;
        }
        #endregion

        private void FrmBUPlanWithDrawTransferInsurranceDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(panel1, false, true);
        }


        /// <summary>
        /// Thêm mới đối tượng từ combobox
        /// </summary>
        protected override void ShowAccountingObjectDetail()
        {
            try
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
                                        cboObjectCode.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
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
                                        cboObjectCode.EditValue = GlobalVariable.EmployeeIDDetailForm;
                                    }
                                }
                            }
                            break;
                        default: break;
                    }
                    //MessageBox.Show(form.Result.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void cboBankId_ButtonClick(object sender, ButtonPressedEventArgs e)
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
                        cboBankId.EditValue = GlobalVariable.BankIDProjectDetailForm;
                    }
                }
            }
        }
    }
}