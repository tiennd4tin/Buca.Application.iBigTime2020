/***********************************************************************
 * <copyright file="FrmFundStructureDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, October 27, 2017
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Department;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using System.Linq;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetItem;
using Buca.Application.iBigTime2020.Presenter.Dictionary.CashWithdrawType;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Department;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountingObject;
using BuCA.Application.iBigTime2020.Session;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FundStructure
{

    /// <summary>
    /// FrmXtraAccountingObjectDetail class
    /// </summary>
    internal partial class FrmFundStructureDetail : FrmXtraBaseTreeDetail, IFundStructureView, IFundStructuresView, IBudgetItemsView, ICashWithdrawTypesView
    //, IAccountingObjectView, IBanksView, IAccountingObjectCategoriesView
    {
        #region Initialize

        /// <summary>
        /// The _accounting object presenter
        /// </summary>

        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        /// <summary>
        /// The cash withdraw types presenter
        /// </summary>
        private readonly CashWithdrawTypesPresenter _cashWithdrawTypesPresenter;

        private readonly FundStructurePresenter _fundStructurePresenter;
        /// <summary>
        /// The fund structures presenter{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountingObjectDetail" /> class.
        /// </summary>
        public FrmFundStructureDetail()
        {
            InitializeComponent();
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _cashWithdrawTypesPresenter = new CashWithdrawTypesPresenter(this);
            _fundStructurePresenter = new FundStructurePresenter(this);
            _fundStructuresPresenter = new FundStructuresPresenter(this);

        }

        #region Implement


        #region CashWithdrawTypeModels
        /// <summary>
        /// Sets the cash withdraw type models.
        /// </summary>
        /// <value>
        /// The cash withdraw type models.
        /// </value>
        public IList<CashWithdrawTypeModel> CashWithdrawTypeModels
        {
            set
            {
                try
                {
                    lookUpCashWithdrawType.Properties.DataSource = value;
                    lookUpCashWithdrawType.Properties.PopulateColumns();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "CashWithdrawTypeName",
                        ColumnCaption = "Nghiệp vụ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawNo", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "SubSystemId", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            lookUpCashWithdrawType.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            //lookUpCashWithdrawType.Properties.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            lookUpCashWithdrawType.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            lookUpCashWithdrawType.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    lookUpCashWithdrawType.Properties.DisplayMember = "CashWithdrawTypeName";
                    lookUpCashWithdrawType.Properties.ValueMember = "CashWithdrawTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion



        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    lookUpBudgetItem.Properties.DataSource = value.Where(v => Int32.Parse(v.BudgetItemCode) >= 9200 && Int32.Parse(v.BudgetItemCode) <= 9400).ToList();
                    lookUpBudgetItem.Properties.PopulateColumns();
                    var gridColumnsCollection = new List<XtraColumn>();
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemCode",
                        ColumnCaption = "Mã Mục",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                    gridColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "BudgetItemName",
                        ColumnCaption = "Tên Mục",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 250
                    });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemType", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            lookUpBudgetItem.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            lookUpBudgetItem.Properties.SortColumnIndex = column.ColumnPosition;
                            lookUpBudgetItem.Properties.PopupWidth = 500;
                            lookUpBudgetItem.Properties.Columns[2].Width = 300;
                            lookUpBudgetItem.Properties.Columns[1].Width = 100;
                        }
                        else lookUpBudgetItem.Properties.Columns[column.ColumnName].Visible = false;
                    }
                    lookUpBudgetItem.Properties.ValueMember = "BudgetItemId";
                    lookUpBudgetItem.Properties.DisplayMember = "BudgetItemName";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                lkuFundStructure.Properties.DataSource = value;
                lkuFundStructure.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "FundStructureCode", ColumnCaption = "Mã khoản chi", ColumnPosition = 1, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "FundStructureName", ColumnCaption = "Tên khoản chi", ColumnPosition = 1, ColumnVisible = true },
                                             new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false },
                                             new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                                             new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                                             new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                                             new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                                             new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Inactive", ColumnCaption = "Được sử dụng", ColumnPosition = 1, ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false },
                                                 new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false },
                                                  new XtraColumn { ColumnName = "IsProjectExpense", ColumnVisible = false },
                                                  new XtraColumn { ColumnName = "IsAllocateExpense", ColumnVisible = false },
                                                  new XtraColumn { ColumnName = "IsExpenseNoBuilding", ColumnVisible = false }
                                            };
                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lkuFundStructure.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lkuFundStructure.Properties.SortColumnIndex = column.ColumnPosition;
                        lkuFundStructure.Properties.PopupWidth = 500;
                        lkuFundStructure.Properties.Columns[2].Width = 300;
                        lkuFundStructure.Properties.Columns[1].Width = 100;
                    }
                    else lkuFundStructure.Properties.Columns[column.ColumnName].Visible = false;
                }
                lkuFundStructure.Properties.ValueMember = "FundStructureId";
                lkuFundStructure.Properties.DisplayMember = "FundStructureCode";
            }
        }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the fund structure code.
        /// </summary>
        /// <value>The fund structure code.</value>
        public string FundStructureCode
        {
            get
            {
                return txtFundStructureCode.Text.Trim();
            }

            set
            {
                txtFundStructureCode.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the fund structure.
        /// </summary>
        /// <value>The name of the fund structure.</value>
        public string FundStructureName
        {
            get
            {
                return txtFundStructureNames.Text.Trim();
            }

            set
            {
                txtFundStructureNames.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the buca code identifier.
        /// </summary>
        /// <value>The buca code identifier.</value>
        public string BUCACodeId
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public string ParentId
        {
            get
            {
                return lkuFundStructure.EditValue == null ? "" : (lkuFundStructure.EditValue).ToString();
            }

            set
            {
                lkuFundStructure.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the inactive.
        /// </summary>
        /// <value>The inactive.</value>
        public bool Inactive
        {
            get
            {
                return cbIsActive.Checked;
            }

            set
            {
                cbIsActive.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets the investment period.
        /// </summary>
        /// <value>The investment period.</value>
        public int? InvestmentPeriod
        {
            get
            {
                return (int?)lookUpInvestmentPeriod.EditValue;
            }

            set
            {
                lookUpInvestmentPeriod.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the is parent.
        /// </summary>
        /// <value>The is parent.</value>
        public bool IsParent
        {
            get;

            set;
        }

        /// <summary>
        /// Gets or sets the is system.
        /// </summary>
        /// <value>The is system.</value>
        public bool IsSystem
        {
            get;

            set;
        }

        public string BudgetItemId
        {
            get { return lookUpBudgetItem.EditValue == null ? "" : lookUpBudgetItem.EditValue.ToString(); }
            set { lookUpBudgetItem.EditValue = value; }
        }

        public int CashWithdrawTypeId
        {
            get { return (int)lookUpCashWithdrawType.EditValue; }
            set { lookUpCashWithdrawType.EditValue = value; }
        }

        public bool IsProjectExpense
        {
            get { return checkEdit1.Checked; }
            set { checkEdit1.Checked = value; }
        }

        public bool IsAllocateExpense
        {
            get { return checkEdit2.Checked; }
            set { checkEdit2.Checked = value; }
        }

        public bool IsExpenseNoBuilding
        {
            get { return checkEdit3.Checked; }
            set { checkEdit3.Checked = value; }
        }
        #endregion

        #region override

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            base.InitControls();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {

            _budgetItemsPresenter.DisplayActive(true);
            _cashWithdrawTypesPresenter.DisplayList();
            _fundStructuresPresenter.Display();
            if (KeyValue != null)
            {
                _fundStructurePresenter.Display(KeyValue);
                if (lkuFundStructure.GetColumnValue("FundStructureName") != null)
                    txtFundStructureName.EditValue = lkuFundStructure.GetColumnValue("FundStructureName").ToString();
            }
            BindLookUpInvestPeriod();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns>System.Boolean.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(FundStructureCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFundStructureCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFundStructureCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FundStructureName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFundStructureName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFundStructureNames.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string SaveData()
        {
            var result = _fundStructurePresenter.Save();
            if (!String.IsNullOrEmpty(result))
                GlobalVariable.FundStructDetailIDFundStructForm = result;
            return result;
        }
        #endregion

        #region Event

        /// <summary>
        /// Lbs the tax code click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void lbTaxCode_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Texts the tax code edit value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void txtTaxCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cbs the is active checked changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void cbIsActive_CheckedChanged(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// Luks the execution unit edit value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void lukExecutionUnit_EditValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Lkus the fund structure edit value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void lkuFundStructure_EditValueChanged(object sender, EventArgs e)
        {
            if (lkuFundStructure.GetColumnValue("FundStructureName") != null)
                txtFundStructureName.EditValue = lkuFundStructure.GetColumnValue("FundStructureName").ToString();
        }

        /// <summary>
        /// Binds the look up invest period.
        /// </summary>
        protected void BindLookUpInvestPeriod()
        {
            var bankSource = new List<ComboLookUpItem> { new ComboLookUpItem { Id = 0, Name = "Giai đoạn chuẩn bị đầu tư" }, new ComboLookUpItem { Id = 1, Name = "Giai đoạn thực hiện đầu tư" }, new ComboLookUpItem { Id = 2, Name = "Giai đoạn kết thúc xây dựng, đưa dự án vào khai thác sử dụng" }, new ComboLookUpItem { Id = 3, Name = "Chi phí Ban quản lý dự án" } };
            lookUpInvestmentPeriod.Properties.DataSource = bankSource;
            lookUpInvestmentPeriod.Properties.PopulateColumns();
            var treeColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "Id", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "Name", ColumnCaption = "Giai đoạn đầu tư", ColumnPosition = 1, ColumnVisible = true }
                                            };
            foreach (var column in treeColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    lookUpInvestmentPeriod.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    lookUpInvestmentPeriod.Properties.SortColumnIndex = column.ColumnPosition;
                }
                else lookUpInvestmentPeriod.Properties.Columns[column.ColumnName].Visible = false;
            }
            lookUpInvestmentPeriod.Properties.ValueMember = "Id";
            lookUpInvestmentPeriod.Properties.DisplayMember = "Name";
        }
        private void lookUpBudgetItem_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                lookUpBudgetItem.EditValue = null;
            }
        }
        private void lookUpInvestmentPeriod_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                lookUpInvestmentPeriod.EditValue = null;
            }
        }
        private void lkuFundStructure_ButtonClick(object sender,
        DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmFundStructDetail = new FrmFundStructureDetail();
                frmFundStructDetail.ShowDialog();
                if (frmFundStructDetail.CloseBox)
                {
                    if (!string.IsNullOrEmpty(GlobalVariable.FundStructDetailIDFundStructForm))
                    {
                        _fundStructuresPresenter.Display();
                        lkuFundStructure.EditValue = GlobalVariable.FundStructDetailIDFundStructForm;
                    }
                }
            }
        }
        #endregion
    }
}