using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.ChoiceAwards
{
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> Books { get; set; }
        public Book? Book { get; set; }
        public double TotalReviews { get; set; }

        public IndexModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Books = _db.Books
            .Include("Genre")
            .Include("Author")
            .Include("Reviews")
            .ToList();

            double highestRatedBookSum = 0;
            int bookId = 0;

            foreach (var book in Books)
            {
                //Get the total sum of all ratings from specific book
                double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == book.BookId).Sum(x => x.Rating));

                //Gets how many ratings that has been done
                var total = _db.Reviews.Where(x => x.BookId == book.BookId).Count();

                double tempSum = Convert.ToDouble((allReviews) / total);
                int tempId = book.BookId;

                if (tempSum > highestRatedBookSum)
                {
                    highestRatedBookSum = tempSum;
                    bookId = tempId;
                    TotalReviews = total;
                }
                //else
                //{
                //    highestRatedBookSum = Convert.ToDouble((allReviews) / total);
                //    bookId = book.BookId;
                //}


            }



            Book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            //Converts it to stringformat and only shows the first decimal
            ////var totalRatingSumString = string.Format("{0:0.0}", totalRatingSum);
            

            //Total number of ratings done
            //var totalRatings = _db.Reviews.Where(x => x.BookId == id).Count();

            //Gets the book and info around it

        }
    }
}
