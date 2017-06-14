using System.Collections.Generic;

namespace PNI.EShop.Core.Audit
{
    public interface IAuditRepository
    {
        IEnumerable<string> GetLatest(int count);

        bool DeleteAll();
    }
}