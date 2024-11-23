using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;

namespace AirBook.Pages.Reservas
{
    public class DetailsModel : PageModel
    {
        private readonly AirBookContext _context;

        public DetailsModel(AirBookContext context)
        {
            _context = context;
        }

        public AirBook.Models.Reserva Reserva { get; set; }

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
            return Page();
        }
    }
}