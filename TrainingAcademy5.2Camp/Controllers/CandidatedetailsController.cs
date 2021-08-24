using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingAcademy5._2Camp.Models;

namespace TrainingAcademy5._2Camp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatedetailsController : ControllerBase
    {
        private readonly Alien51Context _context;

        public CandidatedetailsController(Alien51Context context)
        {
            _context = context;
        }

        // GET: api/Candidatedetails
        [HttpGet]
        public IEnumerable<Candidatedetails> GetCandidatedetails()
        {
            return _context.Candidatedetails;
        }

        // GET: api/Candidatedetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidatedetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidatedetails = await _context.Candidatedetails.FindAsync(id);

            if (candidatedetails == null)
            {
                return NotFound();
            }

            return Ok(candidatedetails);
        }

        // PUT: api/Candidatedetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidatedetails([FromRoute] int id, [FromBody] Candidatedetails candidatedetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatedetails.Candidateid)
            {
                return BadRequest();
            }

            _context.Entry(candidatedetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatedetailsExists(id))
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

        // POST: api/Candidatedetails
        [HttpPost]
        public async Task<IActionResult> PostCandidatedetails([FromBody] Candidatedetails candidatedetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Candidatedetails.Add(candidatedetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidatedetails", new { id = candidatedetails.Candidateid }, candidatedetails);
        }

        // DELETE: api/Candidatedetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidatedetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidatedetails = await _context.Candidatedetails.FindAsync(id);
            if (candidatedetails == null)
            {
                return NotFound();
            }

            _context.Candidatedetails.Remove(candidatedetails);
            await _context.SaveChangesAsync();

            return Ok(candidatedetails);
        }

        private bool CandidatedetailsExists(int id)
        {
            return _context.Candidatedetails.Any(e => e.Candidateid == id);
        }
    }
}