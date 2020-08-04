using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMasGlobalTest.DTO
{
    public class HourlySalaryEmployeesDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == "HourlySalaryEmployee") ;
                {
                    AnnualSalary = 120 * HourlySalary * 12;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
