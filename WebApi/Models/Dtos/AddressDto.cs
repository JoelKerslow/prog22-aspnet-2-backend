using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Addressline1 { get; set; } = null!;
        public string? Addressline2 { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int CustomerProfileId { get; set; }
    }
}
