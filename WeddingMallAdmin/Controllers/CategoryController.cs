using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingMallAdmin.Models;

namespace WeddingMallAdmin.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Category> categories = new List<Category>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7268/api/Category/Getall"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(categories);
        }
    }
}
