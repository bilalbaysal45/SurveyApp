using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Entity.Concrete;

namespace Survey.Data.Concrete.EfCore.Configs
{
    public class AnswerConfig : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(a => a.User)
                   .WithMany(a => a.Answers)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Answers_AspNetUsers");
        }
    }
}