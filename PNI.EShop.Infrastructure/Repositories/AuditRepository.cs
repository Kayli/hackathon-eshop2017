using System;
using System.Collections.Generic;
using PNI.EShop.Core.Audit;

namespace PNI.EShop.Infrastructure
{
    public class AuditRepository : IAuditRepository
    {
        public IEnumerable<string> GetLatest(int count)
        {

            return new string[] { "Audit1", "Audit2", "Audit3" };
        }

        public bool DeleteAll()
        {
            
            return true;
        }
    }
}
