//using Coolbooks.Models;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.IO;
//using System.Threading.Tasks;
//namespace RazorPagesForms.Pages
//{
//    public class UploadFileModel : PageModel
//    {
//        //private IHostEnvironment _environment;
//        private readonly CoolbooksContext _db;
//        public UploadFileModel(CoolbooksContext db)
//        {
//            _db = db;
//        }
//        [BindProperty]
//        public IFormFile Upload { get; set; }
//        public async Task OnPostAsync()
//        {
//            var file = Path.Combine(_db., "uploads", Upload.FileName);
//            using (var fileStream = new FileStream(file, FileMode.Create))
//            {
//                await Upload.CopyToAsync(fileStream);
//            }
//        }
//    }
//}