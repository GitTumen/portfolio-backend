using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotNetApi.Models;

namespace DotNetApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly InfoContext _context;

        public InfoController(InfoContext context)
        {
            _context = context;
        }

        // GET: api/InfoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoItem>>> GetTodoItems()
        {
          if (_context.InfoItems == null)
          {
              return NotFound();
          }
            return await _context.InfoItems.ToListAsync();
        }

        // GET: api/InfoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoItem>> GetInfoItem(long id)
        {
          if (_context.InfoItems == null)
          {
              return NotFound();
          }
            var InfoItem = await _context.InfoItems.FindAsync(id);

            if (InfoItem == null)
            {
                return NotFound();
            }

            return InfoItem;
        }

        // PUT: api/InfoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoItem(long id, InfoItem InfoItem)
        {
            if (id != InfoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(InfoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoItemExists(id))
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

        // POST: api/InfoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoItem>> PostInfoItem(InfoItem InfoItem)
        {
         
            _context.InfoItems.Add(InfoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInfoItem), new { id = InfoItem.Id }, InfoItem);
        }

        // DELETE: api/InfoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfoItem(long id)
        {
            if (_context.InfoItems == null)
            {
                return NotFound();
            }
            var InfoItem = await _context.InfoItems.FindAsync(id);
            if (InfoItem == null)
            {
                return NotFound();
            }

            _context.InfoItems.Remove(InfoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfoItemExists(long id)
        {
            return (_context.InfoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    private static InfoItemDTO ItemToDTO(InfoItem InfoItem) =>
       new InfoItemDTO
       {
           Id = InfoItem.Id,
           Name = InfoItem.Name,
           IsComplete = InfoItem.IsComplete
       };
}

