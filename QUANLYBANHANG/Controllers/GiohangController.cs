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
    public class GiohangController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GiohangController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Giohang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbGiohang>>> GetTbGiohang()
        {
            return await _context.TbGiohang.ToListAsync();
        }

        // GET: api/Giohang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbGiohang>> GetTbGiohang(int id)
        {
            var tbGiohang = await _context.TbGiohang.FindAsync(id);

            if (tbGiohang == null)
            {
                return NotFound();
            }

            return tbGiohang;
        }

        // PUT: api/Giohang/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbGiohang(int id, TbGiohang tbGiohang)
        {
            if (id != tbGiohang.Magiohang)
            {
                return BadRequest();
            }

            _context.Entry(tbGiohang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbGiohangExists(id))
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

        // POST: api/Giohang
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbGiohang>> PostTbGiohang(TbGiohang tbGiohang)
        {
            _context.TbGiohang.Add(tbGiohang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbGiohang", new { id = tbGiohang.Magiohang }, tbGiohang);
        }

        // DELETE: api/Giohang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbGiohang(int id)
        {
            var tbGiohang = await _context.TbGiohang.FindAsync(id);
            if (tbGiohang == null)
            {
                return NotFound();
            }

            _context.TbGiohang.Remove(tbGiohang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbGiohangExists(int id)
        {
            return _context.TbGiohang.Any(e => e.Magiohang == id);
        }
    }
}
