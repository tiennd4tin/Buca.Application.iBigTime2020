/***********************************************************************
 * <copyright file="FrmXtraToolDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItemCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Stock;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Tool
{
    /// <summary>
    ///     Class FrmXtraToolDetail.
    /// </summary>
    public partial class FrmToolDetail : FrmXtraBaseCategoryDetail, IInventoryItemView, IStocksView,
        IAccountsView, IInventoryItemCategoriesView, IAccountingObjectsView, IDepartmentsView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly InventoryItemPresenter _inventoryItemPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly InventoryItemCategoriesPresenter _inventoryItemCategoriesPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenters;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private string toolId = "791060cb-2446-4cc5-b93b-65801bd8dd7b";
        #region IInventoryItemView

        public string InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the inventory category identifier.
        /// </summary>
        /// <value>The inventory category identifier.</value>
        public string InventoryCategoryId
        {

            get
            {
                return toolId;
            }
            set
            {
                toolId = value;
            }
        }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode
        {
            get { return txtInventoryItemCode.Text; }
            set { txtInventoryItemCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        public string InventoryItemName
        {
            get { return txtInventoryItemName.Text; }
            set { txtInventoryItemName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return string.IsNullOrEmpty(txtDescription.Text) ? null : txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit
        {
            get { return string.IsNullOrEmpty(txtUnit.Text) ? null : txtUnit.Text.Trim(); }
            set { txtUnit.Text = value; }
        }

        /// <summary>
        /// Gets or sets the convert unit.
        /// </summary>
        /// <value>The convert unit.</value>
        public string ConvertUnit
        {
            get { return string.IsNullOrEmpty(txtConvertUnit.Text) ? null : txtConvertUnit.Text.Trim(); }
            set { txtConvertUnit.Text = value; }
        }

        /// <summary>
        /// Gets or sets the made in.
        /// </summary>
        /// <value>The made in.</value>
        public string MadeIn
        {
            get { return string.IsNullOrEmpty(txtMadeIn.Text) ? null : txtMadeIn.Text.Trim(); }
            set { txtMadeIn.Text = value; }
        }

        /// <summary>
        /// Gets or sets the convert rate.
        /// </summary>
        /// <value>The convert rate.</value>
        public decimal? ConvertRate
        {
            get { return calcConvertRate.Value; }
            set { calcConvertRate.Text = value == null ? null : value.ToString(); }
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal? UnitPrice
        {
            get { return calcUnitPrice.Value; }
            set { calcUnitPrice.Text = value == null ? null : value.ToString(); }
        }

        /// <summary>
        /// Gets or sets the sale price.
        /// </summary>
        /// <value>The sale price.</value>
        public decimal? SalePrice
        {
            get { return calcSalePrice.Value; }
            set { calcSalePrice.Text = value == null ? null : value.ToString(); }
        }

        /// <summary>
        /// Gets or sets the default stock identifier.
        /// </summary>
        /// <value>The default stock identifier.</value>
        public string DefaultStockId
        {
            get
            {
                return string.IsNullOrEmpty(cboDefaultStockId.Text) ? null :
                    (string)cboDefaultStockId.GetColumnValue("StockId");
            }
            set
            {
                cboDefaultStockId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public string DepartmentId
        {
            get
            {
                return string.IsNullOrEmpty(lookUpDepartment.Text) ? null :
                    (string)lookUpDepartment.GetColumnValue("DepartmentId");
            }
            set
            {
                lookUpDepartment.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the inventory account.
        /// </summary>
        /// <value>The inventory account.</value>
        public string InventoryAccount
        {
            get
            {
                return string.IsNullOrEmpty(cboInventoryAccount.Text) ? null :
                    (string)cboInventoryAccount.GetColumnValue("AccountNumber");
            }
            set
            {
                cboInventoryAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the cogs account.
        /// </summary>
        /// <value>The cogs account.</value>
        public string COGSAccount
        {
            get
            {
                return string.IsNullOrEmpty(cboCOGSAccount.Text) ? null :
                    (string)cboCOGSAccount.GetColumnValue("AccountNumber");
            }
            set
            {
                cboCOGSAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the sale account.
        /// </summary>
        /// <value>The sale account.</value>
        public string SaleAccount
        {
            get
            {
                return string.IsNullOrEmpty(cboSaleAccount.Text) ? null :
                    (string)cboSaleAccount.GetColumnValue("AccountNumber");
            }
            set
            {
                cboSaleAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
        public int? CostMethod { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId
        {
            get
            {
                return string.IsNullOrEmpty(cboAccountingObjectId.Text) ? null :
                    (string)cboAccountingObjectId.GetColumnValue("AccountingObjectId");
            }
            set
            {
                cboAccountingObjectId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>The tax rate.</value>
        public decimal? TaxRate
        {
            get
            {
                switch (cboTaxRate.SelectedIndex)
                {
                    case 0:
                        return 0;
                    case 1:
                        return 10;
                    case 2:
                        return 15;
                }
                return null;
            }
            set
            {
                if (value == decimal.Parse("0"))
                {
                    cboTaxRate.SelectedIndex = 0;
                    return;
                }
                if (value == decimal.Parse("10"))
                {
                    cboTaxRate.SelectedIndex = 1;
                    return;
                }
                if (value == decimal.Parse("15"))
                {
                    cboTaxRate.SelectedIndex = 2;
                    return;
                }
                cboTaxRate.SelectedIndex = -1;
            }
        }

        public bool IsTool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is service.
        /// </summary>
        /// <value><c>true</c> if this instance is service; otherwise, <c>false</c>.</value>
        public bool IsService
        {
            get { return chkIsService.Checked; }
            set { chkIsService.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is taxable.
        /// </summary>
        /// <value><c>true</c> if this instance is taxable; otherwise, <c>false</c>.</value>
        public bool IsTaxable
        {
            get { return cboTaxable.EditValue == (object)0 ? true : false; }
            set { cboTaxable.SelectedIndex = value ? 1 : 0; }
        }

        public bool IsStock
        {
            get { return rndIsStock.SelectedIndex == 0 ? true : false; }
            set { rndIsStock.SelectedIndex = (value == false ? 1 : 0); }
        }

        #endregion

        #region  IStocksView

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                cboDefaultStockId.Properties.DataSource = value;
                cboDefaultStockId.Properties.ForceInitialize();
                cboDefaultStockId.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "StockCode",
                    ColumnCaption = "Mã kho",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 50,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "StockName",
                    ColumnCaption = "Tên Kho",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboDefaultStockId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultStockId.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboDefaultStockId.Properties.Columns[column.ColumnName].Visible = false;
                }
                cboDefaultStockId.Properties.DisplayMember = "StockName";
                cboDefaultStockId.Properties.ValueMember = "StockId";
            }
        }

        #endregion

        #region Property Accounts

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set
            {
                var inventoryAccounts = value.Where(a => a.DetailByInventoryItem).OrderBy(a => a.Grade).ToList();
                // ReSharper disable once InconsistentNaming
                var COGSAccounts = value.Where(a => a.AccountNumber.StartsWith("6") ||
                                                    a.AccountNumber.StartsWith("241") ||
                                                    a.AccountNumber.StartsWith("339") ||
                                                    a.AccountNumber.Equals("154")).OrderBy(a => a.AccountNumber).ThenBy(a => a.Grade).ToList();
                var saleAccounts = value.Where(a => a.AccountNumber.StartsWith("5") ||
                                                    a.AccountNumber.Equals("337")).OrderBy(a => a.AccountNumber).ThenBy(a => a.Grade).ToList();

                cboInventoryAccount.Properties.DataSource = inventoryAccounts;
                cboInventoryAccount.Properties.ForceInitialize();
                cboInventoryAccount.Properties.PopulateColumns();

                cboCOGSAccount.Properties.DataSource = COGSAccounts;
                cboCOGSAccount.Properties.ForceInitialize();
                cboCOGSAccount.Properties.PopulateColumns();

                cboSaleAccount.Properties.DataSource = saleAccounts;
                cboSaleAccount.Properties.ForceInitialize();
                cboSaleAccount.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "Số TK",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 50,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountName",
                    ColumnCaption = "Tên TK",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 200
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByContract", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByExpense", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCapitalPlan", ColumnVisible = false });
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
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByCurrency", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetExpense", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboInventoryAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboInventoryAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboCOGSAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboCOGSAccount.Properties.SortColumnIndex = column.ColumnPosition;

                        cboSaleAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboSaleAccount.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                    {
                        cboInventoryAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboCOGSAccount.Properties.Columns[column.ColumnName].Visible = false;
                        cboSaleAccount.Properties.Columns[column.ColumnName].Visible = false;
                    }
                }

                if (ActionMode == ActionModeEnum.AddNew)
                {
                    cboCOGSAccount.EditValue = @"631";
                    cboSaleAccount.EditValue = @"531";
                }
            }
        }

        #endregion

        #region IInventoryItemCategoriesView

        /// <summary>
        /// Sets the inventory item categories.
        /// </summary>
        /// <value>The inventory item categories.</value>
        public IList<InventoryItemCategoryModel> InventoryItemCategories
        {
            set
            {
                var data = value.Where(o => o.InventoryItemCategoryCode.Contains("CCDC")).FirstOrDefault();
                cboInventoryCategoryId.Properties.DataSource = data;
                cboInventoryCategoryId.Properties.ForceInitialize();
                cboInventoryCategoryId.Properties.PopulateColumns();
                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryCode",
                    ColumnCaption = "Mã loại VT, CCDC",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 50,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemCategoryName",
                    ColumnCaption = "Tên loại VT, CCDC",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 280
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });

                //foreach (var column in columnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        cboInventoryCategoryId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        cboInventoryCategoryId.Properties.SortColumnIndex = column.ColumnPosition;
                //    }
                //    else
                //        cboInventoryCategoryId.Properties.Columns[column.ColumnName].Visible = false;
                //}
                cboInventoryCategoryId.Properties.DisplayMember = "InventoryItemCategoryName";
                cboInventoryCategoryId.Properties.ValueMember = "InventoryItemCategoryId";
                cboInventoryCategoryId.SelectionStart = 1;
            }
        }

        #endregion

        #region IAccountingObjectsView

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                cboAccountingObjectId.Properties.DataSource = value;
                cboAccountingObjectId.Properties.ForceInitialize();
                cboAccountingObjectId.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectCode",
                    ColumnCaption = "Mã đối tượng",
                    ColumnVisible = true,
                    ColumnWith = 20,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectName",
                    ColumnCaption = "Tên đối tượng",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                //columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectID", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectCategoryId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Tel", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CompanyTaxCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "AreaCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactTitle", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactSex", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactMobile", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactEmail", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactOfficeTel", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactHomeTel", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ContactAddress", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsPersonal", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IdentificationNumber", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IssueDate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IssueBy", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryScaleId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Insured", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "LabourUnionFee", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FamilyDeductionAmount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsCustomerVendor", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryCoefficient", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "NumberFamilyDependent", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "EmployeeTypeId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryForm", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryPercentRate", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryAmount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "InsuranceAmount", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefTypeAO", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "SalaryGrade", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CustomField1", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CustomField2", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CustomField3", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CustomField4", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "CustomField5", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsBornLeave", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TaxDepartmentName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TreasuryName", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "TreasuryManageFee", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "OrganizationManageFee", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "OrganizationFeeCode", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboAccountingObjectId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboAccountingObjectId.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        cboAccountingObjectId.Properties.Columns[column.ColumnName].Visible = false;
                }

                cboAccountingObjectId.Properties.DisplayMember = "AccountingObjectName";
                cboAccountingObjectId.Properties.ValueMember = "AccountingObjectId";
            }
        }


        #endregion

        #region Department
        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>The departments.</value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                lookUpDepartment.Properties.DataSource = value;
                lookUpDepartment.Properties.ForceInitialize();
                lookUpDepartment.Properties.PopulateColumns();

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentCode",
                    ColumnCaption = "Mã phòng ban",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    Alignment = HorzAlignment.Center
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentName",
                    ColumnCaption = "Tên phòng ban",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 170
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
                        lookUpDepartment.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpDepartment.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        lookUpDepartment.Properties.Columns[column.ColumnName].Visible = false;
                }
                lookUpDepartment.Properties.ValueMember = "DepartmentId";
                lookUpDepartment.Properties.DisplayMember = "DepartmentName";
            }
        }


        #endregion

        #region Overrides Function

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _stocksPresenter.DisplayByIsActive(true);
            _inventoryItemCategoriesPresenter.DisplayByIsTool(true, true);
            _accountingObjectsPresenters.DisplayActive(true);
            _departmentsPresenter.DisplayActive();
            if (KeyValue != null)
                _inventoryItemPresenter.Display(KeyValue);
            else
            {
                IsTool = true;
            }
            //else txtInventoryItemCode.Text = GetAutoNumber();
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            return _inventoryItemPresenter.Save();
        }

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            if (cboTaxable.SelectedIndex == 1)
            {
                cboTaxRate.Enabled = false;
                cboTaxRate.EditValue = null;
            }
        }

        /// <summary>
        ///     Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(InventoryItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemToolCode"),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventoryItemCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(InventoryItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemToolName"),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventoryItemName.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Form Event

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrmToolDetail" /> class.
        /// </summary>
        public FrmToolDetail()
        {
            InitializeComponent();
            _inventoryItemPresenter = new InventoryItemPresenter(this);
            _stocksPresenter = new StocksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _inventoryItemCategoriesPresenter = new InventoryItemCategoriesPresenter(this);
            _accountingObjectsPresenters = new AccountingObjectsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraToolDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraToolDetail_Load(object sender, EventArgs e)
        {
            groupControl1.Enabled = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTaxable control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboTaxable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTaxable.SelectedIndex == 1)
            {
                cboTaxRate.Enabled = false;
                cboTaxRate.EditValue = null;
            }
            else
            {
                cboTaxRate.Enabled = true;
                cboTaxRate.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the cboDefaultStockId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cboDefaultStockId_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDefaultStockId.EditValue == null) return;
            var accountNumber = (string)cboDefaultStockId.GetColumnValue("DefaultAccountNumber");
            cboInventoryAccount.EditValue = accountNumber;
        }

        private void rndCashWithDrawType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((bool)rndIsStock.EditValue == true)
                groupControl1.Enabled = true;
            else
                groupControl1.Enabled = false;
        }


        private void cboAccountingObjectId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmXtraAccountingObjectDetail frmAccountingObjectDetail = new FrmXtraAccountingObjectDetail();
                frmAccountingObjectDetail.ShowDialog();
                if (frmAccountingObjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                    {
                        _accountingObjectsPresenters.DisplayActive(true);
                        cboAccountingObjectId.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                    }
                }
            }
        }

        private void cboDefaultStockId_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmStockDetail frmStockDetail = new FrmStockDetail();
                frmStockDetail.ShowDialog();
                if (frmStockDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.StockIDInventoryItemDetailForm))
                    {
                        _stocksPresenter.DisplayByIsActive(true);
                        cboDefaultStockId.EditValue = GlobalVariable.StockIDInventoryItemDetailForm;
                    }
                }
            }
        }

        private void cboInventoryAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountsPresenter.DisplayActive();
                        cboInventoryAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;

                    }
                }
            }
        }

        private void cboCOGSAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountsPresenter.DisplayActive();
                        cboCOGSAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }

        private void cboSaleAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmAccountDetail = new FrmAccountDetail();
                frmAccountDetail.ShowDialog();
                if (frmAccountDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.AccountIDAccountTransferForm))
                    {
                        _accountsPresenter.DisplayActive();
                        cboSaleAccount.EditValue = GlobalVariable.AccountIDAccountTransferForm;
                    }
                }
            }
        }
        #endregion
    }
}