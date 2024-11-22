using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly AirBookContext _context;

        public CreateModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Reserva Reserva { get; set; }

        public IActionResult OnGet()
        {
            ViewData["PasajeroId"] = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
            ViewData["VueloId"] = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}