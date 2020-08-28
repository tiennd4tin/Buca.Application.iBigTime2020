using System;
using System.Collections.Generic;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.View.General
{
    public interface IGLVoucherListView :IView
    {

        string RefId { get; set; }

        int RefType { get; set; }

        DateTime RefDate { get; set; }

        string RefNo { get; set; }

        string VoucherTypeId { get; set; }

        int SetupType { get; set; }

        DateTime FromDate { get; set; }

        DateTime ToDate { get; set; }

        string Description { get; set; }

        decimal TotalAmount { get; set; }

        int EditVersion { get; set; }

        IList<GLVoucherListDetailModel> GlVoucherListDetails { get; set; }
    }
}
