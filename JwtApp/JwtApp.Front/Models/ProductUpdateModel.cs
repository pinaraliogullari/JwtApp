﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JwtApp.Front.Models
{
    public class ProductUpdateModel
    {
        [Required(ErrorMessage = "Id alanı geçilemez.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ürün adı boş geçilemez.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Stok boş geçilemez.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Fiyat boş geçilemez.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }
    }
}
