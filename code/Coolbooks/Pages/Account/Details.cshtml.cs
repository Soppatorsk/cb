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
    public class DetailsModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public DetailsModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

      public Userinfo Userinfo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Userinfos == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfos.FirstOrDefaultAsync(m => m.UserInfoId == id);
            if (userinfo == null)
            {
                return NotFound();
            }
            else 
            {
                Userinfo = userinfo;
            }
            return Page();
        }
    }
}
