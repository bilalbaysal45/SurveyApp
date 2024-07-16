using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.MVC.Models
{
    /// <summary>
    /// Necessary API Urls kept here
    /// </summary>
    public static class RequestUris
    {
        public static string GetAllSurveys { get; set; } = "http://localhost:5077/getSurveys";
        public static string GetSurveyById { get; set; } = "http://localhost:5077/getSurvey"; // id DataAccessLayer da ekleniyor
        public static string GetQuestionsBySurveyId { get; set; } = "http://localhost:5077/getQuestionsBySurveyId";
        public static string AddAnswer { get; set; } = "http://localhost:5077/addAnswer";

    }
}