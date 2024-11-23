using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AirBook.Pages.Itinerarios
{
    public class DetailsModel : PageModel
    {
        private readonly AirBookContext _context;

        public DetailsModel(AirBookContext context)
        {
            _context = context;
        }

        public AirBook.Models.Itinerario Itinerario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Itinerario = await _context.Itinerarios
                .Include(i => i.Reserva)
                .FirstOrDefaultAsync(m => m.IdItinerario == id);

            if (Itinerario == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}