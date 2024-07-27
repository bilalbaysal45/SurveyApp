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
        public List<Entity.Concrete.Survey> SurveyResults()
        {
            var result = Context.Surveys
                                .Select(q => new Entity.Concrete.Survey
                                {
                                    Id = q.Id,
                                    Name = q.Name,
                                    Description = q.Description,
                                    CreatedDate = q.CreatedDate,
                                    ModifiedDate = q.ModifiedDate,
                                    Questions = q.Questions.Select(q=>new Question{
                                        Id=q.Id,
                                        Name=q.Name,
                                        Answers = q.Answers.Select(a=> new Answer{
                                            Id=a.Id,
                                            Name=a.Name,
                                            UserId=a.UserId,
                                            User=a.User,
                                            Option = a.Option,
                                            OptionId=a.OptionId,
                                        }).ToList()
                                    }).ToList()
                                })
                                .ToList();
            return result ?? new List<Entity.Concrete.Survey>();
        }
    }
}