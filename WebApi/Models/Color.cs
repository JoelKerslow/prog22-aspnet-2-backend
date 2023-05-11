using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum Color
	{
		Yellow,
		Red,
		Blue,
		Green,
		Beige,
		DarkBlue,
		Black,
		White
	}
}
