using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.ExportXml
{
  public  class ExportXmlModel
    {
        public string ExportID { get; set; }
        public string ExportName { get; set; }
        public string RefType { get; set; }
        public string Description { get; set; }
        public string InputTypeName { get; set; }
        public string FuntionName { get; set; }
        public string DefaultParamater { get; set; }
        public int SortOrder { get; set; }
        public bool IsVisible { get; set; }

        public bool IsParamater { get; set; }
    }
}
