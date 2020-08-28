/***********************************************************************
 * <copyright file="BUTransferDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessEntities
{
    /// <summary>
    /// Class BUTransferDetailEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class BUTransferDetailPurchaseEntity : BusinessEntities
    {
        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string InventoryItemId { get; set; }

        public string Description { get; set; }

        public string StockId { get; set; }

        public string DebitAccount { get; set; }

        public string CreditAccount { get; set; }

        public string Unit { get; set; }

        public decimal Quantity { get; set; }

        public decimal QuantityConvert { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitPriceConvert { get; set; }

        public decimal Amount { get; set; }

        public int? TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal FreightAmount { get; set; }

        public decimal InwardAmount { get; set; }

        public string BudgetSourceId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public int? MethodDistributeId { get; set; }

        public int? CashWithdrawTypeId { get; set; }

        public string AccountingObjectId { get; set; }

        public string ActivityId { get; set; }

        public string ProjectId { get; set; }

        public string ProjectActivityId { get; set; }

        public string ProjectExpenseId { get; set; }

        public string TaskId { get; set; }

        public string ListItemId { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string LotNo { get; set; }

        public bool Approved { get; set; }

        public int? SortOrder { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public string OrgRefNo { get; set; }

        public DateTime? OrgRefDate { get; set; }

        public string FundStructureId { get; set; }

        public string ProjectExpenseEAId { get; set; }

        public string ProjectActivityEAId { get; set; }

        public string BudgetProvideCode { get; set; }

        public string TopicId { get; set; }

        public DateTime? CreateDate { get; set; }
        public string BankId { get; set; }
        public string BudgetExpenseId { get; set; }
    }
}
