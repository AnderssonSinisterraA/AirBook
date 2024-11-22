using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AirBook.Pages.Aerolineas
{
    public class EditModel : PageModel
    {
        private readonly AirBookContext _context;

        public EditModel(AirBookContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Asegúrate de que el IdAerolinea tenga un valor válido
            if (Aerolinea == null || Aerolinea.IdAerolinea == 0)
            {
                return BadRequest("Invalid Aerolinea ID.");
            }

            _context.Attach(Aerolinea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AerolineaExists(Aerolinea.IdAerolinea))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AerolineaExists(int id)
        {
            return _context.Aerolineas.Any(e => e.IdAerolinea == id);
        }
    }
}