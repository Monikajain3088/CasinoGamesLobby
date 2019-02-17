﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.BAL;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfigurationRoot _configurationRoot;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;


        public AuthController(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }
        [HttpPost, Route("GenerateToken")]
        public IActionResult CreateTokenAsync([FromBody]LoginDTOIn userInfo)
        {
            //var existUser = await  _userManager.FindByNameAsync(userInfo.Email);
            if (userInfo == null)
            {
                return BadRequest("Invalid client request");
            }

            if (LoginHelper.IsValidUser(userInfo))
            {

                //var userClaims = await _userManager.GetClaimsAsync(existUser);

                //var claims = new[]
                //{
                //        new Claim(JwtRegisteredClaimNames.NameId, existUser.Id),
                //        new Claim(JwtRegisteredClaimNames.Sub, existUser.UserName),                       
                //        new Claim(JwtRegisteredClaimNames.Email, existUser.Email)
                //    }.Union(userClaims);

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configurationRoot["JwtSecurityToken:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _configurationRoot["JwtSecurityToken:Issuer"],
                    audience: _configurationRoot["JwtSecurityToken:Audience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
      
    }
}
