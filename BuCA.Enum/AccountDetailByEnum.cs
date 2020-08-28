using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuCA.Enum
{
    public enum AccountDetailByEnum
    {
        /// <summary>
        /// Nguồn vôn
        /// </summary>
        [EnumDescription("DetailByBudgetSource")]
        DetailByBudgetSource,

        /// <summary>
        /// Chương
        /// </summary>
        [EnumDescription("DetailByBudgetChapter")]
        DetailByBudgetChapter, // Chương

        /// <summary>
        /// Loại khoản
        /// </summary>
        [EnumDescription("DetailByBudgetKindItem")]
        DetailByBudgetKindItem, // Loại khoản

        /// <summary>
        /// Mục
        /// </summary> 
        [EnumDescription("DetailByBudgetItem")]
        DetailByBudgetItem, // Mục

        /// <summary>
        /// Loại mục
        /// </summary>
        [EnumDescription("DetailByBudgetSubItem")]
        DetailByBudgetSubItem, // Loại mục

        /// <summary>
        /// Dự án
        /// </summary>
        [EnumDescription("DetailByProject")]
        DetailByProject, // Dự án

        /// <summary>
        /// Đối tượng
        /// </summary>
        [EnumDescription("DetailByAccountingObject")]
        DetailByAccountingObject, // Đối tượng

        /// <summary>
        /// Hoạt động
        /// </summary>
        [EnumDescription("DetailByActivity")]
        DetailByActivity, // Hoạt động

        /// <summary>
        /// Vật tư
        /// </summary>
        [EnumDescription("DetailByInventoryItem")]
        DetailByInventoryItem, // Vật tư

        /// <summary>
        /// Tài khoản ngân hàng, kho bạc
        /// </summary>
        [EnumDescription("DetailByFixedAsset")]
        DetailByFixedAsset, // Tài sản

        /// <summary>
        /// Tài khoản ngân hàng, kho bạc
        /// </summary>
        [EnumDescription("DetailByBankAccount")]
        DetailByBankAccount, // Tài khoản ngân hàng, kho bạc

        /// <summary>
        /// Tiền tệ
        /// </summary>
        [EnumDescription("DetailByCurrency")]
        DetailByCurrency, // Tiền tệ

        /// <summary>
        /// Hình thức cấp phát
        /// </summary>
        [EnumDescription("DetailByMethodDistribute")]
        DetailByMethodDistribute, // Hình thức cấp phát
    }
}
