using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoadArt.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoadArt.Controllers
{
    public class DataAddingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void UploadData(string name, string author, string creationYear, string style, string epoch, string medium, int width, 
            int height, string plot, string cost)
        {
            Picture addedPic = new Picture() { 
                Name = name,
                CreationYear = int.Parse(creationYear),
                Style = style,
                Epoch = epoch,
                Medium = medium, 
                Width = width,
                Height = height,
                Plot = plot,
                Cost = long.Parse(cost)
            };

            DataBaseWriter.Write(addedPic);
        }
    }
}
