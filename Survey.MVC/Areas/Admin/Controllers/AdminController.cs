using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Survey.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string id)
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Surveys()
        {
            return  View();
        }
        public IActionResult Questions()
        {
            return View();
        }
    }
}