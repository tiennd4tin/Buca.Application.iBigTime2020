/***********************************************************************
 * <copyright file="OpeningCommitmentFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Friday, December 8, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * DateFriday, December 8, 2017Author SonTV  Description 
 * 
 * ************************************************************************/

using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Opening;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Opening
{
    public class OpeningCommitmentFacade
    {
        private static readonly IOpeningCommitmentDao OpeningCommitmentDao = DataAccess.DataAccess.OpeningCommitmentDao;
        private static readonly IOpeningCommitmentDetailDao OpeningCommitmentDetailDao = DataAccess.DataAccess.OpeningCommitmentDetailDao;

        /// <summary>
        /// Gets the bu commitment requestby reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        public OpeningCommitmentEntity GetOpeningCommitmentbyRefId(string refId)
        {
            return OpeningCommitmentDao.GetOpeningCommitmentbyRefId(refId);
        }
        /// <summary>
        /// Gets the bu plan receipt voucher by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="isIncludedOpeningCommitmentDetail">if set to <c>true</c> [is included bu commitment request detail].</param>
        /// <returns>OpeningCommitmentEntity.</returns>
        public OpeningCommitmentEntity GetOpeningCommitmentVoucherByRefId(string refId, bool isIncludedOpeningCommitmentDetail)
        {
            var openingCommitment = OpeningCommitmentDao.GetOpeningCommitmentbyRefId(refId);
            if (isIncludedOpeningCommitmentDetail && openingCommitment != null)
            {
                openingCommitment.OpeningCommitmentDetails = OpeningCommitmentDetailDao.GetOpeningCommitmentDetailbyRefId(openingCommitment.RefId);
            }
            return openingCommitment;
        }


        /// <summary>
        /// Gets the bu commitment request.
        /// </summary>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        public List<OpeningCommitmentEntity> GetOpeningCommitment()
        {
            return OpeningCommitmentDao.GetOpeningCommitment();
        }
        /// <summary>
        /// Gets the bu commitment requests by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns>List&lt;OpeningCommitmentEntity&gt;.</returns>
        public List<OpeningCommitmentEntity> GetOpeningCommitmentsByRefTypeId(int refTypeId)
        {
            return OpeningCommitmentDao.GetOpeningCommitmentsByRefTypeId(refTypeId);
        }
        /// <summary>
        /// Inserts the bu commitment request.
        /// </summary>
        /// <param name="openingCommitment">The b u commitment request.</param>
        /// <returns>OpeningCommitmentResponse.</returns>
        public OpeningCommitmentResponse InsertOpeningCommitment(OpeningCommitmentEntity openingCommitment)
        {
            var openingCommitmentResponse = new OpeningCommitmentResponse { Acknowledge = AcknowledgeType.Success };


            if (openingCommitment != null && !openingCommitment.Validate())
            {
                foreach (var error in openingCommitment.ValidationErrors)
                    openingCommitmentResponse.Message += error + Environment.NewLine;
                openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                return openingCommitmentResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (openingCommitment != null)
                {
                    var validOpeningCommitment = OpeningCommitmentDao.GetOpeningCommitmentbyRefNo(openingCommitment.RefNo);
                    if (validOpeningCommitment != null)
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        openingCommitmentResponse.Message = "Số cam kết chi " + openingCommitment.RefNo + " đã tồn tại !";
                        return openingCommitmentResponse;
                    }

                    if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingCommitmentResponse;
                    }
                   
                    openingCommitment.RefId = Guid.NewGuid().ToString();
                    openingCommitmentResponse.Message = OpeningCommitmentDao.InsertOpeningCommitment(openingCommitment);

                    if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingCommitmentResponse;
                    }

                    foreach (var openingCommitmentDetail in openingCommitment.OpeningCommitmentDetails)
                    {
                        openingCommitmentDetail.RefId = openingCommitment.RefId;
                        openingCommitmentDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!openingCommitmentDetail.Validate())
                        {
                            foreach (var error in openingCommitmentDetail.ValidationErrors)
                                openingCommitmentResponse.Message += error + Environment.NewLine;
                            openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingCommitmentResponse;
                        }
                        openingCommitmentResponse.Message =
                            OpeningCommitmentDetailDao.InsertOpeningCommitmentDetail(openingCommitmentDetail);
                        if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                        {
                            openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingCommitmentResponse;
                        }
                    }

                    if (openingCommitmentResponse.Message != null)
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingCommitmentResponse;
                    }
                    openingCommitmentResponse.RefId = openingCommitment.RefId;
                    scope.Complete();
                }

                return openingCommitmentResponse;
            }
        }
        /// <summary>
        /// Updates the bu commitment request.
        /// </summary>
        /// <param name="openingCommitment">The b u commitment request.</param>
        /// <returns>OpeningCommitmentResponse.</returns>
        public OpeningCommitmentResponse UpdateOpeningCommitment(OpeningCommitmentEntity openingCommitment)
        {
            var openingCommitmentResponse = new OpeningCommitmentResponse { Acknowledge = AcknowledgeType.Success };


            if (openingCommitment != null && !openingCommitment.Validate())
            {
                foreach (var error in openingCommitment.ValidationErrors)
                    openingCommitmentResponse.Message += error + Environment.NewLine;
                openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                return openingCommitmentResponse;
            }

            using (var scope = new TransactionScope())
            {
                if (openingCommitment != null)
                {
                    var validOpeningCommitment = OpeningCommitmentDao.GetOpeningCommitmentbyRefNo(openingCommitment.RefNo);
                    if (validOpeningCommitment != null && validOpeningCommitment.RefId != openingCommitment.RefId)
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        openingCommitmentResponse.Message = "Số cam kết chi " + openingCommitment.RefNo + " đã tồn tại !";
                        return openingCommitmentResponse;
                    }

                    openingCommitmentResponse.Message = OpeningCommitmentDao.UpdateOpeningCommitment(openingCommitment);

                    if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingCommitmentResponse;
                    }
                    openingCommitmentResponse.Message = OpeningCommitmentDetailDao.DeleteOpeningCommitmentDetail(openingCommitment.RefId);

                    if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        return openingCommitmentResponse;
                    }

                    foreach (var openingCommitmentDetail in openingCommitment.OpeningCommitmentDetails)
                    {
                        openingCommitmentDetail.RefId = openingCommitment.RefId;
                        openingCommitmentDetail.RefDetailId = Guid.NewGuid().ToString();
                        if (!openingCommitmentDetail.Validate())
                        {
                            foreach (var error in openingCommitmentDetail.ValidationErrors)
                                openingCommitmentResponse.Message += error + Environment.NewLine;
                            openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingCommitmentResponse;
                        }
                        openingCommitmentResponse.Message =
                            OpeningCommitmentDetailDao.InsertOpeningCommitmentDetail(openingCommitmentDetail);
                        if (!string.IsNullOrEmpty(openingCommitmentResponse.Message))
                        {
                            openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                            return openingCommitmentResponse;
                        }
                    }

                    if (openingCommitmentResponse.Message != null)
                    {
                        openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return openingCommitmentResponse;
                    }
                    openingCommitmentResponse.RefId = openingCommitment.RefId;
                    scope.Complete();
                }

                return openingCommitmentResponse;
            }
        }
        /// <summary>
        /// Deletes the bu commitment request.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>OpeningCommitmentResponse.</returns>
        public OpeningCommitmentResponse DeleteOpeningCommitment(string refId)
        {
            var openingCommitmentResponse = new OpeningCommitmentResponse { Acknowledge = AcknowledgeType.Success };
            using (var scope = new TransactionScope())
            {
                var openingCommitmentForDelete = OpeningCommitmentDao.GetOpeningCommitmentbyRefId(refId);


                openingCommitmentResponse.Message = OpeningCommitmentDao.DeleteOpeningCommitment(openingCommitmentForDelete);
                if (openingCommitmentResponse.Message != null)
                {
                    openingCommitmentResponse.Acknowledge = AcknowledgeType.Failure;
                    scope.Dispose();
                    return openingCommitmentResponse;
                }
                scope.Complete();
            }

            return openingCommitmentResponse;
        }
    }
}
