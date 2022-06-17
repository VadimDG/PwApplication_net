using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static TestWebApi.Dto.UserValidators;

namespace TestWebApi.Dto
{
    public class User
    {
        [JsonProperty("username")]
        [Required(ErrorMessage = "User name is required")]
        [HumanReadableName]
        public string UserName { get; set; }
        [JsonProperty("password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [JsonProperty("email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "incorrect format of email")]
        public string Email { get; set; }
    }
}
