using Buca.Application.iBigTime2020.BusinessComponents.Message;
using Buca.Application.iBigTime2020.BusinessEntities.Business.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents
{   
    public class OpeningInventoryEntryResponse : ResponseBase
    {
        public OpeningInventoryEntryEntity OpeningInventoryEntry { get; set; }

        public string RefId { get; set; }
    }
}
