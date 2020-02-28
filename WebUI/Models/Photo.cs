using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Portfolio.WebUI.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Display(Name = "Изображение")]
        public string Source { get; set; }

        [Display(Name = "Изображение в низком качестве")]
        public string LowSource { get; set; }

        [Display(Name = "Название")]
        [Required (ErrorMessage = "Название не указано")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Число проголосовавших")]
        [Required (ErrorMessage = "Число проголосовавших не указано")]
        public uint VotersCount { get; set; }

        [Display(Name = "Суммарный рейтинг")]
        [Required (ErrorMessage = "Суммарный рейтинг не указан")]
        public uint RatingSum { get; set; }
    }
}
