using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.MVC.Areas.User.Data;
using Survey.MVC.Models;
using Survey.MVC.Areas.Admin.Models;

namespace Survey.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<IdentityUser> _user;

        public UserController(ILogger<UserController> logger,UserManager<IdentityUser> user)
        {
            _logger = logger;
            _user = user;
        }

        public IActionResult Index(string Error)
        {
            ViewBag.Error = Error;
            var users = _user.Users.ToList();
            return View(users);
        }
        public async Task<IActionResult> User(string id)
        {
            var user = await _user.FindByIdAsync(id);
            var survey = new SurveyDAL(RequestUris.GetAllSurveys);
            ViewBag.Surveys = await survey.GetAll();
            return View(user);
        }
        public async Task<IActionResult> AddSurveyToUser(int surveyId,string userId)
        {
            var surveyUser = new SurveyUserDAL(RequestUris.AddSurveyUser);
            var response = await surveyUser.Create(new SurveyUserViewModel{SurveyId = surveyId, UserId=userId,IsDone = false});
            if(response.Error is null)
            {
                return RedirectToAction("Index", new{response.Error});

            }
            else
            {
                return RedirectToAction("Index",new{response.Error});
            }
        }
    }
}