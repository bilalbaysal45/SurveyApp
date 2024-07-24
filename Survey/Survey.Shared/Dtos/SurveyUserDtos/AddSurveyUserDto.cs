using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Shared.Dtos.SurveyUserDtos
{
    public class AddSurveyUserDto
    {
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; } = false;
    }
}