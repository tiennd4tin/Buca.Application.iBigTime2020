using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
   public interface ITaxTypeDao
    {
        TaxTypeEntity GetTaxType(string taxTypeId);
        List<TaxTypeEntity> GetTaxTypes();
        List<TaxTypeEntity> GetTaxTypesByTaxTypeCode(string taxTypeCode);
        List<TaxTypeEntity> GetTaxTypesByActive(bool isActive);
        string InsertTaxType(TaxTypeEntity taxType);
        string UpdateTaxType(TaxTypeEntity taxType);
        string DeleteTaxType(string taxTypeId);
    }
}
