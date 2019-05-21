using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadExample.Models;
using Microsoft.AspNetCore.Mvc;

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
                //Check file extension is a photo

                //reduce photo size

                //generate unique name to retrieve later

                //store photo on file system and reference in DB
                return View();
            }

            return View();
        }
    }
}