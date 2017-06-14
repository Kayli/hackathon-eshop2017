using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PNI.EShop.Core.Audit;
using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditService _auditService;
        private const int _auditCount = 20;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        public IActionResult Index()
        {
            var retrievedTime = DateTime.Now;
            var auditList = _auditService.GetLatestAudits(_auditCount);
            var model = new AuditViewModel()
            {
                AuditList = auditList.Select(a => new AuditEventViewModel() {
                    Id = a.Id,
                    EventName = a.Name ?? "No event name",
                    EventDetails = a.Details ?? "No event details",
                    EventDateTime = a.CreatedTime
                }),
                RetrievedTime = retrievedTime
            };
            return View(model);
        }

        public IActionResult Clear()
        {
            var result = _auditService.ClearAudits();
            return View(result);
        }
    }
}