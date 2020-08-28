using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice
{
    public interface IPUInvoiceDao
    {
        List<PUInvoiceEntity> GetPUInvoicesByRefTypeId(int refTypeId);
        List<PUInvoiceEntity> GetPUInvoices();
        PUInvoiceEntity GetPUInvoice(string refId);
        PUInvoiceEntity GetPUInvoiceByRefNo(string refNo, DateTime postedDate);
        string UpdatePUInvoice(PUInvoiceEntity pUInvoice);
        string DeletePUInvoice(string refID);
    }
}
