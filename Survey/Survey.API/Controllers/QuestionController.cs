using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.QuestionDtos;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionManager;

        public QuestionController(IQuestionService questionManager){
            _questionManager = questionManager;
        }
        [HttpGet("/getQuestions")]
        public IActionResult GetAll()
        {
            var response = _questionManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getQuestion/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _questionManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addQuestion")]
        public IActionResult Create(AddQuestionDto addNote)
        {
            var response = _questionManager.Create(addNote);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateQuestion")]
        public IActionResult Update(UpdateQuestionDto updateNote)
        {
            var response = _questionManager.Update(updateNote);
            var JsonResponse = JsonSerializer.Serialize(response);
            return Ok(JsonResponse);
        }
        [HttpGet("/getQuestionsBySurveyId/{id}")]
        public IActionResult GetQuestionsBySurveyId(int id)
        {
            var response = _questionManager.GetQuestionsBySurveyId(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}