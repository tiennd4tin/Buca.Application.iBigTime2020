using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmMinutesInventoryFixedAsset.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    public partial class FrmMinutesInventoryFixedAsset : FrmXtraBaseParameter, IDepartmentsView, IFixedAssetCategoriesView
    {
        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoryPresenter;

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
        public string DateInventory
        {
            get { return dateEditInventory.EditValue.ToString(); }
            set { dateEditInventory.EditValue = value; }
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
            get { return cboDepartment.EditValue.ToString() == "0" ? null : cboDepartment.EditValue.ToString(); }
        }

        /// <summary>
        /// Gets the fixed asset category identifier.
        /// </summary>
        /// <value>The fixed asset category identifier.</value>
        public string FixedAssetCategoryId
        {
            get
            {
                if (cboFixedAssetCategory.EditValue.ToString() == "0" || cboFixedAssetCategory.EditValue.ToString() == "-1")
                    return null;
                return cboFixedAssetCategory.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [sum fixed category].
        /// </summary>
        /// <value><c>true</c> if [sum fixed category]; otherwise, <c>false</c>.</value>
        public bool SumFixedCategory
        {
            get { return cboFixedAssetCategory.EditValue.ToString() == "-1"; }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmMinutesInventoryFixedAsset"/> class.
        /// </summary>
        public FrmMinutesInventoryFixedAsset()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetCategoryPresenter = new FixedAssetCategoriesPresenter(this);           
        }

        private RepositoryItemGridLookUpEdit _gridlookupRole;
        private GridView _gridlookupRoleview;
        /// <summary>
        /// Handles the Load event of the FrmMinutesInventoryFixedAsset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmMinutesInventoryFixedAsset_Load(object sender, System.EventArgs e)
        {
            _departmentsPresenter.DisplayActive();
            _fixedAssetCategoryPresenter.Display();
            DateInventory = DateTime.Now.ToString();

            dateTimeRangeV1.cboDateRange.SelectedItem = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
            //set value           
            cboDepartment.EditValue = @"0";
            cboFixedAssetCategory.EditValue = @"-1";
            SetupFirtData();
        }

        public string CounCilList
        {
            get
            {
                string temp = ";";
                for (int i = 0; i < grdMinutesInventoryFixedAssetView.RowCount; i++)
                {
                    for (int x = 0; x < grdMinutesInventoryFixedAssetView.Columns.Count; x++)
                    {
                        temp += grdMinutesInventoryFixedAssetView.GetRowCellValue(i,
                                    grdMinutesInventoryFixedAssetView.Columns[x]) + "~";
                    }
                    temp += ";";
                }
                return temp;
            }
        }
        private void SetupFirtData()
        {
            //Data table Role
            var dtRole = new DataTable();
            dtRole.Columns.Add("Vai trò");
            DataRow dr = dtRole.NewRow();
            DataRow dr2 = dtRole.NewRow();

            dr[0] = "Trưởng ban";
            dr2[0] = "Ủy viên";

            dtRole.Rows.Add(dr);
            dtRole.Rows.Add(dr2);

            _gridlookupRoleview = new GridView();
            _gridlookupRole = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridlookupRoleview,
                TextEditStyle = TextEditStyles.Standard
            };
            _gridlookupRole.DataSource = dtRole;
            _gridlookupRole.View.BestFitColumns();
            _gridlookupRoleview.PopulateColumns(dtRole);
            _gridlookupRoleview.OptionsView.ColumnAutoWidth = true;
            _gridlookupRole.DisplayMember = "Vai trò";
            _gridlookupRole.ValueMember = "Vai trò";
            //Data binding
            var dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Position");
            dt.Columns.Add("Represent");
            dt.Columns.Add("Role");
            grdMinutesInventoryFixedAsset.DataSource = dt;

            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Name",
                ColumnCaption = "Họ tên",
                ColumnPosition = 0,
                ColumnVisible = true,
                ColumnWith = 40
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Position",
                ColumnCaption = "Chức vụ",
                ColumnPosition = 1,
                ColumnVisible = true,
                ColumnWith = 40
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Represent",
                ColumnCaption = "Đại diện",
                ColumnPosition = 2,
                ColumnVisible = true,
                ColumnWith = 40
            });
            ColumnsCollection.Add(new XtraColumn
            {
                ColumnName = "Role",
                ColumnCaption = "Vai trò",
                ColumnPosition = 3,
                ColumnVisible = true,
                ColumnWith = 40,
                RepositoryControl = _gridlookupRole
            });
            foreach (var column in ColumnsCollection)
            {
                if (grdMinutesInventoryFixedAssetView.Columns[column.ColumnName] != null)
                {
                    if (column.ColumnVisible)
                    {
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].OptionsColumn.AllowEdit = true;
                    }
                    else
                        grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Visible = false;
                }

            }

            grdMinutesInventoryFixedAssetView.AddNewRow();
        }

        #region IView

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                var result = new List<DepartmentModel>
                {
                    new DepartmentModel { DepartmentId = "0", DepartmentCode = "<<Tất cả>>", DepartmentName = "<<Tất cả>>" }
                };
                result.AddRange(value);

                cboDepartment.Properties.DataSource = result;
                cboDepartment.Properties.ForceInitialize();
                cboDepartment.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã Phòng ban",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 90
                    },
                    new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên Phòng ban",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 200
                    }
                };
                foreach (var column in columnsCollection)
                {
                    if (cboDepartment.Properties.Columns[column.ColumnName] == null) continue;
                    if (column.ColumnVisible)
                    {
                        cboDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                        cboDepartment.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        cboDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }

                cboDepartment.Properties.DisplayMember = "DepartmentCode";
                cboDepartment.Properties.ValueMember = "DepartmentId";
            }
        }


        /// <summary>
        /// Sets the fixed asset categories.
        /// </summary>
        /// <value>
        /// The fixed asset categories.
        /// </value>
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                var result = new List<FixedAssetCategoryModel>
                {
                    new FixedAssetCategoryModel { FixedAssetCategoryId = "-1", FixedAssetCategoryCode = "<<Tổng hợp>>", FixedAssetCategoryName = "<<Tổng hợp>>", IsParent = false, IsActive = true },
                    new FixedAssetCategoryModel { FixedAssetCategoryId = "0", FixedAssetCategoryCode = "<<Tất cả>>", FixedAssetCategoryName = "<<Tất cả>>", IsParent = false, IsActive = true}
                };
                result.AddRange(value);

                cboFixedAssetCategory.Properties.DataSource = result.Where(a => a.IsParent == false).Where(a => a.IsActive).ToList();
                cboFixedAssetCategory.Properties.ForceInitialize();
                cboFixedAssetCategory.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "FixedAssetCategoryCode",ColumnCaption = "Mã nhóm tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120  },
                    new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên nhóm tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250  },
                    new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                    new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                    new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false },
                    new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false },
                    new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false },
                    new XtraColumn { ColumnName = "DepreciationAccount", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboFixedAssetCategory.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboFixedAssetCategory.Properties.SortColumnIndex = column.ColumnPosition;
                        cboFixedAssetCategory.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else cboFixedAssetCategory.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboFixedAssetCategory.Properties.ValueMember = "FixedAssetCategoryId";
                cboFixedAssetCategory.Properties.DisplayMember = "FixedAssetCategoryName";
            }
        }

        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        public IList<MinutesInventoryModel> MinutesInventoryModel
        {
            set
            {
                grdMinutesInventoryFixedAssetView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Name",
                    ColumnCaption = "Họ tên",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Position",
                    ColumnCaption = "Chức vụ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Represent",
                    ColumnCaption = "Đại diện",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Role",
                    ColumnCaption = "Vai trò",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                foreach (var column in ColumnsCollection)
                {
                    if (grdMinutesInventoryFixedAssetView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            grdMinutesInventoryFixedAssetView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }
        #endregion

        private void grdMinutesInventoryFixedAssetView_InitNewRow(object sender, InitNewRowEventArgs e)
        {

        }


        public bool IsInVisiblePopupMenuGrid { get; set; }
        private void grdMinutesInventoryFixedAssetView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //GridView view = sender as GridView;
            //view.FocusedRowHandle = e.HitInfo.RowHandle;
            //contextDetailMenu.Show(view.GridControl, e.Point);
            try
            {
                e.Menu.Items.Add(new DXMenuItem("Thêm dòng", (a, b) => { grdMinutesInventoryFixedAssetView.AddNewRow(); }));
                e.Menu.Items.Add(new DXMenuItem("Xóa dòng", (a, b) => { grdMinutesInventoryFixedAssetView.DeleteRow(e.HitInfo.RowHandle); }));
            }
            catch (Exception exception)
            {
            }
        }

    }
}
