using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class OrderEntity
{

    [Key]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public CustomerProfileEntity Customer { get; set; } = null!; 

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public decimal TotalAmount { get; set; }

    public string? CustomerComment { get; set; }

    public int? PromoCodeId { get; set; }
    public PromoCodeEntity? PromoCode { get; set; }


    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();

}