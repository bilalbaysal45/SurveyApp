using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Areas.Admin.Models
{
    public class SurveyUserViewModel
    {
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
    }
}