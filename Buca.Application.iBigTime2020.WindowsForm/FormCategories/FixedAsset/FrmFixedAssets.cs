using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraBars;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FixedAsset
{
    public partial class FrmFixedAssets : FrmBaseList, IFixedAssetsView, IDepartmentsView, IFixedAssetCategoriesView
    {
        private readonly FixedAssetsPresenter _FixedAssetsPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAssetCategory;
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;
        private GridView _gridLookUpEditFixedAssetCategoryView;
        private readonly DepartmentsPresenter _departmentsPresenter;
        public FrmFixedAssets()
        {
            InitializeComponent();
            _FixedAssetsPresenter = new FixedAssetsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            barButtonItemRole.Visibility = BarItemVisibility.Never;
        }

        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnVisible = true, ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnWith = 30 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnVisible = true, ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnWith = 100 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnCaption = "Nhóm tài sản ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50, RepositoryControl = _gridLookUpEditFixedAssetCategory });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnVisible = true,
                    ColumnCaption = "Số lượng",
                    ColumnPosition = 4
                    ,
                    ColumnWith = 30,
                    DisplayFormat = "n0",
                    ColumnType = UnboundColumnType.Decimal
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 50, RepositoryControl = _gridLookUpEditDepartment });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "GuaranteeDuration", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSecondHand", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "LastState", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedReason", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationValueCaculated", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDepreciationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingLifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndYear", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditDepreciationAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitDepreciationAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAssetTransfer", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationTimeCaculated", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "Source", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetActivities", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "UsingRatio", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationPeriod", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationLifeTime", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationRate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationCreditAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationDebitAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RevenueAccount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetDetailAccessories", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetVoucherAttachs", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDevaluationDate", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationAmount", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                try
                {
                    _gridLookUpEditDepartmentView = new GridView();
                    _gridLookUpEditDepartmentView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditDepartment = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditDepartmentView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditDepartment.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditDepartment.View.BestFitColumns();

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "DepartmentCode",  ColumnVisible = false },
                        new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentName";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAssetCategoryView = new GridView();
                    _gridLookUpEditFixedAssetCategoryView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAssetCategory = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetCategoryView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditFixedAssetCategory.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAssetCategory.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAssetCategory.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditFixedAssetCategory.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditFixedAssetCategory.View.BestFitColumns();

                    _gridLookUpEditFixedAssetCategory.DataSource = value;
                    _gridLookUpEditFixedAssetCategoryView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>()
                    {
                        new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "FixedAssetCategoryCode",ColumnCaption = "Mã nhóm tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150  },
                        new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên nhóm tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150  },
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

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetCategoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAssetCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFixedAssetCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFixedAssetCategory.DisplayMember = "FixedAssetCategoryName";
                    _gridLookUpEditFixedAssetCategory.ValueMember = "FixedAssetCategoryId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected override void LoadDataIntoGrid()
        {
            _departmentsPresenter.Display();
            _fixedAssetCategoriesPresenter.Display();
            _FixedAssetsPresenter.Display();
        }

        protected override void DeleteGrid()
        {
            new FixedAssetPresenter(null).Delete(PrimaryKeyValue, DateTime.Parse(GlobalVariable.SystemDate));
        }

        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmFixedAssetDetail();
        }

    }
}
