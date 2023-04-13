using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coolbooks.Models;

namespace Coolbooks.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly Coolbooks.Models.CoolbooksContext _context;

        public CreateModel(Coolbooks.Models.CoolbooksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Userinfo Userinfo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Userinfos == null || Userinfo == null)
            {
                return Page();
            }

            _context.Userinfos.Add(Userinfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
