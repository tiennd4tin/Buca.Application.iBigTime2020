using System;
using System.Collections.Generic;
using System.Data;
using Buca.Application.iBigTime2020.BusinessEntities.System;
using Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.System;
using Buca.Application.iBigTime2020.DataHelpers;

namespace Buca.Application.iBigTime2020.DataAccess.SqlServer.System
{
    public class SqlServerLockDateDao : ILockDao
    {
        private static readonly Func<IDataReader, LockEntity> Make = reader =>
           new LockEntity
           {
               Content = reader["Content"].AsString(),
               LockDate = reader["LockDate"].AsString(),
               IsLock= reader["IsLock"].AsBool()
           };


        private object[] Take(LockEntity entity)
        {
            return new object[]
            {
                @"Content", entity.Content,
                @"LockDate", entity.LockDate,
                @"IsLock", entity.IsLock
            };
        }

        public LockEntity GetLock()
        {
            const string procedures = @"uspGet_Lock";
            object[] parms = { };
            return Db.Read(procedures, true, Make, parms);
        }

        public string ExcuteUnLock(LockEntity entity)
        {
            const string sql = @"uspExcute_Lock";
            return Db.Update(sql, true, Take(entity));
        }



        public LockEntity CheckLock(string refId, int refTypeId, DateTime refDate)
        {
            const string procedures = @"uspGet_CheckLock_ByRefDate";
            object[] parms = { "RefID", refId, "RefTypeID", refTypeId, "RefDate", refDate};
            return Db.Read(procedures, true, Make, parms);
        }

        public LockEntity CheckLock(string refId, int refTypeId)
        {
            const string procedures = @"uspGet_CheckLock_ByRefID";
            object[] parms = { "RefID", refId, "RefTypeID", refTypeId };
            return Db.Read(procedures, true, Make, parms);
        }
    }
}
