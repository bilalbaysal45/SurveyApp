using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Survey.MVC.Areas.User.Data.Abstract;
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
        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    Root<TEntity> rootTEntity = new Root<TEntity>();
                    var content = JsonSerializer.Serialize(entity);
                    StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(_requestUri, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        rootTEntity = JsonSerializer.Deserialize<Root<TEntity>>(contentResponse);
                        return rootTEntity.Data;
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return null;
            
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

        public async Task<TEntity> GetById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                Root<TEntity> rootTEntity = new Root<TEntity>();
                _requestUri = _requestUri+$"/{id}";
                var response = await httpClient.GetAsync(_requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();
                    rootTEntity = JsonSerializer.Deserialize<Root<TEntity>>(contentResponse);
                    return rootTEntity.Data;
                }
            }
            return null;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    Root<TEntity> rootTEntity = new Root<TEntity>();
                    var content = JsonSerializer.Serialize(entity);
                    StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(_requestUri, stringContent);
                    if (response.IsSuccessStatusCode)
                    {
                        var contentResponse = await response.Content.ReadAsStringAsync();
                        rootTEntity = JsonSerializer.Deserialize<Root<TEntity>>(contentResponse);
                        return rootTEntity.Data;
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            return null;
        }
    }
}