using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Models
{
    public class QuestionOptionViewModel
    {
        public int QuestionId { get; set; }
        public QuestionViewModel Question { get; set; }
        public int OptionId { get; set; }
        public OptionViewModel Option { get; set; }
    }
}