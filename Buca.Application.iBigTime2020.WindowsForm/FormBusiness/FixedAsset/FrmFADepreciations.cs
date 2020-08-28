/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 30, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.FixedAsset.FixedAssetArmortization;
using Buca.Application.iBigTime2020.Presenter.IncrementDecrement;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset
{
    public partial class FrmFADepreciations : FrmBaseVoucherList, IFADepreciationsView, IFixedAssetsView, IAccountsView, IDepartmentsView, IAccountingObjectsView,
        IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView
    {

        #region Presenter

        /// <summary>
        /// The s u increment decrements presenter
        /// </summary>
        private readonly FADepreciationsPresenter _faDepreciationsPresenter;

        /// <summary>
        /// The departments presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        /// The accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The accounting objects presenter
        /// </summary>
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;

        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;

        private readonly FixedAssetsPresenter _fixedAssetsPresenter;

        /// <summary>
        /// The model
        /// </summary>
        private readonly IModel _model;

        /// <summary>
        /// The budget sub kind item models
        /// </summary>
        private List<BudgetKindItemModel> _budgetSubKindItemModels;

        #endregion

        #region RepositoryItemLookUpEdit

        /// <summary>
        /// The repository method distribute identifier
        /// </summary>
        private RepositoryItemLookUpEdit _repositoryMethodDistributeId;
        private RepositoryItemLookUpEdit _repositoryDescreiption;

        /// <summary>
        /// The grid look up edit inventory item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;

        /// <summary>
        /// The grid look up edit inventory item view
        /// </summary>
        private GridView _gridLookUpEditFixedAssetView;

        /// <summary>
        /// The grid look up edit department
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;

        /// <summary>
        /// The grid look up edit department view
        /// </summary>
        private GridView _gridLookUpEditDepartmentView;

        /// <summary>
        /// The grid look up edit account
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;

        /// <summary>
        /// The grid look up edit account view
        /// </summary>
        private GridView _gridLookUpEditAccountView;

        /// <summary>
        /// The grid look up edit accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;

        /// <summary>
        /// The grid look up edit accounting object view
        /// </summary>
        private GridView _gridLookUpEditAccountingObjectView;

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;

        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;

        /// <summary>
        /// The grid look up edit budget chapter
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;

        /// <summary>
        /// The grid look up edit budget chapter view
        /// </summary>
        private GridView _gridLookUpEditBudgetChapterView;

        /// <summary>
        /// The grid look up edit budget sub kind item
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSubKindItem;

        /// <summary>
        /// The grid look up edit budget sub kind item view
        /// </summary>
        private GridView _gridLookUpEditBudgetSubKindItemView;

        /// <summary>
        /// The _grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;

        /// <summary>
        /// The _grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;

        #endregion

        /// <summary>
        /// Sets the fa depreciations.
        /// </summary>
        /// <value>
        /// The fa depreciations.
        /// </value>
        public IList<FADepreciationModel> FADepreciations
        {
            set
            {
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 80
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodTypeName", ColumnVisible = false });
                ColumnsCollection.Add(
                    new XtraColumn { ColumnName = "FADepreciationDetails", ColumnVisible = false });
            }
        }

        public FrmFADepreciations()
        {
            InitializeComponent();
            _faDepreciationsPresenter = new FADepreciationsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _model = new Model.Model();
        }

        #region override

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            _accountsPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _accountingObjectsPresenter.DisplayActive(true);
            _departmentsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _fixedAssetsPresenter.Display();
            _faDepreciationsPresenter.Display((int)RefType.FADepreciation);
        }

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var methodDistribute = typeof(MethodDistribute).ToList();
            _repositoryMethodDistributeId = new RepositoryItemLookUpEdit
            {
                DataSource = methodDistribute,
                AllowNullInput = DefaultBoolean.True,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryMethodDistributeId.PopulateColumns();
            _repositoryMethodDistributeId.Columns["Key"].Visible = false;


            var description = typeof(Description).ToList();
            _repositoryDescreiption = new RepositoryItemLookUpEdit
            {
                DataSource = description,
                AllowNullInput = DefaultBoolean.False,
                NullText = null,
                NullValuePrompt = null,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryDescreiption.PopulateColumns();
            _repositoryDescreiption.Columns["Key"].Visible = false;

        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new FADepreciationPresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            var faDePreciation = _model.GetFADepreciation(refId, true);
            if (faDePreciation == null)
                return;
            faDePreciation.FADepreciationDetails = faDePreciation.FADepreciationDetails.Where(f => f.IsParallel == false || f.IsParallel == null).ToList() ?? new List<FADepreciationDetailModel>();
            bindingSourceDetail.DataSource = faDePreciation.FADepreciationDetails;
            gridViewDetail.PopulateColumns(faDePreciation.FADepreciationDetails);

            var columnsCollection = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                 new XtraColumn {ColumnName = "FixedAssetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId",
                    ColumnVisible = true,
                    RepositoryControl = _gridLookUpEditFixedAsset,
                    ColumnWith = 100,
                    ColumnCaption = "Mã tài sản",
                    ColumnPosition = 1,
                    AllowEdit = true
                },
                new XtraColumn
                {
                    ColumnName = "FixedAssetName",
                    ColumnVisible = true,
                    ColumnWith = 200,
                    ColumnCaption = "Tên tài sản",
                    ColumnPosition = 2,
                    AllowEdit = true
                },
                new XtraColumn {ColumnName = "OrgPrice", ColumnVisible = false},
                new XtraColumn
                {
                    ColumnName = "AnnualDepreciationRate",
                    ColumnVisible = true,
                    ColumnWith = 120,
                    ColumnCaption = "Tỉ lệ hao mòn",
                    ColumnPosition = 3,
                    IsSummnary = false,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "AnnualDepreciationAmount",
                    ColumnVisible = true,
                    ColumnWith = 120,
                    ColumnCaption = "Số hao mòn năm",
                    ColumnPosition = 4,
                    IsSummnary = false,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                },
                new XtraColumn
                {
                    ColumnName = "Description", ColumnVisible = true, ColumnWith = 200, ColumnCaption = "Diễn giải", ColumnPosition = 5, AllowEdit = false, RepositoryControl = _repositoryDescreiption
                },
                new XtraColumn
                {
                    ColumnName = "DebitAccount", ColumnVisible = true, ColumnWith = 92, ColumnCaption = "TK Nợ", ColumnPosition = 6, AllowEdit = true, RepositoryControl = _gridLookUpEditAccount
                },
                new XtraColumn {ColumnName = "CreditAccount", ColumnVisible = true, ColumnWith = 92, ColumnCaption = "TK Có", ColumnPosition = 7, AllowEdit = true, RepositoryControl = _gridLookUpEditAccount},
                new XtraColumn {ColumnName = "Amount", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Số tiền", ColumnPosition = 8, AllowEdit = false, ColumnType = UnboundColumnType.Decimal},
                new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "CashWithDrawTypeId", ColumnVisible = false},
                new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false},
                new XtraColumn {ColumnName = "TaskId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false},
                new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false},
                   new XtraColumn {ColumnName = "IsParallel", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false},
                new XtraColumn
                {
                    ColumnName = "FundStructureId", ColumnVisible = true, ColumnCaption = "Khoản chi", ColumnWith = 104, ColumnPosition = 9, AllowEdit = false, RepositoryControl = _gridLookUpEditFundStructure, IsLastColumn = true
                },
                new XtraColumn {ColumnName = "BudgetExpenseId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false},
                new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false},
                new XtraColumn {ColumnName = "BudgetProvideCode", ColumnVisible = false},
                new XtraColumn {ColumnName = "TopicId", ColumnVisible = false},
                new XtraColumn {ColumnName = "DetailBy", ColumnVisible = false},
                new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                new XtraColumn {ColumnName = "DevaluationAmount", ColumnVisible = false},
                new XtraColumn {ColumnName = "ContractId", ColumnVisible = false},
            new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false},

            };
            gridViewDetail = InitGridLayout(columnsCollection, gridViewDetail, gridDetail);
            SetNumericFormatControl(gridViewDetail, true);
            gridViewDetail.OptionsView.ShowFooter = false;

            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
            repositoryNumberCalcEdit.Mask.EditMask = @"n2";
            repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
            gridViewDetail.Columns["AnnualDepreciationRate"].ColumnEdit = repositoryNumberCalcEdit;
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="grid">The grid.</param>
        /// <returns>
        /// GridView.
        /// </returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView, GridControl grid)
        {
            var totalColumnWidth = 0;
            foreach (var column in columnsCollection)
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
                        totalColumnWidth += column.ColumnWith;
                        if (column.IsSummaryText)
                        {
                            grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                            grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat =
                                Properties.Resources.SummaryText;
                        }
                        if (column.IsLastColumn)
                        {
                            if (grid.Width - totalColumnWidth <= column.ColumnWith)
                                grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                            else
                                grdView.Columns[column.ColumnName].Width = grid.Width - totalColumnWidth + column.ColumnWith;
                        }
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            return grdView;
        }

        protected override bool ValidAddNew()
        {
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = new DateTime(basePostedDate.Year, 12, 31);
            //Check chỉ cho một chứng từ trong năm
            var faDepreciations =
                _faDepreciationsPresenter.GetFADepreciationsInYear((int)BuCA.Enum.RefType.FADepreciation, toDate);
            if (faDepreciations.Count > 0)
            {
                XtraMessageBox.Show("Chứng từ hao mòn năm nay đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region IView Extens

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>
        /// The inventory items.
        /// </value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAssetView = new GridView();
                    _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFixedAsset.View.BestFitColumns();

                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã CCDC",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên CCDC",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ConvertRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalePrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultStockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "COGSAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SaleAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CostMethod", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditFixedAsset.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditFixedAsset.ValueMember = "InventoryItemId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
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
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditDepartment.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditDepartment.View.BestFitColumns();

                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentCode",
                        ColumnCaption = "Mã phòng/ban",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DepartmentName",
                        ColumnCaption = "Tên phòng/ban",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentName";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    _gridLookUpEditAccountView = new GridView();
                    _gridLookUpEditAccountView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccount = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccount.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccount.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccount.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccount.View.BestFitColumns();

                    _gridLookUpEditAccount.DataSource = value;
                    _gridLookUpEditAccountView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Số tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnCaption = "Tên tài khỏan",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountForeignName",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSource",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetChapter",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetKindItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByBudgetSubItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByMethodDistribute",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByAccountingObject",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByInventoryItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByFixedAsset",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "DetailByProjectActivity",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayOnAccountBalanceSheet",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDisplayBalanceOnReport",
                        ColumnVisible = false
                    });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>
        /// The accounting objects.
        /// </value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                try
                {
                    _gridLookUpEditAccountingObjectView = new GridView();
                    _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditAccountingObjectView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditAccountingObject.View.BestFitColumns();

                    _gridLookUpEditAccountingObject.DataSource = value;
                    _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectCategoryId",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IdentificationNumber",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FamilyDeductionAmount",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "NumberFamilyDependent",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPayInsuranceOnSalary",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsUnEmploymentInsurance",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsPaidInsuranceForPayrollItem",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(
                        new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "OrganizationManageFee",
                        ColumnVisible = false
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                    _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetSourceView = new GridView();
                    _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSourceView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Mã nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceName",
                        ColumnCaption = "Tên nguồn vốn",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetChapterView = new GridView();
                    _gridLookUpEditBudgetChapterView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetChapter = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetChapterView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetChapter.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetChapter.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetChapter.View.BestFitColumns();

                    _gridLookUpEditBudgetChapter.DataSource = value;
                    _gridLookUpEditBudgetChapterView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterCode",
                        ColumnCaption = "Mã Chương",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetChapterName",
                        ColumnCaption = "Tên Chương",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetChapterView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetChapter.DisplayMember = "BudgetChapterCode";
                    _gridLookUpEditBudgetChapter.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                try
                {
                    _budgetSubKindItemModels = value.Where(v => !v.IsParent).ToList();

                    _gridLookUpEditBudgetSubKindItemView = new GridView();
                    _gridLookUpEditBudgetSubKindItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditBudgetSubKindItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditBudgetSubKindItemView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSubKindItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSubKindItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditBudgetSubKindItem.View.BestFitColumns();

                    _gridLookUpEditBudgetSubKindItem.DataSource = _budgetSubKindItemModels;
                    _gridLookUpEditBudgetSubKindItemView.PopulateColumns(_budgetSubKindItemModels);

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemCode",
                        ColumnCaption = "Mã Khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetKindItemName",
                        ColumnCaption = "Tên Khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Caption =
                                column.ColumnCaption;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditBudgetSubKindItemView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditBudgetSubKindItem.DisplayMember = "BudgetKindItemCode";
                    _gridLookUpEditBudgetSubKindItem.ValueMember = "BudgetKindItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAssetView = new GridView();
                    _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFixedAssetView,
                        TextEditStyle = TextEditStyles.Standard
                    };
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFixedAsset.View.BestFitColumns();

                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);
                    //_fixedAssetModels = value.ToList();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetCode",
                        ColumnCaption = "Mã tài sản",
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FixedAssetName",
                        ColumnCaption = "Tên tài sản",
                        ColumnVisible = true,
                        ColumnWith = 250,
                        ColumnPosition = 2
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "GuaranteeDuration", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSecondHand", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LastState", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DisposedReason", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationValueCaculated", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDepreciationAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RemainingLifeTime", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "EndYear", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CreditDepreciationAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DebitDepreciationAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAssetTransfer", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepreciationTimeCaculated", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex =
                                column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                        }
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region FundStructures
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>
        /// The fund structures.
        /// </value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                try
                {
                    _gridLookUpEditFundStructureView = new GridView();
                    _gridLookUpEditFundStructureView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditFundStructure = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditFundStructureView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditFundStructure.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditFundStructure.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFundStructure.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditFundStructure.View.BestFitColumns();

                    _gridLookUpEditFundStructure.DataSource = value;
                    _gridLookUpEditFundStructureView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureCode",
                        ColumnCaption = "Mã cơ cấu vốn",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "FundStructureName",
                        ColumnCaption = "Tên cơ cấu vốn",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditFundStructureView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureCode";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #endregion

        private void grdList_Click(object sender, EventArgs e)
        {

        }

        protected override void ChangeFormDetail()
        {
            //if (string.IsNullOrEmpty(PrimaryKeyValue)) return;
            var obj = gridView.GetFocusedRow();
            if (obj == null)
            {
                SetFormDetail((int)RefType.FADepreciation);
                return;
            }

            var model = (FADepreciationModel)obj;
            SetFormDetail(model.RefType);
        }
    }
}
