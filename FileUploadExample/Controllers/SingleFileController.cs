using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FileUploadExample.Controllers
{
    public class SingleFileController : Controller
    {
        private readonly IHostingEnvironment _env;

        public SingleFileController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Food item)
        {
            //Either use a viewmodel or remove photoURL. URL will
            //be generated programmatically
            ModelState.Remove(nameof(Food.PhotoUrl));
            item.Id = 0; //SQL Server will generate a new ID

            if (ModelState.IsValid)
            {
                IFormFile photo = item.Photo;
                //Check file extension is a photo
                string extension = 
                       Path.GetExtension(photo.FileName);
                if(extension == ".png" || extension == ".jpg")
                {
                    //TODO: Use ImageSharp to resize uploaded photo
                    //https://www.hanselman.com/blog/HowDoYouUseSystemDrawingInNETCore.aspx

                    //generate unique name to retrieve later
                    string newFileName = Guid.NewGuid().ToString();

                    //store photo on file system and reference in DB
                    if(photo.Length > 0) //ensure the file is not empty
                    {
                        string filePath = Path.Combine(_env.WebRootPath, "images"
                                                    , newFileName + extension);
                        //save location to database (in URL format)
                        item.PhotoUrl = "images/" + newFileName + extension;
                        //write file to file system
                        using(FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            await photo.CopyToAsync(fs);
                        }
                    }

                    return View();
                }
                
            }

            return View();
        }
    }
}