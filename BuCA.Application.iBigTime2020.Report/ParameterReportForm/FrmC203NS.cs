/***********************************************************************
 * <copyright file="FrmC203NS.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUNGDQ
 * Email:    tungdq@buca.vn
 * Website:
 * Create Date: Wednesday, June 13, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetKindItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using BuCA.Application.iBigTime2020.Session;
using BuCA.Enum;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// FrmC203NS
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetChaptersView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetSourcesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IBudgetKindItemsView" />
    public partial class FrmC203NS : FrmXtraBaseParameter, IBudgetChaptersView, IBudgetSourcesView, IBudgetKindItemsView, IBudgetItemsView, IProjectsView, IBanksView
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

        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BanksPresenter _banksPresenter;
        internal GridCheckMarksSelection Selection { get; private set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC203NS"/> class.
        /// </summary>
        public FrmC203NS()
        {
            InitializeComponent();
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetKindItemsPresenter = new BudgetKindItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
        }

        #region Variable

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget source.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSource
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                    return true;
                else
                    return false;
            }
        }

        public int TUTC
        {
            get
            {
                return rb1.Checked ? 0 : 1;
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public string StartDate
        {
            get { return GlobalVariable.StartedDate; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget chapter.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetChapter
        {
            get
            {
                if (cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is summary budget sub kind item.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is summary budget sub kind item; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryBudgetSubKindItem
        {
            get
            {
                if (cboBudgetSubKindItem.EditValue.ToString() == "<<Tất cả>>")
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceID
        {
            get
            {
                if (cboBudgetSource.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }
                return "," + (string)cboBudgetSource.GetColumnValue("BudgetSourceId") + ",";
            }
        }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode
        {
            get
            {
                if ((cboBudgetChapter.EditValue.ToString() == "<<Tất cả>>"))
                {
                    return null;
                }
                return "," + cboBudgetChapter.EditValue.ToString() + ",";
            }
        }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetSubKindItemCode
        {
            get
            {
                if (cboBudgetSubKindItem.EditValue.ToString() == "<<Tất cả>>")
                {
                    return null;
                }

                return "," + cboBudgetSubKindItem.EditValue + ",";
            }
        }

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }
        public int MethodDistributeId
        {
            get
            {
                if (
                    cboMethod.EditValue.ToString() == "<<Tất cả>>")
                    return -1;
                return cboMethod.SelectedIndex;
            }
        }
        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }
        public string ProjectID
        {
            get
            {
                if (
                    cboProject.EditValue.ToString() == "<<Không chọn>>")
                {
                    return null;
                }

                return (string)cboProject.GetColumnValue("ProjectId");
            }
        }

        public string BankID
        {
            get
            {
                if
                    (cboBankAccount.EditValue.ToString() == "<<Không chọn>>")
                {
                    return null;
                }

                return (string)cboBankAccount.GetColumnValue("BankId");
            }
        }

        /// <summary>
        /// Gets the inventory item ids.
        /// </summary>
        /// <value>The inventory item ids.</value>
        public string BudgetItemCodeList
        {
            get
            {
                var selectItem = "";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridViewBudgetItem.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            selectItem += (selectItem != "") ? ";;" + gridViewBudgetItem.GetRowCellValue(i, "BudgetItemCode") : "" + gridViewBudgetItem.GetRowCellValue(i, "BudgetItemCode");
                        }
                    }
                }
                if (selectItem != "")
                    selectItem += selectItem + ';';
                return selectItem;
            }
        }
        /// <summary>
        /// Gets the kind of the budget source.
        /// </summary>
        /// <value>
        /// The kind of the budget source.
        /// </value>
        public string BudgetSourceKind
        {
            get
            {
                if (lookupBudgetSourceKind.EditValue.ToString() == "")
                    return null;
                if (lookupBudgetSourceKind.EditValue.ToString() == @"<<Tất cả>>")
                    return ";KP008111;KPK008121;";
                var listKey = ";";
                var list = lookupBudgetSourceKind.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                    listKey = listKey + key + ";";
                string[] temp = listKey.Split(';');
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Equals("0"))
                        temp[i] = "KP008111";
                    if (temp[i].Equals("1"))
                        temp[i] = "KPK008121";
                }
                listKey = "";
                foreach (var key in temp)
                    listKey = listKey + key + ";";
                return listKey;
            }
        }
        #endregion

        #region IView Extend

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
                var result = new List<BudgetChapterModel>
                {
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
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                var result = new List<BudgetSourceModel>
                {
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
        /// Sets the budget kind items.
        /// </summary>
        /// <value>
        /// The budget kind items.
        /// </value>
        public IList<BudgetKindItemModel> BudgetKindItems
        {
            set
            {
                var result = new List<BudgetKindItemModel>
                {
                    new BudgetKindItemModel {BudgetKindItemCode = "<<Tất cả>>", BudgetKindItemName = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboBudgetSubKindItem.Properties.DataSource = result;
                cboBudgetSubKindItem.Properties.ForceInitialize();
                cboBudgetSubKindItem.Properties.PopulateColumns();
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
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBudgetSubKindItem.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboBudgetSubKindItem.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboBudgetSubKindItem.Properties.DisplayMember = "BudgetKindItemCode";
                cboBudgetSubKindItem.Properties.ValueMember = "BudgetKindItemCode";
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
                    ColumnWith = 460
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
        /// Initializes the grid layout.
        /// </summary>
        /// <param name="columnsCollection">The columns collection.</param>
        /// <param name="grdView">The GRD view.</param>
        /// <returns>GridView.</returns>

        public IList<ProjectModel> Projects
        {
            set
            {
                var result = new List<ProjectModel>
                {
                    new ProjectModel {ProjectCode = "<<Không chọn>>", ProjectName = "<<Không chọn>>"}

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
                columnsCollection.Add(new XtraColumn
                { ColumnName = "IsDetailbyActivityAndExpense", ColumnVisible = false });
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

        public IList<BankModel> Banks
        {
            set
            {
                try
                {

                    var result = new List<BankModel>
                    {
                        new BankModel {BankId = "<<Không chọn>>", BankAccount = "<<Không chọn>>"}

                    };
                    result.AddRange(value);
                    cboBankAccount.Properties.DataSource = result;
                    cboBankAccount.Properties.ForceInitialize();
                    cboBankAccount.Properties.PopulateColumns();
                    var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "BankAccount",
                        ColumnCaption = "Số TK",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "BankName",
                        ColumnCaption = "Tên ngân hàng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsOpenInBank", ColumnVisible = false}
                };
                    foreach (var column in columnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            if (cboBankAccount.Properties.Columns[column.ColumnName] != null)
                            {
                                cboBankAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                                cboBankAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                            }
                        }
                        else
                        {
                            cboBankAccount.Properties.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    //cboBankAccount.EditValue = _target;
                    cboBankAccount.Properties.DisplayMember = "BankAccount";
                    cboBankAccount.Properties.ValueMember = "BankAccount";


                }
                catch (Exception ex)
                {
                    //XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
        #endregion

        /// <summary>
        /// Handles the Load event of the FrmC203NS control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmC203NS_Load(object sender, EventArgs e)
        {
            //dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            BindLookUpBudgetSourceKind();
            _budgetSourcesPresenter.DisplayActive();
            _budgetChaptersPresenter.DisplayByIsActive(true);
            _budgetKindItemsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive(true);
            _banksPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            cboBudgetSource.EditValue = @"<<Tất cả>>";
            cboBudgetChapter.EditValue = @"<<Tất cả>>";
            cboBudgetSubKindItem.EditValue = @"<<Tất cả>>";
            cboMethod.EditValue = @"<<Tất cả>>";
            lookupBudgetSourceKind.EditValue = @"<<Tất cả>>";
            cboProject.EditValue = @"<<Không chọn>>";
            cboBankAccount.EditValue = @"<<Không chọn>>";
            Selection = new GridCheckMarksSelection(gridViewBudgetItem);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
        }

        /// <summary>
        /// Binds the kind of the look up budget source.
        /// </summary>
        protected void BindLookUpBudgetSourceKind()
        {
            var bankSource = new List<LookUpItem>
            {
                new LookUpItem { Id = 0, Name = @"Kinh phí thường xuyên" },
                new LookUpItem { Id = 1, Name = @"Kinh phí không thường xuyên" }
            };
            if (bankSource == null) return;
            lookupBudgetSourceKind.Properties.DataSource = bankSource;
            var columnsCollection = new List<XtraColumn>();
            columnsCollection.Add(new XtraColumn { ColumnName = "Id", ColumnVisible = false });
            columnsCollection.Add(new XtraColumn
            {
                ColumnName = "Name",
                ColumnCaption = "Loại kinh phí",
                ColumnPosition = 1,
                ColumnVisible = true
            });
            //foreach (var column in treeColumnsCollection)
            //{
            //    if (column.ColumnVisible)
            //    {
            //        lookupBudgetSourceKind.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //        lookupBudgetSourceKind.Properties.SortColumnIndex = column.ColumnPosition;
            //    }
            //    else
            //        lookupBudgetSourceKind.Properties.Columns[column.ColumnName].Visible = false;
            //}
            lookupBudgetSourceKind.Properties.ValueMember = "Id";
            lookupBudgetSourceKind.Properties.DisplayMember = "Name";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            IsPreviewOrExportXML = false;
            DialogResult = DialogResult.OK;
        }
    }
}
