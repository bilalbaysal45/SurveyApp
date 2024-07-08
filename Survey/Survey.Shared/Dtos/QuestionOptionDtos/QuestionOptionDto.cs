using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos.OptionDtos;
using Survey.Shared.Dtos.QuestionDtos;

namespace Survey.Shared.Dtos.QuestionOptionDtos
{
    public class QuestionOptionDto
    {
        public int QuestionId { get; set; }
        public QuestionDto Question { get; set; }
        public int OptionId { get; set; }
        public OptionDto Option { get; set; }

    }
}