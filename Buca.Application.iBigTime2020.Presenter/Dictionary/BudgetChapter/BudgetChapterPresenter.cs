/***********************************************************************
 * <copyright file="FrmXtraFixedAssetCategoryTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetChapter
{
    /// <summary>
    /// Class BudgetChapterPresenter.
    /// </summary>
    public class BudgetChapterPresenter : Presenter<IBudgetChapterView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetChapterPresenter(IBudgetChapterView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget chapter identifier.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        public void Display(string budgetChapterId)
        {
            if (budgetChapterId == null)
            {
                View.BudgetChapterId = null;
                return;
            }
            var budgetChapter = Model.GetBudgetChapter(budgetChapterId);
            View.BudgetChapterId = budgetChapter.BudgetChapterId;
            View.BudgetChapterCode = budgetChapter.BudgetChapterCode;
            View.BudgetChapterName = budgetChapter.BudgetChapterName;
            View.IsActive = budgetChapter.IsActive;
        }

        /// <summary>
        /// Deletes the specified budget chapter identifier.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>System.Int32.</returns>
        public string Delete(string budgetChapterId)
        {
            return Model.DeleteBudgetChapter(budgetChapterId);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public string Save()
        {
            var budgetChapter = new BudgetChapterModel
            {
                BudgetChapterId = View.BudgetChapterId,
                BudgetChapterCode = View.BudgetChapterCode,
                BudgetChapterName = View.BudgetChapterName,
                IsActive = View.IsActive
            };

            if (string.IsNullOrEmpty(View.BudgetChapterId))
                return Model.AddBudgetChapter(budgetChapter);
            return Model.UpdateBudgetChapter(budgetChapter);
        }
    }
}
