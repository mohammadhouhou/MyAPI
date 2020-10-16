using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.dal.Entities;

namespace MyAPI.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionsController : ControllerBase
    {
        private readonly UniversityContext _context;

        public InstitutionsController(UniversityContext context)
        {
            _context = context;
        }

        // GET: api/Institutions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institution>>> Getinstitutions()
        {
            return await _context.institutions.ToListAsync();
        }

        // GET: api/Institutions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institution>> GetInstitution(string id)
        {
            var institution = await _context.institutions.FindAsync(id);

            if (institution == null)
            {
                return NotFound();
            }

            return institution;
        }

        // PUT: api/Institutions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(string id, Institution institution)
        {
            if (id != institution.name)
            {
                return BadRequest();
            }

            _context.Entry(institution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionExists(id))
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

        // POST: api/Institutions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Institution>> PostInstitution(Institution institution)
        {
            _context.institutions.Add(institution);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InstitutionExists(institution.name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstitution", new { id = institution.name }, institution);
        }

        // DELETE: api/Institutions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Institution>> DeleteInstitution(string id)
        {
            var institution = await _context.institutions.FindAsync(id);
            if (institution == null)
            {
                return NotFound();
            }

            _context.institutions.Remove(institution);
            await _context.SaveChangesAsync();

            return institution;
        }

        private bool InstitutionExists(string id)
        {
            return _context.institutions.Any(e => e.name == id);
        }
    }
}
