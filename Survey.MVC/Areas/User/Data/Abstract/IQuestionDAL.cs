using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data.Abstract
{
    public interface IQuestionDAL
    {
        Task<List<QuestionViewModel>> GetQuestionsBySurveyId(string requestUri, int surveyId);
    }
}