
using Buca.Application.iBigTime2020.BusinessEntities.Dictionary;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Dictionary
{
    public class BudgetChapterResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the account category.
        /// </summary>
        /// <value>The account category.</value>
        public BudgetChapterEntity BudgetChapterEntity { get; set; }

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public string BudgetChapterId { get; set; }
    }
}
