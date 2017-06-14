using System.Collections.Generic;

namespace PNI.EShop.Core.Audit
{
    public interface IAuditRepository
    {
        IEnumerable<Audit> GetLatest(int count);

        bool DeleteAll();
    }
}