using System;
using System.Collections.Generic;
using PNI.EShop.Core.Audit;

namespace PNI.EShop.Infrastructure
{
    public class AuditRepository : IAuditRepository
    {
        public IEnumerable<Audit> GetLatest(int count)
        {

            return new Audit[] {
                new Audit { Id = "1", Name = "EventA", Details = "A", CreatedTime = DateTime.MinValue },
                new Audit { Id = "2", Name = "EventB", Details = "B", CreatedTime = DateTime.MinValue },
                new Audit { Id = "3", Name = "EventC", Details = "C", CreatedTime = DateTime.MinValue }
            };
        }

        public bool DeleteAll()
        {
            
            return true;
        }
    }
}
