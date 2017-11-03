using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinskNews.Models
{
    public class News
    {
        [HiddenInput]
        public int Id { get; set; }

        [MaxLength(200)]
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Введите дату")]
        [Display(Name = "Дата")]
        public DateTime AddDate { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Заполните поле")]
        public string ShortDescription { get; set; }

        [Display(Name = "Полное описание")]
        [Required(ErrorMessage = "Заполните поле")]
        public string FullText { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }

        [ScaffoldColumn(false)]
        public string MineType { get; set; }

    }
}