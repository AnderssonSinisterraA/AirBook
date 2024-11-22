using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult OnGet(int id)
        {
            Reserva = _context.Reservas
                .Include(r => r.Pasajero)
                .Include(r => r.Vuelo)
                .FirstOrDefault(m => m.IdReserva == id);

            if (Reserva == null)
            {
                return NotFound();
            }

            ViewData["PasajeroId"] = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
            ViewData["VueloId"] = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
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