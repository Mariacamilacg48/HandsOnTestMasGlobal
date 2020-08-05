using prjMasGlobalCommon.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace prjMasGlobalTestRepository
{
    public interface IEmployeesRepository
    {
        Task<List<EmployeeDTO>> GetAllAsync();
    }
}