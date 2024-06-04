using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey.Entity.Concrete;

namespace Survey.Data.Concrete.EfCore.Contexts
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //Tablolar
        public DbSet<Entity.Concrete.Survey> Surveys { get;set;}
    }
}