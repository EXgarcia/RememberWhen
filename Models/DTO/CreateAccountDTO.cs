using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RememberWhen.Models.DTO
{
    public class CreateAccountDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}