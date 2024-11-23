using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly AirBookContext _context;

        public IndexModel(AirBookContext context)
        {
            _context = context;
        }

        public IList<AirBook.Models.Reserva> Reservas { get; set; }

        public async Task OnGetAsync()
        {
            Reservas = await _context.Reservas
                .Include(r => r.Pasajero)
                .Include(r => r.Vuelo)
                .ToListAsync();
        }
    }
}