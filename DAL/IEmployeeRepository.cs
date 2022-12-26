using System;
using System.Collections.Generic;
using EmployeeAPI.Models;

namespace EmployeeAPI.DAL
{
    public interface IEmployeeRepository : IDisposable
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee Employee);
        void DeleteEmployee(int EmployeeID);
        void UpdateEmployee(Employee Employee);
        void Save();
    }
}