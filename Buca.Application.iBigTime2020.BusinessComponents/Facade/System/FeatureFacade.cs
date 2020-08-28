using System.Collections.Generic;
using System.Transactions;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;

namespace Buca.Application.iBigTime2020.BusinessComponents.Facade.Dictionary

{
    /// <summary>
    ///     FeatureFacade
    /// </summary>
    public class FeatureFacade
    {
        /// <summary>
        ///     The feature DAO
        /// </summary>
        private static readonly IFeatureDao FeatureDao = DataAccess.DataAccess.FeatureDao;

        /// <summary>
        ///     Gets the features.
        /// </summary>
        /// <returns></returns>
        public IList<FeatureEntity> GetFeatures()
        {
            return FeatureDao.GetFeatures();
        }

        /// <summary>
        ///     Gets the feature entities is parent.
        /// </summary>
        /// <returns></returns>
        public IList<FeatureEntity> GetFeatureEntitiesIsParent()
        {
            return FeatureDao.GetFeatureEntitiesIsParent();
        }

        /// <summary>
        /// Inserts the features.
        /// </summary>
        /// <param name="features">The features.</param>
        /// <returns></returns>
        public string InsertFeatures(IList<FeatureEntity> features)
        {
            var message = "";
            using (var scope = new TransactionScope())
            {
                foreach (var featureEntity in features)
                {
                    message = FeatureDao.InsertFeature(featureEntity);
                    if (!string.IsNullOrEmpty(message))
                    {
                        scope.Dispose();
                        return "";
                    }
                }
                scope.Complete();
            }
            return "";
        }
    }
}