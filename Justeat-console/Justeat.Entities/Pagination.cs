using System;
using System.Collections.Generic;
using System.Text;

namespace Justeat.Entities
{
    public class Pagination
    {
        /// <summary>
        /// Get or set current Page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Get or set Items per Page
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Get or set the Total Page
        /// </summary>
        public int TotalResult { get; set; }
    }
}
