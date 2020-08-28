/***********************************************************************
 * <copyright file="RequestBase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    bangnc@buca.vn
 * Website:
 * Create Date: Wednesday, July 15, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase
{
    public class RequestBase
    {
        /// <summary>
        /// Load options indicated what types are to be returned in the request.
        /// </summary>
        public string[] LoadOptions;

        /// <summary>
        /// Crud action: Create, Read, Update, Delete
        /// </summary>
        public PersistType Action;

        /// <summary>
        /// The store produre
        /// </summary>
        public string StoreProdure;

        /// <summary>
        /// The is convert data
        /// </summary>
        public bool IsConvertData;


        public int UserId;

        public string UserName;

    }
}
