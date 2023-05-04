using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Statistics
{
    public class IndexModel : PageModel
    {
        public DateTime startDate = DateTime.Now.AddDays(-7).Date;
        public DateTime endDate = DateTime.Now;
        public int? author = null;
        public int? genre = null;

        public List<DateTime> dates = new List<DateTime>();
        public List<Comment> Comments = new List<Comment>();
        public List<int> commentCount = new List<int>();

		public List<SelectListItem> Genres { get; set; }
		public List<SelectListItem> Authors { get; set; }

        private readonly CoolbooksContext _db;
        public IndexModel(CoolbooksContext db) => _db = db;
        public void OnGet()
        {
            LoadPage();
            getStats();
        }
        public void OnPostDateSelect(string sd, string ed, int? genre, int? author)
        {
            LoadPage();
            startDate = DateTime.Parse(sd);
            endDate = DateTime.Parse(ed);
            this.genre = genre;
            this.author = author;
            getStats();
        }

        public void LoadPage()
        {
            Genres = _db.Genres.Select(a =>
			new SelectListItem
			{
				Value = a.GenreId.ToString(),
				Text = a.Name
			}).ToList();

            Authors = _db.Authors.Select(a =>
			new SelectListItem
			{
				Value = a.AuthorId.ToString(),
				Text = a.Lastname + ", " + a.Firstname
			}
            ).ToList();

        }

        public void getStats()
        {
            var query = _db.Comments.AsQueryable();
            query = query.Where(x => x.Created >= startDate && x.Created <= endDate);
            if (genre != null)
            {
                Console.Write(genre.ToString());    
                query = query.Where(x => x.Review.Book.GenreId == genre);
            }
            if (author != null)
            {
                query = query.Where(x => x.Review.Book.AuthorId == author);
            }
            query =  query.OrderBy(x => x.Created);
            Comments = query.ToList();

            for (DateTime d = startDate.Date; d != endDate.Date; d = d.AddDays(1))
            {
                int count = 0;
                dates.Add(d);
                foreach (var c in Comments) //TODO inefficient?
                {
                    if (DateToString(c.Created) == DateToString(d)) count++;
                }
                commentCount.Add(count);
            }
        }
        public void getStatsBak()
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
                foreach (var c in Comments) //TODO inefficient?
                {
                    if (DateToString(c.Created) == DateToString(d)) count++;
                }
                commentCount.Add(count);
            }
        }
        public string DateToString(DateTime? d) //also cut off time
        {
            return String.Format($"{d:yyyy-MM-dd}");
        }
    }
}
