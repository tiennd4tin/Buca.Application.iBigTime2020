/***********************************************************************
 * <copyright file="AccountingObjectFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;
using System.Data.SqlClient;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary
{

    /// <summary>
    /// AccountingObjectFacade class
    /// </summary>
    public class AccountingObjectFacade
    {

        /// <summary>
        /// The accounting object DAO
        /// </summary>
        private static readonly IAccountingObjectDao AccountingObjectDao = DataAccess.DataAccess.AccountingObjectDao;
        private static readonly IAccountingObjectCategoryDao AccountingObjectCategoryDao = DataAccess.DataAccess.AccountingObjectCategoryDao;
        private static readonly IBankDao BankDAO = DataAccess.DataAccess.BankDao;

        /// <summary>
        /// Gets the accounting objects.
        /// </summary>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjects()
        {

            return AccountingObjectDao.GetAccountingObjects();
        }

        /// <summary>
        /// Sets the accounting objects.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountObjectByIsActive(bool isActive)
        {
            return AccountingObjectDao.GetAccountingObjectByActives(isActive);
        }

        public List<AccountingObjectEntity> GetAccountObjectByDepartmentId(string departmentid)
        {
            return AccountingObjectDao.GetAccountObjectByDepartmentId(departmentid);
        }

        /// <summary>
        /// Gets the accounting objects by accounting object category identifier.
        /// </summary>
        /// <param name="accountingObjectCategoryId">The accounting object category identifier.</param>
        /// <returns></returns>
        public List<AccountingObjectEntity> GetAccountingObjectsByAccountingObjectCategoryId(string accountingObjectCategoryId)
        {
            return AccountingObjectDao.GetAccountingObjectsByAccountingObjectCategoryId(accountingObjectCategoryId);
        }

        public List<AccountingObjectEntity> GetAccountingObjectsByIsEmployee(bool isEmployee)
        {
            return AccountingObjectDao.GetAccountingObjectsByIsEmployee(isEmployee);
        }

        public List<AccountingObjectEntity> GetAccountingObjectsByIsCustomerVendor(bool isCustomerVendor)
        {
            return AccountingObjectDao.GetAccountingObjectsByIsCustomerVendor(isCustomerVendor);
        }

        /// <summary>
        /// Gets the accounting object by identifier.
        /// </summary>
        /// <param name="accountAccountingObjectId">The account accounting object identifier.</param>
        /// <returns></returns>
        public AccountingObjectEntity GetAccountingObjectById(string accountAccountingObjectId)
        {
            return AccountingObjectDao.GetAccountingObjectById(accountAccountingObjectId);
        }

        /// <summary>
        /// Inserts the account object.
        /// </summary>
        /// <param name="accountingObjectEntity">The accounting object entity.</param>
        /// <returns></returns>
        public AccountingObjectResponse InsertAccountObject(AccountingObjectEntity accountingObjectEntity)
        {
            var response = new AccountingObjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accoutingObjects = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObject = accoutingObjects.Where(x => x.IsEmployee = false).ToList();
                if (accoutingObject.Count > 0 && accountingObjectEntity.IsEmployee == false)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã đối tượng " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                var accoutingObjectEmployees = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObjectEmployee = accoutingObjectEmployees.Where(x => x.IsEmployee).ToList();
                if (accoutingObjectEmployee.Count > 0 && accountingObjectEntity.IsEmployee == true)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nhân viên " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!accountingObjectEntity.Validate())
                {
                    foreach (string error in accountingObjectEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }

                accountingObjectEntity.AccountingObjectId = Guid.NewGuid().ToString();
                var accObject =
                    AccountingObjectCategoryDao.GetAccountingObjectCategory(accountingObjectEntity.AccountingObjectCategoryId);
                if (accObject != null)
                {
                    if (accObject.AccountingObjectCategoryCode == "NCC")
                        accountingObjectEntity.IsCustomerVendor = true;
                }
                //   var validAccountingObject = AccountingObjectDao.Get
                response.Message = AccountingObjectDao.InsertAccountingObject(accountingObjectEntity);
                if (accountingObjectEntity.AccountingObjectBanks.Count() > 0)
                {
                    accountingObjectEntity.AccountingObjectBanks.ForEach(item =>
                    {
                        var bank = new BankEntity()
                        {
                            BankId = Guid.NewGuid().ToString(),
                            BankAccount = item.BankAccount,
                            BankName = item.BankName,
                            IsActive = true,
                            ProjectId = accountingObjectEntity.AccountingObjectId,
                            IsOpenInBank = true,
                            SortBank = item.SortBank,
                        };
                        BankDAO.InsertBank(bank);
                    });
                }
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountingObjectId = accountingObjectEntity.AccountingObjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountingObjectResponse InsertAccountObjectConvert(AccountingObjectEntity accountingObjectEntity)
        {
            var response = new AccountingObjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accoutingObjects = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObject = accoutingObjects.Where(x => x.IsEmployee = false).ToList();
                if (accoutingObject.Count > 0 && accountingObjectEntity.IsEmployee == false)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã đối tượng " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                var accoutingObjectEmployees = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObjectEmployee = accoutingObjectEmployees.Where(x => x.IsEmployee).ToList();
                if (accoutingObjectEmployee.Count > 0 && accountingObjectEntity.IsEmployee == true)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nhân viên " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!accountingObjectEntity.Validate())
                {
                    foreach (string error in accountingObjectEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var accObject =
                    AccountingObjectCategoryDao.GetAccountingObjectCategory(accountingObjectEntity.AccountingObjectCategoryId);
                if (accObject != null)
                {
                    if (accObject.AccountingObjectCategoryCode == "NCC")
                        accountingObjectEntity.IsCustomerVendor = true;
                }
                //   var validAccountingObject = AccountingObjectDao.Get
                response.Message = AccountingObjectDao.InsertAccountingObject(accountingObjectEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountingObjectId = accountingObjectEntity.AccountingObjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
        /// <summary>
        /// Updates the accounting object.
        /// </summary>
        /// <param name="accountingObjectEntity">The accounting object entity.</param>
        /// <returns></returns>
        public AccountingObjectResponse UpdateAccountingObject(AccountingObjectEntity accountingObjectEntity)
        {
            var response = new AccountingObjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accoutingObjects = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObject = accoutingObjects.Where(x => x.IsEmployee == false && x.AccountingObjectId != accountingObjectEntity.AccountingObjectId).ToList();
                if (accoutingObject.Count > 0 && accountingObjectEntity.IsEmployee == false)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã đối tượng " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                var accoutingObjectEmployees = AccountingObjectDao.GetAccountingObjectByCode(accountingObjectEntity.AccountingObjectCode.Trim());
                var accoutingObjectEmployee = accoutingObjectEmployees.Where(x => x.IsEmployee && x.AccountingObjectId != accountingObjectEntity.AccountingObjectId).ToList();
                if (accoutingObjectEmployee.Count > 0 && accountingObjectEntity.IsEmployee == true)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = @"Mã nhân viên " + accountingObjectEntity.AccountingObjectCode.Trim() + @" đã tồn tại!";
                    return response;
                }
                if (!accountingObjectEntity.Validate())
                {
                    foreach (string error in accountingObjectEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                var accObject =
                    AccountingObjectCategoryDao.GetAccountingObjectCategory(accountingObjectEntity.AccountingObjectCategoryId);
                if (accObject != null)
                    if (accObject.AccountingObjectCategoryCode == "NCC")
                        accountingObjectEntity.IsCustomerVendor = true;

                response.Message = AccountingObjectDao.UpdateAccountingObject(accountingObjectEntity);
                // lay ra danh sach bank cu
                var oldBanks = BankDAO.GetProjectBank(accountingObjectEntity.AccountingObjectId);
                var newbanks = accountingObjectEntity.AccountingObjectBanks;
                oldBanks = oldBanks.Where(o => accountingObjectEntity.AccountingObjectBanks.Count() == 0 || !accountingObjectEntity.AccountingObjectBanks.Any(pb => o.BankId == pb.BankId)).ToList();
                if (oldBanks.Count() > 0 && newbanks.Count != 0)
                {
                    oldBanks.ForEach(bank =>
                    {
                        response.Message = BankDAO.DeleteBank(bank);
                        if (!string.IsNullOrEmpty(response.Message))
                        {
                            if (response.Message.Contains("FK"))
                            {
                                response.Message = @"Bạn không thể xóa tài khoản " + bank.BankAccount + " vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                            }
                            response.Acknowledge = AcknowledgeType.Failure;
                            throw new Exception(response.Message);
                        }
                    });
                };
                #region insert bank
                if (accountingObjectEntity.AccountingObjectBanks.Count() > 0)
                {
                    accountingObjectEntity.AccountingObjectBanks.ForEach(item =>
                    {
                        if (item.BankId == null || item.BankId == Guid.Empty.ToString())
                        {
                            var bank = new BankEntity()
                            {
                                BankId = Guid.NewGuid().ToString(),
                                BankAccount = item.BankAccount,
                                BankName = item.BankName,
                                IsActive = true,
                                ProjectId = accountingObjectEntity.AccountingObjectId,
                                IsOpenInBank = true,
                                SortBank = item.SortBank,
                            };
                            BankDAO.InsertBank(bank);
                        }
                        else
                        {
                            var bank = new BankEntity()
                            {
                                BankId = item.BankId,
                                BankAccount = item.BankAccount,
                                BankName = item.BankName,
                                IsActive = true,
                                ProjectId = accountingObjectEntity.AccountingObjectId,
                                IsOpenInBank = true,
                                SortBank = item.SortBank,
                            };
                            BankDAO.UpdateBank(bank);
                        }

                    });
                }
                #endregion
                if (!string.IsNullOrEmpty(response.Message))
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountingObjectId = accountingObjectEntity.AccountingObjectId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>AccountingObject
        /// Deletes the account category.
        /// </summary>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <returns>
        /// AccountCategoryResponse.
        /// </returns>
        public AccountingObjectResponse DeleteAccountingObject(string accountingObjectId)
        {
            var response = new AccountingObjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                var accountingObjectEntity = AccountingObjectDao.GetAccountingObjectById(accountingObjectId);
                response.Message = AccountingObjectDao.DeleteAccountingObject(accountingObjectEntity);

                if (!string.IsNullOrEmpty(response.Message))
                {

                    if (
                        response.Message.Contains("FK_AccountingObject_AccountingObject") ||
                        response.Message.Contains("FK_BABankTransferDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_BADeposit_AccountingObject_AccountingObjectID") ||
                        response.Message.Contains("FK_BADepositDetail_AccountingObject") ||
                        response.Message.Contains("FK_BADepositDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_BADepositDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_BADepositDetailSale_AccountingObject") ||
                        response.Message.Contains("FK_BAWithDraw_AccountingObject") ||
                        response.Message.Contains("FK_BAWithDrawDetail_AccountingObject") ||
                        response.Message.Contains("FK_BAWithDrawDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_BAWithDrawDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_BAWithDrawDetailPurchase_AccountingObject") ||
                        response.Message.Contains("FK_BUCommitmentRequest_AccountingObject") ||
                        response.Message.Contains("FK_BUPlanWithdraw_AccountingObject") ||
                        response.Message.Contains("FK_BUTransfer_AccountingObject") ||
                        response.Message.Contains("FK_BUTransferDetail_AccountingObject") ||
                        response.Message.Contains("FK_BUTransferDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_BUTransferDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_BUTransferDetailPurchase_AccountingObject") ||
                        response.Message.Contains("FK_BUVoucherListDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_CAPayment_AccountingObject") ||
                        response.Message.Contains("FK_CAPaymentDetail_AccountingObject") ||
                        response.Message.Contains("FK_CAPaymentDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_CAPaymentDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_CAPaymentDetailPurchase_AccountingObject") ||
                        response.Message.Contains("FK_CAPaymentDetailSalary_AccountingObject") ||
                        response.Message.Contains("FK_CAReceipt_AccountingObject") ||
                        response.Message.Contains("FK_CAReceiptDetail_AccountingObject") ||
                        response.Message.Contains("FK_CAReceiptDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_CAReceiptDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_FAAdjustmentDetail_AccountingObject") ||
                        response.Message.Contains("FK_FADepreciationDetail_AccountingObject") ||
                        response.Message.Contains("FK_FAIncrementDecrementDetail_AccountingObject") ||
                        response.Message.Contains("FK_FixedAsset_AccountingObject_VendorID") ||
                        response.Message.Contains("FK_GeneralLedger_AccountingObject_AccountingObjectID") ||
                        response.Message.Contains("FK_GLVoucherDetail_AccountingObject") ||
                        response.Message.Contains("FK_GLVoucherDetail_AccountingObject1") ||
                        response.Message.Contains("FK_GLVoucherDetailParallel_AccountingObject") ||
                        response.Message.Contains("FK_INInwardOutward_AccountingObject_AccountingObjectID") ||
                        response.Message.Contains("FK_INInwardOutwardDetail_AccountingObject") ||
                        response.Message.Contains("FK_OpeningAccountEntry_AccountingObject") ||
                        response.Message.Contains("FK_PASalarySortOrder_AccountingObject") ||
                        response.Message.Contains("FK_PUInvoice_AccountingObject") ||
                        response.Message.Contains("FK_PUInvoiceDetailFixedAsset_AccountingObject") ||
                        response.Message.Contains("FK_SUIncrementDecrementDetail_AccountingObject"))

                    {
                        if (accountingObjectEntity.IsEmployee)
                            response.Message = @"Bạn không thể xóa cán bộ '" + accountingObjectEntity.AccountingObjectCode + "' vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                        else
                            response.Message = @"Bạn không thể xóa đối tượng '" + accountingObjectEntity.AccountingObjectCode + "' vì đã có phát sinh trong chứng từ hoặc danh mục liên quan!";
                    }
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                response.AccountingObjectId = accountingObjectEntity.AccountingObjectId;
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        public AccountingObjectResponse DeleteAccountingObjectConvert()
        {
            var response = new AccountingObjectResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                response.Message = AccountingObjectDao.DeleteAccountingObjectConvert();
                return response;
            }
            catch (SqlException sqlException)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = sqlException.Message;
                return response;
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
