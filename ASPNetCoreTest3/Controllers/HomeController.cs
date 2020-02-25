using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreTest3.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreTest3.Controllers
{
    public class HomeController : Controller
    {
        private readonly PhotoContext _context;

        public HomeController(PhotoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var albums = await _context.Albums.OrderByDescending(a => a.Date).ToListAsync();
            var photosSrc = new List<string>(albums.Count());
            
            foreach (var album in albums)
            {
                var albumPhoto = await _context.AlbumPhotos.Include(ap => ap.Photo)
                    .FirstOrDefaultAsync(ap => ap.Album.Id == album.Id);
                string src = albumPhoto?.Photo.LowSource;

                if (src != null)
                    photosSrc.Add(src);
            }

            ViewBag.PhotosSrc = photosSrc;

            return View(albums);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
