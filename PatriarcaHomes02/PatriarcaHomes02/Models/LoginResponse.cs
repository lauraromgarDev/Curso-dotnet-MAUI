using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace PatriarcaHomes02.Models
{
    public class LoginResponse
    {

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }


    }
}
