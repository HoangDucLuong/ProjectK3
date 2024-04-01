using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectK3.Repositories.IServices;

namespace ProjectK3.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IDashboard _dashboard;

    public DashboardController(IDashboard dashboard)
    {
        _dashboard = dashboard;
    }

    [HttpGet]
    public async Task<IActionResult> GetStatisticalItems()
    {
        var statisticalItems = await _dashboard.GetStatisticals();
        if (statisticalItems == null)
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }
        return StatusCode(StatusCodes.Status200OK, statisticalItems);
    }
}
