using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Net;

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
        public Like Like { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Comment?> Comments { get; set; }
        public int LikeCount { get; set; }

        public IEnumerable<Like> LikeList { get; set; }
        public bool LikeExist { get; set; }

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
            .Include(l => l.Likes) //Ta bort om det strular... Denna rad används inte just nu.
            .OrderByDescending(x => x.Created)
            .ToList();

            LikeList = _db.Likes.Include("Review")
                .Include("Comment")
                .ToList();

            //A try to print out the amount of likes in each bookpage. 
            //it is used in the cshtml file. You can see it in one of the foreachloops
            LikeCount = (
    from review in _db.Reviews
    join like in _db.Likes on review.ReviewId equals like.ReviewId
    where review.BookId == id
    select like
    ).Count();


            Comments = _db.Comments.Include(x => x.User)
                .ThenInclude(u => u.Userinfo)
                .Include(r => r.Review)
                .Where(r => r.Review.BookId == id)
                .OrderByDescending(x => x.Created);

        }
        public async Task<IActionResult> OnPostLike(Like like, int id)
        {
            int bookId = id;

            var likeFromDb = _db.Likes.FirstOrDefault(x => x.UserId == like.UserId && x.ReviewId == like.ReviewId);

            if (likeFromDb != null)
            {
                if (likeFromDb.Like1 == "Like" && like.Like1 == "Dislike")
                {
                    likeFromDb.Like1 = like.Like1;
                    _db.SaveChanges();
                    return RedirectToPage("BookPage", new { id = bookId });
                }
                else if (likeFromDb.Like1 == "Dislike" && like.Like1 == "Like")
                {
                    likeFromDb.Like1 = like.Like1;
                    _db.SaveChanges();
                    return RedirectToPage("BookPage", new { id = bookId });
                }
                else
                {
                    _db.Likes.Remove(likeFromDb);
                    _db.SaveChanges();
                    return RedirectToPage("BookPage", new { id = bookId });
                }
            }
            else
            {
                await _db.Likes.AddAsync(like);
                await _db.SaveChangesAsync();
                return RedirectToPage("BookPage", new { id = bookId });
            }
        }
        public async Task<IActionResult> OnPostComment(Comment comment, int id)
        {
            int bookId = id;
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();
            return RedirectToPage("BookPage", new { id = bookId });
        }
    }
}
