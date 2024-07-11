using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.AnswerDtos;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerManager;

        public AnswerController(IAnswerService answerManager)
        {
            _answerManager = answerManager;
        }
        [HttpGet("/getAnswers")]
        public IActionResult GetAll()
        {
            var response = _answerManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getAnswer/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _answerManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addAnswer")]
        public IActionResult Create(AddAnswerDto addAnswer)
        {
            var response = _answerManager.Create(addAnswer);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateAnswer")]
        public IActionResult Update(UpdateAnswerDto updateAnswerDto)
        {
            var response = _answerManager.Update(updateAnswerDto);
            var JsonResponse = JsonSerializer.Serialize(response);
            return Ok(JsonResponse);
        }
    }
}