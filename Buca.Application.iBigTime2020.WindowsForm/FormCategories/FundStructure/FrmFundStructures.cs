
using System;
using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountingObject;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Project;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FundStructure;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.FundStructure
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmFundStructures : FrmBaseTreeList, IFundStructuresView
    {
        private readonly FundStructuresPresenter _fundStructuresPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBanks" /> class.
        /// </summary>
        public FrmFundStructures()
        {
            InitializeComponent();
            InitRepositoryControlData();
            _fundStructuresPresenter = new FundStructuresPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }



        #endregion

        #region properties

        /// <summary>
        /// Sets the fund structures.
        /// </summary>
        /// <value>The fund structures.</value>
        public IList<FundStructureModel> FundStructures
        {
            set
            {
                treeList.DataSource = value;
                treeList.PopulateColumns();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureCode", ColumnCaption = "Mã khoản chi", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureName", ColumnCaption = "Tên khoản chi", ColumnPosition = 2, ColumnWith = 300, ColumnVisible = true });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "FundStructureId", ColumnVisible = false });


                ColumnsCollection.Add(new XtraColumn { ColumnName = "BUCACodeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvestmentPeriod", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithdrawTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsProjectExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsAllocateExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsExpenseNoBuilding", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnWith = 100, ColumnVisible = true });

                foreach (var column in ColumnsCollection)
                {
                    if (treeList.Columns[column.ColumnName] != null)
                        if (column.ColumnVisible)
                        {
                            treeList.Columns[column.ColumnName].Width = 0;

                            treeList.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            treeList.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            treeList.Columns[column.ColumnName].Width = column.ColumnWith;
                            treeList.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                            treeList.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            treeList.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;

                        }
                        else
                        {
                            treeList.Columns[column.ColumnName].Visible = false;
                        }
                }
            }
        }

        #endregion

        //#region override methods


        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns>FrmXtraBaseTreeDetail.</returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmFundStructureDetail();
        }

        //#endregion

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _fundStructuresPresenter.Display();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected override void DeleteTree()
        {


            new FundStructurePresenter(null).Delete(PrimaryKeyValue);

            LoadData();
            SetRowSelected();
        }

        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteFundStructureHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #region private helper

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var accountKind = typeof(AccountKind).ToList();
            _repositoryAccountCategoryKind = new RepositoryItemLookUpEdit
            {
                DataSource = accountKind,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryAccountCategoryKind.PopulateColumns();
            _repositoryAccountCategoryKind.Columns["Key"].Visible = false;
        }

        #endregion
    }
}
