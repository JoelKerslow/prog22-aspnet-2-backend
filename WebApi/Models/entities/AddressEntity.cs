using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

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
    public int CustomerProfileId { get; set; }
    [Required]
    public CustomerProfileEntity CustomerProfile { get; set; } = null!;
}
