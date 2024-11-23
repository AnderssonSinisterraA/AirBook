using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;

namespace AirBook.Pages.Vuelos
{
    public class DetailsModel : PageModel
    {
        private readonly AirBookContext _context;

        public DetailsModel(AirBookContext context)
        {
            _context = context;
        }

        public AirBook.Models.Vuelo Vuelo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vuelo = await _context.Vuelos
                .Include(v => v.Aerolinea)
                .FirstOrDefaultAsync(m => m.IdVuelo == id);

            if (Vuelo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}