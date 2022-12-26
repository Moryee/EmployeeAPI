using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.DAL
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private EmployeeDBContext context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employee.ToList();
        }

        public Employee GetEmployeeByID(int id)
        {
            return context.Employee.Find(id);
        }

        public void InsertEmployee(Employee employee)
        {
            context.Employee.Add(employee);
        }

        public void DeleteEmployee(int employeeID)
        {
            Employee employee = context.Employee.Find(employeeID);
            context.Employee.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}