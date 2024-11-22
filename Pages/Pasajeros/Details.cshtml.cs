using AirBook.Data;
using AirBook.Data.AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AirBook.Pages.Pasajeros
{
    public class DetailsModel : PageModel
    {
        private readonly AirBookContext _context;

        public DetailsModel(AirBookContext context)
        {
            _context = context;
        }

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
    }
}