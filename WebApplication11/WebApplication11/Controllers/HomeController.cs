using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;
using RestSharp;
using Newtonsoft.Json;
using WebApplication11.Models;
namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Repos()
        {
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("/orgs/dotnet/repos");
            var content = client.Execute(request).Content;
            var quertresult = JsonConvert.DeserializeObject<List<Repo>>(content);
            
            return View(quertresult);
           
        }
       
    }
}
