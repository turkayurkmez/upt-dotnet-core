﻿using System.ComponentModel.DataAnnotations;

namespace eshop.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; } = "https://cdn.dsmcdn.com/ty922/product/media/images/20230530/18/371725042/263518095/1/1_org.jpg";
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }

        public int? StockCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
