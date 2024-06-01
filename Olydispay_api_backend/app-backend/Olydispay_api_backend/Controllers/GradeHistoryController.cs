using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class GradeHistoryController : ControllerBase
    {
        private OlydispayApiContext _context;

        public GradeHistoryController(OlydispayApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetGradesHistories()
        {
            return await _context.gradeHistories.ToListAsync();
        }
        [HttpPost]
        public IActionResult Post(GradeHistory gradeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.gradeHistories.Add(gradeHistory);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetGradesHistories), new
                {
                    id = gradeHistory.GradeHistoryID
                }, gradeHistory);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int GradeHistoryID)
        {
            var gradehist = _context.gradeHistories.Find(GradeHistoryID);
            if (gradehist == null)
            {
                return NotFound();
            }
            try
            {
                _context.gradeHistories.Remove(gradehist);
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
        public IActionResult Put(int id, GradeHistory gradeHistory)
        {
            if (id != gradeHistory.GradeHistoryID)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gradeHistoryToUpdate = _context.gradeHistories.Find(id);
            if (gradeHistoryToUpdate == null)
            {
                return NotFound();
            }

            try
            {
                gradeHistoryToUpdate.grade = gradeHistory.grade;
                gradeHistoryToUpdate.fromDate = gradeHistory.fromDate;
                gradeHistoryToUpdate.toDate = gradeHistory.toDate;
                gradeHistoryToUpdate.employee = gradeHistory.employee;
                _context.SaveChanges();
                return Ok(gradeHistoryToUpdate);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Erreur lors de la mise à jour : " + ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
