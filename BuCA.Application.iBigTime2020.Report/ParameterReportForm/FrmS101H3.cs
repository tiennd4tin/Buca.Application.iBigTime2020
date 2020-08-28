using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    public partial class FrmS101H3 : FrmXtraBaseParameter, IBudgetSourcesView, IBudgetChaptersView, IBudgetKindItemsView, IBudgetItemsView, IProjectsView, IAccountsView
    {
        #region Presenter
        /// <summary>
        /// The budget chapters presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        /// <summary>
        /// The budget kind items presenter
        /// </summary>
        private readonly BudgetKindItemsPresenter _budgetKindItemsPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// The budget sources presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The _accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// The _budget source category model
        /// </summary>
        private readonly BudgetSourceCategoriesPresenter _budgetSourceCategoriesPresenter;

        #endregion

        #region Repository
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private GridView _gridLookUpEditBudgetChapterView;


        #endregion

        #region Variable

        private List<BudgetChapterModel> _budgetChapterModel;
        private List<BudgetSourceModel> _budgetSourceModel;
        private List<BudgetKindItemModel> _budgetKindItemModel;
        private List<AccountModel> _accountModel;
        private List<ProjectModel> _projectModel;
        private List<BudgetSourceCategoryModel> _budgetSourceCategoryModel;


        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary account number.
        /// </summary>
        /// <value><c>true</c> if this instance is summary account number; otherwise, <c>false</c>.</value>
        public bool IsSummaryAccountNumber
        {
            get
            {
                if (cboAccountNumber.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary project.
        /// </summary>
        /// <value><c>true</c> if this instance is summary project; otherwise, <c>false</c>.</value>
        public bool IsSummaryProject
        {
            get
            {
                if (cboProject.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is summary project category.
        /// </summary>
        /// <value><c>true</c> if this instance is summary project category; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSourceCategory
        {
            get
            {
                if (lookupBudgetSourceKind.ItemIndex == 0)
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value><c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.</value>
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>")
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Gets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber
        {
            get
            {
                if (cboAccountNumber.EditValue.ToString() == "<<Tổng hợp>>")
                {
                    return null;
                }
                if (cboAccountNumber.EditValue.ToString() == "<<Tất cả>>")
                {
                    string commaText = ",";
                    string accounts = "";
                    foreach (var account in _accountModel)
                    {
                        accounts = accounts + commaText + "'" + account.AccountNumber + "'" + commaText;
                    }
                    return accounts;
                }
                return cboAccountNumber.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetSource.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode
        {
            get
            {
                if ((cboBudgetChapter.EditValue.ToString() == "<<Tổng hợp>>") || cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetChapter.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode
        {
            get
            {
                if (cboBudgetKindItem.EditValue.ToString() == "<<Tổng hợp>>" || cboBudgetKindItem.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboBudgetKindItem.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget item list.
        /// </summary>
        /// <value>The budget item list.</value>
        public string BudgetItemList
        {
            get
            {
                var budgetItemCodes = GetBudgetItems();
                if (budgetItemCodes == ",")
                    return null;
                return budgetItemCodes;
            }
        }

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
        /// Gets the project code.
        /// </summary>
        /// <value>The project code.</value>
        public string ProjectCode
        {
            get
            {
                if ((cboProject.EditValue.ToString() == "<<Tổng hợp>>") || cboProject.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return cboProject.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets the budget source category.
        /// </summary>
        /// <value>The budget source category.</value>
        public int? BudgetSourceKind
        {
            get
            {
                if (lookupBudgetSourceKind.ItemIndex == 0 || lookupBudgetSourceKind.ItemIndex == 1)
                    return null;
                return lookupBudgetSourceKind.ItemIndex - 2 ;
            }
        }
        #endregion

        #region Form Event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS101H3"/> class.
        /// </summary>
        public FrmS101H3()
        {
            if(DesignMode) return;
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmS101H3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmS101H3_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            BindLookUpBudgetSourceKind();
            cboAccountNumber.EditValue = @"<<Tổng hợp>>";
            cboBudgetSource.EditValue = @"<<Tổng hợp>>";
            cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
            cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
            cboProject.EditValue = @"<<Tổng hợp>>";
            cboProject.EditValue = @"<<Tổng hợp>>";
            lookupBudgetSourceKind.ItemIndex = 0;
            Selection = new GridCheckMarksSelection(gridViewBudgetItem);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            gridViewBudgetItem.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewBudgetItem.OptionsSelection.EnableAppearanceFocusedCell = false;
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

        /// <summary>
        /// Gets the budget items.
        /// </summary>
        /// <returns>System.String.</returns>
        private string GetBudgetItems()
        {
            string budgetItems = ",";

            if (gridViewBudgetItem.DataSource != null && gridViewBudgetItem.RowCount > 0)
            {
                for (var i = 0; i < gridViewBudgetItem.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (BudgetItemModel)gridViewBudgetItem.GetRow(i);
                        budgetItems = budgetItems + row.BudgetItemCode + ",";
                    }
                }
            }
            return budgetItems;
        }

        /// <summary>
        /// Binds the kind of the look up budget source.
        /// </summary>
        protected void BindLookUpBudgetSourceKind()
        {
            var bankSource = new List<LookUpItem>
            {
                new LookUpItem { Id = 0, Name = @"<<Tổng hợp>>" },
                new LookUpItem { Id = 1, Name = @"<<Tất cả>>" },
                new LookUpItem { Id = 2, Name = @"Kinh phí thường xuyên" },
                new LookUpItem { Id = 3, Name = @"Kinh phí không thường xuyên" }
            };
            lookupBudgetSourceKind.Properties.DataSource = bankSource;
            lookupBudgetSourceKind.Properties.PopulateColumns();
            var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "Id", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Name", ColumnCaption = "Loại kinh phí", ColumnPosition = 1, ColumnVisible = true }
                                            };
            foreach (var column in treeColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    lookupBudgetSourceKind.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    lookupBudgetSourceKind.Properties.SortColumnIndex = column.ColumnPosition;
                }
                else
                    lookupBudgetSourceKind.Properties.Columns[column.ColumnName].Visible = false;
            }
            lookupBudgetSourceKind.Properties.ValueMember = "Id";
            lookupBudgetSourceKind.Properties.DisplayMember = "Name";
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rndOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rndOption.SelectedIndex == 0)
            {
                cboAccountNumber.EditValue = @"<<Tất cả>>";
                cboBudgetSource.EditValue = @"<<Tất cả>>";
                cboBudgetChapter.EditValue = @"<<Tất cả>>";
                cboBudgetKindItem.EditValue = @"<<Tất cả>>";
                cboProject.EditValue = @"<<Tất cả>>";
                lookupBudgetSourceKind.EditValue = @"<<Tất cả>>";
                lookupBudgetSourceKind.ItemIndex = 1;
            }
            if (rndOption.SelectedIndex == 1)
            {
                cboAccountNumber.EditValue = @"<<Tổng hợp>>";
                cboBudgetSource.EditValue = @"<<Tổng hợp>>";
                cboBudgetChapter.EditValue = @"<<Tổng hợp>>";
                cboBudgetKindItem.EditValue = @"<<Tổng hợp>>";
                cboProject.EditValue = @"<<Tổng hợp>>";
                lookupBudgetSourceKind.ItemIndex = 0;
            }
        }
        #endregion

        #region IView
        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                _accountModel = value.Where(x => x.AccountNumber == "008" || x.AccountNumber == "009").ToList();
                var result = new List<AccountModel>
                {
                    new AccountModel {AccountNumber = "<<Tổng hợp>>", AccountName = "<<Tổng hợp>>"},
                    new AccountModel {AccountNumber = "<<Tất cả>>", AccountName = "<<Tất cả>>"}
                };
                result.AddRange(value.Where(x => x.AccountNumber == "008" || x.AccountNumber == "009").ToList());
                cboAccountNumber.Properties.DataSource = result;
                cboAccountNumber.Properties.ForceInitialize();
                cboAccountNumber.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số tài khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnCaption = "Tên tài khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccountNumber.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountNumber.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboAccountNumber.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboAccountNumber.Properties.DisplayMember = "AccountNumber";
                cboAccountNumber.Properties.ValueMember = "AccountNumber";
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                _budgetSourceModel = value.ToList();
                var result = new List<BudgetSourceModel>
                {
                    new BudgetSourceModel {BudgetSourceCode = "<<Tổng hợp>>", BudgetSourceName = "<<Tổng hợp>>"},
                    new BudgetSourceModel {BudgetSourceCode = "<<Tất cả>>", BudgetSourceName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSource.Properties.DataSource = result;
                cboBudgetSource.Properties.ForceInitialize();
                cboBudgetSource.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Mã nguồn vốn",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceName",
                    ColumnPosition = 2,
                    ColumnCaption = "Tên nguồn vốn",
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetSource.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSource.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSource.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetSource.Properties.DisplayMember = "BudgetSourceCode";
                cboBudgetSource.Properties.ValueMember = "BudgetSourceCode";
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                _budgetChapterModel = value.ToList();

                var result = new List<BudgetChapterModel>
                {
                    new BudgetChapterModel {BudgetChapterCode = "<<Tổng hợp>>", BudgetChapterName = "<<Tổng hợp>>"},
                    new BudgetChapterModel {BudgetChapterCode = "<<Tất cả>>", BudgetChapterName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetChapter.Properties.DataSource = result;
                cboBudgetChapter.Properties.ForceInitialize();
                cboBudgetChapter.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Mã Chương",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterName",
                    ColumnCaption = "Tên Chương",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetChapter.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetChapter.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetChapter.Properties.DisplayMember = "BudgetChapterCode";
                cboBudgetChapter.Properties.ValueMember = "BudgetChapterCode";
            }
        }

        /// <summary>
        /// Sets the budget kind items.
        /// </summary>
        /// <value>The budget kind items.</value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                _budgetKindItemModel = value.ToList();
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tổng hợp>>", BudgetKindItemName = "<<Tổng hợp>>"},
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetKindItem.Properties.DataSource = result;
                cboBudgetKindItem.Properties.ForceInitialize();
                cboBudgetKindItem.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemCode",
                    ColumnCaption = "Mã Khoản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetKindItemName",
                    ColumnCaption = "Tên Khoản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetKindItem.Properties.ValueMember = "BudgetKindItemCode";
            }
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                var budgetItems = value.Where(x => x.BudgetItemCode.StartsWith("5") || x.BudgetItemCode.StartsWith("6") || x.BudgetItemCode.StartsWith("7") || x.BudgetItemCode.StartsWith("8") || x.BudgetItemCode.StartsWith("9"));
                bindingSource.DataSource = budgetItems ?? new List<BudgetItemModel>();
                gridViewBudgetItem.PopulateColumns(budgetItems);
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mã Mục",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemName",
                    ColumnCaption = "Tên Mục",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 550
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                gridViewBudgetItem = InitGridLayout(columnsCollection, gridViewBudgetItem);
                gridViewBudgetItem.OptionsView.ShowFooter = false;
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>The projects.</value>
        public IList<ProjectModel> Projects
        {
            set
            {
                _projectModel = value.ToList();
                var result = new List<ProjectModel>
                    {
                        new ProjectModel {ProjectCode = "<<Tổng hợp>>", ProjectName = "<<Tổng hợp>>"},
                        new ProjectModel {ProjectCode = "<<Tất cả>>", ProjectName = "<<Tất cả>>"}

                    };
                result.AddRange(value);
                cboProject.Properties.DataSource = result;
                cboProject.Properties.ForceInitialize();
                cboProject.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectCode",
                    ColumnCaption = "Mã CTMT, dự án",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ProjectName",
                    ColumnCaption = "Tên CTMT, dự án",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectEnglishName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FinishDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExecutionUnit", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountApproved", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ObjectType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContractorAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectSize", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BuildLocation", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "InvestmentClass", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CDCActivityType", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Investment", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ObjectTypeName", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboProject.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboProject.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboProject.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboProject.Properties.DisplayMember = "ProjectCode";
                cboProject.Properties.ValueMember = "ProjectCode";
            }
        }

        #endregion
    }
}
