using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olydispay_api_backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Olydispay_api_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private OlydispayApiContext _context;

        public EmployeeController(OlydispayApiContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetEmployees()
        {
            return await _context.employees.ToListAsync();
        }
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEmployees), new
                {
                    id = employee.EmployeeID
                }, employee);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int EmployeeID)
        {
            var employ = _context.employees.Find(EmployeeID);
            if (employ == null)
            {
                return NotFound();
            }
            try
            {
                _context.employees.Remove(employ);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de la suppression : " + ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeToUpdate = _context.employees.Find(id);
            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                employeeToUpdate.lastName = employee.lastName;
                employeeToUpdate.firstName = employee.firstName;
                employeeToUpdate.jobTitle = employee.jobTitle;
                employeeToUpdate.gender = employee.gender;
                employeeToUpdate.contractStartDate = employee.contractStartDate;
                employeeToUpdate.contractEndDate = employee.contractEndDate;
                employeeToUpdate.managerId = employee.managerId;
                employeeToUpdate.listOfPersonManaged = employee.listOfPersonManaged;
                employeeToUpdate.department = employee.department;
                _context.SaveChanges();
                return Ok(employeeToUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de la mise à jour : " + ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
