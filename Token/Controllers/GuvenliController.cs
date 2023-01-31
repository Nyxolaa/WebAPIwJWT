using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Token.Models;
using Token.Models.JWT;

namespace Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GuvenliController : ControllerBase
    {
        KitapDbContext _db;

        IJWT _jwt;
        public GuvenliController(KitapDbContext db, IJWT jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Kitaplars.ToList());
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post(Login login)
        {
            string token = _jwt.Authenticate(login.UserName, login.Password);
            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}
