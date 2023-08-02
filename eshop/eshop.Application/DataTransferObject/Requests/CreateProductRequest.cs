﻿using System.ComponentModel.DataAnnotations;

namespace eshop.Application.DataTransferObject.Requests
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Ürün adı boş olamaz")]
        [MinLength(2, ErrorMessage = "En az iki harf olmalı")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg";
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }

        public int? StockCount { get; set; }
    }
}
