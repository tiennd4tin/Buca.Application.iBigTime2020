/***********************************************************************
 * <copyright file="frmbucommitmentadjustmentdetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using BuCA.Option;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmBUCommitmentRequestDetail.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentAdjustmentView" />
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentRequestView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountingObjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    public partial class FrmBUCommitmentAdjustmentDetail : FrmXtraBaseVoucherDetail, IBUCommitmentRequestsView, IBUCommitmentAdjustmentView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetChaptersView, IAccountingObjectsView, IBudgetItemsView, ICurrenciesView, IContractsView, ICapitalPlansView
    {
        #region IBUCommitmentAdjustmentView
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public DateTime RefDate
        {
            get { return dtRefDate.EditValue == null ? DateTime.Now : (DateTime)dtRefDate.EditValue; }
            set { dtRefDate.EditValue = value; }
        }
        public IList<BUCommitmentRequestModel> BUCommitmentRequests { get; set; }
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
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        public int RefType
        {
            get;
            set;
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
        /// Gets or sets a value indicating whether this <see cref="T:Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate.BUCommitmentRequestModel" /> is posted.
        /// </summary>
        /// <value><c>true</c> if posted; otherwise, <c>false</c>.</value>
        public bool Posted
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount
        {
            get { return cbObjectBank.EditValue == null ? null : cbObjectBank.EditValue.ToString(); }

            set { cbObjectBank.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName
        {
            get { return txtBankName.Text.Trim(); }

            set { txtBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the contract no.
        /// </summary>
        /// <value>The contract no.</value>
        public string ContractNo
        {
            get { return LookUpEditContract.EditValue == null ? null : LookUpEditContract.EditValue.ToString(); }
            set { LookUpEditContract.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the contract frame no.
        /// </summary>
        /// <value>The contract frame no.</value>
        public string ContractFrameNo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the kind of the budget source.
        /// </summary>
        /// <value>The kind of the budget source.</value>
        public int BudgetSourceKind
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is foreign currency.
        /// </summary>
        /// <value><c>true</c> if this instance is foreign currency; otherwise, <c>false</c>.</value>
        public bool IsForeignCurrency { get; set; }


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
        /// Gets or sets the post version.
        /// </summary>
        /// <value>The post version.</value>
        public int? PostVersion
        {
            get;

            set;
        }


        /// <summary>
        /// Gets or sets the sign date.
        /// </summary>
        /// <value>The sign date.</value>
        public DateTime? SignDate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the bu commitment request identifier.
        /// </summary>
        /// <value>The bu commitment request identifier.</value>
        public string BUCommitmentRequestId
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the real contract no.
        /// </summary>
        /// <value>The real contract no.</value>
        public string RealContractNo
        {
            get { return btnChooseBUCommitment.Text.Trim(); }
            set { btnChooseBUCommitment.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest adjustment.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest adjustment; otherwise, <c>false</c>.</value>
        public bool IsSuggestAdjustment
        {
            get
            {
                if (CheckIsSuggestAdjustment.Checked)
                    return true;
                else
                    return false;
            }

            set { CheckIsSuggestAdjustment.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is suggest supplement.
        /// </summary>
        /// <value><c>true</c> if this instance is suggest supplement; otherwise, <c>false</c>.</value>
        public bool IsSuggestSupplement
        {
            get
            {
                if (CheckIsSuggestSupplement.Checked)
                    return true;
                else
                    return false;
            }

            set { CheckIsSuggestSupplement.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the adjustment provider bank account.
        /// </summary>
        /// <value>The adjustment provider bank account.</value>
        public string AdjustmentProviderBankAccount
        {
            get { return cbObjectBank.EditValue == null ? null : cbObjectBank.EditValue.ToString(); }

            set { cbObjectBank.EditValue = value; }
        }


        /// <summary>
        /// Gets or sets the name of the adjustment provider bank.
        /// </summary>
        /// <value>The name of the adjustment provider bank.</value>
        public string AdjustmentProviderBankName
        {
            get { return txtBankName.Text.Trim(); }
            set { txtBankName.Text = value; }
        }


        /// <summary>
        /// Gets or sets the bu commitment adjustment details.
        /// </summary>
        /// <value>The bu commitment adjustment details.</value>
        public IList<BUCommitmentAdjustmentDetailModel> BUCommitmentAdjustmentDetails
        {
            get
            {
                var commitmentAdjustmentDetails = new List<BUCommitmentAdjustmentDetailModel>();
                if (bandedGridView.DataSource != null && bandedGridView.RowCount > 0)
                {
                    for (var i = 0; i < bandedGridView.RowCount; i++)
                    {
                        var rowVoucher = (BUCommitmentAdjustmentDetailModel)bandedGridView.GetRow(i);
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

                            var item = new BUCommitmentAdjustmentDetailModel
                            {
                                Description = string.IsNullOrEmpty(rowVoucher.Description) ? string.Empty : rowVoucher.Description.Trim(),
                                CurrencyCode = rowVoucher.CurrencyCode == null ? null : (rowVoucher.CurrencyCode.Equals("VND") ? null : rowVoucher.CurrencyCode),
                                ExchangeRate = rowVoucher.CurrencyCode == null ? rowVoucher.ExchangeRate : (rowVoucher.CurrencyCode.Equals("VND") ? 1 : rowVoucher.ExchangeRate),
                                Amount = rowVoucher.CurrencyCode == null ? rowVoucher.Amount : (rowVoucher.CurrencyCode.Equals("VND") ? rowVoucher.AmountOC : rowVoucher.Amount),
                                AmountOC = rowVoucher.AmountOC,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                CashWithDrawTypeId = rowVoucher.CashWithDrawTypeId,
                                ActivityId = rowVoucher.ActivityId,
                                ProjectId = rowVoucher.ProjectId,
                                ProjectActivityId = rowVoucher.ProjectActivityId,
                                ProjectExpenseId = rowVoucher.ProjectExpenseId,
                                TaskId = rowVoucher.TaskId,
                                ListItemId = rowVoucher.ListItemId,
                                Approved = rowVoucher.Approved,
                                FundStructureId = rowVoucher.FundStructureId,
                                SortOrder = i,
                                BankAccount = rowVoucher.BankAccount,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                ToCurrencyCode = rowVoucher.CurrencyCode == null ? null : (rowVoucher.CurrencyCode.Equals("VND") ? null : rowVoucher.ToCurrencyCode),
                                ToExchangeRate = rowVoucher.CurrencyCode == null ? rowVoucher.ToExchangeRate : (rowVoucher.CurrencyCode.Equals("VND") ? 1 : rowVoucher.ToExchangeRate),
                                ToAmountOC = rowVoucher.ToAmountOC,
                                ToAmount = rowVoucher.CurrencyCode == null ? rowVoucher.ToAmount : (rowVoucher.CurrencyCode.Equals("VND") ? rowVoucher.ToAmountOC : rowVoucher.ToAmount),
                                ToBudgetSourceId = rowVoucher.ToBudgetSourceId,
                                ToBudgetProvideCode = rowVoucher.ToBudgetProvideCode,
                                ToBudgetChapterCode = rowVoucher.ToBudgetChapterCode,
                                ToBudgetKindItemCode = rowVoucher.ToBudgetKindItemCode,
                                ToBudgetSubKindItemCode = rowVoucher.ToBudgetSubKindItemCode,
                                ToBudgetItemCode = rowVoucher.ToBudgetItemCode,
                                ToBudgetSubItemCode = rowVoucher.ToBudgetSubItemCode,
                                ToProjectId = rowVoucher.ToProjectId,
                                RemainAmountOC = rowVoucher.RemainAmountOC,
                                RemainAmount = rowVoucher.RemainAmount,
                                RemainExchangeRate = rowVoucher.RemainExchangeRate,
                                RemainCurrencyCode = rowVoucher.RemainCurrencyCode,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,

                            };
                            //totalAmount += item.Amount;
                            //totalAmountOC += item.AmountOC;
                            commitmentAdjustmentDetails.Add(item);
                        }
                        //TotalAmount = totalAmount;
                        //TotalAmountOC = totalAmountOC;
                    }
                }
                return commitmentAdjustmentDetails;
            }

            set
            {
                var bUCommitmentAdjustmentDetailModels = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUCommitmentAdjustmentDetailModel>();
                bindingSourceDetail.DataSource = bUCommitmentAdjustmentDetailModels;
                grdAccounting.MainView = bandedGridView;
                grdAccounting.ForceInitialize();
                bandedGridView.PopulateColumns(value);

                //var valueMater = new List<MasterGrid>
                //{
                //    new MasterGrid
                //    {
                //        TotalAmount = value.Sum(s => s.RemainAmount),
                //        CurrencyCode = GlobalVariable.MainCurrencyId,
                //        TotalAmountOC = value.Sum(s => s.RemainAmount),
                //        ExchangeRate = 1
                //    }
                //};
                //grdMaster.DataSource = valueMater;
                // checkIncurredCurrency.Checked = bUCommitmentAdjustmentDetailModels.Count(x => x.CurrencyCode != null) > 0;
                //if (checkIncurredCurrency.Checked)
                //{
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 18, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Quy đổi", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnCaption = "Hợp đồng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Hợp đồng", RepositoryControl = _gridLookUpEditProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnCaption = "Kế hoạch vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Kế hoạch vốn", RepositoryControl = _gridLookUpEditProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 20, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Số tiền CKC điều chỉnh quy đổi", ColumnPosition = 19, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh quy đổi", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh quy đổi", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh quy đổi", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });


                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });

                XtraColumnCollectionHelper<BUCommitmentAdjustmentDetailModel>.ShowXtraColumnInBandedGridView(ColumnsCollection, bandedGridView);
                //}
                //else
                //{
                //    ColumnsCollection.Clear();
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnVisible = false, RepositoryControl = _gridLookUpEditCurrency });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 18, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnCaption = "Hợp đồng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Hợp đồng", RepositoryControl = _gridLookUpEditProject });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnCaption = "Kế hoạch vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Kế hoạch vốn", RepositoryControl = _gridLookUpEditProject });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnVisible = false, RepositoryControl = _gridLookUpEditCurrency });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToExchangeRate", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                //    ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });

                //    //foreach (var column in ColumnsCollection)
                //    //{
                //    //    if (bandedGridView.Columns[column.ColumnName] != null)
                //    //    {
                //    //        if (column.ColumnVisible)
                //    //        {
                //    //            bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //    //            bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                //    //            bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                //    //            bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                //    //            bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                //    //            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                //    //            bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                //    //            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                //    //            bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                //    //            if (column.IsSummaryText)
                //    //            {
                //    //                bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                //    //                bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                //    //            }
                //    //        }
                //    //        else bandedGridView.Columns[column.ColumnName].Visible = false;
                //    //    }
                //    //}
                //    XtraColumnCollectionHelper<BUCommitmentAdjustmentDetailModel>.ShowXtraColumnInBandedGridView(ColumnsCollection, bandedGridView);
                //}


                LoadBandGridView();
                if (this.CurrencyCode == "VND")
                {
                    bandedGridView.Columns.ColumnByFieldName("Amount").Visible = false;
                    bandedGridView.Columns.ColumnByFieldName("RemainAmount").Visible = false;
                    bandedGridView.Columns.ColumnByFieldName("ToAmount").Visible = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the bu plan receipt detail models.
        /// </summary>
        /// <value>The bu plan receipt detail models.</value>
        private readonly BUCommitmentRequestPresenter _bUCommitmentRequestPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        /// <summary>
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BUCommitmentRequestsPresenter _bUCommitmentRequestsPresenter;
        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The b u commitment adjustment presenter
        /// </summary>
        private readonly BUCommitmentAdjustmentPresenter _bUCommitmentAdjustmentPresenter;

        #endregion

        #region bands declare
        /// <summary>
        /// The description band
        /// </summary>
        private GridBand _descriptionBand;
        /// <summary>
        /// To amount band
        /// </summary>
        private GridBand _toAmountBand;
        /// <summary>
        /// The remain amount band
        /// </summary>
        private GridBand _remainAmountBand;
        /// <summary>
        /// The fund structure band
        /// </summary>
        private GridBand _fundStructureBand;

        private GridBand _currencyBand;
        private GridBand _exchangerate;

        private GridBand _amountOC;
        private GridBand _toAmountOC;

        /// <summary>
        /// The parent band2
        /// </summary>
        private GridBand _parentBand2;
        /// <summary>
        /// The parent band2 child1
        /// </summary>
        private readonly GridBand _parentBand2Child1;
        /// <summary>
        /// The parent band2 child2
        /// </summary>
        private readonly GridBand _parentBand2Child2;
        /// <summary>
        /// The parent band2 child3
        /// </summary>
        private readonly GridBand _parentBand2Child3;
        /// <summary>
        /// The parent band2 child4
        /// </summary>
        private readonly GridBand _parentBand2Child4;
        /// <summary>
        /// The parent band2 child5
        /// </summary>
        private readonly GridBand _parentBand2Child5;
        /// <summary>
        /// The parent band2 child6
        /// </summary>
        private readonly GridBand _parentBand2Child6;
        /// <summary>
        /// The parent band2 child7
        /// </summary>
        private readonly GridBand _parentBand2Child7;

        /// <summary>
        /// The parent band3
        /// </summary>
        private GridBand _parentBand3;
        /// <summary>
        /// The parent band3 child1
        /// </summary>
        private readonly GridBand _parentBand3Child1;
        /// <summary>
        /// The parent band3 child2
        /// </summary>
        private readonly GridBand _parentBand3Child2;
        /// <summary>
        /// The parent band3 child3
        /// </summary>
        private readonly GridBand _parentBand3Child3;
        /// <summary>
        /// The parent band3 child4
        /// </summary>
        private readonly GridBand _parentBand3Child4;
        /// <summary>
        /// The parent band3 child5
        /// </summary>
        private readonly GridBand _parentBand3Child5;
        /// <summary>
        /// The parent band3 child6
        /// </summary>
        private readonly GridBand _parentBand3Child6;
        /// <summary>
        /// The parent band3 child7
        /// </summary>
        private readonly GridBand _parentBand3Child7;


        #endregion bands declare

        #region RepositoryItemGridLookUpEdit

        private readonly ContractsPresenter _contractsPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;



        //private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        // private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;
        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit debit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        /// <summary>
        /// The grid look up edit debit account view
        /// </summary>
        private GridView _gridLookUpEditDebitAccountView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The grid look up edit bank
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        /// <summary>
        /// The grid look up edit bank view
        /// </summary>
        private GridView _gridLookUpEditBankView;

        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        /// <summary>
        /// The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        /// <summary>
        /// The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        /// <summary>
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditBudgetItemView;

        /// <summary>
        /// The grid look up edit budget item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditCurrency;
        /// <summary>
        /// The grid look up edit budget item view
        /// </summary>
        private GridView _gridLookUpEditCurrencyView;

        /// <summary>
        /// The grid look up edit budget sub item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        /// <summary>
        /// The grid look up edit budget sub item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubItemView;
        private List<BudgetKindItemModel> _budgetKindItemModels;

        #endregion

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
        }

        #endregion

        #region Function
        /// <summary>
        /// Loads the band grid view.
        /// </summary>
        private void LoadBandGridView()
        {

            if (bandedGridView.Bands.Count <= 0)
            {
                _descriptionBand = bandedGridView.Bands.AddBand("Description");
                _parentBand2 = bandedGridView.Bands.AddBand("Parent2");
                _parentBand3 = bandedGridView.Bands.AddBand("Parent3");

                _remainAmountBand = bandedGridView.Bands.AddBand("RemainAmount");
                _toAmountBand = bandedGridView.Bands.AddBand("ToAmount");
                _fundStructureBand = bandedGridView.Bands.AddBand("FundStructureId");
            }

            #region Diễn giải

            _descriptionBand.Caption = @"Diễn giải";
            _descriptionBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _descriptionBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
            bandedGridView.Columns["Description"].OwnerBand = _descriptionBand;
            bandedGridView.Columns["Description"].Visible = true;
            bandedGridView.Columns["Description"].VisibleIndex = 1;
            bandedGridView.Columns["Description"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            #region Thông tin đã hạch toán

            _parentBand2.Caption = @"Thông tin đã hạch toán";
            _parentBand2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;



            _parentBand2Child1.Caption = @"Nguồn";
            _parentBand2Child1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child1.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child2.Caption = @"Chương";
            _parentBand2Child2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child3.Caption = @"Khoản";
            _parentBand2Child3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child4.Caption = @"Tiểu mục";
            _parentBand2Child4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child4.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child5.Caption = @"Mục";
            _parentBand2Child5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child5.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child6.Caption = @"Dự án";
            _parentBand2Child6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child6.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand2Child7.Caption = @"Số tiền";
            _parentBand2Child7.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand2Child7.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["BudgetSourceId"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetSourceId"].Visible = true;
            bandedGridView.Columns["BudgetSourceId"].VisibleIndex = 9;
            bandedGridView.Columns["BudgetSourceId"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["BudgetSourceId"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["BudgetChapterCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetChapterCode"].Visible = true;
            bandedGridView.Columns["BudgetChapterCode"].VisibleIndex = 10;
            bandedGridView.Columns["BudgetChapterCode"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["BudgetChapterCode"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["BudgetSubKindItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetSubKindItemCode"].Visible = true;
            bandedGridView.Columns["BudgetSubKindItemCode"].VisibleIndex = 11;
            bandedGridView.Columns["BudgetSubKindItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["BudgetSubKindItemCode"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["BudgetSubItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetSubItemCode"].Visible = true;
            bandedGridView.Columns["BudgetSubItemCode"].VisibleIndex = 12;
            bandedGridView.Columns["BudgetSubItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["BudgetSubItemCode"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["BudgetItemCode"].OwnerBand = _parentBand2;
            bandedGridView.Columns["BudgetItemCode"].Visible = true;
            bandedGridView.Columns["BudgetItemCode"].VisibleIndex = 13;
            bandedGridView.Columns["BudgetItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["BudgetItemCode"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["ProjectId"].OwnerBand = _parentBand2;
            bandedGridView.Columns["ProjectId"].Visible = true;
            bandedGridView.Columns["ProjectId"].VisibleIndex = 14;
            bandedGridView.Columns["ProjectId"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["ProjectId"].OptionsColumn.AllowEdit = false;

            bandedGridView.Columns["AmountOC"].OwnerBand = _parentBand2;
            bandedGridView.Columns["AmountOC"].Visible = true;
            bandedGridView.Columns["AmountOC"].VisibleIndex = 15;
            bandedGridView.Columns["AmountOC"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["AmountOC"].OptionsColumn.AllowEdit = false;


            //if (checkIncurredCurrency.Checked)
            //{
            // Hiển thị cột loại tiền
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Caption = "Loại tiền";
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].OwnerBand = _parentBand2;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Visible = false;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].VisibleIndex = 12;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].OptionsColumn.AllowSort = DefaultBoolean.False;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].ColumnEdit =
            //    _gridLookUpEditCurrency;

            // Hiển thị cột tỷ giá
            //bandedGridView.Columns["ExchangeRate"].Caption = "Tỷ giá";
            //bandedGridView.Columns["ExchangeRate"].OwnerBand = _parentBand2;
            //bandedGridView.Columns["ExchangeRate"].Visible = false;
            //bandedGridView.Columns["ExchangeRate"].VisibleIndex = 13;
            //bandedGridView.Columns["ExchangeRate"].OptionsColumn.AllowSort = DefaultBoolean.False;

            // Hiển thị cột quy đổi
            bandedGridView.Columns["Amount"].Caption = "Quy đổi";
            bandedGridView.Columns["Amount"].OwnerBand = _parentBand2;
            bandedGridView.Columns["Amount"].Visible = true;
            bandedGridView.Columns["Amount"].VisibleIndex = 14;
            bandedGridView.Columns["Amount"].OptionsColumn.AllowSort = DefaultBoolean.False;
            //}
            //else
            //{
            //    bandedGridView.Columns["Amount"].Visible = false;
            //    bandedGridView.Columns["ExchangeRate"].Visible = false;
            //    bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Visible = false;

            //}
            #endregion

            #region Thông tin đề nghị điều chỉnh

            _parentBand3.Caption = @"Thông tin đề nghị điều chỉnh";
            _parentBand3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;


            _parentBand3Child1.Caption = @"Nguồn";
            _parentBand3Child1.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child1.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child2.Caption = @"Chương";
            _parentBand3Child2.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child2.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child3.Caption = @"Khoản";
            _parentBand3Child3.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child3.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child4.Caption = @"tiểu mục";
            _parentBand3Child4.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child4.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child5.Caption = @"Mục";
            _parentBand3Child5.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child5.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            _parentBand3Child6.Caption = @"Dự án";
            _parentBand3Child6.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _parentBand3Child6.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;



            bandedGridView.Columns["ToBudgetSourceId"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetSourceId"].Visible = true;
            bandedGridView.Columns["ToBudgetSourceId"].VisibleIndex = 2;
            bandedGridView.Columns["ToBudgetSourceId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetChapterCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetChapterCode"].Visible = true;
            bandedGridView.Columns["ToBudgetChapterCode"].VisibleIndex = 3;
            bandedGridView.Columns["ToBudgetChapterCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetSubKindItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetSubKindItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetSubKindItemCode"].VisibleIndex = 4;
            bandedGridView.Columns["ToBudgetSubKindItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetSubItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetSubItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetSubItemCode"].VisibleIndex = 5;
            bandedGridView.Columns["ToBudgetSubItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToBudgetItemCode"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToBudgetItemCode"].Visible = true;
            bandedGridView.Columns["ToBudgetItemCode"].VisibleIndex = 6;
            bandedGridView.Columns["ToBudgetItemCode"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToProjectId"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToProjectId"].Visible = true;
            bandedGridView.Columns["ToProjectId"].VisibleIndex = 7;
            bandedGridView.Columns["ToProjectId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            bandedGridView.Columns["ToAmountOC"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToAmountOC"].Visible = true;
            bandedGridView.Columns["ToAmountOC"].VisibleIndex = 8;
            bandedGridView.Columns["ToAmountOC"].OptionsColumn.AllowSort = DefaultBoolean.False;

            //if (checkIncurredCurrency.Checked)
            //{
            // Hiển thị cột loại tiền
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Caption = "Loại tiền";
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].OwnerBand = _parentBand3;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Visible = false;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].VisibleIndex = 12;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].OptionsColumn.AllowSort = DefaultBoolean.False;
            //bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].ColumnEdit =
            //    _gridLookUpEditCurrency;

            // Hiển thị cột tỷ giá
            //bandedGridView.Columns["ToExchangeRate"].Caption = "Tỷ giá";
            //bandedGridView.Columns["ToExchangeRate"].OwnerBand = _parentBand3;
            //bandedGridView.Columns["ToExchangeRate"].Visible = false;
            //bandedGridView.Columns["ToExchangeRate"].VisibleIndex = 13;
            //bandedGridView.Columns["ToExchangeRate"].OptionsColumn.AllowSort = DefaultBoolean.False;

            // Hiển thị cột quy đổi
            bandedGridView.Columns["ToAmount"].Caption = "Quy đổi";
            bandedGridView.Columns["ToAmount"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToAmount"].Visible = true;
            bandedGridView.Columns["ToAmount"].VisibleIndex = 14;
            bandedGridView.Columns["ToAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;
            //}
            //else
            //{
            //    bandedGridView.Columns["ToAmount"].Visible = false;
            //    bandedGridView.Columns["ToExchangeRate"].Visible = false;
            //    bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Visible = false;

            //}
            #endregion

            #region Số tiền CKC sau điều chỉnh

            _remainAmountBand.Caption = @"Số tiền CKC sau điều chỉnh";
            _remainAmountBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _remainAmountBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["RemainAmountOC"].OwnerBand = _remainAmountBand;
            bandedGridView.Columns["RemainAmountOC"].Visible = true;
            bandedGridView.Columns["RemainAmountOC"].VisibleIndex = 25;
            bandedGridView.Columns["RemainAmountOC"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["RemainAmountOC"].OptionsColumn.AllowEdit = false;
            _remainAmountBand.Caption = @"Số tiền CKC sau điều chỉnh quy đổi";
            _remainAmountBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _remainAmountBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["RemainAmount"].OwnerBand = _remainAmountBand;
            bandedGridView.Columns["RemainAmount"].Visible = true;
            bandedGridView.Columns["RemainAmount"].VisibleIndex = 26;
            bandedGridView.Columns["RemainAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["RemainAmount"].OptionsColumn.AllowEdit = false;
            #endregion

            #region Số tiền CKC điều chỉnh
            // đẩy cột số tiền vào group Thông tin đề nghị điều chỉnh
            _toAmountBand.Visible = false;
            //_toAmountBand.Caption = @"Số tiền CKC điều chỉnh";
            //_toAmountBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //_toAmountBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            //bandedGridView.Columns["ToAmount"].OwnerBand = _toAmountBand;
            //bandedGridView.Columns["ToAmount"].Visible = true;
            //bandedGridView.Columns["ToAmount"].VisibleIndex = 26;
            //bandedGridView.Columns["ToAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            #region Khoản chi

            _fundStructureBand.Caption = @"Khoản chi";
            _fundStructureBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            _fundStructureBand.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

            bandedGridView.Columns["FundStructureId"].OwnerBand = _fundStructureBand;
            bandedGridView.Columns["FundStructureId"].Visible = true;
            bandedGridView.Columns["FundStructureId"].VisibleIndex = 27;
            bandedGridView.Columns["FundStructureId"].OptionsColumn.AllowSort = DefaultBoolean.False;

            #endregion

            bandedGridView.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            bandedGridView.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;
            bandedGridView.OptionsView.AllowHtmlDrawHeaders = true;

            new GridBandPaintHelper(bandedGridView, new[] { _descriptionBand, _remainAmountBand, _toAmountBand, _fundStructureBand });

            SetNumericFormatGridBand(bandedGridView, true);
        }
        #endregion

        #region overrides
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBUCommitmentRequestDetail" /> class.
        /// </summary>
        public FrmBUCommitmentAdjustmentDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _bUCommitmentAdjustmentPresenter = new BUCommitmentAdjustmentPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _bUCommitmentRequestsPresenter = new BUCommitmentRequestsPresenter(this);
            _descriptionBand = new GridBand();
           
            _parentBand2 = new GridBand();
            _parentBand2Child1 = new GridBand();
            _parentBand2Child2 = new GridBand();
            _parentBand2Child3 = new GridBand();
            _parentBand2Child4 = new GridBand();
            _parentBand2Child5 = new GridBand();
            _parentBand2Child6 = new GridBand();
            _parentBand2Child7 = new GridBand();

            _parentBand3 = new GridBand();
            _parentBand3Child1 = new GridBand();
            _parentBand3Child2 = new GridBand();
            _parentBand3Child3 = new GridBand();
            _parentBand3Child4 = new GridBand();
            _parentBand3Child5 = new GridBand();
            _parentBand3Child6 = new GridBand();

            _remainAmountBand = new GridBand();
            _toAmountBand = new GridBand();
            _fundStructureBand = new GridBand();

        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdMaster.Location = new Point(7, 252);
            // tabMain.Location = new Point(6, 282);
            tabMain.SelectedTabPage = tabInventoryItem;
            //tabMain.Size = new Size(998,290);
            grdMaster.Visible = true;
        }

        protected override void EnableControl()
        {
            btnChooseBUCommitment.Enabled = true;
            cbObjectBank.Enabled = true;
        }

        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();

            btnChooseBUCommitment.Enabled = false;
            cbObjectBank.Enabled = false;
        }

        protected override void SetEnableGroupBox(bool isEnable)
        {
            checkIncurredCurrency.Enabled = isEnable;

            bandedGridView.OptionsBehavior.Editable = isEnable;
            bandedGridView.OptionsBehavior.ReadOnly = !isEnable;
            bandedGridView.FocusRectStyle = DrawFocusRectStyle.None;
            bandedGridView.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            bandedGridView.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;

            btnChooseBUCommitment.Enabled = isEnable;
            //txtAdjustBankAccount.Enabled = isEnable;
            //txtAdjustBankName.Enabled = isEnable;
            txtBankName.Enabled = isEnable;
            //txtAccount.Enabled = isEnable;
            cbObjectBank.Enabled = isEnable;


        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();
            _fundStructuresPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _accountingObjectsPresenter.DisplayByIsCustomerVendor(true);
            _bUCommitmentRequestsPresenter.Display();
            InitRepositoryControlData();

            if (KeyValue == null)
            {
                //  dateSignDate.EditValue = DateTime.Now;
                PostedDate = DateTime.Now;
                RefDate = DateTime.Now;
                ;

                CheckIsSuggestAdjustment.Checked = false;
                CheckIsSuggestSupplement.Checked = false;

            }
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((BUCommitmentAdjustmentModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null)
                {
                    if (MasterBindingSource.Current != null && KeyValue == null)
                        KeyValue = ((BUCommitmentAdjustmentModel)MasterBindingSource.Current).RefId;
                }
            }

            _bUCommitmentAdjustmentPresenter.Display(KeyValue);
            LoadFirstObject();


            if (RefType == 0)
                RefType = (int)BuCA.Enum.RefType.BUCommitmentAdjustment;
        }
        private void LoadFirstObject()
        {
            var bUCommitmentRequest = this.BUCommitmentRequests.FirstOrDefault(b => b.RefId == this.BUCommitmentRequestId);
            if (bUCommitmentRequest != null)
            {
                IModel model = new Model.Model();
                var objectBanks = model.GetProjectBank(bUCommitmentRequest.AccountingObjectId);
                this.AccountingObjectId = bUCommitmentRequest.AccountingObjectId;
                this.AccountingObjectBanks = objectBanks;
            }
        }
        public string AccountingObjectId { get; set; }
        private void cbObjectBank_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                if (this.AccountingObjectId != null)
                {
                    IModel model = new Model.Model();
                    FrmXtraAccountingObjectDetail frmXtraAccountingObjectDetail = new FrmXtraAccountingObjectDetail();

                    frmXtraAccountingObjectDetail.KeyValue = this.AccountingObjectId;
                    var bankCurrent = model.GetProjectBank(AccountingObjectId) == null ? null : model.GetProjectBank(AccountingObjectId);
                    frmXtraAccountingObjectDetail.ShowDialog();

                    if (frmXtraAccountingObjectDetail.CloseBox)
                    {
                        var banks = model.GetProjectBank(AccountingObjectId) == null ? null : model.GetProjectBank(AccountingObjectId);
                        cbObjectBank.Properties.DataSource = model.GetProjectBank(AccountingObjectId);
                        if(bankCurrent!=null&& banks!=null&& bankCurrent.Count< banks.Count)
                        {
                            cbObjectBank.EditValue = banks.FirstOrDefault().BankAccount;
                            txtBankName.EditValue = banks.FirstOrDefault().BankName;
                        }
                        //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
                        //{
                        //    this._accountingObjectsPresenter.DisplayAccountingObjectCategoryId(lookUpEditAccountingObject.EditValue.ToString());
                        //    // AutoProjectId = TargetProgramId;
                        //    //SetDetailFromMaster(grdAccountingView, 3, AccountingObjectId, BankId, TargetProgramId);
                        //    _accountingObjectPresenter.DisplayAccoutingObjectBanks(this.AccountingObjectId);
                        //}
                    }
                }
            }
        }
        private void cboObjectBank_EditValueChanged(object sender, EventArgs e)
        {
            if (cbObjectBank.EditValue == null)
                return;

            var bankName = (string)cbObjectBank.GetColumnValue("BankName");
            txtBankName.Text = bankName;
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
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCommitmentAdjustmentRefNo"), detailContent,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            var buCommitmentRequestDetails = BUCommitmentAdjustmentDetails;
            if (buCommitmentRequestDetails.Count == 0)
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
                view.SetRowCellValue(e.RowHandle, "DebitAccount", "008");
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
                view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
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
                //view.SetRowCellValue(e.RowHandle, "DebitAccount", "1111");
                //view.SetRowCellValue(e.RowHandle, "Amount", 0);
                //view.SetRowCellValue(e.RowHandle, "BudgetChapterCode", "423");
                //view.SetRowCellValue(e.RowHandle, "BudgetSubKindItemCode", "521");
                //view.SetRowCellValue(e.RowHandle, "MethodDistributeId", 0);
                //view.SetRowCellValue(e.RowHandle, "CashWithdrawTypeId", 0);
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
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = KeyValue;
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = null;
            return _bUCommitmentAdjustmentPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            new BUCommitmentAdjustmentPresenter(null).Delete(KeyValue);

        }

        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            try
            {
                if (!e.Column.FieldName.Equals("DetailBy"))
                {
                    var debitAccount = grdDetailByInventoryItemView.GetFocusedRowCellValue("DebitAccount");
                    var accountNumberDetailBy = "";
                    if (debitAccount != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(debitAccount.ToString());
                    }

                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override void LoadGridDetailLayout()
        {
            // Override để khỏi lỗi form
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
                    _gridLookUpEditBudgetSource.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSource.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSource.NullText = "";
                    _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Mã nguồn vốn",ColumnVisible = true,ColumnWith = 100,ColumnPosition = 1},
                            new XtraColumn {ColumnName = "BudgetSourceName",ColumnCaption = "Tên nguồn vốn",ColumnVisible = true,ColumnWith = 250,ColumnPosition = 2}
                        };
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
                    var debitAccounts = value;
                    var creditAccounts = value.Where(c => c.AccountNumber.IndexOf("0", StringComparison.Ordinal) == 0).ToList();
                    #region gridLookUpEditDebitAccountView
                    _gridLookUpEditDebitAccountView = new GridView();
                    _gridLookUpEditDebitAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDebitAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDebitAccountView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDebitAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDebitAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDebitAccount.View.BestFitColumns();
                    _gridLookUpEditDebitAccount.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditDebitAccount.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditDebitAccount.NullText = "";
                    _gridLookUpEditDebitAccount.KeyDown += _gridLookUpEditDebitAccountView_KeyDown;


                    _gridLookUpEditDebitAccount.DataSource = debitAccounts;
                    _gridLookUpEditDebitAccountView.PopulateColumns(debitAccounts);

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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });

                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditDebitAccountView.Columns[column.ColumnName].Visible = false;
                    //}
                    //_gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditDebitAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);
                    #endregion
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

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
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };
                    //foreach (var column in gridColumnsCollection)
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                    //            column.ColumnCaption;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                    //            column.ColumnPosition;
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //    {
                    //        _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                    //    }
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

        #region Banks

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

                    _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                    gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

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




                    #region Lookup InvestProject


                    // lookupProject.Properties.DataSource = value;
                    // lookupProject.Properties.PopulateColumns();

                    var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã dự án đầu tư",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên dự án đầu tư",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "StartDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false },
                    new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ParentID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false },
                    new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Investment", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false },
                };
                    foreach (var column in columnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            //     lookupProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            //    lookupProject.Properties.SortColumnIndex = column.ColumnPosition;
                            //    lookupProject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            //  lookupProject.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    //   lookupProject.Properties.DisplayMember = "ProjectCode";
                    //   lookupProject.Properties.ValueMember = "ProjectCode";

                    #endregion


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
                        ColumnCaption = "Mã Khoản chi",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên Khoản chi",
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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                    //    }
                    //    else
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    //}
                    //XtraColumnCollectionHelper<FundStructureModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditFundStructureView);
                    //_gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    //_gridLookUpEditFundStructure.ValueMember = "FundStructureId";

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
                    return;

                _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);
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
                //  lookupVendor.Properties.DataSource = value;
                //  lookupVendor.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã nhà cung cấp",
                        ColumnVisible = true,
                        ColumnPosition = 0,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên nhà cung cấp",
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
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetChapterName", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false },
                    new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                    new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false }
                };
                //foreach (var column in columnsCollection)
                //{
                //    if (lookupVendor.Properties.Columns[column.ColumnName] != null)
                //    {
                //        if (column.ColumnVisible)
                //        {
                //            lookupVendor.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //            lookupVendor.Properties.SortColumnIndex = column.ColumnPosition;
                //            lookupVendor.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                //        }
                //        else
                //        {
                //            lookupVendor.Properties.Columns[column.ColumnName].Visible = false;
                //        }
                //    }

                //}
                //lookupVendor.Properties.DisplayMember = "AccountingObjectCode";
                //lookupVendor.Properties.ValueMember = "AccountingObjectId";
            }
        }
        #endregion

        #region BudgetItem
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
                    var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && v.IsActive == true).ToList();
                    var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && v.IsActive == true).ToList();

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
                    //foreach (var column in gridColumnsCollection)
                    //{
                    //    if (column.ColumnVisible)
                    //    {
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //        _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
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
                    //        _gridLookUpEditBudgetSubItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
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
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Currency

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        //public IList<CurrencyModel> Currencies
        //{
        //    set
        //    {
        //        try
        //        {
        //            _gridLookUpEditCurrencyView = new GridView();
        //            _gridLookUpEditCurrencyView.OptionsView.ColumnAutoWidth = false;
        //            _gridLookUpEditCurrency = new RepositoryItemGridLookUpEdit
        //            {
        //                NullText = "",
        //                View = _gridLookUpEditCurrencyView,
        //                TextEditStyle = TextEditStyles.Standard
        //            };
        //            _gridLookUpEditCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
        //            _gridLookUpEditCurrency.View.OptionsView.ShowIndicator = false;
        //            _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);

        //            _gridLookUpEditCurrency.View.BestFitColumns();

        //            _gridLookUpEditCurrency.DataSource = value;
        //            _gridLookUpEditCurrencyView.PopulateColumns(value);
        //            var gridColumnsCollection = new List<XtraColumn>
        //            {
        //                new XtraColumn {ColumnName = "CurrencyId", ColumnVisible = false},
        //                new XtraColumn
        //                {
        //                    ColumnName = "CurrencyCode",
        //                    ColumnCaption = "Mã tiền",
        //                    ColumnPosition = 1,
        //                    ColumnVisible = true,
        //                    ColumnWith = 100
        //                },
        //                new XtraColumn
        //                {
        //                    ColumnName = "CurrencyName",
        //                    ColumnCaption = "Tiền tệ",
        //                    ColumnPosition = 2,
        //                    ColumnVisible = true,
        //                    ColumnWith = 250
        //                },
        //                new XtraColumn {ColumnName = "Prefix", ColumnVisible = false},
        //                new XtraColumn {ColumnName = "Suffix", ColumnVisible = false},
        //                new XtraColumn {ColumnName = "IsMain", ColumnVisible = false},
        //                new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
        //            };
        //            foreach (var column in gridColumnsCollection)
        //                if (column.ColumnVisible)
        //                {
        //                    _gridLookUpEditCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //                    _gridLookUpEditCurrencyView.Columns[column.ColumnName].VisibleIndex =
        //                        column.ColumnPosition;
        //                    _gridLookUpEditCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;
        //                }
        //                else
        //                {
        //                    _gridLookUpEditCurrencyView.Columns[column.ColumnName].Visible = false;
        //                }
        //            _gridLookUpEditCurrency.DisplayMember = "CurrencyCode";
        //            _gridLookUpEditCurrency.ValueMember = "CurrencyCode";
        //        }
        //        catch (Exception ex)
        //        {
        //            XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
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
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractNameEnglish", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "SignDate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "EndDate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "VendorBankAccountId", ColumnVisible = false });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                LookUpEditContract.Properties.DataSource = value;
                LookUpEditContract.Properties.PopulateColumns();
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        LookUpEditContract.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        LookUpEditContract.Properties.SortColumnIndex = column.ColumnPosition;
                        LookUpEditContract.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        LookUpEditContract.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                LookUpEditContract.Properties.DisplayMember = "ContractNo";
                LookUpEditContract.Properties.ValueMember = "ContractNo";
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
                //_gridLookUpEditContract.EndUpdate();
            }
        }

        #endregion

        #endregion

        #region Control Events

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
        /// Handles the KeyDown event of the _gridLookUpEditBudgetSubKindItemView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void _gridLookUpEditBudgetSubKindItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetKindItemCode"];
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
        /// Handles the KeyDown event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the CellValueChanged event of the bandedGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void bandedGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            IModel model = new Model.Model();

            if (e.Column.FieldName == "BudgetSubItemCode")
            {
                var budgetSubItemCode = (string)bandedGridView.GetRowCellValue(e.RowHandle, "BudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var budgetItemCode = model.GetBudgetItem(item.ParentId);
                    bandedGridView.SetRowCellValue(e.RowHandle, "BudgetItemCode", budgetItemCode.BudgetItemCode);
                }

            }
            if (e.Column.FieldName == "ToBudgetSubItemCode")
            {
                var budgetSubItemCode = (string)bandedGridView.GetRowCellValue(e.RowHandle, "ToBudgetSubItemCode");
                var budgetItem = model.GetBudgetItems().Where(x => x.BudgetItemCode == budgetSubItemCode);

                foreach (var item in budgetItem)
                {
                    var budgetItemCode = model.GetBudgetItem(item.ParentId);
                    bandedGridView.SetRowCellValue(e.RowHandle, "ToBudgetItemCode", budgetItemCode.BudgetItemCode);
                }
            }
            if (e.Column.FieldName == "ToAmountOC")
            {
                var Amount = bandedGridView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "Amount");
                var AmountOC = bandedGridView.GetRowCellValue(e.RowHandle, "AmountOC") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "AmountOC");
                var toAmountOC = bandedGridView.GetRowCellValue(e.RowHandle, "ToAmountOC") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "ToAmountOC");
                //var toAmount = bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount");
                var exchangeRate = gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null ? 1 : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                bandedGridView.SetRowCellValue(e.RowHandle, "ToAmount", toAmountOC * exchangeRate);
                var toAmount = bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount");
                //bandedGridView.SetRowCellValue(e.RowHandle, "ToAmount", toAmountOC * exchangeRate);
                bandedGridView.SetRowCellValue(e.RowHandle, "RemainAmountOC", AmountOC + toAmountOC);
                bandedGridView.SetRowCellValue(e.RowHandle, "RemainAmount", Amount + toAmount);

            }
            if (e.Column.FieldName == "ToAmount")
            {
                var toAmount = bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "ToAmount");
                var Amount = bandedGridView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)bandedGridView.GetRowCellValue(e.RowHandle, "Amount");
                bandedGridView.SetRowCellValue(e.RowHandle, "RemainAmount", toAmount + Amount);
            }
            if (e.Column.FieldName == "RemainAmount")
            {
                decimal totalAmountOC = 0;
                for (var i = 0; i < bandedGridView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmountOC += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = bandedGridView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmountOC += (decimal)bandedGridView.GetRowCellValue(i, "RemainAmount");
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmountOC += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmountOC);
            }
            if (e.Column.FieldName == "RemainAmountOC")
            {
                decimal totalAmountOC = 0;
                for (var i = 0; i < bandedGridView.RowCount; i++)
                {
                    if (e.RowHandle < 0 && e.RowHandle == i)
                    {
                        totalAmountOC += (decimal)e.Value;
                    }
                    else
                    {
                        var rowVoucher = bandedGridView.GetRow(i);
                        if (rowVoucher != null)
                            totalAmountOC += (decimal)bandedGridView.GetRowCellValue(i, "RemainAmountOC"); ;
                    }
                }
                if (e.RowHandle < 0 || IsCopyRow)
                    totalAmountOC += (decimal)e.Value;
                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
            }
        }

        ///// <summary>
        ///// Handles the CellValueChanged event of the grdAccountingView control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        //private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        //{
        //    try
        //    {
        //        if (!e.Column.FieldName.Equals("DetailBy"))
        //        {
        //            var debitAccount = grdDetailByInventoryItemView.GetFocusedRowCellValue("DebitAccount");
        //            var accountNumberDetailBy = "";
        //            if (debitAccount != null)
        //            {
        //                accountNumberDetailBy = GetAccountDetailBy(debitAccount.ToString());
        //            }

        //            var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
        //            var detail = string.Join(";", detailByArray);
        //            grdDetailByInventoryItemView.SetRowCellValue(e.RowHandle, "DetailBy", detail);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.ToString(),
        //            ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }
        //}

        private void bandedGridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var view = (GridView)sender;
            if (view != null)
                SetDefaultValue(view);
        }
        #endregion
        public string CurrencyCode
        {
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
        }
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
                if (value == null || value == 0)
                    value = 1;
                gridViewMaster.SetRowCellValue(0, "ExchangeRate", value);
            }
        }
        /// <summary>
        /// Handles the CheckedChanged event of the checkIncurredCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void checkIncurredCurrency_CheckedChanged(object sender, EventArgs e)
        {
            //if (ActionMode != ActionModeVoucherEnum.None)
            //{
            //    AddBandGridView();
            //}
            CheckEdit check = sender as CheckEdit;
            if (check.IsEditorActive)
            {
                LoadBandGridView();
                //_bUCommitmentRequestPresenter.DisplayNoIsForeignCurrency(KeyValue);
                //_bUCommitmentRequestPresenter.Display(KeyValue);
                // Đặt về ngày hiện tại
                InitRefInfo();
            }
        }
        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            this.IsForeignCurrency = visibale;
            ShowAmountByCurrencyCode(bandedGridView, "Amount", visibale);
            ShowAmountByCurrencyCode(bandedGridView, "RemainAmount", visibale);
            ShowAmountByCurrencyCode(bandedGridView, "ToAmount", visibale);
        }
        protected override void SetAmountByExchangeRate(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "ExchangeRate" || e.Column.FieldName == "TotalAmountOC")
            {
                try
                {
                    var exchangeRate = gridViewMaster.Columns.ColumnByFieldName("ExchangeRate") == null || gridViewMaster.GetRowCellValue(0, "ExchangeRate") == null
                    ? 0
                    : (decimal)gridViewMaster.GetRowCellValue(0, "ExchangeRate");
                    exchangeRate = exchangeRate == 0 ? 1 : exchangeRate;
                    for (var i = 0; i < bandedGridView.RowCount; i++)
                    {
                        var remainAmount = (bandedGridView.Columns.ColumnByFieldName("RemainAmount") == null || bandedGridView.GetRowCellValue(i, "RemainAmount") == null)
                             ? 0
                            : (decimal)bandedGridView.GetRowCellValue(i, "RemainAmount");
                        var amountOC = (bandedGridView.Columns.ColumnByFieldName("AmountOC") == null || bandedGridView.GetRowCellValue(i, "AmountOC") == null)
                                 ? 0
                                : (decimal)bandedGridView.GetRowCellValue(i, "AmountOC");

                        var ToamountOC = (bandedGridView.Columns.ColumnByFieldName("ToAmountOC") == null || bandedGridView.GetRowCellValue(i, "ToAmountOC") == null)
                                ? 0
                               : (decimal)bandedGridView.GetRowCellValue(i, "ToAmountOC");
                        if (amountOC + ToamountOC > 0)
                        {
                            bandedGridView.SetRowCellValue(i, "RemainAmountOC", (decimal)(amountOC + ToamountOC));
                        }
                        if (ToamountOC * exchangeRate > 0)
                        {
                            bandedGridView.SetRowCellValue(i, "ToAmount", (decimal)(ToamountOC * exchangeRate));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        public void AddBandGridView()
        {
            //if (checkIncurredCurrency.Checked)
            //{
            // Hiển thị phần thông tin đã hạch toán
            // Hiển thị cột loại tiền
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Caption =
                @"Loại tiền";
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].OwnerBand =
                _parentBand2;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Visible = false;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].VisibleIndex = 12;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].OptionsColumn
                .AllowSort = DefaultBoolean.False;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].ColumnEdit =
                _gridLookUpEditCurrency;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Width = 100;

            // Hiển thị cột tỷ giá
            bandedGridView.Columns["ExchangeRate"].Caption = @"Tỷ giá";
            bandedGridView.Columns["ExchangeRate"].OwnerBand = _parentBand2;
            bandedGridView.Columns["ExchangeRate"].Visible = false;
            bandedGridView.Columns["ExchangeRate"].VisibleIndex = 13;
            bandedGridView.Columns["ExchangeRate"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["ExchangeRate"].DisplayFormat.FormatType = FormatType.Numeric;
            bandedGridView.Columns["ExchangeRate"].DisplayFormat.FormatString =
                @"c" + GlobalVariable.CurrencyDecimalDigits;
            bandedGridView.Columns["ExchangeRate"].Width = 100;

            // Hiển thị cột quy đổi
            bandedGridView.Columns["Amount"].Caption = @"Quy đổi";
            bandedGridView.Columns["Amount"].OwnerBand = _parentBand2;
            bandedGridView.Columns["Amount"].Visible = true;
            bandedGridView.Columns["Amount"].VisibleIndex = 14;
            bandedGridView.Columns["Amount"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["Amount"].DisplayFormat.FormatType = FormatType.Numeric;
            bandedGridView.Columns["Amount"].DisplayFormat.FormatString = @"c" +
                                                                          GlobalVariable.CurrencyDecimalDigits;
            bandedGridView.Columns["Amount"].Width = 100;

            //Hiển thị phần Thông tin điều chỉnh
            // Hiển thị cột loại tiền
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Caption =
                @"Loại tiền";
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].OwnerBand =
                _parentBand3;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Visible = false;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].VisibleIndex = 12;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].OptionsColumn
                .AllowSort = DefaultBoolean.False;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].ColumnEdit =
                _gridLookUpEditCurrency;
            bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Width = 100;

            // Hiển thị cột tỷ giá
            bandedGridView.Columns["ToExchangeRate"].Caption = @"Tỷ giá";
            bandedGridView.Columns["ToExchangeRate"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToExchangeRate"].Visible = false;
            bandedGridView.Columns["ToExchangeRate"].VisibleIndex = 13;
            bandedGridView.Columns["ToExchangeRate"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["ToExchangeRate"].DisplayFormat.FormatType = FormatType.Numeric;
            bandedGridView.Columns["ToExchangeRate"].DisplayFormat.FormatString = @"c" +
                                                                                  GlobalVariable
                                                                                      .CurrencyDecimalDigits;
            bandedGridView.Columns["ToExchangeRate"].Width = 100;

            // Hiển thị cột quy đổi
            bandedGridView.Columns["ToAmount"].Caption = @"Quy đổi";
            bandedGridView.Columns["ToAmount"].OwnerBand = _parentBand3;
            bandedGridView.Columns["ToAmount"].Visible = true;
            bandedGridView.Columns["ToAmount"].VisibleIndex = 14;
            bandedGridView.Columns["ToAmount"].OptionsColumn.AllowSort = DefaultBoolean.False;
            bandedGridView.Columns["ToAmount"].DisplayFormat.FormatType = FormatType.Numeric;
            bandedGridView.Columns["ToAmount"].DisplayFormat.FormatString = @"c" +
                                                                            GlobalVariable
                                                                                .CurrencyDecimalDigits;
            bandedGridView.Columns["ToAmount"].Width = 100;

            SetNumericFormatGridBand(bandedGridView, true);

            //}
            //else
            //{
            //    bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode)].Visible = false;
            //    bandedGridView.Columns["ExchangeRate"].Visible = false;
            //    bandedGridView.Columns["Amount"].Visible = false;
            //    bandedGridView.Columns[nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode)].Visible = false;
            //    bandedGridView.Columns["ToExchangeRate"].Visible = false;
            //    bandedGridView.Columns["ToAmount"].Visible = false;
            //    bandedGridView.Columns["ToBudgetSubKindItemCode"].Visible = false;

            //}

        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookupProject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lookupProject_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookupProject.EditValue == null) return;
            //var projectName = (string)lookupProject.GetColumnValue("ProjectName");

            //txtProjectName.Text = projectName;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookupVendor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void lookupVendor_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookupVendor.EditValue == null) return;
            //var projectName = (string)lookupVendor.GetColumnValue("AccountingObjectName");

            //txtVendorName.Text = projectName;
        }
        public IList<BankModel> AccountingObjectBanks
        {
            get { return new List<BankModel>(); }
            set
            {
                if (value == null)
                    value = new List<BankModel>();

                cbObjectBank.Properties.DataSource = value;
                cbObjectBank.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInLookUpEdit(gridColumnsCollection, cbObjectBank);

                cbObjectBank.Properties.DisplayMember = "BankAccount";
                cbObjectBank.Properties.ValueMember = "BankAccount";

            }
        }
        /// <summary>
        /// Handles the Click event of the btnChooseBUCommitment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnChooseBUCommitment_Click(object sender, EventArgs e)
        {
            using (var frmParam = new FrmChooseBUCommitment())
            {
                if (frmParam.ShowDialog() == DialogResult.OK)
                {
                    var listRefDetailId = frmParam.RefDetailIds;
                    var masterId = frmParam.RefMasterId;
                    if (masterId == null)
                        return;
                    IModel model = new Model.Model();
                    var bUCommitmentAdjustment = model.GetBUCommitmentAdjustment().Where(o => o.BUCommitmentRequestId == masterId).OrderByDescending(o => o.RefDate).FirstOrDefault();
                    if (bUCommitmentAdjustment != null)
                    {
                        var bUCommitment = model.GetBUCommitmentRequestVoucher(masterId, true);
                        var buCommitmentAdjustmentDetail = model.GetBUCommitmentAdjustmentVoucher(bUCommitmentAdjustment.RefId, true).BUCommitmentAdjustmentDetails;
                        AccountingObjectId = bUCommitment.AccountingObjectId;
                        
                        CurrencyCode = bUCommitmentAdjustment.CurrencyCode;
                        ExchangeRate = bUCommitmentAdjustment.ExchangeRate;
                        if (bUCommitment != null && buCommitmentAdjustmentDetail != null)
                        {
                            btnChooseBUCommitment.Text = bUCommitment.RefNo;
                            BUCommitmentRequestId = masterId;

                            ContractFrameNo = bUCommitment.ContractFrameNo;
                            this.LookUpEditContract.EditValue = bUCommitment.ContractNo;

                            if (buCommitmentAdjustmentDetail != null && !string.IsNullOrEmpty(buCommitmentAdjustmentDetail.FirstOrDefault().CurrencyCode))
                            {
                                gridViewMaster.SetRowCellValue(0, "CurrencyCode", bUCommitmentAdjustment.CurrencyCode);
                                gridViewMaster.SetRowCellValue(0, "ExchangeRate", bUCommitmentAdjustment.ExchangeRate);
                                TotalAmountOC = bUCommitmentAdjustment.TotalAmountOC;
                                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", TotalAmountOC);
                                TotalAmount = bUCommitmentAdjustment.TotalAmount;
                                gridViewMaster.SetRowCellValue(0, "TotalAmount", TotalAmount);
                            }
                            else
                            {
                                gridViewMaster.SetRowCellValue(0, "CurrencyCode", GlobalVariable.MainCurrencyId);
                            }
                            if (bUCommitment.AccountingObjectId != null)
                            {
                                var vendor = model.GetAccountingObject(bUCommitment.AccountingObjectId);
                                var objectBanks = model.GetProjectBank(vendor.AccountingObjectId);
                                this.AccountingObjectBanks = objectBanks;
                                if (objectBanks != null && objectBanks.Count() > 0)
                                {
                                    var bankAc = objectBanks.FirstOrDefault(o => o.BankAccount == bUCommitmentAdjustment.BankAccount);
                                    if (bankAc != null)
                                    {
                                        this.cbObjectBank.EditValue = bankAc.BankAccount;
                                        txtBankName.Text = bankAc.BankName;
                                    }
                                    
                                }
                            }
                        }

                        IList<BUCommitmentAdjustmentDetailModel> listBUCommitmentAdjustmentDetail = new List<BUCommitmentAdjustmentDetailModel>();
                        //var detailId = listRefDetailId.Split(',');
                        //foreach (var item in buCommitmentAdjustmentDetail)
                        //{
                        //if (item != "")
                        //{
                        //var bUCommitmentDetail = bUCommitment.BUCommitmentRequestDetails.Where(x => x.RefDetailId == item).ToList();

                        // Map số liệu từ Đề nghị cam kết chi vào điều chỉnh cam kết chi
                        foreach (var detail in buCommitmentAdjustmentDetail)
                        {
                            BUCommitmentAdjustmentDetailModel bUCommitmentAdjustmentDetailModel = new BUCommitmentAdjustmentDetailModel();

                            bUCommitmentAdjustmentDetailModel.Description = detail.Description;
                            bUCommitmentAdjustmentDetailModel.CurrencyCode = detail.RemainCurrencyCode;
                            bUCommitmentAdjustmentDetailModel.ExchangeRate = detail.RemainExchangeRate;
                            bUCommitmentAdjustmentDetailModel.Amount = detail.RemainAmount;
                            bUCommitmentAdjustmentDetailModel.AmountOC = detail.RemainAmountOC;
                            bUCommitmentAdjustmentDetailModel.BudgetSourceId = detail.ToBudgetSourceId;
                            bUCommitmentAdjustmentDetailModel.BudgetChapterCode = detail.BudgetChapterCode;
                            bUCommitmentAdjustmentDetailModel.BudgetKindItemCode = detail.BudgetKindItemCode;
                            bUCommitmentAdjustmentDetailModel.BudgetSubKindItemCode = detail.BudgetSubKindItemCode;
                            bUCommitmentAdjustmentDetailModel.BudgetItemCode = detail.BudgetItemCode;
                            bUCommitmentAdjustmentDetailModel.BudgetSubItemCode = detail.BudgetSubItemCode;
                            bUCommitmentAdjustmentDetailModel.BudgetDetailItemCode = detail.BudgetDetailItemCode;
                            bUCommitmentAdjustmentDetailModel.MethodDistributeId = detail.MethodDistributeId;
                            bUCommitmentAdjustmentDetailModel.CashWithDrawTypeId = detail.CashWithDrawTypeId;
                            bUCommitmentAdjustmentDetailModel.ActivityId = detail.ActivityId;
                            bUCommitmentAdjustmentDetailModel.ProjectId = detail.ProjectId;
                            bUCommitmentAdjustmentDetailModel.ProjectActivityId = detail.ProjectActivityId;
                            bUCommitmentAdjustmentDetailModel.ProjectExpenseId = detail.ProjectExpenseId;
                            bUCommitmentAdjustmentDetailModel.TaskId = detail.TaskId;
                            bUCommitmentAdjustmentDetailModel.ListItemId = detail.ListItemId;
                            bUCommitmentAdjustmentDetailModel.Approved = detail.Approved;
                            bUCommitmentAdjustmentDetailModel.FundStructureId = detail.FundStructureId;
                            bUCommitmentAdjustmentDetailModel.SortOrder = detail.SortOrder;
                            bUCommitmentAdjustmentDetailModel.BankAccount = detail.BankAccount;
                            bUCommitmentAdjustmentDetailModel.BudgetProvideCode = detail.BudgetProvideCode;
                            bUCommitmentAdjustmentDetailModel.ToCurrencyCode = detail.CurrencyCode;
                            bUCommitmentAdjustmentDetailModel.ToExchangeRate = detail.ExchangeRate;
                            bUCommitmentAdjustmentDetailModel.ToAmountOC = 0;
                            bUCommitmentAdjustmentDetailModel.ToAmount = 0;
                            bUCommitmentAdjustmentDetailModel.ToBudgetSourceId = detail.BudgetSourceId;
                            bUCommitmentAdjustmentDetailModel.ToBudgetProvideCode = detail.BudgetProvideCode;
                            bUCommitmentAdjustmentDetailModel.ToBudgetChapterCode = detail.BudgetChapterCode;
                            bUCommitmentAdjustmentDetailModel.ToBudgetKindItemCode = detail.BudgetKindItemCode;
                            bUCommitmentAdjustmentDetailModel.ToBudgetSubKindItemCode = detail.BudgetSubKindItemCode;
                            bUCommitmentAdjustmentDetailModel.ToBudgetItemCode = detail.BudgetItemCode;
                            bUCommitmentAdjustmentDetailModel.ToBudgetSubItemCode = detail.BudgetSubItemCode;
                            bUCommitmentAdjustmentDetailModel.ToProjectId = detail.ProjectId;
                            bUCommitmentAdjustmentDetailModel.RemainAmountOC = detail.RemainAmountOC;
                            bUCommitmentAdjustmentDetailModel.RemainAmount = detail.RemainAmount;
                            bUCommitmentAdjustmentDetailModel.RemainExchangeRate = 0;
                            bUCommitmentAdjustmentDetailModel.RemainCurrencyCode = detail.CurrencyCode;

                            listBUCommitmentAdjustmentDetail.Add(bUCommitmentAdjustmentDetailModel);
                        }
                        //}

                        //}
                        // Load data GridViewDetail


                        bindingSourceDetail.DataSource = listBUCommitmentAdjustmentDetail ?? new List<BUCommitmentAdjustmentDetailModel>();
                        grdAccounting.MainView = bandedGridView;
                        grdAccounting.ForceInitialize();
                        bandedGridView.PopulateColumns(listBUCommitmentAdjustmentDetail);
                        /*  if (bUCommitment != null && bUCommitment.BUCommitmentRequestDetails.FirstOrDefault().CurrencyCode.ToUpper() != "VND")
                          {
                              AddBandGridView();
                              ColumnsCollection.Clear();
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Quy đổi", ColumnPosition = 18, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Quy đổi" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnVisible = false, ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToExchangeRate), ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Quy đổi", ColumnPosition = 20, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Quy đổi" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 19, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnCaption = "Số tiền CKC sau điều chỉnh quy đổi", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.BUCommitmentRequestDetailId), ColumnVisible = false });
                              foreach (var column in ColumnsCollection)
                              {
                                  if (bandedGridView.Columns[column.ColumnName] != null)
                                  {
                                      if (column.ColumnVisible)
                                      {
                                          bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                          bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                          bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                                          bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                                          bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                                          bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                                          bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                                          bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                                          bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                          if (column.IsSummaryText)
                                          {
                                              bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                              bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                                          }
                                      }
                                      else
                                          bandedGridView.Columns[column.ColumnName].Visible = false;
                                  }

                              }
                          }
                          else
                          {*/
                        ColumnsCollection.Clear();
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Số tiền CKC điều chỉnh quy đổi", ColumnPosition = 19, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh quy đổi", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });

                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh quy đổi", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.BUCommitmentRequestDetailId), ColumnVisible = false });
                        foreach (var column in ColumnsCollection)
                        {
                            if (bandedGridView.Columns[column.ColumnName] != null)
                            {
                                if (column.ColumnVisible)
                                {
                                    bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                    bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                    bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                                    bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                                    bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                                    bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                                    bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                                    bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                                    bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                    if (column.IsSummaryText)
                                    {
                                        bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                        bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                                    }
                                }
                                else
                                    bandedGridView.Columns[column.ColumnName].Visible = false;
                            }

                        }
                        //  }
                        LoadBandGridView();
                        if (this.CurrencyCode == "VND")
                        {
                            bandedGridView.Columns.ColumnByFieldName("Amount").Visible = false;
                            bandedGridView.Columns.ColumnByFieldName("RemainAmount").Visible = false;
                            bandedGridView.Columns.ColumnByFieldName("ToAmount").Visible = false;
                        }

                    }
                    else
                    {
                        var bUCommitment = model.GetBUCommitmentRequestVoucher(masterId, true);
                        if (bUCommitment != null)
                        {
                            btnChooseBUCommitment.Text = bUCommitment.RefNo;
                            BUCommitmentRequestId = masterId;
                            ContractFrameNo = bUCommitment.ContractFrameNo;
                            this.LookUpEditContract.EditValue = bUCommitment.ContractNo;
                            this.AccountingObjectId = bUCommitment.AccountingObjectId;
                            if (bUCommitment.BUCommitmentRequestDetails != null && !string.IsNullOrEmpty(bUCommitment.BUCommitmentRequestDetails.FirstOrDefault().CurrencyCode))
                            {
                                gridViewMaster.SetRowCellValue(0, "CurrencyCode", bUCommitment.BUCommitmentRequestDetails.FirstOrDefault().CurrencyCode);
                                gridViewMaster.SetRowCellValue(0, "ExchangeRate", bUCommitment.BUCommitmentRequestDetails.FirstOrDefault().ExchangeRate);
                                decimal totalAmountOC = 0;
                                decimal totalAmount = 0;
                                foreach (var item in (List<BUCommitmentRequestDetailModel>)bUCommitment.BUCommitmentRequestDetails)
                                {
                                    totalAmountOC += item.AmountOC;
                                    totalAmount += item.Amount;
                                }
                                gridViewMaster.SetRowCellValue(0, "TotalAmountOC", totalAmountOC);
                                gridViewMaster.SetRowCellValue(0, "TotalAmount", totalAmount);
                            }
                            else
                            {
                                gridViewMaster.SetRowCellValue(0, "CurrencyCode", GlobalVariable.MainCurrencyId);
                            }
                            if (bUCommitment.AccountingObjectId != null)
                            {
                                var vendor = model.GetAccountingObject(bUCommitment.AccountingObjectId);
                                var objectBanks = model.GetProjectBank(vendor.AccountingObjectId);
                                this.AccountingObjectBanks = objectBanks;
                                if (objectBanks != null && objectBanks.Count() > 0)
                                {
                                    if (!string.IsNullOrEmpty(bUCommitment.BankAccount))
                                    {
                                        var bankAc = objectBanks.FirstOrDefault(o => o.BankId == bUCommitment.BankAccount);
                                        if (bankAc != null)
                                        {
                                            this.cbObjectBank.EditValue = bankAc.BankAccount;
                                            txtBankName.Text = bankAc.BankName;
                                        }    
                                    }    
                                    
                                }
                            }
                        }

                        IList<BUCommitmentAdjustmentDetailModel> listBUCommitmentAdjustmentDetail = new List<BUCommitmentAdjustmentDetailModel>();
                        var detailId = listRefDetailId.Split(',');
                        foreach (var item in detailId)
                        {
                            if (item != "")
                            {
                                var bUCommitmentDetail = bUCommitment.BUCommitmentRequestDetails.Where(x => x.RefDetailId == item).ToList();

                                // Map số liệu từ Đề nghị cam kết chi vào điều chỉnh cam kết chi
                                foreach (var detail in bUCommitmentDetail)
                                {
                                    BUCommitmentAdjustmentDetailModel bUCommitmentAdjustmentDetailModel = new BUCommitmentAdjustmentDetailModel();

                                    bUCommitmentAdjustmentDetailModel.Description = detail.Description;
                                    bUCommitmentAdjustmentDetailModel.CurrencyCode = detail.CurrencyCode;
                                    bUCommitmentAdjustmentDetailModel.ExchangeRate = detail.ExchangeRate;
                                    bUCommitmentAdjustmentDetailModel.Amount = detail.Amount;
                                    bUCommitmentAdjustmentDetailModel.AmountOC = detail.AmountOC;
                                    bUCommitmentAdjustmentDetailModel.BudgetSourceId = detail.BudgetSourceId;
                                    bUCommitmentAdjustmentDetailModel.BudgetChapterCode = detail.BudgetChapterCode;
                                    bUCommitmentAdjustmentDetailModel.BudgetKindItemCode = detail.BudgetKindItemCode;
                                    bUCommitmentAdjustmentDetailModel.BudgetSubKindItemCode = detail.BudgetSubKindItemCode;
                                    bUCommitmentAdjustmentDetailModel.BudgetItemCode = detail.BudgetItemCode;
                                    bUCommitmentAdjustmentDetailModel.BudgetSubItemCode = detail.BudgetSubItemCode;
                                    bUCommitmentAdjustmentDetailModel.BudgetDetailItemCode = detail.BudgetDetailItemCode;
                                    bUCommitmentAdjustmentDetailModel.MethodDistributeId = detail.MethodDistributeId;
                                    bUCommitmentAdjustmentDetailModel.CashWithDrawTypeId = detail.CashWithDrawTypeId;
                                    bUCommitmentAdjustmentDetailModel.ActivityId = detail.ActivityId;
                                    bUCommitmentAdjustmentDetailModel.ProjectId = detail.ProjectId;
                                    bUCommitmentAdjustmentDetailModel.ProjectActivityId = detail.ProjectActivityId;
                                    bUCommitmentAdjustmentDetailModel.ProjectExpenseId = detail.ProjectExpenseId;
                                    bUCommitmentAdjustmentDetailModel.TaskId = detail.TaskId;
                                    bUCommitmentAdjustmentDetailModel.ListItemId = detail.ListItemId;
                                    bUCommitmentAdjustmentDetailModel.Approved = detail.Approved;
                                    bUCommitmentAdjustmentDetailModel.FundStructureId = detail.FundStructureId;
                                    bUCommitmentAdjustmentDetailModel.SortOrder = detail.SortOrder;
                                    bUCommitmentAdjustmentDetailModel.BankAccount = detail.BankAccount;
                                    bUCommitmentAdjustmentDetailModel.BudgetProvideCode = detail.BudgetProvideCode;
                                    bUCommitmentAdjustmentDetailModel.ToCurrencyCode = detail.CurrencyCode;
                                    bUCommitmentAdjustmentDetailModel.ToExchangeRate = detail.ExchangeRate;
                                    bUCommitmentAdjustmentDetailModel.ToAmountOC = 0;
                                    bUCommitmentAdjustmentDetailModel.ToAmount = 0;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetSourceId = detail.BudgetSourceId;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetProvideCode = detail.BudgetProvideCode;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetChapterCode = detail.BudgetChapterCode;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetKindItemCode = detail.BudgetKindItemCode;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetSubKindItemCode = detail.BudgetSubKindItemCode;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetItemCode = detail.BudgetItemCode;
                                    bUCommitmentAdjustmentDetailModel.ToBudgetSubItemCode = detail.BudgetSubItemCode;
                                    bUCommitmentAdjustmentDetailModel.ToProjectId = detail.ProjectId;
                                    bUCommitmentAdjustmentDetailModel.RemainAmountOC = detail.AmountOC;
                                    bUCommitmentAdjustmentDetailModel.RemainAmount = detail.Amount;
                                    bUCommitmentAdjustmentDetailModel.RemainExchangeRate = 0;
                                    bUCommitmentAdjustmentDetailModel.RemainCurrencyCode = detail.CurrencyCode;

                                    listBUCommitmentAdjustmentDetail.Add(bUCommitmentAdjustmentDetailModel);
                                }
                            }

                        }
                        // Load data GridViewDetail


                        bindingSourceDetail.DataSource = listBUCommitmentAdjustmentDetail ?? new List<BUCommitmentAdjustmentDetailModel>();
                        grdAccounting.MainView = bandedGridView;
                        grdAccounting.ForceInitialize();
                        bandedGridView.PopulateColumns(listBUCommitmentAdjustmentDetail);
                        /*  if (bUCommitment != null && bUCommitment.BUCommitmentRequestDetails.FirstOrDefault().CurrencyCode.ToUpper() != "VND")
                          {
                              AddBandGridView();
                              ColumnsCollection.Clear();
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Quy đổi", ColumnPosition = 18, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Quy đổi" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnVisible = false, ColumnCaption = "Loại tiền", ColumnPosition = 15, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Loại tiền", RepositoryControl = _gridLookUpEditCurrency });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToExchangeRate), ColumnCaption = "Tỷ giá", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tỷ giá", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Quy đổi", ColumnPosition = 20, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Quy đổi" });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 19, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                              ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnCaption = "Số tiền CKC sau điều chỉnh quy đổi", ColumnPosition = 17, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 120, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });
                              ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.BUCommitmentRequestDetailId), ColumnVisible = false });
                              foreach (var column in ColumnsCollection)
                              {
                                  if (bandedGridView.Columns[column.ColumnName] != null)
                                  {
                                      if (column.ColumnVisible)
                                      {
                                          bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                          bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                          bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                                          bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                                          bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                                          bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                                          bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                                          bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                                          bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                          if (column.IsSummaryText)
                                          {
                                              bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                              bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                                          }
                                      }
                                      else
                                          bandedGridView.Columns[column.ColumnName].Visible = false;
                                  }

                              }
                          }
                          else
                          {*/
                        ColumnsCollection.Clear();
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 180, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Diễn giải" });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.CurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "TaskId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnCaption = "Khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản chi", RepositoryControl = _gridLookUpEditFundStructure });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.ToCurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmountOC", ColumnCaption = "Số tiền CKC điều chỉnh", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAmount", ColumnCaption = "Số tiền CKC điều chỉnh quy đổi", ColumnPosition = 19, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC điều chỉnh quy đổi", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSourceId", ColumnCaption = "Nguồn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Nguồn", RepositoryControl = _gridLookUpEditBudgetSource });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetProvideCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Chương", RepositoryControl = _gridLookUpEditBudgetChapter });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubKindItemCode", ColumnCaption = "Khoản", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Khoản", RepositoryControl = _gridLookUpEditBudgetSubKindItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetKindItemCode", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetSubItemCode", ColumnCaption = "Tiểu mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Tiểu mục", RepositoryControl = _gridLookUpEditBudgetSubItem });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToBudgetItemCode", ColumnCaption = "Mục", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Mục", RepositoryControl = _gridLookUpEditBudgetItem });

                        ColumnsCollection.Add(new XtraColumn { ColumnName = "ToProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Dự án", RepositoryControl = _gridLookUpEditProject });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmountOC", ColumnCaption = "Số tiền CKC sau điều chỉnh", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainAmount", ColumnCaption = "Số tiền CKC sau điều chỉnh quy đổi", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Số tiền CKC sau điều chỉnh", ColumnType = UnboundColumnType.Decimal });

                        ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainExchangeRate", ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.RemainCurrencyCode), ColumnVisible = false });
                        ColumnsCollection.Add(new XtraColumn { ColumnName = nameof(BUCommitmentAdjustmentDetailModel.BUCommitmentRequestDetailId), ColumnVisible = false });
                        foreach (var column in ColumnsCollection)
                        {
                            if (bandedGridView.Columns[column.ColumnName] != null)
                            {
                                if (column.ColumnVisible)
                                {
                                    bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                    bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                                    bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                                    bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                                    bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                                    bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                                    bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                                    bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                                    bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                                    if (column.IsSummaryText)
                                    {
                                        bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                        bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                                    }
                                }
                                else
                                    bandedGridView.Columns[column.ColumnName].Visible = false;
                            }

                        }
                        //  }
                        LoadBandGridView();
                        if (this.CurrencyCode == "VND")
                        {
                            bandedGridView.Columns.ColumnByFieldName("Amount").Visible = false;
                            bandedGridView.Columns.ColumnByFieldName("RemainAmount").Visible = false;
                            bandedGridView.Columns.ColumnByFieldName("ToAmount").Visible = false;
                        }
                    }

                }
                //this.CurrencyCode = this.CurrencyCode;
                //this.ExchangeRate = this.ExchangeRate;
            }
        }

        private void FrmBUCommitmentAdjustmentDetail_Load(object sender, EventArgs e)
        {
            //if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            //{
            //    checkIncurredCurrency.Enabled = true;
            //    btnChooseBUCommitment.Enabled = true;
            //    txtAccount.Enabled = true;
            //    txtBankName.Enabled = true;
            //}
            //else
            //{
            //    checkIncurredCurrency.Enabled = false;
            //    btnChooseBUCommitment.Enabled = false;
            //    txtAccount.Enabled = false;
            //    txtBankName.Enabled = false;
            //}

            //txtAccount.Enabled = false;
            txtBankName.Enabled = false;

            bandedGridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            bandedGridView.PopupMenuShowing += BandedGridView_PopupMenuShowing;
        }

        #region Popup Menu



        /// <summary>
        /// Show menu when right click in grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BandedGridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid)
                return;
            var view = sender as BandedGridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupGridDetailMenu.ShowPopup(grdAccounting.PointToScreen(e.Point));
                }
            }
        }

        protected override void DeleteRowItemInBandedGridView()
        {
            if (tabMain.SelectedTabPage.Equals(tabAccounting))
            {
                bandedGridView.DeleteSelectedRows();
                CalculateGridMasterAfterDeletedRow(bandedGridView);
            }
        }

        protected override void AddNewRowItemInBandedGridView()
        {
            if (ActionMode != ActionModeVoucherEnum.None)
            {
                //AnhNT: duplicate dc dòng nhưng chưa double dc dữ liệu, tạm thời để đó
                IsCopyRow = true;
                string selectedCellsText = GetSelectedValues(bandedGridView);
                Clipboard.SetDataObject(selectedCellsText);

                if (!string.IsNullOrEmpty(selectedCellsText))
                {
                    bandedGridView.AddNewRow();
                }
                IsCopyRow = false;
                bandedGridView.CloseEditor();
                bandedGridView.UpdateCurrentRow();
            }
        }
        private string GetSelectedValues(GridView view)
        {
            if (view.SelectedRowsCount == 0)
                return "";

            const string cellDelimiter = "\t";
            const string lineDelimiter = "\r\n";
            string result = "";

            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {
                int row = view.GetSelectedRows()[i];

                // TUDT comment để có thể copy được dữ liệu cho tab Thống kê - Ngày 18/12/2017
                //for (int j = 0; j < view.VisibleColumns.Count; j++) 
                //{
                //    result += view.GetRowCellValue(row, view.VisibleColumns[j]);
                //    if (j != view.VisibleColumns.Count - 1)
                //        result += cellDelimiter;
                //}
                //if (i != 0)
                //    result += lineDelimiter;
                for (int j = 0; j < view.Columns.Count; j++)
                {
                    result += view.GetRowCellValue(row, view.Columns[j]);
                    if (j != view.Columns.Count - 1)
                        result += cellDelimiter;
                }
                if (i != 0)
                    result += lineDelimiter;
            }
            return result;
        }

        #endregion
    }
}
