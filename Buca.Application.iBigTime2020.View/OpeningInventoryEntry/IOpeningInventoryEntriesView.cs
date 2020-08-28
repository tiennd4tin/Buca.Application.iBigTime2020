﻿/***********************************************************************
 * <copyright file="IOpeningAccountEntriesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Opening;

namespace Buca.Application.iBigTime2020.View.OpeningInventoryEntry
{
    /// <summary>
    /// interface IOpeningAccountEntriesView
    /// </summary>
    public interface IOpeningInventoryEntriesView : IView
    {
        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        IList<OpeningInventoryEntryModel> OpeningInventoryEntries { get; set; }
    }
}
