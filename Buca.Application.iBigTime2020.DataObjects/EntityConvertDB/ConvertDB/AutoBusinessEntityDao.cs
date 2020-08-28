using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;

using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class AutoBusinessEntityDao : IEntityAutoBusiness
    {

        public List<AutoBusinessEntity> GetAutoBusiness(string connectionString)
        {
            List<AutoBusinessEntity> listAutoBusiness = new List<AutoBusinessEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var lstAutoBusinessDetail = context.AutoBusinessDetails.ToList();
                var lstAutoBusiness = context.AutoBusinesses.ToList().OrderBy(o=>o.AutoBusinessID);
                int i = 0;
                foreach (var autoBusiness in lstAutoBusiness)
                {
                    
                    foreach (var result in autoBusiness.AutoBusinessDetails)
                    {
                        i = i + 1;
                        var autoBusinessDetail = new AutoBusinessEntity();
                        autoBusinessDetail.AutoBusinessId = result.AutoBusinessDetailID.ToString();
                        autoBusinessDetail.AutoBusinessCode = i.ToString();
                        autoBusinessDetail.AutoBusinessName = autoBusiness.AutoBusinessName;
                        autoBusinessDetail.RefTypeId = autoBusiness.RefTypeID;
                        autoBusinessDetail.DebitAccount = result.DebitAccount;
                        autoBusinessDetail.CreditAccount = result.CreditAccount;
                        autoBusinessDetail.BudgetSourceId = result.BudgetSourceID.ToString();
                        autoBusinessDetail.BudgetChapterCode = result.BudgetChapterCode;
                        autoBusinessDetail.BudgetKindItemCode = result.BudgetKindItemCode;
                        autoBusinessDetail.BudgetSubKindItemCode = result.BudgetSubKindItemCode;
                        autoBusinessDetail.BudgetItemCode = result.BudgetItemCode;
                        autoBusinessDetail.BudgetSubItemCode = result.BudgetSubItemCode;
                        autoBusinessDetail.MethodDistributeId = result.MethodDistributeID;
                        autoBusinessDetail.CashWithDrawTypeId = result.CashWithDrawTypeID;
                        autoBusinessDetail.Description = result.Description;
                        autoBusinessDetail.IsActive = autoBusiness.Inactive == true ? false : true;
                        listAutoBusiness.Add(autoBusinessDetail);
                    }

                }

            }

            return listAutoBusiness;
        }
        public List<AutoBusinessParallelEntity> GetAutoBusinessPararellel(string connectionString)
        {
            List<AutoBusinessParallelEntity> listAutoBusinessPararell = new List<AutoBusinessParallelEntity>();
            using (var context = new MISAEntity(connectionString))
            {
                var lstAutoBusinessDetail = context.AutoBusinessDetails.ToList();
                var lstAutoBusinessParallelDetail = context.AutoBusinessParalellDetails.ToList();
                var lstAutoBusiness = context.AutoBusinesses.ToList().OrderBy(o => o.AutoBusinessID);
                int i = 0;
                foreach (var autoBusiness in lstAutoBusiness)
                {
                    foreach (var autoBusinessDetail in autoBusiness.AutoBusinessDetails)
                    {
                        i = i + 1;
                        foreach (var autoBussinessParallel in autoBusiness.AutoBusinessParalellDetails)
                        {
                            var autoBusinessParallelDetail = new AutoBusinessParallelEntity();
                            autoBusinessParallelDetail.AutoBusinessParallelId = Guid.NewGuid().ToString();
                            autoBusinessParallelDetail.AutoBusinessCode = i.ToString();
                            autoBusinessParallelDetail.AutoBusinessName = autoBusiness.AutoBusinessName;
                            autoBusinessParallelDetail.Description = autoBussinessParallel.Description;
                            autoBusinessParallelDetail.IsActive = autoBusiness.Inactive == true ? false : true;
                            autoBusinessParallelDetail.DebitAccount = autoBusinessDetail.DebitAccount;
                            autoBusinessParallelDetail.CreditAccount = autoBusinessDetail.CreditAccount;
                            autoBusinessParallelDetail.BudgetSourceId = autoBusinessDetail.BudgetSourceID.ToString();
                            autoBusinessParallelDetail.BudgetChapterCode = autoBusinessDetail.BudgetChapterCode;
                            autoBusinessParallelDetail.BudgetKindItemCode = autoBusinessDetail.BudgetKindItemCode;
                            autoBusinessParallelDetail.BudgetSubKindItemCode = autoBusinessDetail.BudgetSubKindItemCode;
                            autoBusinessParallelDetail.BudgetItemCode = autoBusinessDetail.BudgetItemCode;
                            autoBusinessParallelDetail.BudgetSubItemCode = autoBusinessDetail.BudgetSubItemCode;
                            autoBusinessParallelDetail.MethodDistributeId = autoBusinessDetail.MethodDistributeID;
                            autoBusinessParallelDetail.CashWithDrawTypeId = autoBusinessDetail.CashWithDrawTypeID;
                            autoBusinessParallelDetail.DebitAccountParallel = autoBussinessParallel.DebitAccount;
                            autoBusinessParallelDetail.CreditAccountParallel = autoBussinessParallel.CreditAccount;
                            autoBusinessParallelDetail.BudgetSourceIdParallel = autoBussinessParallel.BudgetSourceID.ToString();
                            autoBusinessParallelDetail.BudgetChapterCodeParallel = autoBussinessParallel.BudgetChapterCode;
                            autoBusinessParallelDetail.BudgetKindItemCodeParallel = autoBussinessParallel.BudgetKindItemCode;
                            autoBusinessParallelDetail.BudgetSubKindItemCodeParallel = autoBussinessParallel.BudgetSubKindItemCode;
                            autoBusinessParallelDetail.BudgetItemCodeParallel = autoBussinessParallel.BudgetItemCode;
                            autoBusinessParallelDetail.BudgetSubItemCodeParallel = autoBussinessParallel.BudgetSubItemCode;
                            autoBusinessParallelDetail.MethodDistributeIdParallel = autoBussinessParallel.MethodDistributeID;
                            autoBusinessParallelDetail.CashWithDrawTypeIdParallel = autoBussinessParallel.CashWithDrawTypeID;
                            autoBusinessParallelDetail.SortOrder = autoBussinessParallel.SortOrder;

                            listAutoBusinessPararell.Add(autoBusinessParallelDetail);

                        }
                    }
                }

            }

            return listAutoBusinessPararell;
        }

    }
}
