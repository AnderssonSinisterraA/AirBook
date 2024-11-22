using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Agregar un mensaje de depuración para verificar el estado del modelo
                Console.WriteLine("ModelState no es válido");
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            _context.Vuelos.Add(Vuelo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}