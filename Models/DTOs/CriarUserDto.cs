using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_USUARIOS.Models.DTOs
{
    public class CriarUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}