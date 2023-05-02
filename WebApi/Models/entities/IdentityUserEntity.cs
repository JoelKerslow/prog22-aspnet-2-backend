using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class IdentityUserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }=null!; 
        [Required]
        public string Email { get; set; }=null!; 
        [Required]
        public string Password { get; set; }=null!; 
    }
}
