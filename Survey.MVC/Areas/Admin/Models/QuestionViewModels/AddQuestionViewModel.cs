using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Areas.Admin.Models.QuestionViewModels
{
    public class AddQuestionViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}