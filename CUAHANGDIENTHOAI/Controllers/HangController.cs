using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CUAHANGDIENTHOAI.Data;
using CUAHANGDIENTHOAI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CUAHANGDIENTHOAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangController : ControllerBase
    {

        public readonly ChdtContext _db;

        public HangController(ChdtContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAllHang() =>
            Ok(await _db.HANGs.AsNoTracking().ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHangById(int id)
        {
            var hang = await _db.HANGs.FindAsync(id);
            return (hang is null) ? NotFound() : Ok(hang);
        }
        //    [HttpPost("{int:id}")]

        //    public async Task<IActionResult> Create(int id)
        //    {

        //        var Hang = await _db.HANGs.FindAsync(id);


        //        return NoContent();
        //    }
    }
}
