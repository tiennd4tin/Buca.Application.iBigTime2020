/***********************************************************************
 * <copyright file="frmbuvoucherlistdetailparameter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, June 12, 2018
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    ///     FrmBUVoucherListDetailParameter
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IRefTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    public partial class FrmBUVoucherListDetailParameter : FrmXtraBaseParameter, IBudgetSourcesView, IRefTypesView,
        IProjectsView
    {
        /// <summary>
        ///     The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        ///     The projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        ///     The reference types presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        ///     The model
        /// </summary>
        private readonly IModel Model;

        /// <summary>
        ///     The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        ///     The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        ///     The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        /// <summary>
        ///     The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        ///     The models
        /// </summary>
        private readonly IList<BUVoucherListDetailModel> _models;

        /// <summary>
        ///     The reference types
        /// </summary>
        private List<RefTypeModel> _refTypes;

        /// <summary>
        ///     The grid look up edit reference type
        /// </summary>
        protected RepositoryItemGridLookUpEdit GridLookUpEditRefType;

        /// <summary>
        ///     The grid look up edit reference type view
        /// </summary>
        protected GridView GridLookUpEditRefTypeView;

        private string _cashWithdrawNo = "";

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmBUVoucherListDetailParameter" /> class.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="bUVoucherListDetailModels">The b u voucher list detail models.</param>
        public FrmBUVoucherListDetailParameter(DateTime fromDate, DateTime toDate,
            IList<BUVoucherListDetailModel> bUVoucherListDetailModels, string cashWithdrawNo)
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            if (bUVoucherListDetailModels == null || bUVoucherListDetailModels.Count == 0)
            {
                dateTimeRangeV1.InitData(DateTime.Today);
                var dt = DateTime.Now;
                var firstDayOfMonth = new DateTime(dt.Year, dt.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                dateTimeRangeV1.FromDate = firstDayOfMonth;
                dateTimeRangeV1.ToDate = lastDayOfMonth;
            }
            else
            {
                dateTimeRangeV1.FromDate = fromDate;
                dateTimeRangeV1.ToDate = toDate;

            }
            _cashWithdrawNo = cashWithdrawNo;
            Model = new Model.Model();
            _models = bUVoucherListDetailModels;
            btnFilter_Click(null, null);
        }

        /// <summary>
        ///     Gets the selection.
        /// </summary>
        /// <value>
        ///     The selection.
        /// </value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        ///     Gets from date.
        /// </summary>
        /// <value>
        ///     From date.
        /// </value>
        public DateTime FromDate { get { return dateTimeRangeV1.FromDate; } }

        /// <summary>
        ///     Sets to date.
        /// </summary>
        /// <value>
        ///     To date.
        /// </value>
        public DateTime ToDate { get { return dateTimeRangeV1.ToDate; } }

        /// <summary>
        ///     Gets or sets the condition filter.
        /// </summary>
        /// <value>
        ///     The condition filter.
        /// </value>
        public int ConditionFilter { get; set; }

        /// <summary>
        ///     Gets the bu voucher list detail models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail models.
        /// </value>
        public IList<BUVoucherListDetailModel> BUVoucherListDetailModels
        {
            get
            {
                var listClause = new List<BUVoucherListDetailModel>();

                if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
                    for (var i = 0; i < gridviewAccount.RowCount; i++)
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (BUVoucherListDetailModel)gridviewAccount.GetRow(i);

                            var items = new BUVoucherListDetailModel
                            {
                                BudgetSourceId = row.BudgetSourceId,
                                PostedDate = row.PostedDate,
                                RefDate = row.RefDate,
                                RefNo = row.RefNo,
                                Amount = row.Amount,
                                DebitAccount = row.DebitAccount,
                                CreditAccount = row.CreditAccount,
                                SortOrder = 0,
                                RefId = row.RefId,
                                ExchangeRate = row.ExchangeRate,
                                CurrencyCode = row.CurrencyCode,
                                CashWithdrawTypeId = row.CashWithdrawTypeId,
                                Description = row.Description,
                                BankAccount = row.BankAccount,
                                AmountOC = row.AmountOC,
                                RefDetailId = row.RefDetailId,
                                AccountingObjectId = row.AccountingObjectId,
                                ActivityId = row.ActivityId,
                                Approved = row.Approved,
                                BudgetChapterCode = row.BudgetChapterCode,
                                BudgetDetailItemCode = row.BudgetDetailItemCode,
                                BudgetItemCode = row.BudgetItemCode,
                                BudgetKindItemCode = row.BudgetKindItemCode,
                                BudgetProvideCode = row.BudgetProvideCode,
                                BudgetSubItemCode = row.BudgetSubItemCode,
                                BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                FundStructureId = row.FundStructureId,
                                ListItemId = row.ListItemId,
                                MethodDistributeId = row.MethodDistributeId,
                                OrgRefDate = row.OrgRefDate,
                                OrgRefNo = row.OrgRefNo,
                                ProjectActivityEAId = row.ProjectActivityEAId,
                                ProjectActivityId = row.ProjectActivityId,
                                ProjectExpenseEAId = row.ProjectExpenseEAId,
                                ProjectExpenseId = row.ProjectExpenseId,
                                ProjectId = row.ProjectId,
                                VoucherRefId = row.VoucherRefId,
                                VoucherRefDetailId = row.VoucherRefDetailId,
                                VoucherRefType = row.VoucherRefType
                            };
                            listClause.Add(items);
                        }
                return listClause;
            }
        }

        /// <summary>
        ///     Gets the bu voucher list detail transfer models.
        /// </summary>
        /// <value>
        ///     The bu voucher list detail transfer models.
        /// </value>
        public IList<BUVoucherListDetailTransferModel> BUVoucherListDetailTransferModels
        {
            get
            {
                var listClause = new List<BUVoucherListDetailTransferModel>();

                if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
                    for (var i = 0; i < gridviewAccount.RowCount; i++)
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (BUVoucherListDetailModel)gridviewAccount.GetRow(i);
                            if (row.MethodDistributeId == 1)
                            {
                                var items = new BUVoucherListDetailTransferModel
                                {
                                    BudgetSourceId = row.BudgetSourceId,
                                    Amount = row.Amount,
                                    CreditAccount = "013",
                                    DebitAccount = null,
                                    SortOrder = 0,
                                    RefId = row.RefId,
                                    ExchangeRate = row.ExchangeRate,
                                    CurrencyCode = row.CurrencyCode,
                                    CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                    Description = row.Description,
                                    BankAccount = row.BankAccount,
                                    AmountOC = row.AmountOC.Value,
                                    RefDetailId = row.RefDetailId,
                                    AccountingObjectId = row.AccountingObjectId,
                                    ActivityId = row.ActivityId,
                                    BudgetChapterCode = row.BudgetChapterCode,
                                    BudgetDetailItemCode = row.BudgetDetailItemCode,
                                    BudgetItemCode = row.BudgetItemCode,
                                    BudgetKindItemCode = row.BudgetKindItemCode,
                                    BudgetProvideCode = row.BudgetProvideCode,
                                    BudgetSubItemCode = row.BudgetSubItemCode,
                                    BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                    FundStructureId = row.FundStructureId,
                                    ListItemId = row.ListItemId,
                                    MethodDistributeId = row.MethodDistributeId,
                                    ProjectActivityEAId = row.ProjectActivityEAId,
                                    ProjectActivityId = row.ProjectActivityId,
                                    ProjectExpenseEAId = row.ProjectExpenseEAId,
                                    ProjectExpenseId = row.ProjectExpenseId,
                                    ProjectId = row.ProjectId
                                };
                                listClause.Add(items);
                            }
                            else
                            {
                                if (row.MethodDistributeId == 0)
                                {
                                    var creditAccountOne = "";
                                    var creditAccountTwo = "";
                                    if (row.DebitAccount.StartsWith("6111"))
                                    {
                                        creditAccountOne = "008211";
                                        creditAccountTwo = "008212";
                                        listClause.Add(new BUVoucherListDetailTransferModel
                                        {
                                            BudgetSourceId = row.BudgetSourceId,
                                            Amount = row.Amount * -1,
                                            DebitAccount = null,
                                            CreditAccount = creditAccountOne,
                                            SortOrder = 0,
                                            RefId = row.RefId,
                                            ExchangeRate = row.ExchangeRate,
                                            CurrencyCode = row.CurrencyCode,
                                            CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                            Description = row.Description,
                                            BankAccount = row.BankAccount,
                                            AmountOC = row.AmountOC.Value * -1,
                                            RefDetailId = row.RefDetailId,
                                            AccountingObjectId = row.AccountingObjectId,
                                            ActivityId = row.ActivityId,
                                            BudgetChapterCode = row.BudgetChapterCode,
                                            BudgetDetailItemCode = row.BudgetDetailItemCode,
                                            BudgetItemCode = row.BudgetItemCode,
                                            BudgetKindItemCode = row.BudgetKindItemCode,
                                            BudgetProvideCode = row.BudgetProvideCode,
                                            BudgetSubItemCode = row.BudgetSubItemCode,
                                            BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                            FundStructureId = row.FundStructureId,
                                            ListItemId = row.ListItemId,
                                            MethodDistributeId = row.MethodDistributeId,
                                            ProjectActivityEAId = row.ProjectActivityEAId,
                                            ProjectActivityId = row.ProjectActivityId,
                                            ProjectExpenseEAId = row.ProjectExpenseEAId,
                                            ProjectExpenseId = row.ProjectExpenseId,
                                            ProjectId = row.ProjectId
                                        });
                                        listClause.Add(new BUVoucherListDetailTransferModel
                                        {
                                            BudgetSourceId = row.BudgetSourceId,
                                            Amount = row.Amount,
                                            DebitAccount = null,
                                            CreditAccount = creditAccountTwo,
                                            SortOrder = 0,
                                            RefId = row.RefId,
                                            ExchangeRate = row.ExchangeRate,
                                            CurrencyCode = row.CurrencyCode,
                                            CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                            Description = row.Description,
                                            BankAccount = row.BankAccount,
                                            AmountOC = row.AmountOC.Value,
                                            RefDetailId = row.RefDetailId,
                                            AccountingObjectId = row.AccountingObjectId,
                                            ActivityId = row.ActivityId,
                                            BudgetChapterCode = row.BudgetChapterCode,
                                            BudgetDetailItemCode = row.BudgetDetailItemCode,
                                            BudgetItemCode = row.BudgetItemCode,
                                            BudgetKindItemCode = row.BudgetKindItemCode,
                                            BudgetProvideCode = row.BudgetProvideCode,
                                            BudgetSubItemCode = row.BudgetSubItemCode,
                                            BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                            FundStructureId = row.FundStructureId,
                                            ListItemId = row.ListItemId,
                                            MethodDistributeId = row.MethodDistributeId,
                                            ProjectActivityEAId = row.ProjectActivityEAId,
                                            ProjectActivityId = row.ProjectActivityId,
                                            ProjectExpenseEAId = row.ProjectExpenseEAId,
                                            ProjectExpenseId = row.ProjectExpenseId,
                                            ProjectId = row.ProjectId
                                        });
                                    }

                                    if (row.DebitAccount.StartsWith("6112"))
                                    {
                                        creditAccountOne = "008221";
                                        creditAccountTwo = "008222";
                                        listClause.Add(new BUVoucherListDetailTransferModel
                                        {
                                            BudgetSourceId = row.BudgetSourceId,
                                            Amount = row.Amount * (-1),
                                            DebitAccount = null,
                                            CreditAccount = creditAccountOne,
                                            SortOrder = 0,
                                            RefId = row.RefId,
                                            ExchangeRate = row.ExchangeRate,
                                            CurrencyCode = row.CurrencyCode,
                                            CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                            Description = row.Description,
                                            BankAccount = row.BankAccount,
                                            AmountOC = row.AmountOC.Value * -1,
                                            RefDetailId = row.RefDetailId,
                                            AccountingObjectId = row.AccountingObjectId,
                                            ActivityId = row.ActivityId,
                                            BudgetChapterCode = row.BudgetChapterCode,
                                            BudgetDetailItemCode = row.BudgetDetailItemCode,
                                            BudgetItemCode = row.BudgetItemCode,
                                            BudgetKindItemCode = row.BudgetKindItemCode,
                                            BudgetProvideCode = row.BudgetProvideCode,
                                            BudgetSubItemCode = row.BudgetSubItemCode,
                                            BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                            FundStructureId = row.FundStructureId,
                                            ListItemId = row.ListItemId,
                                            MethodDistributeId = row.MethodDistributeId,
                                            ProjectActivityEAId = row.ProjectActivityEAId,
                                            ProjectActivityId = row.ProjectActivityId,
                                            ProjectExpenseEAId = row.ProjectExpenseEAId,
                                            ProjectExpenseId = row.ProjectExpenseId,
                                            ProjectId = row.ProjectId
                                        });
                                        listClause.Add(new BUVoucherListDetailTransferModel
                                        {
                                            BudgetSourceId = row.BudgetSourceId,
                                            Amount = row.Amount,
                                            DebitAccount = null,
                                            CreditAccount = creditAccountTwo,
                                            SortOrder = 0,
                                            RefId = row.RefId,
                                            ExchangeRate = row.ExchangeRate,
                                            CurrencyCode = row.CurrencyCode,
                                            CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                            Description = row.Description,
                                            BankAccount = row.BankAccount,
                                            AmountOC = row.AmountOC.Value,
                                            RefDetailId = row.RefDetailId,
                                            AccountingObjectId = row.AccountingObjectId,
                                            ActivityId = row.ActivityId,
                                            BudgetChapterCode = row.BudgetChapterCode,
                                            BudgetDetailItemCode = row.BudgetDetailItemCode,
                                            BudgetItemCode = row.BudgetItemCode,
                                            BudgetKindItemCode = row.BudgetKindItemCode,
                                            BudgetProvideCode = row.BudgetProvideCode,
                                            BudgetSubItemCode = row.BudgetSubItemCode,
                                            BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                            FundStructureId = row.FundStructureId,
                                            ListItemId = row.ListItemId,
                                            MethodDistributeId = row.MethodDistributeId,
                                            ProjectActivityEAId = row.ProjectActivityEAId,
                                            ProjectActivityId = row.ProjectActivityId,
                                            ProjectExpenseEAId = row.ProjectExpenseEAId,
                                            ProjectExpenseId = row.ProjectExpenseId,
                                            ProjectId = row.ProjectId
                                        });
                                    }

                                    //if (row.DebitAccount.StartsWith("137"))
                                    //{

                                    //    listClause.Add(new BUVoucherListDetailTransferModel
                                    //    {
                                    //        BudgetSourceId = row.BudgetSourceId,
                                    //        Amount = row.Amount * (-1),
                                    //        DebitAccount = null,
                                    //        CreditAccount = row.CreditAccount,
                                    //        SortOrder = 0,
                                    //        RefId = row.RefId,
                                    //        ExchangeRate = row.ExchangeRate,
                                    //        CurrencyCode = row.CurrencyCode,
                                    //        CashWithDrawTypeId = _cashWithdrawNo == "01" || _cashWithdrawNo == "02" ? 3 : row.CashWithdrawTypeId,
                                    //        Description = row.Description,
                                    //        BankAccount = row.BankAccount,
                                    //        AmountOC = row.AmountOC.Value * -1,
                                    //        RefDetailId = row.RefDetailId,
                                    //        AccountingObjectId = row.AccountingObjectId,
                                    //        ActivityId = row.ActivityId,
                                    //        BudgetChapterCode = row.BudgetChapterCode,
                                    //        BudgetDetailItemCode = row.BudgetDetailItemCode,
                                    //        BudgetItemCode = row.BudgetItemCode,
                                    //        BudgetKindItemCode = row.BudgetKindItemCode,
                                    //        BudgetProvideCode = row.BudgetProvideCode,
                                    //        BudgetSubItemCode = row.BudgetSubItemCode,
                                    //        BudgetSubKindItemCode = row.BudgetSubKindItemCode,
                                    //        FundStructureId = row.FundStructureId,
                                    //        ListItemId = row.ListItemId,
                                    //        MethodDistributeId = row.MethodDistributeId,
                                    //        ProjectActivityEAId = row.ProjectActivityEAId,
                                    //        ProjectActivityId = row.ProjectActivityId,
                                    //        ProjectExpenseEAId = row.ProjectExpenseEAId,
                                    //        ProjectExpenseId = row.ProjectExpenseId,
                                    //        ProjectId = row.ProjectId
                                    //    });

                                    //}
                                }
                            }
                        }
                return listClause;
            }
        }

        /// <summary>
        /// Sets the bu voucher list detail paramater.
        /// </summary>
        /// <value>
        /// The bu voucher list detail paramater.
        /// </value>
        public IList<BUVoucherListDetailModel> BUVoucherListDetailParamater
        {
            set
            {
                // Lọc bỏ các chứng từ đã được chọn rồi
                value = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUVoucherListDetailModel>();
                //value = value.Where(m => m.MethodDistributeId.HasValue && !string.IsNullOrEmpty(m.DebitAccount) &&
                //        (m.MethodDistributeId == 0 || m.MethodDistributeId == 1) && (m.CreditAccount.StartsWith("111") || m.CreditAccount.StartsWith("112")))
                //    .ToList();
                value = value.Where(m => !String.IsNullOrEmpty(m.CreditAccount) && (m.CreditAccount.StartsWith("111") || m.CreditAccount.StartsWith("112")))
                    .ToList();
                if (_models != null && _models.Count > 0)
                    value = value.Where(m =>
                        !_models.ToList().Exists(n => n.VoucherRefDetailId.Equals(m.VoucherRefDetailId))).ToList();
                if (ConditionFilter == 1)
                {
                    var filter = value.Where(f => f.RefDate <= ToDate && f.RefDate >= FromDate);
                    if (filter.Count() == 0)
                        filter = new List<BUVoucherListDetailModel>();

                    bindingSource.DataSource = filter;
                    grdAccount.ForceInitialize();
                    gridviewAccount.PopulateColumns(filter);
                }
                else
                {
                    bindingSource.DataSource = value.OrderBy(c => c.SortOrder).ToList() ?? new List<BUVoucherListDetailModel>();
                    grdAccount.ForceInitialize();
                    gridviewAccount.PopulateColumns(value);
                }
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "VoucherRefDetailId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Approved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectExpenseEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectActivityEAId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "VoucherRefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherRefType",
                    ColumnCaption = "Loại chứng từ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    FixedColumn = FixedStyle.Left,
                    RepositoryControl = GridLookUpEditRefType,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn Giải",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số Tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditBudgetSource
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    ColumnPosition = 12,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu Mục",
                    ColumnPosition = 13,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefNo",
                    ColumnCaption = "Số CT Gốc",
                    ColumnPosition = 14,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefDate",
                    ColumnCaption = "Ngày CT Gốc",
                    ColumnPosition = 15,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "Dự Án",
                    ColumnPosition = 16,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditProject
                });

                gridviewAccount.InitGridLayout(columnsCollection);
                gridviewAccount.OptionsView.ShowFooter = false;
                gridviewAccount.OptionsView.ColumnAutoWidth = false;
                gridviewAccount.BestFitColumns();
                Selection = new GridCheckMarksSelection(gridviewAccount);
                Selection.CheckMarkColumn.VisibleIndex = 0;
                Selection.CheckMarkColumn.Width = 40;
                Selection.CheckMarkColumn.Fixed = FixedStyle.Left;
                SetNumericFormatControl(gridviewAccount, false);
            }
        }

        /// <summary>
        ///     Sets the budget sources.
        /// </summary>
        /// <value>
        ///     The budget sources.
        /// </value>
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

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceCode",
                            ColumnCaption = "Mã nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnPosition = 1
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceName",
                            ColumnCaption = "Tên nguồn vốn",
                            ColumnVisible = true,
                            ColumnWith = 250,
                            ColumnPosition = 2
                        }
                    };
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Sets the projects.
        /// </summary>
        /// <value>
        ///     The projects.
        /// </value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    var projects = value.OrderBy(c => c.ProjectCode).ToList();

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

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);
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
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Sets the reference types.
        /// </summary>
        /// <value>
        ///     The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                try
                {
                    GridLookUpEditRefTypeView = new GridView();
                    GridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                    GridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = GridLookUpEditRefTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True,
                        NullValuePrompt = null,
                        DisplayMember = "RefTypeName",
                        ValueMember = "RefTypeId"
                    };
                    GridLookUpEditRefTypeView.PopulateColumns();

                    GridLookUpEditRefType.DataSource = value;
                    GridLookUpEditRefTypeView.PopulateColumns(value);
                    _refTypes = value.ToList();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeName",
                        ColumnCaption = "Tên loại CT",
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultDebitAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultCreditAccountId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DefaultTaxAccountCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Postable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Searchable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                        }
                    GridLookUpEditRefType.DisplayMember = "RefTypeName";
                    GridLookUpEditRefType.ValueMember = "RefTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        ///     Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns></returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
                if (grdView.Columns[column.ColumnName] != null)
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
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            return grdView;
        }

        /// <summary>
        ///     Handles the Load event of the FrmBUVoucherListDetailParameter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmBUVoucherListDetailParameter_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _refTypesPresenter.Display();
            _projectsPresenter.Display();
            BUVoucherListDetailParamater =
                Model.GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(_cashWithdrawNo);
        }

        /// <summary>
        ///     Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the Click event of the btnFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            ConditionFilter = 1;
            BUVoucherListDetailParamater =
                Model.GetOriginalGeneralLedgerNotInBUVoucherListDetailByCashWithdrawNo(_cashWithdrawNo);
            grdAccount.Refresh();
        }
    }
}