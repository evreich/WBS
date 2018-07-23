using Newtonsoft.Json;

namespace WBS.DAL.Authorization.Models
{
    public class TokenRequest
    {
        [JsonProperty("token")]
        public string TokenString { get; set; }
    }
}
