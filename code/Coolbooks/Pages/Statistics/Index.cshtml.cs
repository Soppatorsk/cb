using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace Coolbooks.Pages.Statistics
{
    public class IndexModel : PageModel
    {
        public DateTime OriginDate ;
        public List<Comment>[] a = new List<Comment>[7] ;
        public List<DateTime> dateTimes = new List<DateTime>();

        private readonly CoolbooksContext _db;
        public IndexModel(CoolbooksContext db) => _db = db;

        public void OnGet()
        {
            OriginDate = DateTime.Today;
            for (int  i = 0; i < 7; i++)
            {
                dateTimes.Add(OriginDate.AddDays(-i));
                List<Comment> c = _db.Comments.Where(x => x.Created >= OriginDate.AddDays(-i - 1) 
                && x.Created <= OriginDate.AddDays(-i))
                    .ToList();
                a[i] = c;
			}
        }
    }
}
