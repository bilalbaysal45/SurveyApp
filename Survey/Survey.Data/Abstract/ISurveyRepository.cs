using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;

namespace Survey.Data.Abstract
{
    public interface ISurveyRepository : IGenericRepository<Entity.Concrete.Survey>
    {
        List<Entity.Concrete.Survey> GetSurveys(string UserId);
        List<Entity.Concrete.Survey> SurveyResults();
    }
}