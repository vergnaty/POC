using System;
using Xunit;
using Justeat.DataService;

namespace Justeat.UnitTest
{
    public class RestorantUnitTest
    {
        [Fact]
       
        public void Get_Restorants_By_Given_Invalid_Code_Expected_Argument_Exception()
        {

            ApiRestaurantService service = new ApiRestaurantService("http://www.google.it", new System.Collections.Generic.Dictionary<string, string>());
            Assert.ThrowsAnyAsync<ArgumentException>(async()=> {
                await  service.GetRestaurants(null);
            });
        }

        [Fact]
        public void Create_APIService_Instance_By_Invalid_Url_Expected_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ApiRestaurantService service = new ApiRestaurantService("", new System.Collections.Generic.Dictionary<string, string>());
            });
		}


    }
}
