/***********************************************************************
 * <copyright file="IFixedAssetCategoryView.cs" company="BUCA JSC">
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

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// FixedAssetCategory View Interface
    /// </summary>
    public interface IFixedAssetCategoryView : IView
    {
        string FixedAssetCategoryId { get; set; }

        string FixedAssetCategoryCode { get; set; }

        string FixedAssetCategoryName { get; set; }

        string Description { get; set; }

        string ParentId { get; set; }

        int Grade { get; set; }

        bool IsParent { get; set; }

        decimal LifeTime { get; set; }

        decimal DepreciationRate { get; set; }

        string OrgPriceAccount { get; set; }

        string DepreciationAccount { get; set; }

        string CapitalAccount { get; set; }

        string BudgetChapterCode { get; set; }

        string BudgetKindItemCode { get; set; }

        string BudgetSubKindItemCode { get; set; }

        string BudgetItemCode { get; set; }

        string BudgetSubItemCode { get; set; }

        bool IsActive { get; set; }
    }
}
