using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FileUploadExample.Controllers
{
    public class SingleFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Food item)
        {
            //Either use a viewmodel or remove photoURL. URL will
            //be generated programmatically
            ModelState.Remove(nameof(Food.PhotoUrl));
            item.Id = 0; //SQL Server will generate a new ID

            if (ModelState.IsValid)
            {
                var photo = item.Photo;
                //Check file extension is a photo
                string extension = 
                       Path.GetExtension(photo.FileName);
                if(extension == ".png" || extension == ".jpg")
                {

                }
                //reduce photo size

                //generate unique name to retrieve later
                string newFileName = Guid.NewGuid().ToString();

                //store photo on file system and reference in DB
                return View();
            }

            return View();
        }
    }
}