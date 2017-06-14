using System;
using System.Collections.Generic;
using System.Text;


namespace PNI.EShop.Core.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;

        public AuditService(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
            // TODO subscribe to all events
        }

        public IEnumerable<Audit> GetLatestAudits(int count)
        {
            return _auditRepository.GetLatest(count);
        }

        public bool ClearAudits()
        {
            // TODO publish delete event
            return _auditRepository.DeleteAll();
        }
    }
}
