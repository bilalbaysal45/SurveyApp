using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.MVC.Areas.Admin.Models.SurveyViewModels;
using Survey.MVC.Areas.User.Data;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyController : Controller
    {
        private readonly ILogger<SurveyController> _logger;

        public SurveyController(ILogger<SurveyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddSurveyViewModel survey)
        {
            if(ModelState.IsValid)
            {
                var surveyMain = new SurveyViewModel{Name = survey.Name,Description=survey.Description};
                surveyMain.CreatedDate = DateTime.Now;
                surveyMain.ModifiedDate = DateTime.Now;
                var surveyDAL = new SurveyDAL(RequestUris.AddSurvey);
                var response = await surveyDAL.Create(surveyMain);
                return View("Index");
            }
            return View("Index");
        }
        public async Task<IActionResult> Surveys()
        {
            var surveyDAL = new SurveyDAL(RequestUris.GetAllSurveys);
            var response = await surveyDAL.GetAll();
            return View(response);
        }
        public async Task<IActionResult> Update(int id)
        {
            var surveyDAL = new SurveyDAL(RequestUris.GetSurveyById);
            var survey = await surveyDAL.GetById(id);
            return View(new UpdateSurveyViewModel{Id = survey.Id,Name=survey.Name,Description=survey.Description,CreatedDate=survey.CreatedDate,ModifiedDate=survey.ModifiedDate});
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateSurveyViewModel updateSurvey)
        {
            if (ModelState.IsValid)
            {
                var surveyMain = new SurveyViewModel {Id= updateSurvey.Id, Name = updateSurvey.Name, Description = updateSurvey.Description,CreatedDate= updateSurvey.CreatedDate };
                surveyMain.ModifiedDate = DateTime.Now;
                var surveyDAL = new SurveyDAL(RequestUris.UpdateSurvey);
                var response = await surveyDAL.Update(surveyMain);
                return View("Index");
            }
            return View("Index");
        }
        public async Task<IActionResult> SurveyResults()
        {
            var surveyDAL = new SurveyDAL(RequestUris.SurveyResults);
            var response = await surveyDAL.SurveyResults(RequestUris.SurveyResults);
            return View(response);
        }
    }
}