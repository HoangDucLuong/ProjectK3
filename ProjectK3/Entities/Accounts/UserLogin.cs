using System.ComponentModel.DataAnnotations;

namespace ProjectK3.Entities.Accounts;

public class UserLogin
{
    [Required]
    public string UserName { get; set; }
    [Required, EmailAddress]
    public string Email {  get; set; }
    [Required]
    public string Password { get; set; }
}
