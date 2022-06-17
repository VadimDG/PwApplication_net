using Newtonsoft.Json;

namespace TestWebApi.Dto
{
    public class UserBySession
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
