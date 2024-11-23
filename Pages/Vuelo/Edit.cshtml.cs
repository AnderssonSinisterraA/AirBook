using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirBook.Pages.Vuelos
{
    public class EditModel : PageModel
    {
        private readonly AirBookContext _context;

        public EditModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Vuelo Vuelo { get; set; }
        public SelectList Aerolineas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vuelo = await _context.Vuelos.FirstOrDefaultAsync(m => m.IdVuelo == id);

            if (Vuelo == null)
            {
                return NotFound();
            }

            Aerolineas = new SelectList(_context.Aerolineas, "IdAerolinea", "NombreAerolinea");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Aerolineas = new SelectList(_context.Aerolineas, "IdAerolinea", "NombreAerolinea");
                return Page();
            }

            _context.Attach(Vuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(Vuelo.IdVuelo))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VueloExists(int id)
        {
            return _context.Vuelos.Any(e => e.IdVuelo == id);
        }
    }
}