using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApi.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly CustomerProfileService _customerProfileService;
    private readonly JwtService _jwtService;

    public AuthService(UserManager<IdentityUser> userManager, CustomerProfileService customerProfileService, SignInManager<IdentityUser> signInManager, JwtService jwtService)
    {
        _userManager = userManager;
        _customerProfileService = customerProfileService;
        _signInManager = signInManager;
        _jwtService = jwtService;
    }

    public async Task<bool> RegisterAsync(CustomerRegisterSchema schema)
    {
        var identityResult = await _userManager.CreateAsync(schema, schema.Password);
        if (identityResult.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(schema.Email);
            var customerProfileEntity = await _customerProfileService.CreateAsync(schema, user!.Id);

            if (customerProfileEntity != null)
                return true;

            await _userManager.DeleteAsync(user);
        }

        return false;
    }

    public async Task<string> LoginAsync(CustomerLoginSchema schema)
    {
        var identityUser = await _userManager.FindByEmailAsync(schema.Email);
        if (identityUser != null)
        {
            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, schema.Password, false);
            if (signInResult.Succeeded)
            {
                var claimsIdentity = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", identityUser.Id),
                    new Claim(ClaimTypes.Name, identityUser.Email!)
                });

                return _jwtService.Generate(claimsIdentity, DateTime.Now.AddDays(1));
            }
        }

        return string.Empty;
    }
}
