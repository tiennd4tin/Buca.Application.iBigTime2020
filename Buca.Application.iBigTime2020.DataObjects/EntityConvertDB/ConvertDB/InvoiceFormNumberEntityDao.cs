using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class InvoiceFormNumberEntityDao : IEntityInvoiceFormNumberDao
    {
       
       public  List<InvoiceFormNumberEntity> GetInvoiceFormNumber(string connectionString)
        {  
            List<InvoiceFormNumberEntity> listInvoiceFormNumber = new List<InvoiceFormNumberEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.InvoiceFormNumbers.ToList();
                foreach (var result in categories)
                {
                    var invoiceFormNumber = new InvoiceFormNumberEntity();
                    invoiceFormNumber.InvoiceFormNumberId = result.InvoiceFormNumberID.ToString();
                    invoiceFormNumber.InvoiceFormNumberCode = result.InvoiceFormNumberCode;
                    invoiceFormNumber.InvoiceFormNumberName = result.InvoiceFormNumberName;
                    invoiceFormNumber.InvoiceType = result.InvoiceType;
                    invoiceFormNumber.IsSystem = result.IsSystem;
                    invoiceFormNumber.IsActive = result.InActive == true?false:true;

                    listInvoiceFormNumber.Add(invoiceFormNumber);

                }

            }

            return listInvoiceFormNumber;
        }

      
    }
}
