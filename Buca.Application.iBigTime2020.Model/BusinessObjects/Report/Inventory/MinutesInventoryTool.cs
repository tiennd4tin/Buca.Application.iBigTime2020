using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buca.Application.iBigTime2020.Model.BusinessObjects.Report.Inventory
{
    /// <summary>
    /// Class Master.
    /// </summary>
    public class MinutesInventoryTool
    {
        public int refId { get; set; }
        public IList<MinutesInventoryToolModel> MinutesInventoryTools { get; set; }
        public IList<Minutes> listMinutes { get; set; }
    }

    /// <summary>
    /// Class Minutes.
    /// </summary>
    public class Minutes
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Delegate { get; set; }
        public string Role { get; set; }
    }
}
