namespace WebApi.Models.Dtos;

public class CustomerProfileDto
{
	public int Id { get; set; }

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string? ProfileImageUrl { get; set; }

	public string UserId { get; set; } = null!;
}
