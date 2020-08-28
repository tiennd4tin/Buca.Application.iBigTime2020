/***********************************************************************
 * <copyright file="IJournalEntryAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessEntities.Business;
using System.Collections.Generic;
using System.Data;

namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao
{
    /// <summary>
    /// IJournalEntryAccountDao
    /// </summary>
    public interface IGeneralLedgerDao
    {
        /// <summary>
        /// Inserts the general ledger.
        /// </summary>
        /// <param name="generalLedgerEntity">The general ledger entity.</param>
        /// <returns>System.Int32.</returns>
        string InsertGeneralLedger(GeneralLedgerEntity generalLedgerEntity);

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteGeneralLedger(string refId);

        /// <summary>
        /// Deletes the general ledger.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns></returns>
        string DeleteGeneralLedger(string accountNumber, int refType);

        /// <summary>
        /// Gets the main currency identifier from database option.
        /// </summary>
        /// <param name="OptionID">The option identifier.</param>
        /// <returns>System.String.</returns>
        DataTable GetMainCurrencyIDFromDBOption(string OptionID);
    }
}
