using Microsoft.AspNetCore.Mvc;
using Perfume.DTOs;
using Perfume.Models;
using Perfume.Services;
using Microsoft.AspNetCore.Identity;


namespace Perfume.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SingInManager<AppUser> _singInManager;
        private readonly TokenService _tokenService;

        public AuthController(
            UserManager<AppUser> userManager,
            SingInManager<AppUser> singInManager,
            TokenService tokenService)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new AppUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.Name + dto.Surname,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeed) return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "User");

            return Ok(new { message = "Kayıt Başarılı" });

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return Unauthorized("Geçersiz bilgiler");

            var result = await _singInManager.CheckPasswordSignInAsync(user, dto.Password, lockoutOnFailure: false);

            if(!result.Succeed) return Unauthorized("Geçersiz bilgiler");

            var roles = await _userManager.GetRolesAsync(user);
            var token = await _tokenService.CreateToken(user, roles);

            return Ok(new AuthResponseDto{
                token = token,
                Email = user.Email!,
                Roles = roles,
                FullName = user.Name + " "+  user.Surname,
                ExpriesAt = DateTime.UtcNow.AddHours(24)
            });

        }

    }
}
