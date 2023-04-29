using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class FavouritesEntity
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        public ProductEntity Product { get; set; }
    }
}
