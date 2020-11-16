using System;
using System.Security.Claims;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Options;
using VentaReal.API.Common.tools;
using VentaReal.API.Data;
using VentaReal.API.Models.Request;
using VentaReal.API.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using VentaReal.API.Models.Entities;

namespace VentaReal.API.Service
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private VentaRealContext _dbContext;
        
        public UserService(VentaRealContext DbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = DbContext;
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();

            using ( var db =  _dbContext)
            {
                string password = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuario.Where( user => 
                                                user.Correo     == model.Correo  &&
                                                user.password   == password ).FirstOrDefault();
                
                if(usuario == null) return null;
                userResponse.Correo = usuario.Correo;
                userResponse.Token  = GetToken(usuario);
            }

            return userResponse;
        }

        private string GetToken(Usuario model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim( ClaimTypes.NameIdentifier, model.IdUsuario.ToString() ),
                        new Claim(ClaimTypes.Email, model.Correo)
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials
                ( 
                    new SymmetricSecurityKey(llave),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}