using Newtonsoft.Json;
using prjMasGlobalCommon;
using prjMasGlobalCommon.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace prjMasGlobalTestRepository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            try
            {
                HelperAPI api = new HelperAPI();
                List<EmployeeDTO> employeesResult = new List<EmployeeDTO>();
                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.GetAsync("/api/Employees");

                if (response.IsSuccessStatusCode)
                {

                    var results = response.Content.ReadAsStringAsync().Result;
                    employeesResult = JsonConvert.DeserializeObject<List<EmployeeDTO>>(results);

                }
                return employeesResult;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}


