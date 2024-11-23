using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirBook.Data;
using AirBook.Models;
using System.Linq;
using System.Threading.Tasks;
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
        public SelectList Pasajeros { get; set; }
        public SelectList Vuelos { get; set; }

        public IActionResult OnGet()
        {
            Pasajeros = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
            Vuelos = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Pasajeros = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
                Vuelos = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
                return Page();
            }

            // Verificar que IdPasajero y IdVuelo no sean NULL
            if (Reserva.IdPasajero == 0 || Reserva.IdVuelo == 0)
            {
                ModelState.AddModelError(string.Empty, "Debe seleccionar un pasajero y un vuelo.");
                Pasajeros = new SelectList(_context.Pasajeros, "IdPasajero", "Nombre");
                Vuelos = new SelectList(_context.Vuelos, "IdVuelo", "NumeroVuelo");
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}