using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Survey.MVC.Areas.User.Data.Abstract;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data
{
    public class QuestionDAL : DataAccessLayer<QuestionViewModel>, IQuestionDAL
    {
        public QuestionDAL(string requestUri) : base(requestUri)
        {
        }
        public async Task<List<QuestionViewModel>> GetQuestionsBySurveyId(string requestUri, int surveyId)
        {
            using (var httpClient = new HttpClient())
            {
                Root<List<QuestionViewModel>> rootQuestions = new Root<List<QuestionViewModel>>();
                requestUri = requestUri+$"/{surveyId}";
                var response = await httpClient.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootQuestions = JsonSerializer.Deserialize<Root<List<QuestionViewModel>>>(contentResponse);
                    return rootQuestions.Data;
                }
            }
            return new List<QuestionViewModel>();
        }
    }
}