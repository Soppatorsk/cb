using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace Coolbooks.Pages.Statistics
{
    public class IndexModel : PageModel
    {
        public DateTime startDate = DateTime.Now.AddDays(-7).Date;
        public DateTime endDate = DateTime.Now;

        public List<DateTime> dates = new List<DateTime>();
        public List<Comment> Comments = new List<Comment>();
        public List<int> commentCount = new List<int>();

        private readonly CoolbooksContext _db;
        public IndexModel(CoolbooksContext db) => _db = db;
        public void OnGet()
        {
            getStats();
        }
        public void OnPostDateSelect(string sd, string ed)
        {
            startDate = DateTime.Parse(sd);
            endDate = DateTime.Parse(ed);
            getStats();
        }

        public void getStats()
        {

            //Console.WriteLine("start: " + startDate);
            //Console.WriteLine("end: " + endDate);
            Comments = _db.Comments
                .Where(x => x.Created >= startDate && x.Created <= endDate)
                .OrderBy(x => x.Created)
                .ToList();
            for (DateTime d = startDate.Date; d != endDate.Date; d = d.AddDays(1))
            {
                int count = 0;
                dates.Add(d);
                foreach (var c in Comments)
                {
                    //Console.WriteLine(c.Created.GetType());
                    //Console.WriteLine(d.GetType());
                    if (DateToString(c.Created) == DateToString(d)) count++;
                }
                commentCount.Add(count);
            }

        }
        public string DateToString(DateTime? d) //cuts time
        {
            return String.Format($"{d:yyyy-MM-dd}");
        }


    }
}
