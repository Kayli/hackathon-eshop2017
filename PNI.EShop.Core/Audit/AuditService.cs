using System;
using System.Collections.Generic;
using System.Text;

namespace PNI.EShop.Core.Audit
{
    public class AuditService : IAuditService
    {
        public AuditService()
        {

        }

        public IEnumerable<string> GetLatestAudits()
        {
            return new string[] { "Audit1", "Audit2", "Audit3" };
        }
    }
}
