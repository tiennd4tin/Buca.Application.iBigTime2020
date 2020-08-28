using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CapitalPlan;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.View.Dictionary;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.CapitalPlan
{
    public partial class FrmCapitalPlans : FrmBaseList, ICapitalPlansView
    {
        private readonly CapitalPlansPresenter _CapitalPlansPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCapitalPlans" /> class.
        /// </summary>
        public FrmCapitalPlans()
        {
            InitializeComponent();
            //InitRepositoryControlData();
            _CapitalPlansPresenter = new CapitalPlansPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties


        public IList<CapitalPlanModel> CapitalPlans
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanCode", ColumnCaption = "Mã KH vốn", ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanName", ColumnCaption = "Tên KH vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanYear", ColumnCaption = "KH năm", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTypeId", ColumnCaption = "Loại KH vốn", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được hoạt động", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 20 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalPlanId", ColumnVisible = false });
            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _CapitalPlansPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CapitalPlanPresenter(null).Delete(PrimaryKeyValue);
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
