using DoctorPatientProject.Data;
using DoctorPatientProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorPatientProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.patients.ToListAsync();
        }

        // GET: api/Patient/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> Create(Patient patient)
        {
            _context.patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // PUT: api/Patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return 200 OK with a message or the updated patient object
            return Ok(new { message = "Patient updated successfully", patient });
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.patients.Remove(patient);
            await _context.SaveChangesAsync();

            // Return 200 OK with a message or the deleted patient object
            return Ok(new { message = "Patient deleted successfully", patient });
        }
        private bool PatientExists(int id)
        {
            return _context.patients.Any(e => e.Id == id);
        }
    }
}
