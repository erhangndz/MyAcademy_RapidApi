using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Web.Models;

namespace RapidApi.Web.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(string cityName)
        {

            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://open-weather13.p.rapidapi.com/city?lang=tr&city={cityName}"),
                Headers =
    {
        { "x-rapidapi-key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                return View(result);
            }


           
        }
    }
}
