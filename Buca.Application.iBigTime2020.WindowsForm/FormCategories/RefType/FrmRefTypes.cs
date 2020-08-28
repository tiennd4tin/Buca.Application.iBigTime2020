using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.EmployeeType;
using Buca.Application.iBigTime2020.Presenter.Dictionary.RefType;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.FormCategories.EmployeeType;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.RefType
{
    /// <summary>
    /// FrmRefTypes
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList.FrmBaseList" />
    /// <seealso cref="Buca.Application.iBigTime2020.View.Dictionary.IRefTypesView" />
    public partial class FrmRefTypes : FrmBaseList,IRefTypesView
    {
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRefTypes"/> class.
        /// </summary>
        public FrmRefTypes()
        {
            InitializeComponent();
            _refTypesPresenter= new RefTypesPresenter(this);
        }

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes {
            set
            {
                grdList.DataSource = value;
                gridView.PopulateColumns();

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeId",
                    ColumnVisible = false,
                    ColumnPosition = 1,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeName",
                    ColumnCaption = "Loại chứng từ",
                    ColumnVisible = true,
                    ColumnPosition = 1,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultDebitAccountCategoryId",
                    ColumnCaption = "Lọc TK nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultDebitAccountId",
                    ColumnVisible = true,
                    ColumnPosition = 3,
                    ColumnWith = 80,
                    AllowEdit = false,
                    ColumnCaption = @"Tk nợ ngầm định"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultCreditAccountCategoryId",
                    ColumnCaption = "Lọc Tk có",
                    ColumnVisible = true,
                    ColumnPosition = 4,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultCreditAccountId",
                    ColumnCaption = "Tk có ngầm định",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultTaxAccountCategoryId",
                    ColumnVisible = true,
                    ColumnPosition = 6,
                    ColumnWith = 80,
                    AllowEdit = false,
                    ColumnCaption = @"Lọc Tk thuế"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultTaxAccountId",
                    ColumnCaption = "Tk thuế ngầm định",
                    ColumnVisible = true,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FunctionId",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeCategoryId",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MasterTableName",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DetailTableName",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "LayoutMaster",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "LayoutDetail",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AllowDefaultSetting",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Postable",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Searchable",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "SortOrder",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "SubSystem",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
            }
        }

        #region override methods

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _refTypesPresenter.Display();
        }

        /// <summary>
        /// Gets the form detail.
        /// LinhMC comment method này lại.
        /// </summary>
        /// <returns>
        /// FrmXtraBaseCategoryDetail.
        /// </returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmRefTypeDetail();
        }

        #endregion
    }
}
