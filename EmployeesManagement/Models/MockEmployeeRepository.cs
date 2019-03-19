using System.Collections.Generic;
using System.Linq;

namespace EmployeesManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeesList;

        public MockEmployeeRepository()
        {
            _employeesList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "A", Email = "a@ccc.com", Department = "A_Department"},
                new Employee() {Id = 2, Name = "B", Email = "b@ccc.com", Department = "B_Department"},
                new Employee() {Id = 3, Name = "C", Email = "c@ccc.com", Department = "C_Department"},
                new Employee() {Id = 4, Name = "D", Email = "d@ccc.com", Department = "D_Department"}
            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeesList.FirstOrDefault(e => e.Id == id);

        }
    }
}
