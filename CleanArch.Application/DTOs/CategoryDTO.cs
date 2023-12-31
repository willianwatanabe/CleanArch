﻿using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs
{
    public class CategoryDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }    
    }
}
