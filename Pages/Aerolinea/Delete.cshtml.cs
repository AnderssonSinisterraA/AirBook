using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Aerolineas
{
    public class DeleteModel : PageModel
    {
        private readonly AirBookContext _context;

        public DeleteModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Aerolinea = await _context.Aerolineas.FindAsync(id);

            if (Aerolinea != null)
            {
                _context.Aerolineas.Remove(Aerolinea);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}