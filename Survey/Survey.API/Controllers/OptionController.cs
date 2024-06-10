using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.OptionDtos;

namespace Survey.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionManager;

        public OptionController(IOptionService optionManager)
        {
            _optionManager = optionManager;
        }
        [HttpGet("/getOptions")]
        public IActionResult GetAll()
        {
            var response = _optionManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/getOption/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _optionManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addOption")]
        public IActionResult Create(AddOptionDto addNote)
        {
            var response = _optionManager.Create(addNote);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updateOption")]
        public IActionResult Update(UpdateOptionDto updateNote)
        {
            var response = _optionManager.Update(updateNote);
            var JsonResponse = JsonSerializer.Serialize(response);
            return Ok(JsonResponse);
        }
    }
}