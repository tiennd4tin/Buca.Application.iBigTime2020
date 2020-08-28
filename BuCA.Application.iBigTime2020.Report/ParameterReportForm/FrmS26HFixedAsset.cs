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
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAsset;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;

namespace BuCA.Application.iBigTime2020.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS11H.
    /// </summary>
    /// <seealso cref="BuCA.Application.iBigTime2020.Report.BaseParameterForm.FrmXtraBaseParameter" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IDepartmentsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IFixedAssetsView" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IInventoryItemCategoriesView" />
    public partial class FrmS26HFixedAsset : FrmXtraBaseParameter, IDepartmentsView, IFixedAssetsView, IInventoryItemCategoriesView, IFixedAssetCategoriesView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        private readonly DepartmentsPresenter _departmentsPresenter;
        /// <summary>
        /// The inventory item categories presenter
        /// </summary>
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        /// <summary>
        /// The fixed assets presenter
        /// </summary>
        private readonly FixedAssetsPresenter _FixedAssetsPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS26HFixedAsset"/> class.
        /// </summary>
        public FrmS26HFixedAsset()
        {
            InitializeComponent();
            _departmentsPresenter = new DepartmentsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.All;
            dateTimeRangeV1.InitSelectedIndex = 7;
            _FixedAssetsPresenter = new FixedAssetsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
        }

        #region Params

        /// <summary>
        /// Gets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
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
        /// cboInventoryItemCategories
        /// Gets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string DepartmentId
        {
            get
            {
                if (cboDepartments.EditValue.ToString() == "<<Tất cả>>")
                    return "A0624CFA-D105-422F-BF20-11F246704DC3";
                else
                    return cboDepartments.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [group by fa category].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [group by fa category]; otherwise, <c>false</c>.
        /// </value>
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
        /// <value>
        /// The bank identifier.
        /// </value>
        public string InventoryItemCategoryId
        {
            get
            {
                if (cboInventoryItemCategories.EditValue.ToString() == "<<Tổng hợp>>")
                    return "91E02A45-A08A-483C-BBA1-80BB73EF38E4";
                if (cboInventoryItemCategories.EditValue.ToString() == "<<Tất cả>>")
                    return "A0624CFA-D105-422F-BF20-11F246704DC3";
                else
                    return cboInventoryItemCategories.EditValue.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS11H" /> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmS26HFixedAsset_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.DisplayActive();
            _FixedAssetsPresenter.DisplayByActive(true);
            _fixedAssetCategoriesPresenter.Display();

            cboInventoryItemCategories.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
            cboDepartments.EditValue = "A0624CFA-D105-422F-BF20-11F246704DC3";
            dateTimeRangeV1.cboDateRange.EditValue = GlobalVariable.DateRangeSelected;
            dateTimeRangeV1.FromDate = GlobalVariable.FromDate;
            dateTimeRangeV1.ToDate = GlobalVariable.ToDate;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            return true;
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
                var result = new List<DepartmentModel>
                {
                    new DepartmentModel {DepartmentId = "A0624CFA-D105-422F-BF20-11F246704DC3", DepartmentCode = "<<Tất cả>>"}
                };
                result.AddRange(value);

                cboDepartments.Properties.DataSource = result;
                cboDepartments.Properties.ForceInitialize();
                cboDepartments.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
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

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>
        /// The inventory item categories.
        /// </value>
        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
            //    var result = new List<InventoryItemCategoryModel>
            //    {
            //        new InventoryItemCategoryModel {InventoryItemCategoryId = "91E02A45-A08A-483C-BBA1-80BB73EF38E4", InventoryItemCategoryCode= "<<Tổng hợp>>"},
            //        new InventoryItemCategoryModel {InventoryItemCategoryId = "A0624CFA-D105-422F-BF20-11F246704DC3",InventoryItemCategoryCode = "<<Tất cả>>"}
            //    };
            //    result.AddRange(value);

            //    cboInventoryItemCategories.Properties.DataSource = result;
            //    cboInventoryItemCategories.Properties.ForceInitialize();
            //    cboInventoryItemCategories.Properties.PopulateColumns();
            //    var columnsCollection = new List<XtraColumn>();
            //    columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
            //    columnsCollection.Add(new XtraColumn
            //    {
            //        ColumnName = "InventoryItemCategoryCode",
            //        ColumnCaption = "Mã loại",
            //        ColumnPosition = 1,
            //        ColumnVisible = true,
            //        ColumnWith = 100
            //    });
            //    columnsCollection.Add(new XtraColumn
            //    {
            //        ColumnName = "InventoryItemCategoryName",
            //        ColumnCaption = "Tên loại",
            //        ColumnPosition = 2,
            //        ColumnVisible = true,
            //        ColumnWith = 250
            //    });

            //    foreach (var column in columnsCollection)
            //    {
            //        if (cboInventoryItemCategories.Properties.Columns[column.ColumnName] != null)
            //        {
            //            if (column.ColumnVisible)
            //            {
            //                cboInventoryItemCategories.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //                cboInventoryItemCategories.Properties.SortColumnIndex = column.ColumnPosition;
            //            }
            //            else
            //                cboInventoryItemCategories.Properties.Columns[column.ColumnName].Visible = false;
            //        }

            //    }
            //    cboInventoryItemCategories.Properties.DisplayMember = "InventoryItemCategoryCode";
            //    cboInventoryItemCategories.Properties.ValueMember = "InventoryItemCategoryId";
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

                var result = new List<FixedAssetModel>
                {
                    new FixedAssetModel {FixedAssetId = "91E02A45-A08A-483C-BBA1-80BB73EF38E4", FixedAssetCode= "<<Tổng hợp>>"},
                    new FixedAssetModel {FixedAssetId = "A0624CFA-D105-422F-BF20-11F246704DC3",FixedAssetCode = "<<Tất cả>>"}
                };
                result.AddRange(value);

                var ColumnsCollection = new List<XtraColumn>();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn {

                    ColumnName = "FixedAssetCode",
                    ColumnVisible = true,
                    ColumnCaption = "Mã tài sản",
                    ColumnPosition = 1,
                    ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn {
                    ColumnName = "FixedAssetName",
                    ColumnVisible = true,
                    ColumnCaption = "Tên tài sản",
                    ColumnPosition = 2,
                    ColumnWith = 100 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId",
                    ColumnCaption = "Nhóm tài sản ", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 50  });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnVisible = false,
 
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDevaluationDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PeriodDevaluationAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DevaluationAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban",
                    ColumnPosition = 5, ColumnVisible = false, ColumnWith = 50 });

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


            }
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        public IList<FixedAssetCategoryModel> FixedAssetCategories {
            set
            {
                var result = new List<FixedAssetCategoryModel>
                {
                    new FixedAssetCategoryModel { FixedAssetCategoryId = "A0624CFA-D105-422F-BF20-11F246704DC3", FixedAssetCategoryName = "<<Tất cả>>" }
                };
                result.AddRange(value.Where(a => a.IsParent == false).Where(a => a.IsActive).ToList());

                cboInventoryItemCategories.Properties.DataSource = result;// value.Where(a => a.IsParent == false).Where(a => a.IsActive).ToList();
                cboInventoryItemCategories.Properties.ForceInitialize();
                cboInventoryItemCategories.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
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
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboInventoryItemCategories.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboInventoryItemCategories.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboInventoryItemCategories.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboInventoryItemCategories.Properties.ValueMember = "FixedAssetCategoryId";
                cboInventoryItemCategories.Properties.DisplayMember = "FixedAssetCategoryName";
            }
        }
    }
}