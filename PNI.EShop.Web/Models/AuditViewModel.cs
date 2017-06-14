using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PNI.EShop.Web.Models
{
    public class AuditViewModel
    {
        public IEnumerable<AuditEventViewModel> AuditList;
        public DateTime RetrievedTime;
    }

    public class AuditEventViewModel
    {
        public string Id;
        public string EventName;
        public string EventDetails;
        public DateTime EventDateTime;
    }
}
