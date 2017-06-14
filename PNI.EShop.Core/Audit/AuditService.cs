using System;
using System.Collections.Generic;
using System.Text;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;


namespace PNI.EShop.Core.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;
        private readonly IEventStore _eventStore;

        public AuditService(IAuditRepository auditRepository, IEventStore eventStore)
        {
            _auditRepository = auditRepository;
            // TODO subscribe to all events
            _eventStore = eventStore;
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

        public void Handle(ProductCreated @event)
        {
            //create an audit record
        }
    }
}
