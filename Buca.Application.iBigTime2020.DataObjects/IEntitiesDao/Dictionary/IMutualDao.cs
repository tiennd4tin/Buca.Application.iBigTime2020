/***********************************************************************
 * <copyright file="IBuildingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;


namespace Buca.Application.iBigTime2020.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IBuildingDao
    /// </summary>
    public interface IMutualDao
    {

        MutualEntity GetMutual(int mutualId);
        List<MutualEntity> GetMutuals();
        List<MutualEntity> GetMutualsByMutualCode(string mutualCode);
        List<MutualEntity> GetMutualsByActive(bool isActive);
        int InsertMutual(MutualEntity mutual);
        string UpdateMutual(MutualEntity mutual);
        string DeleteBuilding(MutualEntity mutual);

        List<MutualEntity> GetMutualsForEstimate(bool isActive);
    }
}
