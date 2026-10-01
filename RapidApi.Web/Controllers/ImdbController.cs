using Microsoft.AspNetCore.Mvc;
using RapidApi.Web.Models;
using System.Text.Json;

namespace RapidApi.Web.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<ImdbMoviesViewModel>>(body);
                return View(result);
            }



          
        }
    }
}
