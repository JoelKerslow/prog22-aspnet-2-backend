using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class CustomerProfileEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public AddressEntity Address { get; set; }

        [Required]
        public int ShippingAddressId { get; set; }

        [ForeignKey("ShippingAddressId")]
        public AddressEntity ShippingAddress { get; set; }

        [Required]
        public int IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public IdentityUser IdentityUser { get; set; }

        [Required]
        public int FavouritesId { get; set; }

        [ForeignKey("FavouritesId")]
        public FavouritesEntity Favourites { get; set; }

    }
}
