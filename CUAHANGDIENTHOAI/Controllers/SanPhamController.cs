using CUAHANGDIENTHOAI.Data;
using CUAHANGDIENTHOAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CUAHANGDIENTHOAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public readonly ChdtContext _context;
        public SanPhamController(ChdtContext context) => _context = context;




        [HttpGet("lay-danh-sach-san-pham")]
        public async Task<IActionResult> getAll() =>
            Ok(await _context.SANPHAMs.AsNoTracking().ToListAsync());



        [HttpGet("{id:int}")]
        public async Task<IActionResult> getById(int id)
        {
            var sp = await _context.SANPHAMs.FindAsync(id);
            return sp is null ? NotFound() : Ok(sp);
        }

        [HttpPost("them-san-pham")]
        public async Task<IActionResult> Create([FromBody] SANPHAM sp)
        {
            _context.SANPHAMs.Add(sp);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(getById), new { id = sp.SANPHAMID }, sp);
        }

        //[HttpPut("sua-san-pham{id:int}")]
        //public async Task<IActionResult> Update(int id, [FromBody] SANPHAM input)
        //{
        //    if (id != input.SANPHAMID) return BadRequest();
        //    var sp = await _context.SANPHAMs.FindAsync(id);
        //    if (sp is null) return NotFound();

        //    sp.HANGID = input.HANGID;
        //    sp.TENSANPHAM = input.TENSANPHAM;
        //    sp.GIA = input.GIA;
        //    sp.TONKHO = input.TONKHO;
        //    sp.TRANGTHAI = input.TRANGTHAI;

        //    await _context.SaveChangesAsync();


        //    return NoContent();
        //}

        [HttpPut("sua-san-pham{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] SANPHAM input)
        {
           if(id != input.SANPHAMID ) return BadRequest();
            var sp = await _context.SANPHAMs.FindAsync(id);
            if (sp is null) return NotFound();

            sp.HANGID = input.HANGID;
            sp.TENSANPHAM = input.TENSANPHAM;
            sp.GIA = input.GIA;
            sp.HANG = input.HANG;
            sp.TONKHO = input.TONKHO;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("xoa-san-pham{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sp = await _context.SANPHAMs.FindAsync(id);

            _context.SANPHAMs.Remove(sp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
