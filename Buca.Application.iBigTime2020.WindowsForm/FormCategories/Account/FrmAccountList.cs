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
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using BuCA.Application.iBigTime2020.Report.BaseParameterForm;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Account
{
    public partial class FrmAccountList : FrmXtraBaseParameter, IAccountsView
    {
        public bool StateCheck { get; set; } //Khi người dùng thao tác chọn trên Lưới IsActive = false, IsNotAcctive =false
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly AccountsPresenter _accountsPresenter;
        public int RowForcus { get; set; } // Dòng đang trỏ đến
        private string Condition = "";

        private TextEdit TxtTextEdit;

        public FrmAccountList()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
        }

        public FrmAccountList(string condition, TextEdit txTextEdit)
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            this.Condition = condition;
            this.TxtTextEdit = txTextEdit;
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                grdlookUpAccount.DataSource = value.Where(x => x.IsActive).ToList();
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "Mã TK",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 150
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnVisible = true,
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnWith = 253
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountCategoryId",
                        ColumnVisible = false,
                        ColumnCaption = "Nhóm tài khoản",
                        ColumnPosition = 3,
                        ColumnWith = 40
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountCategoryKind",
                        ColumnCaption = "Tính chất",
                        ColumnPosition = 4,
                        ColumnVisible = false,
                        ColumnWith = 40
                    },
                    new XtraColumn {ColumnName = "DetailByCurrency", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetExpense", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountForeignName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetSource", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetChapter", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetKindItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBudgetSubItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByMethodDistribute", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByAccountingObject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByProject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByTask", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailBySupply", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByInventoryItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByFixedAsset", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByFund", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByBankAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByProjectActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "DetailByInvestor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "IsActive",
                        ColumnVisible = false,
                        ColumnCaption = "Được sử dụng",
                        ColumnPosition = 5,
                        ColumnWith = 40
                    },
                    new XtraColumn {ColumnName = "IsDisplayOnAccountBalanceSheet", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsDisplayBalanceOnReport", ColumnVisible = false}
                };


                foreach (var column in columnsCollection)
                {
                    if (gridViewAccount.Columns[column.ColumnName] != null)
                        if (column.ColumnVisible)
                        {
                            gridViewAccount.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridViewAccount.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridViewAccount.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            gridViewAccount.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        private void FrmAccountList_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridViewAccount);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            StateCheck = true;
            SetChecked();
            gridViewAccount.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void gridViewAccount_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewAccount.CalcHitInfo(((MouseEventArgs)e).Location);
            if (!hi.InColumn && hi.InRowCell)
                if (gridViewAccount.FocusedRowHandle > -1)
                {
                    RowForcus = gridViewAccount.FocusedRowHandle;
                    StateCheck = false;
                    bool flag = Selection.IsRowSelected(gridViewAccount.FocusedRowHandle);
                    Selection.SelectRow(gridViewAccount.FocusedRowHandle, !flag);
                }
        }

        private void SetChecked()
        {
            if (gridViewAccount.RowCount > 0)
            {
                for (int i = 0; i < gridViewAccount.RowCount; i++)
                {
                    var accountNumber = gridViewAccount.GetRowCellValue(i, "AccountNumber");
                    Selection.SelectRow(i, (";" + Condition + ";").Contains(";" + accountNumber + ";"));
                }
            }
        }

        public string ClauseAccount { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TxtTextEdit.Text = GetWhereAccount();
        }

        public string GetWhereAccount()
        {
            string whereClause = "";

            if (gridViewAccount.DataSource != null && gridViewAccount.RowCount > 0)
            {
                for (var i = 0; i < gridViewAccount.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountModel)gridViewAccount.GetRow(i);
                        whereClause = whereClause + row.AccountNumber + ";";
                    }
                }
            }
            if (whereClause != "")
            {
                whereClause = whereClause.Substring(0, whereClause.Length - 1);
            }
            return whereClause;
        }
    }
}
