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
    public class EfCoreQuestionRepository : EfCoreGenericRepository<Question>, IQuestionRepository
    {
        public EfCoreQuestionRepository(SurveyDbContext _context) : base(_context)
        {
        }
        SurveyDbContext Context { get { return _dbContext as SurveyDbContext; } }
        public List<Question> GetQuestionsBySurveyId(int surveyId)
        {
            // var questions = Context.Questions
            //                         .AsNoTracking()
            //                         .Where(x => x.SurveyId == surveyId)
            //                         .Include(q=>q.QuestionOptions)
            //                         .ThenInclude(qo=>qo.Option)
            //                         .AsSplitQuery()
            //                         .ToList();

            var questions = Context.Questions
                                        .Where(x => x.SurveyId == surveyId)
                                        .Select(q => new Question
                                            {
                                                Id = q.Id,
                                                Name = q.Name,
                                                Description = q.Description,
                                                CreatedDate = q.CreatedDate,
                                                ModifiedDate = q.ModifiedDate,
                                                SurveyId = q.SurveyId,
                                                QuestionOptions = q.QuestionOptions.Select(qo => new QuestionOption
                                                {
                                                    OptionId = qo.OptionId,
                                                    Option = qo.Option
                                                }).ToList()
                                            })
                                        .ToList();
                                        
            return questions;
        }
    }
}