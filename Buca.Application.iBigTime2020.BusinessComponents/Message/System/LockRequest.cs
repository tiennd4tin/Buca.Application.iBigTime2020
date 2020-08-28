using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.BusinessComponents.Message;
using System;
using Buca.Application.iBigTime2020.BusinessComponents.Messages.MessageBase;

namespace Buca.Application.iBigTime2020.BusinessComponents.Messages.Dictionary
{
    public class LockRequest : RequestBase
    {
        public LockEntity Lock;

        public string RefId;

        public int RefTypeId;

        public DateTime RefDate;


    }
}
