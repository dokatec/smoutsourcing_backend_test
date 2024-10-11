using System.ComponentModel.DataAnnotations;

namespace Backend.Models;
public class User
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }


}