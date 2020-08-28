using System;
using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Business.Cash
{

    /// <summary>
    /// Class CAPaymentDetailEntity.
    /// </summary>
    /// <seealso cref="Buca.Application.iBigTime2020.BusinessEntities.BusinessEntities" />
    public class CAPaymentDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAPaymentDetailEntity"/> class.
        /// </summary>
        public CAPaymentDetailEntity() 
        {
            AddRule(new ValidateRequired("RefDetailId"));
            AddRule(new ValidateRequired("RefId"));
        }
        public string AutoBusinessId { get; set; }

        public string RefDetailId { get; set; }

        public string RefId { get; set; }

        public string Description { get; set; }

        public string DebitAccount { get; set; }

        public string CreditAccount { get; set; }

        public decimal Amount { get; set; }

        public decimal AmountOC { get; set; }

        public string BudgetSourceId { get; set; }

        public string BudgetChapterCode { get; set; }

        public string BudgetKindItemCode { get; set; }

        public string BudgetSubKindItemCode { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetSubItemCode { get; set; }

        public int? MethodDistributeId { get; set; }

        public int? CashWithDrawTypeId { get; set; }

        public string AccountingObjectId { get; set; }

        public string ActivityId { get; set; }

        public string ProjectId { get; set; }

        public string ProjectActivityId { get; set; }

        public string ListItemId { get; set; }

        public bool Approved { get; set; }

        public int SortOrder { get; set; }

        public string BudgetDetailItemCode { get; set; }

        public string OrgRefNo { get; set; }

        public DateTime? OrgRefDate { get; set; }

        public string FundStructureId { get; set; }

        public string BankId { get; set; }

        public string ProjectExpenseEAId { get; set; }

        public string ProjectActivityEAId { get; set; }
        public string BudgetExpenseId { get; set; }

        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
    }

}