using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class AccountTransferEntityDao : IEntityAccountTransferDao
    {
       
       public  List<AccountTransferEntity> GetAccountsTransfer(string connectionString)
        {  
            List<AccountTransferEntity> listAccount = new List<AccountTransferEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.AccountTransfers.ToList();
                foreach (var result in categories)
                {
                    var accountTransfer = new AccountTransferEntity();

                   accountTransfer.AccountTransferId    =result.AccountTransferID.ToString();
                   accountTransfer.BusinessType         =(result.BusinessType ==4?2: result.BusinessType)??0;
                   accountTransfer.AccountTransferCode  =result.AccountTransferCode;
                   accountTransfer.ReferentAccount      =result.ReferentAccount;
                   accountTransfer.TransferOrder        =result.TransferOrder??0;
                   accountTransfer.FromAccount          =result.FromAccount;
                   accountTransfer.ToAccount            =result.ToAccount;
                   accountTransfer.TransferSide         =result.TransferSide??0;
                   accountTransfer.BudgetSourceId      =result.BudgetSourceID.ToString();
                   accountTransfer.Description          =result.Description;
                   accountTransfer.IsSystem             =result.IsSystem;
                   accountTransfer.IsActive = result.Inactive == true ? false:true;
                   listAccount.Add(accountTransfer);

                }

               
            }

            return listAccount;
        }

      
    }
}
