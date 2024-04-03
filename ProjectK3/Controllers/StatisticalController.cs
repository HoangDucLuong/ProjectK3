using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectK3.Entities;
using ProjectK3.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectK3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        private readonly ProjectK3Context _context;

        public StatisticalController(ProjectK3Context context)
        {
            _context = context;
        }

        // GET: api/Statistical
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statistical>>> GetStatistics()
        {
            // Thực hiện truy vấn để lấy thông tin thống kê
            var statistics = await _context.Orders
                .Select(order => new Statistical
                {
                    UserId = order.UserId,
                    Username = order.User.Username,
                    OrderId = order.OrderId,
                    ProductId = order.ProductId,
                    OrderDate = order.OrderDate,
                    DeliveryType = order.DeliveryType
                })
                .ToListAsync();

            return statistics;
        }

        // GET: api/Statistical/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statistical>> GetStatistical(int id)
        {
            // Thực hiện truy vấn để lấy thông tin thống kê dựa trên OrderId
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var statistical = new Statistical
            {
                UserId = order.UserId,
                Username = order.User?.Username,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                OrderDate = order.OrderDate,
                DeliveryType = order.DeliveryType
            };

            return statistical;
        }
    }
}
