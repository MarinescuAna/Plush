using System;
using System.Collections.Generic;
using System.Text;

namespace Plush.DataAccessLayer.Domain.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public string AccessTokenExpiration { get; set; }
    }
}
