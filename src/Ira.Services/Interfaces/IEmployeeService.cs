using Ira.Models.Entities;
using Ira.Models.Enums;

namespace Ira.Services.Interfaces
{
    public interface IEmployeeService
    {
        Employee GetById(Guid id);
        List<Employee> GetEmployeesByPosition(EmployeePosition position);
        List<Employee> CreateEmployees(double quantity);
        Employee UpdateEmployeeEmail(Guid id, string email);
    }
}
