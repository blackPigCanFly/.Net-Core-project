namespace EmployeesManagement.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
    }
}
