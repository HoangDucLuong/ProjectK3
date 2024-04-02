using System.ComponentModel.DataAnnotations;

namespace ProjectK3.Entities.Accounts;

public class UserRegister
{
    [Required]
    public string Username { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string? Address { get; set; }
}
