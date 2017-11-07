using Justeat.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Justeat.Repository
{
    public interface IRestaurantService
    {
        /// <summary>
        /// Get all Restaurants by given code
        /// </summary>
        /// <param name="code">the code.</param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        Task<List<Restaurant>> GetRestaurants(string code);

        /// <summary>
        /// Get or set By Given Code and Pagination Info
        /// </summary>
        /// <param name="code">the code.</param>
        /// <param name="pagination">the pagination info.</param>
        /// <returns>List of <see cref="Restaurant"/></returns>
        Task<List<Restaurant>> GetRestaurants(string code, Pagination pagination);
    }
}
