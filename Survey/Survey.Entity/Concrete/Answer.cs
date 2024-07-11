using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Entity.Abstract;


namespace Survey.Entity.Concrete
{
    public class Answer : BaseEntity
    {
        public string UserId { get; set; }
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public User User { get; set; }
        public Option Option { get; set; }
        public Question Question { get; set; }
    }
}