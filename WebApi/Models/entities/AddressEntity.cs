using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
