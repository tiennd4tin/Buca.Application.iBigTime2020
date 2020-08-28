
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{

    public partial class FrmPaymentVoucherListPrintFromVoucher_TT39 : FrmXtraBaseParameter, IBudgetSourcesView, IProjectsView
    {
        private IModel _model;

        public string RefId { get; set; }

        public string ReportId { get; set; }

        public int RefType { get; set; }

        private BUTransferModel _bUTransfers;

        private BAWithDrawModel _baWithDraws;

        private BUPlanWithdrawModel _buPlanWithdraws;

        private CAPaymentModel _caPayments;

        private CAReceiptModel _caReceipts;

        private GLVoucherModel _glVouchers;

        private BUVoucherListModel _buVoucherLists;

        private IList<BudgetSourceModel> _budgetSource;

        private readonly ProjectsPresenter _projectsPresenter;
        private IList<TT39Model> _tt39Models;
        public IList<TT39Model> TT39Models { get { return _tt39Models; } }
        private IList<TT39Model> _buTransfer_TT39Model;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;
        private List<ProjectModel> _projects;
        /// <summary>
        /// Gets a value indicating whether this instance is invisible voucher information.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is invisible voucher information; otherwise, <c>false</c>.
        /// </value>
        public bool IsInvisibleVoucherInfo
        {
            get { return checkNotShowDateAndRefNo.Checked; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is invisible when empty org voucher.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is invisible when empty org voucher; otherwise, <c>false</c>.
        /// </value>
        public bool IsInvisibleWhenEmptyOrgVoucher
        {
            get { return checkCurenRefNo.Checked; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is display voucher date.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is display voucher date; otherwise, <c>false</c>.
        /// </value>
        public int IsDisplayVoucherDate
        {
            get { return checkPrintDateVoucher.Checked ? 1 : 0; }
        }

        /// <summary>
        /// Gets the has repeat every page.
        /// </summary>
        /// <value>
        /// The has repeat every page.
        /// </value>
        public int HasRepeatEveryPage
        {
            get { return checkReContentInPage.Checked ? 1 : 0; }
        }

        public string SourceCode
        {
            get { return txtSourceCode.Text.Trim(); }
        }

        public decimal EvictionNumber
        {
            get { return txtEvictionNumber.Value; }
        }
        public string xxxx { get; set; }
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;
        public FrmPaymentVoucherListPrintFromVoucher_TT39()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter.DisplayActive();
            _projectsPresenter.DisplayActive();

        }

        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;
                }
            }
        }

        private void FrmPaymentVoucherListPrintFromVoucher_TT39_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _model = new Model();
            LoadDataIntoGridDetail(RefId);
            //switch (RefType)
            //{
            //    // TT39 chuyển khoản kho bạc
            //    case 56:
            //        LoadDataIntoGridDetail_BUTransfer(RefId);
            //        break;
            //    // TT39 chi tiền gửi
            //    case 157:
            //        LoadDataIntoGridDetail_BAWithDraw(RefId);
            //        break;
            //    // Phiếu chi
            //    case 106:
            //        LoadDataIntoGridDetail_CAPayment(RefId);
            //        break;
            //    default:
            //        break;
            //}
        }

        // Phiếu chi
        private void LoadDataIntoGridDetail(string refId)
        {
            _tt39Models = new List<TT39Model>();
            switch (RefType)
            {
                // TT39 chuyển khoản kho bạc
                case 56:
                case 61:
                case 60:
                case 561:
                    _bUTransfers = _model.GetBUTransferVoucher(refId, true);
                    foreach (var _bUTransferDetail in _bUTransfers.BUTransferDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _bUTransferDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _bUTransfers.RefNo,
                            RefDate = _bUTransfers.RefDate,
                            Description = _bUTransferDetail.Description,
                            AmountOC = _bUTransferDetail.AmountOC,
                            Amount = _bUTransferDetail.Amount,
                            RefId = _bUTransferDetail.RefId,
                            BudgetItemCode = _bUTransferDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _bUTransferDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _bUTransferDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _bUTransferDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _bUTransferDetail.CashWithDrawTypeId,
                            OrgRefNo = _bUTransferDetail.OrgRefNo,
                            OrgRefDate = _bUTransferDetail.OrgRefDate,
                            CurrencyCode = _bUTransfers.CurrencyCode,
                            IsRealExpend = _bUTransferDetail.CashWithDrawTypeId == 4,
                            ProjectCode = !string.IsNullOrEmpty(_bUTransferDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _bUTransferDetail.ProjectId).ProjectCode : "",
                            
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Chuyển khoản kho bạc mua vật tư hàng hóa
                case 57:
                    _bUTransfers = _model.GetBUTransferVoucher(refId, true);
                    foreach (var _bUTransferDetail in _bUTransfers.BUTransferDetailPurchases)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _bUTransferDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _bUTransfers.RefNo,
                            RefDate = _bUTransfers.RefDate,
                            Description = _bUTransferDetail.Description,
                            AmountOC = _bUTransferDetail.Amount,
                            Amount = _bUTransferDetail.Amount,
                            RefId = _bUTransferDetail.RefId,
                            BudgetItemCode = _bUTransferDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _bUTransferDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _bUTransferDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _bUTransferDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _bUTransferDetail.CashWithdrawTypeId,
                            OrgRefNo = _bUTransferDetail.OrgRefNo,
                            OrgRefDate = _bUTransferDetail.OrgRefDate,
                            CurrencyCode = _bUTransfers.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_bUTransferDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _bUTransferDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Chuyển khoản kho bạc mua tài sản cố định
                case 58:
                    _bUTransfers = _model.GetBUTransferVoucherFixedAccess(refId, true);
                    foreach (var _bUTransferDetail in _bUTransfers.BUTransferDetailFixedAssets)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _bUTransferDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _bUTransfers.RefNo,
                            RefDate = _bUTransfers.RefDate,
                            Description = _bUTransferDetail.Description,
                            AmountOC = _bUTransferDetail.Amount,
                            Amount = _bUTransferDetail.Amount,
                            RefId = _bUTransferDetail.RefId,
                            BudgetItemCode = _bUTransferDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _bUTransferDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _bUTransferDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _bUTransferDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _bUTransferDetail.CashWithdrawTypeId,
                            OrgRefNo = _bUTransferDetail.OrgRefNo,
                            OrgRefDate = _bUTransferDetail.OrgRefDate,
                            CurrencyCode = _bUTransfers.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_bUTransferDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _bUTransferDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Chuyển khoản kho bạc mua tài sản cố định
                case 63:
                case 64:
                case 70:
                    _buVoucherLists = _model.GetBUVoucherList(refId, true, false, false);
                    foreach (var _buVoucherListDetail in _buVoucherLists.BUVoucherListDetailModels)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _buVoucherListDetail.BudgetSourceId);
                        string projectCode = "";
                        if (!string.IsNullOrEmpty(_buVoucherListDetail.ProjectId) && _projects != null && _projects.Count > 0)
                        {
                            var project = _projects.FirstOrDefault(x => x.ProjectId == _buVoucherListDetail.ProjectId);
                            projectCode = project != null ? project.ProjectCode : "";
                        }

                        var item = new TT39Model
                        {
                            RefNo = _buVoucherListDetail.RefNo,
                            RefDate = _buVoucherListDetail.RefDate,
                            Description = _buVoucherListDetail.Description,
                            AmountOC = _buVoucherListDetail.Amount,
                            Amount = _buVoucherListDetail.Amount,
                            RefId = _buVoucherListDetail.RefId,
                            BudgetItemCode = _buVoucherListDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _buVoucherListDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget != null ? budget.BudgetSourceCode : "",
                            BudgetKindItemCode = _buVoucherListDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _buVoucherListDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _buVoucherListDetail.CashWithdrawTypeId,
                            OrgRefNo = _buVoucherListDetail.OrgRefNo,
                            OrgRefDate = _buVoucherListDetail.OrgRefDate,
                            CurrencyCode = _buVoucherListDetail.CurrencyCode,
                            ProjectCode = projectCode,
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // TT39 chi tiền gửi
                case 157:
                    _baWithDraws = _model.GetBAWithDraw(refId, true, false, false, false, true);
                    foreach (var _baWithDrawDetail in _baWithDraws.BAWithDrawDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _baWithDrawDetail.BudgetSourceId) ?? new BudgetSourceModel();

                        var item = new TT39Model
                        {
                            RefNo = _baWithDraws.RefNo,
                            RefDate = _baWithDraws.RefDate,
                            Description = _baWithDrawDetail.Description,
                            AmountOC = _baWithDrawDetail.AmountOC,
                            Amount = _baWithDrawDetail.Amount,
                            RefId = _baWithDrawDetail.RefId,
                            BudgetItemCode = _baWithDrawDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _baWithDrawDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _baWithDrawDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _baWithDrawDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _baWithDrawDetail.CashWithDrawTypeId,
                            OrgRefNo = _baWithDrawDetail.OrgRefNo,
                            OrgRefDate = _baWithDrawDetail.OrgRefDate,
                            CurrencyCode = _baWithDraws.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_baWithDrawDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _baWithDrawDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // TT39 chi tiền gửi
                case 159:
                    _baWithDraws = _model.GetBAWithDrawFixedAccess(refId, true, false, false, false, true);
                    foreach (var _baWithDrawDetail in _baWithDraws.BAWithDrawDetailFixedAssets)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _baWithDrawDetail.BudgetSourceId) ?? new BudgetSourceModel();

                        var item = new TT39Model
                        {
                            RefNo = _baWithDraws.RefNo,
                            RefDate = _baWithDraws.RefDate,
                            Description = _baWithDrawDetail.Description,
                            //  AmountOC = _baWithDrawDetail.Amou,
                            Amount = _baWithDrawDetail.Amount,
                            RefId = _baWithDrawDetail.RefId,
                            BudgetItemCode = _baWithDrawDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _baWithDrawDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _baWithDrawDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _baWithDrawDetail.BudgetSubKindItemCode ?? "",
                            //  CashWithDrawTypeId = _baWithDrawDetail.CashWithDrawTypeId,
                            OrgRefNo = _baWithDrawDetail.OrgRefNo,
                            OrgRefDate = _baWithDrawDetail.OrgRefDate,
                            CurrencyCode = _baWithDraws.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_baWithDrawDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _baWithDrawDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // TT39 Rút dự toán (4 chứng từ)
                case 54:
                case 55:
                case 562:
                case 563:
                    _buPlanWithdraws = _model.GetBUPlanWithdrawByRefId(refId, true);
                    foreach (var _buPlanWithdrawDetail in _buPlanWithdraws.BUPlanWithdrawDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _buPlanWithdrawDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _buPlanWithdraws.RefNo,
                            RefDate = _buPlanWithdraws.RefDate,
                            Description = _buPlanWithdrawDetail.Description,
                            AmountOC = _buPlanWithdrawDetail.AmountOC,
                            Amount = _buPlanWithdrawDetail.Amount,
                            RefId = _buPlanWithdrawDetail.RefId,
                            BudgetItemCode = _buPlanWithdrawDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _buPlanWithdrawDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _buPlanWithdrawDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _buPlanWithdrawDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _buPlanWithdraws.CashWithDrawType,
                            OrgRefNo = _buPlanWithdrawDetail.OrgRefNo,
                            OrgRefDate = _buPlanWithdrawDetail.OrgRefDate,
                            CurrencyCode = _buPlanWithdraws.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_buPlanWithdrawDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _buPlanWithdrawDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Phiếu thu
                case 105:
                case 114:
                    _caReceipts = _model.GetReceiptVoucher(refId, true, false);
                    foreach (var _caReceiptDetail in _caReceipts.CAReceiptDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _caReceiptDetail.BudgetSourceId);
                        var item = new TT39Model
                        {
                            RefNo = _caReceipts.RefNo,
                            RefDate = _caReceipts.RefDate,
                            Description = _caReceiptDetail.Description,
                            AmountOC = _caReceiptDetail.AmountOC,
                            Amount = _caReceiptDetail.Amount,
                            RefId = _caReceiptDetail.RefId,
                            BudgetItemCode = _caReceiptDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _caReceiptDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _caReceiptDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _caReceiptDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _caReceiptDetail.CashWithdrawTypeId,
                            OrgRefNo = _caReceiptDetail.OrgRefNo,
                            OrgRefDate = _caReceiptDetail.OrgRefDate,
                            CurrencyCode = _caReceipts.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_caReceiptDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _caReceiptDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Phiếu chi
                case 106:
                    _caPayments = _model.GetPaymentVoucher(refId, true, false);
                    foreach (var _caPaymentDetail in _caPayments.CAPaymentDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _caPaymentDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _caPayments.RefNo,
                            RefDate = _caPayments.RefDate,
                            Description = _caPaymentDetail.Description,
                            AmountOC = _caPaymentDetail.AmountOC,
                            Amount = _caPaymentDetail.Amount,
                            RefId = _caPaymentDetail.RefId,
                            BudgetItemCode = _caPaymentDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _caPaymentDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _caPaymentDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _caPaymentDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _caPaymentDetail.CashWithDrawTypeId,
                            OrgRefNo = _caPaymentDetail.OrgRefNo,
                            OrgRefDate = _caPaymentDetail.OrgRefDate,
                            CurrencyCode = _caPayments.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_caPaymentDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _caPaymentDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
                // Chứng từ chung
                case 401:
                    _glVouchers = _model.GetGLVoucher(refId, true, false);
                    foreach (var _glVoucherDetail in _glVouchers.GLVoucherDetails)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _glVoucherDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _glVouchers.RefNo,
                            RefDate = _glVouchers.RefDate,
                            Description = _glVoucherDetail.Description,
                            AmountOC = _glVoucherDetail.AmountOC,
                            Amount = _glVoucherDetail.Amount,
                            RefId = _glVoucherDetail.RefId,
                            BudgetItemCode = _glVoucherDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _glVoucherDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = budget.BudgetSourceCode,
                            BudgetKindItemCode = _glVoucherDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _glVoucherDetail.BudgetSubKindItemCode ?? "",
                            CashWithDrawTypeId = _glVoucherDetail.CashWithDrawTypeId,
                            OrgRefNo = _glVoucherDetail.OrgRefNo,
                            OrgRefDate = _glVoucherDetail.OrgRefDate,
                            CurrencyCode = _glVouchers.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_glVoucherDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _glVoucherDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;

                    // Ghi tăng
                case 108:
                    _caPayments = _model.GetPaymentVoucher(refId, true, false,false,true);
                    foreach (var _caPaymentDetail in _caPayments.CAPaymentDetailFixedAssets)
                    {
                        var budget = _budgetSource.FirstOrDefault(x => x.BudgetSourceId == _caPaymentDetail.BudgetSourceId);

                        var item = new TT39Model
                        {
                            RefNo = _caPayments.RefNo,
                            RefDate = _caPayments.RefDate,
                            Description = _caPaymentDetail.Description,
                            //AmountOC = _caPaymentDetail.ExchangeAmount,
                            Amount = _caPaymentDetail.Amount,
                            RefId = _caPaymentDetail.RefId,
                            BudgetItemCode = _caPaymentDetail.BudgetItemCode ?? "",
                            BudgetSubItemCode = _caPaymentDetail.BudgetSubItemCode ?? "",
                            Quantity = 0,
                            Quota = 0,
                            ActualUnitPrice = 0,
                            BudgetSourceCode = _caPaymentDetail.BudgetSourceId,
                            BudgetKindItemCode = _caPaymentDetail.BudgetKindItemCode ?? "",
                            BudgetSubKindItemCode = _caPaymentDetail.BudgetSubKindItemCode ?? "",
                            //CashWithDrawTypeId = _caPaymentDetail.CashWithDrawTypeI,
                            OrgRefNo = _caPaymentDetail.OrgRefNo,
                            OrgRefDate = _caPaymentDetail.OrgRefDate,
                            CurrencyCode = _caPayments.CurrencyCode,
                            ProjectCode = !string.IsNullOrEmpty(_caPaymentDetail.ProjectId) ? _projects.FirstOrDefault(x => x.ProjectId == _caPaymentDetail.ProjectId).ProjectCode : "",
                        };
                        _tt39Models.Add(item);
                    }
                    break;
            }

            gridDetailViewTT39.BeginInit();
            ListBindingSource.DataSource = _tt39Models.OrderBy(c => c.BudgetSourceCode).ToList();
            gridDetailViewTT39.PopulateColumns(_tt39Models);
            gridDetailViewTT39.EndInit();
            gridDetailTT39.ForceInitialize();
            var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = false,
                        ColumnWith = 90,
                        ColumnCaption = "Mã NDKT",
                        ColumnPosition = 1,
                        AllowEdit = false,
                    },
                 new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = false,
                        ColumnWith = 90,
                        ColumnCaption = "Mã ngành KT",
                        ColumnPosition = 2,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nguồn",
                        ColumnPosition = 3,
                        AllowEdit = false,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnVisible = true,
                        ColumnWith = 118,
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quota", ColumnVisible = true,
                        ColumnWith = 140,
                        ColumnCaption = "Định mức",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                      new XtraColumn
                    {
                        ColumnName = "ActualUnitPrice", ColumnVisible = true,
                        ColumnWith = 135,
                        ColumnCaption = "Đơn giá thực tế",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "Amount", ColumnVisible = true,
                        ColumnWith = 138,
                        ColumnCaption = "Thành tiền" + "",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "ProjectCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefType", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefNo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "JournalMemo", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DebitAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TotalAmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsRealExpend", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPlanned", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsAdvance", ColumnVisible = false}
                };
            gridDetailViewTT39 = InitGridLayout(columnsCollection, gridDetailViewTT39);
            SetNumericFormatControl(gridDetailViewTT39, true);
            gridDetailViewTT39.OptionsView.ShowFooter = false;
        }

        /// <summary>
        /// Gets the bu transfer t T39 models.
        /// </summary>
        /// <value>
        /// The bu transfer t T39 models.
        /// </value>
        public IList<TT39Model> BUTransfer_TT39Models
        {
            get
            {
                //Đoạn này gán các giá trị để lấy tham số xác định nghiệp vụ cho từng nhóm
                _buTransfer_TT39Model = new List<TT39Model>();
                if (_tt39Models.Count > 0)
                {
                    var groupTT39 = _tt39Models.Select(x => new { x.BudgetSourceCode }).Distinct();
                    //foreach (var item in _tt39Models)
                    //{
                    //    var budgetSourceCode = item.BudgetSourceCode;
                    //    var voucherLists = _tt39Models.Where(x => x.BudgetSourceCode == budgetSourceCode).ToList();
                    var isRealExpend = true;
                    //    //TinTv: Tạm ẩn check thu hồi tạm ứng
                    //    //var isPlanned = _tt39Models.Where(x => x.CashWithDrawTypeId == 3 && x.BudgetSourceCode == budgetSourceCode).ToList().Count > 0;
                    var isPlanned = false;
                    var isAdvance = _tt39Models.Where(x => (x.CashWithDrawTypeId == 1) && x.BudgetSourceCode == "1").ToList().Count > 0;

                    foreach (var voucherList in _tt39Models)
                    {
                        var newItem = new TT39Model
                        {
                            RefNo = voucherList.RefNo,
                            RefDate = voucherList.RefDate,
                            Description = voucherList.Description,
                            AmountOC = voucherList.AmountOC,
                            Amount = voucherList.Amount,
                            RefId = voucherList.RefId,
                            BudgetItemCode = voucherList.BudgetItemCode,
                            BudgetSubItemCode = voucherList.BudgetSubItemCode,
                            Quantity = voucherList.Quantity,
                            Quota = voucherList.Quota,
                            ActualUnitPrice = voucherList.ActualUnitPrice,
                            BudgetSourceCode = "8888",
                            BudgetKindItemCode = voucherList.BudgetKindItemCode,
                            BudgetSubKindItemCode = voucherList.BudgetSubKindItemCode,
                            CashWithDrawTypeId = voucherList.CashWithDrawTypeId,
                            OrgRefNo = voucherList.OrgRefNo,
                            OrgRefDate = voucherList.OrgRefDate,
                            CurrencyCode = voucherList.CurrencyCode,
                            IsRealExpend = isRealExpend,
                            IsPlanned = isPlanned,
                            IsAdvance = isAdvance,
                            ProjectCode = voucherList.ProjectCode
                        };
                        _buTransfer_TT39Model.Add(newItem);
                    }
                    //}
                }
                return _buTransfer_TT39Model;
            }
        }

        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView39)
        {
            foreach (var column in columnsCollection)
            {

                if (grdView39.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {
                        grdView39.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdView39.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdView39.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdView39.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdView39.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdView39.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdView39.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdView39.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdView39.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        if (column.IsSummaryText)
                        {
                            grdView39.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView39.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
                        }
                    }
                    else
                    {
                        grdView39.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
            return grdView39;
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    _budgetSource = value.ToList();
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard
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
                        },
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceCategoryId",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSavingExpenses", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "BudgetSourceProperty",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "BankAccountId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "PayableBankAccountId",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "IsSelfControl", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceType", ColumnVisible = false}
                    };
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";

                    xxxx = _gridLookUpEditBudgetSource.DisplayMember;
                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _projects = value.ToList();
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
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
