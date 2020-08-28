using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.Finacial
{
    public class S34H_GL_MasterEntity : BusinessEntities
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string CorrespondingAccount { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public string AccountingObjectCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public IList<S34H_GL_Master_LineDetailEntity> GL_Master_LineDetail { get; set; }
    }
}
