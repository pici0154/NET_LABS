using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intro_to_webapps.Models;

namespace Intro_to_webapps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderItemsController : ControllerBase
    {
        private readonly RemindersContext _context;

        public ReminderItemsController(RemindersContext context)
        {
            _context = context;
        }

        // GET: api/ReminderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReminderItem>>> GetReminderItems()
        {
            return await _context.ReminderItems.ToListAsync();
        }

        // GET: api/ReminderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReminderItem>> GetReminderItem(long id)
        {
            var reminderItem = await _context.ReminderItems.FindAsync(id);

            if (reminderItem == null)
            {
                return NotFound();
            }

            return reminderItem;
        }

        // PUT: api/ReminderItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReminderItem(long id, ReminderItem reminderItem)
        {
            if (id != reminderItem.Id)
            {
                return BadRequest();
            }

            if (!ReminderItemExists(id))
            {
                return NotFound();
            }

            _context.Entry(reminderItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(reminderItem);
        }

        // POST: api/ReminderItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReminderItem>> PostReminderItem(ReminderItem reminderItem)
        {
            _context.ReminderItems.Add(reminderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReminderItem", new { id = reminderItem.Id }, reminderItem);
        }

        // DELETE: api/ReminderItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReminderItem>> DeleteReminderItem(long id)
        {
            var reminderItem = await _context.ReminderItems.FindAsync(id);
            if (reminderItem == null)
            {
                return NotFound();
            }

            _context.ReminderItems.Remove(reminderItem);
            //_context.Entry(reminderItem).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return reminderItem;
        }

        private bool ReminderItemExists(long id)
        {
            return _context.ReminderItems.Any(e => e.Id == id);
        }
    }
}
