/***********************************************************************
 * <copyright file="S101HDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, April 11, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.TreasuaryReport
{
   public  class S101HDetailEntity: BusinessEntities
    {
       public string BudgetChapterCode { get; set; }

       public string BudgetSourceCode { get; set; }

       public int BudgetSourceKindId { get; set; }

       /// <summary>
       /// Gets or sets the name of the budget source kind.
       /// </summary>
       /// <value>The name of the budget source kind.</value>
       public string ProjectCode { get; set; }

       public string ProjectName { get; set; }


       public int ReportItemCode { get; set; }

       public string ItemName { get; set; }

       public decimal SumAmount { get; set; }


    }
}
