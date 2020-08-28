
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
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AudittingLog;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Contract;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.Project;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Contract
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmContracts : FrmBaseTreeList, IContractsView
    {
        private readonly ContractsPresenter _contractsPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountCategoryKind;
        private readonly AudittingLogPresenter _audittingLogPresenter;

        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBanks"/> class.
        /// </summary>
        public FrmContracts()
        {         
            InitializeComponent();
            InitRepositoryControlData();
            _contractsPresenter = new ContractsPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        #endregion

        #region properties

        public IList<ContractModel> Contracts
        {
            set
            {
            
                try
                {
                    treeList.DataSource = value ?? new List<ContractModel>();
                    for (var i = 0; i < treeList.Columns.Count; i++)
                    {
                        if (treeList.Columns[i].FieldName != "ContractName" && treeList.Columns[i].FieldName != "StartDate" && treeList.Columns[i].FieldName != "EndDate" && treeList.Columns[i].FieldName != "ContractNo" && treeList.Columns[i].FieldName != "IsActive")
                        {
                            treeList.Columns[i].Visible = false;
                        }
                    }
                    treeList.Columns["ContractName"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["ContractName"].Width = 300;
                    treeList.Columns["ContractName"].Caption = @"Tên hợp đồng";
                    treeList.Columns["StartDate"].OptionsColumn.AllowEdit = false;                   
                    treeList.Columns["StartDate"].Caption = @"Ngày bắt đầu";
                    treeList.Columns["StartDate"].Width = 100;
                    treeList.Columns["EndDate"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["EndDate"].Caption = @"Ngày kết thúc";
                    treeList.Columns["EndDate"].Width = 100;
                    treeList.Columns["ContractNo"].OptionsColumn.AllowEdit = false;
                    treeList.Columns["ContractNo"].Caption = @"Số hợp đồng";
                    treeList.Columns["IsActive"].OptionsColumn.AllowEdit = true;
                    treeList.Columns["IsActive"].Caption = "Được sử dụng";

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        //#region override methods

       
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmContractDetail();
        }

        //#endregion

        protected override void LoadDataIntoTree()
        {
            _contractsPresenter.Display();
        }
       
        /// <summary>
        /// Deletes the item.
        /// </summary>
        protected override void DeleteTree()
        {
           new ContractPresenter(null).Delete(PrimaryKeyValue);   
        }

        protected override void ShowErrorDeleteParent()
        {
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContractHasChild"),
                ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #region private helper

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
