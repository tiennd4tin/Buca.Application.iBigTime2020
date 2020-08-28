
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
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmAllProject : FrmBaseTreeList, IProjectsView
    {
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBanks"/> class.
        /// </summary>
        public FrmAllProject()
        {         
            InitializeComponent();
            InitRepositoryControlData();
            _projectsPresenter = new ProjectsPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {

                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnVisible = true, ColumnCaption = "Tên", ColumnPosition = 2, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = true, ColumnCaption = "Ngày bắt đầu", ColumnPosition = 3, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = true, ColumnCaption = "Ngày kết thúc", ColumnPosition = 4, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = true, ColumnCaption = "Loại", ColumnPosition = 5, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = true, ColumnCaption = "Được sử dụng", ColumnPosition = 6, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });            
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });           
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
            }
        }

        #endregion

        //#region override methods

       
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmAllProjectDetail();
        }

        //#endregion

        protected override void LoadDataIntoTree()
        {
            _projectsPresenter.Display();
        }
        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected override void DeleteTree()
        {
            new ProjectPresenter(null).Delete(PrimaryKeyValue);
        }

        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteProjectHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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
