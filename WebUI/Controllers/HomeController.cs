using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.WebUI.Models;
using Portfolio.WebUI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.WebUI.Controllers
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
            var model = new List<AlbumsViewModel>(albums.Count());
            
            foreach (var album in albums)
            {
                var photos = await _context.AlbumPhotos
                    .Where(ap => ap.Album.Id == album.Id)
                    .Select(ap => ap.Photo.Id)
                    .ToListAsync();

                var allPhotos = await _context.Photos
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();

                model.Add(new AlbumsViewModel{ 
                    Album = album,
                    Photos = photos,
                    AllPhotos = allPhotos
                });
            }

            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
