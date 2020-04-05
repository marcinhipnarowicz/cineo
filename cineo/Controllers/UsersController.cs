
using AutoMapper;
using cineo.Data;
using cineo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cineo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetUser")] // Pobieranie wartości
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }

        [HttpGet("me")] // Pobieranie wartości
        public async Task<IActionResult> GetMyInfo()
        {
            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = await _userRepository.GetUser(currentUserId);

            var userToReturn = _mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }



        [HttpPut("{id}")] // Aktualizacja wartości
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            

            // tylko zalogowany użytkownik może edytować swój profil

            var userFromRepository = await _userRepository.GetUser(id);

            _mapper.Map(userForUpdateDto, userFromRepository);

            if (await _userRepository.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");

        }

    }
}