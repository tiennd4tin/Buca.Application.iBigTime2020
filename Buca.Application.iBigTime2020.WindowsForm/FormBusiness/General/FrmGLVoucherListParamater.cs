/***********************************************************************
 * <copyright file="FrmGLVoucherListParamater.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, July 19, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.View.General;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using Buca.Application.iBigTime2020.Presenter.General;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using GridCheckMarksSelection = Buca.Application.iBigTime2020.WindowsForm.Code.GridCheckMarksSelection;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using DateTimeRangeBlockDev.Helper;
using BuCA.Application.iBigTime2020.Session;
using System.Globalization;
using DevExpress.XtraEditors.Mask;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General
{
    /// <summary>
    /// FrmGLVoucherListParamater
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.General.IGLVoucherListParamatersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IRefTypesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    public partial class FrmGLVoucherListParamater : FrmXtraBaseParameter, IBudgetSourcesView, IGLVoucherListParamatersView, IRefTypesView, IProjectsView
    {
        #region Variable
        /// <summary>
        /// Danh sách chứng từ đã được chọn rồi (cần loại bỏ)
        /// </summary>
        public IList<GLVoucherListDetailModel> _glVoucherListDetailModelsExists;
        public IList<GLPaymentListDetailModel> _glPaymentListDetailModelsExists;
        private GridView _gridLookUpEditProjectView;
        private List<RefTypeModel> _refTypes;

        internal GridCheckMarksSelection Selection { get; private set; }
        #endregion

        #region Presenters

        private readonly GLVoucherListParamatersPresenter _glVoucherListParamatersPresenter;
        private readonly GLPaymentListParamatersPresenter _glPaymentListParamatersPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;
        protected RepositoryItemGridLookUpEdit GridLookUpEditRefType;
        protected GridView GridLookUpEditRefTypeView;
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        #endregion

        #region Properties
        public DateTime FromDate
        {
            get { return dateTimeRangeV1.FromDate; }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public DateTime ToDate
        {
            get { return dateTimeRangeV1.ToDate; }
        }

        /// <summary>
        /// Gets or sets the condition filter.
        /// </summary>
        /// <value>
        /// The condition filter.
        /// </value>
        public int ConditionFilter { get; set; }

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
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Mã nguồn vốn",ColumnVisible = true,ColumnWith = 100,ColumnPosition = 1},
                            new XtraColumn {ColumnName = "BudgetSourceName",ColumnCaption = "Tên nguồn vốn",ColumnVisible = true,ColumnWith = 250,ColumnPosition = 2}
                        };
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gets the gl voucher list detail models.
        /// </summary>
        /// <value>
        /// The gl voucher list detail models.
        /// </value>
        public IList<GLVoucherListDetailModel> GlVoucherListDetailModels
        {
            get
            {
                var listClause = new List<GLVoucherListDetailModel>();

                if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
                {
                    for (var i = 0; i < gridviewAccount.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (GLVoucherListParamaterModel)gridviewAccount.GetRow(i);

                            var items = new GLVoucherListDetailModel
                            {
                                BudgetSourceId = row.BudgetSourceId,
                                DetailRefType = row.DetailRefType,
                                Description = row.Description,
                                PostedDate = row.PostedDate,
                                RefDate = row.RefDate,
                                RefNo = row.RefNo,
                                Amount = row.Amount,
                                AmountOC = row.AmountOC,
                                CreditAccount = row.CreditAccount,
                                DebitAccount = row.DebitAccount,
                                EntryType = 0,
                                SortOrder = 0,
                                DetailId = row.RefDetailId,
                                DetailRefId = row.RefId,
                                RefId = row.RefId,
                                CurrencyCode = row.CurrencyCode,
                                ExchangeRate = row.ExchangeRate,
                            };
                            listClause.Add(items);
                        }
                    }
                }
                return listClause;
            }
        }
        public IList<GLPaymentListDetailModel> GlPaymentListDetailModels
        {
            get
            {
                var listClause = new List<GLPaymentListDetailModel>();

                if (gridviewAccount.DataSource != null && gridviewAccount.RowCount > 0)
                {
                    for (var i = 0; i < gridviewAccount.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (GLVoucherListParamaterModel)gridviewAccount.GetRow(i);

                            var items = new GLPaymentListDetailModel
                            {
                                BudgetSourceId = row.BudgetSourceId,
                                DetailRefType = row.DetailRefType,
                                Description = row.Description,
                                PostedDate = row.PostedDate,
                                RefDate = row.RefDate,
                                RefNo = row.RefNo,
                                Amount = row.Amount,
                                CreditAccount = row.CreditAccount,
                                DebitAccount = row.DebitAccount,
                                EntryType = 0,
                                SortOrder = 0,
                                DetailId = row.RefDetailId,
                                DetailRefId = row.RefId,
                                RefId = row.RefId,
                                CurrencyCode = row.CurrencyCode,
                                ExchangeRate = row.ExchangeRate,
                            };
                            listClause.Add(items);
                        }
                    }
                }
                return listClause;
            }
        }

        /// <summary>
        /// Sets the gl voucher list paramater.
        /// </summary>
        /// <value>
        /// The gl voucher list paramater.
        /// </value>
        public IList<GLVoucherListParamaterModel> GlVoucherListParamater
        {
            set
            {
                // Lọc bỏ các chứng từ đã được chọn rồi
                value = value ?? new List<GLVoucherListParamaterModel>();
                if (_glVoucherListDetailModelsExists != null && _glVoucherListDetailModelsExists.Count > 0)
                    value = value.Where(m => !_glVoucherListDetailModelsExists.ToList().Exists(n => n.DetailId.Equals(m.RefDetailId))).ToList();

                if (_glPaymentListDetailModelsExists != null && _glPaymentListDetailModelsExists.Count > 0)
                    value = value.Where(m => !_glPaymentListDetailModelsExists.ToList().Exists(n => n.DetailId.Equals(m.RefDetailId))).ToList();


                if (ConditionFilter == 1)
                {
                    var filter = value.Where(f => f.RefDate <= ToDate && f.RefDate >= FromDate);
                    if (filter.Count() == 0)
                    {
                        filter = new List<GLVoucherListParamaterModel>();
                    }

                    bindingSource.DataSource = filter;
                    grdAccount.ForceInitialize();
                    gridviewAccount.PopulateColumns(filter);
                }
                else
                {
                    bindingSource.DataSource = value.Where(f => f.RefDate <= ToDate && f.RefDate >= FromDate) ?? new List<GLVoucherListParamaterModel>();
                    grdAccount.ForceInitialize();
                    gridviewAccount.PopulateColumns(value);
                }

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DetailRefType",
                    ColumnCaption = "Loại chứng từ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 200,
                    FixedColumn = FixedStyle.Left,
                    RepositoryControl = GridLookUpEditRefType,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày CT",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });

                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số CT",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn Giải",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnCaption = "Số Tiền",
                    ColumnPosition = 10,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnWith = 150,
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnCaption = "Tỷ giá",
                    ColumnVisible = true,
                    ColumnWith = 70,
                    ColumnPosition = 9,
                    IsNumeric = true,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số Tiền quy đổi",
                    ColumnPosition = 11,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    ColumnType = UnboundColumnType.Decimal
                });

                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    ColumnPosition = 12,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditBudgetSource
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    ColumnPosition = 13,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubKindItemCode",
                    ColumnCaption = "Khoản",
                    ColumnPosition = 14,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    ColumnPosition = 15,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu Mục",
                    ColumnPosition = 16,
                    ColumnVisible = true,
                    ColumnWith = 250
                });

                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefNo",
                    ColumnCaption = "Số CT Gốc",
                    ColumnPosition = 17,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgRefDate",
                    ColumnCaption = "Ngày CT Gốc",
                    ColumnPosition = 18,
                    ColumnVisible = false,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT,Dự Án",
                    ColumnPosition = 19,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    RepositoryControl = _gridLookUpEditProject
                });

                gridviewAccount.InitGridLayout(columnsCollection);
                gridviewAccount.OptionsView.ShowFooter = false;
                gridviewAccount.OptionsView.ColumnAutoWidth = false;
                gridviewAccount.BestFitColumns();
                Selection = new GridCheckMarksSelection(gridviewAccount);
                Selection.CheckMarkColumn.VisibleIndex = 0;
                Selection.CheckMarkColumn.Width = 40;
                Selection.CheckMarkColumn.Fixed = FixedStyle.Left;
                XtraColumnCollectionHelper<GLVoucherListDetailModel>.ShowXtraColumnInGridView(columnsCollection, gridviewAccount);
                SetNumericFormatControl(gridviewAccount, false);
            }
        }

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                try
                {
                    GridLookUpEditRefTypeView = new GridView();
                    GridLookUpEditRefTypeView.OptionsView.ColumnAutoWidth = false;
                    GridLookUpEditRefType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = GridLookUpEditRefTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        AllowNullInput = DefaultBoolean.True,
                        NullValuePrompt = null,
                        DisplayMember = "RefTypeName",
                        ValueMember = "RefTypeId",
                    };
                    GridLookUpEditRefTypeView.PopulateColumns();

                    GridLookUpEditRefType.DataSource = value;
                    GridLookUpEditRefTypeView.PopulateColumns(value);
                    _refTypes = value.ToList();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "RefTypeName",
                        ColumnCaption = "Tên loại CT",
                        ColumnPosition = 1
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FunctionId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "MasterTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailTableName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutMaster", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "LayoutDetail", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultDebitAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultCreditAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultTaxAccountCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultTaxAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AllowDefaultSetting", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Postable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Searchable", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystem", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            GridLookUpEditRefTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    GridLookUpEditRefType.DisplayMember = "RefTypeName";
                    GridLookUpEditRefType.ValueMember = "RefTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    var projects = value.OrderBy(c => c.ProjectCode).ToList();

                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowDropDown = ShowDropDown.SingleClick,
                        ImmediatePopup = true
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();

                    _gridLookUpEditProject.DataSource = projects;
                    _gridLookUpEditProjectView.PopulateColumns(projects);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectCode",
                        ColumnCaption = "Mã CTMT, dự án",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ProjectName",
                        ColumnCaption = "Tên CTMT, dự án",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmGLVoucherListParamater"/> class.
        /// </summary>
        /// <param name="GlVoucherListDetailModelsExists">The gl voucher list detail models exists.</param>
        public FrmGLVoucherListParamater(IList<GLVoucherListDetailModel> GlVoucherListDetailModelsExists = null)
        {
            InitializeComponent();
            _glVoucherListParamatersPresenter = new GLVoucherListParamatersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            //dateTimeRangeV1.InitSelectedIndex = 7;
            dateTimeRangeV1.InitData(DateTime.Today);

            _glVoucherListDetailModelsExists = GlVoucherListDetailModelsExists;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmGLVoucherListParamater"/> class.
        /// </summary>
        /// <param name="GlVoucherListDetailModelsExists">The gl voucher list detail models exists.</param>
        public FrmGLVoucherListParamater(IList<GLPaymentListDetailModel> GlPaymentListDetailModelsExists = null)
        {
            InitializeComponent();
            _glPaymentListParamatersPresenter = new GLPaymentListParamatersPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            //dateTimeRangeV1.InitSelectedIndex = 7;
            dateTimeRangeV1.InitData(DateTime.Today);

            _glPaymentListDetailModelsExists = GlPaymentListDetailModelsExists;
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns></returns>
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
                    }
                    else
                    {
                        grdView.Columns[column.ColumnName].Visible = false;
                    }
            }
            return grdView;
        }

        /// <summary>
        /// Handles the Load event of the FrmGLVoucherListParamater control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmGLVoucherListParamater_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.DisplayActive();
            _refTypesPresenter.Display();
            _projectsPresenter.Display();
            if (_glVoucherListParamatersPresenter != null)
                _glVoucherListParamatersPresenter.Display();
            if (_glPaymentListParamatersPresenter != null)
                _glPaymentListParamatersPresenter.Display();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            //dtReportPeriod.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRangeV1.InitSelectedIndex = 0;
            var basePostedDate = DateTime.ParseExact(GlobalVariable.PostedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dateTimeRangeV1.InitData(new DateTime(basePostedDate.Year, 1, 1));
            dateTimeRangeV1.FromDate = (new DateTime(basePostedDate.Year, 1, 1));
            dateTimeRangeV1.ToDate = (new DateTime(basePostedDate.Year, 12, 31));
            btnFilter_Click(null, null);

        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            ConditionFilter = 1;
            if(_glVoucherListParamatersPresenter != null)
            _glVoucherListParamatersPresenter.Display();
            if (_glPaymentListParamatersPresenter != null)
                _glPaymentListParamatersPresenter.Display();
        }
        #endregion
    }
}
