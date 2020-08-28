using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class BankEntityDao : IEntityBankDao
    {
       
       public  List<BankEntity> GetBank(string connectionString)
        {  
            List<BankEntity> listAccount = new List<BankEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.BankInfoes.ToList();
                foreach (var result in categories)
                {
                    var bank = new BankEntity();

                    bank.BankId = result.BankInfoID.ToString();
                    bank.BankAccount = result.BankAccount;
                    bank.BankName = result.BankName;
                    bank.BankAddress = result.BankAddress;
                    bank.Description = result.Description;
                    bank.IsActive = result.Inactive ==true?false:true;
                    bank.IsOpenInBank = result.OpenInBudget ==true?false:true;

                    listAccount.Add(bank);

                }

               
            }

            return listAccount;
        }

      
    }
}
