/***********************************************************************
 * <copyright file="GL_Master_LineDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TungNS
 * Email:    tungns@buca.vn
 * Website:
 * Create Date: 28 Dec 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Finacial
{
   public class S34H_GL_MasterModel
    {

        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public string AccountingObjectCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public IList<S34H_GL_Master_LineDetailModel> GL_Master_LineDetail { get; set; }
    }
}
