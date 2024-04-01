using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectK3.Entities;

namespace ProjectK3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ProjectK3Context _cart;

        public CartController(ProjectK3Context cart)
        {
            _cart = cart;
        }
       
        
    }
}
