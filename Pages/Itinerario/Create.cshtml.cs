using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Itinerarios
{
    public class CreateModel : PageModel
    {
        private readonly AirBookContext _context;

        public CreateModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Itinerario Itinerario { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ReservaId"] = new SelectList(_context.Reservas, "IdReserva", "IdReserva");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Itinerarios.Add(Itinerario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}