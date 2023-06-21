using sistemaServer.Enums;
using System.ComponentModel.DataAnnotations;

namespace sistemaServer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public string? Cpf { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public DateTime? dateCad { get; set; }
        public string? Wage { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
