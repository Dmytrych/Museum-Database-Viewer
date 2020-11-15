using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoadArt.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace LoadArt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public void LoadData()
        {
            string name = "asd";
            using ( MuseumContext db = new MuseumContext())
            {
                db.Pictures.Load();
                name = db.Pictures.First().Name;
            }
            PictureModel[] models = new PictureModel[3];
            models[0] = new PictureModel() { Author = name, Name = "Mishki" };
            models[1] = new PictureModel() { Author = "Van-Gogh", Name = "The Starry Night" };
            models[2] = new PictureModel() { Author = "Da-Vinci", Name = "Mona-Lisa" };
            var jsonData = JsonConvert.SerializeObject(models);
            var stopWriteToken = new CancellationToken(false);
            Response.WriteAsync(jsonData, stopWriteToken);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
