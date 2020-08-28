using Buca.Application.iBigTime2020.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Buca.Application.iBigTime2020.WindowsForm.Code
{
    public class CommonText
    {
        #region Report list Id
        public static string ReportFixedAssetTag = "FixedAssetTag";
        public const string ReportTT39 = "106_BK.TT39.2016";
        #endregion

        #region Caption Message
        public static string DetailContent = ResourceHelper.GetResourceValueByName("ResDetailContent");
        #endregion

        #region Caption form
        public const string CaptionPUInvoices = "Mua TSCĐ chưa thanh toán";
        public const string CaptionFAIncrementDecrement = "Ghi tăng TSCĐ nhận bằng hiện vật";
        public const string DetailNullValid = "Banj ch]a";
        #endregion

        #region FixedAsset Valid
        public const string FixedAssetValid = "Bạn chưa chọn tài sản";
        public const string DebitAccountValid = "Bạn chưa chọn TK nợ";
        public const string DebitAccountNotExists = "TK nợ không tồn tại";
        public const string CreditAccountValid = "Bạn chưa chọn TK có";
        public const string CreditAccountNotExists = "TK có không tồn tại";
        public const string IncrementRefNoValid = "Bạn chưa nhập số chứng từ ghi tăng";
        #endregion

        #region Account Number
        public const string AccountNumber3341 = "3341";
        public const string AccountNumber1121 = "1121";
        public const string AccountNumber61111 = "61111";
        #endregion

        #region Show Message
        public static void ShowMessageWarning(string message)
        {
            XtraMessageBox.Show(message, DetailContent, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
    }
}
