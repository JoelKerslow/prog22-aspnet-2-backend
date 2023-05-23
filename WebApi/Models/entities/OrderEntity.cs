using System.ComponentModel.DataAnnotations;
using WebApi.Models.Dtos;
using WebApi.Models.entities;

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

    public ICollection<OrderDetailsEntity> OrderDetails { get; set; } = new HashSet<OrderDetailsEntity>();  


    public static implicit operator OrderDto(OrderEntity entity)
    {
        return new OrderDto
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            OrderDate = entity.OrderDate,
            Status = entity.Status,
            TotalAmount = entity.TotalAmount,
            CustomerComment = entity.CustomerComment,
            PromoCodeId = entity.PromoCodeId
        };
    }
}