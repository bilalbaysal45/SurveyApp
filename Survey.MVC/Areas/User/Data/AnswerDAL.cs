using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Areas.User.Data.Abstract;
using Survey.MVC.Areas.User.Models;

namespace Survey.MVC.Areas.User.Data
{
    public class AnswerDAL : DataAccessLayer<AddAnswerViewModel>, IAnswerDAL
    {
        public AnswerDAL(string requestUri) : base(requestUri)
        {
        }
    }
}