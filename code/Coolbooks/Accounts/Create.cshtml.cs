using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Coolbooks.Models;

namespace Coolbooks.Accounts
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
        public AspNetUser AspNetUser { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AspNetUsers == null || AspNetUser == null)
            {
                return Page();
            }

            _context.AspNetUsers.Add(AspNetUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
