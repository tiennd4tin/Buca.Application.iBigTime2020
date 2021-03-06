﻿
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
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using DevExpress.XtraTreeList;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmTargetPrograms : FrmBaseTreeList, IProjectsView
    {
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmTargetPrograms"/> class.
        /// </summary>
        public FrmTargetPrograms()
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT", ColumnVisible = true, ColumnWith = 20, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnCaption = "Loại", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {

            _projectsPresenter.DisplayByObjectType("1");
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
            return new FrmTargetProgram();
        }

        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteTargetProgramHasChild"),
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

        private void FrmTargetPrograms_Load(object sender, EventArgs e)
        {
            TreeListFilterNode += TreeList_FilterNode;
        }

        private void TreeList_FilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (tree == null) return;

            string sFilter = tree.FindFilterText;
            if (string.IsNullOrEmpty(sFilter)) return;

            var bFirst = sFilter.Substring(0, 1).Equals(@"""");
            var bLast = sFilter.Substring(sFilter.Length - 1, 1).Equals(@"""");

            if (bFirst && bLast) return;

            if (!bFirst && !bLast)
                tree.FindFilterText = @"""" + tree.FindFilterText + @"""";
            else if (!bFirst)
                tree.FindFilterText = @"""" + tree.FindFilterText;
            else if (!bLast)
                tree.FindFilterText = tree.FindFilterText + @"""";
        }
    }
}
