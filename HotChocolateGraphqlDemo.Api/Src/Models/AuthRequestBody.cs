using System.ComponentModel.DataAnnotations;

namespace HotChocolateGraphqlDemo.Api.Src.Models
{
    public enum EnumGrantType
    {
        password,
        refresh_token
    }

    public class AuthRequestBody
    {
        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        [Required]
        public string GrantType { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public string Username { get; set; }
    }
}
