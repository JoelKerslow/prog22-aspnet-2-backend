using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Helpers.Services;

public class JwtService
{
	private readonly IConfiguration _config;

	public JwtService(IConfiguration config)
	{
		_config = config;
	}

	public string Generate(ClaimsIdentity claimsIdentity, DateTime expiresAt)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenDescriptor = new SecurityTokenDescriptor()
		{
			Issuer = _config.GetSection("TokenValidation").GetValue<string>("ValidIssuer"),
			Audience = _config.GetSection("TokenValidation").GetValue<string>("ValidAudience"),
			Subject = claimsIdentity,
			Expires = expiresAt,
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("TokenValidation").GetValue<string>("SecretKey")!)),
				SecurityAlgorithms.HmacSha512Signature
			)
		};

		return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
	}

	public string GetIdFromToken(string token)
	{
		try
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtToken = tokenHandler.ReadJwtToken(token);

			var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "id");

			if (idClaim != null)
			{
				return idClaim.Value;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		return null!;
	}

    public string GetEmailFromToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "email");

            if (idClaim != null)
            {
                return idClaim.Value;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null!;
    }

    public string GetNameFromToken(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var idClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "name");

            if (idClaim != null)
            {
                return idClaim.Value;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null!;
    }
}
