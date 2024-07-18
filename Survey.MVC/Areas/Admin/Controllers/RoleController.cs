using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.MVC.Areas.Admin.Models;
using Survey.MVC.Areas.Admin.Models.RoleViewModels;

namespace Survey.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(ILogger<RoleController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRoleViewModel role)
        {
            var roleIdentity = new IdentityRole(role.Name);
            var result = await _roleManager.CreateAsync(roleIdentity);
            if (result.Succeeded)
            {
                return View("Index");
            }
            else
            {
                return BadRequest("Failed to create role");
            }
        }
        public IActionResult Update(string id)
        {
            var role = _roleManager.Roles.SingleOrDefault(x=>x.Id == id);
            return View(new UpdateRoleViewModel{Id=role.Id,Name=role.Name,NormalizedName=role.NormalizedName,ConcurrencyStamp=role.ConcurrencyStamp});
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleViewModel updateRole)
        {
            // Because of concurrencystamp first i null that column
            var role = await _roleManager.FindByIdAsync(updateRole.Id);
            role.ConcurrencyStamp = null;
            role.Name = updateRole.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return View("Index");
            }
            else
            {
                return BadRequest("Failed to create role");
            }
        }
    }
}