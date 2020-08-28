/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;

namespace Buca.Application.iBigTime2020.View.Dictionary
{
    /// <summary>
    /// interface IContractView
    /// </summary>
    public interface IContractView : IView
    {
         string ContractId { get; set; }
         string ContractNo { get; set; }
         string ContractName { get; set; }
         string ContractNameEnglish { get; set; }
         DateTime SignDate { get; set; }
         DateTime StartDate { get; set; }
         DateTime EndDate { get; set; }
         string CurrencyCode { get; set; }
         decimal ExchangeRate { get; set; }
         decimal AmountOC { get; set; }
         string ProjectId { get; set; }
         string Description { get; set; }
         string VendorId { get; set; }
         string VendorBankAccountId { get; set; }
         bool IsActive { get; set; }
         List<ContractDetailsModel> ContractDetails { get; set; }
    }
}
