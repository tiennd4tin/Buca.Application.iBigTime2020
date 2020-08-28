using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.AutoBusinessParallel;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.AutoBusinessParallel
{
    /// <summary>
    /// Class FrmAutoBusinessParallels.
    /// </summary>
    public partial class FrmAutoBusinessParallels : FrmBaseList, IAutoBusinessParallelsView
    {
        private readonly AutoBusinessParallelsPresenter _autoBusinessParallelsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmAutoBusinessParallels"/> class.
        /// </summary>
        public FrmAutoBusinessParallels()
        {
            InitializeComponent();
            _autoBusinessParallelsPresenter = new AutoBusinessParallelsPresenter(this);
        }
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            try
            {
                return new FrmAutoBusinessParallelDetail(Int32.Parse(OldAutoBusinessParallels[0].AutoBusinessCode));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #region Auto Business Parallel

        #region Form event

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _autoBusinessParallelsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>;
        protected override void DeleteGrid()
        {
            new AutoBusinessParallelPresenter(null).Delete(PrimaryKeyValue);
        }

        #endregion
        public IList<AutoBusinessParallelModel> OldAutoBusinessParallels { get; set; }
        public IList<AutoBusinessParallelModel> AutoBusinessParallels
        {
            set
            {
                value = value.OrderBy(o => o.AutoBusinessCode).ToList();
                OldAutoBusinessParallels = value.OrderByDescending(o => o.AutoBusinessCode).ToList();
                gridView.OptionsView.AllowHtmlDrawHeaders = true;
                gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;

                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessParallelId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessCode", ColumnVisible = true, ColumnCaption = "Mã định khoản", ColumnPosition = 1, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessName", ColumnVisible = true, ColumnCaption = "Tên định khoản", ColumnPosition = 1, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccount", ColumnCaption = "Tài khoản nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccount", ColumnCaption = "Tài khoản có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccountParallel", ColumnCaption = "Tài khoản nợ\nđồng thời", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccountParallel", ColumnCaption = "Tài khoản có\nđồng thời", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCodeParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetKindItemCodeParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubKindItemCodeParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCodeParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCodeParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MethodDistributeIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CashWithDrawTypeIdParallel", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
            }
        }

        #endregion
    }
}
