using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coolbooks.Models;

namespace Coolbooks.Pages.Shared.Account
{
    public class DeleteModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public DeleteModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Userinfos == null)
            {
                return NotFound();
            }
            var userinfo = await _context.Userinfos.FindAsync(id);

            if (userinfo != null)
            {
                Userinfo = userinfo;
                _context.Userinfos.Remove(Userinfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
