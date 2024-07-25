using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey.Data.Abstract;
using Survey.Data.Concrete.EfCore.Contexts;
using Survey.Entity.Concrete;

namespace Survey.Data.Concrete.EfCore.Repository
{
    public class EfCoreSurveyRepository : EfCoreGenericRepository<Entity.Concrete.Survey>, ISurveyRepository
    {
        public EfCoreSurveyRepository(SurveyDbContext _context) : base(_context)
        {
        }
        SurveyDbContext Context { get{ return _dbContext as SurveyDbContext; } }
        public List<Entity.Concrete.Survey> GetSurveys(string userId)
        {
            List<int> excludedSurveyIds = new List<int>();
            var surveyUsers = Context.SurveyUsers.Where(x => x.UserId == userId).ToList();
            foreach (var item in surveyUsers)
            {
            excludedSurveyIds.Add(item.SurveyId);
            }
            var result = Context.Surveys
                                    .Where(s => !excludedSurveyIds.Contains(s.Id))
                                    .ToList();
            return result;
        }
    }
}