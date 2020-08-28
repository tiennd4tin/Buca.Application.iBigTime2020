using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Business.General;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.General
{
    public class GLVoucherListResponse : ResponseBase
    {
    
        public string RefId { get; set; }

     
        public GLVoucherListEntity GLVoucherListEntity { get; set; }
    }
}
