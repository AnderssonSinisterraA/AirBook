using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AirBook.Pages.Reservas
{
    public class EditModel : PageModel
    {
        private readonly AirBookContext _context;

        public EditModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Reserva Reserva { get; set; }
        public SelectList Pasajeros { get; set; }
        public SelectList Vuelos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reserva = await _context.Reservas
                .Include(r => r.Pasajero)
                .Include(r => r.Vuelo)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (Reserva == null)
            {
                return NotFound();
            }

            Pasajeros = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
            Vuelos = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Pasajeros = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
                Vuelos = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
                return Page();
            }

            _context.Attach(Reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(Reserva.IdReserva))
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

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}