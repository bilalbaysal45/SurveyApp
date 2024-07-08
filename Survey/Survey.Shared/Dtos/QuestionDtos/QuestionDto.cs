using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos.QuestionOptionDtos;

namespace Survey.Shared.Dtos.QuestionDtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<QuestionOptionDto> QuestionOptions { get; set; }

    }
}