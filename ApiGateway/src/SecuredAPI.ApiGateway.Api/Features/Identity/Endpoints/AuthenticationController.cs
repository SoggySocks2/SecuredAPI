using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecuredAPI.ApiGateway.Api.Features.Identity.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController()
        {

        }

        /// <summary>
        /// Authenticate and generate a new JWT
        /// </summary>
        /// <returns>JWT</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetTokenAsync([FromBody] AuthenticationModel authenticationModel, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (authenticationModel == null) return BadRequest($"{nameof(authenticationModel)} is required");

            var tokenHandler = new JwtSecurityTokenHandler();
            //var encryptionKey = configuration.GetValue<string>("JWTEncryptionKey");
            var key = Encoding.ASCII.GetBytes("My JWT Encryption Key");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.NameIdentifier, "123"),
                            new Claim(ClaimTypes.Name, $"Peter Jones"),
                            //new Claim(ClaimTypes.Role, "Admin"),
                            new Claim(ClaimTypes.Role, "GlobalAdmin")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
}
