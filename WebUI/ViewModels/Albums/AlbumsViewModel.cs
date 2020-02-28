using Portfolio.WebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.ViewModels
{
    public class AlbumsViewModel
    {
        public Album Album { get; set; }
        public List<int> Photos { get; set; }
        public List<Photo> AllPhotos { get; set; }
    }
}
