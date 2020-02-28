using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.WebUI.Controllers
{
    public class AlbumController : Controller
    {
        private readonly PhotoContext _context;

        public AlbumController(PhotoContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            var albumPhotos = await _context.AlbumPhotos
                .Include(ap => ap.Photo)
                .Where(ap => ap.Album.Id == album.Id)
                .ToListAsync();

            var photos = new List<Models.Photo>(albumPhotos.Count);

            foreach (var albumPhoto in albumPhotos)
                photos.Add(albumPhoto.Photo);

            ViewBag.Photos = photos;
            return View(album);
        }
    }
}