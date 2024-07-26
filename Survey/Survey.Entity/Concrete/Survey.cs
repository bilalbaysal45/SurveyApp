using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Abstract;

namespace Survey.Entity.Concrete
{
    public class Survey : BaseEntity
    {
        public List<SurveyUser> SurveyUsers { get; set; }
        public List<Question> Questions { get; set; }
    }
}