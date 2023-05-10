using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingMallAdmin.Models;

namespace WeddingMallAdmin.Controllers
{
    public class ServiceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Service> services = new List<Service>();
            using(var client = new HttpClient())
            {
                using(var response = await client.GetAsync("https://localhost:7268/api/Service/Getall"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    services = JsonConvert.DeserializeObject<List<Service>>(apiResponse);
                }
            }
            return View(services);
        }
    }
}
