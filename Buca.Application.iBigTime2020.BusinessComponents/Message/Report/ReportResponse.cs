using Buca.Application.iBigTime2020.BusinessEntities.Report;

namespace Buca.Application.iBigTime2020.BusinessComponents.Message.Report
{
    public class ReportResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the cash.
        /// </summary>
        /// <value>The cash.</value>
        public ReportListEntity Report { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public string RefId { get; set; }
    }
}
