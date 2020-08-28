using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;
using Buca.Application.iBigTime2020.View.ExportXml;

namespace Buca.Application.iBigTime2020.Presenter.ExportXml
{
   public class ExportXmlDetailPresenter:Presenter<IExportXmlDetailViews>
    {
        public ExportXmlDetailPresenter(IExportXmlDetailViews view)
            : base(view)
        {
        }
        public IList<ExportXmlDetailModel> GetExportXmlDetail(string refType)
        {
            return null;
            // return View.ExportXmlDetail = Model.GetExportXmlDetail(refType);
        }
    }
}
