using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Itinerarios
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookContext _context;

        public DeleteModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Itinerario = await _context.Itinerarios.FindAsync(id);

            if (Itinerario != null)
            {
                _context.Itinerarios.Remove(Itinerario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}