
using System;
using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Cash;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Cash;
using Buca.Application.iBigTime2020.BusinessEntities.Business.InwardOutward;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Inventory;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using BuCA.Enum;
using Buca.Application.iBigTime2020.BusinessComponents.Facade.System;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Cash
{
    /// <summary>
    /// Class CAPaymentFacade.ae
    /// </summary>
    public class CAPaymentFacade : FacadeBase
    {
        private static readonly ICAPaymentDao CAPaymentDao = DataAccess.DataAccess.CAPaymentDao;
        private static readonly ICAPaymentDetailTaxDao CaPaymentDetailTaxDao = DataAccess.DataAccess.CaPaymentDetailTaxDao;
        private static readonly ICAPaymentDetailDao CAPaymentDetailDao = DataAccess.DataAccess.CAPaymentDetailDao;
        private static readonly ICAPaymentDetailPurchaseDao CAPaymentDetailPurchaseDao = DataAccess.DataAccess.CAPaymentDetailPurchaseDao;
        private static readonly ICAPaymentDetailFixedAssetDao CAPaymentDetailFixedAssetDao = DataAccess.DataAccess.CAPaymentDetailFixedAssetDao;
        private static readonly IGeneralLedgerDao GeneralLedgerDao = DataAccess.DataAccess.GeneralLedgerDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IInventoryLedgerDao InventoryLedgerDao = DataAccess.DataAccess.InventoryLedgerDao;
        private static readonly IOriginalGeneralLedgerDao OriginalGeneralLedgerDao = DataAccess.DataAccess.OriginalGeneralLedgerDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;
        private static readonly ICAPaymentDetailParallelDao CAPaymentDetailParallelDao = DataAccess.DataAccess.CAPaymentDetailParallelDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;

        /// <summary>
        /// Gets the ca payment.
        /// </summary>
        /// <returns>
        /// List&lt;CAPaymentEntity&gt;.
        /// </returns>
        public List<CAPaymentEntity> GetCAPayment()
        {
            return CAPaymentDao.GetCaPayment();
        }

        /// <summary>
        /// Gets the ca payments by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;CAPaymentEntity&gt;.</returns>
        public List<CAPaymentEntity> GetCAPaymentsByRefTypeId(int refTypeId)
        {
            return CAPaymentDao.GetCaPaymentsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Gets the ca payment entity.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refType">Type of the reference.</param>
        /// <returns>
        /// CAPaymentEntity.
        /// </returns>
        public CAPaymentEntity GetCaPaymentEntityByRefNo(string refNo, int refType)
        {
            return CAPaymentDao.GetCaPaymentEntitybyRefNo(refNo, refType);
        }

        /// <summary>
        /// Gets the ca payment by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAPaymentDetail">if set to <c>true</c> [is included ca payment detail].</param>
        /// <returns></returns>
        public CAPaymentEntity GetCAPaymentByRefId(string refId, bool isIncludedCAPaymentDetail)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (isIncludedCAPaymentDetail && payment != null)
            {
                switch (payment.RefType)
                {
                    case (int)RefType.CAPayment:
                    case (int)RefType.CAPaymentTreasury:
                        payment.CaPaymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(payment.RefId);
                        break;
                    case (int)RefType.INInward:
                        payment.CAPaymentDetailPurchases = CAPaymentDetailPurchaseDao.GetCAPaymentDetailPurchasesByRefId(payment.RefId);
                        break;
                    case (int)RefType.CAPaymentDetailFixedAsset:
                        payment.CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssetDao.GetCAPaymentDetailFixedAssetsByRefId(payment.RefId);
                        break;
                    case (int)RefType.BAWithDrawFixedAsset:
                        payment.CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssetDao.GetCAPaymentDetailFixedAssetsByRefId(payment.RefId);
                        break;
                    default:
                        payment.CaPaymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(payment.RefId);
                        break;
                }
            }
            return payment;
        }

        /// <summary>
        /// Gets the payment voucher detail purchase.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentEntity.</returns>
        public CAPaymentEntity GetPaymentVoucherDetailPurchase(string refId)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (payment == null)
                return null;
            payment.CAPaymentDetailPurchases = CAPaymentDetailPurchaseDao.GetCAPaymentDetailPurchasesByRefId(payment.RefId);
            return payment;
        }

        /// <summary>
        /// Gets the payment voucher detail fixed asset.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>CAPaymentEntity.</returns>
        public CAPaymentEntity GetPaymentVoucherDetailFixedAsset(string refId)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            payment.CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssetDao.GetCAPaymentDetailFixedAssetsByRefId(payment.RefId);
            return payment;
        }

        /// <summary>
        /// Gets the ca payment by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAPaymentDetail">if set to <c>true</c> [is included ca payment detail].</param>
        /// <param name="isIncludedCAPaymentDetailTax">if set to <c>true</c> [is included ca payment detail tax].</param>
        /// <returns></returns>
        public CAPaymentEntity GetCAPaymentByRefId(string refId, bool isIncludedCAPaymentDetail, bool isIncludedCAPaymentDetailTax)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (payment == null)
                return new CAPaymentEntity();

            if (isIncludedCAPaymentDetail)
            {
                payment.CaPaymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(payment.RefId);
            }
            if (isIncludedCAPaymentDetailTax)
            {
                payment.CaPaymentDetailTaxes = CaPaymentDetailTaxDao.GetCaPaymentDetailTaxByRefId(payment.RefId);
            }

            //default get detail parallel
            payment.CAPaymentDetailParallels = CAPaymentDetailParallelDao.GetCaPaymentDetailbyRefId(payment.RefId);

            return payment;
        }

        /// <summary>
        /// Gets the ca payment by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAPaymentDetail">The is included ca payment detail.</param>
        /// <param name="isIncludedCAPaymentDetailTax">The is included ca payment detail tax.</param>
        /// <param name="isIncludedDetailPurchase">The is included detail purchase.</param>
        /// <returns>Buca.Application.iBigTime2020.BusinessEntities.Business.Cash.CAPaymentEntity.</returns>
        public CAPaymentEntity GetCAPaymentByRefId(string refId, bool isIncludedCAPaymentDetail, bool isIncludedCAPaymentDetailTax,
            bool isIncludedDetailPurchase)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (payment == null)
                return new CAPaymentEntity();

            if (isIncludedCAPaymentDetail)
            {
                payment.CaPaymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(payment.RefId);
            }
            if (isIncludedCAPaymentDetailTax)
            {
                payment.CaPaymentDetailTaxes = CaPaymentDetailTaxDao.GetCaPaymentDetailTaxByRefId(payment.RefId);
            }
            if (isIncludedDetailPurchase)
            {
                payment.CAPaymentDetailPurchases = CAPaymentDetailPurchaseDao.GetCAPaymentDetailPurchasesByRefId(payment.RefId);
            }

            //default get detail parallel
            payment.CAPaymentDetailParallels = CAPaymentDetailParallelDao.GetCaPaymentDetailbyRefId(payment.RefId);

            return payment;
        }

        /// <summary>
        /// Gets the ca payment by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedCAPaymentDetail">if set to <c>true</c> [is included ca payment detail].</param>
        /// <param name="isIncludedCAPaymentDetailTax">if set to <c>true</c> [is included ca payment detail tax].</param>
        /// <param name="isIncludedDetailPurchase">if set to <c>true</c> [is included detail purchase].</param>
        /// <param name="isIncludedDetailFixedAsset">if set to <c>true</c> [is included detail fixed asset].</param>
        /// <returns>CAPaymentEntity.</returns>
        public CAPaymentEntity GetCAPaymentByRefId(string refId, bool isIncludedCAPaymentDetail, bool isIncludedCAPaymentDetailTax,
           bool isIncludedDetailPurchase, bool isIncludedDetailFixedAsset)
        {
            var payment = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);
            if (payment == null)
                return new CAPaymentEntity();

            if (isIncludedCAPaymentDetail)
            {
                payment.CaPaymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(payment.RefId);
            }
            if (isIncludedCAPaymentDetailTax)
            {
                payment.CaPaymentDetailTaxes = CaPaymentDetailTaxDao.GetCaPaymentDetailTaxByRefId(payment.RefId);
            }
            if (isIncludedDetailPurchase)
            {
                payment.CAPaymentDetailPurchases = CAPaymentDetailPurchaseDao.GetCAPaymentDetailPurchasesByRefId(payment.RefId);
            }
            if (isIncludedDetailFixedAsset)
            {
                payment.CAPaymentDetailFixedAssets = CAPaymentDetailFixedAssetDao.GetCAPaymentDetailFixedAssetsByRefId(payment.RefId);
            }

            //default get detail parallel
            payment.CAPaymentDetailParallels = CAPaymentDetailParallelDao.GetCaPaymentDetailbyRefId(payment.RefId);

            return payment;
        }

        /// <summary>
        /// Inserts the ca payment.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>CAPaymentResponse.</returns>
        public CAPaymentResponse InsertCAPayment(CAPaymentEntity caPaymentEntity, bool isConvertData, bool isAutoGenerateParallel = false)
        {
            var paymentResponse = new CAPaymentResponse { Acknowledge = AcknowledgeType.Success };

            if (caPaymentEntity != null && !caPaymentEntity.Validate())
            {
                foreach (var error in caPaymentEntity.ValidationErrors)
                    paymentResponse.Message += error + Environment.NewLine;
                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                return paymentResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (caPaymentEntity != null)
                {
                    var caPayment = CAPaymentDao.GetCaPayment(caPaymentEntity.RefNo.Trim(), caPaymentEntity.PostedDate);
                    if (caPayment != null && caPayment.PostedDate.Year == caPaymentEntity.PostedDate.Year)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        paymentResponse.Message = @"Số chứng từ '" + caPaymentEntity.RefNo + @"' đã tồn tại!";
                        return paymentResponse;
                    }

                    caPaymentEntity.RefId = Guid.NewGuid().ToString();
                    if (caPaymentEntity.RefType == (int)RefType.BUTransferFixedAsset || caPaymentEntity.RefType == (int)RefType.BAWithDrawFixedAsset || caPaymentEntity.RefType == (int)RefType.PUInvoiceFixedAsset || caPaymentEntity.RefType == (int)RefType.FAIncrementDecrement)
                    {
                        caPaymentEntity.RefType = (int)RefType.CAPaymentDetailFixedAsset;
                    }
                    //var checkPC = caPaymentEntity.RefNo.StartsWith("PC");//Phiếu chi
                    //var checkNK = caPaymentEntity.RefNo.StartsWith("NK");//Nhập khẩu
                    //var checkGT = caPaymentEntity.RefNo.StartsWith("GT");//Ghi tăng
                    //if (checkPC) caPaymentEntity.RefType = (int)BuCA.Enum.RefType.CAPayment;
                    //else if(checkNK) caPaymentEntity.RefType = (int)BuCA.Enum.RefType.INInward;
                    //else if(checkGT) caPaymentEntity.RefType = (int)BuCA.Enum.RefType.CAPaymentDetailFixedAsset;

                    paymentResponse.Message = CAPaymentDao.InsertCAPayment(caPaymentEntity);

                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        return paymentResponse;
                    }
                    if (caPaymentEntity.CaPaymentDetails != null && caPaymentEntity.CaPaymentDetails.Count > 0) //Anhnt thêm check tồn tại của detail
                    {
                        foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                        {
                            paymentDetail.RefId = caPaymentEntity.RefId;
                            paymentDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!paymentDetail.Validate())
                            {
                                foreach (var error in paymentDetail.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CAPaymentDetailDao.InsertCAPaymentDetail(paymentDetail);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #region Insert to AccountBalance

                            InsertAccountBalance(caPaymentEntity, paymentDetail);

                            #endregion

                            #region Insert into GeneralLedger

                            if (paymentDetail.DebitAccount != null && paymentDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = paymentDetail.AccountingObjectId,
                                    BankId = paymentDetail.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = paymentDetail.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    // CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId, //AnhNT disable theo yêu cầu của BA
                                    AccountNumber = paymentDetail.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId

                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = paymentDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = paymentDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = paymentDetail.AmountOC;
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                    BankId = paymentDetail.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    // ExchangeRate = paymentDetail.ExchangeRate,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = caPaymentEntity.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    //CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId, //AnhNT disable theo yêu cầu của BA
                                    AccountNumber = paymentDetail.DebitAccount ?? paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.DebitAccount == null ? 0 : paymentDetail.AmountOC,
                                    CreditAmount = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                    CreditAmountOC = paymentDetail.CreditAccount == null ? 0 : paymentDetail.AmountOC,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }

                            #endregion

                            #region Insert into Inventory Ledger

                            if (caPaymentEntity.InwardRefNo != null && caPaymentEntity.RefType == 201)
                            {
                                var inventoryLedgerEntity = new InventoryLedgerEntity
                                {

                                    InventoryLedgerId = Guid.NewGuid().ToString(),
                                    RefId = caPaymentEntity.RefId,
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    RefDate = caPaymentEntity.RefDate,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    //StockId = paymentDetail.StockId,
                                    //InventoryItemId = paymentDetail.InventoryItemId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    // Unit = paymentDetail.Unit,
                                    //UnitPrice = paymentDetail.UnitPrice,
                                    //InwardQuantity = caPaymentEntity.RefType == 201 ? paymentDetail.Quantity : 0,
                                    // OutwardQuantity = caPaymentEntity.RefType == 202 ? paymentDetail.Quantity : 0,
                                    OutwardAmount = caPaymentEntity.RefType == 202 ? paymentDetail.Amount : 0,
                                    InwardAmount = caPaymentEntity.RefType == 201 ? paymentDetail.AmountOC : 0,
                                    InwardAmountOC = caPaymentEntity.RefType == 201 ? paymentDetail.AmountOC : 0,
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    //ExpiryDate = paymentDetail.ExpiryDate,
                                    // LotNo = paymentDetail.LotNo,
                                    RefOrder = caPaymentEntity.RefOrder,
                                    SortOrder = paymentDetail.SortOrder,
                                    AccountNumber = paymentDetail.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                    InwardAmountBalance = 0,
                                    InwardAmountBalanceAfter = 0,
                                    InwardQuantityBalance = 0,
                                    UnitPriceBalance = 0,
                                };
                                paymentResponse.Message =
                                    InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                            }

                            #endregion

                            #region Insert OriginalGeneralLedger

                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = caPaymentEntity.RefType,
                                RefId = caPaymentEntity.RefId,
                                RefDetailId = paymentDetail.RefDetailId,
                                OrgRefDate = paymentDetail.OrgRefDate,
                                OrgRefNo = paymentDetail.OrgRefNo,
                                RefDate = caPaymentEntity.RefDate,
                                RefNo = caPaymentEntity.RefNo,
                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                ActivityId = paymentDetail.ActivityId,
                                Amount = paymentDetail.Amount,
                                AmountOC = paymentDetail.AmountOC,
                                Approved = paymentDetail.Approved,
                                BankId = paymentDetail.BankId,
                                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                BudgetItemCode = paymentDetail.BudgetItemCode,
                                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                BudgetSourceId = paymentDetail.BudgetSourceId,
                                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = paymentDetail.CashWithDrawTypeId,
                                CreditAccount = paymentDetail.CreditAccount,
                                DebitAccount = paymentDetail.DebitAccount,
                                Description = paymentDetail.Description,
                                FundStructureId = paymentDetail.FundStructureId,
                                ProjectActivityId = paymentDetail.ProjectActivityId,
                                MethodDistributeId = paymentDetail.MethodDistributeId,
                                JournalMemo = caPaymentEntity.JournalMemo,
                                ProjectId = paymentDetail.ProjectId,
                                ToBankId = paymentDetail.BankId,
                                SortOrder = paymentDetail.SortOrder,
                                PostedDate = caPaymentEntity.PostedDate,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                ContractId = paymentDetail.ContractId,
                            };
                            paymentResponse.Message =
                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #endregion
                        }
                    }

                    if (caPaymentEntity.CaPaymentDetailTaxes != null && caPaymentEntity.CaPaymentDetailTaxes.Count > 0) //Anhnt thêm check tồn tại của detail
                        foreach (var paymentDetail in caPaymentEntity.CaPaymentDetailTaxes)
                        {
                            paymentDetail.RefId = caPaymentEntity.RefId;
                            paymentDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!paymentDetail.Validate())
                            {
                                foreach (var error in paymentDetail.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CaPaymentDetailTaxDao.InsertCAPaymentDetailTax(paymentDetail);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                        }

                    if (caPaymentEntity.CAPaymentDetailPurchases != null && caPaymentEntity.CAPaymentDetailPurchases.Count > 0)
                    {
                        foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailPurchases)
                        {
                            paymentDetail.RefId = caPaymentEntity.RefId;
                            paymentDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!paymentDetail.Validate())
                            {
                                foreach (var error in paymentDetail.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CAPaymentDetailPurchaseDao.InsertCAPaymentDetailPurchase(paymentDetail);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #region Insert into Inventory Ledger

                            if (caPaymentEntity.InwardRefNo != null && caPaymentEntity.RefType == 201)
                            {
                                var inventoryLedgerEntity = new InventoryLedgerEntity
                                {

                                    InventoryLedgerId = Guid.NewGuid().ToString(),
                                    RefId = caPaymentEntity.RefId,
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    RefDate = caPaymentEntity.RefDate,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    OutwardAmount = caPaymentEntity.RefType == 202 ? paymentDetail.Amount : 0,
                                    InwardAmount = caPaymentEntity.RefType == 201 ? paymentDetail.Amount : 0,
                                    InwardAmountOC = caPaymentEntity.RefType == 201 ? paymentDetail.AmountExchange : 0,
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefOrder = caPaymentEntity.RefOrder,
                                    SortOrder = paymentDetail.SortOrder,
                                    AccountNumber = paymentDetail.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                    InwardAmountBalance = 0,
                                    InwardAmountBalanceAfter = 0,
                                    InwardQuantityBalance = 0,
                                    UnitPriceBalance = 0,
                                    StockId = paymentDetail.StockId,
                                    InventoryItemId = paymentDetail.InventoryItemId,
                                    Unit = paymentDetail.Unit,
                                    UnitPrice = paymentDetail.UnitPrice,
                                    InwardQuantity = caPaymentEntity.RefType == 201 ? paymentDetail.Quantity : 0,
                                    OutwardQuantity = caPaymentEntity.RefType == 202 ? paymentDetail.Quantity : 0,
                                    ExpiryDate = paymentDetail.ExpiryDate,
                                    LotNo = paymentDetail.LotNo,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,

                                };

                                //add by thangnd
                                if (caPaymentEntity.RefType == 201)
                                {
                                    inventoryLedgerEntity.InwardAmount = paymentDetail.AmountExchange;
                                    inventoryLedgerEntity.InwardAmountOC = paymentDetail.Amount;
                                    inventoryLedgerEntity.OutwardAmount = 0;
                                    inventoryLedgerEntity.InwardQuantity = paymentDetail.Quantity;
                                    inventoryLedgerEntity.OutwardQuantity = 0;
                                }
                                paymentResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                            }

                            #endregion

                            #region Insert into GeneralLedger

                            if (paymentDetail.DebitAccount != null && paymentDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = paymentDetail.AccountingObjectId,
                                    BankId = paymentDetail.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = paymentDetail.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,
                                    AccountNumber = paymentDetail.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId

                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = paymentDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = paymentDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = paymentDetail.Amount;
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                    BankId = caPaymentEntity.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = caPaymentEntity.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,
                                    AccountNumber = paymentDetail.DebitAccount ?? paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                    CreditAmount = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                    CreditAmountOC = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = caPaymentEntity.RefType,
                                RefId = caPaymentEntity.RefId,
                                RefDetailId = paymentDetail.RefDetailId,
                                OrgRefDate = paymentDetail.OrgRefDate,
                                OrgRefNo = paymentDetail.OrgRefNo,
                                RefDate = caPaymentEntity.RefDate,
                                RefNo = caPaymentEntity.RefNo,
                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                ActivityId = paymentDetail.ActivityId,
                                Amount = paymentDetail.Amount,
                                AmountOC = paymentDetail.AmountExchange,
                                Approved = paymentDetail.Approved,
                                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                BudgetItemCode = paymentDetail.BudgetItemCode,
                                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                BudgetSourceId = paymentDetail.BudgetSourceId,
                                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,
                                CreditAccount = paymentDetail.CreditAccount,
                                DebitAccount = paymentDetail.DebitAccount,
                                Description = paymentDetail.Description,
                                FundStructureId = paymentDetail.FundStructureId,
                                ProjectActivityId = paymentDetail.ProjectActivityId,
                                MethodDistributeId = paymentDetail.MethodDistributeId,
                                JournalMemo = caPaymentEntity.JournalMemo,
                                ProjectId = paymentDetail.ProjectId,
                                SortOrder = paymentDetail.SortOrder,
                                PostedDate = caPaymentEntity.PostedDate,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                BankId = caPaymentEntity.BankId,
                                ContractId = paymentDetail.ContractId,
                            };
                            paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #endregion
                        }
                    }

                    if (caPaymentEntity.CAPaymentDetailFixedAssets != null && caPaymentEntity.CAPaymentDetailFixedAssets.Count > 0)
                    {
                        foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailFixedAssets)
                        {
                            paymentDetail.RefId = caPaymentEntity.RefId;
                            paymentDetail.RefDetailId = Guid.NewGuid().ToString();
                            if (!paymentDetail.Validate())
                            {
                                foreach (var error in paymentDetail.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CAPaymentDetailFixedAssetDao.InsertCAPaymentDetailFixedAsset(paymentDetail);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #region Insert FixedAssetLedger
                            if (paymentDetail.FixedAssetId != null)
                            {
                                //get fixedAssetInfo

                                //foreach (var cAPaymentDetailFixedAssetDetail in caPaymentEntity.CAPaymentDetailFixedAssets)
                                {
                                    if (paymentDetail.DebitAccount.StartsWith("21"))
                                    {
                                        var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(paymentDetail.FixedAssetId);

                                        var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                        {
                                            FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                            RefId = caPaymentEntity.RefId,
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            RefDate = caPaymentEntity.RefDate,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            FixedAssetId = paymentDetail.FixedAssetId,
                                            DepartmentId = fixedAssetEntity.DepartmentId,
                                            LifeTime = fixedAssetEntity.LifeTime,
                                            AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                            AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                            OrgPriceAccount = null,
                                            OrgPriceDebitAmount = paymentDetail.Amount,
                                            OrgPriceCreditAmount = 0,
                                            DepreciationAccount = null,
                                            DepreciationDebitAmount = 0,
                                            DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                            CapitalAccount = paymentDetail.DebitAccount,
                                            CapitalDebitAmount = paymentDetail.Amount,
                                            CapitalCreditAmount = 0,
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            Description = paymentDetail.Description,
                                            RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                            EndYear = fixedAssetEntity.EndYear,
                                            DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                            DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                            EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                            PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                            Quantity = fixedAssetEntity.Quantity,

                                        };
                                        paymentResponse.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region Insert into GeneralLedger

                            if (paymentDetail.DebitAccount != null && paymentDetail.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = paymentDetail.AccountingObjectId,
                                    BankId = paymentDetail.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = paymentDetail.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,
                                    AccountNumber = paymentDetail.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = paymentDetail.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetail.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = paymentDetail.Amount;
                                generalLedgerEntity.CreditAmountOC = paymentDetail.Amount;
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                    BankId = paymentDetail.BankId,
                                    BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                    ProjectId = paymentDetail.ProjectId,
                                    BudgetSourceId = paymentDetail.BudgetSourceId,
                                    Description = paymentDetail.Description,
                                    RefDetailId = paymentDetail.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = paymentDetail.ActivityId,
                                    BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                    RefId = caPaymentEntity.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetail.MethodDistributeId,
                                    OrgRefNo = paymentDetail.OrgRefNo,
                                    OrgRefDate = paymentDetail.OrgRefDate,
                                    BudgetItemCode = paymentDetail.BudgetItemCode,
                                    ListItemId = paymentDetail.ListItemId,
                                    BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,
                                    AccountNumber = paymentDetail.DebitAccount ?? paymentDetail.CreditAccount,
                                    DebitAmount = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                    DebitAmountOC = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                    CreditAmount = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                    CreditAmountOC = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                    FundStructureId = paymentDetail.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetail.SortOrder,
                                    BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                    ContractId = paymentDetail.ContractId,
                                    CapitalPlanId = paymentDetail.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }

                            #endregion

                            #region Original Ledger
                            AutoMapper(InsertOriginalLedger(paymentDetail, caPaymentEntity), paymentResponse);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                goto Error;
                            #endregion
                        }
                    }

                    #region Sinh dinh khoan dong thoi
                    if (caPaymentEntity.RefType == 108)
                    {
                        if (!isAutoGenerateParallel)
                        {
                            #region CAPaymentDetailParallel

                            if (caPaymentEntity.CAPaymentDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var paymentDetailParallel in caPaymentEntity.CAPaymentDetailParallels)
                                {
                                    #region Insert CA Payment Detail Parallel

                                    paymentDetailParallel.RefId = caPaymentEntity.RefId;
                                    paymentDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                    if (!paymentDetailParallel.Validate())
                                    {
                                        foreach (var error in paymentDetailParallel.ValidationErrors)
                                            paymentResponse.Message += error + Environment.NewLine;
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    paymentResponse.Message = CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(paymentDetailParallel);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount ?? paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            CreditAmount = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.Amount,
                                            CreditAmountOC = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = caPaymentEntity.RefType,
                                        RefId = caPaymentEntity.RefId,
                                        RefDetailId = paymentDetailParallel.RefDetailId,
                                        OrgRefDate = paymentDetailParallel.OrgRefDate,
                                        OrgRefNo = paymentDetailParallel.OrgRefNo,
                                        RefDate = caPaymentEntity.RefDate,
                                        RefNo = caPaymentEntity.RefNo,
                                        AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                        ActivityId = paymentDetailParallel.ActivityId,
                                        Amount = paymentDetailParallel.Amount,
                                        AmountOC = paymentDetailParallel.AmountOC,
                                        //Approved = paymentDetail.Approved,
                                        BankId = paymentDetailParallel.BankId,
                                        BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = paymentDetailParallel.CreditAccount,
                                        DebitAccount = paymentDetailParallel.DebitAccount,
                                        Description = paymentDetailParallel.Description,
                                        FundStructureId = paymentDetailParallel.FundStructureId,
                                        //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                        MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                        JournalMemo = caPaymentEntity.JournalMemo,
                                        ProjectId = paymentDetailParallel.ProjectId,
                                        ToBankId = paymentDetailParallel.BankId,
                                        ExchangeRate = caPaymentEntity.ExchangeRate,
                                        CurrencyCode = caPaymentEntity.CurrencyCode,
                                        PostedDate = caPaymentEntity.PostedDate,
                                        BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                        ContractId = paymentDetailParallel.ContractId,
                                    };
                                    paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //Phiếu chi
                            if (caPaymentEntity.CaPaymentDetails != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithDrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua vật tư hàng hóa
                            if (caPaymentEntity.CAPaymentDetailPurchases != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountExchange,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua tscd

                            if (caPaymentEntity.CAPaymentDetailFixedAssets != null)
                            {
                                //List<CAPaymentDetailParallelEntity> list = new List<CAPaymentDetailParallelEntity>();
                                //foreach (var item in caPaymentEntity.CAPaymentDetailParallels)
                                //{
                                //    list.Add(item);
                                //    paymentResponse.Message =
                                //                CAPaymentDetailParallelDao.DeleteCAPaymentDetailParallelId(
                                //                    item.RefId);
                                //}
                                var paymentDetail = caPaymentEntity.CAPaymentDetailFixedAssets[0];

                                if (paymentDetail != null)
                                {

                                    foreach (var autoBusinessParallelEntity in caPaymentEntity.CAPaymentDetailParallels)
                                    {
                                        #region CAReceiptDetailParallel

                                        var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                        {
                                            RefId = caPaymentEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = paymentDetail.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccount,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccount,
                                            Amount = paymentDetail.Amount,
                                            AmountOC = paymentDetail.AmountOC,
                                            FixedAssetId = paymentDetail.FixedAssetId,
                                            UnitPrice = paymentDetail.OrgPrice,
                                            Quantity = paymentDetail.Quantity,
                                            BudgetSourceId =
                                                    paymentDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                    paymentDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                    paymentDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                    paymentDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                    paymentDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                    paymentDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                    paymentDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                    paymentDetail.CashWithdrawTypeId,
                                            AccountingObjectId = paymentDetail.AccountingObjectId,
                                            ActivityId = paymentDetail.ActivityId,
                                            ProjectId = paymentDetail.ProjectId,
                                            ListItemId = paymentDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = paymentDetail.SortOrder,
                                            OrgRefNo = paymentDetail.OrgRefNo,
                                            OrgRefDate = paymentDetail.OrgRefDate,
                                            FundStructureId = paymentDetail.FundStructureId,
                                            //BankId = paymentDetail.BankId,
                                            BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                            ContractId = paymentDetail.ContractId,
                                            CapitalPlanId = paymentDetail.CapitalPlanId,
                                            AutoBusinessId = paymentDetail.AutoBusinessId
                                            //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                            //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                        };
                                        if (!paymentDetailParallel.Validate())
                                        {
                                            foreach (var error in paymentDetailParallel.ValidationErrors)
                                                paymentResponse.Message += error + Environment.NewLine;
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity
                                        if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = caPaymentEntity.RefType,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                Description = paymentDetailParallel.Description,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                RefId = caPaymentEntity.RefId,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                ListItemId = paymentDetailParallel.ListItemId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                paymentDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                DebitAmount = paymentDetailParallel.Amount,
                                                DebitAmountOC = paymentDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                RefDate = caPaymentEntity.RefDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                                CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                            };
                                            paymentResponse.Message =
                                                GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                            paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                        }
                                        else
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = caPaymentEntity.RefType,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                Description = paymentDetailParallel.Description,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                RefId = caPaymentEntity.RefId,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                ListItemId = paymentDetailParallel.ListItemId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                paymentDetailParallel.DebitAccount ??
                                                paymentDetailParallel.CreditAccount,
                                                DebitAmount =
                                                paymentDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.Amount,
                                                DebitAmountOC =
                                                paymentDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.AmountOC,
                                                CreditAmount =
                                                paymentDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.Amount,
                                                CreditAmountOC =
                                                paymentDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.AmountOC,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                RefDate = caPaymentEntity.RefDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                                CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                            };
                                            paymentResponse.Message =
                                                GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                        }

                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = caPaymentEntity.RefType,
                                            RefId = caPaymentEntity.RefId,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            RefDate = caPaymentEntity.RefDate,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            Amount = paymentDetailParallel.Amount,
                                            AmountOC = paymentDetailParallel.AmountOC,
                                            //Approved = paymentDetail.Approved,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = paymentDetailParallel.CreditAccount,
                                            DebitAccount = paymentDetailParallel.DebitAccount,
                                            Description = paymentDetailParallel.Description,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            ToBankId = paymentDetailParallel.BankId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                        };
                                        paymentResponse.Message =
                                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        #endregion


                                    }
                                }
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet

                            }
                        }
                    }
                    else
                    {
                        if (!isAutoGenerateParallel)
                        {
                            #region CAPaymentDetailParallel

                            if (caPaymentEntity.CAPaymentDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var paymentDetailParallel in caPaymentEntity.CAPaymentDetailParallels)
                                {
                                    #region Insert CA Payment Detail Parallel

                                    paymentDetailParallel.RefId = caPaymentEntity.RefId;
                                    paymentDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                    if (!paymentDetailParallel.Validate())
                                    {
                                        foreach (var error in paymentDetailParallel.ValidationErrors)
                                            paymentResponse.Message += error + Environment.NewLine;
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    paymentResponse.Message = CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(paymentDetailParallel);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount ?? paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            CreditAmount = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.Amount,
                                            CreditAmountOC = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = caPaymentEntity.RefType,
                                        RefId = caPaymentEntity.RefId,
                                        RefDetailId = paymentDetailParallel.RefDetailId,
                                        OrgRefDate = paymentDetailParallel.OrgRefDate,
                                        OrgRefNo = paymentDetailParallel.OrgRefNo,
                                        RefDate = caPaymentEntity.RefDate,
                                        RefNo = caPaymentEntity.RefNo,
                                        AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                        ActivityId = paymentDetailParallel.ActivityId,
                                        Amount = paymentDetailParallel.Amount,
                                        AmountOC = paymentDetailParallel.AmountOC,
                                        //Approved = paymentDetail.Approved,
                                        BankId = paymentDetailParallel.BankId,
                                        BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = paymentDetailParallel.CreditAccount,
                                        DebitAccount = paymentDetailParallel.DebitAccount,
                                        Description = paymentDetailParallel.Description,
                                        FundStructureId = paymentDetailParallel.FundStructureId,
                                        //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                        MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                        JournalMemo = caPaymentEntity.JournalMemo,
                                        ProjectId = paymentDetailParallel.ProjectId,
                                        ToBankId = paymentDetailParallel.BankId,
                                        ExchangeRate = caPaymentEntity.ExchangeRate,
                                        CurrencyCode = caPaymentEntity.CurrencyCode,
                                        PostedDate = caPaymentEntity.PostedDate,
                                        BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                        ContractId = paymentDetailParallel.ContractId,
                                    };
                                    paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //Phiếu chi
                            if (caPaymentEntity.CaPaymentDetails != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithDrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua vật tư hàng hóa
                            if (caPaymentEntity.CAPaymentDetailPurchases != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountExchange,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua tscd
                            if (caPaymentEntity.CAPaymentDetailFixedAssets != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailFixedAssets)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.Amount,
                                                FixedAssetId = paymentDetail.FixedAssetId,
                                                UnitPrice = paymentDetail.OrgPrice,
                                                Quantity = paymentDetail.Quantity,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }

                #endregion

                Error:
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    paymentResponse.RefId = caPaymentEntity.RefId;
                    scope.Complete();
                }

                return paymentResponse;
            }
        }

        /// <summary>
        /// Updates the ca payment.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="isConvertData">if set to <c>true</c> [is convert data].</param>
        /// <param name="isAutoGenerateParallel">if set to <c>true</c> [is automatic generate parallel].</param>
        /// <returns>CAPaymentResponse.</returns>
        public CAPaymentResponse UpdateCAPayment(CAPaymentEntity caPaymentEntity, bool isConvertData, bool isAutoGenerateParallel = false)
        {
            var paymentResponse = new CAPaymentResponse { Acknowledge = AcknowledgeType.Success };

            if (caPaymentEntity != null && !caPaymentEntity.Validate())
            {
                foreach (var error in caPaymentEntity.ValidationErrors)
                    paymentResponse.Message += error + Environment.NewLine;
                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                return paymentResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (caPaymentEntity != null)
                {
                    var caPayment = CAPaymentDao.GetCaPayment(caPaymentEntity.RefNo.Trim(), caPaymentEntity.PostedDate);
                    if (caPayment != null && caPayment.PostedDate.Year == caPaymentEntity.PostedDate.Year)
                    {
                        if (caPayment.RefId != caPaymentEntity.RefId)
                        {
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            paymentResponse.Message = @"Số chứng từ '" + caPaymentEntity.RefNo + @"' đã tồn tại!";
                            return paymentResponse;
                        }
                    }

                    #region Update account balance
                    //Trừ đi số tiền của chứng từ cũ trước khi cộng thêm số tiền mới

                    UpdateAccountBalance(caPaymentEntity);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    #endregion

                    #region Delete relative tables

                    // Xóa bảng CAPaymentDetail
                    paymentResponse.Message = CAPaymentDetailDao.DeleteCAPaymentDetailId(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng CaPaymentDetailTax
                    paymentResponse.Message = CaPaymentDetailTaxDao.DeleteCAPaymentDetailTax(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng CAPaymentDetailPurchase
                    paymentResponse.Message = CAPaymentDetailPurchaseDao.DeleteCAPaymentDetailPurchase(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng CAPaymentDetailFixedAsset
                    paymentResponse.Message = CAPaymentDetailFixedAssetDao.DeleteCAPaymentDetailFixedAsset(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng GeneralLedger
                    paymentResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng InventoryLedger
                    paymentResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng OriginalGeneralLedger
                    paymentResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    // Xóa bảng FixAssetLedger
                    paymentResponse.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(caPaymentEntity.RefId, caPaymentEntity.RefType);
                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        return paymentResponse;
                    }

                    #endregion

                    #region Delete Parallel

                    // Xóa bảng CAPaymentDetailParallel
                    paymentResponse.Message = CAPaymentDetailParallelDao.DeleteCAPaymentDetailParallelId(caPaymentEntity.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    #endregion

                    if (caPaymentEntity.RefType == (int)RefType.BUTransferFixedAsset || caPaymentEntity.RefType == (int)RefType.BAWithDrawFixedAsset || caPaymentEntity.RefType == (int)RefType.PUInvoiceFixedAsset || caPaymentEntity.RefType == (int)RefType.FAIncrementDecrement)
                    {
                        caPaymentEntity.RefType = (int)RefType.CAPaymentDetailFixedAsset;
                    }
                    paymentResponse.Message = CAPaymentDao.UpdateCAPayment(caPaymentEntity);

                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }

                    foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                    {
                        paymentDetail.RefId = caPaymentEntity.RefId;
                        paymentDetail.RefDetailId = Guid.NewGuid().ToString();

                        if (!paymentDetail.Validate())
                        {
                            foreach (string error in paymentDetail.ValidationErrors)
                                paymentResponse.Message += error + Environment.NewLine;
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            return paymentResponse;
                        }
                        paymentResponse.Message = CAPaymentDetailDao.InsertCAPaymentDetail(paymentDetail);
                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                        {
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            return paymentResponse;
                        }

                        #region Insert into AccountBalance

                        // Cộng thêm số tiền mới sau khi sửa chứng từ
                        InsertAccountBalance(caPaymentEntity, paymentDetail);
                        if (paymentResponse.Message != null)
                        {
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return paymentResponse;
                        }

                        #endregion

                        #region Insert OriginalGeneralLedger
                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                        {
                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                            RefType = caPaymentEntity.RefType,
                            RefId = caPaymentEntity.RefId,
                            RefDetailId = paymentDetail.RefDetailId,
                            OrgRefDate = paymentDetail.OrgRefDate,
                            OrgRefNo = paymentDetail.OrgRefNo,
                            RefDate = caPaymentEntity.RefDate,
                            RefNo = caPaymentEntity.RefNo,
                            AccountingObjectId = paymentDetail.AccountingObjectId,
                            ActivityId = paymentDetail.ActivityId,
                            Amount = paymentDetail.Amount,
                            AmountOC = paymentDetail.AmountOC,
                            Approved = paymentDetail.Approved,
                            BankId = paymentDetail.BankId,
                            BudgetChapterCode = paymentDetail.BudgetChapterCode,
                            BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                            BudgetItemCode = paymentDetail.BudgetItemCode,
                            BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                            BudgetSourceId = paymentDetail.BudgetSourceId,
                            BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                            BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                            CashWithDrawTypeId = paymentDetail.CashWithDrawTypeId,
                            CreditAccount = paymentDetail.CreditAccount,
                            DebitAccount = paymentDetail.DebitAccount,
                            Description = paymentDetail.Description,
                            FundStructureId = paymentDetail.FundStructureId,
                            ProjectActivityId = paymentDetail.ProjectActivityId,
                            MethodDistributeId = paymentDetail.MethodDistributeId,
                            JournalMemo = caPaymentEntity.JournalMemo,
                            ProjectId = paymentDetail.ProjectId,
                            ToBankId = paymentDetail.BankId,
                            SortOrder = paymentDetail.SortOrder,
                            PostedDate = caPaymentEntity.PostedDate,
                            CurrencyCode = caPaymentEntity.CurrencyCode,
                            ExchangeRate = caPaymentEntity.ExchangeRate,
                            BudgetExpenseId = paymentDetail.BudgetExpenseId,
                            ContractId = paymentDetail.ContractId,
                        };
                        paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                        {
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            return paymentResponse;
                        }

                        #endregion

                        #region Insert into GeneralLedger

                        if (paymentDetail.DebitAccount != null && paymentDetail.CreditAccount != null)
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = caPaymentEntity.RefType,
                                RefNo = caPaymentEntity.RefNo,
                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                BankId = paymentDetail.BankId,
                                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                ProjectId = paymentDetail.ProjectId,
                                BudgetSourceId = paymentDetail.BudgetSourceId,
                                Description = paymentDetail.Description,
                                RefDetailId = paymentDetail.RefDetailId,
                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                ActivityId = paymentDetail.ActivityId,
                                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                RefId = paymentDetail.RefId,
                                PostedDate = caPaymentEntity.PostedDate,
                                MethodDistributeId = paymentDetail.MethodDistributeId,
                                OrgRefNo = paymentDetail.OrgRefNo,
                                OrgRefDate = paymentDetail.OrgRefDate,
                                BudgetItemCode = paymentDetail.BudgetItemCode,
                                ListItemId = paymentDetail.ListItemId,
                                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                // CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,//AnhNT disable theo yêu cầu của BA
                                AccountNumber = paymentDetail.DebitAccount,
                                CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                DebitAmount = paymentDetail.Amount,
                                DebitAmountOC = paymentDetail.AmountOC,
                                CreditAmount = 0,
                                CreditAmountOC = 0,
                                FundStructureId = paymentDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = caPaymentEntity.JournalMemo,
                                RefDate = caPaymentEntity.RefDate,
                                SortOrder = paymentDetail.SortOrder,
                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                ContractId = paymentDetail.ContractId,
                                CapitalPlanId = paymentDetail.CapitalPlanId
                            };
                            paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            //insert lan 2
                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                            generalLedgerEntity.AccountNumber = paymentDetail.CreditAccount;
                            generalLedgerEntity.CorrespondingAccountNumber = paymentDetail.DebitAccount;
                            generalLedgerEntity.DebitAmount = 0;
                            generalLedgerEntity.DebitAmountOC = 0;
                            generalLedgerEntity.CreditAmount = paymentDetail.Amount;
                            generalLedgerEntity.CreditAmountOC = paymentDetail.AmountOC;
                            paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                        }
                        else //ghi don
                        {
                            var generalLedgerEntity = new GeneralLedgerEntity
                            {
                                RefType = caPaymentEntity.RefType,
                                RefNo = caPaymentEntity.RefNo,
                                AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                BankId = paymentDetail.BankId,
                                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                                ProjectId = paymentDetail.ProjectId,
                                BudgetSourceId = paymentDetail.BudgetSourceId,
                                Description = paymentDetail.Description,
                                RefDetailId = paymentDetail.RefDetailId,
                                // ExchangeRate = paymentDetail.ExchangeRate,
                                ActivityId = paymentDetail.ActivityId,
                                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                                RefId = caPaymentEntity.RefId,
                                PostedDate = caPaymentEntity.PostedDate,
                                MethodDistributeId = paymentDetail.MethodDistributeId,
                                OrgRefNo = paymentDetail.OrgRefNo,
                                OrgRefDate = paymentDetail.OrgRefDate,
                                BudgetItemCode = paymentDetail.BudgetItemCode,
                                ListItemId = paymentDetail.ListItemId,
                                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode,
                                //CashWithDrawTypeId = paymentDetail.CashWithdrawTypeId,//AnhNT disable theo yêu cầu của BA
                                AccountNumber = paymentDetail.DebitAccount ?? paymentDetail.CreditAccount,
                                DebitAmount = paymentDetail.DebitAccount == null ? 0 : paymentDetail.Amount,
                                DebitAmountOC = paymentDetail.DebitAccount == null ? 0 : paymentDetail.AmountOC,
                                CreditAmount = paymentDetail.CreditAccount == null ? 0 : paymentDetail.Amount,
                                CreditAmountOC = paymentDetail.CreditAccount == null ? 0 : paymentDetail.AmountOC,
                                FundStructureId = paymentDetail.FundStructureId,
                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                JournalMemo = caPaymentEntity.JournalMemo,
                                RefDate = caPaymentEntity.RefDate,
                                SortOrder = paymentDetail.SortOrder,
                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                ContractId = paymentDetail.ContractId,
                                CapitalPlanId = paymentDetail.CapitalPlanId
                            };
                            paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                        }
                        #endregion

                        #region Insert into Inventory Ledger

                        if (caPaymentEntity.InwardRefNo != null && caPaymentEntity.RefType == 201)
                        {

                            var inventoryLedgerEntity = new InventoryLedgerEntity
                            {

                                InventoryLedgerId = Guid.NewGuid().ToString(),
                                RefId = caPaymentEntity.RefId,
                                RefType = caPaymentEntity.RefType,
                                RefNo = caPaymentEntity.RefNo,
                                RefDate = caPaymentEntity.RefDate,
                                PostedDate = caPaymentEntity.PostedDate,
                                //StockId = paymentDetail.StockId,
                                //InventoryItemId = paymentDetail.InventoryItemId,
                                BudgetSourceId = paymentDetail.BudgetSourceId,
                                Description = paymentDetail.Description,
                                RefDetailId = paymentDetail.RefDetailId,
                                // Unit = paymentDetail.Unit,
                                //UnitPrice = paymentDetail.UnitPrice,
                                //InwardQuantity = caPaymentEntity.RefType == 201 ? paymentDetail.Quantity : 0,
                                // OutwardQuantity = caPaymentEntity.RefType == 202 ? paymentDetail.Quantity : 0,
                                // OutwardAmount = caPaymentEntity.RefType == 107 ? paymentDetail.Amount : 0,
                                InwardAmount = caPaymentEntity.RefType == 201 ? paymentDetail.Amount : 0,
                                InwardAmountOC = caPaymentEntity.RefType == 201 ? paymentDetail.AmountOC : 0,
                                JournalMemo = caPaymentEntity.JournalMemo,
                                //ExpiryDate = paymentDetail.ExpiryDate,
                                // LotNo = paymentDetail.LotNo,
                                RefOrder = caPaymentEntity.RefOrder,
                                SortOrder = paymentDetail.SortOrder,
                                AccountNumber = paymentDetail.DebitAccount,
                                CorrespondingAccountNumber = paymentDetail.CreditAccount,
                                InwardAmountBalance = 0,
                                InwardAmountBalanceAfter = 0,
                                InwardQuantityBalance = 0,
                                UnitPriceBalance = 0,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                            };
                            paymentResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                        }

                        #endregion
                    }

                    foreach (var paymentDetailTax in caPaymentEntity.CaPaymentDetailTaxes)
                    {
                        paymentDetailTax.RefId = caPaymentEntity.RefId;
                        paymentDetailTax.RefDetailId = Guid.NewGuid().ToString();

                        if (!paymentDetailTax.Validate())
                        {
                            foreach (string error in paymentDetailTax.ValidationErrors)
                                paymentResponse.Message += error + Environment.NewLine;
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            return paymentResponse;
                        }
                        paymentResponse.Message = CaPaymentDetailTaxDao.InsertCAPaymentDetailTax(paymentDetailTax);
                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                        {
                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                            return paymentResponse;
                        }

                    }

                    if (caPaymentEntity.CAPaymentDetailPurchases != null)
                    {
                        foreach (var paymentDetailPurchases in caPaymentEntity.CAPaymentDetailPurchases)
                        {
                            paymentDetailPurchases.RefId = caPaymentEntity.RefId;
                            paymentDetailPurchases.RefDetailId = Guid.NewGuid().ToString();

                            if (!paymentDetailPurchases.Validate())
                            {
                                foreach (string error in paymentDetailPurchases.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CAPaymentDetailPurchaseDao.InsertCAPaymentDetailPurchase(paymentDetailPurchases);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #region Insert into Inventory Ledger

                            if (caPaymentEntity.InwardRefNo != null && caPaymentEntity.RefType == 201)
                            {
                                //trường hợp giành riêng cho nhập mua tiền mặt
                                var inventoryLedgerEntity = new InventoryLedgerEntity
                                {

                                    InventoryLedgerId = Guid.NewGuid().ToString(),
                                    RefId = caPaymentEntity.RefId,
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    RefDate = caPaymentEntity.RefDate,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    BudgetSourceId = paymentDetailPurchases.BudgetSourceId,
                                    Description = paymentDetailPurchases.Description,
                                    RefDetailId = paymentDetailPurchases.RefDetailId,
                                    //OutwardAmount = caPaymentEntity.RefType == 107 ? paymentDetailPurchases.Amount : 0,
                                    InwardAmount = caPaymentEntity.RefType == 201 ? paymentDetailPurchases.AmountExchange : 0,
                                    InwardAmountOC = caPaymentEntity.RefType == 201 ? paymentDetailPurchases.Amount : 0,
                                    //OutwardAmount = 0, //add by thangnd
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefOrder = caPaymentEntity.RefOrder,
                                    SortOrder = paymentDetailPurchases.SortOrder,
                                    AccountNumber = paymentDetailPurchases.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetailPurchases.CreditAccount,
                                    InwardAmountBalance = 0,
                                    InwardAmountBalanceAfter = 0,
                                    InwardQuantityBalance = 0,
                                    UnitPriceBalance = 0,
                                    StockId = paymentDetailPurchases.StockId,
                                    InventoryItemId = paymentDetailPurchases.InventoryItemId,
                                    Unit = paymentDetailPurchases.Unit,
                                    UnitPrice = paymentDetailPurchases.UnitPrice,
                                    //InwardQuantity = caPaymentEntity.RefType == 201 ? paymentDetailPurchases.Quantity : 0,
                                    //OutwardQuantity = caPaymentEntity.RefType == 202 ? paymentDetailPurchases.Quantity : 0,
                                    ExpiryDate = paymentDetailPurchases.ExpiryDate,
                                    LotNo = paymentDetailPurchases.LotNo,
                                    CurrencyCode = paymentDetailPurchases.CurrencyCode,
                                };

                                //add by thangnd
                                if (caPaymentEntity.RefType == 201)
                                {
                                    inventoryLedgerEntity.InwardAmount = paymentDetailPurchases.AmountExchange;
                                    inventoryLedgerEntity.InwardAmountOC = paymentDetailPurchases.Amount;
                                    inventoryLedgerEntity.OutwardAmount = 0;
                                    inventoryLedgerEntity.InwardQuantity = paymentDetailPurchases.Quantity;
                                    inventoryLedgerEntity.OutwardQuantity = 0;
                                }
                                paymentResponse.Message = InventoryLedgerDao.InsertInventoryLedger(inventoryLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                            }

                            #endregion

                            #region Insert into GeneralLedger

                            if (paymentDetailPurchases.DebitAccount != null && paymentDetailPurchases.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = paymentDetailPurchases.AccountingObjectId,
                                    BankId = paymentDetailPurchases.BankId,
                                    BudgetChapterCode = paymentDetailPurchases.BudgetChapterCode,
                                    ProjectId = paymentDetailPurchases.ProjectId,
                                    BudgetSourceId = paymentDetailPurchases.BudgetSourceId,
                                    Description = paymentDetailPurchases.Description,
                                    RefDetailId = paymentDetailPurchases.RefDetailId,
                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                    ActivityId = paymentDetailPurchases.ActivityId,
                                    BudgetSubKindItemCode = paymentDetailPurchases.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetailPurchases.BudgetKindItemCode,
                                    RefId = paymentDetailPurchases.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetailPurchases.MethodDistributeId,
                                    OrgRefNo = paymentDetailPurchases.OrgRefNo,
                                    OrgRefDate = paymentDetailPurchases.OrgRefDate,
                                    BudgetItemCode = paymentDetailPurchases.BudgetItemCode,
                                    ListItemId = paymentDetailPurchases.ListItemId,
                                    BudgetSubItemCode = paymentDetailPurchases.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetailPurchases.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetailPurchases.CashWithdrawTypeId,
                                    AccountNumber = paymentDetailPurchases.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetailPurchases.CreditAccount,
                                    DebitAmount = paymentDetailPurchases.AmountExchange,
                                    DebitAmountOC = paymentDetailPurchases.Amount,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = paymentDetailPurchases.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetailPurchases.SortOrder,
                                    BudgetExpenseId = paymentDetailPurchases.BudgetExpenseId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = paymentDetailPurchases.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailPurchases.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = paymentDetailPurchases.AmountExchange;
                                generalLedgerEntity.CreditAmountOC = paymentDetailPurchases.Amount;// khong hieu sao cho nay lai luu nguoc Amount va AmountOC, nhung lai thay no dung =)))
                                generalLedgerEntity.CreditAmountOC = paymentDetailPurchases.Amount;
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                    BankId = paymentDetailPurchases.BankId,
                                    BudgetChapterCode = paymentDetailPurchases.BudgetChapterCode,
                                    ProjectId = paymentDetailPurchases.ProjectId,
                                    BudgetSourceId = paymentDetailPurchases.BudgetSourceId,
                                    Description = paymentDetailPurchases.Description,
                                    RefDetailId = paymentDetailPurchases.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = paymentDetailPurchases.ActivityId,
                                    BudgetSubKindItemCode = paymentDetailPurchases.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetailPurchases.BudgetKindItemCode,
                                    RefId = caPaymentEntity.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetailPurchases.MethodDistributeId,
                                    OrgRefNo = paymentDetailPurchases.OrgRefNo,
                                    OrgRefDate = paymentDetailPurchases.OrgRefDate,
                                    BudgetItemCode = paymentDetailPurchases.BudgetItemCode,
                                    ListItemId = paymentDetailPurchases.ListItemId,
                                    BudgetSubItemCode = paymentDetailPurchases.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetailPurchases.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetailPurchases.CashWithdrawTypeId,
                                    AccountNumber = paymentDetailPurchases.DebitAccount ?? paymentDetailPurchases.CreditAccount,
                                    DebitAmount = paymentDetailPurchases.DebitAccount == null ? 0 : paymentDetailPurchases.AmountExchange,
                                    DebitAmountOC = paymentDetailPurchases.DebitAccount == null ? 0 : paymentDetailPurchases.Amount,
                                    CreditAmount = paymentDetailPurchases.CreditAccount == null ? 0 : paymentDetailPurchases.AmountExchange,
                                    CreditAmountOC = paymentDetailPurchases.CreditAccount == null ? 0 : paymentDetailPurchases.Amount,
                                    FundStructureId = paymentDetailPurchases.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetailPurchases.SortOrder,
                                    BudgetExpenseId = paymentDetailPurchases.BudgetExpenseId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }

                            #endregion

                            #region Insert OriginalGeneralLedger
                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                            {
                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                RefType = caPaymentEntity.RefType,
                                RefId = caPaymentEntity.RefId,
                                RefDetailId = paymentDetailPurchases.RefDetailId,
                                OrgRefDate = paymentDetailPurchases.OrgRefDate,
                                OrgRefNo = paymentDetailPurchases.OrgRefNo,
                                RefDate = caPaymentEntity.RefDate,
                                RefNo = caPaymentEntity.RefNo,
                                AccountingObjectId = paymentDetailPurchases.AccountingObjectId,
                                ActivityId = paymentDetailPurchases.ActivityId,
                                Amount = paymentDetailPurchases.AmountExchange,
                                AmountOC = paymentDetailPurchases.Amount,
                                Approved = paymentDetailPurchases.Approved,
                                BudgetChapterCode = paymentDetailPurchases.BudgetChapterCode,
                                BudgetDetailItemCode = paymentDetailPurchases.BudgetDetailItemCode,
                                BudgetItemCode = paymentDetailPurchases.BudgetItemCode,
                                BudgetKindItemCode = paymentDetailPurchases.BudgetKindItemCode,
                                BudgetSourceId = paymentDetailPurchases.BudgetSourceId,
                                BudgetSubItemCode = paymentDetailPurchases.BudgetSubItemCode,
                                BudgetSubKindItemCode = paymentDetailPurchases.BudgetSubKindItemCode,
                                CashWithDrawTypeId = paymentDetailPurchases.CashWithdrawTypeId,
                                CreditAccount = paymentDetailPurchases.CreditAccount,
                                DebitAccount = paymentDetailPurchases.DebitAccount,
                                Description = paymentDetailPurchases.Description,
                                FundStructureId = paymentDetailPurchases.FundStructureId,
                                ProjectActivityId = paymentDetailPurchases.ProjectActivityId,
                                MethodDistributeId = paymentDetailPurchases.MethodDistributeId,
                                JournalMemo = caPaymentEntity.JournalMemo,
                                ProjectId = paymentDetailPurchases.ProjectId,
                                SortOrder = paymentDetailPurchases.SortOrder,
                                PostedDate = caPaymentEntity.PostedDate,
                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                BudgetExpenseId = paymentDetailPurchases.BudgetExpenseId,
                                BankId = paymentDetailPurchases.BankId,
                                ContractId = paymentDetailPurchases.ContractId,
                            };
                            paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #endregion
                        }
                    }

                    if (caPaymentEntity.CAPaymentDetailFixedAssets != null)
                    {
                        foreach (var paymentDetailFixedAsset in caPaymentEntity.CAPaymentDetailFixedAssets)
                        {
                            paymentDetailFixedAsset.RefId = caPaymentEntity.RefId;
                            paymentDetailFixedAsset.RefDetailId = Guid.NewGuid().ToString();

                            if (!paymentDetailFixedAsset.Validate())
                            {
                                foreach (string error in paymentDetailFixedAsset.ValidationErrors)
                                    paymentResponse.Message += error + Environment.NewLine;
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }
                            paymentResponse.Message = CAPaymentDetailFixedAssetDao.InsertCAPaymentDetailFixedAsset(paymentDetailFixedAsset);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                            {
                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                return paymentResponse;
                            }

                            #region Insert FixedAssetLedger
                            if (paymentDetailFixedAsset.FixedAssetId != null)
                            {
                                //get fixedAssetInfo

                                //foreach (var cAPaymentDetailFixedAssetDetail in caPaymentEntity.CAPaymentDetailFixedAssets)
                                {
                                    if (paymentDetailFixedAsset.DebitAccount.StartsWith("21"))
                                    {
                                        var fixedAssetEntity = FixedAssetDao.GetFixedAssetById(paymentDetailFixedAsset.FixedAssetId);

                                        var fixedAssetLedgerEntity = new FixedAssetLedgerEntity
                                        {
                                            FixedAssetLedgerId = Guid.NewGuid().ToString(),
                                            RefId = caPaymentEntity.RefId,
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            RefDate = caPaymentEntity.RefDate,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            FixedAssetId = paymentDetailFixedAsset.FixedAssetId,
                                            DepartmentId = fixedAssetEntity.DepartmentId,
                                            LifeTime = fixedAssetEntity.LifeTime,
                                            AnnualDepreciationRate = fixedAssetEntity.DepreciationRate,
                                            AnnualDepreciationAmount = fixedAssetEntity.PeriodDepreciationAmount,
                                            OrgPriceAccount = null,
                                            OrgPriceDebitAmount = paymentDetailFixedAsset.AmountOC,
                                            OrgPriceCreditAmount = 0,
                                            DepreciationAccount = null,
                                            DepreciationDebitAmount = 0,
                                            DepreciationCreditAmount = fixedAssetEntity.AccumDepreciationAmount + fixedAssetEntity.AccumDevaluationAmount,
                                            CapitalAccount = paymentDetailFixedAsset.DebitAccount,
                                            CapitalDebitAmount = paymentDetailFixedAsset.Amount,
                                            CapitalCreditAmount = 0,
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            Description = paymentDetailFixedAsset.Description,
                                            RemainingLifeTime = fixedAssetEntity.RemainingLifeTime,
                                            EndYear = fixedAssetEntity.EndYear,
                                            DevaluationAmount = fixedAssetEntity.DevaluationAmount,
                                            DevaluationPeriod = fixedAssetEntity.DevaluationPeriod,
                                            EndDevaluationDate = fixedAssetEntity.EndDevaluationDate == new DateTime(0001, 01, 01) ? fixedAssetEntity.DevaluationDate.AddMonths((int)fixedAssetEntity.DevaluationLifeTime) : fixedAssetEntity.EndDevaluationDate,
                                            PeriodDevaluationAmount = fixedAssetEntity.PeriodDevaluationAmount,
                                            Quantity = fixedAssetEntity.Quantity
                                        };
                                        paymentResponse.Message = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region Insert into GeneralLedger

                            if (paymentDetailFixedAsset.DebitAccount != null && paymentDetailFixedAsset.CreditAccount != null)
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = paymentDetailFixedAsset.AccountingObjectId,
                                    BankId = paymentDetailFixedAsset.BankId,
                                    BudgetChapterCode = paymentDetailFixedAsset.BudgetChapterCode,
                                    ProjectId = paymentDetailFixedAsset.ProjectId,
                                    BudgetSourceId = paymentDetailFixedAsset.BudgetSourceId,
                                    Description = paymentDetailFixedAsset.Description,
                                    RefDetailId = paymentDetailFixedAsset.RefDetailId,
                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                    ActivityId = paymentDetailFixedAsset.ActivityId,
                                    BudgetSubKindItemCode = paymentDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetailFixedAsset.BudgetKindItemCode,
                                    RefId = paymentDetailFixedAsset.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetailFixedAsset.MethodDistributeId,
                                    OrgRefNo = paymentDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = paymentDetailFixedAsset.OrgRefDate,
                                    BudgetItemCode = paymentDetailFixedAsset.BudgetItemCode,
                                    ListItemId = paymentDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = paymentDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetailFixedAsset.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetailFixedAsset.CashWithdrawTypeId,
                                    AccountNumber = paymentDetailFixedAsset.DebitAccount,
                                    CorrespondingAccountNumber = paymentDetailFixedAsset.CreditAccount,
                                    DebitAmount = paymentDetailFixedAsset.Amount,
                                    DebitAmountOC = paymentDetailFixedAsset.AmountOC,
                                    CreditAmount = 0,
                                    CreditAmountOC = 0,
                                    FundStructureId = paymentDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetailFixedAsset.SortOrder,
                                    BudgetExpenseId = paymentDetailFixedAsset.BudgetExpenseId,
                                    ContractId = paymentDetailFixedAsset.ContractId,
                                    CapitalPlanId = paymentDetailFixedAsset.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }

                                //insert lan 2
                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                generalLedgerEntity.AccountNumber = paymentDetailFixedAsset.CreditAccount;
                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailFixedAsset.DebitAccount;
                                generalLedgerEntity.DebitAmount = 0;
                                generalLedgerEntity.DebitAmountOC = 0;
                                generalLedgerEntity.CreditAmount = paymentDetailFixedAsset.Amount;
                                generalLedgerEntity.CreditAmountOC = paymentDetailFixedAsset.AmountOC;
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }
                            else //ghi don
                            {
                                var generalLedgerEntity = new GeneralLedgerEntity
                                {
                                    RefType = caPaymentEntity.RefType,
                                    RefNo = caPaymentEntity.RefNo,
                                    AccountingObjectId = caPaymentEntity.AccountingObjectId,
                                    BankId = paymentDetailFixedAsset.BankId,
                                    BudgetChapterCode = paymentDetailFixedAsset.BudgetChapterCode,
                                    ProjectId = paymentDetailFixedAsset.ProjectId,
                                    BudgetSourceId = paymentDetailFixedAsset.BudgetSourceId,
                                    Description = paymentDetailFixedAsset.Description,
                                    RefDetailId = paymentDetailFixedAsset.RefDetailId,
                                    ExchangeRate = 1,
                                    ActivityId = paymentDetailFixedAsset.ActivityId,
                                    BudgetSubKindItemCode = paymentDetailFixedAsset.BudgetSubKindItemCode,
                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                    BudgetKindItemCode = paymentDetailFixedAsset.BudgetKindItemCode,
                                    RefId = caPaymentEntity.RefId,
                                    PostedDate = caPaymentEntity.PostedDate,
                                    MethodDistributeId = paymentDetailFixedAsset.MethodDistributeId,
                                    OrgRefNo = paymentDetailFixedAsset.OrgRefNo,
                                    OrgRefDate = paymentDetailFixedAsset.OrgRefDate,
                                    BudgetItemCode = paymentDetailFixedAsset.BudgetItemCode,
                                    ListItemId = paymentDetailFixedAsset.ListItemId,
                                    BudgetSubItemCode = paymentDetailFixedAsset.BudgetSubItemCode,
                                    BudgetDetailItemCode = paymentDetailFixedAsset.BudgetDetailItemCode,
                                    CashWithDrawTypeId = paymentDetailFixedAsset.CashWithdrawTypeId,
                                    AccountNumber = paymentDetailFixedAsset.DebitAccount ?? paymentDetailFixedAsset.CreditAccount,
                                    DebitAmount = paymentDetailFixedAsset.DebitAccount == null ? 0 : paymentDetailFixedAsset.Amount,
                                    DebitAmountOC = paymentDetailFixedAsset.DebitAccount == null ? 0 : paymentDetailFixedAsset.Amount,
                                    CreditAmount = paymentDetailFixedAsset.CreditAccount == null ? 0 : paymentDetailFixedAsset.Amount,
                                    CreditAmountOC = paymentDetailFixedAsset.CreditAccount == null ? 0 : paymentDetailFixedAsset.Amount,
                                    FundStructureId = paymentDetailFixedAsset.FundStructureId,
                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                    JournalMemo = caPaymentEntity.JournalMemo,
                                    RefDate = caPaymentEntity.RefDate,
                                    SortOrder = paymentDetailFixedAsset.SortOrder,
                                    BudgetExpenseId = paymentDetailFixedAsset.BudgetExpenseId,
                                    ContractId = paymentDetailFixedAsset.ContractId,
                                    CapitalPlanId = paymentDetailFixedAsset.CapitalPlanId
                                };
                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                {
                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                    return paymentResponse;
                                }
                            }

                            #endregion

                            #region Original Ledger
                            AutoMapper(InsertOriginalLedger(paymentDetailFixedAsset, caPaymentEntity), paymentResponse);
                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                goto Error;
                            #endregion
                        }
                    }

                    #region Sinh dinh khoan dong thoi
                    if (caPaymentEntity.RefType == 108)
                    {
                        if (!isAutoGenerateParallel)
                        {
                            #region CAPaymentDetailParallel

                            if (caPaymentEntity.CAPaymentDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var paymentDetailParallel in caPaymentEntity.CAPaymentDetailParallels)
                                {
                                    #region Insert CA Payment Detail Parallel

                                    paymentDetailParallel.RefId = caPaymentEntity.RefId;
                                    paymentDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                    if (!paymentDetailParallel.Validate())
                                    {
                                        foreach (var error in paymentDetailParallel.ValidationErrors)
                                            paymentResponse.Message += error + Environment.NewLine;
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    paymentResponse.Message = CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(paymentDetailParallel);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount ?? paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            CreditAmount = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.Amount,
                                            CreditAmountOC = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = caPaymentEntity.RefType,
                                        RefId = caPaymentEntity.RefId,
                                        RefDetailId = paymentDetailParallel.RefDetailId,
                                        OrgRefDate = paymentDetailParallel.OrgRefDate,
                                        OrgRefNo = paymentDetailParallel.OrgRefNo,
                                        RefDate = caPaymentEntity.RefDate,
                                        RefNo = caPaymentEntity.RefNo,
                                        AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                        ActivityId = paymentDetailParallel.ActivityId,
                                        Amount = paymentDetailParallel.Amount,
                                        AmountOC = paymentDetailParallel.AmountOC,
                                        //Approved = paymentDetail.Approved,
                                        BankId = paymentDetailParallel.BankId,
                                        BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = paymentDetailParallel.CreditAccount,
                                        DebitAccount = paymentDetailParallel.DebitAccount,
                                        Description = paymentDetailParallel.Description,
                                        FundStructureId = paymentDetailParallel.FundStructureId,
                                        //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                        MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                        JournalMemo = caPaymentEntity.JournalMemo,
                                        ProjectId = paymentDetailParallel.ProjectId,
                                        ToBankId = paymentDetailParallel.BankId,
                                        ExchangeRate = caPaymentEntity.ExchangeRate,
                                        CurrencyCode = caPaymentEntity.CurrencyCode,
                                        PostedDate = caPaymentEntity.PostedDate,
                                        BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                        ContractId = paymentDetailParallel.ContractId,
                                    };
                                    paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //Phiếu chi
                            if (caPaymentEntity.CaPaymentDetails != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithDrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua vật tư hàng hóa
                            if (caPaymentEntity.CAPaymentDetailPurchases != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountExchange,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua tscd

                            if (caPaymentEntity.CAPaymentDetailFixedAssets != null)
                            {
                                //List<CAPaymentDetailParallelEntity> list = new List<CAPaymentDetailParallelEntity>();
                                //foreach (var item in caPaymentEntity.CAPaymentDetailParallels)
                                //{
                                //    list.Add(item);
                                //    paymentResponse.Message =
                                //                CAPaymentDetailParallelDao.DeleteCAPaymentDetailParallelId(
                                //                    item.RefId);
                                //}
                                var paymentDetail = caPaymentEntity.CAPaymentDetailFixedAssets[0];
                                if(paymentDetail !=null)
                                {
                                    foreach (var autoBusinessParallelEntity in caPaymentEntity.CAPaymentDetailParallels)
                                    {
                                        #region CAReceiptDetailParallel

                                        var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                        {
                                            RefId = caPaymentEntity.RefId,
                                            RefDetailId = Guid.NewGuid().ToString(),
                                            Description = paymentDetail.Description,
                                            DebitAccount = autoBusinessParallelEntity.DebitAccount,
                                            CreditAccount = autoBusinessParallelEntity.CreditAccount,
                                            Amount = paymentDetail.Amount,
                                            AmountOC = paymentDetail.AmountOC,
                                            FixedAssetId = paymentDetail.FixedAssetId,
                                            UnitPrice = paymentDetail.OrgPrice,
                                            Quantity = paymentDetail.Quantity,
                                            BudgetSourceId =
                                                    paymentDetail.BudgetSourceId,
                                            BudgetChapterCode =
                                                    paymentDetail.BudgetChapterCode,
                                            BudgetKindItemCode =
                                                    paymentDetail.BudgetKindItemCode,
                                            BudgetSubKindItemCode =
                                                    paymentDetail.BudgetSubKindItemCode,
                                            BudgetItemCode =
                                                    paymentDetail.BudgetItemCode,
                                            BudgetSubItemCode =
                                                    paymentDetail.BudgetSubItemCode,
                                            MethodDistributeId =
                                                    paymentDetail.MethodDistributeId,
                                            CashWithdrawTypeId =
                                                    paymentDetail.CashWithdrawTypeId,
                                            AccountingObjectId = paymentDetail.AccountingObjectId,
                                            ActivityId = paymentDetail.ActivityId,
                                            ProjectId = paymentDetail.ProjectId,
                                            ListItemId = paymentDetail.ListItemId,
                                            Approved = true,
                                            SortOrder = paymentDetail.SortOrder,
                                            OrgRefNo = paymentDetail.OrgRefNo,
                                            OrgRefDate = paymentDetail.OrgRefDate,
                                            FundStructureId = paymentDetail.FundStructureId,
                                            //BankId = paymentDetail.BankId,
                                            BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                            ContractId = paymentDetail.ContractId,
                                            CapitalPlanId = paymentDetail.CapitalPlanId,
                                            AutoBusinessId = paymentDetail.AutoBusinessId
                                            //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                            //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                        };
                                        if (!paymentDetailParallel.Validate())
                                        {
                                            foreach (var error in paymentDetailParallel.ValidationErrors)
                                                paymentResponse.Message += error + Environment.NewLine;
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        #endregion

                                        #region Insert General Ledger Entity
                                        if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = caPaymentEntity.RefType,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                Description = paymentDetailParallel.Description,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                RefId = caPaymentEntity.RefId,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                ListItemId = paymentDetailParallel.ListItemId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                paymentDetailParallel.DebitAccount,
                                                CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                DebitAmount = paymentDetailParallel.Amount,
                                                DebitAmountOC = paymentDetailParallel.AmountOC,
                                                CreditAmount = 0,
                                                CreditAmountOC = 0,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                RefDate = caPaymentEntity.RefDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                                CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                            };
                                            paymentResponse.Message =
                                                GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            //insert lan 2
                                            generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                            generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                            generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                            generalLedgerEntity.DebitAmount = 0;
                                            generalLedgerEntity.DebitAmountOC = 0;
                                            generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                            generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                            paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                        }
                                        else
                                        {
                                            var generalLedgerEntity = new GeneralLedgerEntity
                                            {
                                                RefType = caPaymentEntity.RefType,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                Description = paymentDetailParallel.Description,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                RefId = caPaymentEntity.RefId,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                ListItemId = paymentDetailParallel.ListItemId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                AccountNumber =
                                                paymentDetailParallel.DebitAccount ??
                                                paymentDetailParallel.CreditAccount,
                                                DebitAmount =
                                                paymentDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.Amount,
                                                DebitAmountOC =
                                                paymentDetailParallel.DebitAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.AmountOC,
                                                CreditAmount =
                                                paymentDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.Amount,
                                                CreditAmountOC =
                                                paymentDetailParallel.CreditAccount == null
                                                    ? 0
                                                    : paymentDetailParallel.AmountOC,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                GeneralLedgerId = Guid.NewGuid().ToString(),
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                RefDate = caPaymentEntity.RefDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                                CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                            };
                                            paymentResponse.Message =
                                                GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                        }

                                        #endregion

                                        #region Insert OriginalGeneralLedger

                                        var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                        {
                                            OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                            RefType = caPaymentEntity.RefType,
                                            RefId = caPaymentEntity.RefId,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            RefDate = caPaymentEntity.RefDate,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            Amount = paymentDetailParallel.Amount,
                                            AmountOC = paymentDetailParallel.AmountOC,
                                            //Approved = paymentDetail.Approved,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            CreditAccount = paymentDetailParallel.CreditAccount,
                                            DebitAccount = paymentDetailParallel.DebitAccount,
                                            Description = paymentDetailParallel.Description,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            ToBankId = paymentDetailParallel.BankId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                        };
                                        paymentResponse.Message =
                                            OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                originalGeneralLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        #endregion


                                    }
                                }
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet

                             
                            }
                        }
                    }
                    else
                    {
                        if (!isAutoGenerateParallel)
                        {
                            #region CAPaymentDetailParallel

                            if (caPaymentEntity.CAPaymentDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var paymentDetailParallel in caPaymentEntity.CAPaymentDetailParallels)
                                {
                                    #region Insert CA Payment Detail Parallel

                                    paymentDetailParallel.RefId = caPaymentEntity.RefId;
                                    paymentDetailParallel.RefDetailId = Guid.NewGuid().ToString();

                                    if (!paymentDetailParallel.Validate())
                                    {
                                        foreach (var error in paymentDetailParallel.ValidationErrors)
                                            paymentResponse.Message += error + Environment.NewLine;
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    paymentResponse.Message = CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(paymentDetailParallel);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion

                                    #region Insert General Ledger Entity
                                    if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount,
                                            CorrespondingAccountNumber = paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.AmountOC,
                                            CreditAmount = 0,
                                            CreditAmountOC = 0,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }

                                        //insert lan 2
                                        generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                        generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                        generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                        generalLedgerEntity.DebitAmount = 0;
                                        generalLedgerEntity.DebitAmountOC = 0;
                                        generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                        generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }
                                    else
                                    {
                                        var generalLedgerEntity = new GeneralLedgerEntity
                                        {
                                            RefType = caPaymentEntity.RefType,
                                            RefNo = caPaymentEntity.RefNo,
                                            AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                            BankId = paymentDetailParallel.BankId,
                                            BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                            ProjectId = paymentDetailParallel.ProjectId,
                                            BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                            Description = paymentDetailParallel.Description,
                                            RefDetailId = paymentDetailParallel.RefDetailId,
                                            ExchangeRate = caPaymentEntity.ExchangeRate,
                                            ActivityId = paymentDetailParallel.ActivityId,
                                            BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                            CurrencyCode = caPaymentEntity.CurrencyCode,
                                            BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                            RefId = caPaymentEntity.RefId,
                                            PostedDate = caPaymentEntity.PostedDate,
                                            MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                            OrgRefNo = paymentDetailParallel.OrgRefNo,
                                            OrgRefDate = paymentDetailParallel.OrgRefDate,
                                            BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                            ListItemId = paymentDetailParallel.ListItemId,
                                            BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                            BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                            CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                            AccountNumber = paymentDetailParallel.DebitAccount ?? paymentDetailParallel.CreditAccount,
                                            DebitAmount = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.Amount,
                                            DebitAmountOC = paymentDetailParallel.DebitAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            CreditAmount = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.Amount,
                                            CreditAmountOC = paymentDetailParallel.CreditAccount == null ? 0 : paymentDetailParallel.AmountOC,
                                            FundStructureId = paymentDetailParallel.FundStructureId,
                                            GeneralLedgerId = Guid.NewGuid().ToString(),
                                            JournalMemo = caPaymentEntity.JournalMemo,
                                            RefDate = caPaymentEntity.RefDate,
                                            BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                            ContractId = paymentDetailParallel.ContractId,
                                            CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                        };
                                        paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                        if (!string.IsNullOrEmpty(paymentResponse.Message))
                                        {
                                            paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                            return paymentResponse;
                                        }
                                    }


                                    #endregion

                                    #region Insert OriginalGeneralLedger

                                    var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                    {
                                        OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                        RefType = caPaymentEntity.RefType,
                                        RefId = caPaymentEntity.RefId,
                                        RefDetailId = paymentDetailParallel.RefDetailId,
                                        OrgRefDate = paymentDetailParallel.OrgRefDate,
                                        OrgRefNo = paymentDetailParallel.OrgRefNo,
                                        RefDate = caPaymentEntity.RefDate,
                                        RefNo = caPaymentEntity.RefNo,
                                        AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                        ActivityId = paymentDetailParallel.ActivityId,
                                        Amount = paymentDetailParallel.Amount,
                                        AmountOC = paymentDetailParallel.AmountOC,
                                        //Approved = paymentDetail.Approved,
                                        BankId = paymentDetailParallel.BankId,
                                        BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                        BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                        BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                        BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                        BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                        BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                        BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                        CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                        CreditAccount = paymentDetailParallel.CreditAccount,
                                        DebitAccount = paymentDetailParallel.DebitAccount,
                                        Description = paymentDetailParallel.Description,
                                        FundStructureId = paymentDetailParallel.FundStructureId,
                                        //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                        MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                        JournalMemo = caPaymentEntity.JournalMemo,
                                        ProjectId = paymentDetailParallel.ProjectId,
                                        ToBankId = paymentDetailParallel.BankId,
                                        ExchangeRate = caPaymentEntity.ExchangeRate,
                                        CurrencyCode = caPaymentEntity.CurrencyCode,
                                        PostedDate = caPaymentEntity.PostedDate,
                                        BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                        ContractId = paymentDetailParallel.ContractId,
                                    };
                                    paymentResponse.Message = OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(originalGeneralLedgerEntity);
                                    if (!string.IsNullOrEmpty(paymentResponse.Message))
                                    {
                                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                        return paymentResponse;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //Phiếu chi
                            if (caPaymentEntity.CaPaymentDetails != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CaPaymentDetails)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithDrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountOC,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithDrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber = paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }


                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua vật tư hàng hóa
                            if (caPaymentEntity.CAPaymentDetailPurchases != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailPurchases)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.AmountExchange,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }

                            //Phiếu chi mua tscd
                            if (caPaymentEntity.CAPaymentDetailFixedAssets != null)
                            {
                                //truong hop sinh tu dong se sinh theo chung tu chi tiet
                                foreach (var paymentDetail in caPaymentEntity.CAPaymentDetailFixedAssets)
                                {
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao
                                        .GetAutoBusinessParallelsByAutoBussinessInformations(
                                            paymentDetail.DebitAccount, paymentDetail.CreditAccount,
                                            paymentDetail.BudgetSourceId,
                                            paymentDetail.BudgetChapterCode, paymentDetail.BudgetKindItemCode,
                                            paymentDetail.BudgetSubKindItemCode, paymentDetail.BudgetItemCode,
                                            paymentDetail.BudgetSubItemCode,
                                            paymentDetail.MethodDistributeId, paymentDetail.CashWithdrawTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region CAReceiptDetailParallel

                                            var paymentDetailParallel = new CAPaymentDetailParallelEntity()
                                            {
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = Guid.NewGuid().ToString(),
                                                Description = paymentDetail.Description,
                                                DebitAccount = autoBusinessParallelEntity.DebitAccountParallel,
                                                CreditAccount = autoBusinessParallelEntity.CreditAccountParallel,
                                                Amount = paymentDetail.Amount,
                                                AmountOC = paymentDetail.Amount,
                                                FixedAssetId = paymentDetail.FixedAssetId,
                                                UnitPrice = paymentDetail.OrgPrice,
                                                Quantity = paymentDetail.Quantity,
                                                BudgetSourceId =
                                                    autoBusinessParallelEntity.BudgetSourceIdParallel ??
                                                    paymentDetail.BudgetSourceId,
                                                BudgetChapterCode =
                                                    autoBusinessParallelEntity.BudgetChapterCodeParallel ??
                                                    paymentDetail.BudgetChapterCode,
                                                BudgetKindItemCode =
                                                    autoBusinessParallelEntity.BudgetKindItemCodeParallel ??
                                                    paymentDetail.BudgetKindItemCode,
                                                BudgetSubKindItemCode =
                                                    autoBusinessParallelEntity.BudgetSubKindItemCodeParallel ??
                                                    paymentDetail.BudgetSubKindItemCode,
                                                BudgetItemCode =
                                                    autoBusinessParallelEntity.BudgetItemCodeParallel ??
                                                    paymentDetail.BudgetItemCode,
                                                BudgetSubItemCode =
                                                    autoBusinessParallelEntity.BudgetSubItemCodeParallel ??
                                                    paymentDetail.BudgetSubItemCode,
                                                MethodDistributeId =
                                                    autoBusinessParallelEntity.MethodDistributeIdParallel ??
                                                    paymentDetail.MethodDistributeId,
                                                CashWithdrawTypeId =
                                                    autoBusinessParallelEntity.CashWithDrawTypeIdParallel ??
                                                    paymentDetail.CashWithdrawTypeId,
                                                AccountingObjectId = paymentDetail.AccountingObjectId,
                                                ActivityId = paymentDetail.ActivityId,
                                                ProjectId = paymentDetail.ProjectId,
                                                ListItemId = paymentDetail.ListItemId,
                                                Approved = true,
                                                SortOrder = paymentDetail.SortOrder,
                                                OrgRefNo = paymentDetail.OrgRefNo,
                                                OrgRefDate = paymentDetail.OrgRefDate,
                                                FundStructureId = paymentDetail.FundStructureId,
                                                //BankId = paymentDetail.BankId,
                                                BudgetExpenseId = paymentDetail.BudgetExpenseId,
                                                ContractId = paymentDetail.ContractId,
                                                CapitalPlanId = paymentDetail.CapitalPlanId,
                                                AutoBusinessId = paymentDetail.AutoBusinessId
                                                //paymentDetailParallel.BudgetExpenseId = paymentDetail.BudgetExpenseId;
                                                //paymentDetailParallel.BudgetProvideCode = paymentDetail.BudgetProvideCode;
                                            };
                                            if (!paymentDetailParallel.Validate())
                                            {
                                                foreach (var error in paymentDetailParallel.ValidationErrors)
                                                    paymentResponse.Message += error + Environment.NewLine;
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }
                                            paymentResponse.Message =
                                                CAPaymentDetailParallelDao.InsertCAPaymentDetailParallel(
                                                    paymentDetailParallel);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion

                                            #region Insert General Ledger Entity
                                            if (paymentDetailParallel.DebitAccount != null && paymentDetailParallel.CreditAccount != null)
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount,
                                                    CorrespondingAccountNumber = paymentDetailParallel.CreditAccount, // Thêm TK Có
                                                    DebitAmount = paymentDetailParallel.Amount,
                                                    DebitAmountOC = paymentDetailParallel.AmountOC,
                                                    CreditAmount = 0,
                                                    CreditAmountOC = 0,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }

                                                //insert lan 2
                                                generalLedgerEntity.GeneralLedgerId = Guid.NewGuid().ToString();
                                                generalLedgerEntity.AccountNumber = paymentDetailParallel.CreditAccount;
                                                generalLedgerEntity.CorrespondingAccountNumber = paymentDetailParallel.DebitAccount;
                                                generalLedgerEntity.DebitAmount = 0;
                                                generalLedgerEntity.DebitAmountOC = 0;
                                                generalLedgerEntity.CreditAmount = paymentDetailParallel.Amount;
                                                generalLedgerEntity.CreditAmountOC = paymentDetailParallel.AmountOC;
                                                paymentResponse.Message = GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);

                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }
                                            else
                                            {
                                                var generalLedgerEntity = new GeneralLedgerEntity
                                                {
                                                    RefType = caPaymentEntity.RefType,
                                                    RefNo = caPaymentEntity.RefNo,
                                                    AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                    BankId = paymentDetailParallel.BankId,
                                                    BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                    ProjectId = paymentDetailParallel.ProjectId,
                                                    BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                    Description = paymentDetailParallel.Description,
                                                    RefDetailId = paymentDetailParallel.RefDetailId,
                                                    ExchangeRate = caPaymentEntity.ExchangeRate,
                                                    ActivityId = paymentDetailParallel.ActivityId,
                                                    BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                    CurrencyCode = caPaymentEntity.CurrencyCode,
                                                    BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                    RefId = caPaymentEntity.RefId,
                                                    PostedDate = caPaymentEntity.PostedDate,
                                                    MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                    OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                    OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                    BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                    ListItemId = paymentDetailParallel.ListItemId,
                                                    BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                    BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                    CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                    AccountNumber =
                                                    paymentDetailParallel.DebitAccount ??
                                                    paymentDetailParallel.CreditAccount,
                                                    DebitAmount =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    DebitAmountOC =
                                                    paymentDetailParallel.DebitAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    CreditAmount =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.Amount,
                                                    CreditAmountOC =
                                                    paymentDetailParallel.CreditAccount == null
                                                        ? 0
                                                        : paymentDetailParallel.AmountOC,
                                                    FundStructureId = paymentDetailParallel.FundStructureId,
                                                    GeneralLedgerId = Guid.NewGuid().ToString(),
                                                    JournalMemo = caPaymentEntity.JournalMemo,
                                                    RefDate = caPaymentEntity.RefDate,
                                                    BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                    ContractId = paymentDetailParallel.ContractId,
                                                    CapitalPlanId = paymentDetailParallel.CapitalPlanId
                                                };
                                                paymentResponse.Message =
                                                    GeneralLedgerDao.InsertGeneralLedger(generalLedgerEntity);
                                                if (!string.IsNullOrEmpty(paymentResponse.Message))
                                                {
                                                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                    return paymentResponse;
                                                }
                                            }

                                            #endregion

                                            #region Insert OriginalGeneralLedger

                                            var originalGeneralLedgerEntity = new OriginalGeneralLedgerEntity
                                            {
                                                OriginalGeneralLedgerId = Guid.NewGuid().ToString(),
                                                RefType = caPaymentEntity.RefType,
                                                RefId = caPaymentEntity.RefId,
                                                RefDetailId = paymentDetailParallel.RefDetailId,
                                                OrgRefDate = paymentDetailParallel.OrgRefDate,
                                                OrgRefNo = paymentDetailParallel.OrgRefNo,
                                                RefDate = caPaymentEntity.RefDate,
                                                RefNo = caPaymentEntity.RefNo,
                                                AccountingObjectId = paymentDetailParallel.AccountingObjectId,
                                                ActivityId = paymentDetailParallel.ActivityId,
                                                Amount = paymentDetailParallel.Amount,
                                                AmountOC = paymentDetailParallel.AmountOC,
                                                //Approved = paymentDetail.Approved,
                                                BankId = paymentDetailParallel.BankId,
                                                BudgetChapterCode = paymentDetailParallel.BudgetChapterCode,
                                                BudgetDetailItemCode = paymentDetailParallel.BudgetDetailItemCode,
                                                BudgetItemCode = paymentDetailParallel.BudgetItemCode,
                                                BudgetKindItemCode = paymentDetailParallel.BudgetKindItemCode,
                                                BudgetSourceId = paymentDetailParallel.BudgetSourceId,
                                                BudgetSubItemCode = paymentDetailParallel.BudgetSubItemCode,
                                                BudgetSubKindItemCode = paymentDetailParallel.BudgetSubKindItemCode,
                                                CashWithDrawTypeId = paymentDetailParallel.CashWithdrawTypeId,
                                                CreditAccount = paymentDetailParallel.CreditAccount,
                                                DebitAccount = paymentDetailParallel.DebitAccount,
                                                Description = paymentDetailParallel.Description,
                                                FundStructureId = paymentDetailParallel.FundStructureId,
                                                //ProjectActivityId = paymentDetailParallel.ProjectActivityId,
                                                MethodDistributeId = paymentDetailParallel.MethodDistributeId,
                                                JournalMemo = caPaymentEntity.JournalMemo,
                                                ProjectId = paymentDetailParallel.ProjectId,
                                                ToBankId = paymentDetailParallel.BankId,
                                                ExchangeRate = caPaymentEntity.ExchangeRate,
                                                CurrencyCode = caPaymentEntity.CurrencyCode,
                                                PostedDate = caPaymentEntity.PostedDate,
                                                BudgetExpenseId = paymentDetailParallel.BudgetExpenseId,
                                                ContractId = paymentDetailParallel.ContractId,
                                            };
                                            paymentResponse.Message =
                                                OriginalGeneralLedgerDao.InsertOriginalGeneralLedger(
                                                    originalGeneralLedgerEntity);
                                            if (!string.IsNullOrEmpty(paymentResponse.Message))
                                            {
                                                paymentResponse.Acknowledge = AcknowledgeType.Failure;
                                                return paymentResponse;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }



                    #endregion

                    paymentResponse.RefId = caPaymentEntity.RefId;
                }
            Error:
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }
                scope.Complete();
            }

            return paymentResponse;
        }

        /// <summary>
        /// Deletes the ca payment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>
        /// CAPaymentResponse.
        /// </returns>
        public CAPaymentResponse DeleteCAPayment(string refId)
        {
            var paymentResponse = new CAPaymentResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var paymentEntityForDelete = CAPaymentDao.GetCaPaymentEntitybyRefId(refId);

                #region Update account balance
                // Cập nhật giá trị vào account balance trước khi xóa
                paymentResponse.Message = UpdateAccountBalance(paymentEntityForDelete);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                #endregion

                paymentResponse.Message = CAPaymentDao.DeleteCAPayment(paymentEntityForDelete);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                // Xóa bảng GeneralLedger
                paymentResponse.Message = GeneralLedgerDao.DeleteGeneralLedger(paymentEntityForDelete.RefId);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                // Xóa bảng OriginalGeneralLedger
                paymentResponse.Message = OriginalGeneralLedgerDao.DeleteOriginalGeneralLedger(paymentEntityForDelete.RefId);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                paymentResponse.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(paymentEntityForDelete.RefId, paymentEntityForDelete.RefType);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                if (paymentEntityForDelete.RefType == (int)BuCA.Enum.RefType.INInward)
                {
                    // Xóa bảng InventoryLedger
                    paymentResponse.Message = InventoryLedgerDao.DeleteInventoryLedger(paymentEntityForDelete.RefId);
                    if (paymentResponse.Message != null)
                    {
                        paymentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return paymentResponse;
                    }
                }

                #region Delete Parallel

                // Xóa bảng CAPaymentDetailParallel
                paymentResponse.Message = CAPaymentDetailParallelDao.DeleteCAPaymentDetailParallelId(paymentEntityForDelete.RefId);
                if (paymentResponse.Message != null)
                {
                    paymentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return paymentResponse;
                }

                #endregion

                scope.Complete();
            }

            return paymentResponse;
        }

        #region Insert/Update AccountBalance Function

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(CAPaymentEntity caPaymentEntity, CAPaymentDetailEntity paymentDetail)
        {
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = paymentDetail.DebitAccount,
                CurrencyCode = caPaymentEntity.CurrencyCode,
                ExchangeRate = caPaymentEntity.ExchangeRate,
                BalanceDate = caPaymentEntity.PostedDate,
                MovementDebitAmountOC = paymentDetail.AmountOC,
                MovementDebitAmount = paymentDetail.Amount,
                MovementCreditAmountOC = 0,
                MovementCreditAmount = 0,
                BudgetSourceId = paymentDetail.BudgetSourceId,
                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                BudgetItemCode = paymentDetail.BudgetItemCode,
                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                MethodDistributeId = paymentDetail.MethodDistributeId,
                AccountingObjectId = caPaymentEntity.AccountingObjectId,
                ActivityId = paymentDetail.ActivityId,
                ProjectId = paymentDetail.ProjectId,
                BankAccount = paymentDetail.BankId,
                FundStructureId = paymentDetail.FundStructureId,
                ProjectActivityId = paymentDetail.ProjectActivityId,
                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(CAPaymentEntity caPaymentEntity, CAPaymentDetailEntity paymentDetail)
        {
            //credit account
            return new AccountBalanceEntity
            {
                AccountBalanceId = Guid.NewGuid().ToString(),
                AccountNumber = paymentDetail.CreditAccount,
                CurrencyCode = caPaymentEntity.CurrencyCode,
                ExchangeRate = caPaymentEntity.ExchangeRate,
                BalanceDate = caPaymentEntity.PostedDate,
                MovementDebitAmountOC = 0,
                MovementDebitAmount = 0,
                MovementCreditAmountOC = paymentDetail.AmountOC,
                MovementCreditAmount = paymentDetail.Amount,
                BudgetSourceId = paymentDetail.BudgetSourceId,
                BudgetChapterCode = paymentDetail.BudgetChapterCode,
                BudgetKindItemCode = paymentDetail.BudgetKindItemCode,
                BudgetSubKindItemCode = paymentDetail.BudgetSubKindItemCode,
                BudgetItemCode = paymentDetail.BudgetItemCode,
                BudgetSubItemCode = paymentDetail.BudgetSubItemCode,
                MethodDistributeId = paymentDetail.MethodDistributeId,
                AccountingObjectId = caPaymentEntity.AccountingObjectId,
                ActivityId = paymentDetail.ActivityId,
                ProjectId = paymentDetail.ProjectId,
                BankAccount = paymentDetail.BankId,
                FundStructureId = paymentDetail.FundStructureId,
                ProjectActivityId = paymentDetail.ProjectActivityId,
                BudgetDetailItemCode = paymentDetail.BudgetDetailItemCode
            };
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalanceEntity">The account balance entity.</param>
        /// <param name="movementAmount">The movement amount.</param>
        /// <param name="movementAmountExchange">The movement amount exchange.</param>
        /// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange,
            bool isMovementAmount, int balanceSide)
        {
            string message;
            // cập nhật bên TK nợ
            if (balanceSide == 1)
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount + movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementDebitAmount = accountBalanceEntity.MovementDebitAmount - movementAmount;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            else
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount + movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC + movementAmountExchange;
                }
                else
                {
                    accountBalanceEntity.MovementCreditAmount = accountBalanceEntity.MovementCreditAmount - movementAmount;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC - movementAmountExchange;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null)
                    return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(CAPaymentEntity caPaymentEntity)
        {
            var paymentDetails = CAPaymentDetailDao.GetCaPaymentDetailbyRefId(caPaymentEntity.RefId);
            foreach (var paymentDetail in paymentDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, paymentDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmount, false, 1);
                    if (message != null)
                        return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, paymentDetail);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmount, false, 2);
                    if (message != null)
                        return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="caPaymentEntity">The ca payment entity.</param>
        /// <param name="paymentDetail">The payment detail.</param>
        public void InsertAccountBalance(CAPaymentEntity caPaymentEntity, CAPaymentDetailEntity paymentDetail)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(caPaymentEntity, paymentDetail);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmount, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(caPaymentEntity, paymentDetail);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmount, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        #endregion
    }

}