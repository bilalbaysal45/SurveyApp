using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyManager;

        public SurveyController(ISurveyService surveyManager)
        {
            _surveyManager = surveyManager;
        }
        [HttpGet("/getNotes")]
        public IActionResult GetAll()
        {
            var response = _surveyManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getNote/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _surveyManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addNote")]
        public IActionResult Create(AddSurveyDto addNote)
        {
            var response = _surveyManager.Create(addNote);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateNote")]
        public IActionResult Update(UpdateSurveyDto updateNote)
        {
            var response = _surveyManager.Update(updateNote);
            var JsonResponse = JsonSerializer.Serialize(response);
            return Ok(JsonResponse);
        }
    }
}