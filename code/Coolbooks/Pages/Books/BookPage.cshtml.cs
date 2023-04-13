using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Books
{
    public class BookPageModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book Book { get; set; }
        public Review Review { get; set; }
        //public IEnumerable<Book> Book { get; set; }

        public double TotalRatingSum { get; set; }
        public double OneRatings { get; set; }

        public BookPageModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            //WORKING
            //Review = _db.Reviews.FirstOrDefault(b => b.BookId == id);

            //Get all 1 star ratings
            var oneRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 1)
                              .Sum(x => Convert.ToDouble(x.Rating));

            var totalOneRatingScore = oneRatings * 1;

            //Get all 2 star ratings
            var twoRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 2)
                  .Sum(x => Convert.ToDouble(x.Rating));

            var totalTwoRatingScore = twoRatings * 2;

            //Get all 3 star ratings
            var threeRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 3)
                  .Sum(x => Convert.ToDouble(x.Rating));

            var totalThreeRatingScore = threeRatings * 3;
            //Get all 4 star ratings
            var fourRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 4)
                  .Sum(x => Convert.ToDouble(x.Rating));

            var totalFourRatingScore = fourRatings * 4;
            //Get all 5 star ratings
            var fiveRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 5)
                  .Sum(x => Convert.ToDouble(x.Rating));

            var totalFiveRatingScore = fiveRatings * 5;

            var total = _db.Reviews.Sum(x => Convert.ToDouble(x.Rating));

            var allRating = _db.Reviews.Where(x => x.BookId == id)
.Sum(x => Convert.ToDouble(x.Rating));
            //TotalRatingSum = (totalOneRatingScore + totalTwoRatingScore + totalThreeRatingScore + totalFourRatingScore + totalFiveRatingScore) / total;
            TotalRatingSum = (allRating) / total;


            //TEST




            Book = _db.Books
            .Include("Genre")
            .Include("Author")
            .FirstOrDefault(b => b.BookId == id);
        }
    }
}
