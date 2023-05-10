using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum Size
	{
		XS,
		S,
		M,
		L,
		XL,
		XXL
	}
}
