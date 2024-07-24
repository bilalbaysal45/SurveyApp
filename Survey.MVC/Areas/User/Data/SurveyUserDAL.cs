using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Areas.Admin.Models;


namespace Survey.MVC.Areas.User.Data
{
    public class SurveyUserDAL : DataAccessLayer<SurveyUserViewModel>
    {
        public SurveyUserDAL(string requestUri) : base(requestUri)
        {
        }
    }
}