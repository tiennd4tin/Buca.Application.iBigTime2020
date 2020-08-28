/***********************************************************************
 * <copyright file="ICustomerViews.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.Dictionary;


namespace Buca.Application.iBigTime2020.View.Dictionary
{

    /// <summary>
    /// ICustomersView interface
    /// </summary>
    public interface ICustomersView:IView
    {

        /// <summary>
        /// Sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        List<CustomerModel> Customers { set; }
    }
}
