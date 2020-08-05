using prjMasGlobalCommon.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prjMasGlobalLogic
{
    public interface IEmployeeLogic 
    {
        Task<List<EmployeeDTO>> GetAllEmployees();
    }
}