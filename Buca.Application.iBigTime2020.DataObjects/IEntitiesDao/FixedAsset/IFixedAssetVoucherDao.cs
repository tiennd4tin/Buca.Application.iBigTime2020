using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.FixedAsset;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.FixedAsset
{
    public interface IFixedAssetVoucherDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="FixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetVoucherEntity> GetFixedAssetVoucherByFixedAssetId(int FixedAssetId);
    }
}
