using Microsoft.AspNetCore.Http;
using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.ViewModels
{
    public class PhotosEditorViewModel
    {
        public Photo Photo { get; set; }
        [Display(Name = "Фотография")]
        public IFormFile PhotoFile { get; set; }
    }
}
