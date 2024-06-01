using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Olydispay_api_backend.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Olydispay_api_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private OlydispayApiContext _context;
        public DepartmentController(OlydispayApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAsync()
        {
            return await _context.departments.ToListAsync();
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.departments.Add(department);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAsync), new
                {
                    id = department.DepartmentID
                }, department);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int DepartmentID)
        {
            var department = _context.departments.Find(DepartmentID);
            if (department == null)
            {
                return NotFound();
            }
            try
            {
                _context.departments.Remove(department);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de la suppression : "+ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Department department)
        {
            if (id != department.DepartmentID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departmentToUpdate = _context.departments.Find(id);
            if (departmentToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                departmentToUpdate.name = department.name;
                _context.SaveChanges();
                return Ok(departmentToUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de la mise à jour : " + ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
