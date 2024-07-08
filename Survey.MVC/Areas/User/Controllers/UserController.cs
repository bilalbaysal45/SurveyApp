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
        public async Task<IActionResult> Surveys()
        {
            var surveyDAL = new SurveyDAL(RequestUris.GetAllSurveys);
            var surveys = await surveyDAL.GetAll();
            return View(surveys);
        }
        public async Task<IActionResult> Survey(int id)
        {
            //anket çekildi
            var surveyDAL = new SurveyDAL(RequestUris.GetSurveyById);
            var survey = await surveyDAL.GetById(id);

            //Sorular çekildi şıklarda eklenecek ve sorularla gelmesini planlıyorum
            var questionDAL = new QuestionDAL(RequestUris.GetQuestionsBySurveyId);
            var questions = await questionDAL.GetQuestionsBySurveyId(RequestUris.GetQuestionsBySurveyId,id);

            //Anket çek, o anketin sorularını ve şıklarını çek
            return View(survey);
        }
    }
}