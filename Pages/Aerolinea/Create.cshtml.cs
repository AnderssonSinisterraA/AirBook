using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AirBook.Data;
using AirBook.Models;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Aerolineas
{
    public class CreateModel : PageModel
    {
        private readonly AirBookContext _context;

        public CreateModel(AirBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AirBook.Models.Aerolinea Aerolinea { get; set; }

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

            _context.Aerolineas.Add(Aerolinea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}