using Ira.Models.Entities;
using Ira.Repositories.Context;
using Ira.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ILogger<GenericRepository<Employee>> logger, IraContext context) : base(logger, context)
        {
        }
    }
}
