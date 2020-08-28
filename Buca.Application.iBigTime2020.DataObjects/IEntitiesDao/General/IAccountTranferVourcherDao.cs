/***********************************************************************
 * <copyright file="IGeneralDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using  Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.General
{
    /// <summary>
    /// IAccountTranferVourcherDao
    /// </summary>
  public  interface  IAccountTranferVourcherDao
  {

      /// <summary>
      /// Gets the account tranfer vourcher by reference identifier.
      /// </summary>
      /// <param name="refId">The reference identifier.</param>
      /// <returns></returns>
      IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByRefId(long refId);

      /// <summary>
      /// Insers the account tranfer vourcher.
      /// </summary>
      /// <param name="accountTranferVourcher">The account tranfer vourcher.</param>
      /// <returns></returns>
      int InserAccountTranferVourcher (AccountTranferVourcherEntity accountTranferVourcher);

      /// <summary>
      /// Deletes the account tranfer detail vourchers.
      /// </summary>
      /// <param name="refId">The reference identifier.</param>
      /// <returns></returns>
      string DeleteAccountTranferDetailVourchers(long refId);


      /// <summary>
      /// Gets the account tranfer vourcher by posted date and currency code.
      /// </summary>
      /// <param name="postedDate">The posted date.</param>
      /// <param name="currencyCode">The currency code.</param>
      /// <returns></returns>
      IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByPostedDateAndCurrencyCode(DateTime postedDate, string currencyCode);


      IList<AccountTranferVourcherEntity> GetAccountTranferVourchersByEdit(DateTime postedDate, string currencyCode, int refTypeId);
  }
}
