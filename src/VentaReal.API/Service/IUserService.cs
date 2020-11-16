using VentaReal.API.Models.Request;
using VentaReal.API.Models.Response;

namespace VentaReal.API.Service
{
    public interface IUserService
    {
         UserResponse Auth(AuthRequest model);
    }
}