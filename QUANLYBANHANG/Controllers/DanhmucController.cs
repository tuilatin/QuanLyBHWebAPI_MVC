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
    public class DanhmucController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DanhmucController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Danhmuc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDanhmuc>>> GetTbDanhmuc()
        {
            return await _context.TbDanhmuc.ToListAsync();
        }

        // GET: api/Danhmuc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDanhmuc>> GetTbDanhmuc(int id)
        {
            var tbDanhmuc = await _context.TbDanhmuc.FindAsync(id);

            if (tbDanhmuc == null)
            {
                return NotFound();
            }

            return tbDanhmuc;
        }

        // PUT: api/Danhmuc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDanhmuc(int id, TbDanhmuc tbDanhmuc)
        {
            if (id != tbDanhmuc.Madanhmuc)
            {
                return BadRequest();
            }

            _context.Entry(tbDanhmuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDanhmucExists(id))
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

        // POST: api/Danhmuc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDanhmuc>> PostTbDanhmuc(TbDanhmuc tbDanhmuc)
        {
            _context.TbDanhmuc.Add(tbDanhmuc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDanhmuc", new { id = tbDanhmuc.Madanhmuc }, tbDanhmuc);
        }

        // DELETE: api/Danhmuc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDanhmuc(int id)
        {
            var tbDanhmuc = await _context.TbDanhmuc.FindAsync(id);
            if (tbDanhmuc == null)
            {
                return NotFound();
            }

            _context.TbDanhmuc.Remove(tbDanhmuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDanhmucExists(int id)
        {
            return _context.TbDanhmuc.Any(e => e.Madanhmuc == id);
        }
    }
}
