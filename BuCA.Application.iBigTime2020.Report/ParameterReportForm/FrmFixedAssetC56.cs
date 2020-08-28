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
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using DateTimeRangeBlockDev.Helper;

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
    public partial class FrmFixedAssetC56 : FrmXtraBaseParameter, IFixedAssetCategoriesView, IFixedAssetsView
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

        public int IsType
        {
            get { return (int)checkChooseFixedAsset.EditValue; }
            set
            {
                checkChooseFixedAsset.EditValue = 0;
            }
        }

        public int IsPeriod {get { return dateTimeRangeV1.cboDateRange.SelectedIndex; } }
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
                            if (IsType == 1)
                            {
                                var row = (FixedAssetModel) gridFixedAssetControlView.GetRow(i);
                                selectFixedAssetItem = selectFixedAssetItem + row.FixedAssetId + ",";
                            }
                            if (IsType == 0)
                            {
                                var row = (FixedAssetCategoryModel)gridFixedAssetControlView.GetRow(i);
                                selectFixedAssetItem = selectFixedAssetItem + row.FixedAssetCategoryId + ",";
                            }

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
        public FrmFixedAssetC56()
        {
            InitializeComponent();
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            checkChooseFixedAsset.EditValue = 0;
            dateTimeRangeV1.InitSelectedIndex = 0;
        }


        #region IView


        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {

                bindingSourceFixedAssets.DataSource = value;
                gridFixedAssetControl.ForceInitialize();
                gridFixedAssetControlView.PopulateColumns(value);
                gridFixedAssetControlView.BestFitColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCategoryCode",
                    ColumnCaption = "Mã loại",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCategoryName",
                    ColumnCaption = "Tên loại",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 280
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "FixedAssetCategoryId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Description", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ParentId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Grade", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsParent", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "LifeTime", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DepreciationRate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "OrgPriceAccount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "DepreciationAccount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "CapitalAccount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});

                if (columnsCollection == null) return;
                foreach (var column in columnsCollection)
                {
                    if (gridFixedAssetControlView.Columns[column.ColumnName] != null)
                    {
                        if (column.ColumnVisible)
                        {
                            gridFixedAssetControlView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridFixedAssetControlView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment
                                = HorzAlignment.Center;
                            gridFixedAssetControlView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridFixedAssetControlView.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridFixedAssetControlView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment =
                                column.Alignment;
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

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>The fixed assets.</value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                bindingSourceFixedAssets.DataSource = value;
                gridFixedAssetControl.ForceInitialize();
                gridFixedAssetControlView.PopulateColumns(value);
                gridFixedAssetControlView.BestFitColumns();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnVisible = true, ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnVisible = true, ColumnCaption = "Tên tài sản", ColumnPosition = 2 , ColumnWith = 280 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnCaption = "Nhóm tài sản ", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnVisible = false
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = false });

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

                if (ColumnsCollection == null) return;

                var fieldValues = typeof(FixedAssetModel).GetProperties().Select(f => f.Name).ToList();
                foreach (var field in fieldValues)
                {
                    if (ColumnsCollection.Where(c => c.ColumnName == field.ToString()).Count() == 0)
                    {
                        ColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = field,
                            ColumnVisible = false,
                        });
                    }
                }


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


        #region Event

        private void FrmFixedAssetS24H_Load(object sender, EventArgs e)
        {
            if ((int)checkChooseFixedAsset.EditValue == 0)
            {
                _fixedAssetCategoriesPresenter.Display();
            }
            if ((int)checkChooseFixedAsset.EditValue == 1)
            {
                _fixedAssetsPresenter.Display();
            }
            gridFixedAssetControl.Visible = true;
            Selection = new GridCheckMarksSelection(gridFixedAssetControlView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
        }



        #endregion

        private void checkChooseFixedAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)checkChooseFixedAsset.EditValue == 1)
            {
                _fixedAssetsPresenter.Display();
            }
            else if ((int)checkChooseFixedAsset.EditValue == 0)
            {
                _fixedAssetCategoriesPresenter.Display();
                gridFixedAssetControl.Visible = true;
            }

            Selection = new GridCheckMarksSelection(gridFixedAssetControlView);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 10;
        }
    }
}
