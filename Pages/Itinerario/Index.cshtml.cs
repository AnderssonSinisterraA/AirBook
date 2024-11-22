using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Itinerarios
{
    public class IndexModel : PageModel
    {
        private readonly AirBookContext _context;

        public IndexModel(AirBookContext context)
        {
            _context = context;
        }

        public IList<AirBook.Models.Itinerario> Itinerarios { get; set; }

        public async Task OnGetAsync()
        {
            Itinerarios = await _context.Itinerarios
                .Include(i => i.Reserva)
                .ToListAsync();
        }
    }
}
