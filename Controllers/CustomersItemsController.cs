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
    public class CustomersItemsController : ControllerBase
    {
        private readonly CustomersContext _context;

        public CustomersItemsController(CustomersContext context)
        {
            _context = context;
        }

    // GET: api/CustomersItems
    [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomersItem>>> GetTodoItems()
        {
          if (_context.CustomersItems == null)
          {
              return NotFound();
          }
            return await _context.CustomersItems.ToListAsync();
        }

    // GET: api/CustomersItems/5
    [HttpGet("{id}")]
        public async Task<ActionResult<CustomersItem>> GetCustomersItem(long id)
        {
          if (_context.CustomersItems == null)
          {
              return NotFound();
          }
            var CustomersItem = await _context.CustomersItems.FindAsync(id);

            if (CustomersItem == null)
            {
                return NotFound();
            }

            return CustomersItem;
        }

    // PUT: api/CustomersItems/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomersItem(long id, CustomersItem CustomersItem)
        {
            if (id != CustomersItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(CustomersItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersItemExists(id))
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

    // POST: api/CustomersItems
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
        public async Task<ActionResult<CustomersItem>> PostCustomersItem(CustomersItem CustomersItem)
        {
         
            _context.CustomersItems.Add(CustomersItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomersItem), new { id = CustomersItem.Id }, CustomersItem);
        }

    // DELETE: api/CustomersItems/5
    [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomersItem(long id)
        {
            if (_context.CustomersItems == null)
            {
                return NotFound();
            }
            var CustomersItem = await _context.CustomersItems.FindAsync(id);
            if (CustomersItem == null)
            {
                return NotFound();
            }

            _context.CustomersItems.Remove(CustomersItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomersItemExists(long id)
        {
            return (_context.CustomersItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    private static CustomersItemDTO ItemToDTO(CustomersItem CustomersItem) =>
     new CustomersItemDTO
     {
         Id = CustomersItem.Id,
         Name = CustomersItem.Name,
         IsComplete = CustomersItem.IsComplete
     };
}

