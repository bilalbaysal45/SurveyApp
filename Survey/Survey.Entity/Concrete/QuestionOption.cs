using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Entity.Concrete
{
    public class QuestionOption
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int OptionId { get; set; }
        public Option Option { get; set; }

    }
}