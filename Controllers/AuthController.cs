using System;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSiva.Data;
using WebApiSiva.Models;
using WebApiSiva.Dtos;
using WebApiSiva.Entities;
using System.Linq;

namespace WebApiSiva.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly GTDbContext _context;
        public AuthController(IAuthRepository repo, IConfiguration config, GTDbContext context)
        {
            _repo = repo;
            _config = config;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForRegisterDto)
        {
            var userFromRepo = await _repo.Login(userForRegisterDto.Email.ToLower(), userForRegisterDto.Password);
            if (userFromRepo == null) //User login failed
                return Unauthorized();

            //generate token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tokenCreated);

            return Ok(new { token });
        }

        [HttpPost("register")] //<host>/api/auth/register
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {   // Data Transfer Object containing username and password.
            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            userForRegisterDto.Email = userForRegisterDto.Email.ToLower(); //Convert username to lower case before storing in database.

            if (await _repo.UserExists(userForRegisterDto.Email))
                return BadRequest("Email is already taken.");

            var userToCreate = new User
            {
                Email = userForRegisterDto.Email
            };

            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpGet("clientexists/{numclient}/{email}")] //<host>/api/auth/clientexists/?numclient=190311100051 or "/clientexists/?email=xxx@xxx.com
        public async Task<IActionResult> ClientExists(string numclient, string email)
        {
          
            object Cliente = null;

            if (numclient != null && email != null)
            {
                Cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.NumCliente == numclient);     
                   
                if(Cliente != null)
                return Ok();
                else
                return BadRequest("El cliente no existe!");
  

            }
            else 
            {
                return BadRequest("Faltan Parametros!");
            }
        }
    }
}