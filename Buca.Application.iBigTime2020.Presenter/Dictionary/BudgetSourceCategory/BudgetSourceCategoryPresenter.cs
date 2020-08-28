﻿/***********************************************************************
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

using Buca.Application.iBigTime2020.View.Dictionary;


namespace Buca.Application.iBigTime2020.Presenter.Dictionary.BudgetSourceCategory
{
    /// <summary>
    /// class BudgetSourceCategoryPresenter
    /// </summary>
    public class BudgetSourceCategoryPresenter : Presenter<IBudgetSourceCategoryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceCategoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourceCategoryPresenter(IBudgetSourceCategoryView view)
            : base(view)
        {
        }

        ///// <summary>
        ///// Displays the specified budgetSourceCategory identifier.
        ///// </summary>
        ///// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        //public void Display(string budgetSourceCategoryId)
        //{
        //    if (budgetSourceCategoryId == null) { View.BudgetSourceCategoryId = 0; return; }

        //    var budgetSourceCategory = Model.GetBudgetSourceCategory(int.Parse(budgetSourceCategoryId));

        //    View.BudgetSourceCategoryId = budgetSourceCategory.BudgetSourceCategoryId;
        //    View.BudgetSourceCategoryCode = budgetSourceCategory.BudgetSourceCategoryCode;
        //    View.BudgetSourceCategoryName = budgetSourceCategory.BudgetSourceCategoryName;
        //    View.Description = budgetSourceCategory.Description;
        //    View.IsActive = budgetSourceCategory.IsActive;
        //    View.IsSummaryEstimateReport = budgetSourceCategory.IsSummaryEstimateReport;
        //}

        ///// <summary>
        ///// Saves this instance.
        ///// </summary>
        ///// <returns></returns>
        //public int Save()
        //{
        //    var budgetSourceCategory = new BudgetSourceCategoryModel
        //    {
        //        BudgetSourceCategoryId = View.BudgetSourceCategoryId,
        //        BudgetSourceCategoryCode = View.BudgetSourceCategoryCode,
        //        BudgetSourceCategoryName = View.BudgetSourceCategoryName,
        //        Description = View.Description,
        //        IsActive = View.IsActive,
        //        IsSummaryEstimateReport = View.IsSummaryEstimateReport
        //    };

        //    return View.BudgetSourceCategoryId == 0 ? Model.AddBudgetSourceCategory(budgetSourceCategory) : Model.UpdateBudgetSourceCategory(budgetSourceCategory);
        //}

        ///// <summary>
        ///// Deletes the specified accont identifier.
        ///// </summary>
        ///// <param name="accountId">The accont identifier.</param>
        ///// <returns></returns>
        //public int Delete(int accountId)
        //{
        //    return Model.DeleteBudgetSourceCategory(accountId);
        //}
    }
}
