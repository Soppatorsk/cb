using Coolbooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Coolbooks.Pages.ChoiceAwards
{
    public class IndexModel : PageModel
    {
        private readonly CoolbooksContext _db;
        public IEnumerable<Book> BooksFirst { get; set; }
        public List<Book> TopBooks { get; set; }
        public Book? FirstYearBook { get; set; }
        public Book? SecondYearBook { get; set; }
        public Book? ThirdYearBook { get; set; }
        public double TotalReviews { get; set; }
        public DateTime DateTime { get; set; }


        public int CurrentYear { get; set; }
        public int SecondYear { get; set; }
        public int ThirdYear { get; set; }


        [BindProperty]
        public int SelectedYear { get; set; }
        public IndexModel(CoolbooksContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            DateTime now = DateTime.Now;
            CurrentYear = now.Year;
            SecondYear = now.Year -1;
            ThirdYear = now.Year -2;

            DateTime dateFirst = new DateTime(now.Year, 1, 1);
            DateTime dateSecond = new DateTime(now.Year -1, 1, 1);
            DateTime dateThird = new DateTime(now.Year -2, 1, 1);

            //DateTime = dateFirst;
            //BooksFirst = _db.Books
            //.Include("Genre")
            //.Include("Author")
            //.Include("Reviews")
            //.Where(x => x.Created > dateFirst)
            //.ToList();

            //double highestRatedBookSum = 0;
            //int bookId = 0;

            //foreach (var book in BooksFirst)
            //{
            //    //Get the total sum of all ratings from specific book
            //    double allReviews = Convert.ToDouble(_db.Reviews.Where(x => x.BookId == book.BookId).Sum(x => x.Rating));

            //    //Gets how many ratings that has been done
            //    var total = _db.Reviews.Where(x => x.BookId == book.BookId).Count();

            //    double tempSum = Convert.ToDouble((allReviews) / total);
            //    int tempId = book.BookId;

            //    if (tempSum > highestRatedBookSum)
            //    {
            //        highestRatedBookSum = tempSum;
            //        bookId = tempId;
            //        TotalReviews = total;
            //    }
            //    //else
            //    //{
            //    //    highestRatedBookSum = Convert.ToDouble((allReviews) / total);
            //    //    bookId = book.BookId;
            //    //}


            //}

            FirstYearBook = GetTopBook(now.Year, 1);
            SecondYearBook = GetTopBook(now.Year -1, 2);
            ThirdYearBook = GetTopBook(now.Year - 2, 3);

        }
        public Book GetTopBook(int year, int yearValue)
        {


            DateTime date = new DateTime(year, 1, 1);
            DateTime date2 = new DateTime(year +1, 1, 1);
            //DateTime date3 = new DateTime(year, 1, 1);

            if(yearValue == 1)
            {
                BooksFirst = _db.Books
                .Include("Genre")
                .Include("Author")
                .Include("Reviews")
                .Where(x => x.Created > date)
                .ToList();
            }
            else if (yearValue == 2)
            {
                BooksFirst = _db.Books
                .Include("Genre")
                .Include("Author")
                .Include("Reviews")
                .Where(x => x.Created > date && x.Created < date2)
                .ToList();
            }
            else if (yearValue == 3)
            {
                BooksFirst = _db.Books
                .Include("Genre")
                .Include("Author")
                .Include("Reviews")
                .Where(x => x.Created > date && x.Created < date2)
                .ToList();
            }


            double highestRatedBookSum = 0;
            int bookId = 0;

            foreach (var bestBook in BooksFirst)
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


            }
            Book? book = _db.Books.FirstOrDefault(x => x.BookId == bookId);
            return book;
        }
        public IActionResult OnPost()
        {
            // do something with the selected year
            // ...

            return RedirectToPage("Index", new { year = SelectedYear });
        }
    }
}
