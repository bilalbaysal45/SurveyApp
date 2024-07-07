using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data
{
    public class SurveyDAL : DataAccessLayer<SurveyViewModel>
    {
        public SurveyDAL(string requestUri) : base(requestUri)
        {}
    }
}