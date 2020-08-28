﻿/***********************************************************************
 * <copyright file="GeneralDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.General
{
   public class GeneralVoucherDetailModel : BaseVoucherModel
    {
        /// <summary>
        /// Gets or sets the general detail identifier.
        /// </summary>
        /// <value>
        /// The general detail identifier.
        /// </value>
       public int RefDetailId { get; set; }

       /// <summary>
       /// Gets or sets the account number.
       /// </summary>
       /// <value>
       /// The account number.
       /// </value>
       public string  AccountNumber { get; set; }

       /// <summary>
       /// Gets or sets the corresponding account number.
       /// </summary>
       /// <value>
       /// The corresponding account number.
       /// </value>
       public string  CorrespondingAccountNumber { get; set; }

       /// <summary>
       /// Gets or sets the description.
       /// </summary>
       /// <value>
       /// The description.
       /// </value>
       public string  Description { get; set; }

       /// <summary>
       /// Gets or sets the amount oc.
       /// </summary>
       /// <value>
       /// The amount oc.
       /// </value>
       public decimal AmountOc { get; set; }

       /// <summary>
       /// Gets or sets the amount exchange.
       /// </summary>
       /// <value>
       /// The amount exchange.
       /// </value>
       public decimal AmountExchange { get; set; }

       /// <summary>
       /// Gets or sets the currency code.
       /// </summary>
       /// <value>
       /// The currency code.
       /// </value>
       public string  CurrencyCode { get; set; }

       /// <summary>
       /// Gets or sets the exchage rate.
       /// </summary>
       /// <value>
       /// The exchage rate.
       /// </value>
       public decimal ExchangeRate { get; set; }

       /// <summary>
       /// Gets or sets the bussiness.
       /// </summary>
       /// <value>
       /// The bussiness.
       /// </value>
       public int? VoucherTypeId { get; set; }


       public int? BankId { get; set; }

       /// <summary>
       /// Gets or sets the budget source code.
       /// </summary>
       /// <value>
       /// The budget source code.
       /// </value>
       public string  BudgetSourceCode { get; set; }

       /// <summary>
       /// Gets or sets the budget item code.
       /// </summary>
       /// <value>
       /// The budget item code.
       /// </value>
       public string  BudgetItemCode { get; set; }

       /// <summary>
       /// Gets or sets the depatment identifier.
       /// </summary>
       /// <value>
       /// The depatment identifier.
       /// </value>
       public int? DepartmentId { get; set; }

       /// <summary>
       /// Gets or sets the accounting object identifier.
       /// </summary>
       /// <value>
       /// The accounting object identifier.
       /// </value>
       public int? AccountingObjectId { get; set; }

       /// <summary>
       /// Gets or sets the customer identifier.
       /// </summary>
       /// <value>
       /// The customer identifier.
       /// </value>
       public int? CustomerId { get; set; }

       /// <summary>
       /// Gets or sets the vendor identifier.
       /// </summary>
       /// <value>
       /// The vendor identifier.
       /// </value>
       public int? VendorId { get; set; }

       /// <summary>
       /// Gets or sets the employee identifier.
       /// </summary>
       /// <value>
       /// The employee identifier.
       /// </value>
       public int? EmployeeId { get; set; }

       /// <summary>
       /// Gets or sets the project identifier.
       /// </summary>
       /// <value>
       /// The project identifier.
       /// </value>
       public int?  ProjectId { get; set; }

       /// <summary>
       /// Gets or sets the automatic business.
       /// </summary>
       /// <value>
       /// The automatic business.
       /// </value>
       public int AutoBusiness { get; set; }

       /// <summary>
       /// Gets or sets the reference identifier.
       /// </summary>
       /// <value>
       /// The reference identifier.
       /// </value>
       public long RefId { get; set; }

       /// <summary>
       /// Gets or sets the capital allocate code.
       /// </summary>
       /// <value>
       /// The capital allocate code.
       /// </value>
       public string CapitalAllocateCode { get; set; }


       /// <summary>
       /// Gets or sets the inventory item code.
       /// </summary>
       /// <value>
       /// The inventory item code.
       /// </value>
       public int? InventoryItemId { get; set; }
    }
}
