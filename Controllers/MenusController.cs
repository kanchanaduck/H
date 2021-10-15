using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularFirst.Data;
using AngularFirst.Models;

namespace AngularFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenu()
        {
            // return await _context.Menu.ToListAsync();
            var menu = await _context.Menu
                            .Include(e => e.children)
                              .ThenInclude(c => c.children)
                              .Where(e => e.parent_menu_code == null)
                            .ToListAsync();      

            if (menu.Count <= 0)
            {
                return NotFound();
            }

            return menu;
        }

        // GET: api/Menus/children/<parent_menu_code>
        [HttpGet("children/{id}")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenuChildren(string id)
        {
            var menu = await _context.Menu
                                .Include(e => e.children)
                                // .Where(x => !x.ParentId.HasValue)
                                    .Where(e => e.parent_menu_code == id )
                                .ToListAsync();
           
            if (menu.Count <= 0)
            {
                return NotFound();
            }

            return menu;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(string id)
        {
             var menu = await _context.Menu.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu(string id, Menu menu)
        {
            if (id != menu.menu_code)
            {
                return BadRequest();
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            _context.Menu.Add(menu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MenuExists(menu.menu_code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenu", new { id = menu.menu_code }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(string id)
        {
            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuExists(string id)
        {
            return _context.Menu.Any(e => e.menu_code == id);
        }
    }
}
