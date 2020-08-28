using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using Buca.Application.iBigTime2020.Model;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetGroupItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// FrmBUPlanReceiptDetail
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail.FrmXtraBaseVoucherDetail" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUPlanReceiptView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetItemsView" />
    public partial class FrmBUPlanReceiptDetail : FrmXtraBaseVoucherDetail, IBUPlanReceiptView, IAccountsView, IBudgetSourcesView, IBudgetKindItemsView, IFundStructuresView, IBanksView, IProjectsView, IBudgetChaptersView, IBudgetItemsView, IBudgetGroupItemsView, IContractsView, ICapitalPlansView, IActivitysView
    {
        #region IBUPlanReceiptView
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
        public int RefType
        {
            get { return (int)rgRefTypeId.EditValue; }
            set { rgRefTypeId.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the reference date.txt
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
            get { return gridViewMaster.GetRowCellValue(0, "CurrencyCode") == null ? GlobalVariable.MainCurrencyId : gridViewMaster.GetRowCellValue(0, "CurrencyCode").ToString(); }
            set { gridViewMaster.SetRowCellValue(0, "CurrencyCode", value ?? GlobalVariable.MainCurrencyId); }
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
        /// Gets or sets the decision date.
        /// </summary>
        /// <value>
        /// The decision date.
        /// </value>
        public DateTime? DecisionDate
        {
            get { return dtDecisionDate.EditValue == null || string.IsNullOrEmpty(dtDecisionDate.EditValue.ToString()) ? (DateTime?)null : (DateTime)dtDecisionDate.EditValue; }
            set { dtDecisionDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the decision no.
        /// </summary>
        /// <value>
        /// The decision no.
        /// </value>
        public string DecisionNo
        {
            get { return txtDecisionNo.Text; }
            set { txtDecisionNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [posted].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [posted]; otherwise, <c>false</c>.
        /// </value>
        public bool Posted { get; set; }

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
        /// Gets or sets the allocation configuration.
        /// </summary>
        /// <value>
        /// The allocation configuration.
        /// </value>
        public int AllocationConfig { get; set; }

        /// <summary>
        /// Gets or sets the bu plan receipt detail models.
        /// </summary>
        /// <value>
        /// The bu plan receipt detail models.
        /// </value>
        public IList<BUPlanReceiptDetailModel> BuPlanReceiptDetailModels
        {
            get
            {
                var buPlanReceiptDetails = new List<BUPlanReceiptDetailModel>();
                if (grdAccountingView.DataSource != null && grdAccountingView.RowCount > 0)
                {
                    for (var i = 0; i < grdAccountingView.RowCount; i++)
                    {
                        var rowVoucher = (BUPlanReceiptDetailModel)grdAccountingView.GetRow(i);

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

                            var item = new BUPlanReceiptDetailModel
                            {
                                Description = rowVoucher.Description,
                                Amount = rowVoucher.Amount,
                                AmountOC = rowVoucher.AmountOC,
                                DebitAccount = rowVoucher.DebitAccount,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetSourceId = rowVoucher.BudgetSourceId,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetKindItemCode = budgetKindItemCode,
                                BudgetGroupItemCode = rowVoucher.BudgetGroupItemCode,
                                BudgetParentItemCode = rowVoucher.BudgetParentItemCode,
                                BudgetItemCode = rowVoucher.BudgetItemCode,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                FundStructureId = rowVoucher.FundStructureId,
                                BankId = rowVoucher.BankId,
                                ProjectId = rowVoucher.ProjectId,
                                MethodDistributeId = rowVoucher.MethodDistributeId,
                                BudgetDetailItemCode = rowVoucher.BudgetDetailItemCode,
                                BudgetProvideCode = rowVoucher.BudgetProvideCode,
                                SortOrder = i,
                                ListItemId = rowVoucher.ListItemId,
                                ProjectActivityEAId = rowVoucher.ProjectActivityEAId,
                                ContractId = rowVoucher.ContractId,
                                CapitalPlanId = rowVoucher.CapitalPlanId,
                                ActivityId = rowVoucher.ActivityId
                            };
                            buPlanReceiptDetails.Add(item);
                        }
                    }
                }
                return buPlanReceiptDetails;
            }
            set
            {
                bindingSourceDetail.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUPlanReceiptDetailModel>();
                grdAccountingView.PopulateColumns(value);

                #region columns for grdAccountingView
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                     new XtraColumn
                    {
                        ColumnName = "DebitAccount",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 1,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditDebitAccount,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 400,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 2,
                        AllowEdit = true
                    },

                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnCaption = "Số tiền quy đổi",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditProject,
                        ColumnWith = 150,
                        ColumnCaption = "Dự án",
                        ColumnPosition = 5,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSource,
                        ColumnWith = 150,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 6,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditCapitalPlan,
                        ColumnWith = 150,
                        ColumnCaption = "Kế hoạch vốn",
                        ColumnPosition = 7,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                     new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditBudgetChapter,
                        ColumnWith = 150,
                        ColumnCaption = "Chương",
                        ColumnPosition = 8,
                        AllowEdit = true
                    },
                    new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = true,
                        RepositoryControl = _gridLookUpEditBudgetSubKindItem,
                        ColumnWith = 150,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 9,
                        AllowEdit = true},
                    new XtraColumn
                    {
                        ColumnName = "BudgetGroupItemCode",
                        ColumnVisible = false
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetParentItemCode",
                        ColumnVisible = false,
                        ColumnWith = 150,
                        ColumnCaption = "Nhóm mục",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                     new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
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
                        ColumnPosition =11,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetItem
                    },
                    new XtraColumn {ColumnName = "FundStructureId", ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditFundStructure,
                        ColumnWith = 200,
                        ColumnCaption = "Khoản chi",
                        ColumnPosition = 8,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditBank,
                        ColumnWith = 200,
                        ColumnCaption = "Tài khoản NH, KB",
                        ColumnPosition = 9,
                        AllowEdit = true},
                    new XtraColumn {ColumnName = "ContractId", ColumnVisible = false,
                        RepositoryControl = _gridLookUpEditContract,
                        ColumnWith = 150,
                        ColumnCaption = "Hợp đồng"},

                    new XtraColumn{ColumnName = "MethodDistributeId", ColumnVisible = false,
                        ColumnWith = 150,
                        ColumnCaption = "Cấp phát",
                        ColumnPosition = 12,
                        AllowEdit = true,
                        IsLastColumn = true,
                        RepositoryControl = _repositoryMethodDistributeId},
                      new XtraColumn{ColumnName = "ActivityId", ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Công việc",
                        ColumnPosition = 13,
                        AllowEdit = true,
                        IsLastColumn = true,
                        RepositoryControl = _gridLookUpEditActivity},
                   // new XtraColumn {ColumnName = "Amount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater1OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater2OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater3OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountQuater4OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth1OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth2OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth3OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth4OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth5OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth6", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth6OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth7", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth7OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth8", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth8OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth9", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth9OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth10", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth10OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth11", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth11OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth12", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountMonth12OC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailBy", ColumnVisible = false}
            };
                grdAccountingView = InitGridLayout(columnsCollection, grdAccountingView);
                SetNumericFormatControl(grdAccountingView, true);
                //grdAccountingView.OptionsView.ShowFooter = false;
                grdAccountingView.ViewCaption = "";

                #endregion
            }
        }
        #endregion

        #region Presenter

        private readonly ContractsPresenter _contractsPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly CapitalPlansPresenter _capitalPlansPresenter;
        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly BUPlanReceiptPresenter _buPlanReceiptPresenter;

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

        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// The budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The budget group items presenter
        /// </summary>
        private readonly BudgetGroupItemsPresenter _budgetGroupItemsPresenter;

        #endregion

        #region RepositoryItemGridLookUpEdit && Variable

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDebitAccount;
        private GridView _gridLookUpEditDebitAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;
        private GridView _gridLookUpEditBudgetSubKindItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubItem;
        private GridView _gridLookUpEditBudgetSubItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetGroupItem;
        private GridView _gridLookUpEditBudgetGroupItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private List<BudgetKindItemModel> _budgetSubKindItemModels;
        private List<BudgetSourceModel> _budgetSourceModels;

        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;

        private IList<BudgetKindItemModel> _budgetKindItemModels;
        private List<BudgetItemModel> _budgetItemModels;

        private RepositoryItemGridLookUpEdit _gridLookUpEditContract;
        private GridView _gridLookUpEditContractView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCapitalPlan;
        private GridView _gridLookUpEditCapitalPlanView;
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



            var debitAccount = typeof(DebitAccountNumber).ToList();
            //_repositoryDebitAccount = new RepositoryItemLookUpEdit
            //{
            //    DataSource = debitAccount,
            //    AllowNullInput = DefaultBoolean.True,
            //    NullText = "0092",
            //    NullValuePrompt = null,
            //    DisplayMember = "Value",
            //    ValueMember = "Key",
            //    ShowHeader = false,

            //};
            //_repositoryDebitAccount.PopulateColumns();
            //_repositoryDebitAccount.Columns["Key"].Visible = false;
        }

        #endregion

        #region overrides
        public FrmBUPlanReceiptDetail()
        {
            InitializeComponent();
            _contractsPresenter = new ContractsPresenter(this);
            _capitalPlansPresenter = new CapitalPlansPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _buPlanReceiptPresenter = new BUPlanReceiptPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetGroupItemsPresenter = new BudgetGroupItemsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            dtDecisionDate.Focus();           

        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            tabMain.SelectedTabPage = tabInventoryItem;
            tabMain.ShowTabHeader = DefaultBoolean.False;
            grdMaster.Location = new Point(7, 185);
            tabMain.Location = new Point(7, 245);
           
        }
        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _budgetKindItemsPresenter.DisplayActive();
            _projectsPresenter.DisplayByObjectType("2");
            _fundStructuresPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetItemsPresenter.DisplayActive(true);
            _contractsPresenter.Display();
            _capitalPlansPresenter.Display();
            _budgetGroupItemsPresenter.Display();
            _activitysPresenter.Display();

            InitRepositoryControlData();
            if (ActionMode == ActionModeVoucherEnum.AddNew) KeyValue = ((BUPlanReceiptModel)MasterBindingSource.Current).RefId;
            else
            {
                if (MasterBindingSource != null) if (MasterBindingSource.Current != null && KeyValue == null) KeyValue = ((BUPlanReceiptModel)MasterBindingSource.Current).RefId;
            }


            _buPlanReceiptPresenter.Display(KeyValue ?? "");
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                RefType = (int)BaseRefTypeId;
            }
            if (RefId == null)
            {
                lookUpEditBudgetChapterCode.EditValue = GlobalVariable.DefaultBudgetChapterCode;
                DecisionDate = DateTime.Now;

                grdAccountingView.AddNewRow();
            }
            
            //grdAccountingView.AddNewRow();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var detailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");

            // Bỏ nhập ngày quyết định - quyennh 7/5/2018
            //if (dtDecisionDate.EditValue == null || dtDecisionDate.DateTime == DateTime.MinValue || DecisionDate == null || DecisionDate == DateTime.MinValue)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBUBudgetReserveDecisionDate"), detailContent,
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dtDecisionDate.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), detailContent,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            var faDepreciationDetails = BuPlanReceiptDetailModels;
            if (faDepreciationDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"), detailContent,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            foreach (var faDepreciationDetail in BuPlanReceiptDetailModels)
            {
                if (faDepreciationDetail.ProjectId == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn dự án",
                                                           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Error);
                    return false;
                }
                if (faDepreciationDetail.CapitalPlanId == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn kế hoạch vốn",
                                                           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                                           MessageBoxIcon.Error);
                    return false;
                }
                if (faDepreciationDetail.DebitAccount == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDebitValid"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    return false;
                }

                //if (BudgetChapterCode == null)
                //{
                //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCodenull"),
                //                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                       MessageBoxIcon.Error);
                //    return false;
                //}
                if (faDepreciationDetail.BudgetSourceId == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetailVoucherEmptyBudgetSourceId"),
                                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    return false;
                }

                //Khoan
                if (faDepreciationDetail.BudgetSubKindItemCode == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSubKindItemCodeNull"),
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
                view.SetRowCellValue(e.RowHandle, "DebitAccount", "0092");
                view.SetRowCellValue(e.RowHandle, "Amount", 0);
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
                InitDetailRow(e, view);
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
            return _buPlanReceiptPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            new BUPlanReceiptPresenter(null).Delete(KeyValue);

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
                    _budgetSourceModels = value.ToList();
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();

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
                    //var debitAccounts = value.Where(v => Convert.ToInt32(v.AccountNumber) == 92).ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
                    var debitAccounts = value.Where(v => v.AccountNumber.StartsWith("0")).ToList().DebitAccounts((int)BaseRefTypeId, RefTypes.ToList());
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
                    //XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);
                    //_gridLookUpEditDebitAccount.DisplayMember = "AccountNumber";
                    //_gridLookUpEditDebitAccount.ValueMember = "AccountNumber";

                    _gridLookUpEditDebitAccountView = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                    _gridLookUpEditDebitAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditDebitAccountView, debitAccounts, "AccountNumber", "AccountNumber", gridColumnsCollection);
                    XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditDebitAccountView);

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
                    _budgetKindItemModels = value.ToList();
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

                    _gridLookUpEditBudgetSubKindItemView = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSubKindItem = XtraColumnCollectionHelper<BudgetKindItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubKindItemView, _budgetSubKindItemModels, "BudgetKindItemCode", "BudgetKindItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetKindItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubKindItemView);


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
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //_gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                //_gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId");

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });
                _gridLookUpEditBankView = XtraColumnCollectionHelper<BankModel>.CreateGridViewReponsitory();
                _gridLookUpEditBank = XtraColumnCollectionHelper<BankModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBankView, value, "BankAccount", "BankId", gridColumnsCollection);
                XtraColumnCollectionHelper<BankModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBankView);
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

                    _gridLookUpEditProjectView = XtraColumnCollectionHelper<ProjectModel>.CreateGridViewReponsitory();
                    _gridLookUpEditProject = XtraColumnCollectionHelper<ProjectModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditProjectView, value, "ProjectCode", "ProjectId", gridColumnsCollection);
                    XtraColumnCollectionHelper<ProjectModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditProjectView);
                    //_gridLookUpEditProject.DisplayMember = "ProjectCode";
                    //_gridLookUpEditProject.ValueMember = "ProjectId";
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
                        ColumnCaption = "Mã cơ cấu vốn",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên cơ cấu vốn",
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
                    //        _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
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

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetChapterView = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetChapter = XtraColumnCollectionHelper<BudgetChapterModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetChapterView, value, "BudgetChapterCode", "BudgetChapterCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetChapterModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetChapterView);

                    lookUpEditBudgetChapterCode.Properties.DataSource = value;
                    lookUpEditBudgetChapterCode.Properties.PopulateColumns();

                    lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                    lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterCode";
                    
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region BudgetItem
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
                if (value == null)
                    return;
                _budgetItemModels = value.ToList();
                //var budgetItemModels = value.Where(v => v.BudgetItemType <= 1).ToList();
                //var budgetSubItemModels = value.Where(v => v.BudgetItemType == 2).ToList();
                var budgetItemModels = value.Where(v => v.BudgetItemType == 2 && Convert.ToInt32(v.BudgetItemCode) >= 9200 && Convert.ToInt32(v.BudgetItemCode) <= 9400).ToList();
                var budgetSubItemModels = value.Where(v => v.BudgetItemType == 3 && Convert.ToInt32(v.BudgetItemCode) >= 9201 && Convert.ToInt32(v.BudgetItemCode) <= 9449).ToList();
                // Tiểu mục


                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã tiểu mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên tiểu mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetSubItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetSubItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSubItemView, budgetSubItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSubItemView);

                // Mục

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã mục", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên mục", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditBudgetItemView = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridViewReponsitory();
                _gridLookUpEditBudgetItem = XtraColumnCollectionHelper<BudgetItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetItemView, budgetItemModels, "BudgetItemCode", "BudgetItemCode", gridColumnsCollection);
                XtraColumnCollectionHelper<BudgetItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetItemView);
            }
        }
        #endregion

        #region BudgetGroupItem
        public IList<BudgetGroupItemModel> BudgetGroupItems
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetGroupItemView = new GridView();
                    _gridLookUpEditBudgetGroupItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetGroupItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetGroupItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditBudgetGroupItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetGroupItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetGroupItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetGroupItem.View.BestFitColumns();
                    _gridLookUpEditBudgetGroupItem.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetGroupItem.KeyDown += _gridLookUpEditBudgetGroupItemView_KeyDown;

                    _gridLookUpEditBudgetGroupItem.DataSource = value;
                    _gridLookUpEditBudgetGroupItemView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetGroupItemCode",
                        ColumnCaption = "Mã nhóm mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetGroupItemName",
                        ColumnCaption = "Tên nhóm mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RepBudgetItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetGroupItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetGroupItem.DisplayMember = "BudgetGroupItemName";
                    _gridLookUpEditBudgetGroupItem.ValueMember = "BudgetGroupItemCode";

                    _gridLookUpEditBudgetGroupItemView = XtraColumnCollectionHelper<BudgetGroupItemModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetGroupItem = XtraColumnCollectionHelper<BudgetGroupItemModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetGroupItemView, value, "BudgetGroupItemName", "BudgetGroupItemCode", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetGroupItemModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetGroupItemView);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public IList<ActivityModel> Activitys {
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
            var budgetSourceCode = grdAccountingView.Columns["BudgetKindItemId"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        private void _gridLookUpEditBudgetGroupItemView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetGroupItem = grdAccountingView.Columns["BudgetGroupItemCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetGroupItem, null);
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
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)
                return;
            var budgetSourceCode = grdAccountingView.Columns["BudgetChapterCode"];
            grdAccountingView.SetRowCellValue(grdAccountingView.FocusedRowHandle, budgetSourceCode, null);
            e.Handled = true;
        }

        /// <summary>
        /// Handles the CellValueChanged event of the grdAccountingView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs" /> instance containing the event data.</param>
        private void grdAccountingView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (DesignMode) return;
            try
            {

                if (e.Column.FieldName == "Description" && e.Value != null)
                {
                    if (grdAccountingView.RowCount > 0)
                    {
                        txtDescription.Text = e.Value.ToString();
                        //for (int i = 0; i < grdAccountingView.RowCount; i++)
                        //{
                        //    var description = grdAccountingView.GetRowCellValue(i, "Description");
                        //    if (description != null)
                        //        txtDescription.Text = string.IsNullOrEmpty(txtDescription.Text)
                        //            ? description.ToString()
                        //            : txtDescription.Text + ", " + description;
                        //}
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
        /// Handles the SelectedIndexChanged event of the rgRefTypeId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rgRefTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefType = (int)rgRefTypeId.EditValue == 51 ? (int)BuCA.Enum.RefType.BUPlanReceiptEarlyYear : (int)BuCA.Enum.RefType.BUPlanReceiptAddition;
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected override void SetEnableGroupBox(bool isEnable)
        {
            base.SetEnableGroupBox(isEnable);
            rgRefTypeId.Enabled = isEnable;
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditBudgetChapterCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookUpEditBudgetChapterCode_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditBudgetChapterCode.EditValue == null)
                return;
            var chaperName = (string)lookUpEditBudgetChapterCode.GetColumnValue("BudgetChapterCode");
            txtBudgetChapterName.Text = chaperName;
        }

        /// <summary>
        /// Button add budget chapter
        /// </summary>
        private void lookUpEditBudgetChapterCode_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmBudgetChapter = new FrmBudgetChapterDetail();
                frmBudgetChapter.ShowDialog();
                if (frmBudgetChapter.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.BudgetChapterIDAccountingObjectDetailForm))
                    {
                        _budgetChaptersPresenter.DisplayByIsActive(true);
                        lookUpEditBudgetChapterCode.Properties.DisplayMember = "BudgetChapterCode";
                        lookUpEditBudgetChapterCode.Properties.ValueMember = "BudgetChapterCode";
                        lookUpEditBudgetChapterCode.EditValue =
                            GlobalVariable.BudgetChapterIDAccountingObjectDetailForm;
                    }
                }
            }
        }


        protected override void GridAccountingCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            IModel model = new Model.Model();
            
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
        #endregion

        private void dtPostDate_TextChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        protected override void HiddenParallelAndOpenByCurrencyCode(object sender, CellValueChangedEventArgs e)
        {
            bool visibale = !e.Value.ToString().Equals("VND");
            ShowAmountByCurrencyCode(grdAccountingView, "Amount", visibale);
        }
    }
}
