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
    }
}