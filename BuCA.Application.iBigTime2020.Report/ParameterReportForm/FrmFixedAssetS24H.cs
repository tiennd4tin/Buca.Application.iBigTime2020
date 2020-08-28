/***********************************************************************
 * <copyright file="FrmS22H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Tuesday, November 28, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateTuesday, November 28, 2017Author SonTV  Description 
 * 
 * ************************************************************************/


using Buca.Application.iBigTime2020.View.Dictionary;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using BuCA.Application.iBigTime2020.Report.CommonClass;
using DevExpress.Utils;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using BuCA.Application.iBigTime2020.Report.ReportClass;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS22H.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetCategoriesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemsView" />
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IStocksView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemCategoriesView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IAccountsView" />
    public partial class FrmFixedAssetS24H : FrmXtraBaseParameter, IDepartmentsView, IFixedAssetCategoriesView, IFixedAssetsView
    {
        /// <summary>
        /// The is visible account
        /// </summary>
        private bool IsVisibleAccount = true;
        #region Presenter
        /// <summary>
        /// The stocks presenter
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;

        /// <summary>
        /// The inventory items presenter
        /// </summary>
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;

        /// <summary>
        /// The fixed assets presenter
        /// </summary>
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        #endregion


        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        internal GridCheckMarksSelection Selection { get; private set; }
        #region Parameter
        /// <summary>
        /// Sets from date.
        /// </summary>
        /// <value>From date.</value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Sets to date.
        /// </summary>
        /// <value>To date.</value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets the fixed asset category grade.
        /// </summary>
        /// <value>The fixed asset category grade.</value>
        public int FixedAssetCategoryGrade
        {
            get
            {
                int fixedAssetCategoryGrade = 0;
                switch (cboFixedAssetCategoryGrade.Text)
                {
                    case "Chi tiết nhất":
                        return fixedAssetCategoryGrade = 0;
                    case "1":
                        return fixedAssetCategoryGrade = 1;
                    case "2":
                        return fixedAssetCategoryGrade = 2;
                    case "3":
                        return fixedAssetCategoryGrade = 3;
                    case "4":
                        return fixedAssetCategoryGrade = 4;
                    case "5":
                        return fixedAssetCategoryGrade = 5;
                    case "6":
                        return fixedAssetCategoryGrade = 6;
                }
                return fixedAssetCategoryGrade;
            }
        }

        /// <summary>
        /// Gets the show quantity.
        /// </summary>
        /// <value>The show quantity.</value>
        public int ShowQuantity
        {
            get { return cboShowQuantity.EditValue.Equals("Hiển thị số lượng trên Sổ") ? 0 : 1; }
        }


        /// <summary>
        /// Gets the fixed asset category identifier.
        /// </summary>
        /// <value>The fixed asset category identifier.</value>
        public string FixedAssetCategoryId
        {
            get { return cboInventoryCategories.EditValue.Equals("00000000-0000-0000-0000-000000000000") ? null : cboInventoryCategories.EditValue.ToString(); }
        }

        /// <summary>
        /// Gets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentId
        {
            get
            {
                return cboDepartments.EditValue.Equals("00000000-0000-0000-0000-000000000000") ? null : cboDepartments.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [print by condition].
        /// </summary>
        /// <value><c>true</c> if [print by condition]; otherwise, <c>false</c>.</value>
        public bool PrintByCondition
        {
            get { return checkPrintByCondition.EditValue == null ? false : (bool)checkPrintByCondition.EditValue; }
        }

        /// <summary>
        /// Gets a value indicating whether [print fixed asset opening].
        /// </summary>
        /// <value><c>true</c> if [print fixed asset opening]; otherwise, <c>false</c>.</value>
        public bool PrintFixedAssetOpening
        {
            get { return checkFixedAssetOpenning.EditValue == null ? false : (bool)checkFixedAssetOpenning.EditValue; }
        }

        /// <summary>
        /// Gets a value indicating whether [print fixed asset increment in year].
        /// </summary>
        /// <value><c>true</c> if [print fixed asset increment in year]; otherwise, <c>false</c>.</value>
        public bool PrintFixedAssetIncrementInYear
        {
            get { return checkFixedAssetIncrease.EditValue == null ? false : (bool)checkFixedAssetIncrease.EditValue; }
        }

        /// <summary>
        /// Gets a value indicating whether [print fixed asset not increment].
        /// </summary>
        /// <value><c>true</c> if [print fixed asset not increment]; otherwise, <c>false</c>.</value>
        public bool PrintFixedAssetNotIncrement
        {
            get { return checkFixedAssetNoIncrease.EditValue == null ? false : (bool)checkFixedAssetNoIncrease.EditValue; }
        }

        /// <summary>
        /// Gets the list fixed asset identifier.
        /// </summary>
        /// <value>The list fixed asset identifier.</value>
        public string ListFixedAssetId
        {
            get
            {
                var selectFixedAssetItem = "";
                if (Selection.SelectedCount > 0)
                {
                    for (int i = 0; i < gridFixedAssetControlView.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var row = (FixedAssetModel)gridFixedAssetControlView.GetRow(i);
                            selectFixedAssetItem = selectFixedAssetItem + row.FixedAssetId + ",";
                        }
                    }
                }
                return selectFixedAssetItem;
            }
        }

        #endregion
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS22H" /> class.
        /// </summary>
        public FrmFixedAssetS24H()
        {
            InitializeComponent();
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _fixedAssetsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridFixedAssetControlView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 50;
        }


        #region IView

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        //public IList<InventoryItemCategoryModel> InventoryItemCategories
        //{
        //    set
        //    {
        //        var result = new List<InventoryItemCategoryModel>
        //        {
        //            new InventoryItemCategoryModel {InventoryItemCategoryCode = "<<Tất cả>>", InventoryItemCategoryName = "<<Tất cả>>"}
        //        };
        //        result.AddRange(value);
        //        cboDepartments.Properties.DataSource = result;
        //        cboDepartments.Properties.ForceInitialize();
        //        cboDepartments.Properties.PopulateColumns();
        //        var columnsCollection = new List<XtraColumn>();
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
        //            ColumnWith = 250,

        //        });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
        //        columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


        //        foreach (var column in columnsCollection)
        //        {
        //            if (column.ColumnVisible)
        //            {
        //                cboDepartments.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //                cboDepartments.Properties.SortColumnIndex = column.ColumnPosition;
        //            }
        //            else
        //                cboDepartments.Properties.Columns[column.ColumnName].Visible = false;
        //        }
        //        cboDepartments.Properties.DisplayMember = "InventoryItemCategoryCode";
        //        cboDepartments.Properties.ValueMember = "InventoryItemCategoryCode";
        //    }
        //}

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
                    new DepartmentModel {DepartmentId = "00000000-0000-0000-0000-000000000000", DepartmentCode = "<<Tổng hợp>>"}
                };
                result.AddRange(value);
                cboDepartments.Properties.DataSource = result;
                cboDepartments.Properties.ForceInitialize();
                cboDepartments.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã phòng ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên phòng ban",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDepartments.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDepartments.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDepartments.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDepartments.Properties.DisplayMember = "DepartmentCode";
                cboDepartments.Properties.ValueMember = "DepartmentId";
            }
        }

        /// <summary>
        /// Sets the fixed asset categories.
        /// </summary>
        /// <value>The fixed asset categories.</value>
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                var result = new List<FixedAssetCategoryModel>
                {
                    new FixedAssetCategoryModel {FixedAssetCategoryId = "00000000-0000-0000-0000-000000000000", FixedAssetCategoryCode = "<<Tất cả>>"}
                };
                result.AddRange(value);
                cboInventoryCategories.Properties.DataSource = result;
                cboInventoryCategories.Properties.ForceInitialize();
                cboInventoryCategories.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCategoryCode",
                    ColumnCaption = "Mã loại",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCategoryName",
                    ColumnCaption = "Tên loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 250,

                });
                columnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepreciationAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });


                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboInventoryCategories.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboInventoryCategories.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboInventoryCategories.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboInventoryCategories.Properties.DisplayMember = "FixedAssetCategoryCode";
                cboInventoryCategories.Properties.ValueMember = "FixedAssetCategoryId";
            }
        }

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>The fixed assets.</value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                bindingSourceFixedAssets.DataSource = value;
                gridFixedAssetControlView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnVisible = true, ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnWith = 200});

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnVisible = true, ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnWith = 350});

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnCaption = "Nhóm tài sản ", ColumnPosition = 3, ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnVisible = false
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 5, ColumnVisible = false});

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


                if (ColumnsCollection == null) return;
                foreach (var column in ColumnsCollection)
                {
                    if (gridFixedAssetControlView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {

                            gridFixedAssetControlView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridFixedAssetControlView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                            gridFixedAssetControlView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridFixedAssetControlView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridFixedAssetControlView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            gridFixedAssetControlView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            gridFixedAssetControlView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridFixedAssetControlView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            gridFixedAssetControlView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                        else
                            gridFixedAssetControlView.Columns[column.ColumnName].Visible = false;
                    }

                }
            }
        }
        #endregion


        #region Method

        #endregion


        #region Event



        /// <summary>
        /// Handles the EditValueChanged event of the checkPrintByCondition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkPrintByCondition_EditValueChanged(object sender, EventArgs e)
        {
            if (checkPrintByCondition.Checked == true)
                groupPrintByCondition.Enabled = true;
            else
                groupPrintByCondition.Enabled = false;


        }

        /// <summary>
        /// Handles the Load event of the FrmFixedAssetS24H control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmFixedAssetS24H_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.DisplayActive();
            _fixedAssetCategoriesPresenter.Display();

            //  cboSelectDesignReport.EditValue = 0;
            //checkChooseFixedAsset.Checked = true;
            cboDepartments.EditValue = @"00000000-0000-0000-0000-000000000000";
            cboInventoryCategories.EditValue = @"00000000-0000-0000-0000-000000000000";
            cboShowQuantity.SelectedIndex = 0;
            cboFixedAssetCategoryGrade.SelectedIndex = 6;
            checkPrintByCondition.Checked = false;
            checkFixedAssetIncrease.Checked = false;
            checkFixedAssetNoIncrease.Checked = false;
            checkFixedAssetOpenning.Checked = false;
            //checkChooseFixedAsset.Checked = false;
        }


        /// <summary>
        /// Handles the CheckedChanged event of the checkChooseFixedAsset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkChooseFixedAsset_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
