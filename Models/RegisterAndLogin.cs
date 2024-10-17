using System.ComponentModel.DataAnnotations;


namespace Backend.Models
{
    public class Register
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#\\$%\\^&\\*])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "A senha deve conter no mínimo 8 caracteres, incluindo letras maiúsculas e minúsculas, números e caracteres especiais.")]
        public string Password { get; set; }
    }

    public class Login
    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
