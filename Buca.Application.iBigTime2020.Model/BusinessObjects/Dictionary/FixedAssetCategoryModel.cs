/***********************************************************************
 * <copyright file="FixedAssetCategoryModel.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// FixedAsset Category Model
    /// </summary>
    public class FixedAssetCategoryModel
    {
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
