using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Areas.User.Models
{
    public class UserAnswers
    {
        public int[] SelectedValues { get; set; }
        public string UserId { get; set; }
    }
}