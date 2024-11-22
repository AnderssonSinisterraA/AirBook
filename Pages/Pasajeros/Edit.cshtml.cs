using AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AirBook.Pages.Pasajeros
{
    public class EditModel : PageModel
    {
        private readonly AirBookContext _context;

        public EditModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pasajero Pasajero { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pasajero = await _context.Pasajeros.FindAsync(id);

            if (Pasajero == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verifica que el IdPasajero no tenga un valor temporal
            if (Pasajero.IdPasajero == 0)
            {
                return BadRequest("Invalid Pasajero ID.");
            }

            _context.Attach(Pasajero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasajeroExists(Pasajero.IdPasajero))
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

        private bool PasajeroExists(int id)
        {
            return _context.Pasajeros.Any(e => e.IdPasajero == id);
        }
    }
}