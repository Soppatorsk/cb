using Azure.Identity;
using Coolbooks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Security.Principal;

namespace Coolbooks.Pages.Reviews
{
    public class ReadModel : PageModel
    {
        public Book? Book { get; set; }
        public Review? Review { get; set; }
        public AspNetUser? AspNetUser { get; set; }
        public AspNetUser tmpUser { get; set; }
        public Like NewLike = new Like();

        public Like ExistantUserLike { get; set; }

        public Comment Comment = new Comment();
        public string UserFullName { get; set; }
        public string AuthorFullName = string.Empty;
        public int Likes = 0;
        public int Dislikes = 0;

        public List<Comment> Comments = new List<Comment>();
        private readonly CoolbooksContext _db;
        public ReadModel(CoolbooksContext db) => _db = db;

        public void LoadPage(int id)
        {

            //TODO tmp
            tmpUser = _db.AspNetUsers.FirstOrDefault();

            Review = _db.Reviews
           .Include("Book")
           .FirstOrDefault(b => b.ReviewId == id);

            Book = _db.Books
                .Include("Author")
                .FirstOrDefault(b => b.BookId == Review.BookId);

            AspNetUser = _db.AspNetUsers

              .FirstOrDefault(b => b.Id == Review.Id);

            UserFullName = AspNetUser.UserName ;
            AuthorFullName = Review.Book.Author.Firstname  ;

            //Likes
            Likes = _db.Likes.Where(x => x.ReviewId == id && x.Like1 == "Like")
                .Count();

            Dislikes = _db.Likes.Where(x => x.ReviewId == id && x.Like1 == "Dislike")
                .Count();

            ExistantUserLike = _db.Likes.Where(x => x.ReviewId == id ).FirstOrDefault();

            //Comments
            //TODO
            Comments = _db.Comments.Include("IdNavigation")
                .Where(x => x.ReviewId == id)
                .ToList();
        }
        public void OnGet(int id)
        {
            LoadPage(id);
        }

        public void OnPostFlag(int id)
        {
            LoadPage(id);

			Review = _db.Reviews
            .Where(r => r.ReviewId == id).FirstOrDefault();
            Review.Status = "Flagged";
            _db.SaveChanges();
        }

        public void OnPostFlagComment(int id, int CommentId)
        {
            LoadPage(id);
			Comment = _db.Comments
            .Where(r => r.CommentId == CommentId).FirstOrDefault();
            Comment.Status = "Flagged";
            _db.SaveChanges();

        }

        public void OnPostRemove(int id)
        {
            LoadPage(id);

			Review = _db.Reviews
            .Where(r => r.ReviewId == id).FirstOrDefault();
            Review.Status = "Removed";
            _db.SaveChanges();

        }

        public void OnPostLike(int id)
        {
            LoadPage(id);

            Review = _db.Reviews.Where(r => r.ReviewId == id).FirstOrDefault();  
            
                NewLike.ReviewId = id;
                NewLike.Like1 = Request.Form["Vote"];

                //TODO user
                NewLike.Id = tmpUser.Id; 

                if (ExistantUserLike == null) _db.Add(NewLike);
                _db.SaveChanges();
        }

        public void OnPostComment(int id)
        {
            LoadPage(id);

            Comment.Text = Request.Form["text"];
            Comment.ReviewId = id;
            Comment.Created = DateTime.Now;
            //TODO error if empty, cant comment review
            try
            {
            Comment.ParentCommentId = int.Parse(Request.Form["CommentParentId"]);

            } catch
            {
                Console.WriteLine("hehe");
            }

            //TODO user
            Comment.Id = tmpUser.Id; 

            _db.Add(Comment);
            _db.SaveChanges();
        }

    }
}
