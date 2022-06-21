using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NotasWorkshop.Bl.Dtos;
using NotasWorkshop.Model.Contexts.NotasWorkshop;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Services.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace NotasWorkshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly NotasWorkshopDbContext Context;
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _accessor;

        public AuthController(IConfiguration configuration, NotasWorkshopDbContext context, IUserService service, IHttpContextAccessor accessor)
        {
            _configuration = configuration;
            _service = service;
            _accessor = accessor;
            Context = context;
        }
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> RegisterUser(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.Id = request.Id.Value;
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.Gender = request.Gender;
            user.PasswordHash = PasswordSalt;
            user.PasswordSalt = PasswordHash;
            PostUser(user);
            return Ok(user);
        }
        private User PostUser(User user)
        {

            var userFromService = _service.CreateUser(user);
            return userFromService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await Context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int Id)
        {
            var user = await Context.Users.FindAsync(Id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            var userFind = _service.GetAllUsers().Where(x => x.Username == request.Username && x.Password == request.Password).FirstOrDefault();

            if (userFind is null)
            {
                return BadRequest("User not found.");
            }

            string token = CreateToken(userFind);

            return Ok(token);
        }
        [HttpPut("{id}"),Authorize(Roles="Admin")]
        public async Task<ActionResult<List<User>>> UpdateUsers(int id, [FromForm] UserDto request)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");
            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.Gender = request.Gender;
            user.UserRoles = request.UserRoles;
            user.PasswordHash = PasswordSalt;
            user.PasswordSalt = PasswordHash;
            await Context.SaveChangesAsync();
            return Ok(await Context.Users.ToListAsync());
        }
        [HttpDelete("{id}"),Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(await Context.Users.ToListAsync());
        }
        [HttpPost("AddRolesWithAdmin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] PasswordSalt);
            user.Id = request.Id.Value;
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Username = request.Username;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.Gender = request.Gender;
            user.UserRoles = request.UserRoles;
            user.PasswordHash = PasswordSalt;
            user.PasswordSalt = PasswordHash;
            PostUser(user);
            return Ok(user);
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new  Claim ( ClaimTypes .Name , user .Username ) ,
                new Claim(ClaimTypes.Role, user.UserRoles.ToString()),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettingss:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordHash = hmac.Key;
                PasswordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        private bool VerifyPasswordHasd(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computeHash.SequenceEqual(PasswordHash);
            }
        }
    }
}
