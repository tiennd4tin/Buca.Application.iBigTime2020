/***********************************************************************
 * <copyright file="FrmCash05.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Thursday, November 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateThursday, November 30, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmCash05.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBanksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    public partial class FrmCash05 : FrmXtraBaseParameter, IBanksView, IProjectsView
    {
        #region Presenter
        /// <summary>
        /// The banks presenter
        /// </summary>
        BanksPresenter _banksPresenter;
        /// <summary>
        /// The projects presenter
        /// </summary>
        ProjectsPresenter _projectsPresenter;
        #endregion

        #region Variable
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets the parameter from date.
        /// </summary>
        /// <value>The parameter from date.</value>
        public string ParamFromDate
        {
            get { return dateTimeRangeV1.FromDate.ToString("MM/dd/yyyy"); }
        }
        /// <summary>
        /// Gets the parameter to date.
        /// </summary>
        /// <value>The parameter to date.</value>
        public string ParamToDate
        {
            get { return dateTimeRangeV1.ToDate.ToString("MM/dd/yyyy"); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary project.
        /// </summary>
        /// <value><c>true</c> if this instance is summary project; otherwise, <c>false</c>.</value>
        public bool IsSummaryProject
        {
            get
            {
                if (cboProject.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }

        }
        /// <summary>
        /// Gets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectID
        {
            get
            {
                if (cboProject.EditValue.ToString() == "<<Tất cả>>" || cboProject.EditValue.ToString() == "<<Tổng hợp>>")
                    return null;
                else
                    return cboProject.EditValue.ToString();
            }
        }
        /// <summary>
        /// Gets the bank account.
        /// </summary>
        /// <value>The bank account.</value>
        public string BankAccount
        {
            get
            {
                if (cboBank.EditValue.ToString() == "<<Tất cả>>")
                    return null;
                else
                    return cboBank.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the openning balance112.
        /// </summary>
        /// <value>The openning balance112.</value>
        public decimal OpenningBalance112
        {
            get { return calBeginningBalance.EditValue == null ? 0 : (decimal)calBeginningBalance.EditValue; }
        }
        /// <summary>
        /// Gets or sets the movement debit112.
        /// </summary>
        /// <value>The movement debit112.</value>
        public decimal MovementDebit112
        {
            get { return calIncurredIncrease.EditValue == null ? 0 : (decimal)calIncurredIncrease.EditValue; }
        }
        /// <summary>
        /// Gets or sets the movement credit112.
        /// </summary>
        /// <value>The movement credit112.</value>
        public decimal MovementCredit112
        {
            get { return calIncurredReduction.EditValue == null ? 0 :(decimal)calIncurredReduction.EditValue; }
        }
        /// <summary>
        /// Gets or sets the closing balance112.
        /// </summary>
        /// <value>The closing balance112.</value>
        public decimal ClosingBalance112
        {
            get { return calClosingBalance.EditValue == null ? 0 :(decimal)calClosingBalance.EditValue; }
        }

        public bool IsRenderKBNN
        {
            get
            {
                if (checkDisplayValue.Checked == true)
                    return true;
                else
                    return false;
            }
        }
        public int selectReport
        {
            get { return cboSelectDesignReport.SelectedIndex; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCash05"/> class.
        /// </summary>
        public FrmCash05()
        {
            InitializeComponent();
            _banksPresenter = new BanksPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }
        
        #region IView
        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>The banks.</value>
        public IList<BankModel> Banks
        {
            set
            {
                var result = new List<BankModel>
                {
                    new BankModel {BankAccount = "<<Tất cả>>", BankName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBank.Properties.DataSource = result;
                cboBank.Properties.ForceInitialize();
                cboBank.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BankName",
                    ColumnCaption = "Tên NH,KB",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (cboBank.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            cboBank.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboBank.Properties.SortColumnIndex = column.ColumnPosition;
                        }
                        else
                            cboBank.Properties.Columns[column.ColumnName].Visible = false;
                    }

                }
                cboBank.Properties.DisplayMember = "BankAccount";
                cboBank.Properties.ValueMember = "BankAccount";
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
                var result = new List<ProjectModel>
                {
                    new ProjectModel {ProjectId = "<<Tổng hợp>>", ProjectCode = "<<Tổng hợp>>", ProjectName = "<<Tổng hợp>>"},
                    new ProjectModel {ProjectId = "<<Tất cả>>", ProjectCode = "<<Tất cả>>", ProjectName = "<<Tất cả>>"},
                    new ProjectModel {ProjectId = "<< Không chọn >>", ProjectCode = "<< Không chọn >>", ProjectName = "<< Không chọn >>"},
                };
                result.AddRange(value);
                cboProject.Properties.DataSource = result;
                cboProject.Properties.ForceInitialize();
                cboProject.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectCode",
                    ColumnCaption = "Mã",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectName",
                    ColumnCaption = "Tên",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ObjectTypeName",
                    ColumnCaption = "Loại",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 100

                });

                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (cboProject.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            cboProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboProject.Properties.SortColumnIndex = column.ColumnPosition;
                            cboProject.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            cboProject.Properties.Columns[column.ColumnName].Visible = false;
                    }

                }
                cboProject.Properties.DisplayMember = "ProjectCode";
                cboProject.Properties.ValueMember = "ProjectId";
            }
        }

       
        #endregion

        #region Event
        /// <summary>
        /// Handles the Load event of the FrmCash05 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmCash05_Load(object sender, EventArgs e)
        {
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            //BindSelectDesignReport();
            cboSelectDesignReport.EditValue = 0;
            checkDisplayValue.Checked = true;

            cboBank.EditValue = "<<Tất cả>>";
            cboProject.EditValue = "<<Tất cả>>";
            cboSelectDesignReport.SelectedIndex = 0;

        }
        /// <summary>
        /// Checks the display value edit value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void checkDisplayValue_EditValueChanged(object sender, EventArgs e)
        {
            if (checkDisplayValue.Checked)
            {
                labelControl1.Enabled = false;
                labelControl3.Enabled = false;
                labelControl4.Enabled = false;
                labelControl7.Enabled = false;

                calBeginningBalance.Enabled = false;
                calClosingBalance.Enabled = false;
                calIncurredIncrease.Enabled = false;
                calIncurredReduction.Enabled = false;

            }
            else
            {
                labelControl1.Enabled = true;
                labelControl3.Enabled = true;
                labelControl4.Enabled = true;
                labelControl7.Enabled = true;

                calBeginningBalance.Enabled = true;
                calClosingBalance.Enabled = true;
                calIncurredIncrease.Enabled = true;
                calIncurredReduction.Enabled = true;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// Binds the select design report.
        /// </summary>
        //protected void BindSelectDesignReport()
        //{
        //    var bankSource = new List<LookUpItem> { new LookUpItem { Id = 0, Name = "Mẫu theo TT 61/2014/TT-BTC" }, new LookUpItem { Id = 1, Name = "Mẫu theo CV 17660/BTC-KBNN ngày 201/12/2013" } };
        //    cboSelectDesignReport.Properties.DataSource = bankSource;
        //    cboSelectDesignReport.Properties.PopulateColumns();
        //    var treeColumnsCollection = new List<XtraColumn> {
        //                                        new XtraColumn { ColumnName = "Id", ColumnVisible = false },
        //                                        new XtraColumn { ColumnName = "Name", ColumnPosition = 1, ColumnVisible = true }
        //                                    };
        //    foreach (var column in treeColumnsCollection)
        //    {
        //        if (column.ColumnVisible)
        //        {
        //            cboSelectDesignReport.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //            cboSelectDesignReport.Properties.SortColumnIndex = column.ColumnPosition;
        //        }
        //        else cboSelectDesignReport.Properties.Columns[column.ColumnName].Visible = false;
        //    }
        //    cboSelectDesignReport.Properties.ValueMember = "Id";
        //    cboSelectDesignReport.Properties.DisplayMember = "Name";
        //}
        #endregion

    
    }
}
