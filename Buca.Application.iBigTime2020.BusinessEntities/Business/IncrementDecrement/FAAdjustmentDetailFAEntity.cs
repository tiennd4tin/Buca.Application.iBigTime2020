/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: October 27, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.IncrementDecrement
{
    /// <summary>
    /// SUTransferEntity
    /// </summary>
    public class FAAdjustmentDetailFAEntity : BusinessEntities
    {
      public string RefDetailID { get; set; }
      public string RefID { get; set; }
      public string FixedAssetID { get; set; }
      public string DepartmentID { get; set; }
      public decimal OldOrgPrice { get; set; }
      public decimal OldDevaluationAmount { get; set; }
      public decimal OldAccumDevaluationAmount { get; set; }
      public decimal OldAccumDepreciationAmount { get; set; }
      public decimal OldRemainingAmount { get; set; }
      public decimal OldAnnualDepreciationRate { get; set; }
      public decimal OldAnnualDepreciationAmount { get; set; }
      public decimal OldPeriodDevaluationAmount { get; set; }
      public decimal OldQuantity { get; set; }
      public decimal OldProductionRate { get; set; }
      public decimal OldDevaluationRate { get; set; }
      public decimal OldRemainingDevaluationLifeTime { get; set; }
      public decimal NewOrgPrice { get; set; }
      public decimal NewDevaluationAmount { get; set; }
      public decimal NewAccumDevaluationAmount { get; set; }
      public decimal NewAccumDepreciationAmount { get; set; }
      public decimal NewRemainingAmount { get; set; }
      public decimal NewAnnualDepreciationRate { get; set; }
      public decimal NewAnnualDepreciationAmount { get; set; }
      public decimal NewPeriodDevaluationAmount { get; set; }
      public decimal NewQuantity { get; set; }
      public decimal NewProductionRate { get; set; }
      public decimal NewDevaluationRate { get; set; }
      public decimal NewRemainingDevaluationLifeTime { get; set; }
      public int NewRemainingLifeTime { get; set; }
      public decimal DiffOrgPrice { get; set; }
      public decimal DiffDevaluationAmount { get; set; }
      public decimal DiffAccumDevaluationAmount { get; set; }
      public decimal DiffAccumDepreciationAmount { get; set; }
      public decimal DiffRemainingAmount { get; set; }
      public decimal DiffAnnualDepreciationRate { get; set; }
      public decimal DiffAnnualDepreciationAmount { get; set; }
      public decimal DiffPeriodDevaluationAmount { get; set; }
      public decimal DiffQuantity { get; set; }
      public int SortOrder { get; set; }
      public int EndYear { get; set; }
    }
}
