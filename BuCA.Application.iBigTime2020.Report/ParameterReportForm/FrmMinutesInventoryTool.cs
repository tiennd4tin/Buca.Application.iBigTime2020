/***********************************************************************
 * <copyright file="FrmS11H.cs" company="BUCA JSC">
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
using System.Linq;
using System.Windows.Forms;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS11H.
    /// </summary>
    public partial class FrmMinutesInventoryTool : FrmXtraBaseParameter, IDepartmentsView, IInventoryItemCategoriesView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;

        private readonly AccountsPresenter _accountsPresenter;
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        private RepositoryItemLookUpEdit _repositoryRole;

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
        public string DepartmentId
        {
            get
            {
                if (cboDepartments.EditValue.ToString() == "A0624CFA-D105-422F-BF20-11F246704DC3")
                    return null;
                else
                    return cboDepartments.EditValue.ToString();
            }
        }

        public bool GroupByFACategory
        {
            get
            {
                if (cboInventoryItemCategories.EditValue.ToString() == "91E02A45-A08A-483C-BBA1-80BB73EF38E4")
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Gets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string InventoryItemCategoryId
        {
            get
            {
                if (cboInventoryItemCategories.EditValue.ToString() == "A0624CFA-D105-422F-BF20-11F246704DC3")
                    return null;
                else
                    return cboInventoryItemCategories.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [minutes euqal book].
        /// </summary>
        /// <value><c>true</c> if [minutes euqal book]; otherwise, <c>false</c>.</value>
        public bool MinutesEuqalBook
        {
            get
            {
                if (checkMinutesEuqalBook.Checked == true)
                    return true;
                else
                    return false;
            }
        }


        /// <summary>
        /// Gets a value indicating whether [sum inventory category].
        /// </summary>
        /// <value><c>true</c> if [sum inventory category]; otherwise, <c>false</c>.</value>
        public bool SumInventoryCategory
        {
            get
            {
                if (cboInventoryItemCategories.EditValue.ToString() == "91E02A45-A08A-483C-BBA1-80BB73EF38E4")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the list minutes.
        /// </summary>
        /// <value>The list minutes.</value>
        public IList<Minutes> listMinutes
        {
            get
            {
                var minutes = new List<Minutes>();
                if (gridMinutesView.DataSource != null && gridMinutesView.RowCount > 0)
                {
                    for (var i = 0; i < gridMinutesView.RowCount; i++)
                    {
                        //for(int x = 0;x<gridMinutesView.Columns.Count;x++)
                        //    if(gridMinutesView.GetRowCellValue(i, gridMinutesView.Columns[x]).Equals(null))
                        //        gridMinutesView.SetRowCellValue(i, gridMinutesView.Columns[x], "");
                        var rowVoucher = (Minutes) gridMinutesView.GetRow(i);
                        if (rowVoucher != null)
                        {
                            string _Fullname = "";
                            string _Delegate = "";
                            string _Position = "";
                            string _Role = "";
                            if (rowVoucher.FullName != null)
                            _Fullname = rowVoucher.FullName.Trim();
                            if (rowVoucher.Delegate != null)
                                _Delegate = rowVoucher.Delegate.Trim();
                            if (rowVoucher.Position != null)
                                _Position = rowVoucher.Position.Trim();
                            if (rowVoucher.Role != null)
                                _Role = rowVoucher.Role.Trim();
                            var item = new Minutes
                            {
                                FullName = _Fullname,
                                Delegate = _Delegate,
                                Position = _Position,
                                Role = _Role,
                            };
                            minutes.Add(item);
                        }
                    }
                }
                return minutes;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS11H"/> class.
        /// </summary>
        public FrmMinutesInventoryTool()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            dateTimeRangeV1.InitSelectedIndex = 7;
        }

        /// <summary>
        /// Handles the Load event of the FrmS11H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS11H_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.DisplayActive();
            _inventoryItemCategoriesPresenter.Display(true);

            cboInventoryItemCategories.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
            cboDepartments.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
        }

        protected override bool ValidData()
        {
            return true;
        }

        public void LoadGridView()
        {
            checkMinutesEuqalBook.Checked = true;
            IList<Minutes> listMinutes = new List<Minutes>();

            bindingSource.DataSource = listMinutes;
            gridMinutesView.PopulateColumns(listMinutes);

            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "FullName",
                ColumnCaption = "Họ và tên",
                ToolTip = "Họ và tên",
                AllowEdit = true,
                ColumnPosition = 1,
                ColumnVisible = true,
                ColumnWith = 150,
                Alignment = HorzAlignment.Default,
                ColumnType = UnboundColumnType.String
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Position",
                ColumnCaption = "Chức vụ",
                ToolTip = "Chức vụ",
                AllowEdit = true,
                ColumnPosition = 2,
                ColumnVisible = true,
                ColumnWith = 150,
                ColumnType = UnboundColumnType.String,
                Alignment = HorzAlignment.Default
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Delegate",
                ColumnCaption = "Đại diện",
                ToolTip = "Đại diện",
                AllowEdit = true,
                ColumnPosition = 3,
                ColumnVisible = true,
                ColumnWith = 150,
                ColumnType = UnboundColumnType.String,
                Alignment = HorzAlignment.Default
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Role",
                ColumnCaption = "Vai trò",
                ToolTip = "Vai trò",
                AllowEdit = true,
                ColumnPosition = 4,
                ColumnVisible = true,
                ColumnWith = 150,
                Alignment = HorzAlignment.Default,
                RepositoryControl = _repositoryRole
            });

            if (ColumnsCollection == null) return;
            foreach (var column in ColumnsCollection)
            {
                if (gridMinutesView.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {

                        gridMinutesView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridMinutesView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment =
                            HorzAlignment.Center;
                        gridMinutesView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridMinutesView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridMinutesView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment =
                            column.Alignment;
                        gridMinutesView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridMinutesView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridMinutesView.Columns[column.ColumnName].OptionsColumn.AllowEdit = true;
                        gridMinutesView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else
                        gridMinutesView.Columns[column.ColumnName].Visible = false;
                }

            }
        }

        private void LoadResponitory()
        {
            var roles = new Dictionary<string, string> {{"Trưởng ban", "Trưởng ban"}, {"Ủy viên", "Ủy viên"}};
            _repositoryRole = new RepositoryItemLookUpEdit
            {
                DataSource = roles,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryRole.PopulateColumns();
            _repositoryRole.Columns["Key"].Visible = false;
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                var result = new List<DepartmentModel>
                {
                    new DepartmentModel
                    {
                        DepartmentId = "A0624CFA-D105-422F-BF20-11F246704DC3",
                        DepartmentCode = "<<Tất cả>>"
                    }
                };
                result.AddRange(value);

                cboDepartments.Properties.DataSource = result;
                cboDepartments.Properties.ForceInitialize();
                cboDepartments.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Description", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã Phòng ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên Phòng ban",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                foreach (var column in columnsCollection)
                {
                    if (cboDepartments.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            cboDepartments.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            cboDepartments.Properties.SortColumnIndex = column.ColumnPosition;
                        }
                        else
                            cboDepartments.Properties.Columns[column.ColumnName].Visible = false;
                    }

                }

                cboDepartments.Properties.DisplayMember = "DepartmentCode";
                cboDepartments.Properties.ValueMember = "DepartmentId";
            }
        }

        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                //var  result = value.Where(v => v.IsTool == true).ToList();
                //var data = value.Where(v => v.IsTool == true).ToList();
                var data = new List<InventoryItemCategoryModel>
                {
                    new InventoryItemCategoryModel
                    {
                        InventoryItemCategoryId = "91E02A45-A08A-483C-BBA1-80BB73EF38E4",
                        InventoryItemCategoryCode = "<<Tổng hợp>>"
                    },
                    new InventoryItemCategoryModel
                    {
                        InventoryItemCategoryId = "A0624CFA-D105-422F-BF20-11F246704DC3",
                        InventoryItemCategoryCode = "<<Tất cả>>"
                    }
                };
                data.AddRange(value.Where(v => v.IsTool == true).ToList());

                cboInventoryItemCategories.Properties.DataSource = data;
                cboInventoryItemCategories.Properties.ForceInitialize();
                cboInventoryItemCategories.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "InventoryItemCategoryId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsTool", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryCode",
                    ColumnCaption = "Mã loại",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryName",
                    ColumnCaption = "Tên loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });

                foreach (var column in columnsCollection)
                {
                    if (cboInventoryItemCategories.Properties.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            cboInventoryItemCategories.Properties.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            cboInventoryItemCategories.Properties.SortColumnIndex = column.ColumnPosition;
                        }
                        else
                            cboInventoryItemCategories.Properties.Columns[column.ColumnName].Visible = false;
                    }

                }
                cboInventoryItemCategories.Properties.DisplayMember = "InventoryItemCategoryCode";
                cboInventoryItemCategories.Properties.ValueMember = "InventoryItemCategoryId";
            }
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void FrmMinutesInventoryTool_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.DisplayActive();
            _inventoryItemCategoriesPresenter.Display(true);

            cboInventoryItemCategories.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
            cboDepartments.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
            LoadResponitory();
            LoadGridView();
            gridMinutesView.AddNewRow();
        }


    }
}