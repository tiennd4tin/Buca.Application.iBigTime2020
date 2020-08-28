using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml;
using Buca.Application.iBigTime2020.View.ExportXml;

namespace Buca.Application.iBigTime2020.Presenter.ExportXml
{
    public class ExportXmlPresenter: Presenter<IExportXmlViews>
    {
        public ExportXmlPresenter(IExportXmlViews view)
            : base(view)
        {
        }

        public IList<ExportXmlModel> GetExportXml()
        {
            return View.ExportXml = Model.GetExportXml();
        }

        public IList<ExportXmlBCTCModel> GetExportXmlBCTC()
        {
            return View.ExportXmlBCTC = Model.GetExportXmlBCTC();
        }

        public IList<ExportXmlBCTCBudgetSourceModel> GetExportXmlBCTCBudgetSource()
        {
            return View.ExportXmlBCTCBudgetSource = Model.GetExportXmlBCTCBudgetSource();
        }
    }
}
