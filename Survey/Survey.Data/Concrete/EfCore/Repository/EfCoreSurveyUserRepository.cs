using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Concrete;
using Survey.Data.Abstract;
using Survey.Data.Concrete.EfCore.Contexts;


namespace Survey.Data.Concrete.EfCore.Repository
{
    public class EfCoreSurveyUserRepository : EfCoreGenericRepository<SurveyUser>, ISurveyUserRepository
    {
        public EfCoreSurveyUserRepository(SurveyDbContext _context) : base(_context)
        {
        }
        SurveyDbContext Context { get { return _dbContext as SurveyDbContext; } }
    }
}