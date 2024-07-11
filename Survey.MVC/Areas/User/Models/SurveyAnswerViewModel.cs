using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Models
{
    public class SurveyAnswerViewModel
    {
        public List<AddAnswerViewModel> Answers { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}