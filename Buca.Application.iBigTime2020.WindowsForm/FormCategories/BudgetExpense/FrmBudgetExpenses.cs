using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetExpense;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetExpense
{
    /// <summary>
    /// Class FrmBudgetExpenses.
    /// </summary>
    public partial class FrmBudgetExpenses : FrmBaseList, IBudgetExpensesView
    {
        private readonly BudgetExpensesPresenter _budgetExpensesPresenter;
        private RepositoryItemLookUpEdit _repositoryBudgetExpenseType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetExpenses"/> class.
        /// </summary>
        public FrmBudgetExpenses()
        {
            InitializeComponent();
            _budgetExpensesPresenter = new BudgetExpensesPresenter(this);
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            InitRepositoryControlData();
            _budgetExpensesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BudgetExpensePresenter(null).Delete(PrimaryKeyValue);
        }

        /// <summary>
        /// Sets the budget expenses.
        /// </summary>
        /// <value>The budget expenses.</value>
        public IList<BudgetExpenseModel> BudgetExpenses
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetExpenseId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseCode",
                    ColumnVisible = true,
                    ColumnCaption = "Mã phí, lệ phí",
                    ColumnWith = 100,
                    ColumnPosition = 1
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseName",
                    ColumnVisible = true,
                    ColumnCaption = "Tên phí, lệ phí",
                    ColumnWith = 200,
                    ColumnPosition = 2
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetExpenseType",
                    ColumnVisible = true,
                    ColumnCaption = "Loại",
                    ColumnWith = 70,
                    ColumnPosition = 3,
                    RepositoryControl = _repositoryBudgetExpenseType
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnVisible = true,
                    ColumnCaption = "Được sử dụng",
                    ColumnWith = 70,
                    ColumnPosition = 4
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
            }
        }

        #region private helper

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var budgetExpenseType = typeof(BudgetExpenseType).ToList();
            _repositoryBudgetExpenseType = new RepositoryItemLookUpEdit
            {
                DataSource = budgetExpenseType,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryBudgetExpenseType.PopulateColumns();
            _repositoryBudgetExpenseType.Columns["Key"].Visible = false;
        }

        #endregion
    }
}
