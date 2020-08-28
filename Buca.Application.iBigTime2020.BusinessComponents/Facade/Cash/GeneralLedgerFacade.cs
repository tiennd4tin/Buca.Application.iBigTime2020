using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    public class GeneralLedgerFacade
    {
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
 

        //public IList<GeneralLedgerEntity> GetSearchVoucher(string FromDate, string ToDate, string CurrencyCode, string DepartmentCode, string FixedAssetCode,
        //  string BudgetGroupCode)
        //{
        //   // return GeneralLedgerDao.GetSearchVoucher(FromDate, ToDate, CurrencyCode, DepartmentCode, FixedAssetCode, BudgetGroupCode);
        //    //return "";
        //}


    }
}
