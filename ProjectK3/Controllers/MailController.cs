﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectK3.Entities.Emails;
using ProjectK3.Repositories.IServices;

namespace ProjectK3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MailController : ControllerBase
{
    private readonly IMailService _mail;

    public MailController(IMailService mail)
    {
        _mail = mail;
    }

    [HttpPost("sendmail")]
    public async Task<IActionResult> SendMailAsync
        (MailData mailData)
    {
        bool result = await _mail.SendAsync(mailData, new CancellationToken());

        if (result)
        {
            return StatusCode(StatusCodes.Status200OK, "Mail has successfully been sent.");
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occured. The Mail could not be sent.");
        }
    }
}
