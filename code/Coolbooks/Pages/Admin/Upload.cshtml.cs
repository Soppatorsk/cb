using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;

public class UploadModel : PageModel
{
	private readonly IWebHostEnvironment _environment;

	public UploadModel(IWebHostEnvironment environment)
	{
		_environment = environment;
	}

	public string Message { get; set; }

	public void OnGet()
	{

	}

	public void OnPostUpload(List<IFormFile> postedFiles)
	{
		string wwwPath = _environment.WebRootPath;

		string contentPath = _environment.ContentRootPath;

		string path = Path.Combine(_environment.WebRootPath, "Images");
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}

		List<string> uploadedFiles = new List<string>();
		foreach (IFormFile postedFile in postedFiles)
		{
			string fileName = Path.GetFileName(postedFile.FileName);
			using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
			{
				postedFile.CopyTo(stream);
				uploadedFiles.Add(fileName);
				Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
			}
		}
	}
}
