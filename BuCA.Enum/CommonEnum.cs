/***********************************************************************
 * <copyright file="CommonEnum.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, March 03, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace BuCA.Enum
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public static string GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var description = value.ToString();
            var fieldInfo = value.GetType().GetField(description);
            var attributes =
                (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <summary>
        /// To the list.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">type</exception>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var list = new ArrayList();
            var enumValues = System.Enum.GetValues(type);
            var i = -1;
            foreach (var value in enumValues)
            {
                i += 1;
                list.Add(new KeyValuePair<int, string>(i, GetDescription((System.Enum)value)));
            }
            return list;
        }
    }

    /// <summary>
    /// Enum Description Attribute
    /// </summary>
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private readonly string _description;

        public string Description
        {
            get { return _description; }
        }

        public EnumDescriptionAttribute(string description)
        {
            _description = description;
        }
    }

    public enum CommonEnum
    {

    }

    public enum EnumNavigationStatus
    {
        FirstPosition = 0,
        LastPosition = 1,
        InsidePosition = 2,
        EmptyPostion = 3,
        OnlyOneRow = 4,
        CloseForm = 5
    }

    /// <summary>
    /// Enum of  state of fixed asset
    /// </summary>
    public enum FixedAssetState
    {
        [EnumDescription("Mua chưa dùng")]
        NotUse,
        [EnumDescription("Đang dùng")]
        Using,
        [EnumDescription("Đang dùng - Dừng tính khấu hao")]
        UsingNotDepreciation,
        [EnumDescription("Đã thanh lý")]
        Disposed,
        [EnumDescription("Đã chuyển nhượng")]
        Transferred,
        [EnumDescription("Ghi giảm theo số lượng")]
        DisposedByQuantity
    }
    public enum FixedAssetActivity
    {
        [EnumDescription("Hoạt động hành chính")]
        MainActivity,
        [EnumDescription("Hoạt động dự án")]
        ProjectActivity,
        [EnumDescription("Hoạt động thu phí ")]
        FeeActivity,
        [EnumDescription("Hoạt động SX, KD")]
        ProductActivity,
        [EnumDescription("Hoạt động quản lý SX, KD")]
        ManagerActivity,
        [EnumDescription("Hoạt động phúc lợi")]
        BenifitActivity,
        [EnumDescription("Hoạt động khác")]
        OrtherActivity
    }

    public enum AccountKind
    {
        [EnumDescription("Dư Nợ")]
        DebitAccount,
        [EnumDescription("Dư Có")]
        CreditAccount,
        [EnumDescription("Lưỡng tính")]
        Other,
    }
    public enum DebitAccountNumber
    {
        [EnumDescription("0092")]
        DebitAccount
    }

    public enum BudgetExpenseType
    {
        [EnumDescription("Phí")]
        Fee,
        [EnumDescription("Lệ phí")]
        Expense
    }

    public enum PlanType
    {
        [EnumDescription("Dự toán thu")]
        Receipt,
        [EnumDescription("Dự toán chi")]
        Payment,
    }

    public enum ControlValueType
    {
        [EnumDescription("Money")]
        Money,
        [EnumDescription("Quantity")]
        Quantity,
        [EnumDescription("Rate")]
        Rate,
        [EnumDescription("ExchangeRate")]
        ExchangeRate,
        [EnumDescription("Year")]
        Year,
        [EnumDescription("Percent")]
        Percent
    }

    public enum AccountTransferBusinessType
    {
        //[EnumDescription("Quyết toán số dư đầu năm")]
        [EnumDescription("Kết chuyển TK dự toán chi ĐTXDCB")]
        Openning,
        //[EnumDescription("Kết chuyển số dư cuối năm")]
        //Closing,
        [EnumDescription("Xác định kết quả hoạt động")]
        Estimate,
        //[EnumDescription("Kết chuyển TT Ghi thu - Ghi chi")]
        [EnumDescription("Kết chuyển chi phí XDCB chờ quyết toán")]
        Receipt,
        //[EnumDescription("Kết chuyển chênh lệch thu, chi")]
        [EnumDescription("Quyết toán dự án hoàn thành")]
        Difference,
        [EnumDescription("Tài khoản dự toán ghi đồng thời")]
        Contemporaneous
    }

    public enum AccountTransferSide
    {
        [EnumDescription("Nợ")]
        DebitSide,
        [EnumDescription("Có")]
        CreditSide,
        [EnumDescription("Hai bên")]
        Other,
    }

    public enum MethodDistribute
    {
        [EnumDescription("Dự toán")]
        Estimate,
        [EnumDescription("Lệnh chi")]
        PaymentOrder,
        [EnumDescription("Hiện vật")]
        Item,
        [EnumDescription("Ghi thu - Ghi chi")]
        Recording,
        [EnumDescription("Khác")]
        Other,
    }
    public enum Description
    {
        [EnumDescription("Khấu hao tài sản cố định")]
        KhauHao,
        [EnumDescription("Hao mòn tài sản cố định")]
        HaoMon

    }

    public enum InvoiceType
    {
        [EnumDescription("Không có hóa đơn")]
        NonInvoice = 0,
        [EnumDescription("Hoá đơn thông thường")]
        GeneralInvoice = 1,
        [EnumDescription("Hóa đơn giá trị gia tăng")]
        ValueAddedInvoice = 2
    }

    /// <summary>
    /// DecreaseReason
    /// </summary>
    public enum DecreaseReason
    {
        [EnumDescription("Thanh lý")]
        Liquidation = 1,
        [EnumDescription("Điều chuyển")]
        Transfer = 2,
        [EnumDescription("Bán")]
        Sell = 3,
        [EnumDescription("Chuyển sang CCDC")]
        SwitchToTool = 4,
        [EnumDescription("Chuyển nhượng")]
        Assign = 5,
        [EnumDescription("Mất")]
        Lost = 6,
        [EnumDescription("Tiêu hủy")]
        Destruction = 7,
        [EnumDescription("Hình thức khác")]
        AnotherForm = 8
    }

    public enum InvType
    {
        /// <summary>
        /// Không có hóa đơn
        /// </summary>
        [EnumDescription("Không có hóa đơn")]
        Estimate = 0,

        /// <summary>
        /// Hóa đơn thông thường
        /// </summary>
        [EnumDescription("Hóa đơn thông thường")]
        PaymentOrder = 1,

        /// <summary>
        /// Hóa đơn GTGT
        /// </summary>
        [EnumDescription("Hóa đơn GTGT")]
        Item = 2,
    }
}
