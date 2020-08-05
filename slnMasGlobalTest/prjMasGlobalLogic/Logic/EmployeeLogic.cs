using prjMasGlobalCommon.DTO;
using prjMasGlobalTestRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjMasGlobalLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                EmployeesRepository emp = new EmployeesRepository();

                var employeesResult = await emp.GetAllAsync();

                foreach (var employee in employeesResult)
                {
                    employee.AnnualSalary = CalculateSalary(employee.ContractTypeName, employee.HourlySalary, employee.MonthlySalary);
                }
            
                return employeesResult;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<EmployeeDTO> GetEmployeeById(int idEmployee)
        {
            try
            {
                EmployeesRepository emp = new EmployeesRepository();

                var employeesResult = await emp.GetAllAsync();

                var employeeResult = employeesResult.Where(x => x.Id == idEmployee).FirstOrDefault();

                employeeResult.AnnualSalary = CalculateSalary(employeeResult.ContractTypeName, employeeResult.HourlySalary, employeeResult.MonthlySalary);

                return employeeResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public double CalculateSalary(string contractTypeName, double hourlySalaryName, double monthlySalaryName)
        {
            double annualSalary = 0;

            if (contractTypeName == "HourlySalaryEmployee")
            {
                annualSalary = 120 * hourlySalaryName * 12;
            }
            else if (contractTypeName == "MonthlySalaryEmployee")
            {
                annualSalary = monthlySalaryName * 12;

            }
            return annualSalary;
        }



    }

}

