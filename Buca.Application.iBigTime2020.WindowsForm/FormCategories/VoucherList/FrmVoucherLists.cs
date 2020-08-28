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
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.VoucherList;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.Data;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.VoucherList
{
    public partial class FrmVoucherLists : FrmBaseList, IVoucherListsView
    {
        private readonly VoucherListsPresenter _voucherListsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmVoucherLists"/> class.
        /// </summary>
        public FrmVoucherLists()
        {
            InitializeComponent();
            _voucherListsPresenter = new VoucherListsPresenter(this);
        }

        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <value>
        /// The voucher lists.
        /// </value>
        public IList<VoucherListModel> VoucherLists
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherListId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherListCode", ColumnCaption = "Số chứng từ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherListName", ColumnCaption = "Tên chứng từ ghi sổ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromDate", ColumnCaption = "Ngày bắt đầu", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.DateTime, DisplayFormat = "dd/MM/yyyy"});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToDate", ColumnCaption = "Ngày kết thúc", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.DateTime, DisplayFormat = "dd/MM/yyyy" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 120, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentAttached", ColumnCaption = "Chứng từ kèm theo", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Center });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _voucherListsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new VoucherListPresenter(null).Delete(PrimaryKeyValue);
        }

        //#endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmVoucherListDetail();
        }
    }
}
