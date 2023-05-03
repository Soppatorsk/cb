using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coolbooks.Models;

namespace Coolbooks.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public IndexModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

        public IList<AspNetUser> AspNetUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AspNetUsers != null)
            {
                AspNetUser = await _context.AspNetUsers.ToListAsync();
            }
        }
    }
}
