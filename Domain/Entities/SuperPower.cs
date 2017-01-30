using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SuperPower
    {
        public SuperPower()
        {

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Название суперспособности обязательно должно быть указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "В названии суперспособности должно быть не менее 3 и не более 50 символов")]
        [Display(Name = "Суперспособность")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание суперспособности обязательно должно быть указано")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "В названии суперспособности должно быть не менее 10 и не более 200 символов")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Уровень прокачки должен быть указан")]
        [Range(1, 100, ErrorMessage = "Введите число в диапазоне от 1 до 100")]
        [Display(Name = "Прокачка")]
        public int Rating { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Супергерой")]
        public int? SuperHeroId { get; set; }
        public virtual SuperHero SuperHero { get; set; }
    }
}
