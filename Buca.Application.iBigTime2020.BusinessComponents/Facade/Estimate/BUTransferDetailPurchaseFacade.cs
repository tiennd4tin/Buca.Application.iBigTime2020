/***********************************************************************
 * <copyright file="BUTransferFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, December 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, December 13, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Estimate;
using Buca.Application.iBigTime2020.BusinessEntities;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Estimate;
using Buca.Application.iBigTime2020.DataAccess;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Estimate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Estimate
{
    public class BUTransferDetailPurchaseFacade
    {
        private static readonly IBUTransferDetailPurchaseDao BUTransferDetailPurchaseDao = DataAccess.DataAccess.BUTransferDetailPurchaseDao;

        public List<BUTransferDetailPurchaseEntity> GetBUTransferDetailPurchasesByRefId(string refId)
        {
            return BUTransferDetailPurchaseDao.GetBUTransferDetailPurchasesByRefId(refId);
        }
    }
}
