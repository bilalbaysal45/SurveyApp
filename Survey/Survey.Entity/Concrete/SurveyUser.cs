using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Entity.Concrete
{
    public class SurveyUser
    {
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsDone{ get; set; }
    }
}