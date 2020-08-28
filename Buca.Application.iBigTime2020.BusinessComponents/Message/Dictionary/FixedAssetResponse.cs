using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class FixedAssetResponse : ResponseBase
    {
        public FixedAssetCategoryEntity FixedAssetCategoryEntity { get; set; }
        public  string FixedAssetId { get; set; }
    }
}
