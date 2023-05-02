using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class ShowcaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }=null!;

        public string Offer { get; set; }=null!;

        public string ImgUrl { get; set; }=null!;
    }
}
