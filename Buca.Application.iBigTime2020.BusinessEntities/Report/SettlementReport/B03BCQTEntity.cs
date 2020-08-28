/***********************************************************************
 * <copyright file="B03BCQTEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 29, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessEntities.Report.SettlementReport
{
   public class B03BCQTEntity: BusinessEntities
    {
       public int ReportItemIndex { get; set; }

       public string ReportItemAlias { get; set; }

       public string ReportItemCode { get; set; }

       public string ReportItemName { get; set; }

       public int Grade { get; set; }

       public string BudgetChapterCode { get; set; }

       public string GroupName { get; set; }

       public string GroupTypeChild { get; set; }

       public string GroupType { get; set; }

       public bool IsBold { get; set; }

       public bool IsItalic { get; set; }

       public decimal Col1 { get; set; }

       public decimal Col2 { get; set; }

       public decimal Col3 { get; set; }
    }
}
