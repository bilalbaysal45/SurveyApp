using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Areas.User.Models;

namespace Survey.MVC.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SurveyId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<QuestionOptionViewModel> QuestionOptions { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}