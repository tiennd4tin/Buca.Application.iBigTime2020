﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Cash;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Cash.PaymentVoucher;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Account;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Activity;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InventoryItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Stock;
using Buca.Application.iBigTime2020.View.Cash;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using BuCA.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory
{
    /// <summary>
    /// Class FrmCAReceiptInwards.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseVoucherList" />
    public partial class FrmCAPaymentInwards : FrmBaseVoucherList, ICAPaymentsView, IAccountingObjectsView, IAccountsView, IFundStructuresView, IStocksView,
        IInventoryItemsView, IActivitysView
    {
        private readonly CAPaymentsPresenter _paymentsPresenter;
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly StocksPresenter _stocksPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;

        #region RepositoryItemGridLookUpEdit

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccount;
        private GridView _gridLookUpEditAccountView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private GridView _gridLookUpEditAccountingObjectView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditFundStructure;
        private GridView _gridLookUpEditFundStructureView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditInventoryItem;
        private GridView _gridLookUpEditInventoryItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditStock;
        private GridView _gridLookUpEditStockView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditActivity;
        private GridView _gridLookUpEditActivityView;


        #endregion

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        private static IModel Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCAReceipts"/> class.
        /// </summary>
        public FrmCAPaymentInwards()
        {
            InitializeComponent();

            _paymentsPresenter = new CAPaymentsPresenter(this);
            _activitysPresenter = new ActivitysPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _stocksPresenter = new StocksPresenter(this);

            Model = new Model.Model();
        }

        /// <summary>
        /// Sets the ca payments.
        /// </summary>
        /// <value>The ca payments.</value>
        public IList<CAPaymentModel> CAPayments
        {
            set
            {
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "PostedDate",
                    ColumnCaption = "Ngày hạch toán",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 40,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefNo",
                    ColumnCaption = "Số chứng từ",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InwardRefNo",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDate",
                    ColumnCaption = "Ngày chứng từ",
                    ColumnType = UnboundColumnType.DateTime,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    Alignment = HorzAlignment.Center,
                    ColumnWith = 40,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "JournalMemo",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalAmount",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnType = UnboundColumnType.Decimal,
                    ColumnWith = 40
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityId",
                    ColumnVisible = true,
                    ColumnWith = 130,
                    ColumnCaption = "Công việc",
                    ColumnPosition = 41,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditActivity
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParalellRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentIncluded", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnVisible = false,
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefType",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Address",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Receiver", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalTaxAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Posted", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IncrementRefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalFreightAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalInwardAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalPaymentAmount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RelationRefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CaPaymentDetailTaxes", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailPurchases", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailFixedAssets", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CAPaymentDetailParallels", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountingObjectsPresenter.DisplayActive(true);
            _fundStructuresPresenter.Display();
            _accountsPresenter.DisplayActive();
            _inventoryItemsPresenter.DisplayByIsActive(true);
            _stocksPresenter.DisplayByIsActive(true);
            _activitysPresenter.DisplayActive(true);
            _paymentsPresenter.Display((int)BuCA.Enum.RefType.INInward);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(string refId)
        {
            if (refId != null)
            {
                var paymentModel = Model.GetPaymentVoucherDetailPurchase(refId);

                bindingSourceDetail.DataSource = paymentModel.CAPaymentDetailPurchases;
                gridDetail.DataSource = paymentModel.CAPaymentDetailPurchases;
                gridViewDetail.PopulateColumns(bindingSourceDetail.DataSource);

                var columnsCollection = new List<XtraColumn>();
                columnsCollection.Add(new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "RefId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemId",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ColumnCaption = "Mã hàng",
                    ColumnPosition = 1,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditInventoryItem
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnVisible = true,
                    ColumnWith = 150,
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 2,
                    AllowEdit = true,
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "StockId",
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnCaption = "Kho",
                    ColumnPosition = 3,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditStock
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DebitAccount",
                    ColumnVisible = true,
                    RepositoryControl = _gridLookUpEditAccount,
                    ColumnWith = 90,
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 4,
                    AllowEdit = true
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CreditAccount",
                    ColumnVisible = true,
                    ColumnWith = 90,
                    ColumnCaption = "TK Có",
                    ColumnPosition = 5,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditAccount
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Unit",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ColumnCaption = "ĐVT",
                    ColumnPosition = 6,
                    AllowEdit = true,
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ColumnCaption = "Số lượng",
                    ColumnPosition = 7,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "QuantityConvert", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "UnitPrice",
                    ColumnVisible = true,
                    ColumnWith = 110,
                    ColumnCaption = "Đơn giá",
                    ColumnPosition = 8,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "UnitPriceConvert", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Amount",
                    ColumnVisible = true,
                    ColumnWith = 110,
                    ColumnCaption = "Thành tiền",
                    ColumnPosition = 9,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "ContractId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "CapitalPlanId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvType", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvSeries", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvNo", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "TaxRate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "TaxAmount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "TaxAccount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "PurchasePurposeId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "FreightAmount", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InwardAmount",
                    ColumnVisible = true,
                    ColumnWith = 110,
                    ColumnCaption = "Giá trị nhập kho",
                    ColumnPosition = 10,
                    IsSummnary = true,
                    AllowEdit = true,
                    ColumnType = UnboundColumnType.Decimal
                });
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ActivityId",
                    ColumnVisible = true,
                    ColumnWith = 110,
                    ColumnCaption = "Công việc",
                    ColumnPosition = 11,
                    IsSummnary = true,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditActivity
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetKindItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSubKindItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetSubItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "MethodDistributeId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "CashWithdrawTypeId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false});
                //columnsCollection.Add(new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectActivityId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectExpenseId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ListItemId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ExpiryDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "LotNo", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "Approved", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "SortOrder", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "BudgetDetailItemCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "InvoiceTypeCode", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "OrgRefNo", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "OrgRefDate", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FundStructureId",
                    ColumnVisible = false,
                    ColumnWith = 120,
                    ColumnCaption = "Cơ cấu vốn",
                    ColumnPosition = 11,
                    AllowEdit = true,
                    RepositoryControl = _gridLookUpEditFundStructure
                });
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectExpenseEAId", ColumnVisible = false});
                columnsCollection.Add(new XtraColumn {ColumnName = "ProjectActivityEAId", ColumnVisible = false});
                //gridViewDetail.InitGridLayout(columnsCollection);
                //SetNumericFormatControl(gridViewDetail, true);
                XtraColumnCollectionHelper<CAPaymentDetailPurchaseModel>.ShowXtraColumnInGridView(columnsCollection,
                    gridViewDetail);
            }
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CAPaymentPresenter(null).Delete(PrimaryKeyValue);
        }

        #region private helper

        #endregion

        #region IView

        #region IAccountsView

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
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
                        TextEditStyle = TextEditStyles.Standard,
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryKind", ColumnVisible = false, });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountForeignName", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSource", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetChapter", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetKindItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBudgetSubItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByMethodDistribute", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByAccountingObject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProject", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByTask", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBySupply", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInventoryItem", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFixedAsset", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByFund", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByBankAccount", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByProjectActivity", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DetailByInvestor", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false });

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditAccountView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditAccount.DisplayMember = "AccountNumber";
                    _gridLookUpEditAccount.ValueMember = "AccountNumber";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region AccountingObjects

        /// <summary>
        ///     Sets the accounting objects.
        /// </summary>
        /// <value>The accounting objects.</value>
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectCode",
                        ColumnCaption = "Mã đối tượng",
                        ColumnVisible = true,
                        ColumnWith = 120,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountingObjectName",
                        ColumnCaption = "Tên đối tượng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn {ColumnName = "AccountingObjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountingObjectCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Tel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Fax", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Website", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CompanyTaxCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BudgetCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AreaCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactTitle", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactSex", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactMobile", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactEmail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactOfficeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactHomeTel", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ContactAddress", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPersonal", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IdentificationNumber", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IssueBy", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryScaleId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Insured", ColumnVisible = false},
                    new XtraColumn {ColumnName = "LabourUnionFee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FamilyDeductionAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomerVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryCoefficient", ColumnVisible = false},
                    new XtraColumn {ColumnName = "NumberFamilyDependent", ColumnVisible = false},
                    new XtraColumn {ColumnName = "EmployeeTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryForm", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryPercentRate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPayInsuranceOnSalary", ColumnVisible = false},
                    new XtraColumn {ColumnName = "InsuranceAmount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsUnEmploymentInsurance", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeAO", ColumnVisible = false},
                    new XtraColumn {ColumnName = "SalaryGrade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField1", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField2", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField3", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField4", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CustomField5", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsPaidInsuranceForPayrollItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBornLeave", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TaxDepartmentName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "TreasuryName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };
                #region Lookup edit accounting objects

                _gridLookUpEditAccountingObjectView = new GridView();
                _gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditAccountingObjectView,
                    TextEditStyle = TextEditStyles.Standard,
                };
                _gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditAccountingObject.PopupFormSize = new Size(368, 150);

                _gridLookUpEditAccountingObject.View.BestFitColumns();

                _gridLookUpEditAccountingObject.DataSource = value;
                _gridLookUpEditAccountingObjectView.PopulateColumns(value);

                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _gridLookUpEditAccountingObjectView.Columns[column.ColumnName].Visible = false;
                }
                _gridLookUpEditAccountingObject.DisplayMember = "AccountingObjectName";
                _gridLookUpEditAccountingObject.ValueMember = "AccountingObjectId";

                #endregion
            }
        }

        #endregion

        /// <summary>
        /// Sets the inventory items.
        /// </summary>
        /// <value>The inventory items.</value>
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                try
                {
                    _gridLookUpEditInventoryItemView = new GridView();
                    _gridLookUpEditInventoryItemView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInventoryItem = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInventoryItemView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInventoryItem.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInventoryItem.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditInventoryItem.View.BestFitColumns();

                    _gridLookUpEditInventoryItem.DataSource = value;
                    _gridLookUpEditInventoryItemView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemCode",
                        ColumnCaption = "Mã hàng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "InventoryItemName",
                        ColumnCaption = "Tên hàng",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
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
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "TaxRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTool", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsService", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsTaxable", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInventoryItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInventoryItem.DisplayMember = "InventoryItemCode";
                    _gridLookUpEditInventoryItem.ValueMember = "InventoryItemId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                try
                {
                    _gridLookUpEditStockView = new GridView();
                    _gridLookUpEditStockView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditStock = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditStockView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditStock.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditStock.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditStock.PopupFormSize = new Size(368, 150);

                    _gridLookUpEditStock.View.BestFitColumns();

                    _gridLookUpEditStock.DataSource = value;
                    _gridLookUpEditStockView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockCode",
                        ColumnCaption = "Mã kho",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "StockName",
                        ColumnCaption = "Tên kho",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DefaultAccountNumber", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditStockView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditStockView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditStockView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditStockView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditStock.DisplayMember = "StockName";
                    _gridLookUpEditStock.ValueMember = "StockId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<ActivityModel> Activitys 
        {
            set
            {
                if (value == null)
                    value = new List<ActivityModel>();
                var gridColumnsCollection = new List<XtraColumn>();

                gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã công việc", ColumnVisible = true, ColumnWith = 100, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên công việc", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                _gridLookUpEditActivityView = XtraColumnCollectionHelper<ActivityModel>.CreateGridViewReponsitory();
                _gridLookUpEditActivity = XtraColumnCollectionHelper<ActivityModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditActivityView, value, "ActivityCode", "ActivityId", gridColumnsCollection);

                XtraColumnCollectionHelper<ActivityModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditActivityView);
                _gridLookUpEditActivity.EndUpdate();
            }
        }

        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return base.GetFormDetail();
        }

        #endregion

        protected override void ChangeFormDetail()
        {
            //if (string.IsNullOrEmpty(PrimaryKeyValue)) return;
            var obj = gridView.GetFocusedRow();
            if (obj == null)
            {
                SetFormDetail((int)RefType.INInward);
                return;
            }

            var model = (CAPaymentModel)obj;
            SetFormDetail(model.RefType);
        }
    }
}
