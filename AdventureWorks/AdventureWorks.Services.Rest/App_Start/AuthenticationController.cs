using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationController : ControllerBase
    {
        private readonly IPersonService personService;

        private IConfiguration Configuration { get; }

        public AuthenticationController(IConfiguration configuration, IPersonService personService)
        {
            Configuration = configuration;
            this.personService = personService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authentication")]
        public ActionResult Authenticate([FromBody]Credentials credentials)
        {
            Output authResult = personService.Authenticate(new Services.Credentials()
            {
                Email = credentials.Username,
                Password = credentials.Password
            });
            if (authResult.Messages.HasErrors())
                return StatusCode((int)authResult.HttpStatus, authResult);

            Output<PersonInfo> info = personService.Read(credentials.Username);
            if (info.Messages.HasErrors())
                return StatusCode((int)authResult.HttpStatus, new Output(info.Messages));

            ClaimsIdentity identity = SecurityManager.CreateIdentity("password", info.Result);

            // generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>(Startup.ConfigJwtKey));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenStr = tokenHandler.WriteToken(token);

            return Ok(new Output<string>(null, tokenStr));
        }
    }
}
