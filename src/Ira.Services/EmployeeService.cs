using FakerDotNet;
using Ira.Models.Entities;
using Ira.Models.Enums;
using Ira.Repositories.Interfaces;
using Ira.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ira.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _repoEmployee;

        public EmployeeService(
            ILogger<EmployeeService> logger,
            IEmployeeRepository repoEmployee)
        {
            _logger = logger;
            _repoEmployee = repoEmployee;
        }

        public Employee GetById(Guid id)
        {
            return _repoEmployee.Get(id);
        }

        public List<Employee> GetEmployeesByPosition(EmployeePosition position)
        {
            var all = _repoEmployee.GetAll();

            return all.Where(x => x.Position == position.ToString()).ToList();
        }

        public List<Employee> CreateEmployees(double quantity)
        {
            var result = new List<Employee>();

            for (int i = 0; i < quantity; i++)
            {
                var position = GetPosition(i);
                var email = Faker.Internet.FreeEmail();

                if (position == EmployeePosition.Captain)
                {
                    email = Faker.Internet.SafeEmail();
                }

                if (position == EmployeePosition.Pilot)
                {
                    email = Faker.Internet.Email();
                }

                result.Add(new Employee()
                {
                    Id = Guid.NewGuid(),
                    AidCard = Faker.Company.SpanishOrganisationNumber(),
                    CompleteName = Faker.Name.Name(),
                    Description = Faker.Hipster.Sentence(),
                    Email = email,
                    Position = position.ToString(),
                });
            }

            return result;
        }

        public Employee UpdateEmployeeEmail(Guid id, string email)
        {
            var employee = _repoEmployee.Get(id);
            employee.Email = email;

            _repoEmployee.Update(employee);

            return employee;
        }

        private EmployeePosition GetPosition(int position)
        {
            if (position <= 1)
            {
                return (EmployeePosition)position;
            }

            return Utilities.RandomFromEnum<EmployeePosition>();
        }
    }
}
