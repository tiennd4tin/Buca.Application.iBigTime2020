/***********************************************************************
 * <copyright file="BaseVoucherModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, October 8, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.BaseModel
{
    public class BaseVoucherModel : IDataErrorInfo
    {
        /// <summary>
        /// Gets or sets the detail by.
        /// </summary>
        /// <value>
        /// The detail by.
        /// </value>
        [Browsable(true)]
        public string DetailBy { get; set; }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        [Browsable(false)]
        public string Error
        {
            get { return GetError(); }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return GetError(columnName); }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        string GetError(string columnName = null)
        {
            switch (columnName)
            {
                case "CurrencyCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Loại tiền không được để trống!" : null;
                    return null;
                case "AccountNumber":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Tài khoản không được để trống!" : null;
                    return null;
                case "CorrespondingAccountNumber":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Tài khoản đối ứng không được để trống!" : null;
                    return null;
                case "BudgetItemCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var accountCode = GetPropValue(this, "CorrespondingAccountNumber");
                        var budgetItemValue = GetPropValue(this, columnName);
                        if (accountCode != null && accountCode.ToString().StartsWith("6612") && budgetItemValue != null && !(budgetItemValue.ToString().StartsWith("6")
                            || budgetItemValue.ToString().StartsWith("7") || budgetItemValue.ToString().StartsWith("9")))
                        {
                            return "Mục tiểu mục yêu cầu cho bút toán này là loại Mục tiểu mục chi!";
                        }
                        return GetPropValue(this, columnName) == null ? "Mã mục lục ngân sách không được để trống!" : null;
                    }
                    return null;
                case "BudgetSourceCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nguồn vốn không được để trống!" : null;
                    return null;
                case "VoucherTypeId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Nghiệp vụ không được để trống!" : null;
                    return null;
                case "ProjectId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        if (GetPropValue(this, columnName) == null)
                        {
                            return "Mã dự án không được để trống!";
                        }
                        else
                        {
                            if ((int)GetPropValue(this, columnName) == 0)
                            {
                                return "Mã dự án không được để trống!";
                            }
                            return null;
                        }

                    return null;
                case "DepartmentId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã phòng ban không được để trống!" : null;
                    return null;
                case "FixedAssetId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã tài sản không được để trống!" : null;
                    return null;
                case "InventoryItemId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã vật tư không được để trống!" : null;
                    return null;
                case "AccountingObjectId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Đối tượng khác không được để trống!" : null;
                    return null;
                case "CustomerId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã khách hàng không được để trống!" : null;
                    return null;
                case "VendorId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nhà cung cấp không được để trống!" : null;
                    return null;
                case "EmployeeId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nhân viên không được để trống!" : null;
                    return null;
                case "Quantity":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var quantity = GetPropValue(this, columnName);
                        return quantity == null || (int)quantity == 0 ? "Số lượng phải khác 0!" : null;
                    }
                    return null;
                case "ExchangeRate":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var exchangeRate = GetPropValue(this, columnName);
                        return exchangeRate == null || Convert.ToDecimal(exchangeRate) == 0
                            ? "Tỷ giá phải khác 0!"
                            : null;
                    }
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="propName">Name of the property.</param>
        /// <returns></returns>
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
    public class BaseCheckErrorDetailByAccount : IDataErrorInfo
    {

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        [Browsable(false)]
        public string Error
        {
            get { return GetError(); }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return GetError(columnName); }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        string GetError(string columnName = null)
        {
            if (columnName != null)
            {
                if (GetPropValue(this, columnName) == null)
                {
                    Dictionary<string, string> ls1 = new Dictionary<string, string>();
                    Dictionary<string, string> ls2 = new Dictionary<string, string>();
                    var debitAccount = GetPropValue(this, "DebitAccount");
                    var creditAccount = GetPropValue(this, "CreditAccount");
                    if (debitAccount != null)
                    {
                        ls1 = new Dictionary<string, string>(getColumnValidDetailByAccount(debitAccount.ToString()));
                    }
                    if (creditAccount != null)
                    {
                        ls2 = new Dictionary<string, string>(getColumnValidDetailByAccount(creditAccount.ToString()));
                    }
                    var lsFinal = ls1.Union(ls2);
                    if (lsFinal.Count() > 0)
                    {
                        foreach (var cl in lsFinal)
                        {
                            if (cl.Key == columnName)
                            {
                                return cl.Value;
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="propName">Name of the property.</param>
        /// <returns></returns>
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName) != null ? src.GetType().GetProperty(propName).GetValue(src, null) : null;
        }
        //
        [Browsable(false)]
        public List<AccountModel> _lsAcount = null;
        [Browsable(false)]
        public List<AccountModel> lsAcount
        {
            get
            {
                if (_lsAcount == null)
                {
                    Model model = new Model();
                    _lsAcount= model.GetAccounts().ToList();
                }
                return _lsAcount;
            }
        }
        private Dictionary<string, string> getColumnValidDetailByAccount(string AccountNumber)
        {
            Dictionary<string, string> ls = new Dictionary<string, string>();
            var accountModel = lsAcount.Where(p => p.AccountNumber == AccountNumber).FirstOrDefault();
            if (accountModel != null)
            {
                // Hop dong
                if (accountModel.DetailByContract)
                {
                    ls.Add("ContractId","Vui lòng chọn hợp đồng");
                }
                // Nguồn
                if (accountModel.DetailByBudgetSource)
                {
                    ls.Add("BudgetSourceId", "Vui lòng chọn nguồn");
                }

                // Chương
                if (accountModel.DetailByBudgetChapter)
                {
                    ls.Add("BudgetChapterCode", "Vui lòng chọn chương");
                }

                // Loại khoản
                if (accountModel.DetailByBudgetKindItem)
                {
                    ls.Add("BudgetSubKindItemCode", "Vui lòng chọn khoản");
                }

                // Mục
                if (accountModel.DetailByBudgetItem)
                {
                    ls.Add("BudgetItemCode", "Vui lòng chọn muc");
                }

                // Tiểu mục - loại mục
                if (accountModel.DetailByBudgetSubItem)
                {
                    ls.Add("BudgetSubItemCode", "Vui lòng chọn tiểu mục");
                }

                // Dự án 
                if (accountModel.DetailByProject)
                {
                    ls.Add("ProjectId", "Vui lòng chọn dự án");
                }

                // Đối tượng
                if (accountModel.DetailByAccountingObject)
                {
                    ls.Add("AccountingObjectId", "Vui lòng chọn đối tượng");
                }

                // Hoạt động
                if (accountModel.DetailByActivity)
                {
                    ls.Add("ActivityId", "Vui lòng chọn hoạt động");
                }

                // Vật tư
                if (accountModel.DetailByInventoryItem)
                {
                    ls.Add("InventoryItemId", "Vui lòng chọn vật tư");
                }

                // Tài sản
                if (accountModel.DetailByFixedAsset)
                {
                    ls.Add("FixedAssetId", "Vui lòng chọn tài sản");
                }

                // Ngân hàng, kho bạc
                if (accountModel.DetailByBankAccount)
                {
                    ls.Add("BankId", "Vui lòng chọn ngân hàng, kho bạc");
                }

                // Tiền tệ
                if (accountModel.DetailByCurrency)
                {
                    ls.Add("CurrencyId", "Vui lòng chọn tiền tệ");
                }

                // Hình thức cấp phát
                if (accountModel.DetailByMethodDistribute)
                {
                    ls.Add("MethodDistributeId", "Vui lòng chọn cấp phát");
                }

                // Khoản chi
                if (accountModel.DetailByExpense)
                {
                    ls.Add("FundStructureId", "Vui lòng chọn khoản chi");
                }
            }
            return ls;
        }
    }
}
