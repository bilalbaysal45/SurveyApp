using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.MVC.Areas.User.Data;
using Survey.MVC.Areas.User.Models;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private static string userId;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index(string id)
        { 
            ModelState.Clear();
            userId = id;
            var user = await _signInManager.UserManager.FindByIdAsync(id);
            if(ModelState.IsValid){
                return View("Index",user);
            }
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
        public async Task<IActionResult> Survey(int id,int[] selectedValues, string userIdFromJavaScript)
        {
            //anket çekildi
            var surveyDAL = new SurveyDAL(RequestUris.GetSurveyById);
            var survey = await surveyDAL.GetById(id);

            //Sorular çekildi şıklarda eklenecek ve sorularla gelmesini planlıyorum
            var questionDAL = new QuestionDAL(RequestUris.GetQuestionsBySurveyId);
            var questions = await questionDAL.GetQuestionsBySurveyId(RequestUris.GetQuestionsBySurveyId,id);

            var surveyanswers = new SurveyAnswerViewModel();
            surveyanswers.Questions = questions;
            surveyanswers.Answers = new List<AddAnswerViewModel>();
            for (int i = 0; i < questions.Count; i++)
            {
                surveyanswers.Answers.Add(new AddAnswerViewModel{Name = "",Description="",CreatedDate=DateTime.Now,ModifiedDate=DateTime.Now,UserId = userId,OptionId=0,QuestionId=0});                
            }

            return View(surveyanswers);
        }
        [HttpPost]
        public IActionResult UserAnswers(int[] selectedValues, string userIdFromJavaScript)
        {
            string a = userIdFromJavaScript;

            return RedirectToAction("Index", "User",new { area = "User", id = userIdFromJavaScript });
        }
    }
}