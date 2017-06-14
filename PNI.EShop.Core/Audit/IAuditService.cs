using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Audit
{
    public interface IAuditService : IHandlesEvent<ProductCreated>
    {
        IEnumerable<Audit> GetLatestAudits(int count);

        bool ClearAudits();
    }
}
