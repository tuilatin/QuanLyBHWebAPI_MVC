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
    public class SanphamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SanphamController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sanpham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbSanpham>>> GetTbSanpham()
        {
            return await _context.TbSanpham.ToListAsync();
        }

        // GET: api/Sanpham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbSanpham>> GetTbSanpham(int id)
        {
            var tbSanpham = await _context.TbSanpham.FindAsync(id);

            if (tbSanpham == null)
            {
                return NotFound();
            }

            return tbSanpham;
        }

        // PUT: api/Sanpham/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbSanpham(int id, TbSanpham tbSanpham)
        {
            if (id != tbSanpham.Masanpham)
            {
                return BadRequest();
            }

            _context.Entry(tbSanpham).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbSanphamExists(id))
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

        // POST: api/Sanpham
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbSanpham>> PostTbSanpham(TbSanpham tbSanpham)
        {
            _context.TbSanpham.Add(tbSanpham);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbSanpham", new { id = tbSanpham.Masanpham }, tbSanpham);
        }

        // DELETE: api/Sanpham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbSanpham(int id)
        {
            var tbSanpham = await _context.TbSanpham.FindAsync(id);
            if (tbSanpham == null)
            {
                return NotFound();
            }

            _context.TbSanpham.Remove(tbSanpham);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbSanphamExists(int id)
        {
            return _context.TbSanpham.Any(e => e.Masanpham == id);
        }
    }
}
