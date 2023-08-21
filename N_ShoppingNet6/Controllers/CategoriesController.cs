using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_ShoppingNet6.Entities;

namespace N_ShoppingNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly N_ShoppingContext _context;

        public CategoriesController(N_ShoppingContext ctx) 
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok (_context.Categories.ToList());
        }
    }
}
