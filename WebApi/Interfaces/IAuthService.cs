using WebApi.Models.Schemas;

namespace WebApi.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(CustomerLoginSchema schema);
        Task<bool> RegisterAsync(CustomerRegisterSchema schema);
    }
}