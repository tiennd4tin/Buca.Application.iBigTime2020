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
   public class S34H_GL_Master_LineDetailModel
    {

       public string AccountNumber { get; set; }
        public int AccountCategoryKind { get; set; }
        public string AccountingObjectId { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public int MonthYear { get; set; }
        public int MonthPeriod { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public IList<S34H_GL_Detail_SubDetailModel> GL_Detail_SubDetail { get; set; }
    }
}
