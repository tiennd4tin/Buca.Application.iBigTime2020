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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// Interface IBudgetSourceView
    /// </summary>
    public interface IBudgetSourceView : IView
    {
        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
         string BudgetSourceId { get; set; }

         /// <summary>
         /// Gets or sets the budget source code.
         /// </summary>
         /// <value>
         /// The budget source code.
         /// </value>
         string BudgetSourceCode { get; set; }

         /// <summary>
         /// Gets or sets the name of the budget source.
         /// </summary>
         /// <value>
         /// The name of the budget source.
         /// </value>
         string BudgetSourceName { get; set; }

         /// <summary>
         /// Gets or sets the parent identifier.
         /// </summary>
         /// <value>
         /// The parent identifier.
         /// </value>
         string ParentId { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether [is parent].
         /// Gets or sets a value indicating whether [is parent].
         /// </summary>
         /// <value>
         ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
         /// </value>
         bool IsParent { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether [is saving expenses].
         /// </summary>
         /// <value>
         ///   <c>true</c> if [is saving expenses]; otherwise, <c>false</c>.
         /// </value>
         bool IsSavingExpenses { get; set; }

         /// <summary>
         /// Gets or sets the budget source category identifier.
         /// </summary>
         /// <value>
         /// The budget source category identifier.
         /// </value>
         string BudgetSourceCategoryId { get; set; }

         /// <summary>
         /// Gets or sets the budget source property.
         /// </summary>
         /// <value>
         /// The budget source property.
         /// </value>
         int BudgetSourceProperty { get; set; }

         /// <summary>
         /// Gets or sets the bank account.
         /// </summary>
         /// <value>
         /// The bank account.
         /// </value>
         string BankAccountId { get; set; }

         /// <summary>
         /// Gets or sets the payable bank account.
         /// </summary>
         /// <value>
         /// The payable bank account.
         /// </value>
         string PayableBankAccountId { get; set; }

         /// <summary>
         /// Gets or sets the target code.
         /// </summary>
         /// <value>
         /// The target code.
         /// </value>
         string ProjectId { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether [is self control].
         /// </summary>
         /// <value>
         ///   <c>true</c> if [is self control]; otherwise, <c>false</c>.
         /// </value>
         bool IsSelfControl { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether [is active].
         /// </summary>
         /// <value>
         ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
         /// </value>
         bool IsActive { get; set; }

        /// <summary>
        /// Get or set BudgetCode
        /// </summary>
        /// <value>
        ///   The target code
        /// </value>
        string BudgetCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget source.
        /// </summary>
        /// <value>
        /// The type of the budget source.
        /// </value>
        short BudgetSourceType { get; set; }
    }
}