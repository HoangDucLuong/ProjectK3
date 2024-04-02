using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectK3.Entities;
using ProjectK3.Entities.Accounts;
using ProjectK3.Entities.Emails;
using ProjectK3.Repositories.IServices;

namespace ProjectK3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAcountService _acountService;
    private readonly IMailService _mail;

    private readonly ProjectK3Context _context;
    public static User userDetial = new User();

    public AuthController(IConfiguration configuration, IAcountService acountService, IMailService mail, ProjectK3Context context)
    {
        _configuration = configuration;
        _acountService = acountService;
        _mail = mail;
        _context = context;
    }

    [HttpGet, Authorize]
    public ActionResult<string> GetMe()
    {
        var userName = _acountService.GetMyName();
        return Ok(userName);
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> GetUserByMail(string email)
    {
        try
        {
            var user = await _context.Users.Include(u => u.Status).FirstOrDefaultAsync(i => i.Email == email);
            return StatusCode(StatusCodes.Status200OK, user);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No user found for mail: {email}");
        }
    }

    [HttpPost("signUp")]
    public async Task<ActionResult<User>> SignUp(UserRegister login)
    {
        if (_context.Users.Any(u  => u.Email == login.Email))
        {
            return BadRequest("User already exists");
        }
        var user = new User
        {
            Email = login.Email,
            Address = login.Address,
            Username = login.Username,
            Password = login.Password

        };
        _context.Users.Add(user);
       // await _context.SaveChangesAsync();
        
        var mailVerify = new WelcomeMail
        {
            To = user.Email,
            From = "khandy38@gmail.com",
            DisplayName = "ProjectK3",

            Subject = "Verify Mail",
            Body = "Hello",
        };
        _mail.SendAsync(mailVerify, default);
        return Ok("User successfully created!");
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserLogin login)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
        if (user == null)
        {
            return BadRequest("User not found.");
        }
        if (user.Email != login.Email)
        {
            return BadRequest($"Failed to login {user.Email}");
        }
        return Ok();
    }
}
