using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.Shared.Dtos.SurveyUserDtos
{
    public class SurveyUserDto
    {
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public SurveyDto Survey { get; set; }
    }
}