﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Xomega.Framework;
using Xomega.Framework.Services;

namespace AdventureWorks.Services.Rest
{
    public class AuthenticationController : TokenAuthController
    {
        public class Credentials
        {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }
        }

        private readonly IPersonService personService;

        public AuthenticationController(ErrorList errorList, ErrorParser errorParser,
            IOptionsMonitor<AuthConfig> configOptions, IPersonService personService)
            : base(errorList, errorParser, configOptions)
        {
            this.personService = personService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authentication")]
        public async Task<ActionResult> AuthenticateAsync([FromBody]Credentials credentials, CancellationToken token)
        {
            try
            {
                if (!ModelState.IsValid)
                    currentErrors.AddModelErrors(ModelState);
                currentErrors.AbortIfHasErrors();

                ClaimsIdentity identity = new ClaimsIdentity();
                await personService.AuthenticateAsync(new Services.Credentials()
                {
                    Email = credentials.Username,
                    Password = credentials.Password
                });
                var info = await personService.ReadAsync(credentials.Username);
                identity = SecurityManager.CreateIdentity(JwtBearerDefaults.AuthenticationScheme, info.Result);

                // generate jwt token
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                string jwtToken = GetSecurityToken(identity, jwtTokenHandler);
                return StatusCode((int)currentErrors.HttpStatus, new Output<string>(currentErrors, jwtToken));
            }
            catch (Exception ex)
            {
                currentErrors.MergeWith(errorsParser.FromException(ex));
            }
            return StatusCode((int)currentErrors.HttpStatus, new Output(currentErrors));
        }
    }
}
