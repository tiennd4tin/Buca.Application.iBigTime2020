using Buca.Application.iBigTime2020.BusinessEntities.Report.ExportXml;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.ExportXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.ExportXml
{
   public class ExportXmlFacade
   {
       private static readonly IExportXmlDao ExportXmlDao = DataAccess.DataAccess.ExportXmlDao;

       public IList<ExportXmlEntity> GetExportXmlEntities()
       {
           return ExportXmlDao.GetExportXmlEntities();
       }
       public IList<ExportXmlDetailEntity> GetExportXmlDetailEntities(string refType)
       {
           return ExportXmlDao.GetExportXmlDetailEntities(refType);
       }
       public IList<ExportXmlBCTCEntiry> GetExportXmlBCTCEntities()
       {
           return ExportXmlDao.GetExportXmlBCTCEntities();
       }
       public IList<ExportXmlBCTCBudgetSourceEntity> GetExportXmlBCTCBudgetSourceEntities()
       {
           return ExportXmlDao.GetExportXmlBCTCBudgetSourceEntity();
       }

       public string Delete_BudgetSourceMappingToExport()
       {
           return ExportXmlDao.Delete_BudgetSourceMappingToExport();
       }

       public string InsertBudgetSourceMappingToExport(ExportXmlBCTCBudgetSourceEntity entity)
       {
           return ExportXmlDao.InsertBudgetSourceMappingToExport(entity);
       }
    }
}
