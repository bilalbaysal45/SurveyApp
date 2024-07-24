using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.SurveyUserDtos;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyUserController : ControllerBase
    {
        private readonly ISurveyUserService _surveyUserManager;

        public SurveyUserController(ISurveyUserService surveyUserManager)
        {
            _surveyUserManager = surveyUserManager;
        }
        [HttpPost("/addSurveyUser")]
        public IActionResult Create(AddSurveyUserDto addSurveyUser)
        {
            var response = _surveyUserManager.Create(addSurveyUser);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}