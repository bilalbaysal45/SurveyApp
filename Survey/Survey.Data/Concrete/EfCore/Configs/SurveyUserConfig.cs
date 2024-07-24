using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Entity.Concrete;

namespace Survey.Data.Concrete.EfCore.Configs
{
    public class SurveyUserConfig : IEntityTypeConfiguration<SurveyUser>
    {
        public void Configure(EntityTypeBuilder<SurveyUser> builder)
        {
            builder.HasKey(x => new { x.SurveyId, x.UserId });
        }
    }
}