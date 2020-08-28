// ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 09-29-2018
//
// Last Modified By : thangnd
// Last Modified On : 09-29-2018
// ***********************************************************************
// <copyright file="ParseUpdateInfoEventArgs.cs" company="by adguard">
//     Copyright © by adguard 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Buca.AutoUpdater.Core
{
    public class ParseUpdateInfoEventArgs : EventArgs
    {
        /// <summary>
        /// Remote data received from the AppCast file.
        /// </summary>
        /// <value>The remote data.</value>
        public string RemoteData { get; }

        /// <summary>
        /// Set this object with values received from the AppCast file.
        /// </summary>
        /// <value>The update information.</value>
        public UpdateInfoEventArgs UpdateInfo { get; set; }

        /// <summary>
        /// An object containing the AppCast file received from server.
        /// </summary>
        /// <param name="remoteData">A string containing remote data received from the AppCast file.</param>
        public ParseUpdateInfoEventArgs(string remoteData)
        {
            RemoteData = remoteData;
        }
    }
}
