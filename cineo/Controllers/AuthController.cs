﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cineo.Data;
using cineo.Dtos;
using cineo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cineo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _config;
        // private readonly IMapper _mapper;

        public AuthController(IAuthRepository repository, IConfiguration config)
        {

            _config = config;
            _repository = repository;
        }
        // [HttpGet] – pobieranie wartości
        // [HttpPut] – edycja rekordu 
        // [HttpDelete] – usuwanie rekordu

        // [HttpPost] – tworzymy rekord
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {


            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repository.UserExists(userForRegisterDto.Username))
                return BadRequest("Username already exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repository.Register(userToCreate, userForRegisterDto.Password);

            // var userToReturn = _mapper.Map<UserForDetailDto>(createdUser);

            //return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id}, userToReturn); 
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepository = await _repository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepository == null)
                return Unauthorized();

            //  zmienna do przechowywania danych
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepository.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepository.Username)
            };

            // generowanie naszego klucza (super secret key) w appsettings.json
            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("AppSettings:Token").Value));

            // sposób mieszania danych 
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Deskryptor – identyfikator pliku
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            // obsługa tokena
            var tokenHandler = new JwtSecurityTokenHandler();

            // utworzenie tokena
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // var user = _mapper.Map<UserForListDto>(userFromRepository);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),

            });
        }
    }
}
