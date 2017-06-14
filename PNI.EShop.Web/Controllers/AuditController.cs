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
            var auditList = _auditService.GetLatestAudits(_auditCount);
            return View(new AuditViewModel() { AuditList = auditList });
        }

        public IActionResult Clear()
        {
            var result = _auditService.ClearAudits();
            return View(result);
        }
    }
}