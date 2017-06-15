using System.Collections.Generic;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Audit
{
    public interface IAuditRepository
    {
        bool Add(Audit item);
        IEnumerable<Audit> GetLatest(int count);
        bool DeleteAll();
    }
}