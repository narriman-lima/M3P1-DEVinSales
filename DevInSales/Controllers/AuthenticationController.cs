﻿using DevInSales.DTOs;
using DevInSales.Models;
using DevInSales.Repositories;
using DevInSales.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DevInSales.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var user = UserRepository.VerificarUsuarioESenha(dto.Username, dto.Password);

            if (user == null) return NotFound("Usuário e/ou senha incorreto(s)");

            var token = TokenService.GenerateToken(user);

            return Ok(token);

        }
    }
}


