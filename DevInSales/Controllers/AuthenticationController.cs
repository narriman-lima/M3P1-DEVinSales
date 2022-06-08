using DevInSales.DTOs;
using DevInSales.Enums;
using DevInSales.Models;
using DevInSales.Repositories;
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
        /// <summary>
        /// Realiza login por nome do usuário e senha
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="200">Login efetuado com sucesso.</response>
        /// <response code="404">Usuário e/ou senha incorreto(s).</response>
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var user = UserRepository.VerificarUsuarioESenha(dto.Username, dto.Password);

            if (user == null) return NotFound("Usuário e/ou senha incorreto(s)");

            var token = TokenService.GenerateToken(user);

            return Ok($"Bem-vindo(a) {dto.Username} ao sistema de funcionários DEVinSales.\nEste é seu token: \n\n" + token);

        }

        /// <summary>
        /// Lista os usuários cadastrados para facilitar o acesso à informações para login
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Lista de usuários encontrada.</response>
        /// <response code="404">Lista não encontrada.</response>
        [Route("funcionarios")]
        [HttpGet]
        public IActionResult ListarUsuarios()
        => User.IsInRole(Permissoes.Usuario.GetDisplayName())
        ? Ok(UserRepository.ListarUsuarios().Select(x => new { x.Name, x.DescricaoPermissao }))
        : Ok(UserRepository.ListarUsuarios());
    }
}


