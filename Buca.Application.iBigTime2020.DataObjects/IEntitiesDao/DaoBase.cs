using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess
{
    public class DaoBase
    {
        public T Make<T>(IDataRecord record) where T : new()
        {
            T obj = new T();
            Type myType = obj.GetType();
            for (int i = 0; i < record.FieldCount; i++)
            {
                string fieldName = record.GetName(i);
                System.Reflection.PropertyInfo pro = myType.GetProperty(fieldName);
                if (pro == null)
                {
                    fieldName = fieldName.Replace("ID", "Id");
                    pro = myType.GetProperty(fieldName);
                }
                if (pro != null)
                {
                    var proType = pro.PropertyType;
                    var value = record[i];

                    if (proType.Equals(typeof(string)))
                        value = value.AsString(string.Empty);
                    else if (proType.Equals(typeof(bool)))
                        value = value.AsBool();
                    else if (proType.Equals(typeof(bool?)))
                        value = value.AsBoolForNull();
                    else if (proType.Equals(typeof(int)))
                        value = value.AsInt();
                    else if (proType.Equals(typeof(int?)))
                        value = value.AsIntForNull();
                    else if (proType.Equals(typeof(long)))
                        value = value.AsLong();
                    else if (proType.Equals(typeof(byte)))
                        value = value.AsByte();
                    else if (proType.Equals(typeof(short)))
                        value = value.AsShort();
                    else if (proType.Equals(typeof(short?)))
                        value = value.AsShortForNull();
                    else if (proType.Equals(typeof(double)))
                        value = value.AsDouble();
                    else if (proType.Equals(typeof(decimal)))
                        value = value.AsDecimal();
                    else if (proType.Equals(typeof(decimal?)))
                        value = value.AsDecimalForNull();
                    else if (proType.Equals(typeof(float)))
                        value = value.AsFloat();
                    else if (proType.Equals(typeof(float?)))
                        value = value.AsFloatForNull();
                    else if (proType.Equals(typeof(DateTime)))
                        value = value.AsDateTime();
                    else if (proType.Equals(typeof(DateTime?)))
                        value = value.AsDateTimeForNull();
                    else if (proType.Equals(typeof(Guid)))
                        value = value.AsGuid();
                    else
                        continue;

                    pro.SetValue(obj, value, null);
                }
            }

            return obj;
        }

        /// <summary>
        /// Dùng hàm này nếu insert hoặc update toàn bộ field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public object[] Take<T>(T input)
        {
            var orgType = input.GetType().GetProperties();
            var obj = new object[orgType.Length*2];
            for (int i = 0; i < orgType.Length; i++)
            {
                obj[i * 2] = "@" + orgType[i].Name.Replace("Id", "ID");
                if (obj[i * 2].ToString().Equals("@ValidationErrors"))
                    obj[i * 2 + 1] = null;
                else
                    obj[i * 2 + 1] = input.GetType().GetProperty(orgType[i].Name).GetValue(input, null) != null ? input.GetType().GetProperty(orgType[i].Name).GetValue(input, null) : null;
            }
            return obj;
        }
        public object[] Take(ContractEntity input)
        {
            /*var orgType = input.GetType().GetProperties();
            var obj = new object[orgType.Length * 2];
            for (int i = 0; i < orgType.Length; i++)
            {
                obj[i * 2] = "@" + orgType[i].Name.Replace("Id", "ID");
                if (obj[i * 2].ToString().Equals("@ValidationErrors"))
                    obj[i * 2 + 1] = null;
                else
                    obj[i * 2 + 1] = input.GetType().GetProperty(orgType[i].Name).GetValue(input, null) != null ? input.GetType().GetProperty(orgType[i].Name).GetValue(input, null) : null;
            }
            return obj;*/
            return new object[] { 
                "@ContractID", input.ContractId,
                "@ContractNo",input.ContractNo,
                "@ContractName",input.ContractName,
                "@ContractNameEnglish",input.ContractNameEnglish,
                "@SignDate",input.SignDate ,
                "@StartDate" ,input.StartDate,
                "@EndDate", input.EndDate,
                "@CurrencyCode",input.CurrencyCode,
                "@ExchangeRate",input.ExchangeRate,
                "@AmountOC",input.AmountOC,
                "@ProjectID", input.ProjectId,
                "@Description" ,input.Description,
                "@VendorID",input.VendorId,
                "@VendorBankAccountID",input.VendorBankAccountId,
                "@IsActive",input.IsActive,
            };
        }

        /// <summary>
        /// Dùng hàm này nếu insert hoặc update 1 số field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="listField"></param>
        /// <returns></returns>
        public object[] Take<T>(T input, string[] listField)
        {
            var obj = new object[listField.Length * 2];
            for (int i = 0; i < listField.Length; i++)
            {
                var newFieldName = listField[i].Replace("ID", "Id");
                var count = 0;//Biến tránh vòng lặp vô tận
                //Đưa field và dữ liệu vào mảng
                begin:
                obj[i * 2] = "@" + newFieldName;
                try
                {
                    obj[i * 2 + 1] = input.GetType().GetProperty(newFieldName).GetValue(input, null) != null ? input.GetType().GetProperty(newFieldName).GetValue(input, null) : null;
                }
                catch//Trả field name về như cũ nếu lỗi và retry, chỉ retry 1 lần, code cho phù hợp với kiểu đặt tên field cũ
                {
                    //Trả về ID nếu như không phải là Id
                    if (count <= 0)
                    {
                        count++;
                        newFieldName = listField[i].Replace("Id", "ID");
                        goto begin;
                    }
                }
            }
            return obj;
        }
    }
}
