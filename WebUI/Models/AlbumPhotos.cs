using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WebUI.Models
{
    public class AlbumPhotos
    {
        public int Id { get; set; }

        [Display(Name = "Альбом")]
        [Required(ErrorMessage = "Необходимо указать альбом")]
        public Album Album { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Необходимо указать фото")]
        public Photo Photo { get; set; }
    }
}
