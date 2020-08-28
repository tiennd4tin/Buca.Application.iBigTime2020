using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmC2_02aNS : FrmXtraBaseParameter, IBanksView, IProjectsView
    {
        private readonly BanksPresenter _banksPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private GridView _gridLookUpEditBankView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;
        private string _target;
        public FrmC2_02aNS(string target, string bank)
        {
            InitializeComponent();

            _banksPresenter = new BanksPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            InitData();

            cboBankAccount.EditValue = bank;
            cboTargetProgramId.EditValue = target;
        }

        private void InitData()
        {
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.Display();
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
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsOpenInBank", ColumnVisible = false}
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
                    cboBankAccount.EditValue = _target;
                    cboBankAccount.Properties.DisplayMember = "BankAccount";
                    cboBankAccount.Properties.ValueMember = "BankAccount";


                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            //    txtbankcode.EditValue = cboBankAccount.GetColumnValue("BankAccount");
        }

        private void cboTargetProgramId_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboTargetProgramId.EditValue != null)
            //    txtprojectcode.EditValue = cboTargetProgramId.GetColumnValue("ProjectCode");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
    }
}
