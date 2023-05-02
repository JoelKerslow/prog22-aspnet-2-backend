using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class OrderEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public CustomerProfileEntity Customer { get; set; }=null!; 

        [Required]
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }=null!;

        [Required]
        public decimal TotalAmount { get; set; }

        public string Comments { get; set; }=null!;

        [ForeignKey("ProductOrderDetailId")]
        public ProductOrderDetailEntity ProductOrderDetail { get; set; }=null!; 

       
    }
}
