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
        /// <summary>
        /// Id новости
        /// </summary>
        [HiddenInput]
        public int Id { get; set; }

        /// <summary>
        /// Заголовок новости
        /// </summary>
        [MaxLength(200)]
        [Display(Name = "Заголовок")]
        [Required(ErrorMessage = "Введите заголовок")]
        public string Title { get; set; }

        /// <summary>
        /// Дата создания новости
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Введите дату")]
        [Display(Name = "Дата")]
        public DateTime AddDate { get; set; }

        /// <summary>
        /// Краткое описание новости
        /// </summary>
        [MaxLength(1000)]
        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Заполните поле")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Полное описание новости
        /// </summary>
        [Display(Name = "Полное описание")]
        [Required(ErrorMessage = "Заполните поле")]
        public string FullText { get; set; }
        
        /// <summary>
        /// Данные изображения
        /// </summary>
        [ScaffoldColumn(false)]
        public byte[] Image { get; set; }

        /// <summary>
        /// Тип данных
        /// </summary>
        [ScaffoldColumn(false)]
        public string MineType { get; set; }

    }
}