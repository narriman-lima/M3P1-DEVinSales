using DevInSales.Context;
using DevInSales.DTOs;
using DevInSales.Enums;
using DevInSales.Models;
using DevInSales.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;

namespace DevInSales.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;

        public AuthenticationController(SqlContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Realiza login por nome do email e senha
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="200">Login efetuado com sucesso.</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="403">Usuário não tem permissão.</response>
        /// <response code="404">Usuário e/ou senha incorreto(s).</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                var user = _context.User.First(x => x.Email.ToLower() == dto.Email.ToLower() && x.Password.ToLower() == dto.Password.ToLower());

                if (user == null) return NotFound("Usuário e/ou senha incorreto(s)");

                var profile = _context.Profile.First(x => x.Id == user.ProfileId);

                var token = TokenService.GenerateToken(user.Name, profile.Role);

                return Ok($"Bem-vindo(a) {user.Name} ao sistema de funcionários DEVinSales! Você possui permissão de {user.Role}. Segue seu token: \n\n" + token);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }

        }
    }
}


