using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;

namespace WebApi.Models.Entities;

public class ShowcaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Offer { get; set; } = null!;

    [Required]  
    public string ImgUrl { get; set; } = null!;

    public static implicit operator ShowcaseDto(ShowcaseEntity entity)
    {
        return new ShowcaseDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Offer = entity.Offer,
            ImgUrl = entity.ImgUrl,
        };
    }
}
