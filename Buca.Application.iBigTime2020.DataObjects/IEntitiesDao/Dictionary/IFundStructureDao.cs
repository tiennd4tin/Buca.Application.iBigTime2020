using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    public interface IFundStructureDao
    {
        FundStructureEntity GetFundStructure(string fundStructureId);
        List<FundStructureEntity> GetFundStructures();
        List<FundStructureEntity> GetFundStructuresByFundStructureCode(string fundStructureCode);
        List<FundStructureEntity> GetFundStructuresByActive(bool isActive);
        string InsertFundStructure(FundStructureEntity fundStructure);
        string UpdateFundStructure(FundStructureEntity fundStructure);
        string DeleteFundStructure(string fundStructureId);
        string DeleteFundStructureConvert();
    }
}
