using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMasGlobalTest.DTO
{
    public class MonthlySalaryEmployeesDTO : EmployeeDTO
    {
        public override void CalculateSalary()
        {
            try
            {
                if (ContractTypeName == "MonthlySalaryEmployee")
                {
                    AnnualSalary = MonthlySalary * 12;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
