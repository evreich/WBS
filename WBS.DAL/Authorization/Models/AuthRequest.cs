﻿using Newtonsoft.Json;

namespace WBS.DAL.Authorization.Models
{
    public class AuthRequest
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
