using Encriptado_test.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encriptado_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : ControllerBase
    {
        [HttpGet]
        [Route("Encrypt")]
        public EncryptResponse Encrypt(string password)
        {
            try
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                string hashPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

                EncryptResponse response = new()
                {
                    Password = password,
                    EncryptPassword = hashPassword,
                    Salt = salt,
                    PasswordWithSalt = password + salt
                };
                return response;

            } catch
            {
                EncryptResponse response = new();

                return response;

            }
        }

        [HttpPost]
        [Route("Validate")]
        public bool Validate(EncryptResponse modelo)
        {
            return BCrypt.Net.BCrypt.Verify(modelo.Password, modelo.EncryptPassword);
        }
    }
}
