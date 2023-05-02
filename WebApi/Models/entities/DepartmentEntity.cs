using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities;

public class DepartmentEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!; 

    
}
