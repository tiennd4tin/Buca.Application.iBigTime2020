
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
    public partial class FrmProjects : FrmBaseTreeList, IProjectsView
    {
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBanks"/> class.
        /// </summary>
        public FrmProjects()
        {         
            InitializeComponent();
            InitRepositoryControlData();
            _projectsPresenter = new ProjectsPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties

        public IList<ProjectModel> Projects
        {
            set
            {
            
                try
                {
                    treeList.DataSource = value ?? new List<ProjectModel>();
                    for (var i = 0; i < treeList.Columns.Count; i++)
                    {
                        if (treeList.Columns[i].FieldName != "ProjectName" && treeList.Columns[i].FieldName != "ProjectCode" && treeList.Columns[i].FieldName != "IsActive" && treeList.Columns[i].FieldName != "StartDate" && treeList.Columns[i].FieldName != "FinishDate")
                        {
                            treeList.Columns[i].Visible = false;
                        }
                    }
                    treeList.Columns["ProjectName"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["ProjectName"].Width = 300;
                    treeList.Columns["ProjectName"].Caption = @"Tên dự án";
                    treeList.Columns["StartDate"].OptionsColumn.AllowEdit = false;                   
                    treeList.Columns["StartDate"].Caption = @"Ngày bắt đầu";
                    treeList.Columns["StartDate"].Width = 100;
                    treeList.Columns["FinishDate"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["FinishDate"].Caption = @"Ngày kết thúc";
                    treeList.Columns["FinishDate"].Width = 100;
                    treeList.Columns["ProjectCode"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["ProjectCode"].Caption = @"Mã dự án";
                    treeList.Columns["IsActive"].OptionsColumn.AllowEdit = true;
                    treeList.Columns["IsActive"].Caption = "Được sử dụng";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        //#region override methods

       
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmProjectDetail();
        }

        //#endregion

        protected override void LoadDataIntoTree()
        {
            _projectsPresenter.DisplayByObjectType("2");
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
