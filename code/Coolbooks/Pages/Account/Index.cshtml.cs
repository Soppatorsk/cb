using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coolbooks.Models;

namespace Coolbooks.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public IndexModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

        public IList<Userinfo> Userinfo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                Userinfo = await _context.Userinfos.ToListAsync();
            }
        }
    }
}
