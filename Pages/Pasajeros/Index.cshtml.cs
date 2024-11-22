using AirBook.Data;
using AirBook.Data.AirBook.Data;
using AirBook.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace AirBook.Pages.Pasajeros
{
    public class IndexModel : PageModel
    {
        private readonly AirBookContext _context;

        public IndexModel(AirBookContext context)
        {
            _context = context;
        }

        public IList<Pasajero> Pasajeros { get; set; }

        public async Task OnGetAsync()
        {
            Pasajeros = await _context.Pasajeros.ToListAsync();
        }
    }
}