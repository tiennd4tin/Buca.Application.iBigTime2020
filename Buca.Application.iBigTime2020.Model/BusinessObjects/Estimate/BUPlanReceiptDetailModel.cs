/***********************************************************************
 * <copyright file="BUPlanReceiptDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   kiennt
 * Email:    kiennt@buca.vn
 * Website:
 * Create Date: 12, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  12/04/2018       Author    tudt           Description: Add new column MethodDistributeID
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Estimate
{
    /// <summary>
    /// Class BUPlanReceiptDetailModel.
    /// </summary>
    public class BUPlanReceiptDetailModel:BaseCheckErrorDetailByAccount
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        public string RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the budget kind item code.
        /// </summary>
        /// <value>The budget kind item code.</value>
        public string BudgetKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub kind item code.
        /// </summary>
        /// <value>The budget sub kind item code.</value>
        public string BudgetSubKindItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>The budget group item code.</value>
        public string BudgetGroupItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>The budget group item code.</value>
        public string BudgetParentItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>The budget sub item code.</value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the list item identifier.
        /// </summary>
        /// <value>The list item identifier.</value>
        public string ListItemId { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>The budget detail item code.</value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the project activity ea identifier.
        /// </summary>
        /// <value>The project activity ea identifier.</value>
        public string ProjectActivityEAId { get; set; }

        /// <summary>
        /// Gets or sets the amount quater1.
        /// </summary>
        /// <value>The amount quater1.</value>
        public decimal AmountQuater1 { get; set; }

        /// <summary>
        /// Gets or sets the amount quater1 oc.
        /// </summary>
        /// <value>The amount quater1 oc.</value>
        public decimal AmountQuater1OC { get; set; }

        /// <summary>
        /// Gets or sets the amount quater2.
        /// </summary>
        /// <value>The amount quater2.</value>
        public decimal AmountQuater2 { get; set; }

        /// <summary>
        /// Gets or sets the amount quater2 oc.
        /// </summary>
        /// <value>The amount quater2 oc.</value>
        public decimal AmountQuater2OC { get; set; }

        /// <summary>
        /// Gets or sets the amount quater3.
        /// </summary>
        /// <value>The amount quater3.</value>
        public decimal AmountQuater3 { get; set; }
        public string BudgetChapterCode { get; set; }
        /// <summary>
        /// Gets or sets the amount quater3 oc.
        /// </summary>
        /// <value>The amount quater3 oc.</value>
        public decimal AmountQuater3OC { get; set; }

        /// <summary>
        /// Gets or sets the amount quater4.
        /// </summary>
        /// <value>The amount quater4.</value>
        public decimal AmountQuater4 { get; set; }

        /// <summary>
        /// Gets or sets the amount quater4 oc.
        /// </summary>
        /// <value>The amount quater4 oc.</value>
        public decimal AmountQuater4OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month1.
        /// </summary>
        /// <value>The amount month1.</value>
        public decimal AmountMonth1 { get; set; }

        /// <summary>
        /// Gets or sets the amount month1 oc.
        /// </summary>
        /// <value>The amount month1 oc.</value>
        public decimal AmountMonth1OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month2.
        /// </summary>
        /// <value>The amount month2.</value>
        public decimal AmountMonth2 { get; set; }

        /// <summary>
        /// Gets or sets the amount month2 oc.
        /// </summary>
        /// <value>The amount month2 oc.</value>
        public decimal AmountMonth2OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month3.
        /// </summary>
        /// <value>The amount month3.</value>
        public decimal AmountMonth3 { get; set; }

        /// <summary>
        /// Gets or sets the amount month3 oc.
        /// </summary>
        /// <value>The amount month3 oc.</value>
        public decimal AmountMonth3OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month4.
        /// </summary>
        /// <value>The amount month4.</value>
        public decimal AmountMonth4 { get; set; }

        /// <summary>
        /// Gets or sets the amount month4 oc.
        /// </summary>
        /// <value>The amount month4 oc.</value>
        public decimal AmountMonth4OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month5.
        /// </summary>
        /// <value>The amount month5.</value>
        public decimal AmountMonth5 { get; set; }

        /// <summary>
        /// Gets or sets the amount month5 oc.
        /// </summary>
        /// <value>The amount month5 oc.</value>
        public decimal AmountMonth5OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month6.
        /// </summary>
        /// <value>The amount month6.</value>
        public decimal AmountMonth6 { get; set; }

        /// <summary>
        /// Gets or sets the amount month6 oc.
        /// </summary>
        /// <value>The amount month6 oc.</value>
        public decimal AmountMonth6OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month7.
        /// </summary>
        /// <value>The amount month7.</value>
        public decimal AmountMonth7 { get; set; }

        /// <summary>
        /// Gets or sets the amount month7 oc.
        /// </summary>
        /// <value>The amount month7 oc.</value>
        public decimal AmountMonth7OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month8.
        /// </summary>
        /// <value>The amount month8.</value>
        public decimal AmountMonth8 { get; set; }

        /// <summary>
        /// Gets or sets the amount month8 oc.
        /// </summary>
        /// <value>The amount month8 oc.</value>
        public decimal AmountMonth8OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month9.
        /// </summary>
        /// <value>The amount month9.</value>
        public decimal AmountMonth9 { get; set; }

        /// <summary>
        /// Gets or sets the amount month9 oc.
        /// </summary>
        /// <value>The amount month9 oc.</value>
        public decimal AmountMonth9OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month10.
        /// </summary>
        /// <value>The amount month10.</value>
        public decimal AmountMonth10 { get; set; }

        /// <summary>
        /// Gets or sets the amount month10 oc.
        /// </summary>
        /// <value>The amount month10 oc.</value>
        public decimal AmountMonth10OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month11.
        /// </summary>
        /// <value>The amount month11.</value>
        public decimal AmountMonth11 { get; set; }

        /// <summary>
        /// Gets or sets the amount month11 oc.
        /// </summary>
        /// <value>The amount month11 oc.</value>
        public decimal AmountMonth11OC { get; set; }

        /// <summary>
        /// Gets or sets the amount month12.
        /// </summary>
        /// <value>The amount month12.</value>
        public decimal AmountMonth12 { get; set; }

        /// <summary>
        /// Gets or sets the amount month12 oc.
        /// </summary>
        /// <value>The amount month12 oc.</value>
        public decimal AmountMonth12OC { get; set; }

        /// <summary>
        /// Gets or sets the budget provide code.
        /// </summary>
        /// <value>The budget provide code.</value>
        public string BudgetProvideCode { get; set; }

        /// <summary>
        /// Gets or sets the detail by.
        /// </summary>
        /// <value>The detail by.</value>
        public string DetailBy { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        public int MethodDistributeId { get; set; }
        public string ContractId { get; set; }
        public string CapitalPlanId { get; set; }
        public string ActivityId { get; set; }
    }
}
