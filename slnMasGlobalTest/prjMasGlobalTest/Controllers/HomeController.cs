using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using prjMasGlobalCommon.DTO;
using prjMasGlobalLogic;
using prjMasGlobalTest.Helpers;
using prjMasGlobalTest.Models;

namespace prjMasGlobalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<EmployeeDTO> employeeDTO;
        private bool getBild = false;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                EmployeeLogic emp = new EmployeeLogic();
                
                employeeDTO = await emp.GetAllEmployees();
                    
                return View(employeeDTO);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string idEmployee)
        {
            try
            {
                EmployeeLogic emp = new EmployeeLogic();
                employeeDTO = new List<EmployeeDTO>();


                if (!string.IsNullOrEmpty(idEmployee))
                {
                    int idEmployeeGet = Convert.ToInt32(idEmployee);
                    

                    employeeDTO.Add(await emp.GetEmployeeById(idEmployeeGet));
                }
                else
                {
                    employeeDTO = await emp.GetAllEmployees();
                }
                return View(employeeDTO);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
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
