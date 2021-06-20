using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SideJointAPI.Model;

namespace SideJointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterItemsController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly ILogger<MasterItemsController> _logger;
        public MasterItemsController(MainContext context, ILogger<MasterItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

    

        // GET: api/MasterItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterItem>>> GetMasterItems()
        {
            return await _context.MasterItems.ToListAsync();
        }

        // GET: api/MasterItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterItem>> GetMasterItems(int id)
        {
            var MasterItems = await _context.MasterItems.FindAsync(id);

            if (MasterItems == null)
            {
                return NotFound();
            }

            return MasterItems;
        }

        // PUT: api/MasterItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobs(int id, MasterItem MasterItem)
        {
            if (id != MasterItem.id)
            {
                return BadRequest();
            }

            _context.Entry(MasterItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterExists(id))
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

        // POST: api/MasterItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MasterItem>> PostJobs(MasterItem MasterItem)
        {
            _context.MasterItems.Add(MasterItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMasterItems), new { id = MasterItem.id }, MasterItem);
        }

        // DELETE: api/MasterItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MasterItem>> DeleteMasterItem(long id)
        {
            var MasterItems = await _context.MasterItems.FindAsync(id);
            if (MasterItems == null)
            {
                return NotFound();
            }

            _context.MasterItems.Remove(MasterItems);
            await _context.SaveChangesAsync();

            return MasterItems;
        }

        private bool MasterExists(long id)
        {
            return _context.MasterItems.Any(e => e.id == id);
        }
    }
}
