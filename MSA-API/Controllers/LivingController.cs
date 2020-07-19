using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA_API.Data;
using MSA_API.Models;

namespace MSA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivingController : ControllerBase
    {
        private readonly StudentContext _context;

        public LivingController(StudentContext context)
        {
            _context = context;
        }

        // PUT: api/Living/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            Student student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return BadRequest("Student ID does not exist");
            }

            var addresses = _context.Address.Where(a => a.studentId.Equals(id)).ToList();

            _context.Address.RemoveRange(addresses);

            if(id != address.studentId)
            {
                return BadRequest();
            }

            _context.Address.Add(address);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddressExists(address.streetNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();

        }

        // POST: api/Living/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Address>> PostAddress(int id, Address address)
        {
            Student student = await _context.Student.FindAsync(id);

            if(student == null)
            {
                return BadRequest("Student ID does not exist");
            }

            if (id != address.studentId)
            {
                return BadRequest();
            }

            _context.Address.Add(address);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddressExists(address.streetNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.streetNumber == id);
        }
    }
}
