using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QUANLYBANHANG.Models;

namespace QUANLYBANHANG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HoaDonController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/HoaDon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbHoadon>>> GetTbHoadon()
        {
            return await _context.TbHoadon.ToListAsync();
        }

        // GET: api/HoaDon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbHoadon>> GetTbHoadon(int id)
        {
            var tbHoadon = await _context.TbHoadon.FindAsync(id);

            if (tbHoadon == null)
            {
                return NotFound();
            }

            return tbHoadon;
        }

        // PUT: api/HoaDon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbHoadon(int id, TbHoadon tbHoadon)
        {
            if (id != tbHoadon.Mahoadon)
            {
                return BadRequest();
            }

            _context.Entry(tbHoadon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbHoadonExists(id))
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

        // POST: api/HoaDon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbHoadon>> PostTbHoadon(TbHoadon tbHoadon)
        {
            _context.TbHoadon.Add(tbHoadon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbHoadon", new { id = tbHoadon.Mahoadon }, tbHoadon);
        }

        // DELETE: api/HoaDon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbHoadon(int id)
        {
            var tbHoadon = await _context.TbHoadon.FindAsync(id);
            if (tbHoadon == null)
            {
                return NotFound();
            }

            _context.TbHoadon.Remove(tbHoadon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbHoadonExists(int id)
        {
            return _context.TbHoadon.Any(e => e.Mahoadon == id);
        }
    }
}
