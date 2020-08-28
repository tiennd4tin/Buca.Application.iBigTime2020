using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using Buca.Application.iBigTime2020.View.Dictionary;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory;

namespace Buca.Application.iBigTime2020.Presenter.Dictionary.FixedAssetCategory
{

    public class FixedAssetCategoryPresenter : Presenter<IFixedAssetCategoryView>
    {
        public FixedAssetCategoryPresenter(IFixedAssetCategoryView view)
            : base(view)

        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }
        public void Display(string fixedAsssetCategoryId)
        {
            if (fixedAsssetCategoryId == null)
            {
                View.FixedAssetCategoryId = null;
                return;
            }
            var fixedAssetCategory = Model.GetFixedAssetCategoryById(fixedAsssetCategoryId);
            {
                View.FixedAssetCategoryId = fixedAssetCategory.FixedAssetCategoryId;
                View.FixedAssetCategoryCode = fixedAssetCategory.FixedAssetCategoryCode;
                View.FixedAssetCategoryName = fixedAssetCategory.FixedAssetCategoryName;
                View.Description = fixedAssetCategory.Description;
                View.ParentId = fixedAssetCategory.ParentId;
                View.Grade = fixedAssetCategory.Grade;
                View.IsParent = fixedAssetCategory.IsParent;
                View.LifeTime = fixedAssetCategory.LifeTime;
                View.DepreciationRate = fixedAssetCategory.DepreciationRate;
                View.OrgPriceAccount = fixedAssetCategory.OrgPriceAccount;
                View.DepreciationAccount = fixedAssetCategory.DepreciationAccount;
                View.CapitalAccount = fixedAssetCategory.CapitalAccount;
                View.BudgetChapterCode = fixedAssetCategory.BudgetChapterCode;
                View.BudgetKindItemCode = fixedAssetCategory.BudgetKindItemCode;
                View.BudgetSubKindItemCode = fixedAssetCategory.BudgetSubKindItemCode;
                View.BudgetItemCode = fixedAssetCategory.BudgetItemCode;
                View.BudgetSubItemCode = fixedAssetCategory.BudgetSubItemCode;
                View.IsActive = fixedAssetCategory.IsActive;

            }
        }
        public string Save()
        {

            var fixedAssetCategoryModel = new FixedAssetCategoryModel
            {
                FixedAssetCategoryId = View.FixedAssetCategoryId,
                FixedAssetCategoryCode = View.FixedAssetCategoryCode.Trim(),
                FixedAssetCategoryName = View.FixedAssetCategoryName.Trim(),
                Description = View.Description == null ? "" : View.Description.Trim(),
                ParentId = View.ParentId.Trim(),
                Grade = View.Grade,
                IsParent = View.IsParent,
                LifeTime = View.LifeTime,
                DepreciationRate = View.DepreciationRate,
                OrgPriceAccount = View.OrgPriceAccount,
                DepreciationAccount = View.DepreciationAccount,
                CapitalAccount = View.CapitalAccount,
                BudgetChapterCode = View.BudgetChapterCode,
                BudgetKindItemCode = View.BudgetKindItemCode,
                BudgetSubKindItemCode = View.BudgetSubKindItemCode,
                BudgetItemCode = View.BudgetItemCode,
                BudgetSubItemCode = View.BudgetSubItemCode,
                IsActive = View.IsActive


            };
            if (View.FixedAssetCategoryId == null)
            {
                return Model.InsertFixedAssetCategory(fixedAssetCategoryModel);
            }
            return Model.UpdateFixedAssetCategory(fixedAssetCategoryModel);

        }
        public string Delete(string fixedCategoryAssetId)
        {
            return Model.DeleteFixedAssetCategory(fixedCategoryAssetId);
        }
    }


}