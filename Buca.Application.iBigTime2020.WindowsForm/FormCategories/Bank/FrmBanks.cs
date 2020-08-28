// ***********************************************************************
// Assembly         : A-BIGTIME2018
// Author           : thangnd
// Created          : 10-09-2017
//
// Last Modified By : thangnd
// Last Modified On : 10-27-2017
// ***********************************************************************
// <copyright file="FrmBanks.cs" company="BuCA JSC">
//     Copyright © BuCA JSC
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Bank;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Bank
{
    /// <summary>
    /// Class FrmAccountingCategories.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    public partial class FrmBanks : FrmBaseList, IBanksView
    {
        private readonly BanksPresenter _banksPresenter;
        
        #region event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBanks"/> class.
        /// </summary>
        public FrmBanks()
        {
            InitializeComponent();
            //InitRepositoryControlData();
            _banksPresenter = new BanksPresenter(this);
        }

        #endregion

        #region properties

        public IList<BankModel> Banks
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản ngân hàng, kho bạc", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên tài khoản ngân hàng, kho bạc", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAddress", ColumnCaption = "Địa chỉ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsOpenInBank", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
                //TienNV 29/6/2020
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Used", ColumnCaption = "Used", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 20 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortBank", ColumnCaption = "SortBank", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 20 });

            }
        }

        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _banksPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BankPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion
    }
}
