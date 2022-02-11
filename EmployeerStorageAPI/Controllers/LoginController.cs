using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Enums;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EmployeerStorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;

        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _config = configuration;
        }

        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = UserRole.User
            };

            _userService.Add(user);
            _userService.SaveChanges();

            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] UserDto request)
        {
            var user = _userService.Get(x => x.Username == request.Username); // Perfomance?
            if (user == null
                || user.Role == UserRole.Ban
                || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Results.Unauthorized();
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRole), user.Role))
            };
            var validTime = DateTime.UtcNow.Add(TimeSpan.FromMinutes(60));
            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: validTime,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value)), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = user.Username,
                valid_to = validTime.ToLongDateString() + " " + validTime.ToLongTimeString(),
            };

            return Results.Json(response);
        }

        [HttpGet("ban/{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> BlockUser(Guid id)
        {
            var user = _userService.Get(x => x.Id == id);
            if (user == null) 
                return NotFound();

            if (_userService.BanUser(id))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }


        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
