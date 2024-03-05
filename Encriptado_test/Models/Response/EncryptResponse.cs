namespace Encriptado_test.Models.Response
{
    public class EncryptResponse
    {
        public string Password { get; set; } = String.Empty;
        public string EncryptPassword { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string PasswordWithSalt { get; set; } = String.Empty;
    }
}
