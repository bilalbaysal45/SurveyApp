using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survey.Data.Concrete.EfCore.Configs;
using Survey.Entity.Concrete;

namespace Survey.Data.Concrete.EfCore.Contexts
{
    public class SurveyDbContext : IdentityDbContext<User>
    {
        public SurveyDbContext(DbContextOptions options) : base(options)
        {
        }
        //Tablolar
        public DbSet<Entity.Concrete.Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestionOptionConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Answer).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}