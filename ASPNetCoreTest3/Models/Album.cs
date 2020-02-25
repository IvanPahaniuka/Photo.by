using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASPNetCoreTest3.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Название не указанно")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата")]
        [Required(ErrorMessage = "Дата не указанна")]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
