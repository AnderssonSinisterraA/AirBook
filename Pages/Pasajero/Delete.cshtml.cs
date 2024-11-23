using AirBook.Data;
using AirBook.Data.AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AirBook.Pages.Pasajeros
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookContext _context;

        public DeleteModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Pasajero Pasajero { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pasajero = await _context.Pasajeros.FindAsync(id);

            if (Pasajero == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Pasajero = await _context.Pasajeros.FindAsync(id);

            if (Pasajero != null)
            {
                _context.Pasajeros.Remove(Pasajero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}