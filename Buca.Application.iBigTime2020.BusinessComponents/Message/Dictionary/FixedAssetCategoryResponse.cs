using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{

    public class FixedAssetCategoryResponse : ResponseBase
    {
        public FixedAssetCategoryResponse() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

       public FixedAssetCategoryEntity FixedAssetCategoryEntity {get;set;}

      public string fixedAssetCategoryId { get; set; }
    }

}