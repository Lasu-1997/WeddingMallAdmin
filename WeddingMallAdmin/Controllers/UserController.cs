using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingMallAdmin.Models;

namespace WeddingMallAdmin.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<User> userList = new List<User>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7268/api/User/Getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return View(userList);
        }
    }
}
