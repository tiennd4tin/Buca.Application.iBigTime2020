﻿/***********************************************************************
 * <copyright file="UserControlInventoryItemList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.InventoryItem
{
    /// <summary>
    /// class UserControlInventoryItemList
    /// </summary>
    public partial class FrmInventoryItems : FrmBaseList, IInventoryItemsView, IInventoryItemCategoriesView
    {
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItemCategory;
        private GridView _gridLookUpEditInventoryItemCategoryView;
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        public bool IsTool = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmInventoryItems"/> class.
        /// </summary>
        public FrmInventoryItems()
        {
            InitializeComponent();
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
        }

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value> 
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                var inventoryItems = value.OrderBy(v => v.InventoryItemCode).ToList();
                ListBindingSource.DataSource = inventoryItems;
                gridView.PopulateColumns(inventoryItems);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });


                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCode",
                    ColumnCaption = "Mã nguyên liệu, vật liệu",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 70
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemName",
                    ColumnCaption = "Tên nguyên liệu, vật liệu",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryCategoryId",
                    ColumnCaption = "Loại nguyên liệu, vật liệu",
                    ColumnPosition = 3,
                    ColumnVisible = false,
                    ColumnWith = 200,
                    RepositoryControl = _gridLookUpEditInventoryItemCategory
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 50
                });

                XtraColumnCollectionHelper<InventoryItemModel>.ShowXtraColumnInGridView(ColumnsCollection, gridView);
                //gridView.InitGridLayout(ColumnsCollection);
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _inventoryItemCategoriesPresenter.DisplayByIsTool(IsTool);
            _inventoryItemsPresenter.DisplayByIsTool(IsTool);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new InventoryItemPresenter(null).Delete(PrimaryKeyValue);
        }

        #region private helper

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                try
                {
                    //RepositoryItemGridLookUpEdit InventoryItemCategory
                    _gridLookUpEditInventoryItemCategoryView = new GridView();
                    _gridLookUpEditInventoryItemCategoryView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItemCategory = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemCategoryView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditInventoryItemCategory.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditInventoryItemCategory.View.BestFitColumns();

                    _gridLookUpEditInventoryItemCategory.DataSource = value;
                    _gridLookUpEditInventoryItemCategoryView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {
                            ColumnName = "InventoryItemCategoryName", ColumnCaption = "Tên nhóm vật tư, CCDC",
                            ColumnPosition = 1,
                            ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInventoryItemCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInventoryItemCategory.DisplayMember = "InventoryItemCategoryName";
                    _gridLookUpEditInventoryItemCategory.ValueMember = "InventoryItemCategoryId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}