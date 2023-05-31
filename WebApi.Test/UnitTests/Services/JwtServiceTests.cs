using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.Helpers.Services;

namespace WebApi.Test.UnitTests.Services;

public class JwtServiceTests
{
    private readonly JwtService _jwtServiceSUT;
    protected IConfiguration _configuration;

    public JwtServiceTests()
    {
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        _configuration = configBuilder.Build();

        _jwtServiceSUT = new JwtService(_configuration);
    }

    [Fact]
    public void Generate_ReturnsValidJwtToken()
    {
        // Arrange
        var claimsIdentity = new ClaimsIdentity(new[] { new Claim("id", "123") });
        var expiresAt = DateTime.UtcNow.AddDays(1);

        // Act
        var token = _jwtServiceSUT.Generate(claimsIdentity, expiresAt);

        // Assert
        Assert.NotNull(token);
        Assert.NotEmpty(token);

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        Assert.Equal("ManeroApi", jwtToken.Issuer);
        Assert.Equal("ManeroUser", jwtToken.Audiences.First());
        Assert.Equal("123", jwtToken.Claims.FirstOrDefault(claim => claim.Type == "id")?.Value);
    }

    [Fact]
    public void GetIdFromToken_ReturnsIdInToken()
    {
        // Arrange
        var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjA0MzFjYTJlLThjNzEtNDk3Mi1iZjYwLTE3ZGJkZDdiOGI4NCIsInVuaXF1ZV9uYW1lIjoib3NjYXJAbWFpbC5jb20iLCJuYmYiOjE2ODQ4NDI5ODQsImV4cCI6MTY4NDg0NjU4NCwiaWF0IjoxNjg0ODQyOTg0LCJpc3MiOiJNYW5lcm9BcGkiLCJhdWQiOiJNYW5lcm9Vc2VyIn0.YnQUfGuzvF6g9pkEdMtwsCOCObwiyINlJn_1AiiZdRaxfmB6UoiumHqqYqc1_XdjBlIxwGgrqUPdOqcmFg7gFA";

        // Act
        var result = _jwtServiceSUT.GetIdFromToken(token);

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal("0431ca2e-8c71-4972-bf60-17dbdd7b8b84", result);
    }

    [Fact]
    public void GetIdFromToken_ReturnsNullFromInvalidToken()
    {
        // Arrange
        var token = "fisk";
        // Act
        var result = _jwtServiceSUT.GetIdFromToken(token);

        // Assert
        Assert.Null(result);
    }
}
