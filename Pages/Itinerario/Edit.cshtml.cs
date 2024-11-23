using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Itinerarios
{
    public class EditModel : PageModel
    {
        private readonly AirBookContext _context;

        public EditModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Itinerario Itinerario { get; set; }

        public IActionResult OnGet(int id)
        {
            Itinerario = _context.Itinerarios
                .Include(i => i.Reserva)
                .FirstOrDefault(m => m.IdItinerario == id);

            if (Itinerario == null)
            {
                return NotFound();
            }

            ViewData["ReservaId"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Itinerario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioExists(Itinerario.IdItinerario))
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

        private bool ItinerarioExists(int id)
        {
            return _context.Itinerarios.Any(e => e.IdItinerario == id);
        }
    }
}