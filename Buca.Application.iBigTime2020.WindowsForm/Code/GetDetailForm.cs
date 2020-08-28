using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.WindowsForm.FormBase.FormDetail;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BADeposit;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.BAWithDraw;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAPayment;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.CAReceipt;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Estimate;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.FixedAsset;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.General;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.IncrementDecrement;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.Inventory;
using Buca.Application.iBigTime2020.WindowsForm.FormBusiness.PUInvoice;

namespace Buca.Application.iBigTime2020.WindowsForm.Code
{
    public static class GetDetailForm
    {
        public static FrmXtraBaseVoucherDetail GetForm(string refType)
        {
            var refTypeId = int.Parse(refType);

            switch (refTypeId)
            {
                case 51: // nhận dự toán
                    return new FrmBUPlanReceiptDetail();
                case 53: // điều chỉnh dự toán
                    return new FrmBUPlanAdjustmentDetail();
                case 54: // rút dự toán tiền mặt
                    return new FrmBUPlanWithdrawCashDetail();
                case 55: // rút dự toán chuyển khoản
                    return new FrmBUPlanWithDrawTransferDetail();
                case 56: // Chuyển khoản kho bạc
                    return new FrmBUTransferDetail();
                case 57: // mua ccdc bằng chuyển khoản kho bạc
                    return new FrmBUTransferDetailPurchase();
                case 58: // mua TSCĐ bằng chuyển khoản kho bạc
                    return new FrmBUTransferDetailFixedAsset();
                case 60: //chuyển khoản trả lương
                    return new FrmBUTransfersPayWageDetail();
                case 61: //chuyển khoản trả bảo hiểm
                    return new FrmBUTransfersPayInsurranceDetail();
                case 63: //Bảng kê chứng từ thanh toán đã cấp dự toán
                    return new FrmBUVoucherListDetail();
                case 64: //Bảng kê chứng từ thanh toán chưa cấp dự toán
                    return new FrmBUNoEstimateVoucherListDetail();
                case 69: // hủy dự toán
                    return new FrmBUPlanCancelDetail();
                case 73: //dự toán giữ lại
                    return new FrmBUBudgetReserveDetail();
                case 71: //đề nghị cam kết chi
                    return new FrmBUCommitmentRequestDetail();
                case 72: //điều chỉnh cam kết chi
                    return new FrmBUCommitmentAdjustmentDetail();
                case 101:// phiếu thu
                    return new FrmCAReceiptDetail();
                case 105: // Phiếu thu từ ngân sách nhà nước
                    return new FrmCAReceiptEstimateDetail();
                case 106: // Phiếu chi
                    return new FrmCAPaymentDetail();
                case 107: // Phiếu chi mua vật tư hàng hóa
                    return new FrmCAPaymentInwardDetail();
                case 108: // mua TSCĐ bằng tiền mặt
                    return new FrmCAPaymentFixedAssetDetail();
                case 113: // Phiếu chi nộp tiền vào NH, KB
                    return new FrmCAPaymentTreasuryDetail();
                case 114: // Phiếu rút tiền gửi NH, KB
                    return new FrmCAReceiptTreasuryDetail();
                case 157:// chi tiền gửi
                    return new FrmBAWithDrawDetail();
                case 153:// chi tiền gửi
                    return new FrmBADepositDetail();
                case 158: // mua CCDC bằng tiền gửi
                    return new FrmBAWithDrawPurchaseDetail();
                case 159: // mua TSCD bằng tiền gửi
                    return new FrmBAWithDrawFixedAssetDetail();
                case 162: // chuyển tiền nội bộ
                    return new FrmBABankTransferDetail();
                case 201: // nhập kho
                    return new FrmCAPaymentInwardDetail();
                case 202: // Xuất kho
                    return new FrmINOutwardDetail();
                case 251: // mua TSCĐ chưa thanh toán
                    return new FrmPUInvoiceDetailFixedAsset();
                case 252: // nhận bằng hiện vật
                    return new frmFAIncrementDecrementDetail();
                case 253: // ghi giảm TSCĐ
                    return new FrmFADecrementDetail();
                case 254: // đánh giá lại tài sản
                    return new FrmRevaluationOfFixedAssetDetail();
                case 255: //hao mòn TSCĐ
                    return new FrmFADepreciationDetail();
                case 401: // chứng từ chung
                    return new FrmGLVoucherDetail();
                case 404: // Chứng từ xác định kết quả hoạt động 
                    return new FrmGLVouchersPerformanceResultsDetail();
                case 407: // Chứng từ ghi sổ
                    return new FrmGLVoucherListDetail();
                case 419: // Khấu hao TSCĐ
                    return new FrmFADevaluationDetail();
                case 561: //chuyển khoản kho bạc vào tài khoản tiền gửi
                    return new FrmBUTransferDepositDetail();
                case 562: // rút dự toán tiên gửi
                    return new FrmBUPlanWithDrawDepositDetail();
                case 563: // rút dư jtoán trả lương
                    return new FrmBUPlanWithDrawTransferInsurranceDetail();
            }
            return new FrmXtraBaseVoucherDetail();
        }
    }
}
