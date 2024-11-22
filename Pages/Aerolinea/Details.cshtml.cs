using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;

namespace AirBook.Pages.Aerolineas
{
    public class DetailsModel : PageModel
    {
        private readonly AirBookContext _context;

        public DetailsModel(AirBookContext context)
        {
            _context = context;
        }

        public AirBook.Models.Aerolinea Aerolinea { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Aerolinea = await _context.Aerolineas.FindAsync(id);

            if (Aerolinea == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}