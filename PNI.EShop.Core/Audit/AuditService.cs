using System;
using System.Collections.Generic;
using System.Text;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IEventStore _eventStore;

        public AuditService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public IEnumerable<string> GetLatestAudits()
        {
            return new string[] { "Audit1", "Audit2", "Audit3" };
        }

        public void Handle(ProductCreated @event)
        {
            //create an audit record
        }
    }
}
