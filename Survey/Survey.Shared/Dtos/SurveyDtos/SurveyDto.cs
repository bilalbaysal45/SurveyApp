using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos.QuestionDtos;

namespace Survey.Shared.Dtos.SurveyDtos
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<SurveyUser> SurveyUsers { get; set;}
        public List<QuestionDto> Questions { get; set; }
    }
}