﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class SuperHero
    {
        public SuperHero()
        {
        }
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage ="Имя супергероя обязательно должно быть указано")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "В имени супергероя должно быть не менее 3 и не более 50 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name ="Описание")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual ICollection<SuperPower> SuperPowers { get; set; }
    }
}
