using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;

namespace Buca.Application.iBigTime2020.View.ExportXml
{
  public  interface IExportXmlDetailViews :IView
    {
        IList<ExportXmlDetailModel> ExportXmlDetail { set; }
    }
}
