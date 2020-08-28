


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class FixedAssetFacade.
    /// </summary>
    public class FixedAssetFacade : FacadeBase
    {
        private static readonly IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao = DataAccess.DataAccess.OpeningFixedAssetEntryDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        //private static readonly IFixedAssetCurrencyDao FixedAssetCurrencyDao = DataAccess.DataAccess.FixedAssetCurrencyDao;
        private static readonly IFixedAssetDetailAccessoryDao FixedAssetDetailAccessoryDao = DataAccess.DataAccess.FixedAssetDetailAccessoryDao;

        /// <summary>
        /// Gets the fixed assets.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssets()
        {
            return FixedAssetDao.GetFixedAssets();
        }

        /// <summary>
        /// Gets the fixed assets active.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsActive()
        {
            return FixedAssetDao.GetFixedAssetsByActive(true);
        }
        public List<FixedAssetEntity> GetFixedAssetsActiveDecre(bool isActive, string refId)
        {
            return FixedAssetDao.GetFixedAssetsActiveDecre(isActive, refId);
        }
        /// <summary>
        /// Gets the fixed assets for decrement.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsForDecrement(bool isActive, DateTime refDate)
        {
            return FixedAssetDao.GetFixedAssetsForDecrement(isActive, refDate);
        }

        /// <summary>
        /// Gets the fixed assets for adjustment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="isForceGetOnLedger">if set to <c>true</c> [is force get on ledger].</param>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsForAdjustment(string fixedAssetId, DateTime postedDate, int refType,
            bool isForceGetOnLedger)
        {
            return FixedAssetDao.GetFixedAssetsForAdjustment(fixedAssetId, postedDate, refType, isForceGetOnLedger);
        }

        /// <summary>
        /// Gets the fixed assets by increment.
        /// </summary>
        /// <returns></returns>
        public List<FixedAssetEntity> GetFixedAssetsByIncrement(string fixedAssetId)
        {
            return FixedAssetDao.GetFixedAssetsByIncrement(fixedAssetId);
        }

        /// <summary>
        /// Gets the fixed asset by asset code.
        /// </summary>
        /// <param name="assetcode">The assetcode.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetByAssetCode(string assetcode)
        {
            return FixedAssetDao.GetFixedAssetByCode(assetcode);
        }

        /// <summary>
        /// Gets the fixed asset by assetid.
        /// </summary>
        /// <param name="assetId">The asset identifier.</param>
        /// <returns></returns>
        public FixedAssetEntity GetFixedAssetByAssetid(string assetId)
        {
            var fixedasset = FixedAssetDao.GetFixedAssetById(assetId);
            if (fixedasset != null)
            {
                fixedasset.FixedAssetDetailAccessories =
                    FixedAssetDetailAccessoryDao.GetFixedAssetByFixedAssetId(assetId);
                fixedasset.FixedAssetVoucherAttachs = FixedAssetDao.GetFixedAssetVoucherAttachByFixedAssetId(assetId);
            }
            return fixedasset;
        }

        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="systemDate">The system date.</param>
        /// <returns></returns>
        public FixedAssetResponse DeleteFixedAsset(string fixedAssetId, DateTime systemDate)
        {
            var response = new FixedAssetResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(fixedAssetId);

                    if (fixedAssetEntity != null && !string.IsNullOrEmpty(fixedAssetEntity.RefId) && fixedAssetEntity.PurchasedDate < systemDate)
                    {
                        AutoMapper(DeleteGeneralLedger(fixedAssetEntity.RefId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        AutoMapper(DeleteOriginalLedger(fixedAssetEntity.RefId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        AutoMapper(DeleteOpeningFixedAssetEntry(fixedAssetEntity.FixedAssetId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        if (fixedAssetEntity.RefType == 603)
                        {
                            AutoMapper(DeleteFixAssetLedger603(fixedAssetEntity.FixedAssetId, fixedAssetEntity.RefType),
                                response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                            //Xóa ts dư đầu kỳ
                            AutoMapper(DeleteGeneralLedger(fixedAssetId), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                        }
                        else
                        {
                            AutoMapper(DeleteFixAssetLedger(fixedAssetEntity.RefId, fixedAssetEntity.RefType),
                                response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                        }

                        response.Message = OpeningFixedAssetEntryDao.DeleteOpeningFixedAssetEntry(fixedAssetEntity.RefId);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;
                    }

                    response.Message = FixedAssetDao.DeleteFixedAsset(fixedAssetEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        if (response.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            response.Message = "Tài sản đã phát sinh trong chứng từ liên quan, không thể xóa!";
                        }
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    response.Message = FixedAssetDao.DeleteFixedAssetActivity(fixedAssetEntity);

                #region Error
                Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    #endregion

                    response.FixedAssetId = fixedAssetEntity.FixedAssetId;
                    scope.Complete();
                    return response;
                }
                catch (Exception e)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = e.Message;
                    return response;
                }
            }

        }

        public FixedAssetResponse DeleteFixedAssetConvert()
        {
            var response = new FixedAssetResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    response.Message = FixedAssetDao.DeleteFixedAssetConvert();
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        if (response.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            response.Message = "Tài sản đã phát sinh trong chứng từ liên quan, không thể xóa!";
                        }
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Error
                    Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    #endregion

                   
                    scope.Complete();
                    return response;
                }
                catch (Exception e)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = e.Message;
                    return response;
                }
            }

        }
        /// <summary>
        /// Inserts the fixed asset.
        /// </summary>
        /// <param name="fixedAssetEntity">The fixed asset entity.</param>
        /// <returns></returns>
        public FixedAssetResponse InsertFixedAsset(FixedAssetEntity fixedAssetEntity)
        {
            var response = new FixedAssetResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (!fixedAssetEntity.Validate())
                    {
                        foreach (string error in fixedAssetEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    fixedAssetEntity.FixedAssetId = Guid.NewGuid().ToString();
                    fixedAssetEntity.FixedAssetCode = fixedAssetEntity.FixedAssetCode.Trim();
                    var fixedAssetCheck = FixedAssetDao.GetFixedAssetByCode(fixedAssetEntity.FixedAssetCode);
                    if (fixedAssetCheck != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã tài sản cố định đã tồn tại";
                        scope.Dispose();
                        return response;
                    }
                    response.Message = FixedAssetDao.InsertFixedAsset(fixedAssetEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    foreach (var fixedAssetDetailAccessory in fixedAssetEntity.FixedAssetDetailAccessories)
                    {
                        fixedAssetDetailAccessory.FixedAssetId = fixedAssetEntity.FixedAssetId;
                        FixedAssetDetailAccessoryDao.InsertFixedAssetDetailAccessory(fixedAssetDetailAccessory);
                    }
                    response.FixedAssetId = fixedAssetEntity.FixedAssetId;
                    scope.Complete();
                    return response;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    scope.Dispose();
                    return response;
                }
            }
        }

        public FixedAssetResponse InsertFixedAssetConvert(FixedAssetEntity fixedAssetEntity)
        {
            var response = new FixedAssetResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (!fixedAssetEntity.Validate())
                    {
                        foreach (string error in fixedAssetEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    fixedAssetEntity.FixedAssetCode = fixedAssetEntity.FixedAssetCode.Trim();
                    var fixedAssetCheck = FixedAssetDao.GetFixedAssetByCode(fixedAssetEntity.FixedAssetCode);
                    if (fixedAssetCheck != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã tài sản cố định đã tồn tại";
                        scope.Dispose();
                        return response;
                    }
                    response.Message = FixedAssetDao.InsertFixedAsset(fixedAssetEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    foreach (var fixedAssetDetailAccessory in fixedAssetEntity.FixedAssetDetailAccessories)
                    {
                        fixedAssetDetailAccessory.FixedAssetId = fixedAssetEntity.FixedAssetId;
                        FixedAssetDetailAccessoryDao.InsertFixedAssetDetailAccessory(fixedAssetDetailAccessory);
                    }
                    response.FixedAssetId = fixedAssetEntity.FixedAssetId;
                    scope.Complete();
                    return response;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    scope.Dispose();
                    return response;
                }
            }
        }

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAssetEntity">The fixed asset entity.</param>
        /// <returns></returns>
        public FixedAssetResponse UpdateFixedAsset(FixedAssetEntity fixedAssetEntity, DateTime systemDate)
        {
            var response = new FixedAssetResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (!fixedAssetEntity.Validate())
                    {
                        foreach (string error in fixedAssetEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    fixedAssetEntity.FixedAssetCode = fixedAssetEntity.FixedAssetCode.Trim();
                    var fixedAssetCheck = FixedAssetDao.GetFixedAssetByCode(fixedAssetEntity.FixedAssetCode);
                    if (fixedAssetCheck != null && fixedAssetCheck.FixedAssetId != fixedAssetEntity.FixedAssetId)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = "Mã tài sản cố định đã tồn tại";
                        scope.Dispose();
                        return response;
                    }

                    #region AnhNT: Xóa dư đầu kỳ nếu sửa ngày < dbstartdate
                    //=========================================================================
                    var fixedAssetEntity2 = FixedAssetDao.GetFixedAssetById(fixedAssetEntity.FixedAssetId);

                    if (fixedAssetEntity2 != null && !string.IsNullOrEmpty(fixedAssetEntity2.RefId) && fixedAssetEntity2.PurchasedDate < systemDate)
                    {
                        AutoMapper(DeleteGeneralLedger(fixedAssetEntity2.RefId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        AutoMapper(DeleteOriginalLedger(fixedAssetEntity2.RefId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        AutoMapper(DeleteOpeningFixedAssetEntry(fixedAssetEntity2.FixedAssetId), response);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;

                        if (fixedAssetEntity2.RefType == 603)
                        {
                            AutoMapper(DeleteFixAssetLedger603(fixedAssetEntity2.FixedAssetId, fixedAssetEntity2.RefType),
                                response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                            //Xóa ts dư đầu kỳ
                            AutoMapper(DeleteGeneralLedger(fixedAssetEntity.FixedAssetId), response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                        }
                        else
                        {
                            AutoMapper(DeleteFixAssetLedger(fixedAssetEntity2.RefId, fixedAssetEntity2.RefType),
                                response);
                            if (!string.IsNullOrEmpty(response.Message))
                                goto Error;
                        }

                        response.Message = OpeningFixedAssetEntryDao.DeleteOpeningFixedAssetEntry(fixedAssetEntity2.RefId);
                        if (!string.IsNullOrEmpty(response.Message))
                            goto Error;
                    }
                    //=========================================================================
                    #endregion

                    response.Message = FixedAssetDao.UpdateFixedAsset(fixedAssetEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    FixedAssetDetailAccessoryDao.DeleteFixedAssetDetailAccessoryByFixedAssetId(fixedAssetEntity.FixedAssetId);
                    foreach (var fixedAssetDetailAccessory in fixedAssetEntity.FixedAssetDetailAccessories)
                    {
                        fixedAssetDetailAccessory.FixedAssetId = fixedAssetEntity.FixedAssetId;
                        FixedAssetDetailAccessoryDao.InsertFixedAssetDetailAccessory(fixedAssetDetailAccessory);
                    }
                #region Error
                Error:
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    #endregion
                    response.FixedAssetId = fixedAssetEntity.FixedAssetId;
                    scope.Complete();
                    return response;
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    scope.Dispose();
                    return response;
                }
            }
        }
    }
}