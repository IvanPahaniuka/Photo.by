﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreTest3.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace ASPNetCoreTest3.Controllers
{
    public class PhotosController : Controller
    {
        private static Size _lowSize = new Size(300, 300);

        private readonly PhotoContext _context;
        private readonly IHostingEnvironment _environment;

        public PhotosController(PhotoContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Photos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Photos
                .OrderByDescending(p => p.Id)
                .ToListAsync());
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile imageFile,
            [Bind("Id,Source,LowSource,Name,Description,VotersCount,RatingSum")] Photo photo)
        {
            photo.RatingSum = 0;
            photo.VotersCount = 0;


            if (ModelState.IsValid && imageFile != null)
            {
                _context.Add(photo);
                await _context.SaveChangesAsync();

                bool loadingResult = await LoadImage(photo, imageFile);
                if (!loadingResult)
                {
                    _context.Remove(photo);
                    await _context.SaveChangesAsync();
                    return View(photo);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(photo);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }
            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile imageFile,
            [Bind("Id,Source,LowSource,Name,Description,VotersCount,RatingSum")] Photo photo)
        {
            if (id != photo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && 
                System.IO.File.Exists(_environment.WebRootPath + photo.Source) &&
                System.IO.File.Exists(_environment.WebRootPath + photo.LowSource))
            {
                try
                {
                    if (imageFile != null)
                    {
                        bool loadingResult = await LoadImage(photo, imageFile);
                        if (!loadingResult)
                        {
                            return View(photo);
                        }
                    }

                    _context.Update(photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.Id))
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
            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = await _context.Photos.FindAsync(id);

            try
            {
                if (photo?.Source != null)
                {
                    System.IO.File.Delete(_environment.WebRootPath + photo.Source);
                }

                if (photo?.LowSource != null)
                {
                    System.IO.File.Delete(_environment.WebRootPath + photo.LowSource);
                }
            }
            finally
            {
                _context.Photos.Remove(photo);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        private bool PhotoExists(int id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }

        private async Task<bool> LoadImage(Photo photo, IFormFile imageFile)
        {
            if (imageFile == null || photo == null)
                return false;

            int id = photo.Id;
            string extension = Path.GetExtension(imageFile.FileName);
            string path = $"/Files/Images/{id}_temp{extension}";
            string pathLow = $"/Files/Images/{id}c_temp.jpg";

            try
            {

                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }



                Image image = Image.Load(_environment.WebRootPath + path);

                float xscale = _lowSize.Width * 1.0f / image.Width;
                float yscale = _lowSize.Height * 1.0f / image.Height;
                float scale = xscale > yscale ? xscale : yscale;

                image.Mutate(i => i
                    .Resize((int)Math.Ceiling(image.Width * scale),
                            (int)Math.Ceiling(image.Height * scale))
                    .Crop(new Rectangle(
                        (i.GetCurrentSize().Width - _lowSize.Width) >> 1,
                        (i.GetCurrentSize().Height - _lowSize.Height) >> 1,
                        _lowSize.Width, _lowSize.Height)));

                using (var fileStream = new FileStream(_environment.WebRootPath + pathLow, FileMode.Create))
                {
                    image.SaveAsJpeg(fileStream, new JpegEncoder { Quality = 77 });
                }
            }
            catch
            {
                System.IO.File.Delete(_environment.WebRootPath + path);
                System.IO.File.Delete(_environment.WebRootPath + pathLow);
                return false;
            }



            try
            {
                if (photo.Source != null)
                {
                    System.IO.File.Delete(_environment.WebRootPath + photo.Source);
                }

                string newPath = $"/Files/Images/{id}{extension}";
                System.IO.File.Move(
                    _environment.WebRootPath + path,
                    _environment.WebRootPath + newPath);
                path = newPath;
            }
            catch
            {
                path = photo.Source;
            }

            try
            {
                if (photo.LowSource != null)
                {
                    System.IO.File.Delete(_environment.WebRootPath + photo.LowSource);
                }

                string newPathLow = $"/Files/Images/{id}c.jpg";
                System.IO.File.Move(
                    _environment.WebRootPath + pathLow,
                    _environment.WebRootPath + newPathLow);
                pathLow = newPathLow;
            }
            catch
            {
                pathLow = photo.LowSource;
            }


            photo.Source = path;
            photo.LowSource = pathLow;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
