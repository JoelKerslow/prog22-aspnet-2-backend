﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class OrderReviewEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!; 
    }
}
