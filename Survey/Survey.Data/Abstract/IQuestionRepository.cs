using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;

namespace Survey.Data.Abstract
{
    public interface IQuestionRepository :IGenericRepository<Question>
    {
        List<Question> GetQuestionsBySurveyId(int surveyId);
    }
}