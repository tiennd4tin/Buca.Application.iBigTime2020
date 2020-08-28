using Buca.Application.iBigTime2020.BusinessEntities.Business.PUInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.PUInvoice
{
    public interface IPUInvoiceDetailFixedAssetDao
    {
        List<PUInvoiceDetailFixedAssetEntity> GetPUInvoiceDetailFixedAssets(string refId);
        string UpdatePUInvoiceDetailFixedAsset(PUInvoiceDetailFixedAssetEntity entity);
        string DeletePUInvoiceDetailFixedAssets(string refId);
    }
}
