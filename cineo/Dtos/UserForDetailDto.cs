using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Dtos
{
    public class UserForDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Premission { get; set; } = 1;
    }
}
