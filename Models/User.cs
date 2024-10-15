using System.ComponentModel.DataAnnotations;

namespace Backend.Models;
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [RegularExpression(@"\d{3}\.\d{3}\.\d{3}-\d{2}", ErrorMessage = "Formato de CPF inválido. Use xxx.xxx.xxx-xx.")]
    public string? CPF { get; set; }

    [Required(ErrorMessage = "O email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [StringLength(100, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.", MinimumLength = 8)]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#\\$%\\^&\\*])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "A senha deve conter no mínimo 8 caracteres, incluindo letras maiúsculas e minúsculas, números e caracteres especiais.")]
    public string? Senha { get; set; }


}