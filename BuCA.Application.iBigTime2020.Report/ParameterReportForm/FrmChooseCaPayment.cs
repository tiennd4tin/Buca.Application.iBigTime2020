/***********************************************************************
 * <copyright file="FrmChooseCaPayment.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.View.Estimate;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate;
using Buca.Application.iBigTime2020.Presenter.Estimate;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Buca.Application.iBigTime2020.Model;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Mask;
using BuCA.Application.iBigTime2020.Session;
using System.Threading;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Presenter.Cash.ReceiptVoucher;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.XtraRichEdit.Model;
using Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher;
using BuCA.Enum;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate
{
    /// <summary>
    /// Class FrmChooseCaPayment.
    /// </summary>
    /// <seealso cref="DevExpress.XtraEditors.XtraForm" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Estimate.IBUCommitmentRequestsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IProjectsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFundStructuresView" />
    public partial class FrmChooseCaPayment : XtraForm, ICAPaymentsView, IBudgetSourcesView, IProjectsView, IFundStructuresView
    {
        internal GridCheckMarksSelection Selection { get; private set; }
        #region Presenter

        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The _fund structures presenter
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        /// <summary>
        /// The b u commitment requests presenter
        /// </summary>
        private readonly CAPaymentsPresenter _cAPaymentsPresenter;

        /// <summary>
        /// The b u commitment request presenter
        /// </summary>
        BUCommitmentRequestPresenter _bUCommitmentRequestPresenter;

        /// <summary>
        /// The bu commitment detail
        /// </summary>
        IList<BUCommitmentRequestDetailModel> buCommitmentDetail = null;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;


        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
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
                    };
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditBudgetSource.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditBudgetSource.View.BestFitColumns();
                    _gridLookUpEditBudgetSource.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditBudgetSource.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditBudgetSource.NullText = "";
                    //   _gridLookUpEditBudgetSource.KeyDown += _gridLookUpEditBudgetSourceView_KeyDown;

                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Mã nguồn vốn",ColumnVisible = true,ColumnWith = 100,ColumnPosition = 1},
                            new XtraColumn {ColumnName = "BudgetSourceName",ColumnCaption = "Tên nguồn vốn",ColumnVisible = true,ColumnWith = 250,ColumnPosition = 2}
                        };
                    _gridLookUpEditBudgetSourceView = InitGridLayout(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                 //   XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceName";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Projects
        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _gridLookUpEditProjectView = new GridView();
                    _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditProjectView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditProject.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditProject.View.BestFitColumns();
                    _gridLookUpEditProject.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditProject.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditProject.NullText = "";
                    //      _gridLookUpEditProject.KeyDown += _gridLookUpEditProjectView_KeyDown;

                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);
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
                    XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FundStructures
        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
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
                    _gridLookUpEditFundStructure.TextEditStyle = TextEditStyles.Standard;
                    _gridLookUpEditFundStructure.AllowNullInput = DefaultBoolean.True;
                    _gridLookUpEditFundStructure.NullText = "";
                    //  _gridLookUpEditFundStructure.KeyDown += _gridLookUpEditFundStructureView_KeyDown;

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
                    _gridLookUpEditFundStructure.DisplayMember = "FundStructureName";
                    _gridLookUpEditFundStructure.ValueMember = "FundStructureId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region RepositoryItemGridLookUpEdit

        /// <summary>
        /// The grid look up edit budget source
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        /// <summary>
        /// The grid look up edit budget source view
        /// </summary>
        private GridView _gridLookUpEditBudgetSourceView;


        /// <summary>
        /// The grid look up edit project
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        /// <summary>
        /// The grid look up edit project view
        /// </summary>
        private GridView _gridLookUpEditProjectView;

        /// <summary>
        /// The grid look up edit fund structure
        /// </summary>
        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        /// <summary>
        /// The grid look up edit fund structure view
        /// </summary>
        private GridView _gridLookUpEditFundStructureView;
        #endregion

        #region Event
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmChooseCaPayment"/> class.
        /// </summary>
        public FrmChooseCaPayment()
        {
            InitializeComponent();

            _cAPaymentsPresenter = new CAPaymentsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
        }
        /// <summary>
        /// Handles the Load event of the FrmChooseCaPayment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmChooseCaPayment_Load(object sender, EventArgs e)
        {
            var _listRefType = new List<RefTypeModel>()
            {
                new RefTypeModel() { RefTypeId = (int)RefType.CAPayment },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentInventoryItem },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentDetailFixedAsset },
                //new RefTypeModel() { RefTypeId = (int)RefType.CAPaymentTreasury },
            };
            _cAPaymentsPresenter.Display(_listRefType);
            _fundStructuresPresenter.Display();
            _budgetSourcesPresenter.Display();
            _projectsPresenter.Display();
           // LoadgridView();
            Selection = new GridCheckMarksSelection(grdCAPaymentView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
        }

        #endregion

        #region Function

        /// <summary>
        /// Loadgrids the view.
        /// </summary>
        public void LoadgridView()
        {
            if (buCommitmentDetail != null)
            {
               
                bindingSourceBUCommitment.DataSource = buCommitmentDetail;
                grdCAPaymentView.PopulateColumns(buCommitmentDetail);
            }
            else
            {
                bindingSourceBUCommitment.DataSource = new List<BUCommitmentRequestDetailModel>();
                grdCAPaymentView.PopulateColumns(new List<BUCommitmentRequestDetailModel>());
            }


            #region columns for grdAccountingView

            var columnsCollection = new List<XtraColumn>
                {
                 new XtraColumn
                {
                    ColumnName = "Description",
                   ColumnVisible = true,
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSourceId",
                    ColumnCaption = "Nguồn",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 0,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditBudgetSource
                },
                new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Chương",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                //  RepositoryControl = _gridLookUpEditBudgetChapter
                },
                new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Khoản",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                //    RepositoryControl = _gridLookUpEditBudgetSubKindItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetSubItemCode",
                    ColumnCaption = "Tiểu mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith =100,
                 //   RepositoryControl = _gridLookUpEditBudgetSubItem
                },
                new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                 //   RepositoryControl = _gridLookUpEditBudgetItem
                },
                 new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnVisible = false
                },

                  new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnVisible = false,
                },
                    new XtraColumn
                {
                    ColumnName = "AmountOC",
                    ColumnVisible = false,
                },

                new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số tiền đã CKC",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    AllowEdit = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                },
                 new XtraColumn
                {
                    ColumnName = "ProjectId",
                    ColumnCaption = "CTMT, Dự án",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 6,
                    ColumnVisible = false,
                    ColumnWith = 300,
                    RepositoryControl = _gridLookUpEditProject
                },
                      new XtraColumn
                {
                    ColumnName = "FundStructureId",
                    ColumnCaption = "Cơ cấu vốn",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 7,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    RepositoryControl = _gridLookUpEditFundStructure
                },
                               new XtraColumn
                {
                    ColumnName = "BankAccount",
                    ColumnVisible = false,
                },
                                    new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnCaption = "Số tiền còn lại",
                    Alignment = HorzAlignment.Center,
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    AllowEdit = true,
                              ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 100,
                },

    new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false },
   new XtraColumn { ColumnName = "RefId", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetDetailItemCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectActivityId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ProjectExpenseId", ColumnVisible = false },
   new XtraColumn { ColumnName = "TaskId", ColumnVisible = false },
   new XtraColumn { ColumnName = "ListItemId", ColumnVisible = false },
   new XtraColumn { ColumnName = "Approved", ColumnVisible = false },
   new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false },
   new XtraColumn { ColumnName = "BudgetProvideCode", ColumnVisible = false },
   new XtraColumn { ColumnName = "Description", ColumnVisible = false },
      new XtraColumn { ColumnName = "Address", ColumnVisible = false },
            };
            grdCAPaymentView = InitGridLayout(columnsCollection, grdCAPaymentView);
            SetNumericFormatControl(grdCAPaymentView, true);
            grdCAPaymentView.OptionsView.ShowFooter = false;



            #endregion
        }

        /// <summary>
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>
        private GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (var column in columnsCollection)
            {
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
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = "{0:n3}";
                        //      grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }
            return grdView;
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        public void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {

                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(GlobalVariable.ExchangeRateDecimalDigits);
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + GlobalVariable.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyDecimalDigits;
                        }

                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        //oCol.DisplayFormat.FormatString =
                        //    Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.FormatString = "dd/MM/yyyy";
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets the reference detail ids.
        /// </summary>
        /// <value>
        /// The reference detail ids.
        /// </value>
        public string RefDetailIds
        {
            get
            {
                var selectRefDetail = "";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < grdCAPaymentView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectRefDetail += (selectRefDetail != "") ? "," + grdCAPaymentView.GetRowCellValue(i, "RefDetailId") : "" + grdCAPaymentView.GetRowCellValue(i, "RefDetailId");
                        }
                    }
                }
                if (selectRefDetail != "")
                    selectRefDetail += ',';
                return selectRefDetail;
            }
        }
        public List<string> RefIds {
            get
            {
                var selectRefDetail = new List<string>();
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < grdCAPaymentView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectRefDetail.Add(grdCAPaymentView.GetRowCellValue(i, "RefId").ToString());
                        }
                    }
                }
                return selectRefDetail;
            }
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        public bool ValidData()
        {
            return true;
        }

        /// <summary>
        /// Gets or sets the reference master identifier.
        /// </summary>
        /// <value>
        /// The reference master identifier.
        /// </value>
        public string RefMasterId { get; set; }
        public IList<CAPaymentModel> CAPayments
        {
            set
            {
                List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
                var data = value.OrderByDescending(m => m.PostedDate).ToList();
                bindingSourceBUCommitment.DataSource = data;
                grdCAPaymentView.PopulateColumns(data);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày HT",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 150,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số PC",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày PC",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 150
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentIncluded", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Người nhận",
                    ColumnPosition = 4,
                    ColumnVisible = false,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Lý do chi",
                    ColumnPosition = 5,
                    ColumnVisible = false,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    Alignment = HorzAlignment.Far,
                    IsSummnary = true,
                    SummaryType = SummaryItemType.Sum,
                    ColumnWith = 150
                });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Loại tiền",
                    Alignment = HorzAlignment.Center,
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 7,
                    ColumnVisible = false,
                    ColumnWith = 40
                }
               );
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnCaption = "Loại phiếu thu",
                    ColumnPosition = 8,
                    ColumnVisible = false,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalTaxAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InwardRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalFreightAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalInwardAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalPaymentAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RelationRefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CaPaymentDetailTaxes", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailPurchases", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailFixedAssets", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailParallels", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Receiver", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                grdCAPaymentView = InitGridLayout(ColumnsCollection, grdCAPaymentView);
                SetNumericFormatControl(grdCAPaymentView, true);
            }
        }

    }
}
