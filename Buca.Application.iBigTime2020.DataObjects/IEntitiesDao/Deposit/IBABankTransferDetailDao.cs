using Buca.Application.iBigTime2020.BusinessEntities.Business.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Deposit
{
    public interface IBABankTransferDetailDao
    {
        IList<BABankTransferDetailEntity> GetBABankTransferDetailsByRefId(string refId);
        string InsertBABankTransferDetail(BABankTransferDetailEntity bABankTransferDetailEntity);
        string DeleteBABankTransferDetailByRefId(string refId);
    }
}
