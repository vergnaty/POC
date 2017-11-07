using System;
using System.Collections.Generic;

namespace Justeat.Entities
{
    public class Restaurant
    {
        /// <summary>
        /// Get or Set the Restaurant Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get or set the Rating
        /// </summary>
        public float RatingStars { get; set; }

        /// <summary>
        /// Get or Set the type of Cusine
        /// </summary>
        public List<CuisineType> CuisineTypes { get; set; }
    }

    public class CuisineType
    {
        /// <summary>
        /// Get or set the Cusine Name
        /// </summary>
        public string Name { get; set; }
    }
}
