using DryIoc;
using Justeat.DataService;
using Justeat.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Console.Infrastructure
{
    public class IoCContainer
    {
        static Container container;

        /// <summary>
        /// Create new instance of <see cref="IoCContainer"/>
        /// </summary>
        private IoCContainer()
        {
            if (container == null)
            {
                //Get From Configuration
                string url = "https://public.je-apis.com/restaurants";
                Dictionary<string, string> headers = GetHeaders();

                container = new Container();
                container.RegisterDelegate<IRestaurantService>(d => new ApiRestaurantService(url, headers), reuse: Reuse.Singleton);
            }
        }

        /// <summary>
        /// Initialize the Ioc Container
        /// </summary>
        /// <returns></returns>
        public static IoCContainer Init()
        {
            return new IoCContainer();
        }

        /// <summary>
        /// Resolve Concurrent class
        /// </summary>
        /// <typeparam name="T">the type.</typeparam>
        /// <param name="serviceName">the service name.</param>
        /// <returns>Concurrent class of <see cref="T"/></returns>
        public T Resolve<T>(string serviceName = null)
        {
            return container.Resolve<T>();
        }


        /// <summary>
        /// Get Justeat API Headers
        /// </summary>
        /// <returns>List of Headers</returns>
        private static Dictionary<string, string> GetHeaders()
        {
            //GET from configuration
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Basic VGVjaFRlc3RBUEk6dXNlcjI=");
            headers.Add("Accept-Tenant", "uk");
            headers.Add("Accept-Language", "en-GB");
            return headers;
        }
    }
}
