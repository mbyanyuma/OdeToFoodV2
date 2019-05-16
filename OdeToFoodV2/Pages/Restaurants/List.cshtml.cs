using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFoodV2.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantData _restaurantData;
        private readonly ILogger<ListModel> _logger;

        public string TheMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            _config = config;
            _restaurantData = restaurantData;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Executing the ListModel bro"); //log test, check output from asp.net core web server
            TheMessage = _config["Message"]; //gets the value for the -Message- setting in appsettings.json

            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}