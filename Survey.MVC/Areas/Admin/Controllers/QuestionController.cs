using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.MVC.Areas.Admin.Models.QuestionViewModels;
using Survey.MVC.Areas.User.Data;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var surveys = new SurveyDAL(RequestUris.GetAllSurveys);
            ViewBag.Surveys = await surveys.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddQuestionViewModel question)
        {
            if (ModelState.IsValid)
            {
                var questionMain = new QuestionViewModel { Name = question.Name, Description = question.Description, SurveyId = question.SurveyId };
                questionMain.CreatedDate = DateTime.Now;
                questionMain.ModifiedDate = DateTime.Now;
                var questionDAL = new QuestionDAL(RequestUris.AddQuestion);
                var response = await questionDAL.Create(questionMain);
                return View("Index");
            }
            return View("Index");
        }
        

    }
}