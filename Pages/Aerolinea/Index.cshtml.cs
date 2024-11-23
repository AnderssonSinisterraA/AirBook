using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AirBook.Data;
using AirBook.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirBook.Data.AirBook.Data;

namespace AirBook.Pages.Aerolineas
{
    public class IndexModel : PageModel
    {
        private readonly AirBookContext _context;

        public IndexModel(AirBookContext context)
        {
            _context = context;
        }

        public IList<AirBook.Models.Aerolinea> Aerolineas { get; set; }

        public async Task OnGetAsync()
        {
            Aerolineas = await _context.Aerolineas.ToListAsync();
        }
    }
}