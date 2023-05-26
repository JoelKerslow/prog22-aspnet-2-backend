using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class AddressSchema
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Addressline1 { get; set; } = null!;

        public string? Addressline2 { get; set; }

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Icon { get; set; } = null!;

        [Required]
        public int CustomerProfileId { get; set; }

        public static implicit operator AddressEntity(AddressSchema schema)
        {
            return new AddressEntity()
            {
                Title = schema.Title,
                Addressline1 = schema.Addressline1,
                Addressline2 = schema.Addressline2,
                PostalCode = schema.PostalCode,
                City = schema.City,
                Country = schema.Country,
                Icon = schema.Icon,
                CustomerProfileId = schema.CustomerProfileId,
            };
        }
    }
}
