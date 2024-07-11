using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Shared.Dtos.AnswerDtos
{
    public class AddAnswerDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }

    }
}