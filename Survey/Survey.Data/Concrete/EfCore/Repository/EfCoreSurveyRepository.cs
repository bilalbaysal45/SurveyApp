using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey.Data.Abstract;
using Survey.Data.Concrete.EfCore.Contexts;

namespace Survey.Data.Concrete.EfCore.Repository
{
    public class EfCoreSurveyRepository : EfCoreGenericRepository<Entity.Concrete.Survey>, ISurveyRepository
    {
        public EfCoreSurveyRepository(SurveyDbContext _context) : base(_context)
        {
        }
        SurveyDbContext Context { get{ return _dbContext as SurveyDbContext; } }
    }
}