using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class ShowcaseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Offer { get; set; } = null!;

        public string ImgUrl { get; set; } = null!;
    }
}
