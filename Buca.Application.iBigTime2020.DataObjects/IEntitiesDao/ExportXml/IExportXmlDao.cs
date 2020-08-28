using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Report.ExportXml;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.ExportXml
{
  public  interface  IExportXmlDao
  {
      IList<ExportXmlEntity> GetExportXmlEntities();
        IList<ExportXmlDetailEntity> GetExportXmlDetailEntities (string refId );
      IList<ExportXmlBCTCEntiry> GetExportXmlBCTCEntities();
      IList<ExportXmlBCTCBudgetSourceEntity> GetExportXmlBCTCBudgetSourceEntity();
      string Delete_BudgetSourceMappingToExport();
      string InsertBudgetSourceMappingToExport(ExportXmlBCTCBudgetSourceEntity entity);
  }
}
