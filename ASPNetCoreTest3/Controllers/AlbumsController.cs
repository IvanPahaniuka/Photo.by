using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreTest3.Models;

namespace ASPNetCoreTest3.Controllers
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

            ViewBag.AlbumPhotos = await _context.AlbumPhotos.Where(ap => ap.Album.Id == id)
                .Include(ap => ap.Photo).ToListAsync();
            return View(album);
        }

        // GET: Albums/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.PhotosList = await _context.Photos.OrderByDescending(p => p.Id).ToListAsync();
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Date")] Album album, int[] Photos)
        {
            if (ModelState.IsValid)
            {
                await UpdateAlbumPhotos(album, Photos);

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
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

            ViewBag.PhotosList = await _context.Photos.OrderByDescending(p => p.Id).ToListAsync();
            ViewBag.AlbumPhotos = await _context.AlbumPhotos.Where(ap => ap.Album.Id == id)
                .Include(ap => ap.Photo).ToListAsync();
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date")] Album album, int[] Photos)
        {
            if (id != album.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await UpdateAlbumPhotos(album, Photos);

                    _context.Entry(album).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.Id))
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
            return View(album);
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

            return View(album);
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

        private async Task UpdateAlbumPhotos(Album album, int[] Photos)
        {
            int id = album.Id;
            var apRangeToRemove = await _context.AlbumPhotos.Where(ap => ap.Album.Id == id).ToArrayAsync();
            _context.AlbumPhotos.RemoveRange(apRangeToRemove);



            var apRange = new List<AlbumPhotos>(Photos.Length);
            foreach (var photo in Photos)
                apRange.Add(new AlbumPhotos { 
                    Album = album, 
                    Photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == photo) 
                });

            await _context.AlbumPhotos.AddRangeAsync(apRange);
        }
    }
}
