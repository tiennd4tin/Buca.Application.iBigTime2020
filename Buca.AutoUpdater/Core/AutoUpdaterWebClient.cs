// ***********************************************************************
// Assembly         : Buca.AutoUpdater
// Author           : thangnd
// Created          : 10-02-2018
//
// Last Modified By : thangnd
// Last Modified On : 10-02-2018
// ***********************************************************************
// <copyright file="AutoUpdaterWebClient.cs" company="by BUCA JSC">
//     Copyright © by Thang Nguyen 2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Net;

namespace Buca.AutoUpdater.Core
{
    /// <summary>
    /// Class AutoUpdaterWebClient.
    /// </summary>
    /// <seealso cref="System.Net.WebClient" />
    public class AutoUpdaterWebClient : WebClient
    {
        /// <summary>
        /// Gets or sets the response URI.
        /// </summary>
        /// <value>The response URI.</value>
        public Uri ResponseUri { get; set; }

        /// <summary>
        /// Returns the <see cref="T:System.Net.WebResponse" /> for the specified <see cref="T:System.Net.WebRequest" /> using the specified <see cref="T:System.IAsyncResult" />.
        /// </summary>
        /// <param name="request">A <see cref="T:System.Net.WebRequest" /> that is used to obtain the response.</param>
        /// <param name="result">An <see cref="T:System.IAsyncResult" /> object obtained from a previous call to <see cref="M:System.Net.WebRequest.BeginGetResponse(System.AsyncCallback,System.Object)" /> .</param>
        /// <returns>A <see cref="T:System.Net.WebResponse" /> containing the response for the specified <see cref="T:System.Net.WebRequest" />.</returns>
        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
        {
            var webResponse = base.GetWebResponse(request, result);
            ResponseUri = webResponse.ResponseUri;
            return webResponse;
        }
    }
}
