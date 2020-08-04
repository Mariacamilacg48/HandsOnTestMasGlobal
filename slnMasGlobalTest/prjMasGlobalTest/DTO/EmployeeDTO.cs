using prjMasGlobalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMasGlobalTest.DTO
{
    public abstract class EmployeeDTO : Employee
    {
        public double? AnnualSalary { get; set; }
        public abstract void CalculateSalary();

    }
}
