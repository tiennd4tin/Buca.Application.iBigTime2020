using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert
{
    public interface IEntityPUInvoiceDao
    {
        List<PUInvoiceEntity> GetPUInvoices(string connectionString);
    }
}
