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
    public class AddressesController : ControllerBase
    {
        private readonly StudentContext _context;

        public AddressesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Address.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{streetNumber, street, id, city}")]
        public async Task<ActionResult<Address>> GetAddress(int streetNumber, string street, int id, string city)
        {
            var address = await _context.Address.FindAsync(streetNumber, street, id, city);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{streetNumber, street, id, city}")]
        public async Task<ActionResult<Address>> DeleteAddress(int streetNumber, string street, int id, string city)
        {
            var address = await _context.Address.FindAsync(streetNumber, street, id, city);
            if (address == null)
            {
                return NotFound();
            }

            _context.Address.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        private bool AddressExists(string id)
        {
            return _context.Address.Any(e => e.country == id);
        }
    }
}
