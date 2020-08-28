/***********************************************************************
 * <copyright file="UserControlBudgetChapterList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter;
using Buca.Application.iBigTime2020.View.Dictionary;
using Buca.Application.iBigTime2020.WindowsForm.Code.PropertyGrid;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormList;
using DevExpress.Utils;

namespace Buca.Application.iBigTime2020.WindowsForm.FormCategories.BudgetChapter
{
    /// <summary>
    /// Class UserControlBudgetChapterList.
    /// </summary>
    public partial class FrmBudgetChapters : FrmBaseList, IBudgetChaptersView
    {
        /// <summary>
        /// The _budget chapter presenter
        /// </summary>
        private readonly BudgetChaptersPresenter _budgetChapterPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmBudgetChapters"/> class.
        /// </summary>
        public FrmBudgetChapters()
        {
            InitializeComponent();
            _budgetChapterPresenter = new BudgetChaptersPresenter(this);
        }

        #region IBudgetChaptersView Members
        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>The budget chapters.</value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                var budgetChapters = value.OrderBy(v => v.BudgetChapterCode).ToList();
                ListBindingSource.DataSource = budgetChapters;
                gridView.PopulateColumns(budgetChapters);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterCode",
                    ColumnCaption = "Mã chương",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 70,
                    Alignment = HorzAlignment.Near,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetChapterName",
                    ColumnCaption = "Tên chương",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "IsActive",
                    ColumnCaption = "Được sử dụng",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 150,
                    Alignment = HorzAlignment.Center
                });
            }
        }
        #endregion

        #region protected overrides method
        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _budgetChapterPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BudgetChapterPresenter(null).Delete(PrimaryKeyValue);
        }
        #endregion
    }
}
