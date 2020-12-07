using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class UserRegisterModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
    }
}
