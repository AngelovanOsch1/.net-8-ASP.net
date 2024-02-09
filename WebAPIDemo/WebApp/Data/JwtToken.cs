using Newtonsoft.Json;

namespace WebApp.Data
{
    public class JwtToken
    {
        [JsonProperty("access_token")]
        public string? AccesToken {  get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

    }
}
