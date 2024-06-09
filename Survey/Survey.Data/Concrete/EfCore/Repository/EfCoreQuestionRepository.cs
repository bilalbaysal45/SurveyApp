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
        SurveyDbContext Context{get{return _dbContext as SurveyDbContext;}}
    }
}