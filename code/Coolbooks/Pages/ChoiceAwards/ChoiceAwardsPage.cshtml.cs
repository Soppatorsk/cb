using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Coolbooks.Pages.ChoiceAwards
{
    public class ChoiceAwardsPageModel : PageModel
    {
        [BindProperty]
        public int SelectedYear { get; set; }
        public string SelectedGenre { get; set; }
        public int TotalReviews { get; set; }
        public Book? Book { get; set; }
        public Book? BestGenreBook { get; set; }
        public IEnumerable <Genre?> Genres { get; set; }
        public string HighestRatedBookSum { get; set; }
        public string TopGenreBookSum { get; set; }
        public Book? MostReviewdBook { get; set; }              
        public bool IsSet { get; set; }
        private readonly CoolbooksContext _db;
        public ChoiceAwardsPageModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet(int year, string genre)
        {

            Genres = _db.Genres.ToList();
            SelectedGenre = genre;

            IsSet = true;
            SelectedYear = year;

            if(year > 0)
            {
                if (genre != null)
                {
                    BestGenreBook = GetTopBookGenre(year, genre);
                }
                Book = GetTopBook(year);
                MostReviewdBook = GetMostReviewed(year);
            }
        }
        public IActionResult OnPost()
        {
            SelectedYear = Convert.ToInt32(Request.Form["year"]);
            SelectedGenre = Request.Form["genre"];

            return RedirectToPage("ChoiceAwardsPage", new { year = SelectedYear,
                                                                    genre = SelectedGenre
                                                                                        });
        }
        public Book GetTopBook(int year)
        {

            //Creates two datetimes to check all the books that are between these two dates.
            DateTime date = new DateTime(year, 1, 1);
            DateTime dateTwo = new DateTime(year +1, 1, 1); 

                var booksFirst = _db.Books
                .Include("Genre")
                .Include("Author")
                .Include("Reviews")
                .Where(x => x.Created > date && x.Created < dateTwo)
                .ToList();
            


            double highestRatedBookSum = 0;
            int bookId = 0;

            foreach (var bestBook in booksFirst)
            {
                //Get the total sum of all ratings from specific book
                double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == bestBook.BookId).Sum(x => x.Rating));

                //Gets how many ratings that has been done
                var total = _db.Reviews.Where(x => x.BookId == bestBook.BookId).Count();

                double tempSum = Convert.ToDouble((allReviews) / total);
                int tempId = bestBook.BookId;

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
                HighestRatedBookSum = string.Format("{0:0.0}", highestRatedBookSum);

            }


            Book? book = _db.Books.FirstOrDefault(x => x.BookId == bookId);
            return book;
        }
        public Book GetMostReviewed(int year)
        {
            DateTime date = new DateTime(year, 1, 1);
            DateTime dateTwo = new DateTime(year + 1, 1, 1);

            var bookList = _db.Books
                .Include("Genre")
                .Include("Author")
                .Include("Reviews")
                .Where(x => x.Created > date && x.Created < dateTwo)
                .ToList();

            double highestRatedBook = 0;
            int bookId = 0;

            foreach (var bestBook in bookList)
            {
                //Get the total sum of all ratings from specific book
                double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == bestBook.BookId).Sum(x => x.Rating));

                //Gets how many ratings that has been done
                var total = _db.Reviews.Where(x => x.BookId == bestBook.BookId).Count();

                double tempSum = Convert.ToDouble((allReviews) / total);
                int tempId = bestBook.BookId;

                if (total > highestRatedBook)
                {
                    highestRatedBook = total;
                    bookId = tempId;
                    TotalReviews = total;
                }
            }
            Book? book = _db.Books.FirstOrDefault(x => x.BookId == bookId);

            return book;
        }
        public Book GetTopBookGenre(int year, string genre)
        {
            //Creates two datetimes to check all the books that are between these two dates.
            DateTime date = new DateTime(year, 1, 1);
            DateTime dateTwo = new DateTime(year + 1, 1, 1);

            var booksFirst = _db.Books
            .Include("Genre")
            .Include("Author")
            .Include("Reviews")
            .Where(x => x.Created > date && x.Created < dateTwo)
            .ToList();



            double highestRatedBookSum = 0;
            int bookId = 0;
            var test = booksFirst.Any(x => Convert.ToString(x.Genre.Name) == genre);

            foreach (var bestBook in booksFirst)
            {


                if (test == false)
                {
                    return null;
                }

                //Get the total sum of all ratings from specific book
                double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == bestBook.BookId && x.Book.Genre.Name == genre).Sum(x => x.Rating));

                //Gets how many ratings that has been done
                var total = _db.Reviews.Where(x => x.BookId == bestBook.BookId && x.Book.Genre.Name == genre).Count();

                double tempSum = Convert.ToDouble((allReviews) / total);
                int tempId = bestBook.BookId;

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
                TopGenreBookSum = string.Format("{0:0.0}", highestRatedBookSum);

            }


            Book? book = _db.Books.FirstOrDefault(x => x.BookId == bookId);
            return book;
        }
    }
}
