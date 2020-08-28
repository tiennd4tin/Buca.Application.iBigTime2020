using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FixedAssetEntityDao : IEntityFixedAssetDao
    {
       
       public  List<FixedAssetEntity> GetFixedAsset(string connectionString)
        {  
            List<FixedAssetEntity> listAccount = new List<FixedAssetEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var department = context.Departments.ToList();
                var categories = context.FixedAssets.ToList();
                foreach (var result in categories)
                {
                    var fixedAsset = new FixedAssetEntity();
                    fixedAsset.FixedAssetId = result.FixedAssetID.ToString();
                    fixedAsset.FixedAssetCategoryId = result.FixedAssetCategoryID.ToString();
                    fixedAsset.DepartmentId = result.Department==null?"": result.Department.DepartmentID.ToString();
                    fixedAsset.FixedAssetCode = result.FixedAssetCode;
                    fixedAsset.FixedAssetName = result.FixedAssetName;
                    fixedAsset.Quantity = result.Quantity??0;
                    fixedAsset.Description = result.Description;
                    fixedAsset.ProductionYear = result.ProductionYear??0;
                    fixedAsset.MadeIn = result.MadeIn;
                    fixedAsset.SerialNumber = result.SerialNumber;
                    fixedAsset.Accessories = result.Accessories;
                    //fixedAsset.VendorId = result.ven;
                    fixedAsset.GuaranteeDuration = result.GuaranteeDuration;
                    fixedAsset.IsSecondHand = result.IsSecondHand;
                    fixedAsset.LastState = result.LastState??0;
                    fixedAsset.DisposedDate = result.DisposedDate??DateTime.Now;
                    fixedAsset.DisposedAmount = result.DisposedAmount;
                    fixedAsset.DisposedReason = result.DisposedReason;
                    fixedAsset.PurchasedDate = result.PurchasedDate??DateTime.Now;
                    fixedAsset.UsedDate = result.UsedDate??DateTime.Now;
                    fixedAsset.DepreciationDate = result.DepreciationDate?? DateTime.Now;
                    fixedAsset.IncrementDate = result.IncrementDate??DateTime.Now;
                    fixedAsset.OrgPrice = result.OrgPrice;
                    fixedAsset.DepreciationValueCaculated = result.DepreciationValueCaculated;
                    fixedAsset.AccumDepreciationAmount = result.AccumDepreciationAmount;
                    fixedAsset.LifeTime = decimal.ToInt32(result.LifeTime);
                    fixedAsset.DepreciationRate = result.DepreciationRate;
                    fixedAsset.PeriodDepreciationAmount = result.PeriodDepreciationAmount;
                    fixedAsset.RemainingAmount = result.RemainingAmount;
                    fixedAsset.RemainingLifeTime = result.RemainingLifeTime??0;
                    fixedAsset.EndYear = result.EndYear??0;
                    fixedAsset.OrgPriceAccount = result.OrgPriceAccount;
                    fixedAsset.CapitalAccount = result.CapitalAccount;
                    fixedAsset.BudgetChapterCode = result.BudgetChapterCode;
                    fixedAsset.BudgetKindItemCode = result.BudgetKindItemCode;
                    fixedAsset.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                    fixedAsset.BudgetItemCode = result.BudgetItemCode;
                    fixedAsset.BudgetSubItemCode = result.BudgetSubItemCode;
                    fixedAsset.CreditDepreciationAccount = result.DepreciationAccount;
                    fixedAsset.DebitDepreciationAccount = result.DebitDepreciationAccount;
                    fixedAsset.IsFixedAssetTransfer = result.IsFixedAssetTransfer;
                    fixedAsset.DepreciationTimeCaculated = result.DepreciationTimeCaculated;
                    fixedAsset.Unit = result.Unit;
                   // fixedAsset.RevenueAccount = result.re;
                    fixedAsset.Source = result.Source;
                    fixedAsset.DevaluationDate = result.DevaluationDate??DateTime.Now;
                    fixedAsset.DevaluationAmount = result.DevaluationAmount;
                    fixedAsset.DevaluationPeriod = result.DevaluationPeriod;
                    fixedAsset.DevaluationLifeTime = result.DevaluationLifeTime;
                    fixedAsset.DevaluationRate = result.DevaluationRate;
                    fixedAsset.PeriodDevaluationAmount = result.PeriodDevaluationAmount;
                    fixedAsset.AccumDevaluationAmount = result.AccumDevaluationAmount;
                    //fixedAsset.re = result.RemainingDevaluationLifeTime;
                    fixedAsset.EndDevaluationDate = result.EndDevaluationDate??DateTime.Now;
                    fixedAsset.DevaluationDebitAccount = result.DevaluationDebitAccount;
                    fixedAsset.DevaluationCreditAccount = result.DevaluationCreditAccount;
                    //fixedAsset.ProductionRate = result.ProductionRate;
                    fixedAsset.IsActive = true;
                    //fixedAsset.UsingRatio = result.UsingRatio;
                    fixedAsset.FixedAssetDetailAccessories = new List<FixedAssetDetailAccessoryEntity>();
                    fixedAsset.FixedAssetVoucherAttachs = new List<FixedAssetVoucherAttachEntity>();

                    listAccount.Add(fixedAsset);

                }

               
            }

            return listAccount;
        }

      
    }
}
