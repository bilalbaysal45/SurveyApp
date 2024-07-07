using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Survey.MVC.Models;

namespace Survey.MVC.Areas.User.Data
{
    public class DataAccessLayer<TEntity> : IDataAccessLayer<TEntity> where TEntity : class
    {
        private string _requestUri { get; set; }
        public DataAccessLayer(string requestUri)
        {
            _requestUri = requestUri;
        }
        public TEntity Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAll()
        {
            Root<List<TEntity>> rootTEntity = new Root<List<TEntity>>();
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(_requestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        string contentResponse = await response.Content.ReadAsStringAsync();
                        rootTEntity = JsonSerializer.Deserialize<Root<List<TEntity>>>(contentResponse);
                        return rootTEntity.Data;
                    }
                }
                catch (System.Exception)
                {
                    return new List<TEntity>();
                }
                
            }
            return new List<TEntity>();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}