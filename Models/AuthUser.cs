using System.ComponentModel.DataAnnotations;


namespace Backend.Models
{
    public class AuthUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
