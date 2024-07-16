using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/")]
    public class Main : ControllerBase
    {

        private readonly DataContext _context;

        public Main(DataContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "urls")]
        public ActionResult postUrls()
        {
            var response = _context.GetUrls();
            Console.WriteLine(response);
            return StatusCode(200, response);
        }
    }
}
