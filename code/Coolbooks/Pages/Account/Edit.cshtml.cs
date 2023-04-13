using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coolbooks.Models;

namespace Coolbooks.Pages.Shared.Account
{
    public class EditModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public EditModel(Coolbooks.Models.CoolbooksContext context)
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

            var userinfo =  await _context.Userinfos.FirstOrDefaultAsync(m => m.UserInfoId == id);
            if (userinfo == null)
            {
                return NotFound();
            }
            Userinfo = userinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Userinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserinfoExists(Userinfo.UserInfoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserinfoExists(int id)
        {
          return (_context.Userinfos?.Any(e => e.UserInfoId == id)).GetValueOrDefault();
        }
    }
}
