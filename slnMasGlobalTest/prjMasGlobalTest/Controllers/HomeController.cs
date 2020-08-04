using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using prjMasGlobalTest.Helpers;
using prjMasGlobalTest.Models;

namespace prjMasGlobalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HelperAPI api = new HelperAPI();
            List<Employee> employees = new List<Employee>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("/api/Employees");

            if (response.IsSuccessStatusCode)
            {
               
                var results = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(results);
                
                /*
                if (employees != null)
                {
                    foreach (var emp in employees)
                    {
                        if (emp.ContractTypeName != null)
                        {

                        }

                    }
                }*/
                
            }

            return View(employees);
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
    }
}
