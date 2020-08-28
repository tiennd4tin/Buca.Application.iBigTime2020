using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAssetCategory
{
    public partial class FrmFixedAssetCategories : FrmBaseTreeList, IFixedAssetCategoriesView
    {
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
    
        public FrmFixedAssetCategories()
        {
            InitializeComponent();
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
         
        }
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set 
            {
                try
                {
                    treeList.DataSource = value ?? new List<FixedAssetCategoryModel>();
                    //treeList.BeginUpdate();
                    //treeList.PopulateColumns();
                    for (var i = 0; i < treeList.Columns.Count; i++)
                    {
                        if (treeList.Columns[i].FieldName != "FixedAssetCategoryName" && treeList.Columns[i].FieldName != "FixedAssetCategoryCode" && treeList.Columns[i].FieldName !="IsActive")
                        {
                            treeList.Columns[i].Visible = false;
                        }
                    }
                    treeList.Columns["FixedAssetCategoryName"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["FixedAssetCategoryName"].Caption = @"Tên loại TSCĐ";
                    treeList.Columns["FixedAssetCategoryName"].Width = 750;
                    treeList.Columns["FixedAssetCategoryCode"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["FixedAssetCategoryCode"].Caption = @"Mã loại TSCĐ";
                    treeList.Columns["FixedAssetCategoryCode"].Width = 250;

                    treeList.Columns["IsActive"].OptionsColumn.AllowEdit = true;
                    treeList.Columns["IsActive"].Caption = "Được sử dụng";
                    treeList.Columns["IsActive"].Width = 150;

                    //treeList.OptionsView.ShowHorzLines = false;
                    //treeList.OptionsView.ShowVertLines = false;
                    //treeList.ExpandAll();
                    //treeList.EndUpdate();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        protected override void LoadDataIntoTree()
        {
            _fixedAssetCategoriesPresenter.Display();
        }
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
          
            return new FrmFixedAssetCategoryDetail();
            
        }
    
        protected override void DeleteTree()
        {
        new FixedAssetCategoryPresenter(null).Delete(PrimaryKeyValue);

        }
        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteFixedAssetCategoryItemHasChild"),
                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    
}

