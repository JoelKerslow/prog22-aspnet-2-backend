using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class CampaignEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string CampaignName { get; set; } = null!;

    [Required]
    public int DiscountPercent { get; set; }


    public IEnumerable<ProductEntity> CampaignProducts { get; set; } = new List<ProductEntity>();

}
