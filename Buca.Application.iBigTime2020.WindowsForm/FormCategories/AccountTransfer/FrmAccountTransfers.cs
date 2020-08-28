/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 10, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using BuCA.Enum;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountTransfer;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AccountTransfer
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmAccountTransfers : FrmBaseList, IAccountTransfersView
    {
        private readonly AccountTransfersPresenter _accountTransfersPresenter;
        private RepositoryItemLookUpEdit _repositoryAccountTransferSide;
        private RepositoryItemLookUpEdit _repositoryAccountTransferBusinessType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAccountTransfers"/> class.
        /// </summary>
        public FrmAccountTransfers()
        {
            InitializeComponent();
            InitRepositoryControlData();
            _accountTransfersPresenter = new AccountTransfersPresenter(this);
        }

        /// <summary>
        /// Sets the account tranfers.
        /// </summary>
        /// <value>
        /// The account tranfers.
        /// </value>
        public IList<AccountTransferModel> AccountTranfers
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountTransferId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountTransferCode", ColumnCaption = "Mã TK kết chuyển", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromAccount", ColumnCaption = "Từ Tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToAccount", ColumnCaption = "Đến tài khoản", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TransferSide", ColumnCaption = "Bên kết chuyển", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default, RepositoryControl = _repositoryAccountTransferSide });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BusinessType", ColumnCaption = "Loại kết chuyển", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 120, Alignment = HorzAlignment.Default, RepositoryControl = _repositoryAccountTransferBusinessType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ReferentAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TransferOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountTransfersPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AccountTransferPresenter(null).Delete(PrimaryKeyValue);
        }

        //#endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmAccountTransferDetail();
        }

        #region private helper

        /// <summary>
        /// Initializes the repository control data.
        /// </summary>
        private void InitRepositoryControlData()
        {
            var accountTransferSide = typeof(AccountTransferSide).ToList();
            var accountTransferBusinessType = typeof(AccountTransferBusinessType).ToList();
            _repositoryAccountTransferSide = new RepositoryItemLookUpEdit
            {
                DataSource = accountTransferSide,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryAccountTransferBusinessType = new RepositoryItemLookUpEdit
            {
                DataSource = accountTransferBusinessType,
                DisplayMember = "Value",
                ValueMember = "Key",
                ShowHeader = false
            };
            _repositoryAccountTransferSide.PopulateColumns();
            _repositoryAccountTransferSide.Columns["Key"].Visible = false;
            _repositoryAccountTransferBusinessType.PopulateColumns();
            _repositoryAccountTransferBusinessType.Columns["Key"].Visible = false;
        }

        #endregion
    }
}
