using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.PurchasePurpose;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.PurchasePurpose
{
    public partial class FrmPurchasePurposes : FrmBaseList, IPurchasePurposesView
    {
        /// <summary>
        /// The _stocks presenter
        /// </summary>
        private readonly PurchasePurposesPresenter _stocksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmPurchasePurposes"/> class.
        /// </summary>
        public FrmPurchasePurposes()
        {
            InitializeComponent();
            _stocksPresenter = new PurchasePurposesPresenter(this);
        }

        public IList<PurchasePurposeModel> PurchasePurposes {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasePurposeId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasePurposeCode", ColumnCaption = "Mã nhóm HHDV mua vào", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PurchasePurposeName", ColumnCaption = "Tên nhóm HHDV mua vào", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnCaption = "Hệ thống", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 30 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _stocksPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PurchasePurposePresenter(null).Delete(PrimaryKeyValue);
        }
    }
}
