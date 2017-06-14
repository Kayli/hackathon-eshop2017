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
        private IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }

        public IActionResult Index()
        {
            var auditList = _auditService.GetLatestAudits();
            return View(new AuditViewModel() { AuditList = auditList });
        }
    }
}