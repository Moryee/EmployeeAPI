using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI;
using EmployeeAPI.Models;
using EmployeeAPI.DAL;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // private readonly EmployeeContext _context;

        // public EmployeeController(EmployeeContext context)
        // {
        //     _context = context;
        // }

        private IEmployeeRepository employeeRepository;

        public EmployeeController(EmployeeDBContext context)
        {
            this.employeeRepository = new EmployeeRepository(context);
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
          if (employeeRepository.GetEmployees() == null)
          {
              return NotFound();
          }
            return new ActionResult<IEnumerable<Employee>>(employeeRepository.GetEmployees());
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            if (employeeRepository.GetEmployees() == null)
            {
                return NotFound();
            }
            var employee = employeeRepository.GetEmployeeByID(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            employeeRepository.UpdateEmployee(employee);

            try
            {
                employeeRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Employee> PostEmployee(Employee employee)
        {
          if (employeeRepository.GetEmployees == null)
          {
              return Problem("Entity set 'EmployeeContext.Employee'  is null.");
          }
            employeeRepository.InsertEmployee(employee);
            employeeRepository.Save();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (employeeRepository.GetEmployees == null || employeeRepository.GetEmployeeByID(id) == null)
            {
                return NotFound();
            }

            employeeRepository.DeleteEmployee(id);

            employeeRepository.Save();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {

            if(employeeRepository.GetEmployeeByID(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
