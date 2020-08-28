
using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Report.Voucher;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Report;
using System.Data;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Report
{
    /// <summary>
    /// Class VoucherReportFacade.
    /// </summary>
    public class VoucherReportFacade
    {
        private static readonly IVoucherReportDao VoucherReportDao = DataAccess.DataAccess.VoucherReportDao;

        #region Phiếu Chi
        /// <summary>
        /// Reports the cash payment C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C31BBEntity&gt;.</returns>
        public IEnumerable<C41BBEntity> ReportCashPaymentC41BB(string refId)
        {
            return VoucherReportDao.ReportCashPaymentC41BB(refId);
        }

        /// <summary>
        /// Reports the cash deposit C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C41BBEntity&gt;.</returns>
        public IEnumerable<C41BBEntity> ReportCashDepositC41BB(string refId)
        {
            return VoucherReportDao.ReportCashDepositC41BB(refId);
        }

        /// <summary>
        /// Reports the cash payment fixed asset C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C41BBEntity&gt;.</returns>
        public IEnumerable<C41BBEntity> ReportCashPaymentFixedAssetC41BB(string refId)
        {
            return VoucherReportDao.ReportCashPaymentFixedAssetC41BB(refId);
        }

        /// <summary>
        /// Reports the cash payment get from ba deposit.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C41BBEntity&gt;.</returns>
        public IEnumerable<C41BBEntity> ReportCashPaymentGetFromBADeposit(string refId)
        {
            return VoucherReportDao.ReportCashPaymentGetFromBADeposit(refId);
        }

        /// <summary>
        /// Reports the cash payment purchase C41 bb.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C41BBEntity&gt;.</returns>
        public IEnumerable<C41BBEntity> ReportCashPaymentPurchaseC41BB(string refId)
        {
            return VoucherReportDao.ReportCashPaymentPurchaseC41BB(refId);
        }

        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        public IList<C402CKBEntity> ReportC402CKB(string storeProdure, string refIdList)
        {
            return VoucherReportDao.GetReportC402C(storeProdure, refIdList);
        }
        public IList<C402CKBEntity> ReportC205ANS(string storeProdure, string refIdList)
        {
            return VoucherReportDao.ReportC205ANS(storeProdure, refIdList);
        }
        /// <summary>
        /// Reports the C402 CKB.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <param name="refIdList">The reference identifier list.</param>
        /// <returns></returns>
        public IList<C4_09Entity> ReportC409(string storeProdure, string refIdList)
        {
            return VoucherReportDao.GetReportC409(storeProdure, refIdList);
        }
        public IList<VoucherEntity> GetVoucherData(string refIdList, int reftype)
        {
            return VoucherReportDao.GetVoucherData(refIdList, reftype);
        }

        public IEnumerable<C41BBDetailEntity> ReportCashRPaymentC41BBDetails(string refId)
        {
            return VoucherReportDao.ReportCashPaymentC41BBDetails(refId);
        }

        public IEnumerable<C41BBDetailEntity> ReportCashPaymentPurchaseC41BBDetails(string refId)
        {
            return VoucherReportDao.ReportCashPaymentPurchaseC41BBDetails(refId);
        }

        public IEnumerable<C41BBDetailEntity> ReportCashPaymentFixedAssetC41BBDetails(string refId)
        {
            return VoucherReportDao.ReportCashPaymentFixedAssetC41BBDetails(refId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
        public IEnumerable<C41BBDetailEntity> ReportCashDepositC41BBDetails(string refId)
        {
            return VoucherReportDao.ReportCashDepositC41BBDetails(refId);
        }
        #endregion

        #region Phiếu thu
        public IEnumerable<C30BBEntity> ReportCashRecepitC30BB(string refId)
        {
            return VoucherReportDao.ReportCashRecepitC30BB(refId);
        }
        public IEnumerable<C45_BBEntity> ReportCashRecepitC45BB(string refId)
        {
            return VoucherReportDao.ReportCashRecepitC45BB(refId);
        }

        /// <summary>
        /// Reports the cash recepit C40 bb details.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IEnumerable<C40BBDetailEntity> ReportCashRecepitC40BBDetails(string refId)
        {
            return VoucherReportDao.ReportCashRecepitC40BBDetails(refId);
        }

        #endregion

        #region Giấy rút tiền mặt từ tài khoản
        /// <summary>
        /// Reports the cash payment C4 09.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IEnumerable&lt;C4_09Entity&gt;.</returns>
        public IEnumerable<C4_09Entity> ReportCAReceipt_C4_09(string refId, BuCA.Enum.RefType refType = BuCA.Enum.RefType.CAReceipt)
        {
            return VoucherReportDao.ReportCAReceipt_C4_09(refId, refType);
        }
        #endregion

        #region C203

        public IEnumerable<C203NSEntity> ReportC203NSTT77(string refId, DateTime StartDate, DateTime FiscalStartDate,
            string BudgetSourceKind, string TargetProgramID, string BankInfoID, string BudgetSourceID,
            string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, bool IsActiveTemplate, DateTime SystemDate, bool IsSystemDate, bool IsRefDate,
            bool CheckCashWithDrawType)
        {
            return VoucherReportDao.ReportC203NSTT77(refId, StartDate, FiscalStartDate,
                BudgetSourceKind, TargetProgramID, BankInfoID, BudgetSourceID,
                BudgetChapterCode, BudgetSubKindItemCode, MethodDistributeID,
                BudgetItemCodeList, IsActiveTemplate, SystemDate, IsSystemDate, IsRefDate,
                CheckCashWithDrawType);
        }

        public IEnumerable<C302NSEntity> GetReportC302NS(string refId, DateTime StartDate, int PayType,
            string TargetProgramID,
            string BudgetSourceID, string BudgetChapterCode, string BudgetSubKindItemCode, int MethodDistributeID,
            string BudgetItemCodeList, string InvestmentNumber, DateTime InvestmentDate, string YearPlan,
            bool CheckCashWithDrawType)
        {
            return VoucherReportDao.GetReportC302NS(refId, StartDate, PayType,
                TargetProgramID,
                BudgetSourceID, BudgetChapterCode, BudgetSubKindItemCode, MethodDistributeID,
                BudgetItemCodeList, InvestmentNumber, InvestmentDate, YearPlan,
                CheckCashWithDrawType);
        }

        #endregion

        #region Giấy rút dự toán
        public IEnumerable<C2_02aEntity> ReportBUPlanWithDraw(string refId, int IsGroupDetail, int IsShowDuplicate, int content, BuCA.Enum.RefType refType = BuCA.Enum.RefType.BUPlanWithDrawCash)
        {
            return VoucherReportDao.ReportBUPlanWithDraw(refId, IsGroupDetail, IsShowDuplicate, content, refType);
        }
        #endregion

        #region Phiếu xuất kho
        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDEntity&gt;.</returns>
        public IList<C21HDEntity> ReportCashReceiptSaleOutwardStock(string refId)
        {
            return VoucherReportDao.ReportCashReceiptSaleOutwardStock(refId);
        }

        /// <summary>
        /// Reports the cash receipt sale outward stock detail.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C21HDDetailEntity&gt;.</returns>
        public IList<C21HDDetailEntity> ReportCashReceiptSaleOutwardStockDetail(string refId)
        {
            return VoucherReportDao.ReportCashReceiptSaleOutwardStockDetail(refId);
        }

        #endregion

        #region Phiếu nhập kho
        /// <summary>
        /// Reports the cash receipt sale outward stock.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C20HDEntity&gt;.</returns>
        public IList<C20HDEntity> ReportCashReceiptSaleC20HD(string refId, int refType)
        {
            return VoucherReportDao.ReportCashReceiptSaleC20HD(refId, refType);
        }

        #endregion

        #region Giấy nộp tiền vào kho bạc

        /// <summary>
        /// Reports the cash payment C408.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<C408Entity> ReportCashPaymentC408(int refType, string refId)
        {
            return VoucherReportDao.ReportCashPaymentC408(refType, refId);
        }

        #endregion

        #region C2-12/NS: Giấy đề nghị cam kết chi NSNN (Thông tư số 77/2017/TT-BTC)
        /// <summary>
        /// Gets the C212 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C212NSEntity&gt;.</returns>
        public IList<C212NSEntity> GetC212NS(string refId)
        {
            return VoucherReportDao.GetC212NS(refId);
        }
        #endregion

        #region C2-13/NS: Phiếu điều chỉnh số liệu cam kết chi (TT số 77/2017/TT-BTC)
        /// <summary>
        /// Gets the C213 ns.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>IList&lt;C213NSEntity&gt;.</returns>
        public IList<C213NSEntity> GetC213NS(string refId)
        {
            return VoucherReportDao.GetC213NS(refId);
        }
        #endregion

        #region DataSet
        public DataSet GetDataSet(string storeProcedure, object[] parms)
        {
            return VoucherReportDao.GetDataSet(storeProcedure, parms);
        }
        #endregion

        #region C3-01/NS – Giấy rút vốn đầu tư

        public IList<C301NSEntity> ReportC301NS(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            return VoucherReportDao.ReportC301NS(refId, refTypeId, isDetail, isParent, mH);
        }

        public IList<C301NSDetailEntity> ReportC301NSDetail(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            return VoucherReportDao.ReportC301NSDetail(refId, refTypeId, isDetail, isParent, mH);
        }
        public IList<C301NSDetail2Entity> ReportC301NSDetail2(string refId, int refTypeId, bool isDetail, bool isParent, int mH)
        {
            return VoucherReportDao.ReportC301NSDetail2(refId, refTypeId, isDetail, isParent, mH);
        }
        #endregion

        #region C3-04/NS – Giấy nộp trả vốn đầu tư

        public IList<C304NSEntity> ReportC304NS(string refId)
        {
            return VoucherReportDao.ReportC304NS(refId);
        }
        #endregion

        #region C409KB - Giấy rút tiền mặt

        public IList<C409KBEntity> ReportC409KB(string refId, bool isDetail)
        {
            return VoucherReportDao.ReportC409KB(refId, isDetail);
        }

        public IList<C409KBDetailsEntity> ReportC409KBDetail(string refId, bool isDetail)
        {
            return VoucherReportDao.ReportC409KBDetail(refId, isDetail);
        }
        #endregion

        #region PaymentPurchase – Giấy đề nghị thanh toán vốn đầu tư

        public IList<PaymentPurchaseEntity> ReportPaymentPurchase(string refId)
        {
            return VoucherReportDao.ReportPaymentPurchase(refId);
        }
        #endregion
        
        #region C3-04/NS – Giấy nộp trả vốn đầu tư

        public IList<C205aEntity> ReportC205A(string refId)
        {
            return VoucherReportDao.ReportC205A(refId);
        }

        public IList<C206NSEntity> ReportC206NS(string refId)
        {
            return VoucherReportDao.ReportC206NS(refId);
        }
        #endregion


    }
}
