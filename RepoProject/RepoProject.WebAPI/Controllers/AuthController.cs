using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using RepoProject.Core.Entities;
using RepoProject.Core.DTOs;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RepoProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IConfiguration config, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _config = config;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("GetMethod")]
        public async Task<List<User>> GetMethod()
        {
            List<User> users = new List<User>();   
            try
            {
               users = await _userManager.Users.ToListAsync();
               
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex, ex.Message); 
            }
            return users;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDTO)
        {
            try
            {
                var userToCreate = _mapper.Map<UserRegisterDto, User>(userRegisterDTO);
                var result = await _userManager.CreateAsync(userToCreate, userRegisterDTO.Password);
                if (result.Succeeded)
                {
                    return Ok(userToCreate);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLoginDto.UserName);
                if (user == null)
                {
                    return Ok("UserName or Password Wrong");
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);

                if (result.Succeeded)
                {
                    var appUser = _mapper.Map<User, UserListDto>(user);

                    return Ok(new
                    {
                        token = GanerateJwtToken(user).Result,
                        user = appUser
                    });
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

            
        }

        private async Task<string> GanerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
