using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary;
using Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary;
using System.Linq;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessEntities.Business;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.BusinessEntities.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    public class UserFeaturePermisionFacade
    {
        /// <summary>
        /// The user feature permision DAO
        /// </summary>
        private static readonly IUserFeaturePermisionDao UserFeaturePermisionDao = DataAccess.DataAccess.UserFeaturePermisionDao;

        /// <summary>
        /// Deletes the user feature permision.
        /// </summary>
        /// <param name="featureID">The feature identifier.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        public UserFeaturePermisionResponse DeleteUserFeaturePermision(string featureID, string UserProfileID)
        {
            var response = new UserFeaturePermisionResponse { Acknowledge = AcknowledgeType.Success };
            try
            {

                response.Message = UserFeaturePermisionDao.DeleteUserFeaturePermision(featureID, UserProfileID);
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Inserts the user feature permision.
        /// </summary>
        /// <param name="userfeaturePermision">The userfeature permision.</param>
        /// <returns></returns>
        public UserFeaturePermisionResponse InsertUserFeaturePermision(IList<UserFeaturePermisionEntity> userFeaturePermisions)
        {
            var response = new UserFeaturePermisionResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!userFeaturePermisions.Any())
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    //Delete UserFeaturePermision
                    var userFeaturePermision = userFeaturePermisions.FirstOrDefault();
                    if (userFeaturePermision == null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    response.Message =
                        UserFeaturePermisionDao.DeleteUserFeaturePermision(userFeaturePermision.FeatureID,
                            userFeaturePermision.UserProfileID);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    //Insert UserFeaturePermision
                    foreach (var userFeaturePermisionEntity in userFeaturePermisions)
                    {
                        userFeaturePermisionEntity.UserFeaturePermisionID = Guid.NewGuid().ToString();
                        response.Message =
                            UserFeaturePermisionDao.InsertUserFeaturePermision(userFeaturePermisionEntity);
                        if (!string.IsNullOrEmpty(response.Message))
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                    }
                    response.UserFeaturePermisionID = "Done";
                    scope.Complete();
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Gets the feature permision entities by user profile identifier and feature identifier.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFeatureId(
            string userProfileId, string featureId)
        {
            return UserFeaturePermisionDao.GetUserFeaturePermisionEntitiesByUserProfileIdAndFeatureId(userProfileId,
                featureId);
        }

        /// <summary>
        /// Gets the name of the user feature permision entities by user profile identifier and form.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="formName">Name of the form.</param>
        /// <returns></returns>
        public IList<UserFeaturePermisionEntity> GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(
            string userProfileId, string formName)
        {
            return UserFeaturePermisionDao.GetUserFeaturePermisionEntitiesByUserProfileIdAndFormName(userProfileId,
                formName);
        }
    }
}
