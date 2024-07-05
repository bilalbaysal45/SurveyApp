using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Survey.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string id)
        {
            var user = await _signInManager.UserManager.FindByIdAsync(id);
            return View(user);
        }
        public IActionResult ChangePassword()
        {
            return RedirectToPage("/Account/Manage/ChangePassword", new { area = "Identity" });
        }
    }
}