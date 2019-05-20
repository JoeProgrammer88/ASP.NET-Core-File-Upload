using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadExample.Controllers
{
    public class SingleFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}