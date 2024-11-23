using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirBook.Data;
using AirBook.Models;
using System.Linq;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Vuelos
{
    public class CreateModel : PageModel
    {
        private readonly AirBookContext _context;

        public CreateModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Vuelo Vuelo { get; set; }
        public SelectList Aerolineas { get; set; }

        public IActionResult OnGet()
        {
            Aerolineas = new SelectList(_context.Aerolineas, "IdAerolinea", "NombreAerolinea");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Aerolineas = new SelectList(_context.Aerolineas, "IdAerolinea", "NombreAerolinea");
                return Page();
            }

            _context.Vuelos.Add(Vuelo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}