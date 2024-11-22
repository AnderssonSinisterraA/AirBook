using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookContext _context;

        public DeleteModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Reserva Reserva { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Reserva = await _context.Reservas
                .Include(r => r.Pasajero)
                .Include(r => r.Vuelo)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (Reserva == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Reserva = await _context.Reservas.FindAsync(id);

            if (Reserva != null)
            {
                _context.Reservas.Remove(Reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}