/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  10/10/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceFormNumber;
using Buca.Application.iBigTime2020.Presenter.Dictionary.InvoiceType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.InvoiceFormNumber
{
    /// <summary>
    /// FrmInvoiceFormNumbers
    /// </summary>
    public partial class FrmInvoiceFormNumbers : FrmBaseList, IInvoiceFormNumbersView, IInvoiceTypiesView
    {
        /// <summary>
        /// The _invoice form numbers presenter
        /// </summary>
        private readonly InvoiceFormNumbersPresenter _invoiceFormNumbersPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditInvoiceFormNumberCategory;
        private GridView _gridLookUpEditInvoiceFormNumberCategoryView;
        private readonly InvoiceTypiesPresenter _invoiceTypiesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmInvoiceFormNumbers"/> class.
        /// </summary>
        public FrmInvoiceFormNumbers()
        {
            InitializeComponent();
            _invoiceFormNumbersPresenter = new InvoiceFormNumbersPresenter(this);
            _invoiceTypiesPresenter = new InvoiceTypiesPresenter(this);
        }

        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <value>
        /// The voucher lists.
        /// </value>
        public IList<InvoiceFormNumberModel> InvoiceFormNumbers
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberCode", ColumnCaption = "Mẫu số", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceFormNumberName", ColumnCaption = "Tên mẫu", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InvoiceType", ColumnCaption = "Loại hóa đơn", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Default, RepositoryControl = _gridLookUpEditInvoiceFormNumberCategory});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
            }
        }

        public IList<InvoiceTypeModel> InvoiceTypies
        {
            set
            {
                try
                {
                    //RepositoryItemGridLookUpEdit VoucherType
                    _gridLookUpEditInvoiceFormNumberCategoryView = new GridView();
                    _gridLookUpEditInvoiceFormNumberCategoryView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditInvoiceFormNumberCategory = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditInvoiceFormNumberCategoryView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditInvoiceFormNumberCategory.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditInvoiceFormNumberCategory.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditInvoiceFormNumberCategory.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditInvoiceFormNumberCategory.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditInvoiceFormNumberCategory.View.BestFitColumns();

                    _gridLookUpEditInvoiceFormNumberCategory.DataSource = value;
                    _gridLookUpEditInvoiceFormNumberCategoryView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "InvoiceTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "InvoiceTypeCode", ColumnVisible = false},
                        new XtraColumn { ColumnName = "InvoiceTypeName", ColumnCaption = "Loại hóa đơn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 320 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditInvoiceFormNumberCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditInvoiceFormNumberCategoryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditInvoiceFormNumberCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditInvoiceFormNumberCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditInvoiceFormNumberCategory.DisplayMember = "InvoiceTypeName";
                    _gridLookUpEditInvoiceFormNumberCategory.ValueMember = "InvoiceTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _invoiceTypiesPresenter.Display();
            _invoiceFormNumbersPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new InvoiceFormNumberPresenter(null).Delete(PrimaryKeyValue);
        }
    }
}
