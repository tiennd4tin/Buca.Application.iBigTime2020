using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Voucher;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC2_02bNS : FrmXtraBaseParameter, IBanksView, IProjectsView, IAccountingObjectsView, IBudgetChaptersView, IBudgetItemsView
    {
        #region Variable
        private Enum.RefType _refType = Enum.RefType.BUPlanWithDrawCash;
        #endregion
        private readonly BanksPresenter _banksPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private static IModel Model { get; set; }

        public string RefId { get; set; }
        public FrmC2_02bNS(string refId, string target, string bank, Enum.RefType refType = Enum.RefType.BUPlanWithDrawCash)
        {
            InitializeComponent();
            Model = new Model();
            _refType = refType;
            _banksPresenter = new BanksPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            InitData();
            RefId = refId;
            LoadDataIntoGridDetail(refId);

            gridDetailView.OptionsView.ShowGroupPanel = false;
            gridDetailView.OptionsView.ShowIndicator = false;
            for (int i = 0; i < gridDetailView.RowCount; i++)
            {
              
                    var Amount = gridDetailView.GetRowCellValue(i, "Amount") == null ? 0 :
                        (decimal)gridDetailView.GetRowCellValue(i, "Amount");
                    var AmountTax = gridDetailView.GetRowCellValue(i, "AmountTax") == null ? 0 :
                        (decimal)gridDetailView.GetRowCellValue(i, "AmountTax");
                    gridDetailView.SetRowCellValue(i, "AmountNet", Amount - AmountTax);
             
            }
          
                cboBankAccount.EditValue = bank;
                cboTargetProgramId.EditValue = target;
           
          
        }

        private void InitData()
        {
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.Display();
            _accountingObjectsPresenter.Display();
            _budgetChaptersPresenter.Display();
            _budgetItemsPresenter.DisplayActive(true);
        }

        public string ProjectCode
        {
            get { return Convert.ToString(cboTargetProgramId.EditValue); }
        }

        public string ProjectName
        {
            get { return Convert.ToString(cboTargetProgramId.GetColumnValue(nameof(ProjectModel.ProjectName))); }
        }

        public string BankAccount
        {
            get { return Convert.ToString(cboBankAccount.EditValue); }
        }

        public string BankName
        {
            get { return Convert.ToString(cboBankAccount.GetColumnValue(nameof(BankModel.BankName))); }
        }

        public string AccountingObjectId
        {
            get { return cboAccountingObject.EditValue == null ? null : cboAccountingObject.EditValue.ToString(); }
        }

        public string CKC_HDK
        {
            get { return txtCKC_HDK.EditValue == null ? "" : txtCKC_HDK.EditValue.ToString(); }
        }

        public string HDTH
        {
            get { return txtHDTH.EditValue == null ? "" : txtHDTH.EditValue.ToString(); }
        }

        public string TKNO1
        {
            get { return txtNo1.EditValue == null ? "" : txtNo1.EditValue.ToString(); }
        }
        public string TKNO2
        {
            get { return txtNo2.EditValue == null ? "" : txtNo2.EditValue.ToString(); }
        }
        public string TKNO3
        {
            get { return txtNo3.EditValue == null ? "" : txtNo3.EditValue.ToString(); }
        }
        public string TKCO1
        {
            get { return txtCo1.EditValue == null ? "" : txtCo1.EditValue.ToString(); }
        }
        public string TKCO2
        {
            get { return txtCo2.EditValue == null ? "" : txtCo2.EditValue.ToString(); }
        }
        public string TKCO3
        {
            get { return txtCo3.EditValue == null ? "" : txtCo3.EditValue.ToString(); }
        }

        public string DBHC
        {
            get { return txtDBHC.EditValue == null ? "" : txtDBHC.EditValue.ToString(); }
        }

        public int fontsize
        {
            get { return (int)nbrFontsize.Value; }
        }

        public int numberonpage
        {
            get { return (int)nbrNumberLineOnPage.Value; }
        }

        public int numberonlastpage
        {
            get { return (int)nbrNumberLineOnLastPage.Value; }
        }

        public bool LoopSubtilte
        {
            get { return chkLoopSubtilte.Checked; }
        }

        public int RealytoPay
        {
            get
            {
                int result = 0;
                if (chkRealytoPay.Checked)
                    result = 1;
                else
                {
                    if (chkNotRealyToPay.Checked)
                        result = 2;

                }
                return result;


            }
        }

        public bool IsGroupDetail
        {
            get { return chkIsGroupDetail.Checked; }
        }

        public bool IsShowDuplicate
        {
            get { return ChkIsShowDuplicate.Checked; }
        }

        public bool IsCash
        {
            get { return chkCash.Checked; }
        }

        public int content
        {
            get { return cboContent.SelectedIndex; }
        }

        public string TaxDebitBankAccount1_NoChangeSize
        {
            get { return txtTaxDebitBankAccount1_NoChangeSize.EditValue == null ? "" : txtTaxDebitBankAccount1_NoChangeSize.EditValue.ToString(); }
        }

        public string TaxCreditBankAccount1_NoChangeSize
        {
            get
            {
                return txtTaxCreditBankAccount1_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxCreditBankAccount1_NoChangeSize.EditValue.ToString();
            }
        }

        public string TaxDebitBankAccount2_NoChangeSize
        {
            get
            {
                return txtTaxDebitBankAccount2_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxDebitBankAccount2_NoChangeSize.EditValue.ToString();
            }
        }

        public string TaxCreditBankAccount2_NoChangeSize
        {
            get
            {
                return txtTaxCreditBankAccount2_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxCreditBankAccount2_NoChangeSize.EditValue.ToString();
            }
        }

        public string TaxDebitBankAccount3_NoChangeSize
        {
            get
            {
                return txtTaxDebitBankAccount3_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxDebitBankAccount3_NoChangeSize.EditValue.ToString();
            }
        }

        public string TaxCreditBankAccount3_NoChangeSize
        {
            get
            {
                return txtTaxCreditBankAccount3_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxCreditBankAccount3_NoChangeSize.EditValue.ToString();
            }
        }
        public string TaxOrganizationCode_NoChangeSize
        {
            get
            {
                return txtTaxOrganizationCode_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxOrganizationCode_NoChangeSize.EditValue.ToString();
            }
        }

        public string TaxLocationCode_NoChangeSize
        {
            get
            {
                return txtTaxLocationCode_NoChangeSize.EditValue == null
                    ? ""
                    : txtTaxLocationCode_NoChangeSize.EditValue.ToString();
            }
        }

        public string taxAccountingObjectName
        {
            get
            {
                return string.IsNullOrEmpty(cboAccountingObject.EditValue.ToString()) || cboAccountingObject.EditValue.ToString()== "<Null>" ? "" : cboAccountingObject.EditValue.ToString();
            }
        }
        public string taxBudgetChapterCode
        {
            get { return txtBudgetChapterCode.EditValue == null ? "" : txtBudgetChapterCode.EditValue.ToString(); }
        }

        public string taxBudgetSubItemCose
        {
            get { return txtBudgetSubItemCose.EditValue == null ? "" : txtBudgetSubItemCose.EditValue.ToString(); }
        }

        public string taxTaxPeriod
        {
            get { return txtTaxPeriod.EditValue == null ? "" : txtTaxPeriod.EditValue.ToString(); }
        }

        public string taxOrganizationManageFee
        {
            get { return txtOrganizationManageFee.EditValue == null ? "" : txtOrganizationManageFee.EditValue.ToString(); }
        }

        public string taxOrganizationFeeCode
        {
            get { return txtOrganizationFeeCode.EditValue == null ? "" : txtOrganizationFeeCode.EditValue.ToString(); }
        }

        public string taxTreasuryManageFee
        {
            get { return txtTreasuryManageFee.EditValue == null ? "" : txtTreasuryManageFee.EditValue.ToString(); }
        }

        public string CompanyTaxCode
        {
            get { return txtCompanyTaxCode.EditValue == null ? "" : txtCompanyTaxCode.EditValue.ToString(); }
        }
        #region IView
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

        public IList<BankModel> Banks
        {
            set
            {
                try
                {

                    cboBankAccount.Properties.DataSource = value;
                    cboBankAccount.Properties.ForceInitialize();
                    cboBankAccount.Properties.PopulateColumns();
                    var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "BankAccount",
                        ColumnCaption = "Số TK",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankName",
                        ColumnCaption = "Tên ngân hàng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsOpenInBank", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };
                    foreach (var column in columnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            if (cboBankAccount.Properties.Columns[column.ColumnName] != null)
                            {
                                cboBankAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                cboBankAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                            }
                        }
                        else
                        {
                            cboBankAccount.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    cboBankAccount.Properties.DisplayMember = "BankAccount";
                    cboBankAccount.Properties.ValueMember = "BankAccount";


                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                cboAccountingObject.Properties.DataSource = value;
                cboAccountingObject.Properties.ForceInitialize();
                cboAccountingObject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã người lĩnh",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên người lĩnh",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                       new XtraColumn {ColumnName = "AccountingObjectBanks", ColumnVisible = false},
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
                        cboAccountingObject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountingObject.Properties.SortColumnIndex = column.ColumnPosition;
                        cboAccountingObject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                    {
                        cboAccountingObject.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }
                cboAccountingObject.Properties.DisplayMember = "AccountingObjectCode";
                cboAccountingObject.Properties.ValueMember = "AccountingObjectName";

            }
        }
        public IList<BudgetChapterModel> BudgetChapters
        {
            get;
            set;
            //set
            //{
            //    lookUpBudgetChapterId.Properties.DataSource = value;
            //    lookUpBudgetChapterId.Properties.PopulateColumns();
            //    var treeColumnsCollection = new List<XtraColumn> {
            //                                    new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
            //                                    new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnPosition = 1, ColumnVisible = true },
            //                                    new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnPosition = 1, ColumnVisible = true },
            //                                    new XtraColumn { ColumnName = "IsActive",ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },

            //                                };
            //    foreach (var column in treeColumnsCollection)
            //    {
            //        if (column.ColumnVisible)
            //        {
            //            lookUpBudgetChapterId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //            lookUpBudgetChapterId.Properties.SortColumnIndex = column.ColumnPosition;
            //            lookUpBudgetChapterId.Properties.PopupWidth = 500;
            //            lookUpBudgetChapterId.Properties.Columns[2].Width = 300;
            //            lookUpBudgetChapterId.Properties.Columns[1].Width = 100;
            //            lookUpBudgetChapterId.Properties.Columns[3].Width = 100;
            //        }
            //        else
            //            lookUpBudgetChapterId.Properties.Columns[column.ColumnName].Visible = false;
            //    }
            //    lookUpBudgetChapterId.Properties.ValueMember = "BudgetChapterId";
            //    lookUpBudgetChapterId.Properties.DisplayMember = "BudgetChapterCode";
            //}
        }

        #endregion

        private void chkNotRealyToPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotRealyToPay.Checked)
                chkRealytoPay.Checked = false;
            chkRealytoPay.Visible = true;
        }

        private void chkRealytoPay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRealytoPay.Checked)
                chkNotRealyToPay.Checked = false;
            chkNotRealyToPay.Visible = true;
        }

        private void cboBankAccount_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboBankAccount.EditValue != null)
                //txtbankcode.EditValue = cboBankAccount.GetColumnValue("BankAccount");
        }

        private void cboTargetProgramId_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboTargetProgramId.EditValue != null)
                //txtprojectcode.EditValue = cboTargetProgramId.GetColumnValue("ProjectCode");
        }

        private void cboAccountingObject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboAccountingObject.EditValue != null)
            {
                txtCompanyTaxCode.EditValue = cboAccountingObject.GetColumnValue("CompanyTaxCode");
                txtTreasuryManageFee.EditValue = cboAccountingObject.GetColumnValue("TreasuryManageFee");
                txtOrganizationManageFee.EditValue = cboAccountingObject.GetColumnValue("OrganizationManageFee");
                txtOrganizationFeeCode.EditValue = cboAccountingObject.GetColumnValue("OrganizationFeeCode");
            }
        }

        private void lookUpBudgetChapterId_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookUpBudgetChapterId.EditValue != null)
            //    txtBudgetChapterCode.EditValue = lookUpBudgetChapterId.GetColumnValue("BudgetChapterCode");
        }
        public IList<C2_02a_NSDetailModel> C2_02a_NSDetailModels
        {
            get
            {
                var c402CkbModels = new List<C2_02a_NSDetailModel>();
                if (gridDetailView.RowCount > 0)
                {
                    for (int i = 0; i < gridDetailView.RowCount; i++)
                    {
                        var rowVoucher = (C2_02a_NSDetailModel)gridDetailView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            var item = new C2_02a_NSDetailModel
                            {
                                Memo = rowVoucher.Memo,
                                Amount = rowVoucher.Amount,
                                BudgetSubItemCode = rowVoucher.BudgetSubItemCode,
                                BudgetChapterCode = rowVoucher.BudgetChapterCode,
                                BudgetSubKindItemCode = rowVoucher.BudgetSubKindItemCode,
                                BudgetSourceCode = rowVoucher.BudgetSourceCode,
                                AmountTax = rowVoucher.AmountTax,
                                AmountNet = rowVoucher.AmountNet,
                                CashWithDrawType = rowVoucher.CashWithDrawType
                            };
                            c402CkbModels.Add(item);
                        }
                    }
                }

                return c402CkbModels;
            }
        }

        public IList<BudgetItemModel> BudgetItems { get; set; }

        private void LoadDataIntoGridDetail(string refId)
        {
            var reports = Model.ReportBUPlanWithDraw(refId, Convert.ToInt16(IsGroupDetail), 1, 1, _refType).First();

            bindingSource.DataSource = reports.Details;
            gridDetail.ForceInitialize();
            gridDetailView.PopulateColumns(reports);

            var columnsCollection = new List<XtraColumn>
                {
                new XtraColumn
                {
                    ColumnName="BudgetSourceCode",
                    ColumnVisible = false,
                } ,
                new XtraColumn
                    {
                        ColumnName = "Memo",
                        ColumnVisible = true,
                        ColumnWith = 220,
                        ColumnCaption = "Nội dung thanh toán",
                        ColumnPosition = 1,
                        AllowEdit = true,
                    },
                      new XtraColumn
                    {
                        ColumnName = "BudgetSubItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Tiểu mục",
                        ColumnPosition = 2,
                        AllowEdit = false,
                    },
                      new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Chương",
                        ColumnPosition = 3,
                        AllowEdit = false,
                    },
                    new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "BudgetSubKindItemCode",
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnCaption = "Khoản",
                        ColumnPosition = 4,
                        AllowEdit = false,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Amount",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Tổng số tiền",
                        ColumnPosition = 5,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountTax",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnCaption = "Nộp thuế",
                        ColumnPosition = 6,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountNet",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Thanh toán đv hưởng",
                        ColumnPosition = 7,
                        IsSummnary = true,
                        AllowEdit = true,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "CashWithDrawType",
                        ColumnVisible = false,
                        ColumnWith = 120,
                        ColumnCaption = "",
                        ColumnPosition = 8
                    },
                   


                };
            gridDetailView = InitGridLayout(columnsCollection, gridDetailView);
            SetNumericFormatControl(gridDetailView, true);
            //gridDetailView.OptionsView.ShowFooter = false;

        }
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
        protected virtual void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode)
                return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible)
                    continue;
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

        private void gridDetailView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Amount" || e.Column.FieldName == "AmountTax")
            {
                var Amount = gridDetailView.GetRowCellValue(e.RowHandle, "Amount") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "Amount");
                var AmountTax = gridDetailView.GetRowCellValue(e.RowHandle, "AmountTax") == null ? 0 :
                     (decimal)gridDetailView.GetRowCellValue(e.RowHandle, "AmountTax");
                gridDetailView.SetRowCellValue(e.RowHandle, "AmountNet", Amount - AmountTax);
            }
        }


        private void chkIsGroupDetail_CheckedChanged_1(object sender, EventArgs e)
        {
            LoadDataIntoGridDetail(RefId);

            for (int i = 0; i < gridDetailView.RowCount; i++)
            {

                var Amount = gridDetailView.GetRowCellValue(i, "Amount") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(i, "Amount");
                var AmountTax = gridDetailView.GetRowCellValue(i, "AmountTax") == null ? 0 :
                    (decimal)gridDetailView.GetRowCellValue(i, "AmountTax");
                gridDetailView.SetRowCellValue(i, "AmountNet", Amount - AmountTax);

            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
    }
}
