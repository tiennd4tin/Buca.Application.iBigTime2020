/***********************************************************************
 * <copyright file="AutoBusinessEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 26 September 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.BusinessRules;

namespace Buca.Application.iBigTime2020.BusinessEntities.Dictionary
{
    /// <summary>
    /// class AutoBusinessEntity
    /// </summary>
    public class AutoBusinessEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessEntity"/> class.
        /// </summary>
        public AutoBusinessEntity()
        {
            AddRule(new ValidateRequired("AutoBusinessCode"));
            AddRule(new ValidateRequired("AutoBusinessName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessEntity" /> class.
        /// </summary>
        /// <param name="autoBusinessId">The automatic business identifier.</param>
        /// <param name="autoBusinessCode">The automatic business code.</param>
        /// <param name="autoBusinessName">Name of the automatic business.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="debitAccount">The debit account.</param>
        /// <param name="creditAccount">The credit account.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetKindItemCode">The budget kind item code.</param>
        /// <param name="budgetSubKindItemCode">The budget sub kind item code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="budgetSubItemCode">The budget sub item code.</param>
        /// <param name="methodDistributeId">The method distribute identifier.</param>
        /// <param name="cashWithDrawTypeId">The cash with draw type identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public AutoBusinessEntity(string autoBusinessId, string autoBusinessCode, string autoBusinessName, int refTypeId,
            string debitAccount, string creditAccount, string budgetSourceId, string budgetChapterCode, string budgetKindItemCode, string budgetSubKindItemCode,
        string budgetItemCode, string budgetSubItemCode, int? methodDistributeId, int? cashWithDrawTypeId, string description,bool isActive)
            : this()
        {
            AutoBusinessId = autoBusinessId;
            AutoBusinessCode = autoBusinessCode;
            AutoBusinessName = autoBusinessName;
            RefTypeId = refTypeId;
            DebitAccount = debitAccount;
            CreditAccount = creditAccount;
            BudgetSourceId = budgetSourceId;
            BudgetChapterCode = budgetChapterCode;
            BudgetKindItemCode = budgetKindItemCode;
            BudgetSubKindItemCode = budgetSubKindItemCode;
            BudgetItemCode = budgetItemCode;
            BudgetSubItemCode = budgetSubItemCode;
            MethodDistributeId = methodDistributeId;
            CashWithDrawTypeId = cashWithDrawTypeId;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the automatic business identifier.
        /// </summary>
        /// <value>
        /// The automatic business identifier.
        /// </value>
        public string AutoBusinessId { get; set; }

        /// <summary>
        /// Gets or sets the automatic business code.
        /// </summary>
        /// <value>
        /// The automatic business code.
        /// </value>
        public string AutoBusinessCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the automatic business.
        /// </summary>
        /// <value>
        /// The name of the automatic business.
        /// </value>
        public string AutoBusinessName { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>
        /// The debit account.
        /// </value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>
        /// The credit account.
        /// </value>
        public string CreditAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>
        /// The budget source identifier.
        /// </value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>
        /// The budget kind item code.
        /// </value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>
        /// The budget sub kind item code.
        /// </value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>
        /// The method distribute identifier.
        /// </value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash with draw type identifier.
        /// </summary>
        /// <value>
        /// The cash with draw type identifier.
        /// </value>
        public int? CashWithDrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
