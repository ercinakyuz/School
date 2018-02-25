using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using School.Business.Manager;
using School.Model.Dto.Member;

namespace School.Api.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IConfiguration _config;
        private readonly MemberManager _userManager;

        public LoginController(IConfiguration config)
        {
            _userManager = new MemberManager();
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]MemberLoginDto dto)
        {
            IActionResult response = Unauthorized();
            var member = Authenticate(dto);

            if (member != null)
            {
                member.Token = BuildToken(member);
                response = Ok(member);
            }

            return response;
        }

        private string BuildToken(MemberDto member)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Email, member.Email),
                new Claim(JwtRegisteredClaimNames.NameId, member.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private MemberDto Authenticate(MemberLoginDto dto)
        {
            var user = _userManager.GetUser(dto);
            return user;
        }

    }
}