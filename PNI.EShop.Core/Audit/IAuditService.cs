using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNI.EShop.Core.Audit
{
    public interface IAuditService
    {
        IEnumerable<string> GetLatestAudits();
    }
}
