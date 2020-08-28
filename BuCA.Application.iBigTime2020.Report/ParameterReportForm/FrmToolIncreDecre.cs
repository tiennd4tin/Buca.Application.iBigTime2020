using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmToolIncreDecre : FrmXtraBaseParameter, IDepartmentsView, IInventoryItemCategoriesView, IInventoryItemsView
    {
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;

        public string DepartmentId
        {
            get
            {
                if (cboDepartment.EditValue.ToString() == "a7f14b9e-71a8-42fd-9cfc-9315e6551a03")
                {
                    return null;
                }
                else
                    return cboDepartment.EditValue.ToString();
            }
        }
        public string InventoryItemsList
        {
            get
            {
                var clause = GetClause();
                return clause;
            }
        }
        public string AllInventoryItemsList
        {
            get
            {
                var clause = GetAllClause();
                return clause;
            }
        }

        public string InventoryItemCategory
        {
            get { return cboInventoryCategory.EditValue.ToString(); }
        }
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

        public IList<DepartmentModel> Departments
        {
            set
            {
                var result = new List<DepartmentModel>
                {
                    new DepartmentModel { DepartmentId = "a7f14b9e-71a8-42fd-9cfc-9315e6551a03", DepartmentCode = "<<Tất cả>>", DepartmentName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboDepartment.Properties.DataSource = result;
                cboDepartment.Properties.ForceInitialize();
                cboDepartment.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã phòng/ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên phòng ban",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = false,
                    ColumnPosition = 3,
                    ColumnWith = 400,
                    AllowEdit = false,
                    ColumnCaption = @"Diễn giải"
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnVisible = false,
                    ColumnPosition = 4,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Grade",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsParent",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ParentId",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDepartment.Properties.DisplayMember = "DepartmentCode";
                cboDepartment.Properties.ValueMember = "DepartmentId";
            }
        }



        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                var data = value.Where(v => v.IsTool == true).ToList();
                cboInventoryCategory.Properties.DataSource = data;
                //cboInventoryCategory.Properties.ForceInitialize();
                //cboInventoryCategory.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryCode",
                    ColumnCaption = "Mã Loại",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryName",
                    ColumnCaption = "Tên Loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ParentId",
                    ColumnVisible = false,
                    ColumnPosition = 3,
                    ColumnWith = 400,
                    AllowEdit = false,

                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Grade",

                    ColumnVisible = false,
                    ColumnPosition = 4,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsParent",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsTool",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsSystem",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnVisible = false,
                    AllowEdit = false
                });
                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        //cboInventoryCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        //cboInventoryCategory.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        //cboInventoryCategory.Properties.Columns[column.ColumnName].Visible = false;
                //}
                cboInventoryCategory.Properties.DisplayMember = "InventoryItemCategoryName";
                cboInventoryCategory.Properties.ValueMember = "InventoryItemCategoryId";
            }
        }

        public string _inventoryCategoryId
        {
            get
            {
                if (cboInventoryCategory.EditValue.ToString().Contains("<<Tất cả>>"))
                    return "";
                var listKey = "";
                var list = cboInventoryCategory.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                    listKey = listKey + "," + key;
                if (list.Count != 0)
                    listKey = listKey.Remove(0, 1);
                return listKey;
            }
        }


        public IList<InventoryItemModel> InventoryItems
        {
            set
            {

                var data = value.Where(v => _inventoryCategoryId.Contains(v.InventoryCategoryId)).ToList();
                bindingSource1.DataSource = data;
                gridviewAccountingObject.PopulateColumns(data);
                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã CCDC", ColumnVisible = true, ColumnWith = 40 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên CCDC", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
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
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsStock", ColumnVisible = false });

                //gridviewAccountingObject = InitGridLayout(ColumnsCollection, gridviewAccountingObject);
                ShowXtraColumnInGridView<InventoryItemModel>(ColumnsCollection, gridviewAccountingObject);
                gridviewAccountingObject.OptionsView.ShowFooter = false;
                gridviewAccountingObject.OptionsView.ShowGroupPanel = false;

            }
        }

        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
                if (grdView.Columns[column.ColumnName] != null)
                    if (column.ColumnVisible)
                    {
                        grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = @"Tổng cộng";
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            }
            return grdView;
        }
        public FrmToolIncreDecre()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
        }

        private void FrmToolIncreDecre_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.Display();
            _inventoryItemCategoriesPresenter.Display(true);
            _inventoryItemsPresenter.Display();

            cboDepartment.Text = "<<Tất cả>>";
            cboInventoryCategory.CheckAll();
            //Selection = new GridCheckMarksSelection(gridviewAccountingObject);
            //Selection.CheckMarkColumn.VisibleIndex = 0;
            //Selection.CheckMarkColumn.Width = 25;
            Selection.SelectAll();
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;

            //dateTimeRangeV1.FromDate = new DateTime(DateTime.Now.Year, 1, 1);
            //dateTimeRangeV1.ToDate = new DateTime(DateTime.Now.Year, 12, 31);
        }
        private string GetClause()
        {
            string Clause = ",";

            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (InventoryItemModel)gridviewAccountingObject.GetRow(i);
                        Clause = Clause + row.InventoryItemId + ",";
                    }
                }
            }
            return Clause;
        }
        private string GetAllClause()
        {
            string Clause = ",";
            Selection.SelectAll();
            if (gridviewAccountingObject.DataSource != null && gridviewAccountingObject.RowCount > 0)
            {
                for (var i = 0; i < gridviewAccountingObject.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (InventoryItemModel)gridviewAccountingObject.GetRow(i);
                        Clause = Clause + row.InventoryItemId + ",";
                    }
                }
            }
            return Clause;
        }

        private void cboInventoryCategory_EditValueChanged(object sender, EventArgs e)
        {
            _inventoryItemsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridviewAccountingObject);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridviewAccountingObject.OptionsSelection.EnableAppearanceFocusedCell = false;
        }
    }
}
