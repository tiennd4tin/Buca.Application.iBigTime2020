
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// Interface IVoucherReport
    /// </summary>
    public interface IVoucherReportDao
    {
        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C31BBEntity&gt;.</returns>
        IList<C41BBEntity> ReportCashPaymentC41BB(string refId);

        /// <summary>
        /// Reports the cash payment C41 bb details.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C41BBDetailEntity> ReportCashPaymentC41BBDetails(string refId);

        /// <summary>
        /// Reports the cash Deposit C41 bb details (Tạm thời chưa dùng)
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<C41BBDetailEntity> ReportCashDepositC41BBDetails(string refId);

        /// <summary>
        /// Reports the cash Puchase C41 bb details
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<C41BBDetailEntity> ReportCashPaymentPurchaseC41BBDetails(string refId);

        /// <summary>
        /// Reports the cash FixedAsset C41 bb details
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<C41BBDetailEntity> ReportCashPaymentFixedAssetC41BBDetails(string refId);


        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        IList<C41BBEntity> ReportCashDepositC41BB(string refId);

        /// <summary>
        /// Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        IList<C41BBEntity> ReportCashPaymentFixedAssetC41BB(string refId);

        /// <summary>
        /// Reports the cash payment get from ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        IList<C41BBEntity> ReportCashPaymentGetFromBADeposit(string refId);

        /// <summary>
        /// Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C41BBEntity&gt;.</returns>
        IList<C41BBEntity> ReportCashPaymentPurchaseC41BB(string refId);

        /// <summary>
        /// Reports the cash payment C4 09.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C4_09Entity&gt;.</returns>
        IList<C4_09Entity> ReportCAReceipt_C4_09(string refId, BuCA.Enum.RefType refType = BuCA.Enum.RefType.CAReceipt);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="StartDate"></param>
        /// <param name="FiscalStartDate"></param>
        /// <param name="BudgetSourceKind"></param>
        /// <param name="TargetProgramID"></param>
        /// <param name="BankInfoID"></param>
        /// <param name="BudgetSourceID"></param>
        /// <param name="BudgetChapterCode"></param>
        /// <param name="BudgetSubKindItemCode"></param>
        /// <param name="MethodDistributeID"></param>
        /// <param name="BudgetItemCodeList"></param>
        /// <param name="IsActiveTemplate"></param>
        /// <param name="SystemDate"></param>
        /// <param name="IsSystemDate"></param>
        /// <param name="IsRefDate"></param>
        /// <param name="CheckCashWithDrawType"></param>
        /// <returns></returns>
        IList<C203NSEntity> ReportC203NSTT77(string refId, DateTime StartDate, DateTime FiscalStartDate,
            string BudgetSourceKind, string TargetProgramID, string BankInfoID, string BudgetSourceID,
            string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, bool IsActiveTemplate, DateTime SystemDate, bool IsSystemDate, bool IsRefDate,
            bool CheckCashWithDrawType);

        IList<C302NSEntity> GetReportC302NS(string refId, DateTime StartDate, int PayType,
            string TargetProgramID,
            string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, string InvestmentNumber, DateTime InvestmentDate, string YearPlan,
            bool CheckCashWithDrawType);

            /// <summary>
            /// Reports the bu plan with draw.
            /// </summary>
            /// <param name="refId">The reference identifier.</param>
            /// <param name="IsGroupDetail">The is group detail.</param>
            /// <param name="IsShowDuplicate">The is show duplicate.</param>
            /// <param name="content">The content.</param>
            /// <returns>IList&lt;C2_02aEntity&gt;.</returns>
        IList<C2_02aEntity> ReportBUPlanWithDraw(string refId, int IsGroupDetail, int IsShowDuplicate, int content, BuCA.Enum.RefType refType = BuCA.Enum.RefType.BUPlanWithDrawCash);

        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDEntity&gt;.</returns>
        IList<C21HDEntity> ReportCashReceiptSaleOutwardStock(string refId);


        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C20HDEntity&gt;.</returns>
        IList<C20HDEntity> ReportCashReceiptSaleC20HD(string refId, int refType);

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailEntity&gt;.</returns>
        IList<C21HDDetailEntity> ReportCashReceiptSaleOutwardStockDetail(string refidList);

        /// <summary>
        /// Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C30BBEntity> ReportCashRecepitC30BB(string refId);

        /// <summary>
        /// Reports the cash recepit C40 bb details.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C40BBDetailEntity> ReportCashRecepitC40BBDetails(string refId);

        /// <summary>
        /// Reports the cash recepit C30 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C45_BBEntity> ReportCashRecepitC45BB(string refId);

        /// <summary>
        /// Reports the cash payment.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<C408Entity> ReportCashPaymentC408(int refType, string refId);

        /// <summary>
        /// Gets the report C402 c.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<C402CKBEntity> GetReportC402C(string storeProdure, string refIdList);
        IList<C402CKBEntity> ReportC205ANS(string storeProdure, string refIdList);

        /// <summary>
        /// Gets the report C409.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        IList<C4_09Entity> GetReportC409(string storeProdure, string refIdList);

        /// <summary>
        /// Gets the voucher data.
        /// </summary>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <param name="reftype">The reftype.</param>
        /// <returns>IList&lt;VoucherEntity&gt;.</returns>
        IList<VoucherEntity> GetVoucherData(string refIdList, int reftype);

        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSEntity&gt;.</returns>
        IList<C212NSEntity> GetC212NS(string refId);

        /// <summary>
        /// Gets the C213 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C213NSEntity&gt;.</returns>
        IList<C213NSEntity> GetC213NS(string refId);

        DataSet GetDataSet(string storeProcedure, object[] parms);

        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSEntity&gt;.</returns>
        IList<C301NSEntity> ReportC301NS(string refId, int refTypeId, bool isDetail, bool isParent, int mH);
        IList<C301NSDetailEntity> ReportC301NSDetail(string refId, int refTypeId, bool isDetail, bool isParent, int mH);
        IList<C301NSDetail2Entity> ReportC301NSDetail2(string refId, int refTypeId, bool isDetail, bool isParent, int mH);

        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSEntity&gt;.</returns>
        IList<C304NSEntity> ReportC304NS(string refId);

        /// <summary>
        /// Giấy rút tiền mặt
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="isDetail"></param>
        /// <returns></returns>
        IList<C409KBEntity> ReportC409KB(string refId, bool isDetail);
        IList<C409KBDetailsEntity> ReportC409KBDetail(string refId, bool isDetail);

        /// <summary>
        /// Giấy đề nghị thanh toán vốn đầu tư
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<PaymentPurchaseEntity> ReportPaymentPurchase(string refId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<C205aEntity> ReportC205A(string refId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        IList<C206NSEntity> ReportC206NS(string refId);
    }
}
