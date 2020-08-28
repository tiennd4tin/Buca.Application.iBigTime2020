using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Deposit;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Cash.ReceiptVoucher;
using Buca.Application.iBigTime2020.Presenter.Deposit;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.View.Deposit;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.Estimate;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BuCA.Application.iBigTime2020.Report
{
    public partial class FrmC301NS_Param : XtraForm,IProjectsView, IBUTransferView, ICAReceiptView, IBADepositView
    {
        private readonly BanksPresenter _banksPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BUTransferPresenter _bUTransferPresenter;
        private readonly CAReceiptPresenter _caReceiptPresenter;
        private readonly BADepositPresenter _bADepositPresenter;
        private List<BUTransferDetailModel> GetListDataBUTransfer = new List<BUTransferDetailModel>();
        private List<CAReceiptDetailModel> GetListDataCAReceipt = new List<CAReceiptDetailModel>();
        private List<BADepositDetailModel> GetListDataBADeposit = new List<BADepositDetailModel>();
        public List<SelectItemModel> Parallels { get; set; }
        public string KeyValue { get; set; }
        public string Address { get; set; }
        #region Variables
        public bool Check1
        {
            get { return check1.Checked ? true : false; }
        }
        public bool Check2
        {
            get { return check2.Checked ? true : false; }
        }
        public bool Check3
        {
            get { return check3.Checked ? true : false; }
        }
        public bool Check4
        {
            get { return check4.Checked ? true : false; }
        }
        public bool Check5
        {
            get { return check5.Checked ? true : false; }
        }
        public bool Check6
        {
            get { return check6.Checked ? true : false; }
        }
        public bool Check7
        {
            get { return check7.Checked ? true : false; }
        }

        public int TaxYear
        {
            get
            {
                return string.IsNullOrEmpty(txtYear.Text) ? 0: Convert.ToInt32(txtYear.Text);
            }
        }
        
        public string ProjectCode
        {
            get { return Convert.ToString(cboTargetProgramId.Text); }
        }

        public string ProjectName
        {
            get { return Convert.ToString(cboTargetProgramId.GetColumnValue(nameof(ProjectModel.ProjectName))); }
        }

        public string CKCHDK
        {
            get
            {
                return txtCKC_HDK.Text;
            }
        }

        public string CKCHDTH
        {
            get
            {
                return txtHDTH.Text;
            }
        }

        public List<BUTransferDetailModel> ListDetails
        {
            get
            {
                return GetListDataBUTransfer;
            }
        }
        public List<CAReceiptDetailModel> ListDetailCAReceipts
        {
            get
            {
                return GetListDataCAReceipt;
            }
        }

        public List<BADepositDetailModel> ListDetailBADeposit
        {
            get
            {
                return GetListDataBADeposit;
            }
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    cboTargetProgramId.Properties.DataSource = value;
                    cboTargetProgramId.Properties.ForceInitialize();
                    cboTargetProgramId.Properties.PopulateColumns();
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectCode",
                            ColumnCaption = "Mã CTMT, dự án",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100
                        },
                        new XtraColumn
                        {
                            ColumnName = "ProjectName",
                            ColumnCaption = "Tên CTMT, dự án",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250
                        },
                        new XtraColumn {ColumnName = "ProjectNumber", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "ProjectEnglishName",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "BUCACodeID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "StartDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FinishDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExecutionUnit", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DepartmentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "TotalAmountApproved", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn
                        {
                            ColumnName = "IsDetailbyActivityAndExpense",
                            ColumnVisible = false
                        },
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                         new XtraColumn {ColumnName = "ObjectType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ObjectTypeName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorID", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ContractorAddress", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ProjectSize", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BuildLocation", ColumnVisible = false},
                        new XtraColumn {ColumnName = "InvestmentClass", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CDCActivityType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Investment", ColumnVisible = false}
                    };
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            cboTargetProgramId.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    cboTargetProgramId.Properties.DisplayMember = "ProjectCode";
                    cboTargetProgramId.Properties.ValueMember = "ProjectCode";
                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    // MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public string RefId { get; set; }
        public bool Approved { get; set; }
        public int RefType { get; set; }
        public DateTime RefDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string RefNo { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public string ParalellRefNo { get; set; }
        public string JournalMemo { get; set; }
        public string TargetProgramId { get; set; }
        public string BankInfoId { get; set; }
        public string AccountingObjectId { get; set; }
        public string AccountingObjectName { get; set; }
        public string AccountingObjectAddress { get; set; }
        public string AccountingObjectBankAccount { get; set; }
        public string AccountingObjectBankName { get; set; }
        public string DocumentIncluded { get; set; }
        public string InwardStockRefNo { get; set; }
        public DateTime? WithdrawRefDate { get; set; }
        public string WithdrawRefNo { get; set; }
        public string IncrementRefNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountOC { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalFreightAmount { get; set; }
        public decimal TotalInwardAmount { get; set; }
        public bool Posted { get; set; }
        public int? PostVersion { get; set; }
        public int? EditVersion { get; set; }
        public int? RefOrder { get; set; }
        public string RelationRefId { get; set; }
        public string BUCommitmentRequestId { get; set; }
        public decimal TotalFixedAssetAmount { get; set; }
        public IList<BUTransferDetailModel> BUTransferDetails { get { return BUTransferDetails; } set {


                #region Colunms for grdDetailByInventoryItemView
                //if(value != null)
                //{
                //    foreach(var item in value)
                //    {
                //        item.TotalAmount = item.AmountOC;
                //    }
                //}
                this.bindingSourceDetail.DataSource = value ?? new List<BUTransferDetailModel>();
                grdViewAccountingParallel.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Tax",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thuế",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal,
                        IsSummnary = true,                        
                    },
                    new XtraColumn {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    },
                    new XtraColumn {
                        ColumnName = "TotalAmount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiền tính thuế",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    }

                };
                
                grdViewAccountingParallel = InitColumn(columnsCollection, grdViewAccountingParallel);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                grdViewAccountingParallel.ViewCaption = "";

                #endregion


            }
        }
        private void grdViewAccountingParallel_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Tax")
            {
                //var totalAmount = (decimal)grdViewAccountingParallel.GetRowCellValue(e.RowHandle, "Amount") - (decimal)(e.Value);
                //grdViewAccountingParallel.SetRowCellValue(e.RowHandle, "TotalAmount", totalAmount);
                if(mHReport == 0)
                {
                    GetListDataBUTransfer = new List<BUTransferDetailModel>();
                    for (int i = 0; i < grdViewAccountingParallel.DataRowCount; i++)
                    {
                        GetListDataBUTransfer.Add((BUTransferDetailModel)grdViewAccountingParallel.GetRow(i));
                    }
                }
                else if(mHReport == 1)
                {
                    GetListDataCAReceipt = new List<CAReceiptDetailModel>();
                    for (int i = 0; i < grdViewAccountingParallel.DataRowCount; i++)
                    {
                        GetListDataCAReceipt.Add((CAReceiptDetailModel)grdViewAccountingParallel.GetRow(i));
                    }
                }
                else if (mHReport == 2)
                {
                    GetListDataBADeposit = new List<BADepositDetailModel>();
                    for (int i = 0; i < grdViewAccountingParallel.DataRowCount; i++)
                    {
                        GetListDataBADeposit.Add((BADepositDetailModel)grdViewAccountingParallel.GetRow(i));
                    }
                }
            }
        }
        private GridView InitColumn(List<XtraColumn> columnsCollections, GridView grdView)
        {
            for(var i=0;i < grdView.Columns.Count; i++)
            {
                var column = grdView.Columns[i];
                var columnsCollection = columnsCollections.FirstOrDefault(c => c.ColumnName == column.FieldName);

                if (columnsCollection != null)
                {
                    grdView.Columns[i].Visible = true;
                    grdView.Columns[i].Caption = columnsCollection.ColumnCaption;
                    grdView.Columns[i].VisibleIndex = columnsCollection.ColumnPosition;
                    grdView.Columns[i].Width = columnsCollection.ColumnWith;
                    grdView.Columns[i].UnboundType = columnsCollection.ColumnType;
                    //column.Fixed = columnsCollection.FixedColumn;
                    grdView.Columns[i].OptionsColumn.AllowEdit = columnsCollection.AllowEdit;
                    // column.ToolTip = columnsCollection.ToolTip;
                    //   column.ColumnEdit = columnsCollection.RepositoryControl;
                    grdView.Columns[i].OptionsColumn.AllowSort = DefaultBoolean.False;
                    grdView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    grdView.Columns[i].DisplayFormat.FormatString = @"{0:n0}";
                }
                else
                {
                    grdView.Columns[i].Visible = false;
                }
               
            }
            return grdView;
        }
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
        public IList<BUTransferDetailParallelModel> BuTransferDetailParallel { get; set; }
        public IList<BUTransferDetailPurchaselModel> BUTransferDetailPurchases { get; set; }
        public IList<BUTransferDetailFixedAssetlModel> BUTransferDetailFixedAssets { get; set; }
        public string BUPlanWithdrawRefId { get; set; }
        public string OutwardRefNo { get; set; }
        public int? InvType { get; set; }
        public DateTime? InvDateOrWithdrawRefDate { get; set; }
        public string InvSeries { get; set; }
        public string InvNoOrWithdrawRefNo { get; set; }
        public string BankId { get; set; }
        public decimal TotalOutwardAmount { get; set; }
        public int? InvoiceForm { get; set; }
        public string InvoiceFormNumberId { get; set; }
        public string InvSeriesPrefix { get; set; }
        public string InvSeriesSuffix { get; set; }
        public string PayForm { get; set; }
        public string CompanyTaxcode { get; set; }
        public string AccountingObjectContactName { get; set; }
        public string ListNo { get; set; }
        public DateTime? ListDate { get; set; }
        public bool IsAttachList { get; set; }
        public string ListCommonNameInventory { get; set; }
        public decimal TotalReceiptAmount { get; set; }
        public List<CAReceiptDetailModel> CAReceiptDetails {
            get { return CAReceiptDetails; }
            set
            {


                #region Colunms for grdDetailByInventoryItemView
                //if(value != null)
                //{
                //    foreach(var item in value)
                //    {
                //        item.TotalAmount = item.AmountOC;
                //    }
                //}
                this.bindingSourceDetail.DataSource = value ?? new List<CAReceiptDetailModel>();
                grdViewAccountingParallel.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Tax",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thuế",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal,
                        IsSummnary = true,
                    },
                    new XtraColumn {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    },
                    new XtraColumn {
                        ColumnName = "TotalAmount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiền tính thuế",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    }

                };

                grdViewAccountingParallel = InitColumn(columnsCollection, grdViewAccountingParallel);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                grdViewAccountingParallel.ViewCaption = "";

                #endregion
            }
        }
        public List<CAReceiptDetailTaxModel> CAReceiptDetailTaxes { get; set; }
        public List<CAReceiptDetailParallelModel> CAReceiptDetailParallels { get; set; }
        public string Payer { get; set; }
        public DateTime? InvDate { get; set; }
        public string InvNo { get; set; }
        public bool Reconciled { get; set; }
        public string ComPanyTaxcode { get; set; }
        public IList<BADepositDetailModel> BADepositDetails
        {
            get { return BADepositDetails; }
            set
            {
                #region Colunms for grdDetailByInventoryItemView
                //if(value != null)
                //{
                //    foreach(var item in value)
                //    {
                //        item.TotalAmount = item.AmountOC;
                //    }
                //}
                foreach (var item in value)
                {
                    //item.AmountOC = string.Format("{0:n0}", item.AmountOC);
                }
                this.bindingSourceDetail.DataSource = value ?? new List<BADepositDetailModel>();
                grdViewAccountingParallel.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 1,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Tax",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Thuế",
                        ColumnPosition = 2,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal,
                        IsSummnary = true,
                    },
                    new XtraColumn {
                        ColumnName = "AmountOC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 3,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    },
                    new XtraColumn {
                        ColumnName = "TotalAmount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tiền tính thuế",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal,
                    }

                };

                grdViewAccountingParallel = InitColumn(columnsCollection, grdViewAccountingParallel);
                grdViewAccountingParallel.OptionsView.ShowFooter = false;
                grdViewAccountingParallel.ViewCaption = "";

                #endregion
            }
        }
        public IList<BADepositDetailFixedAssetModel> BADepositDetailFixedAssets { get; set; }
        public IList<BADepositDetailSaleModel> BADepositDetailSales { get; set; }
        public IList<BADepositDetailTaxModel> BADepositDetailTaxs { get; set; }
        public IList<BADepositDetailParallelModel> BADepositDetailParallels { get; set; }

        #endregion
        public int mHReport = 0;
        public FrmC301NS_Param()
        {
            InitializeComponent();
            _bUTransferPresenter = new BUTransferPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _projectsPresenter.Display();
            _bUTransferPresenter.Display(KeyValue);
        }
        public FrmC301NS_Param(string keyValue, int mH)
        {
            InitializeComponent();
            _bUTransferPresenter = new BUTransferPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _caReceiptPresenter = new CAReceiptPresenter(this);
            _bADepositPresenter = new BADepositPresenter(this);
            _projectsPresenter.Display();
            mHReport = mH;
            if (mH == 0)
            {
                _bUTransferPresenter.Display(keyValue);
            }
            else if(mH == 1)
            {
                _caReceiptPresenter.Display(keyValue, true, true);
            }
            else if (mH == 2)
            {
                _bADepositPresenter.Display(keyValue, true, false, false, true);
            }

        }
            #region Events

            private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Valid chỉ gõ number
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion

        private void grdAccountingParallel_Click(object sender, EventArgs e)
        {

        }
    }
}
