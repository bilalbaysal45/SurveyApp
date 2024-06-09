using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Abstract;

namespace Survey.Entity.Concrete
{
    public class Question : BaseEntity 
    {
        public int SurveyId { get; set; }
    }
}