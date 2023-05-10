using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum Color
	{
		Red,
		Blue,
		Beige,
		DarkBlue,
		Black
	}
}
