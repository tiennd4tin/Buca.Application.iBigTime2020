using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class FundStructureEntityDao : IEntityFundStructureDao
    {


        public List<FundStructureEntity> GetFundStructure(string connectionString)
        {
            List<FundStructureEntity> listfFundStructure = new List<FundStructureEntity>();
            using (var context = new MISAEntity(connectionString))
            {

                var categories = context.FundStructures.ToList();
                foreach (var result in categories)
                {
                    var fundStructure = new FundStructureEntity();
                    fundStructure.FundStructureId = result.FundStructureID.ToString();
                    fundStructure.FundStructureCode = result.FundStructureCode;
                    fundStructure.FundStructureName = result.FundStructureName;
                    fundStructure.BUCACodeId = result.MISACodeID;
                    fundStructure.ParentId = result.ParentID.ToString();
                    fundStructure.Grade = result.Grade;
                    fundStructure.IsParent = result.IsParent;
                    fundStructure.Inactive = result.Inactive ==true?false:true;
                    fundStructure.IsSystem = result.IsSystem;
                    fundStructure.InvestmentPeriod = result.InvestmentPeriod;

                    listfFundStructure.Add(fundStructure);

                }

            }
            return listfFundStructure;
        }

    }
       
}
