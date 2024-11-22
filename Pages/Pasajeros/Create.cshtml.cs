using AirBook.Data;
using AirBook.Data.AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AirBook.Pages.Pasajeros
{
    public class CreateModel : PageModel
    {
        private readonly AirBookContext _context;

        public CreateModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pasajero Pasajero { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pasajeros.Add(Pasajero);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}