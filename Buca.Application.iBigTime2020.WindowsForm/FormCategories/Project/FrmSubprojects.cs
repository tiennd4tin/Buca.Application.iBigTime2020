
using System;
using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmSubprojects : FrmBaseTreeList, IProjectsView
    {
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmSubprojects"/> class.
        /// </summary>
        public FrmSubprojects()
        {
            InitializeComponent();
            //InitRepositoryControlData();
            _projectsPresenter = new ProjectsPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties

        public IList<ProjectModel> Projects
        {
            set
            {
                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã Hạng mục công trình", ColumnVisible = true, ColumnWith = 20, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên Hạng mục công trình", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnCaption = "Ngày bắt đầu", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnCaption = "Ngày kết thúc", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnCaption = "Loại", ColumnPosition = 2, ColumnVisible = false, ColumnWith = 150 });
                
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition =4, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #endregion

        #region override methods

        protected override void LoadDataIntoTree()
        {
            _projectsPresenter.DisplayByObjectType("3");
        }


        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected override void DeleteTree()
        {
            new ProjectPresenter(null).Delete(PrimaryKeyValue);
        }
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmSubProjectDetail();
        }
        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteSubProjectHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region private helper

        private void InitRepositoryControlData()
        {
            var accountKind = typeof(AccountKind).ToList();
            _repositoryAccountCategoryKind = new RepositoryItemLookUpEdit
            {
                DataSource = accountKind,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryAccountCategoryKind.PopulateColumns();
            _repositoryAccountCategoryKind.Columns["Key"].Visible = false;
        }

        #endregion
    }
}
