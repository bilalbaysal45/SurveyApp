using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Survey.MVC.Areas.User.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}