using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Buca.Application.iBigTime2020.Model;

namespace BuCA.Application.iBigTime2020.Report.ReportClass
{
    public class ExportXmlToTreasury : BaseReport
    {
        public ExportXmlToTreasury()
        {
            Model = new Model();
        }

        #region Nhóm xuất khẩu BC gửi kho bạc nhà nước
        /// <summary>
        /// B01/BCTC
        /// </summary>
        public DataSet GetSumReportB01BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB01BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B02/BCTC
        /// </summary>
        public DataSet GetSumReportB02BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB02BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B03a/BCTC
        /// </summary>
        public DataSet GetSumReportB03aBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB03aBCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B03b/BCTC
        /// </summary>
        public DataSet GetSumReportB03bBCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB03bBCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B04/BCTC
        /// </summary>
        public DataSet GetSumReportB04BCTC_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB04BCTC_XmlToTreasury(startDate, fromDate, toDate);
        }

        /// <summary>
        /// B01BSTT
        /// </summary>
        public DataSet GetSumReportB01BSTT_XmlToTreasury(DateTime startDate, DateTime fromDate, DateTime toDate)
        {
            return Model.GetSumReportB01BSTT_XmlToTreasury(startDate, fromDate, toDate);
        }
        #endregion
    }
}
