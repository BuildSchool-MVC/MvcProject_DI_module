using System;

namespace WebApplication.Models
{
    public class SignupModel
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
    }
}