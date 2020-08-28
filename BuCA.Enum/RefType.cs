namespace BuCA.Enum
{
    /// <summary>
    /// Enum RefType
    /// </summary>
    public enum RefType
    {
        /// <summary>
        /// The ca receipt
        /// </summary>
        [EnumDescription("Phiếu thu")]
        CAReceipt = 101, //Phiếu thu

        /// <summary>
        /// The ca receipt sales
        /// </summary>
        [EnumDescription("Phiếu thu bán hàng")]
        CAReceiptSales = 102, //Phiếu thu bán hàng

        /// <summary>
        /// The ca receipt fixed asset
        /// </summary>
        [EnumDescription("Phiếu thu bán tài sản cố định")]
        CAReceiptFixedAsset = 103, //Phiếu thu bán tài sản cố định

        /// <summary>
        /// The ca receipt customer
        /// </summary>
        [EnumDescription("Phiếu thu tiền khách hàng")]
        CAReceiptCustomer = 104, //Phiếu thu tiền khách hàng

        /// <summary>
        /// The ca payment inventory item
        /// </summary>
        [EnumDescription("Phiếu chi mua vật tư hàng hóa")]
        CAPaymentInventoryItem = 107, //Phiếu chi mua vật tư hàng hóa

        /// <summary>
        /// The ca receipt estimate
        /// </summary>
        [EnumDescription("Phiếu thu từ ngân sách nhà nước")]
        CAReceiptEstimate = 105, //Phiếu thu từ ngân sách nhà nước

        /// <summary>
        /// The ca receipt tresury
        /// </summary>
        [EnumDescription("Phiếu thu rút tiền gửi NH, KB")]
        CAReceiptTreasury = 114, //Phiếu thu rút tiền gửi NH, KB

        /// <summary>
        /// The ca payment treasury
        /// </summary>
        [EnumDescription("Phiếu chi nộp tiền vào NH, KB")]
        CAPaymentTreasury = 113, //Phiếu thu rút tiền gửi NH, KB

        /// <summary>
        /// The ca payment
        /// </summary>
        [EnumDescription("Phiếu chi ")]
        CAPayment = 106, //Phiếu thu rút tiền gửi NH, KB

        /// <summary>
        /// The ca payment detail fixed asset
        /// </summary>
        [EnumDescription("Phiếu chi mua tài sản cố định")]
        CAPaymentDetailFixedAsset =
            108, //Phiếu chi mua tài sản cố định

        /// <summary>
        /// The ba deposit collection
        /// </summary>
        [EnumDescription("Thu tiền gửi")]
        BADeposit = 153,

        /// <summary>
        /// The ba deposit money
        /// </summary>
        [EnumDescription("Chi tiền gửi mua vật tư hàng hóa")]
        BAWithDrawPurchase = 158,

        /// <summary>
        /// The ba deposit money
        /// </summary>
        [EnumDescription("Chi tiền gửi")]
        BAWithDraw = 157,

        /// <summary>
        /// The in inward
        /// </summary>
        [EnumDescription("Nhập kho")]
        INInward = 201,

        /// <summary>
        /// The in outward
        /// </summary>
        [EnumDescription("Xuất kho")]
        INOutward = 202,

        /// <summary>
        /// The su increment
        /// </summary>
        [EnumDescription("Ghi tăng công cụ dụng cụ")]
        SUIncrement = 205,

        /// <summary>
        /// The su decrement
        /// </summary>
        [EnumDescription("Ghi giảm công cụ dụng cụ")]
        SUDecrement = 206,

        /// <summary>
        /// The su decrement
        /// </summary>
        [EnumDescription("Điều chuyển công cụ dụng cụ")]
        SUTransfer = 207,

        /// <summary>
        /// The fa depreciation
        /// </summary>
        [EnumDescription("Hao mòn TSCĐ")]
        FADepreciation = 255,

        /// <summary>
        /// The fa depreciation
        /// </summary>
        [EnumDescription("Ghi giảm tài sản cố định")]
        FADecrement = 253,

        [EnumDescription("Đánh giá lại tài sản cố định")]
        RevaluationOfFixedAsset = 254,

        /// <summary>
        /// The ba with draw fixed asset
        /// </summary>
        [EnumDescription("Chi tiền gửi mua tài sản cố định")]
        BAWithDrawFixedAsset = 159,

        /// <summary>
        /// The bu plan with draw cash
        /// Rút dự toán tiền mặt
        /// </summary>
        [EnumDescription("Rút dự toán tiền mặt")]
        BUPlanWithDrawCash = 54,

        /// <summary>
        /// The bu plan with draw deposit
        /// </summary>
        [EnumDescription("Rút dự toán tiền gửi")]
        BUPlanWithDrawDeposit = 562,

        /// <summary>
        /// The bu plan with draw transfer
        /// </summary>
        [EnumDescription("Rút dự toán tiền gửi")]
        BUPlanWithDrawTransfer = 55,

        /// <summary>
        /// The bu plan with draw transfer
        /// </summary>
        [EnumDescription("Hủy dự toán")]
        BUPlanCancel = 69,

        /// <summary>
        /// The bu plan receipt early year
        /// </summary>
        [EnumDescription("Rút dự toán tiền gửi")]
        BUPlanReceiptEarlyYear = 51,

        /// <summary>
        /// The bu plan receipt addition
        /// </summary>
        [EnumDescription("Rút dự toán tiền gửi")]
        BUPlanReceiptAddition = 52,
        
        [EnumDescription("Rút dự toán chuyển lương, bảo hiểm")]
        BUPlanWithdrawTransferInsurrance = 563,

        /// <summary>
        /// The gl voucher
        /// </summary>
        [EnumDescription("Chứng từ chung")]
        GLVoucher = 401,

        [EnumDescription("Chi phí ĐTXDCB chờ quyết toán")]
        GLVoucherLastYear = 402,

        [EnumDescription("Quyết toán dự án hoàn thành")]
        GLVoucherEarlyYear = 403,

        [EnumDescription("Xác định kết quả hoạt động")]
        GLVoucherPerformanceResults = 404,
        /// <summary>
        /// The bu commitment request
        /// </summary>
        [EnumDescription("Đề nghị cam kết chi")]
        BUCommitmentRequest = 71,

        /// <summary>
        /// The bu commitment adjustment
        /// </summary>
        [EnumDescription("Điều chỉnh cam kết chi")]
        BUCommitmentAdjustment = 72,

        /// <summary>
        /// The opening commitment
        /// </summary>
        [EnumDescription("Cam kết chi ban đầu")]
        OpeningCommitment = 606,

        /// <summary>
        /// The ba bank transfer
        /// </summary>
        [EnumDescription("Chuyển tiền nội bộ")]
        BABankTransfer = 162,

        /// <summary>
        /// The bu budget reserve
        /// </summary>
        [EnumDescription("Dự toán giữ lại")]
        BUBudgetReserve = 73,

        /// <summary>
        /// The bu transfer
        /// </summary>
        [EnumDescription("Chuyển khoản kho bạc")]
        BUTransfer = 56,

        /// <summary>
        /// The bu transfer
        /// </summary>
        [EnumDescription("Bảng kê chứng từ thanh toán đã rút dự toán")]
        BUVoucherList = 63,

        /// <summary>
        /// The bu voucher list
        /// </summary>
        [EnumDescription("Bảng kê chứng từ thanh toán chưa cấp dự toán")]
        BUNoEstimateVoucherList = 64,

        /// <summary>
        /// The bu cash basic voucher list
        /// </summary>
        [EnumDescription("Bảng kê chứng từ thanh toán thực chi")]
        BUCashBasicVoucherList=70,

        [EnumDescription("Chuyển khoản kho bạc trả lương")]
        BUTransferPayWage = 60,

        [EnumDescription("Chuyển khoản kho bạc trả bảo hiểm")]
        BUTransferPayInsurrance = 61,
        /// <summary>
        /// The bu transfer deposits
        /// </summary>
        [EnumDescription("Chuyển khoản kho bạc vào TK tiền gửi")]
        BUTransferDeposits = 561,

        [EnumDescription("Điều chỉnh dự toán")]
        BUPlanAdjustment = 53,

        [EnumDescription("Chứng từ ghi sổ")]
        GLVoucherList = 407,

        [EnumDescription("Phân bổ thanh toán tạm ứng")]
        GLPaymentList = 409,

        [EnumDescription("Số dư ban đầu công cụ dụng cụ và vật tư")]
        OpeningInventoryEntry = 601,

        [EnumDescription("Số dư Công cụ dụng cụ")]
        OpeningSupplyEntry = 602,

        /// <summary>
        /// Chuyển khoản kho bạc mua vật tư hàng hóa
        /// </summary>
        [EnumDescription("Chuyển khoản kho bạc mua vật tư hàng hóa")]
        BUTransferPurchase = 57,

        /// <summary>
        /// Chuyển khoản kho bạc mua TSCĐ
        /// </summary>
        [EnumDescription("Chuyển khoản kho bạc mua TSCĐ")]
        BUTransferFixedAsset = 58,
        /// <summary>
        /// Số dư đầu kì TSCĐ
        /// </summary>
        [EnumDescription("Số dư đầu kì TSCĐ")]
        OpeningFixedAsset = 603,

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        [EnumDescription("Mua TSCĐ chưa thanh toán")]
        PUInvoiceFixedAsset = 251,

        /// <summary>
        /// Tăng TSCĐ nhận bằng hiện vật
        /// </summary>
        [EnumDescription("Tăng TSCĐ nhận bằng hiện vật")]
        FAIncrementDecrement = 252,

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        [EnumDescription("Trích khấu hao tài sản cố định")]
        FADevaluation = 419,

        /// <summary>
        /// Mua TSCĐ chưa thanh toán
        /// </summary>
        [EnumDescription("Dư đầu kỳ tài khoản")]
        OpeningAccountEntry = 1002,
        /// <summary>
        /// Chi phí ĐTXDCB chờ quyết toán"
        /// </summary>
    }
}