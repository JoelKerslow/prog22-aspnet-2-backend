using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

    public class FavouritesEntity
    {
	[Key]
	public int Id { get; set; }

	public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
