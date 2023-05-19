using ASPNETCoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Data;
using System.Diagnostics;

namespace ASPNETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController
    {
            readonly IConfiguration _configuration;
            public readonly string API_KEY = "36c56b9ade26441da11224304231805";
            public WeatherController(IConfiguration configuration)
            {

                _configuration = configuration;

            }

          
            [HttpGet("{CityName}")]
            public string GetWeather(string CityName)
            {
                string request_url = $"http://api.weatherapi.com/v1/current.json?key={API_KEY}&q={CityName}";

                var client = new RestClient(request_url);
                var response = client.Execute(new RestRequest());

                string jsonResponse = JsonConvert.SerializeObject(response);
                JObject json = JObject.Parse(jsonResponse);

                // JToken propertyValue = json["current"];
                //IList<string> keys = json.Properties().Select(p => p.Name).ToList();
                //Debug.WriteLine(String.Join("\n", keys));
                JToken interest = JToken.Parse(json["Content"].ToString());

                // Debug.WriteLine(interest["current"]["temp_c"]);
                // Debug.WriteLine(interest["current"]);
                JObject jsonObject = new JObject
                {
                    ["temperature"] = interest["current"]["temp_c"],
                    ["wind"] = interest["current"]["wind_kph"],
                    ["gust"] = interest["current"]["gust_kph"],

                };
                return jsonObject.ToString();
            }
       
    }
}
