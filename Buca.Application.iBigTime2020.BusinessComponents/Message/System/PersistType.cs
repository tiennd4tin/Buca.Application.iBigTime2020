/***********************************************************************
 * <copyright file="PersistType.cs" company="BUCA JSC">
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
    public enum PersistType
    {
        /// <summary>
        /// The insert
        /// </summary>
        Insert = 1,

        /// <summary>
        /// The update
        /// </summary>
        Update = 2,

        /// <summary>
        /// The delete
        /// </summary>
        Delete = 3,

        /// <summary>
        /// The scalar
        /// </summary>
        Scalar = 4
    }
}

