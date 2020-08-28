/***********************************************************************
 * <copyright file="FrmContractDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, October 27, 2017lkuBankAccount
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, October 27, 2017Author SonTV  Description 
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObjectCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using System.Linq;
using System.Reflection;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using BuCA.Application.iBigTime2020.Session;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;
using XtraColumn = Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid.XtraColumn;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSource;
using System.Data;
using DevExpress.Data.Mask;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Contract
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmContractDetail : FrmXtraBaseTreeDetail, IContractView, IAccountingObjectsView, IProjectsView, ICurrenciesView, IBudgetSourcesView
    {
        private readonly ProjectsPresenter _ProjectsPresenter;
        private readonly ContractPresenter _ContractPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private IList<AccountingObjectModel> _accountingObjects;
        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCurrency;
        private GridView _gridLookUpEditCurrencyView;
        private List<CurrencyModel> _currencies;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;
        private List<BudgetSourceModel> _budgetSourceModels;

        /// <summary>
        /// Initializes a new instance of the <see cref=""/> class.
        /// </summary>
        public FrmContractDetail()
        {
            InitializeComponent();
            _currenciesPresenter = new CurrenciesPresenter(this);
            _ProjectsPresenter = new ProjectsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _ContractPresenter = new ContractPresenter(this);
            barManager1.AllowShowToolbarsPopup = false;
            barManager1.StatusBar.Visible = false;
        }

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            dateSign.Properties.MaxValue = DateTime.Now;
            dateStartDate.Properties.MaxValue = DateTime.Now;
            dateFinishDate.EditValue = DateTime.Now;

            base.InitControls();
        }
        private void dateStart_Leave(object sender, EventArgs e)
        {
            //Valid_dtPostedDate();
        }

        private void dateEnd_Leave(object sender, EventArgs e)
        {
            //Valid_dtPostedDate();
        }
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountingObjectsPresenter.DisplayByIsCustomerVendor(true);
            _ProjectsPresenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _ContractPresenter.Display(KeyValue);
            if (KeyValue != null)
            {
                //_ContractPresenter.Display(KeyValue);
                if (!string.IsNullOrEmpty(VendorId))
                {
                    txtVendorBank.Text = _accountingObjects.Where(x => x.AccountingObjectId == VendorId).ToList().Count != 0 ? _accountingObjects.Where(x => x.AccountingObjectId == VendorId).FirstOrDefault().BankName : "";
                }
            }
            else
            {
                dateStartDate.EditValue = DateTime.Now;
                dateFinishDate.EditValue = DateTime.Now;
                dateSign.EditValue = DateTime.Now;
            }

            #region dinh dang so tien tren tab phu luc hop dong

            gridViewContract.Columns["ExchangeValue"].DisplayFormat.FormatType = FormatType.Numeric;
            gridViewContract.Columns["ExchangeValue"].DisplayFormat.FormatString = "C";

            gridViewContract.Columns["ExchangeRate"].DisplayFormat.FormatType = FormatType.Numeric;
            gridViewContract.Columns["ExchangeRate"].DisplayFormat.FormatString = "C";

            gridViewContract.Columns["Prices"].DisplayFormat.FormatType = FormatType.Numeric;
            gridViewContract.Columns["Prices"].DisplayFormat.FormatString = "C";

            #endregion
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(ContractNo))
            {
                XtraMessageBox.Show("Bạn chưa nhập số hợp đồng",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContractNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ContractName))
            {
                XtraMessageBox.Show("Bạn chưa nhập tên hợp đồng",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContractName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ProjectId))
            {
                XtraMessageBox.Show("Bạn chưa chọn dự án",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                lkUpTargetProgram.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override string SaveData()
        {
            var result = _ContractPresenter.Save();
            GlobalVariable.ContractIDDetailForm = result;
            return result;
        }
        #endregion

        #region Event

        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Handles the EditValueChanged event of the lkUpTargetProgram control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lkUpTargetProgram_EditValueChanged(object sender, EventArgs e)
        {

            if (lkUpTargetProgram.GetColumnValue("ProjectCode") != null)
                txtTargetContractName.EditValue = (string)lkUpTargetProgram.GetColumnValue("ProjectName");
            else
                txtTargetContractName.EditValue = "";
        }

        private void lkUpTargetProgram_KeyDown(object sender, KeyEventArgs e)
        {
            if (lkUpTargetProgram.SelectionLength == lkUpTargetProgram.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                lkUpTargetProgram.EditValue = null;
                e.Handled = true;
            }
        }

        private void lkUpTargetProgram_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                FrmProjectDetail FrmProjectDetail = new FrmProjectDetail();
                FrmProjectDetail.ShowDialog();
                if (FrmProjectDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.ProjectIDAccountingObjectDetailForm))
                    {
                        _ProjectsPresenter.Display();
                        lkUpTargetProgram.EditValue = GlobalVariable.ProjectIDAccountingObjectDetailForm;
                    }
                }
            }
        }

        private void lkVendor_EditValueChanged(object sender, EventArgs e)
        {
            //txtVendorBank.Text = _accountingObjects.Where(x => x.AccountingObjectId == VendorId).FirstOrDefault().BankName;
        }

        #endregion

        #region Implement
        public string ContractId { get; set; }

        public string ContractNo
        {
            get { return txtContractNo.Text.Trim(); }
            set { txtContractNo.Text = value; }

        }

        public string ContractName
        {
            get { return txtContractName.Text.Trim(); }
            set { txtContractName.Text = value; }

        }

        public string ContractNameEnglish
        {
            get { return txtContractNameEnglish.Text == null ? null : txtContractNameEnglish.Text.Trim(); }
            set { txtContractNameEnglish.Text = value; }

        }

        public DateTime SignDate
        {
            get { return (DateTime)dateSign.EditValue; }
            set { dateSign.EditValue = value; }

        }

        public DateTime StartDate
        {
            get { return (DateTime)dateStartDate.EditValue; }
            set { dateStartDate.EditValue = value; }
        }

        public DateTime EndDate
        {
            get { return (DateTime)dateFinishDate.EditValue; }
            set { dateFinishDate.EditValue = value; }
        }

        public string CurrencyCode
        {
            get { return lhkCurrencyCode.EditValue.ToString(); }
            set { lhkCurrencyCode.EditValue = value; }
        }

        public decimal ExchangeRate
        {
            get { return (decimal)lhkExchange.Value; }
            set { lhkExchange.Value = value; }
        }

        public decimal AmountOC
        {
            get { return (decimal)lhkTotalAmountOC.Value; }
            set { lhkTotalAmountOC.Value = value; }
        }

        public string ProjectId
        {
            get { return lkUpTargetProgram.EditValue.ToString(); }
            set { lkUpTargetProgram.EditValue = value; }
        }

        public string Description
        {
            get { return txtDescription.EditValue == null ? "" : txtDescription.EditValue.ToString(); }
            set { txtDescription.Text = value; }
        }

        private BankModel VendorBankSelected = null;
        public string VendorId
        {
            get
            {
                if (lkVendor.EditValue == null) return null;
                if (string.IsNullOrEmpty(lkVendor.EditValue.ToString())) return null;
                return lkVendor.EditValue.ToString();
            }
            set { lkVendor.EditValue = value; }
        }
        public string VendorBankAccountId
        {
            get
            {
                var accountingObject = _accountingObjects.Where(x => x.AccountingObjectId == VendorId).FirstOrDefault();
                if (accountingObject != null) return accountingObject.BankAccount;
                return null;
            }
            set { txtVendorBank.Text = _accountingObjects.Where(x => x.AccountingObjectId == VendorId).ToList().Count != 0 ? _accountingObjects.Where(x => x.AccountingObjectId == VendorId).FirstOrDefault().BankAccount : ""; }
        }

        public bool IsActive
        {
            get { return cbIsActive.Checked; }
            set { cbIsActive.Checked = value; }
        }

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                if (value == null)
                    value = new List<AccountingObjectModel>();
                _accountingObjects = value;
                //value.Insert(0, new AccountingObjectModel() { AccountingObjectId = CommonText.AllText, AccountingObjectName = CommonText.AllText, AccountingObjectCode = CommonText.AllText });

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectCode), ColumnCaption = "Mã đối tượng", ColumnVisible = true, ColumnWith = 120, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = nameof(AccountingObjectModel.AccountingObjectName), ColumnCaption = "Tên đối tượng", ColumnVisible = true, ColumnWith = 250, ColumnPosition = 2 });

                lkVendor.Properties.DataSource = value;
                lkVendor.Properties.PopulateColumns();
                lkVendor.Properties.DisplayMember = nameof(AccountingObjectModel.AccountingObjectName);
                lkVendor.Properties.ValueMember = nameof(AccountingObjectModel.AccountingObjectId);
                ShowXtraColumnInLookUpEdit<AccountingObjectModel>(gridColumnsCollection, lkVendor);
                //lkVendor.ItemIndex = 0;
            }
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                var lstProject = value.Where(p => p.ObjectType == 2).ToList();
                if (lstProject == null)
                    lstProject = new List<ProjectModel>();

                var gridColumnsCollection = new List<XtraColumn>();
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã CTMT, dự án", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
                gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên CTMT, dự án", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });

                lkUpTargetProgram.Properties.DataSource = lstProject;
                lkUpTargetProgram.Properties.PopulateColumns();
                lkUpTargetProgram.Properties.DisplayMember = nameof(ProjectModel.ProjectCode);
                lkUpTargetProgram.Properties.ValueMember = nameof(ProjectModel.ProjectId);
                ShowXtraColumnInLookUpEdit<ProjectModel>(gridColumnsCollection, lkUpTargetProgram);
                //lkUpTargetProgram.ItemIndex = 0;
            }
        }

        public IList<CurrencyModel> Currencies
        {
            //set
            //{
            //    if (value == null)
            //        value = new List<CurrencyModel>();

            //    var gridColumnsCollection = new List<XtraColumn>();
            //    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã loại tiền", ColumnVisible = true, ColumnWith = 140, ColumnPosition = 1 });
            //    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên loại tiền", ColumnVisible = true, ColumnWith = 350, ColumnPosition = 2 });


            //}
            //get { return _currencies; }
            set
            {
                try
                {
                    _gridLookUpEditCurrencyView = new GridView();
                    _gridLookUpEditCurrencyView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditCurrency = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditCurrencyView,
                        TextEditStyle = TextEditStyles.Standard,
                    };
                    _gridLookUpEditCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditCurrency.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditCurrency.PopupFormSize = new Size(368, 150);
                    _gridLookUpEditCurrency.View.BestFitColumns();

                    _gridLookUpEditCurrency.DataSource = value;
                    _gridLookUpEditCurrencyView.PopulateColumns(value);
                    _currencies = value.ToList();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Mã loại tiền",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CurrencyName",
                        ColumnCaption = "Tên loại tiền",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditCurrencyView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditCurrency.DisplayMember = "CurrencyCode";
                    _gridLookUpEditCurrency.ValueMember = "CurrencyId";

                    lhkCurrencyCode.Properties.DataSource = value;
                    lhkCurrencyCode.Properties.PopulateColumns();
                    lhkCurrencyCode.Properties.DisplayMember = nameof(CurrencyModel.CurrencyCode);
                    lhkCurrencyCode.Properties.ValueMember = nameof(CurrencyModel.CurrencyId);
                    ShowXtraColumnInLookUpEdit<CurrencyModel>(gridColumnsCollection, lhkCurrencyCode);
                    lhkCurrencyCode.ItemIndex = 2;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    var budgetSourceModels = value.Where(o => o.IsParent == false && o.IsActive == true).ToList();
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

                    _gridLookUpEditBudgetSource.DataSource = budgetSourceModels;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(budgetSourceModels);
                    _budgetSourceModels = budgetSourceModels.ToList();

                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Mã nguồn vốn",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetSourceName",
                        ColumnCaption = "Tên nguồn vốn",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSavingExpenses", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCategoryId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceProperty", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "PayableBankAccountId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsSelfControl", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceId";
                    _gridLookUpEditBudgetSourceView = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridViewReponsitory();
                    _gridLookUpEditBudgetSource = XtraColumnCollectionHelper<BudgetSourceModel>.CreateGridLookUpEditReponsitory(_gridLookUpEditBudgetSourceView, budgetSourceModels, "BudgetSourceCode", "BudgetSourceId", gridColumnsCollection);
                    XtraColumnCollectionHelper<BudgetSourceModel>.ShowXtraColumnInGridView(gridColumnsCollection, _gridLookUpEditBudgetSourceView);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        RepositoryItemDateEdit SDate;
        #endregion
        public List<ContractDetailsModel> ContractDetails
        {
            get
            {
                var contract = new List<ContractDetailsModel>();
                if (gridViewContract.DataSource != null && gridViewContract.RowCount != 0)
                {
                    for (int i = 0; i < gridViewContract.RowCount; i++)
                    {
                        var contractDetail = (ContractDetailsModel)gridViewContract.GetRow(i);
                        if (contractDetail != null)
                        {
                            var item = new ContractDetailsModel
                            {
                                ContractDetailID = contractDetail.ContractDetailID,
                                ContractID = contractDetail.ContractID,
                                BudgetSourceId = contractDetail.BudgetSourceId,
                                SignDate = contractDetail.SignDate == null ? DateTime.Now.Date : contractDetail.SignDate.Date,
                                CurrencyId = contractDetail.CurrencyId,
                                ExchangeRate = contractDetail.ExchangeRate,
                                ExchangeValue = contractDetail.ExchangeValue,
                                Prices = contractDetail.Prices,
                                Description = contractDetail.Description,
                                AddendumNo = contractDetail.AddendumNo

                            };
                            contract.Add(item);
                        }
                    }
                }
                return contract;
            }
            set
            {
                SDate = new RepositoryItemDateEdit();
                SDate.Mask.MaskType = MaskType.DateTimeAdvancingCaret;
                SDate.EditFormat.FormatType = FormatType.DateTime;    // cái SDate này sinh ra để làm theo yêu cầu của Mrs.Mai, cho sửa ngày tháng thì tự động chuyển sang tháng khi sửa ngày xong, tương tự với tháng và năm
                SDate.EditFormat.FormatString = "dd/MM/yyyy";
                SDate.EditMask = "dd/MM/yyyy";
                SDate.Mask.EditMask = "dd/MM/yyyy";

                bindingSourceContract.DataSource = value ?? new List<ContractDetailsModel>();
                gridViewContract.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>()
                {
                    new XtraColumn{ColumnName = "ContractDetailID", ColumnVisible = false, AllowEdit = true},
                    new XtraColumn{ColumnName = "ContractID", ColumnVisible = false, AllowEdit = true},
                    new XtraColumn{ColumnName = "Description", ColumnVisible = false, AllowEdit = true},
                    new XtraColumn
                    {
                        ColumnName = "AddendumNo",
                        ColumnCaption = "Phụ lục số",
                        ColumnPosition = 1,
                        ColumnWith = 92,
                        ColumnVisible = true,
                        AllowEdit = true
                    },
                    new XtraColumn
                    {
                        ColumnName = "SignDate",
                        ColumnCaption = "Ngày ký",
                        ColumnPosition = 2,
                        ColumnWith = 90,
                        ColumnVisible = true,
                        AllowEdit = true,
                        RepositoryControl = SDate
                    },
                    new XtraColumn
                    {
                        ColumnName = "CurrencyId",
                        ColumnCaption = "Loại tiền",
                        ColumnPosition = 3,
                        ColumnWith = 90,
                        ColumnVisible = true,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditCurrency
                    },
                    new XtraColumn
                    {
                        ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 4,
                        ColumnWith = 90,
                        ColumnVisible = true,
                        AllowEdit = true,
                        DisplayFormat = "N",

                    },
                    new XtraColumn
                    {
                        ColumnName = "BudgetSourceId",
                        ColumnCaption = "Nguồn vốn",
                        ColumnPosition = 5,
                        ColumnWith = 92,
                        ColumnVisible = true,
                        AllowEdit = true,
                        RepositoryControl = _gridLookUpEditBudgetSource
                    },
                    new XtraColumn
                    {
                        ColumnName = "Prices",
                        ColumnCaption = "Nguyên tệ",
                        ColumnPosition = 6,
                        ColumnWith = 92,
                        ColumnVisible = true,
                        AllowEdit = true,
                        DisplayFormat = "N",
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "ExchangeValue",
                        ColumnCaption = "Giá trị quy đổi",
                        ColumnPosition = 7,
                        ColumnWith = 92,
                        ColumnVisible = true,
                        DisplayFormat = "N1",
                        //AllowEdit = true
                    },
                    new XtraColumn{ColumnName = "Stt", ColumnVisible = false, AllowEdit = true},
                };
                gridViewContract = InitGridLayout(columnsCollection, gridViewContract);
                SetNumericFormatControl(gridViewContract, true);
                gridViewContract.OptionsView.ShowFooter = false;
                gridViewContract.ViewCaption = "";
            }
        }
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
                    //grdView.Columns[column.ColumnName].ColumnEditName
                    if (column.IsSummaryText)
                    {
                        grdView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        grdView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }

                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }

            return grdView;
        }
        private void lhkExchange_ValueChanged(object sender, EventArgs e)
        {
            lhkTotalAmountExchange.Value = lhkExchange.Value * lhkTotalAmountOC.Value;
        }

        private void lhkTotalAmountOC_ValueChanged(object sender, EventArgs e)
        {
            lhkTotalAmountExchange.Value = lhkExchange.Value * lhkTotalAmountOC.Value;
        }

        private void lookUpEditAccountingObject_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                using (var frmDetail = new FrmXtraAccountingObjectDetail())
                {
                    frmDetail.ShowDialog();
                    if (frmDetail.CloseBox)
                    {
                        if (!string.IsNullOrEmpty(GlobalVariable.AccountingObjectIDInventoryItemDetailForm))
                        {
                            _accountingObjectsPresenter.Display();
                            lkVendor.EditValue = GlobalVariable.AccountingObjectIDInventoryItemDetailForm;
                        }
                    }
                }
            }

        }

        private void FormatNumber_KeyUp(object sender, KeyEventArgs e)
        {
            lhkTotalAmountOC.ThousandsSeparator = true;
            lhkExchange.ThousandsSeparator = true;
            lhkTotalAmountExchange.ThousandsSeparator = true;
            lhkTotalAmountOC.Select(lhkTotalAmountOC.Text.Length, 0);
            lhkExchange.Select(lhkExchange.Text.Length, 0);
            lhkTotalAmountExchange.Select(lhkTotalAmountExchange.Text.Length, 0);
        }

        private void gridViewContract_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                switch (e.Column.FieldName)
                {
                    case "ExchangeRate":
                    case "Prices":
                        {
                            var exchangeRate = (decimal)gridViewContract.GetRowCellValue(e.RowHandle, "ExchangeRate");
                            var prices = (decimal)gridViewContract.GetRowCellValue(e.RowHandle, "Prices");
                            var exchangeValue = (decimal)gridViewContract.GetRowCellValue(e.RowHandle, "ExchangeValue");

                            if (exchangeValue != exchangeRate * prices)
                            {
                                gridViewContract.SetRowCellValue(e.RowHandle, "ExchangeValue", exchangeRate * prices);
                            }
                        }
                        break;
                    case "ExchangeValue":
                        {
                            decimal sumPrice = 0;
                            for (int i = 0; i < gridViewContract.RowCount; i++)
                            {
                                var xxx = gridViewContract.GetRowCellValue(i, "ExchangeValue");
                                if (xxx != null)
                                    sumPrice = sumPrice + (decimal)gridViewContract.GetRowCellValue(i, "ExchangeValue");
                            }

                            //gridViewContract.Columns["ExchangeValue"].EditValue = sumPrice;
                        }
                        break;
                    case "CurrencyId":
                        {
                            var Mai = gridViewContract.GetRowCellValue(e.RowHandle, "CurrencyId");
                            var MM = gridViewContract.GetRowCellDisplayText(e.RowHandle, "CurrencyId");
                            if (MM.ToString() == "VND") gridViewContract.SetFocusedRowCellValue("ExchangeRate", "1");
                            break;
                        }

                }

            }
            catch (Exception) { }
        }

        private void gridViewContract_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridViewContract.SetFocusedRowCellValue("SignDate", DateTime.Now.Date);
            gridViewContract.SetFocusedRowCellValue("ExchangeRate", "1");
        }

        private void gridViewContract_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var rowH = gridViewContract.FocusedRowHandle;
            var focusRow = (ContractDetailsModel)gridViewContract.GetFocusedRow();
            if (focusRow == null)
            {
                return;
            }
            if (rowH >= 0)
            {
                popupMenu1.ShowPopup(barManager1, new Point(MousePosition.X, MousePosition.Y));
            }
            else popupMenu1.HidePopup();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var focusRow = (ContractDetailsModel)gridViewContract.GetFocusedRow();
            var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"), ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                gridViewContract.DeleteRow(this.gridViewContract.FocusedRowHandle);
                _ContractPresenter.DeleteContractDetail(focusRow.ContractDetailID);
            }
            
        }
    }
}