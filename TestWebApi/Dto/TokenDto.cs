using Newtonsoft.Json;

namespace TestWebApi.Dto
{
    public class TokenDto
    {
        [JsonProperty("id_token")]
        public string Token { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
