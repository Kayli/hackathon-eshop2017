using System.Collections.Generic;
using System.Collections.Concurrent;
using PNI.EShop.Core.Audit;
using System.Linq;

namespace PNI.EShop.Infrastructure
{
    public class AuditRepository : IAuditRepository
    {
        private ConcurrentBag<Audit> _dbSet;

        public AuditRepository()
        {
            _dbSet = new ConcurrentBag<Audit>();
        }

        public bool Add(Audit item)
        {
            _dbSet.Add(item);
            return true;
        }

        public IEnumerable<Audit> GetLatest(int count)
        {
            var list = _dbSet.ToList();
            var auditList = list.OrderByDescending(a => a.CreatedTime).Take(count);
            return auditList.ToArray();
            //return new Audit[] {
            //    new Audit { Id = "1", Name = "EventA", Details = "A", CreatedTime = DateTime.MinValue },
            //    new Audit { Id = "2", Name = "EventB", Details = "B", CreatedTime = DateTime.MinValue },
            //    new Audit { Id = "3", Name = "EventC", Details = "C", CreatedTime = DateTime.MinValue }
            //};
        }

        public bool DeleteAll()
        {
            _dbSet = new ConcurrentBag<Audit>();
            return !_dbSet.Any();
        }
    }
}
