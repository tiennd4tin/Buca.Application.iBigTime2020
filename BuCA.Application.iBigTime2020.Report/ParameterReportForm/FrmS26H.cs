/***********************************************************************
 * <copyright file="FrmS26H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, September 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using System.Linq;
using DevExpress.Utils;
using BuCA.Application.iBigTime2020.Report.ReportClass;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS26H.
    /// </summary>
    public partial class FrmS26H : FrmXtraBaseParameter, IInventoryItemsView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        //private readonly DepartmentsPresenter _departmentsPresenter;
        //private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        //private readonly AccountsPresenter _accountsPresenter;
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        internal GridCheckMarksSelection Selection { get; private set; }
        #region Params

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>cboInventoryItemCategories
        /// Gets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>

        /// <summary>
        /// Gets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string InventoryItemCategoryId
        {
            get
            {
                return "791060cb-2446-4cc5-b93b-65801bd8dd7b";
            }
        }
        public bool GroupByFACategory
        {
            get
            {
                    return true;
            }
        }
        //public bool IsDetailMonth
        //{
        //    get
        //    { return chkDetailMonth.Checked; }
        //}

        /// <summary>
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>



        public string InventoryIDs
        {
            get
            {
                var selectInventoryItem = ",";
                if (Selection.IsSelectedAll || Selection.SelectedCount < 1)
                    return null;
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridInventoryView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (InventoryItemModel)gridInventoryView.GetRow(i);
                            selectInventoryItem = selectInventoryItem + row.InventoryItemId + ",";
                        }
                    }
                }
                return selectInventoryItem;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS26H"/> class.
        /// </summary>
        public FrmS26H()
        {
            InitializeComponent();
            //_departmentsPresenter = new DepartmentsPresenter(this);
            //_inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            //dateTimeRangeV1.InitSelectedIndex = 7;
      
        }

        /// <summary>
        /// Handles the Load event of the FrmS26H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>


        protected override bool ValidData()
        {
            return true;
        }

        //public IList<DepartmentModel> Departments
        //{
        //    set
        //    {
        //        var result = new List<DepartmentModel>
        //        {
        //            new DepartmentModel {DepartmentId = "A0624CFA-D105-422F-BF20-11F246704DC3", DepartmentCode = "<<Tất cả>>"}
        //        };
        //        result.AddRange(value);

        //        cboDepartments.Properties.DataSource = result;
        //        cboDepartments.Properties.ForceInitialize();
        //        cboDepartments.Properties.PopulateColumns();
        //        var columnsCollection = new List<XtraColumn>();
        //        columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn
        //        {
        //            ColumnName = "DepartmentCode",
        //            ColumnCaption = "Mã Phòng ban",
        //            ColumnPosition = 1,
        //            ColumnVisible = true,
        //            ColumnWith = 100
        //        });
        //        columnsCollection.Add(new XtraColumn
        //        {
        //            ColumnName = "DepartmentName",
        //            ColumnCaption = "Tên Phòng ban",
        //            ColumnPosition = 2,
        //            ColumnVisible = true,
        //            ColumnWith = 250
        //        });
        //        foreach (var column in columnsCollection)
        //        {
        //            if (cboDepartments.Properties.Columns[column.ColumnName] != null)
        //            {
        //                if (column.ColumnVisible)
        //                {
        //                    cboDepartments.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //                    cboDepartments.Properties.SortColumnIndex = column.ColumnPosition;
        //                }
        //                else
        //                    cboDepartments.Properties.Columns[column.ColumnName].Visible = false;
        //            }

        //        }

        //        cboDepartments.Properties.DisplayMember = "DepartmentCode";
        //        cboDepartments.Properties.ValueMember = "DepartmentId";
        //    }
        //}

        //public IList<InventoryItemCategoryModel> InventoryItemCategories
        //{
        //    set
        //    {
        //        var result = new List<InventoryItemCategoryModel>
        //        {
        //            new InventoryItemCategoryModel {InventoryItemCategoryId = "91E02A45-A08A-483C-BBA1-80BB73EF38E4", InventoryItemCategoryCode= "<<Tổng hợp>>"},
        //            new InventoryItemCategoryModel {InventoryItemCategoryId = "A0624CFA-D105-422F-BF20-11F246704DC3",InventoryItemCategoryCode = "<<Tất cả>>"}
        //        };
        //        result.AddRange(value);

        //        cboInventoryItemCategories.Properties.DataSource = result;
        //        cboInventoryItemCategories.Properties.ForceInitialize();
        //        cboInventoryItemCategories.Properties.PopulateColumns();
        //        var columnsCollection = new List<XtraColumn>();
        //        columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn
        //        {
        //            ColumnName = "InventoryItemCategoryCode",
        //            ColumnCaption = "Mã loại",
        //            ColumnPosition = 1,
        //            ColumnVisible = true,
        //            ColumnWith = 100
        //        });
        //        columnsCollection.Add(new XtraColumn
        //        {
        //            ColumnName = "InventoryItemCategoryName",
        //            ColumnCaption = "Tên loại",
        //            ColumnPosition = 2,
        //            ColumnVisible = true,
        //            ColumnWith = 250
        //        });

        //        foreach (var column in columnsCollection)
        //        {
        //            if (cboInventoryItemCategories.Properties.Columns[column.ColumnName] != null)
        //            {
        //                if (column.ColumnVisible)
        //                {
        //                    cboInventoryItemCategories.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //                    cboInventoryItemCategories.Properties.SortColumnIndex = column.ColumnPosition;
        //                }
        //                else
        //                    cboInventoryItemCategories.Properties.Columns[column.ColumnName].Visible = false;
        //            }

        //        }
        //        cboInventoryItemCategories.Properties.DisplayMember = "InventoryItemCategoryCode";
        //        cboInventoryItemCategories.Properties.ValueMember = "InventoryItemCategoryId";
        //    }
        //}

        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (InventoryItemCategoryId != null)
                {
                    inventoryItemBindingSource.DataSource = value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList();
                    gridInventoryView.PopulateColumns(value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList());
                }
                else
                {
                    inventoryItemBindingSource.DataSource = value;
                    gridInventoryView.PopulateColumns(value);
                }
                inventoryItemBindingSource.DataSource = value.Where(x =>x.InventoryCategoryId == InventoryItemCategoryId).ToList();
                gridInventoryView.PopulateColumns(value.Where(x => x.InventoryCategoryId == InventoryItemCategoryId).ToList());
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư/CCDC", ToolTip = "Tên vật tư/CCDC", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư/CCDC", ToolTip = "Mã vật tư/CCDC", ColumnPosition = 0, ColumnVisible = true, ColumnWith = 80 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitsInStock", ColumnVisible = false });

                if (ColumnsCollection == null) return;
                foreach (var column in ColumnsCollection)
                {
                    if (gridInventoryView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridInventoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridInventoryView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridInventoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridInventoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridInventoryView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridInventoryView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridInventoryView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridInventoryView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridInventoryView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridInventoryView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }

        private void FrmS26H_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_I_BIGTIME_2020DataSet.InventoryItem' table. You can move, or remove it, as needed.
            this.inventoryItemTableAdapter.Fill(this._I_BIGTIME_2020DataSet.InventoryItem);
            //_departmentsPresenter.DisplayActive();
            //_inventoryItemCategoriesPresenter.Display(true);
            _inventoryItemsPresenter.DisplayByIsTool(true);
            Selection = new GridCheckMarksSelection(gridInventoryView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
            dateTimeRangeV1.cboDateRange.SelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            //cboInventoryItemCategories.EditValue = @"A0624CFA-D105-422F-BF20-11F246704DC3";
            //cboDepartments.EditValue = @"A0624CFA-D105-422F-BF20-11F246704DC3";
        }
    }
}