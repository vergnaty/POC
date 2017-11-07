using App.Console.Infrastructure;
using Justeat.Entities;
using Justeat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables;

namespace JusteatConsole
{

    /// <summary>
    /// this console application manage requestes to get list of restaurants by given outcode and pagination
    /// Principal Applied - Single Responsability, Dipendency Inversion and DRY
    /// </summary>
    class Program
    {
        static string INPUT_NAME = "outcode";
        static void Main(string[] args)
        {
            WriteWelcomeMessage();
            Execute();
        }

       
        /// <summary>
        /// Execute this instance.
        /// Applying DRY Principal - Recursive Method in order to keep continue to get input and execute queries.
        /// </summary>
        private static void Execute()
        {
            Console.Write($"{INPUT_NAME}> ");

            var args = Console.ReadLine().Split(' ');
            Pagination pagination = GetPagination(args);
            IRestaurantService service = GetService();

            List<Restaurant> restaurants = GetRestaurants(service, args[0], pagination);
            WriteResultToConsole(restaurants);

            Execute(); 
        }

        /// <summary>
        /// Get Pagination by given args
        /// </summary>
        /// <returns>The pagination.</returns>
        /// <param name="args">Arguments.</param>
        private static Pagination GetPagination(string[] args)
        {
            if (args.Count() == 1) return null;

            int page,totalItems  = 0;
            int.TryParse(args[1],out page);
    		int.TryParse(args[2], out totalItems);

            if (page == 0 || totalItems == 0) return null;

            return new Pagination()
            {
                Page = page,
                ItemsPerPage = totalItems
            };
        }

        /// <summary>
        /// Gets the restaurants.
        /// </summary>
        /// <returns>The restaurants.</returns>
        /// <param name="service">Service.</param>
        /// <param name="code">Code.</param>
        /// <param name="pag">Pag.</param>
        private static List<Restaurant> GetRestaurants(IRestaurantService service, string code, Pagination pag)
        {
            if (pag == null)
            {
                return service.GetRestaurants(code).Result;
            }
            var result = service.GetRestaurants(code, pag).Result;
            return result;
        }

        /// <summary>
        /// Write the result to console.
        /// </summary>
        /// <param name="restaurants">List of Restaurants.</param>
        private static void WriteResultToConsole(List<Restaurant> restaurants)
        {
			ConsoleTable table = new ConsoleTable("Name", "Rating", "Cusines");
            restaurants.ForEach(d =>
            {
                string cusineTypes = string.Join("-", d.CuisineTypes.Select(c => c.Name));
                table.AddRow(d.Name, d.RatingStars, cusineTypes);
            });

			table.Write();
        }

        /// <summary>
        /// Gets the Resturant service.
        /// </summary>
        /// <returns>The service.</returns>
        private static IRestaurantService GetService()
        {
            IoCContainer container = IoCContainer.Init();
            IRestaurantService service = container.Resolve<IRestaurantService>();
            return service;
        }

        /// <summary>
        /// Writes the welcome message.
        /// </summary>
        private static void WriteWelcomeMessage()
        {
            Console.WriteLine("*********************************************************************************");
            Console.WriteLine("**************************** JUSTEAT Restuarants ********************************");
            Console.WriteLine("***************** Please entre the outcode and press ENTER **********************");
            Console.WriteLine("*********************************************************************************");
        }
    }
}