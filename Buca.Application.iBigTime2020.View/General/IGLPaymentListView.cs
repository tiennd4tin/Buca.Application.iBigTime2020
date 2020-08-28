using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model.BusinessObjects.General;

namespace Buca.Application.iBigTime2020.View.General
{
    public interface IGLPaymentListView :IView
    {

        string RefId { get; set; }

        int RefType { get; set; }

        DateTime RefDate { get; set; }

        DateTime PostedDate { get; set; }

        string RefNo { get; set; }

        string VoucherTypeId { get; set; }

        int SetupType { get; set; }

        DateTime FromDate { get; set; }

        DateTime ToDate { get; set; }

        string Description { get; set; }

        decimal TotalAmount { get; set; }

        int EditVersion { get; set; }

        IList<GLPaymentListDetailModel> GLPaymentListDetails { get; set; }
    }
}
