using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.IEntityConvert;

namespace Buca.Application.iBigTime2020.DataAccess.EntityConvertDB.ConvertDB
{
    public class PurchasePurposeEntityDao : IEntityPurchasePurposeDao
    {
       
       public  List<PurchasePurposeEntity> GetPurchasePurpose(string connectionString)
        {  
            List<PurchasePurposeEntity> listPurchasePurpose = new List<PurchasePurposeEntity>();
            using (var context = new MISAEntity(connectionString))
            {
               
                var categories = context.PurchasePurposes.ToList();
                foreach (var result in categories)
                {
                    var purchasePurpose = new PurchasePurposeEntity();
                    purchasePurpose.PurchasePurposeId = result.PurchasePurposeID.ToString();
                    purchasePurpose.PurchasePurposeCode = result.PurchasePurposeCode;
                    purchasePurpose.PurchasePurposeName = result.PurchasePurposeName;
                    purchasePurpose.Description = result.Description;
                    purchasePurpose.IsSystem = result.IsSystem;
                    purchasePurpose.IsActive = result.Inactive == true?false:true;


                    listPurchasePurpose.Add(purchasePurpose);

                }

               
            }

            return listPurchasePurpose;
        }

      
    }
}
