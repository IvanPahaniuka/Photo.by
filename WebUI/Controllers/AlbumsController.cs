using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio.WebUI.Models;
using Portfolio.WebUI.ViewModels;

namespace Portfolio.WebUI.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly PhotoContext _context;

        public AlbumsController(PhotoContext context)
        {
            _context = context;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Albums.OrderByDescending(a => a.Date).ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            var allPhotos = await _context.Photos
                .OrderByDescending(p => p.Id).ToListAsync();
            var photos = await _context.AlbumPhotos
                .Where(ap => ap.Album.Id == album.Id)
                .Select(ap => ap.Photo.Id)
                .ToListAsync();

            var model = new AlbumsViewModel{ 
                Album = album,
                Photos = photos,
                AllPhotos = allPhotos
                };

            return View(model);
        }

        // GET: Albums/Create
        public async Task<IActionResult> Create()
        {
            var allPhotos = await _context.Photos.OrderByDescending(p => p.Id).ToListAsync();

            var model = new AlbumsViewModel{ 
                Album = new Album(), 
                Photos = new List<int>(),
                AllPhotos =  allPhotos
                };

            return View(model);
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlbumsViewModel model)
        {
            if (ModelState.IsValid)
            {
                await UpdateAlbumPhotos(
                    album: model.Album, 
                    photos: model.Photos);

                _context.Albums.Add(model.Album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            var allPhotos = await _context.Photos
                .OrderByDescending(p => p.Id).ToListAsync();
            var photos = await _context.AlbumPhotos
                .Where(ap => ap.Album.Id == album.Id)
                .Select(ap => ap.Photo.Id)
                .ToListAsync();

            var model = new AlbumsViewModel{ 
                Album = album,
                Photos = photos,
                AllPhotos = allPhotos
                };

            return View(model);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlbumsViewModel model)
        {
            if (id != model.Album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await UpdateAlbumPhotos(model.Album, model.Photos);

                    _context.Entry(model.Album).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(model.Album.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (album == null)
            {
                return NotFound();
            }

            var allPhotos = await _context.Photos
                .OrderByDescending(p => p.Id).ToListAsync();
            var photos = await _context.AlbumPhotos
                .Where(ap => ap.Album.Id == album.Id)
                .Select(ap => ap.Photo.Id)
                .ToListAsync();

            var model = new AlbumsViewModel{ 
                Album = album,
                Photos = photos,
                AllPhotos = allPhotos
                };

            return View(model);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.Id == id);
        }

        private async Task UpdateAlbumPhotos(Album album, IEnumerable<int> photos)
        {
            int id = album.Id;
            var apRangeToRemove = await _context.AlbumPhotos.Where(ap => ap.Album.Id == id).ToArrayAsync();
            _context.AlbumPhotos.RemoveRange(apRangeToRemove);


            var apRange = new List<AlbumPhotos>(photos.Count());
            foreach (var photo in photos)
                apRange.Add(new AlbumPhotos { 
                    Album = album, 
                    Photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == photo) 
                });

            await _context.AlbumPhotos.AddRangeAsync(apRange);
        }
    }
}
