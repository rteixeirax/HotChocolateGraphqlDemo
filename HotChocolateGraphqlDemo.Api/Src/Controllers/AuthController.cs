using HotChocolateGraphqlDemo.Api.Src.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace HotChocolateGraphqlDemo.Api.Src.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }

        [HttpPost("grant")]
        public IActionResult Grant([FromBody] AuthRequestBody body)
        {
            if (body.GrantType == EnumGrantType.password.ToString())
            {
                return Ok(new AuthResponse
                {
                    AccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiracy = "",
                    RefreshToken = Guid.NewGuid().ToString(),
                    RefreshTokenExpiracy = "",
                });
            }

            if (body.GrantType == EnumGrantType.refresh_token.ToString())
            {
                return Ok(new AuthResponse
                {
                    AccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiracy = "",
                    RefreshToken = Guid.NewGuid().ToString(),
                    RefreshTokenExpiracy = "",
                });
            }

            return BadRequest("unsupported_grant_type");
        }
    }
}
