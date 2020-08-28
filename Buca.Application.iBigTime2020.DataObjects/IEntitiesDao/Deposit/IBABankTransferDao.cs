using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    public interface IBABankTransferDao
    {
        BABankTransferEntity GetBABankTransfer(string refId);
        IList<BABankTransferEntity> GetBABankTransfers();
        BABankTransferEntity GetBABankTransferByRefNo(string refNo);
        BABankTransferEntity GetBABankTransferByRefNo(string refNo, DateTime postedDate);
        string InsertBABankTransfer(BABankTransferEntity bABankTransfer);
        string UpdateBABankTransfer(BABankTransferEntity bABankTransfer);
        string DeleteBABankTransfer(BABankTransferEntity bABankTransfer);



    }
}
