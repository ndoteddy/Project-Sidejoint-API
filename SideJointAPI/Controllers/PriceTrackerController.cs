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
    public class PriceTrackerController : ControllerBase
    {
        private readonly MainContext _context;
        private readonly ILogger<PriceTrackerController> _logger;
        private List<PriceSummaryDTO> _listPriceSummaryDTO = new List<PriceSummaryDTO>();

        public PriceTrackerController(MainContext context, ILogger<PriceTrackerController> logger)
        {
            _context = context;
            _logger = logger;
        }

    

        // GET: api/PriceTracker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriceTracker>>> GetPriceTracker()
        {
            return await _context.PriceTracker.ToListAsync();
        }

        //// GET: api/PriceTracker/Summary
        [HttpGet("Summary")]
        public async Task<ActionResult<List<PriceSummaryDTO>>> GetPriceSummary()      
        {

            var _masterdata = await _context.MasterItems.AsNoTracking().ToListAsync();
            var _listPriceSummaryDTO = new List<PriceSummaryDTO>();
            foreach (var masteritem in _masterdata)
            {
                var todayopeningmarket = masteritem.todayopenvalue;
                var data = await _context.PriceTracker.Where(x => x.itemid == masteritem.id).AsNoTracking().ToListAsync();
                var result = data.GroupBy(x => x.itemid)
                               .Select(group => new PriceSummaryItem
                               {
                                   itemid = group.Key,
                                   totalprice = Math.Round(group.Sum(i => i.price), 2),
                                   averageprice = Math.Round(group.Average(i => i.price), 2)
                               }).ToList();

                foreach (var item in result)
                {
                    var percentage = Math.Round(((Double)item.averageprice - (Double)todayopeningmarket) / ((Double)todayopeningmarket) * 100);
                    var percentageInString = "";
                    if (percentage > 0)
                    {
                        item.pricestatus = "UP";
                        percentageInString = "+" + percentage + "%";
                    }
                    else
                    {
                        item.pricestatus = "DOWN";
                        percentageInString = percentage + "%";
                    }
                    item.percentage = percentageInString;
                }

                _listPriceSummaryDTO.Add(new PriceSummaryDTO()
                {
                    itemid = masteritem.id,
                    name = masteritem.name,
                    email = masteritem.email,
                    todayopenvalue = masteritem.todayopenvalue,
                    priceSummaryItem = result

                });
            }
            return _listPriceSummaryDTO;
        }


        // GET: api/PriceTracker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriceTracker>> GetPriceTracker(int id)
        {
            var PriceTrackerItems = await _context.PriceTracker.FindAsync(id);

            if (PriceTrackerItems == null)
            {
                return NotFound();
            }

            return PriceTrackerItems;
        }

        // PUT: api/PriceTracker/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceTrackers(int id, PriceTracker PriceTracker)
        {
            if (id != PriceTracker.id)
            {
                return BadRequest();
            }

            _context.Entry(PriceTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceTrackerExists(id))
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

        // POST: api/PriceTracker
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PriceTracker>> PostPriceTracker(PriceTracker PriceTracker)
        {
            _context.PriceTracker.Add(PriceTracker);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPriceTracker), new { id = PriceTracker.id }, PriceTracker);
        }

        [HttpPost("random")]
        public async Task<ActionResult<PriceTracker>> PostPriceTrackerRandom()
        {

            var _priceTracker = new PriceTracker()
            {
                itemid = (int)GetRandomNumber(1, 3),
                price = (decimal)GetRandomNumber(100000, 150000),
                createdat = DateTime.Now,
                createdby=1
            };

            _context.PriceTracker.Add(_priceTracker);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPriceTracker), new { id = _priceTracker.id }, _priceTracker);
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

     

        // DELETE: api/PriceTracker/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PriceTracker>> DeletePriceTracker(int id)
        {
            var PriceTracker = await _context.PriceTracker.FindAsync(id);
            if (PriceTracker == null)
            {
                return NotFound();
            }

            _context.PriceTracker.Remove(PriceTracker);
            await _context.SaveChangesAsync();

            return PriceTracker;
        }

        private bool PriceTrackerExists(int id)
        {
            return _context.PriceTracker.Any(e => e.id == id);
        }
    }
}
