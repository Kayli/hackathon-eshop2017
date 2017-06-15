using System;
using System.Collections.Generic;
using PNI.EShop.Core.Order.Events;
using PNI.EShop.Core.Services;

namespace PNI.EShop.Core.Audit
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;
        private readonly IEventStore _eventStore;

        public AuditService(IAuditRepository auditRepository, IEventStore eventStore)
        {
            _auditRepository = auditRepository;
            _eventStore = eventStore;
        }

        public IEnumerable<Audit> GetLatestAudits(int count)
        {
            return _auditRepository.GetLatest(count);
        }

        public bool ClearAudits()
        {
            var clearResult = _auditRepository.DeleteAll();
            if (clearResult) {
                _eventStore.Publish(new AuditCleared() {
                    EventPublished = DateTimeOffset.Now
                });
            }
            return clearResult;
        }

        public void Handle(ProductCreated @event)
        {
            _auditRepository.Add(new Audit() {
                Id = @event.EventId.ToString(),
                Name = @event.GetType().ToString(),
                Details = @event.Name,
                CreatedTime = @event.EventPublished.UtcDateTime
            });
        }


        public void Handle(AuditCleared @event)
        {
            _auditRepository.Add(new Audit() {
                Id = @event.EventId.ToString(),
                Name = @event.GetType().ToString(),
                CreatedTime = @event.EventPublished.UtcDateTime
            });
        }

        public void Handle(OrderCreated @event)
        {
            _auditRepository.Add(new Audit()
            {
                Id = @event.EventId.ToString(),
                Name = @event.GetType().ToString(),
                Details = @event.ProductName + " - " + @event.Price,
                CreatedTime = @event.EventPublished.UtcDateTime
            });
        }
    }
}
