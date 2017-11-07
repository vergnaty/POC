using Justeat.Repository;
using System;
using Justeat.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using Justeat.Data.ApiResponses;

namespace Justeat.DataService
{
    /// <summary>
    /// This class rappresent the Restaurant data service 
    /// Using an external API to retrive data. 
    /// </summary>
    public class ApiRestaurantService : IRestaurantService
    {
        #region private variables 

        string endpoint = "";
        Dictionary<string, string> headers;
        HttpClient client;

        #endregion

        #region constructure

        /// <summary>
        /// Create new instance of <see cref="ApiRestaurantService"/>
        /// </summary>
        /// <param name="url">the base url.</param>
        /// <param name="headers">the headers</param>
        public ApiRestaurantService(string url, Dictionary<string, string> headers)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("cannot be null or empty", nameof(url));

            this.headers = headers ?? throw new ArgumentNullException(nameof(headers));
            this.endpoint = url;

            this.SetHttpClient();
        }
        #endregion

        #region IRestaurantService Implementations

        public async Task<List<Restaurant>> GetRestaurants(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentException("Cannot be null or Empty", nameof(code));

            string queryString = $"?q={code}";

            var response = await this.client.GetAsync(queryString);
            return await DeserializeResponse(response);
        }

        public async Task<List<Restaurant>> GetRestaurants(string code, Pagination pagination)
        {
            int skip = pagination.Page > 1 ? (pagination.Page - 1) * pagination.ItemsPerPage : 0;
            var restaurants = await this.GetRestaurants(code);

            pagination.TotalResult = restaurants.Count();

            return restaurants.Skip(skip)
                              .Take(pagination.ItemsPerPage)
                              .ToList();
        }

        #endregion

        #region private methods
        /// <summary>
        /// Set Http Client using the base endpoint and Headers
        /// </summary>
        private void SetHttpClient()
        {
            this.client = new HttpClient()
            {
                BaseAddress = new Uri(this.endpoint)
            };

            foreach (var header in this.headers)
            {
                this.client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        /// <summary>
        /// Deserialize Restaurant API Response
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/></param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        private async Task<List<Restaurant>> DeserializeResponse(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();

            RestaurantResponse currentResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<RestaurantResponse>(json);
            return currentResponse.Restaurants;
        }
        #endregion
    }
}
