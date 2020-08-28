/***********************************************************************
 * <copyright file="FrmC402CKB.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Tuesday, December 19, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmC402CKB : FrmXtraBaseParameter
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        private static IModel Model { get; set; }

        public bool CheckBankTransfer
        {
            get
            {
                if (ck_BankTransfer.Checked) return true;
                return false;
            }
        }
        public bool CheckCashInBank
        {
            get
            {
                if (ck_CashInBank.Checked) return true;
                return false;
            }
        }
        public bool CheckCashInTreasury
        {
            get
            {
                if (ck_CashInTreasury.Checked) return true;
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC402CKB"/> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public FrmC402CKB(string refId, string procedure)
        {
            InitializeComponent();
            Model = new Model();
            LoadDataIntoGridDetail(refId, procedure);
        }

        /// <summary>
        /// Handles the CellValueChanged event of the gridDetailView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void gridDetailView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Tax")
                {
                    var tax = gridDetailView.GetRowCellValue(e.RowHandle, "Tax") == null ? 0 : (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "Tax");
                    var amount = gridDetailView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 : (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "Amount");
                    var payment = amount - tax;
                    gridDetailView.SetRowCellValue(e.RowHandle, "Payment", payment);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is multi view.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is multi view; otherwise, <c>false</c>.
        /// </value>
        public bool IsMultiView { get { return chkView.Checked; } }

        /// <summary>
        /// Gets the tax payers.
        /// </summary>
        /// <value>
        /// The tax payers.
        /// </value>
        public string TaxPayers { get { return txtTaxPayers.Text; } }

        /// <summary>
        /// Gets the tax code.
        /// </summary>
        /// <value>
        /// The tax code.
        /// </value>
        public string TaxCode { get { return txtTaxCode.Text; } }

        /// <summary>
        /// Gets the budget sub item.
        /// </summary>
        /// <value>
        /// The budget sub item.
        /// </value>
        public string BudgetSubItem { get { return txtstrBudgetSubItem.Text; } }

        /// <summary>
        /// Gets the chapter code.
        /// </summary>
        /// <value>
        /// The chapter code.
        /// </value>
        public string ChapterCode { get { return txtChapterCode.Text; } }

        /// <summary>
        /// Gets the format number declaration.
        /// </summary>
        /// <value>
        /// The format number declaration.
        /// </value>
        public string FormatNumberDeclaration { get { return txtFormatNumberDeclaration.Text; } }

        /// <summary>
        /// Gets the format number isssua tax.
        /// </summary>
        /// <value>
        /// The format number isssua tax.
        /// </value>
        public string FormatNumberIsssuaTax { get { return txtFormatNumberIsssuaTax.Text; } }

        /// <summary>
        /// Gets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public string Organization { get { return txtOrganization.Text; } }

        /// <summary>
        /// Gets the account bank.
        /// </summary>
        /// <value>
        /// The account bank.
        /// </value>
        public string AccountBank { get { return txtAccountBank.Text; } }
        public string DonorsCode { get { return txtDonorsCode.Text; } }

        /// <summary>
        /// Gets the organization code.
        /// </summary>
        /// <value>
        /// The organization code.
        /// </value>
        public string OrganizationCode { get { return txtOrganizationCode.Text; } }

        public string TaxPayDebitAccount1 { get { return txtTaxPayDebitAccount1.Text; } }

        public string TaxPayCreditAccount1 { get { return txtTaxPayCreditAccount1.Text; } }

        public string TaxPayDebitAccount2 { get { return txtTaxPayDebitAccount2.Text; } }

        public string TaxPayCreditAccount2 { get { return txtTaxPayCreditAccount2.Text; } }

        public string TaxPayOrganizationCode { get { return txtTaxPayOrganizationCode.Text; } }

        public string TaxPayDBHCCode { get { return txtTaxPayDBHCCode.Text; } }

        public string UnitEnjoyPayDebitAccount { get { return txtUnitEnjoyPayDebitAccount.Text; } }

        public string UnitEnjoyPayCreditAccount { get { return txtUnitEnjoyPayCreditAccount.Text; } }

        /// <summary>
        /// Gets the C402 CKB models.
        /// </summary>
        /// <value>
        /// The C402 CKB models.
        /// </value>
        public IList<C402CKBModel> C402CkbModels
        {
            get
            {
                var c402CkbModels = new List<C402CKBModel>();
                if (gridDetailView.RowCount > 0 || bindingSource.Count > 0)
                {
                    for (int i = 0; i < (gridDetailView.RowCount == 0 ? bindingSource.Count : gridDetailView.RowCount); i++)
                    {
                        var rowVoucher = gridDetailView.RowCount == 0 ? (C402CKBModel)bindingSource[i] : (C402CKBModel)gridDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new C402CKBModel
                            {
                                Description = rowVoucher.Description,
                                Amount = rowVoucher.Amount,
                                RefId = rowVoucher.RefId,
                                RefNo = rowVoucher.RefNo,
                                EditVersion = rowVoucher.EditVersion,
                                AccountingObjectAddress = rowVoucher.AccountingObjectAddress,
                                Tax = rowVoucher.Tax,
                                DescriptionReplaced = rowVoucher.DescriptionReplaced,
                                BankAccount = rowVoucher.BankAccount,
                                ReceiptObjectName = rowVoucher.ReceiptObjectName,
                                ReceiptCode = rowVoucher.ReceiptCode,
                                AccountInBank = rowVoucher.AccountInBank,
                                AccountingObjectBankAccount = rowVoucher.AccountingObjectBankAccount,
                                ReceiptTargetProgram = rowVoucher.ReceiptTargetProgram,
                                RefDate = rowVoucher.RefDate,
                                Payment = rowVoucher.Payment,
                                ReceiptAccountInBank = rowVoucher.ReceiptAccountInBank,
                                CurencyCode = rowVoucher.CurencyCode,
                                RefType = rowVoucher.RefType,
                                IsOpenInBank = rowVoucher.IsOpenInBank,
                                BudgetCode = rowVoucher.BudgetCode
                            };
                            c402CkbModels.Add(item);
                        }
                    }
                }
                if (!IsMultiView && c402CkbModels.Any() && c402CkbModels.Count > 1)
                {
                    var item = new C402CKBModel
                    {
                        Description = c402CkbModels.First().DescriptionReplaced,
                        Amount = c402CkbModels.Sum(x => x.Amount),
                        RefId = c402CkbModels.First().RefId,
                        RefNo = c402CkbModels.First().RefNo,
                        EditVersion = c402CkbModels.First().EditVersion,
                        AccountingObjectAddress = c402CkbModels.First().AccountingObjectAddress,
                        Tax = c402CkbModels.Sum(x => x.Tax),
                        DescriptionReplaced = c402CkbModels.First().DescriptionReplaced,
                        BankAccount = c402CkbModels.First().BankAccount,
                        ReceiptObjectName = c402CkbModels.First().ReceiptObjectName,
                        ReceiptCode = c402CkbModels.First().ReceiptCode,
                        AccountInBank = c402CkbModels.First().AccountInBank,
                        AccountingObjectBankAccount = c402CkbModels.First().AccountingObjectBankAccount,
                        ReceiptTargetProgram = c402CkbModels.First().ReceiptTargetProgram,
                        RefDate = c402CkbModels.First().RefDate,
                        Payment = c402CkbModels.Sum(x => x.Payment),
                        ReceiptAccountInBank = c402CkbModels.First().ReceiptAccountInBank,
                        CurencyCode = c402CkbModels.First().CurencyCode,
                        IsOpenInBank = c402CkbModels.First().IsOpenInBank,
                        BudgetCode = c402CkbModels.First().BudgetCode,
                        ActivityGrade = c402CkbModels.First().ActivityGrade,
                        ActivityCode = c402CkbModels.First().ActivityCode,
                    };
                    c402CkbModels = new List<C402CKBModel> { item };
                }
                return c402CkbModels;
            }
        }

        /// <summary>
        /// Gets the C402 CKB models.
        /// </summary>
        /// <value>
        /// The C402 CKB models.
        /// </value>
        public IList<C402CKBModel> C402CkbModelDetails
        {
            get
            {
                var c402CkbModels = new List<C402CKBModel>();
                if (gridDetailView.RowCount > 0 || bindingSource.Count > 0)
                {
                    for (int i = 0; i < (gridDetailView.RowCount == 0 ? bindingSource.Count : gridDetailView.RowCount); i++)
                    {
                        var rowVoucher = gridDetailView.RowCount == 0 ? (C402CKBModel)bindingSource[i] : (C402CKBModel)gridDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new C402CKBModel
                            {
                                Description = rowVoucher.Description,
                                Amount = rowVoucher.Amount,
                                RefId = rowVoucher.RefId,
                                RefNo = rowVoucher.RefNo,
                                EditVersion = rowVoucher.EditVersion,
                                AccountingObjectAddress = rowVoucher.AccountingObjectAddress,
                                Tax = rowVoucher.Tax,
                                DescriptionReplaced = rowVoucher.DescriptionReplaced,
                                BankAccount = rowVoucher.BankAccount,
                                ReceiptObjectName = rowVoucher.ReceiptObjectName,
                                ReceiptCode = rowVoucher.ReceiptCode,
                                AccountInBank = rowVoucher.AccountInBank,
                                AccountingObjectBankAccount = rowVoucher.AccountingObjectBankAccount,
                                ReceiptTargetProgram = rowVoucher.ReceiptTargetProgram,
                                RefDate = rowVoucher.RefDate,
                                Payment = rowVoucher.Payment,
                                ReceiptAccountInBank = rowVoucher.ReceiptAccountInBank,
                                CurencyCode = rowVoucher.CurencyCode,
                                RefType = rowVoucher.RefType,
                                IsOpenInBank = rowVoucher.IsOpenInBank,
                                BudgetCode = rowVoucher.BudgetCode,
                                ActivityCode = rowVoucher.ActivityCode,
                                ActivityGrade = rowVoucher.ActivityGrade,
                                ReceiveId = rowVoucher.ReceiveId,
                                ReceiveIssueDate = rowVoucher.ReceiveIssueDate,
                                ReceiveIssueLocation = rowVoucher.ReceiveIssueLocation,
                                ReceiveName = rowVoucher.ReceiveName,
                            };
                            c402CkbModels.Add(item);
                        }
                    }
                }
                if (!IsMultiView && c402CkbModels.Any() && c402CkbModels.Count > 1)
                {
                    string activeCode = "";
                    int countResult = 1;
                    var resultActiveCodeList = c402CkbModels.Select(s => s.ActivityCode).Distinct().ToList();
                    resultActiveCodeList.ForEach(itemResult =>
                    {
                        activeCode = activeCode + itemResult;
                        if (countResult < resultActiveCodeList.Count())
                        {
                            activeCode = activeCode + ", ";
                        }
                        countResult++;
                    });
                    var item = new C402CKBModel
                    {
                        Description = c402CkbModels.First().DescriptionReplaced,
                        Amount = c402CkbModels.Sum(x => x.Amount),
                        RefId = c402CkbModels.First().RefId,
                        RefNo = c402CkbModels.First().RefNo,
                        EditVersion = c402CkbModels.First().EditVersion,
                        AccountingObjectAddress = c402CkbModels.First().AccountingObjectAddress,
                        Tax = c402CkbModels.Sum(x => x.Tax),
                        DescriptionReplaced = c402CkbModels.First().DescriptionReplaced,
                        BankAccount = c402CkbModels.First().BankAccount,
                        ReceiptObjectName = c402CkbModels.First().ReceiptObjectName,
                        ReceiptCode = c402CkbModels.First().ReceiptCode,
                        AccountInBank = c402CkbModels.First().AccountInBank,
                        AccountingObjectBankAccount = c402CkbModels.First().AccountingObjectBankAccount,
                        ReceiptTargetProgram = c402CkbModels.First().ReceiptTargetProgram,
                        RefDate = c402CkbModels.First().RefDate,
                        Payment = c402CkbModels.Sum(x => x.Payment),
                        ReceiptAccountInBank = c402CkbModels.First().ReceiptAccountInBank,
                        CurencyCode = c402CkbModels.First().CurencyCode,
                        IsOpenInBank = c402CkbModels.First().IsOpenInBank,
                        BudgetCode = c402CkbModels.First().BudgetCode,
                        ActivityGrade = c402CkbModels.First().ActivityGrade,
                        ActivityCode = activeCode, //c402CkbModels.First().ActivityCode,
                        ReceiveId = c402CkbModels.First().ReceiveId,
                        ReceiveIssueDate = c402CkbModels.First().ReceiveIssueDate,
                        ReceiveIssueLocation = c402CkbModels.First().ReceiveIssueLocation,
                        ReceiveName = c402CkbModels.First().ReceiveName,
                    };
                    c402CkbModels = new List<C402CKBModel> { item };
                }
                return c402CkbModels;
            }
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        private void LoadDataIntoGridDetail(string refId, string procedure)
        {
            var storeProcedure = procedure;// "uspReport_BAV_Withdraw_TT08_C402";
            var reports = Model.ReportC402CKB(storeProcedure, refId);
            bindingSource.DataSource = reports;
            gridDetailView.PopulateColumns(reports);
            var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Nội dung thanh toán",
                        ColumnPosition = 1,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityCode",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Mã ngân sách",
                        ColumnPosition = 2,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "ActivityGrade",
                        ColumnVisible = true,
                        ColumnWith = 200,
                        ColumnCaption = "Niên độ NS",
                        ColumnPosition = 3,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tổng số tiền",
                        ColumnPosition = 4,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn {ColumnName = "Tax", ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nộp thuế",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal

                    },
                    new XtraColumn {ColumnName = "Payment", ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnCaption = "TT cho ĐV hưởng",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = false,
                        ColumnType = UnboundColumnType.Decimal

                    },
                         new XtraColumn{ ColumnName = "CashWithDrawTypeID",ColumnVisible = false },
                          new XtraColumn{ ColumnName = "BudgetChapterCode",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "ProjectName",ColumnVisible = false },
                          new XtraColumn{ ColumnName = "Investment",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "ProjectBankName",ColumnVisible = false },
                          new XtraColumn{ ColumnName = "ProjectBankAccount",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "OrgRefNo",ColumnVisible = false },
                          new XtraColumn{ ColumnName = "BudgetSubKindItemCode",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "ReceiveName",ColumnVisible = false },
                          new XtraColumn{ ColumnName = "ReceiveId",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "ReceiveIssueLocation",ColumnVisible = false },
                           new XtraColumn{ ColumnName = "ReceiveIssueDate",ColumnVisible = false },

                    new XtraColumn{ ColumnName = "AccountInBank",ColumnVisible = false },
                    new XtraColumn{ ColumnName = "BankAccount",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "ReceiptObjectName", ColumnVisible = false},
                    new XtraColumn{ ColumnName = "ReceiptCode", ColumnVisible = false},
                    new XtraColumn{ ColumnName = "AccountingObjectAddress",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "AccountingObjectBankAccount",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "ReceiptTargetProgram",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "ReceiptAccountInBank",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "RefId",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "RefNo",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "RefDate",ColumnVisible = false},
                    new XtraColumn{ ColumnName = "EditVersion",ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                    new XtraColumn{ColumnName = "DescriptionReplaced",ColumnVisible = false},
                    new XtraColumn{ColumnName = "CurencyCode",ColumnVisible = false},
                    new XtraColumn{ColumnName = "RefType",ColumnVisible = false},
                    new XtraColumn{ColumnName = "IsOpenInBank",ColumnVisible = false},
                    new XtraColumn{ColumnName = "BudgetCode",ColumnVisible = false},

                };
            gridDetailView = InitGridLayout(columnsCollection, gridDetailView);
            SetNumericFormatControl(gridDetailView, true);
            gridDetailView.OptionsView.ShowFooter = false;
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
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
            }
            return grdView;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }

        private void FrmC402CKB_Load(object sender, EventArgs e)
        {

        }
        private void ck_BankTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_BankTransfer.Checked)
            {
                ck_CashInBank.Checked = false;
                ck_CashInTreasury.Checked = false;
            }
            else
            {
                if (!ck_CashInBank.Checked && !ck_CashInTreasury.Checked)
                    ck_BankTransfer.Checked = true;
            }
        }

        private void ck_CashInTreasury_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_CashInTreasury.Checked)
            {
                ck_CashInBank.Checked = false;
                ck_BankTransfer.Checked = false;
            }
            else
            {
                if (!ck_CashInBank.Checked && !ck_BankTransfer.Checked)
                    ck_CashInTreasury.Checked = true;
            }
        }


        private void ck_CashInBank_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_CashInBank.Checked)
            {
                ck_BankTransfer.Checked = false;
                ck_CashInTreasury.Checked = false;
            }
            else
            {
                if (!ck_CashInTreasury.Checked && !ck_BankTransfer.Checked)
                    ck_CashInBank.Checked = true;
            }
        }
    }
}
