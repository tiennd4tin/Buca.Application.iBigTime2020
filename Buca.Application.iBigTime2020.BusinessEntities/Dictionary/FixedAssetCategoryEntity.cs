/***********************************************************************
 * <copyright file="FixedAssetCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
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
    /// FixedAssetCategory Entity
    /// </summary>
    public class FixedAssetCategoryEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetCategoryEntity"/> class.
        /// </summary>
        public FixedAssetCategoryEntity()
        {
            AddRule(new ValidateRequired("FixedAssetCategoryCode"));
            AddRule(new ValidateRequired("FixedAssetCategoryName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetCategoryEntity"/> class.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="fixedAssetCategoryCode">The fixed asset category code.</param>
        /// <param name="fixedAssetCategoryName">Name of the fixed asset category.</param>
        /// <param name="fixedAssetCategoryForeignName">The fixed asset category name en.</param>
        /// <param name="depreciationRate">The depreciation rate.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="orgPriceAccount">The org price account.</param>
        /// <param name="depreciationAccount">The depreciation account.</param>
        /// <param name="capitalAccount">The capital account.</param>
        /// <param name="budgetChapterCode">The chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public FixedAssetCategoryEntity(string fixedAssetCategoryId, string parentId, string fixedAssetCategoryCode, string fixedAssetCategoryName,string fixedAssetDescription, string fixedAssetCategoryForeignName, decimal depreciationRate,
                                        decimal lifeTime, int grade, bool isParent, string orgPriceAccount, string depreciationAccount, string capitalAccount,
                                        string budgetChapterCode,string budgetKindItemCode, string budgetCategoryCode, string budgetGroupCode, string budgetItemCode,string budgetSubItemCode, bool isActive)
            : this()
        {
            FixedAssetCategoryId = fixedAssetCategoryId;
            FixedAssetCategoryCode = fixedAssetCategoryCode;
            FixedAssetCategoryName = fixedAssetCategoryName;
            Description = fixedAssetDescription;
            ParentId = parentId;
            Grade = grade;
            IsParent = isParent;
            LifeTime = lifeTime;
            DepreciationRate = depreciationRate;
            OrgPriceAccount = orgPriceAccount;
            DepreciationAccount = depreciationAccount;
            CapitalAccount = capitalAccount;
            BudgetChapterCode = budgetChapterCode;
            BudgetKindItemCode = budgetKindItemCode;
            BudgetItemCode = budgetItemCode;
            BudgetSubItemCode = budgetSubItemCode;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public string FixedAssetCategoryId { get; set; }

        public string FixedAssetCategoryCode { get; set; }

        public string FixedAssetCategoryName { get; set; }

        public string Description { get; set; }

        public string ParentId { get; set; }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public decimal LifeTime { get; set; }

        public decimal DepreciationRate { get; set; }

        public string OrgPriceAccount { get; set; }

        public string DepreciationAccount { get; set; }

        public string CapitalAccount { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public bool IsActive { get; set; }
    }
}
