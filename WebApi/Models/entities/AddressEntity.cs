using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

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
    public string Icon { get; set; } = null!;

    [Required]
    public int CustomerProfileId { get; set; }
    [Required]
    public CustomerProfileEntity CustomerProfile { get; set; } = null!;

    public static implicit operator AddressDto(AddressEntity entity)
    {
        return new AddressDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Addressline1 = entity.Addressline1,
            Addressline2 = entity.Addressline2,
            PostalCode = entity.PostalCode,
            City = entity.City,
            Country = entity.Country,
            Icon = entity.Icon,
            CustomerProfileId = entity.CustomerProfileId,
        };
    }
}
