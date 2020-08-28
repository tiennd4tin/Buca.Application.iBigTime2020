/***********************************************************************
 * <copyright file="StockEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace Buca.Application.iBigTime2020.BusinessEntities.Salary
{
  public  class SalaryVoucherEntity
    {
      public int RefTypeId { get; set; }
      public string RefNo { get; set; }
      public string PostedDate { get; set; }
      public string CurrencyCode { get; set; }
      public decimal ExchangeRate { get; set; }

    }
}
