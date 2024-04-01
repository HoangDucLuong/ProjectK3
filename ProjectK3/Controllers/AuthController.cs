using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectK3.Entities;
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
            var user = await _context.Users.Include(u => u.Email).FirstOrDefaultAsync(i => i.Email == email);
            return StatusCode(StatusCodes.Status200OK, user);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, $"No user found for mail: {email}");
        }
    }
}
