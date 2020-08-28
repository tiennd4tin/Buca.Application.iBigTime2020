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

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Salary;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Salary
{
    public interface ISalaryVoucherDao
    {
        List<SalaryVoucherEntity> GetSalaryVoucherMonthDate(string monthDate);

        List<SalaryVoucherEntity> GetSalaryVoucherMonthDateIsPostedDate(string monthDate);

        List<SalaryVoucherEntity> GetSalaryVoucherIsRetail(string monthDate,bool isRetail,int refTypeId);

        string  CanclCalc(string monthDate, string refNo);
        
    }
}
