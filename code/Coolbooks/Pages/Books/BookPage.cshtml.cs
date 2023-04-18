using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Coolbooks.Pages.Books
{
    public class BookPageModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public Book? Book { get; set; }
        public IEnumerable<Review?> Reviews { get; set; }
        public double? TotalRatingSum { get; set; }
        public string TotalRatingSumString { get; set; }
        public double TotalRatings { get; set; }
        public double Total { get; set; }
        public bool CommentField { get; set; }
        public Like Like { get; set; }

        public BookPageModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {

            //Get the total sum of all ratings from specific book
             double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == id).Sum(x => x.Rating));
            var total = _db.Reviews.Where(x => x.BookId == id).Count();

            //Gets all the Ratings of datatype Double so that 
            //it is possible to use the numeric type in BookPage.cshtml
            TotalRatingSum = Convert.ToDouble((allReviews) / total);

            //Converts it to stringformat and only shows the first decimal
            TotalRatingSumString = string.Format("{0:0.0}", TotalRatingSum);
            //TotalRatingSum = (allRating) / total;

            //Total number of ratings done
            TotalRatings = _db.Reviews.Where(x => x.BookId == id).Count();

            //Gets the book and info around it
            Book = _db.Books
            .Include("Genre")
            .Include("Author")
            .FirstOrDefault(b => b.BookId == id);


            Reviews = _db.Reviews
            .Where(r => r.BookId == id)
            .Include(r => r.User)
            .ThenInclude(u => u.Userinfo)
            .OrderByDescending(x => x.Created)
            .ToList();

        }
        public async Task<IActionResult> OnPostLike(Like like, int bookId)
        {


            await _db.Likes.AddAsync(like);
            await _db.SaveChangesAsync();
            return RedirectToPage("BookPage");
        }
        ////////RATING
        /////
        ////Get all 1 star ratings
        //var oneRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 1)
        //                  .Sum(x => Convert.ToDouble(x.Rating));

        //var totalOneRatingScore = oneRatings * 1;

        ////Get all 2 star ratings
        //var twoRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 2)
        //      .Sum(x => Convert.ToDouble(x.Rating));

        //var totalTwoRatingScore = twoRatings * 2;

        ////Get all 3 star ratings
        //var threeRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 3)
        //      .Sum(x => Convert.ToDouble(x.Rating));

        //var totalThreeRatingScore = threeRatings * 3;
        ////Get all 4 star ratings
        //var fourRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 4)
        //      .Sum(x => Convert.ToDouble(x.Rating));

        //var totalFourRatingScore = fourRatings * 4;
        ////Get all 5 star ratings
        //var fiveRatings = _db.Reviews.Where(x => x.BookId == id && Convert.ToDouble(x.Rating) == 5)
        //      .Sum(x => Convert.ToDouble(x.Rating));
    }
}
