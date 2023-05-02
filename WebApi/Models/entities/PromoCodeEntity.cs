﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class PromoCodeEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = null!;

		public string? Brand { get; set; }

		[Required]
        public decimal Discount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Code { get; set; } = null!;

        [Required]
        public bool IsReusable { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}
