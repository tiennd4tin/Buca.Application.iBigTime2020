using System.Collections;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AccountCategory;
using Buca.Application.iBigTime2020.Presenter.Dictionary.Currency;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using BuCA.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.Currency
{
    public partial class FrmCurrencies : FrmBaseList, ICurrenciesView
    {
        private readonly CurrenciesPresenter _currenciesPresenter;
        #region event
        public FrmCurrencies()
        {
            InitializeComponent();
            _currenciesPresenter = new CurrenciesPresenter(this);
        }
        #endregion
        #region properties

        public IList<CurrencyModel> Currencies
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Near });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnCaption = "Tiền tố", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnCaption = "Hậu tố", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnCaption = "Là đồng tiền hạch toán", ColumnPosition = 6, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });

            }
        }
        #endregion

        #region override methods

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _currenciesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CurrencyPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmCurrencyDetail();
        }

    }
}
