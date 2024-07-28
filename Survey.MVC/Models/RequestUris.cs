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
        public static string GetSurveysByUserId { get; set; } = "http://localhost:5077/getSurveysByUserId";
        public static string GetSurveyById { get; set; } = "http://localhost:5077/getSurvey"; // id DataAccessLayer da ekleniyor
        public static string AddSurvey { get; set; } = "http://localhost:5077/addSurvey";
        public static string UpdateSurvey { get; set; } = "http://localhost:5077/updateSurvey";
        public static string SurveyResults { get; set; } = "http://localhost:5077/getSurveyResults";
        public static string AddQuestion{ get; set; } = "http://localhost:5077/addQuestion";
        public static string GetQuestionById { get; set;} = "http://localhost:5077/getQuestion"; // id DataAccessLayer da ekleniyor
        public static string UpdateQuestion { get; set; } = "http://localhost:5077/updateQuestion";
        public static string GetQuestionsBySurveyId { get; set; } = "http://localhost:5077/getQuestionsBySurveyId";
        public static string AddAnswer { get; set; } = "http://localhost:5077/addAnswer";
        public static string AddSurveyUser { get; set; } = "http://localhost:5077/addSurveyUser";
        public static string UpdateSurveyUser { get; set; } = "http://localhost:5077/updateSurveyUser";


    }
}