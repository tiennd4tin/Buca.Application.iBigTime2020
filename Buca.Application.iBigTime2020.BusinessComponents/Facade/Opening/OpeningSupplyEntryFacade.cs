/***********************************************************************
 * <copyright file="OpeningSupplyEntryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018 Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening
{
    public class OpeningSupplyEntryFacade
    {
        private static readonly IOpeningSupplyEntryDao OpeningSupplyEntryDao = DataAccess.DataAccess.OpeningSupplyEntryDao;
        private static readonly ISupplyLedgerDao SupplyLedgerDao = DataAccess.DataAccess.SupplyLedgerDao;

        /// <summary>
        /// Gets the bu commitment requestby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(string refId)
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);
        }
        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedOpeningSupplyEntryDetail">if set to <c>true</c> [is included bu commitment request detail].</param>
        /// <returns>OpeningSupplyEntryEntity.</returns>
        public OpeningSupplyEntryEntity GetOpeningSupplyEntryVoucherByRefId(string refId, bool isIncludedOpeningSupplyEntryDetail)
        {
            var openingSupplyEntry = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);
            return openingSupplyEntry;
        }


        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry()
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntry();
        }
        /// <summary>
        /// Gets the bu commitment requests by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningSupplyEntryEntity&gt;.</returns>
        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId)
        {
            return OpeningSupplyEntryDao.GetOpeningSupplyEntrysByRefTypeId(refTypeId);
        }
        /// <summary>
        /// Inserts the bu commitment request.
        /// </summary>
        /// <param name="openingSupplyEntry">The b u commitment request.</param>
        /// <returns>OpeningSupplyEntryResponse.</returns>
        public OpeningSupplyEntryResponse InsertOpeningSupplyEntry(OpeningSupplyEntryEntity openingSupplyEntry)
        {
            var openingSupplyEntryResponse = new OpeningSupplyEntryResponse { Acknowledge = AcknowledgeType.Success };


            if (openingSupplyEntry != null && !openingSupplyEntry.Validate())
            {
                foreach (var error in openingSupplyEntry.ValidationErrors)
                    openingSupplyEntryResponse.Message += error + Environment.NewLine;
                openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                return openingSupplyEntryResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (openingSupplyEntry != null)
                {

                    if (!string.IsNullOrEmpty(openingSupplyEntryResponse.Message))
                    {
                        openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingSupplyEntryResponse;
                    }
                    openingSupplyEntry.RefId = Guid.NewGuid().ToString();
                    openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.InsertOpeningSupplyEntry(openingSupplyEntry);

                    if (!string.IsNullOrEmpty(openingSupplyEntryResponse.Message))
                    {
                        openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingSupplyEntryResponse;
                    }

                    if (openingSupplyEntryResponse.Message != null)
                    {
                        openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingSupplyEntryResponse;
                    }
                    openingSupplyEntryResponse.RefId = openingSupplyEntry.RefId;

                    scope.Complete();
                }

                return openingSupplyEntryResponse;
            }
        }
        /// <summary>
        /// Updates the bu commitment request.
        /// </summary>
        /// <param name="openingSupplyEntry">The b u commitment request.</param>
        /// <returns>OpeningSupplyEntryResponse.</returns>
        public OpeningSupplyEntryResponse UpdateOpeningSupplyEntry(IList<OpeningSupplyEntryEntity> openingSupplyEntries)
        {
            var openingSupplyEntryResponse = new OpeningSupplyEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntries();
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }
                #region Xóa bảng SupplyLedger
                openingSupplyEntryResponse.Message =
                    SupplyLedgerDao.DeleteSupplyLedgerByOPN();
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }

                #endregion

                #region Insert SupplyLedger

                if (openingSupplyEntries != null)
                {
                    foreach (var openingSupplyEntry in openingSupplyEntries)
                    {
                        if (!openingSupplyEntry.Validate())
                        {
                            foreach (string error in openingSupplyEntry.ValidationErrors)
                                openingSupplyEntryResponse.Message += error + Environment.NewLine;
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }

                        if (string.IsNullOrEmpty(openingSupplyEntry.RefId))
                            openingSupplyEntry.RefId = Guid.NewGuid().ToString();

                        openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.UpdateOpeningSupplyEntry(openingSupplyEntry);

                        if (!string.IsNullOrEmpty(openingSupplyEntryResponse.Message))
                        {
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }
                    }
                    //openingSupplyEntryResponse.RefId = openingSupplyEntries.First().RefId;
                    foreach (var openingSupplyEntriesDetail in openingSupplyEntries)
                    {
                        if (openingSupplyEntriesDetail.RefId != null)
                        {
                            var supplyLedgerEntity = new BusinessEntities.Business.SupplyLedgerEntity
                            {
                                SupplyLedgerId = Guid.NewGuid().ToString(),
                                RefId = openingSupplyEntriesDetail.RefId,
                                RefType = openingSupplyEntriesDetail.RefType,
                                RefNo = "OPN",
                                RefDate = openingSupplyEntriesDetail.PostedDate,
                                PostedDate = openingSupplyEntriesDetail.PostedDate,
                                DepartmentId = openingSupplyEntriesDetail.DepartmentId,
                                InventoryItemId = openingSupplyEntriesDetail.InventoryItemId,
                                Unit = null,
                                UnitPrice = openingSupplyEntriesDetail.UnitPrice,
                                IncrementQuantity = openingSupplyEntriesDetail.RefType == 602 ? openingSupplyEntriesDetail.Quantity : 0,
                                DecrementQuantity = openingSupplyEntriesDetail.RefType == 602 ? 0 : openingSupplyEntriesDetail.Quantity,
                                IncrementAmount = openingSupplyEntriesDetail.RefType == 602 ? openingSupplyEntriesDetail.Amount : 0,
                                DecrementAmount = openingSupplyEntriesDetail.RefType == 602 ? 0 : openingSupplyEntriesDetail.Amount,
                                //JournalMemo = openingSupplyEntriesDetail.JournalMemo,
                                //Description = openingSupplyEntriesDetail.Description,
                                //AccountNumber = openingSupplyEntriesDetail.DebitAccount,
                                RefDetailId = openingSupplyEntriesDetail.RefId
                            };
                            openingSupplyEntryResponse.Message = SupplyLedgerDao.InsertSupplyLedger(supplyLedgerEntity);
                            if (!string.IsNullOrEmpty(openingSupplyEntryResponse.Message))
                            {
                                openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                                return openingSupplyEntryResponse;
                            }
                        }
                    }
                    #endregion
                }
                scope.Complete();
            }
            return openingSupplyEntryResponse;
        }
        /// <summary>
        /// Deletes the bu commitment request.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningSupplyEntryResponse.</returns>
        public OpeningSupplyEntryResponse DeleteOpeningSupplyEntry(string refId)
        {
            var openingSupplyEntryResponse = new OpeningSupplyEntryResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var openingSupplyEntryForDelete = OpeningSupplyEntryDao.GetOpeningSupplyEntrybyRefId(refId);


                openingSupplyEntryResponse.Message = OpeningSupplyEntryDao.DeleteOpeningSupplyEntry(openingSupplyEntryForDelete);
                if (openingSupplyEntryResponse.Message != null)
                {
                    openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingSupplyEntryResponse;
                }

                #region Xóa bảng SupplyLedger
                        openingSupplyEntryResponse.Message =
                            SupplyLedgerDao.DeleteSupplyLedgerByRefId(refId);
                        if (openingSupplyEntryResponse.Message != null)
                        {
                            openingSupplyEntryResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return openingSupplyEntryResponse;
                        }
                    
                #endregion
                scope.Complete();
            }

            return openingSupplyEntryResponse;
        }
    }
}
