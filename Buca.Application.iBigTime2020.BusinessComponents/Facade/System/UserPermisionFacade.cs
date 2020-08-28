using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    /// <summary>
    ///     UserPermisionFacade
    /// </summary>
    public class UserPermisionFacade
    {
        /// <summary>
        ///     The user permision DAO
        /// </summary>
        private static readonly IUserPermisionDao UserPermisionDao = DataAccess.DataAccess.UserPermisionDao;

        /// <summary>
        ///     Gets the user permisions.
        /// </summary>
        /// <returns></returns>
        public IList<UserPermisionEntity> GetUserPermisions()
        {
            return UserPermisionDao.GetUserPermisions();
        }

        /// <summary>
        ///     Gets the user permision bỳeature i by feature identifier.
        /// </summary>
        /// <param name="featureId">The feature identifier.</param>
        /// <returns></returns>
        public IList<UserPermisionEntity> GetUserPermisionByFeatureId(string featureId)
        {
            return UserPermisionDao.GetUserPermisionByFeatureId(featureId);
        }

        /// <summary>
        ///     Gets the user permisions by feature.
        /// </summary>
        /// <param name="Feature">The feature.</param>
        /// <param name="UserProfileID">The user profile identifier.</param>
        /// <returns></returns>
        public IList<UserPermisionEntity> GetUserPermisionsByFeature(string Feature, string UserProfileID)
        {
            var userPermision = UserPermisionDao.GetUserPermisionsByFeature(Feature, UserProfileID);
            return userPermision;
        }
    }
}