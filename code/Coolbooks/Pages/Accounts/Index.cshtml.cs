using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coolbooks.Models;

namespace Coolbooks.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public IndexModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Genre).ToListAsync();
            }
        }
    }
}
