using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Survey.MVC.Areas.Admin.Models;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data
{
    public class SurveyDAL : DataAccessLayer<SurveyViewModel>
    {
        public SurveyDAL(string requestUri) : base(requestUri)
        {}



        /// <summary>
        /// Get Surveys Not Added to a User
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="surveyUser"></param>
        /// <returns></returns>
        public async Task<List<SurveyViewModel>> GetSurveys(string requestUri, string userId)
        {
            using (var httpClient = new HttpClient())
            {
                Root<List<SurveyViewModel>> rootSurveys = new Root<List<SurveyViewModel>>();
                requestUri = requestUri + $"/{userId}";
                var response = await httpClient.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootSurveys = JsonSerializer.Deserialize<Root<List<SurveyViewModel>>>(contentResponse);
                    return rootSurveys.Data;
                }
            }
            return new List<SurveyViewModel>();
        }
    }
}