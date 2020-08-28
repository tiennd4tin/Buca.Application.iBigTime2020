using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Activity
{
    public partial class FrmActivitys : FrmBaseList, IActivitysView
    {
        private readonly ActivitysPresenter _activitysPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmActivitys" /> class.
        /// </summary>
        public FrmActivitys()
        {
            InitializeComponent();
            //InitRepositoryControlData();
            _activitysPresenter = new ActivitysPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties


        public IList<ActivityModel> Activitys
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _activitysPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new ActivityPresenter(null).Delete(PrimaryKeyValue);
        }
        ///// <summary>
        ///// Deletes the item.
        ///// </summary>
        //protected override void DeleteItem()
        //{

        //    try
        //    {
        //        ActionMode = ActionModeEnum.Delete;
        //        var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"), ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
        //                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //        if (result == DialogResult.OK)
        //        {
        //            if (treeList.FindNodeByKeyID(PrimaryKeyValue).HasChildren)
        //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteTreeHasChildProject"),
        //                    ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
        //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            else
        //            {
        //                DeleteTree();
        //                _audittingLogPresenter.Save();
        //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteResult"),
        //                    ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
        //                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //    }
        //    catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption")); }
        //    finally
        //    {
        //        LoadData();
        //        SetRowSelected();
        //    }
        //}
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
