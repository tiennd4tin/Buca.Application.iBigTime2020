/***********************************************************************
 * <copyright file="BudgetChapterEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;


namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class BudgetChapterEntity.
    /// </summary>
    public class BudgetChapterEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterEntity"/> class.
        /// </summary>
        public BudgetChapterEntity()
        {
            AddRule(new ValidateRequired("BudgetChapterCode"));
            AddRule(new ValidateRequired("BudgetChapterName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterEntity" /> class.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetChapterName">Name of the budget chapter.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public BudgetChapterEntity(string budgetChapterId, string budgetChapterCode, string budgetChapterName, bool isActive)
            : this()
        {
            BudgetChapterId = budgetChapterId;
            BudgetChapterCode = budgetChapterCode;
            BudgetChapterName = budgetChapterName;
            IsActive = isActive;
        }
        
        /// <summary>
        /// Gets or sets the budget chapter identifier.
        /// </summary>
        /// <value>The budget chapter identifier.</value>
        public string BudgetChapterId { get; set; }
        
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the budget chapter.
        /// </summary>
        /// <value>The name of the budget chapter.</value>
        public string BudgetChapterName { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}
